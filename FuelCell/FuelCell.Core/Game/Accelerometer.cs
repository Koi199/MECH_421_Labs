using Microsoft.Xna.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuelCell
{
    /// <summary>
    /// Enhanced accelerometer data structure (adapted from your working code)
    /// </summary>
    public class AccelerometerReading
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public DateTime Timestamp { get; set; }

        public AccelerometerReading(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
            Timestamp = DateTime.Now;
        }

        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }
    }

    /// <summary>
    /// Smoothing and filtering processor (from your working implementation)
    /// </summary>
    public class AccelerometerProcessor
    {
        private readonly Queue<AccelerometerReading> _dataHistory;
        private readonly int _smoothingWindowSize;

        public float SmoothingAlpha { get; set; } = 0.3f;
        public bool UseMovingAverage { get; set; } = true;
        public bool UseLowPassFilter { get; set; } = true;

        public AccelerometerReading RawData { get; private set; }
        public AccelerometerReading SmoothedData { get; private set; }
        public AccelerometerReading FinalData { get; private set; }

        private AccelerometerReading _previousSmoothed;

        public AccelerometerProcessor(int smoothingWindowSize = 5)
        {
            _smoothingWindowSize = Math.Max(1, smoothingWindowSize);
            _dataHistory = new Queue<AccelerometerReading>(_smoothingWindowSize);

            RawData = new AccelerometerReading(127.5f, 127.5f, 127.5f);
            SmoothedData = new AccelerometerReading(127.5f, 127.5f, 127.5f);
            FinalData = new AccelerometerReading(127.5f, 127.5f, 127.5f);
            _previousSmoothed = new AccelerometerReading(127.5f, 127.5f, 127.5f);
        }

        public AccelerometerReading ProcessData(int x, int y, int z)
        {
            // Convert to float and store raw data
            RawData = new AccelerometerReading(x, y, z);

            // Add to history
            _dataHistory.Enqueue(new AccelerometerReading(x, y, z));
            if (_dataHistory.Count > _smoothingWindowSize)
            {
                _dataHistory.Dequeue();
            }

            // Apply smoothing only - skip calibration, use raw values
            SmoothedData = ApplySmoothing(RawData);

            // Use smoothed data directly as final data
            FinalData = SmoothedData;

            // Update previous values
            _previousSmoothed = new AccelerometerReading(SmoothedData.X, SmoothedData.Y, SmoothedData.Z);

            return FinalData;
        }

        private AccelerometerReading ApplyLowPassFilter(AccelerometerReading current)
        {
            float smoothedX = SmoothingAlpha * current.X + (1 - SmoothingAlpha) * _previousSmoothed.X;
            float smoothedY = SmoothingAlpha * current.Y + (1 - SmoothingAlpha) * _previousSmoothed.Y;
            float smoothedZ = SmoothingAlpha * current.Z + (1 - SmoothingAlpha) * _previousSmoothed.Z;

            return new AccelerometerReading(smoothedX, smoothedY, smoothedZ);
        }

        private AccelerometerReading ApplyMovingAverage()
        {
            if (_dataHistory.Count == 0)
                return new AccelerometerReading(127.5f, 127.5f, 127.5f);

            float avgX = _dataHistory.Average(d => d.X);
            float avgY = _dataHistory.Average(d => d.Y);
            float avgZ = _dataHistory.Average(d => d.Z);

            return new AccelerometerReading(avgX, avgY, avgZ);
        }

        private AccelerometerReading ApplySmoothing(AccelerometerReading rawData)
        {
            AccelerometerReading result = rawData;

            if (UseMovingAverage && _dataHistory.Count > 1)
            {
                result = ApplyMovingAverage();
            }

            if (UseLowPassFilter)
            {
                result = ApplyLowPassFilter(result);
            }

            return result;
        }

        public float GetAccelerationMagnitude()
        {
            return (float)Math.Sqrt(FinalData.X * FinalData.X + FinalData.Y * FinalData.Y + FinalData.Z * FinalData.Z);
        }
    }

    /// <summary>
    /// Game-adapted accelerometer input handler using raw values with flat zone
    /// </summary>
    public class AccelerometerInput : IDisposable
    {
        private SerialPort _serialPort;
        private CancellationTokenSource _cts;
        private Task _readerTask;
        private bool _isRunning;

        private Vector3 _currentMovement = Vector3.Zero;
        private float _currentTurn = 0f;

        // Config
        public string PortName { get; set; } = "COM7";
        public int BaudRate { get; set; } = 9600;
        public float FlatZone { get; set; } = 5.0f;

        public bool IsConnected => _serialPort?.IsOpen == true;

        public AccelerometerInput()
        {
            // keep constructor for compatibility
        }

        public bool Initialize()
        {
            try
            {
                _serialPort = new SerialPort(PortName, BaudRate);
                _serialPort.Open();

                _cts = new CancellationTokenSource();
                _isRunning = true;
                _readerTask = Task.Run(() => ReadLoop(_cts.Token));

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Init failed: {ex.Message}");
                return false;
            }
        }

        private void ReadLoop(CancellationToken token)
        {
            int state = 0;
            int ax = 0, ay = 0, az = 0;

            while (_isRunning && !token.IsCancellationRequested)
            {
                try
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        int b = _serialPort.ReadByte();
                        if (b == 255) { state = 1; continue; }

                        switch (state)
                        {
                            case 1: ax = b; state = 2; break;
                            case 2: ay = b; state = 3; break;
                            case 3:
                                az = b;
                                state = 0;
                                UpdateGameMovement(ax, ay, az);
                                break;
                        }
                    }
                    else
                    {
                        Thread.Sleep(1); // yield CPU
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Read error: {ex.Message}");
                }
            }
        }

        private void UpdateGameMovement(int ax, int ay, int az)
        {
            const float neutral = 127.5f;

            float forward = 0f;
            float turn = 0f;

            float xOffset = ax - neutral;
            if (Math.Abs(xOffset) > FlatZone)
                forward = xOffset > 0 ? 1f : -1f;

            float yOffset = ay - neutral;
            if (Math.Abs(yOffset) > FlatZone)
                turn = yOffset > 0 ? 1f : -1f;

            _currentMovement = new Vector3(0f, 0f, forward);
            _currentTurn = turn;
        }

        // --- Public API (unchanged names) ---
        public Vector3 GetMovementVector() => _currentMovement;
        public float GetTurnAmount() => _currentTurn;

        public void Calibrate()
        {
            // No calibration needed for raw values
            System.Diagnostics.Debug.WriteLine("Calibration skipped - using raw values");
        }

        public void Dispose()
        {
            _isRunning = false;
            _cts?.Cancel();
            try { _readerTask?.Wait(500); } catch { }
            _serialPort?.Close();
            _serialPort?.Dispose();
            _cts?.Dispose();
        }
    }
}
