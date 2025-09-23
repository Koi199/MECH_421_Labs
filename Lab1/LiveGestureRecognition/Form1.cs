using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LiveGestureRecognition
{
    public partial class Form1 : Form
    {
        // Enhanced accelerometer data structure
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
        }

        // Smoothing and filtering processor
        public class AccelerometerProcessor
        {
            private readonly Queue<AccelerometerReading> _dataHistory;
            private readonly int _smoothingWindowSize;
            private AccelerometerReading _baselineCalibration;

            public float DeadZone { get; set; } = 5.0f;  // Adjusted for your 0-255 range
            public float SmoothingAlpha { get; set; } = 0.3f;
            public int MovingAverageWindow { get; set; } = 5;
            public bool UseMovingAverage { get; set; } = true;
            public bool UseLowPassFilter { get; set; } = true;
            public bool UseDeadZone { get; set; } = true;

            public AccelerometerReading RawData { get; private set; }
            public AccelerometerReading SmoothedData { get; private set; }
            public AccelerometerReading FinalData { get; private set; }

            private AccelerometerReading _previousSmoothed;
            private AccelerometerReading _previousFinal;

            public AccelerometerProcessor(int smoothingWindowSize = 5)
            {
                _smoothingWindowSize = Math.Max(1, smoothingWindowSize);
                _dataHistory = new Queue<AccelerometerReading>(_smoothingWindowSize);
                _baselineCalibration = new AccelerometerReading(127.5f, 127.5f, 127.5f); // Middle of 0-255 range

                RawData = new AccelerometerReading(127.5f, 127.5f, 127.5f);
                SmoothedData = new AccelerometerReading(127.5f, 127.5f, 127.5f);
                FinalData = new AccelerometerReading(127.5f, 127.5f, 127.5f);
                _previousSmoothed = new AccelerometerReading(127.5f, 127.5f, 127.5f);
                _previousFinal = new AccelerometerReading(127.5f, 127.5f, 127.5f);
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

                // Apply smoothing
                SmoothedData = ApplySmoothing(RawData);

                // Apply calibration
                var calibrated = ApplyCalibration(SmoothedData);

                // Apply dead zone
                FinalData = ApplyDeadZone(calibrated);

                // Update previous values
                _previousSmoothed = new AccelerometerReading(SmoothedData.X, SmoothedData.Y, SmoothedData.Z);
                _previousFinal = new AccelerometerReading(FinalData.X, FinalData.Y, FinalData.Z);

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

            private AccelerometerReading ApplyCalibration(AccelerometerReading data)
            {
                return new AccelerometerReading(
                    data.X - _baselineCalibration.X,
                    data.Y - _baselineCalibration.Y,
                    data.Z - _baselineCalibration.Z
                );
            }

            private AccelerometerReading ApplyDeadZone(AccelerometerReading current)
            {
                if (!UseDeadZone)
                    return current;

                float deltaX = Math.Abs(current.X - _previousFinal.X);
                float deltaY = Math.Abs(current.Y - _previousFinal.Y);
                float deltaZ = Math.Abs(current.Z - _previousFinal.Z);

                float newX = deltaX > DeadZone ? current.X : _previousFinal.X;
                float newY = deltaY > DeadZone ? current.Y : _previousFinal.Y;
                float newZ = deltaZ > DeadZone ? current.Z : _previousFinal.Z;

                return new AccelerometerReading(newX, newY, newZ);
            }

            public void Calibrate()
            {
                if (_dataHistory.Count > 0)
                {
                    _baselineCalibration = ApplyMovingAverage();
                }
                else
                {
                    _baselineCalibration = new AccelerometerReading(RawData.X, RawData.Y, RawData.Z);
                }
            }

            public float GetAccelerationMagnitude()
            {
                return (float)Math.Sqrt(FinalData.X * FinalData.X + FinalData.Y * FinalData.Y + FinalData.Z * FinalData.Z);
            }

            public bool DetectThrow(float threshold = 50.0f)
            {
                return GetAccelerationMagnitude() > threshold;
            }
        }


        private string serialDataString = "";
        private Timer myTimer = new Timer();
        private Timer GestureTimeout = new Timer();
        private enum DataStream { LEAD, Ax, Ay, Az };
        private DataStream nextDataStream;
        private int rawAx, rawAy, rawAz;
        private const int x_offset = 127;
        private const int y_offset = 127;
        private const int z_offset = 127;

        // Enhanced with accelerometer processor
        private AccelerometerProcessor accelerometerProcessor;

        private ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Ax = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Ay = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Az = new ConcurrentQueue<Int32>();

        private List<int> gestureBuffer = new List<int>();
        private Queue<String> detectedGestures = new Queue<String>();
        private Queue<String> finalizedGestures = new Queue<String>();

        private const int GESTURE_TIMEOUT_MS = 3000;
        private State CurrentState = 0;
        private bool stateProcessed = false;

        private List<int> Last100Ax = new List<int>();
        private List<int> Last100Ay = new List<int>();
        private List<int> Last100Az = new List<int>();

        // Average calculation variables
        // Calculate start index and count for the slice
        int takeCount;
        int startIndex;
        // Slice using GetRange
        private List<int> last100 = new List<int>();
        // Calculate average
        double avg;


        enum State
        {
            IDLE = 0,
            START,
            GESTUREDETECTED,
            WAITFORMOREGESTURES,
            GESTURECOMPLETED
        }

        enum Gesture
        {
            NONE = 0,
            POS_X, POS_Y, POS_Z, NEG_X, NEG_Y, NEG_Z
        }

        public Form1()
        {
            InitializeComponent();

            // Initialize accelerometer processor
            accelerometerProcessor = new AccelerometerProcessor(smoothingWindowSize: 5);

            // Configure for Pokemon throwing (responsive but not too sensitive)
            accelerometerProcessor.SmoothingAlpha = 0.6f;
            accelerometerProcessor.DeadZone = 3.0f;
            accelerometerProcessor.UseMovingAverage = true;
            accelerometerProcessor.UseLowPassFilter = true;
            accelerometerProcessor.UseDeadZone = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
            {
                comboBoxCOMPorts.Text = "No COM ports!";
            }
            else
            {
                comboBoxCOMPorts.SelectedIndex = 0;
            }

            buttonConnectSerial.Text = "Connect Serial";

            GestureTimeout.Interval = GESTURE_TIMEOUT_MS;
            GestureTimeout.Tick += (s, args) =>
            {
                GestureTimeout.Stop();
            };

            myTimer.Interval = 50; // Increased frequency for smoother game response
            myTimer.Tick += UpdateDataStream;
            myTimer.Start();
        }

        private void UpdateDataStream(object sender, EventArgs e)
        {
            if (serialPort_MSP430.IsOpen)
            {
                textBox_CurrentState.Text = serialPort_MSP430.BytesToRead.ToString();
            }
            textBox_gesturebuffercount.Text = string.Join(", ", finalizedGestures.ToList());
            textBox_DataQSize.Text = dataQueue.Count.ToString();

            while (dataQueue.TryDequeue(out int value))
            {
                textBox_Data.AppendText(value.ToString() + ", ");
                processDataQueue(value);
            }
        }

        private void comboBoxCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCOMPorts.SelectedItem != null)
            {
                serialPort_MSP430.PortName = comboBoxCOMPorts.SelectedItem.ToString();
            }
        }

        private void buttonConnectSerial_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort_MSP430.IsOpen)
                {
                    string transmit = "a";
                    byte[] TxByte = Encoding.Unicode.GetBytes(transmit);

                    serialPort_MSP430.Open();
                    serialPort_MSP430.Write(TxByte, 0, 1);

                    buttonConnectSerial.Text = "Disconnect Serial";
                    comboBoxCOMPorts.Enabled = false;
                    CurrentState = State.START;

                    // Calibrate the accelerometer on connection
                    accelerometerProcessor.Calibrate();
                }
                else
                {
                    string transmit = "z";
                    byte[] TxByte = Encoding.Unicode.GetBytes(transmit);
                    serialPort_MSP430.Write(TxByte, 0, 1);
                    serialPort_MSP430.Close();

                    buttonConnectSerial.Text = "Connect Serial";
                    comboBoxCOMPorts.Enabled = true;
                    CurrentState = State.IDLE;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                if (serialPort_MSP430.IsOpen)
                {
                    buttonConnectSerial.Text = "Disconnect Serial";
                    comboBoxCOMPorts.Enabled = false;
                }
                else
                {
                    buttonConnectSerial.Text = "Connect Serial";
                    comboBoxCOMPorts.Enabled = true;
                }
            }
        }

        private void serialPort_MSP430_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            while (serialPort_MSP430.BytesToRead > 0 && serialPort_MSP430.IsOpen)
            {
                newByte = serialPort_MSP430.ReadByte();
                dataQueue.Enqueue(newByte);
                serialDataString = serialDataString + newByte.ToString() + ", ";
            }
        }

        private void processDataQueue(int value)
        {
            if (value == 255)
            {
                nextDataStream = DataStream.Ax;
            }
            else
            {
                switch (nextDataStream)
                {
                    case DataStream.Ax:
                        dataQueue_Ax.Enqueue(value);
                        rawAx = value;
                        nextDataStream = DataStream.Ay;
                        break;
                    case DataStream.Ay:
                        dataQueue_Ay.Enqueue(value);
                        rawAy = value;
                        nextDataStream = DataStream.Az;
                        break;
                    case DataStream.Az:
                        dataQueue_Az.Enqueue(value);
                        rawAz = value;

                        if (dataQueue_Ax.TryDequeue(out int ax) &&
                            dataQueue_Ay.TryDequeue(out int ay) &&
                            dataQueue_Az.TryDequeue(out int az))
                        {   
                            Last100Ax.Add(ax);
                            Last100Ay.Add(ay);
                            Last100Az.Add(az);

                            // Process through accelerometer processor for smoothing
                            var processedData = accelerometerProcessor.ProcessData(ax, ay, az);

                            // Update display with both raw and processed data
                            textBox_Ax.Text = $"Raw: {ax}";
                            textBox_Ay.Text = $"Raw: {ay}";
                            textBox_Az.Text = $"Raw: {az}";

                            // Use original gesture recognition with raw values
                            gestureBuffer.Add(ax);
                            gestureBuffer.Add(ay);
                            gestureBuffer.Add(az);

                            textBox_Orientation.Text = DetermineOrientation(ax, ay, az);

                            stateMachine();

                        }

                        nextDataStream = DataStream.LEAD;
                        break;
                }

                // Calculate and display averages over 100 data points
                if (Last100Ax.Count >= 100)
                {
                    double minx = (Last100Ax.Min() - x_offset)/25;
                    double maxx = (Last100Ax.Max() - x_offset)/25;
                    textBox_Minx100.Text = minx.ToString();
                    textBox_Maxx100.Text = maxx.ToString();
                    Last100Ax.Clear();
                }
                if (Last100Ay.Count >= 100)
                {
                    double miny = (Last100Ay.Min() - y_offset)/25;
                    double maxy = (Last100Ay.Max() - y_offset)/25;
                    textBox_Miny100.Text = miny.ToString();
                    textBox_Maxy100.Text = maxy.ToString();
                    Last100Ay.Clear();
                }
                if (Last100Az.Count >= 100)
                {
                    double minz = (Last100Az.Min() - z_offset)/25;
                    double maxz = (Last100Az.Max() - z_offset)/25;
                    textBox_Maxz100.Text = maxz.ToString();
                    textBox_Minz100.Text = minz.ToString();

                    Last100Az.Clear();
                }

                if (Last100Ax.Count >= 50 && Last100Ay.Count >= 50 && Last100Az.Count >= 50)
                {
                    double avgx = (Last100Ax.Average() - x_offset)/25;
                    double avgy = (Last100Ay.Average() - y_offset)/25;
                    double avgz = (Last100Az.Average() - z_offset)/25;

                    double magnitude = Math.Sqrt(Math.Pow(avgx, 2) + Math.Pow(avgy, 2) + Math.Pow(avgz, 2));
                    textBox_TotalAcc.Text = magnitude.ToString();

                }

            }
        }


        // Rest of your original methods remain the same...
        private void stateMachine()
        {
            switch (CurrentState)
            {
                case State.IDLE:
                    break;

                case State.START:
                    if (!stateProcessed)
                    {
                        
                        finalizedGestures.Clear();
                        detectedGestures.Clear();
                        stateProcessed = true;
                    }

                    for (int i = 0; i < gestureBuffer.Count; i++)
                    {
                        if ((gestureBuffer[i] > 200) || (gestureBuffer[i] < 45))
                        {
                            CurrentState = State.GESTUREDETECTED;
                            stateProcessed = false;
                            break;
                        }
                    }
                    gestureBuffer.Clear();
                    break;

                case State.GESTUREDETECTED:
                    if (!stateProcessed)
                    {
                        textBox_AssessedGesture.Text = "";
                        MapGesture(gestureBuffer);
                        gestureBuffer.Clear();
                        GestureTimeout.Start();
                        stateProcessed = true;
                    }
                    CurrentState = State.WAITFORMOREGESTURES;
                    stateProcessed = false;
                    break;

                case State.WAITFORMOREGESTURES:
                    for (int i = 0; i < gestureBuffer.Count; i++)
                    {
                        if ((gestureBuffer[i] > 200) || (gestureBuffer[i] < 45))
                        {
                            GestureTimeout.Stop();
                            GestureTimeout.Start();
                            CurrentState = State.GESTUREDETECTED;
                            stateProcessed = false;
                            break;
                        }
                    }
                    gestureBuffer.Clear();

                    if (!GestureTimeout.Enabled)
                    {
                        CurrentState = State.GESTURECOMPLETED;
                        stateProcessed = false;
                    }
                    break;

                case State.GESTURECOMPLETED:
                    if (!stateProcessed)
                    {
                        GestureTimeout.Stop();
                        identifyGesture();
                        stateProcessed = true;
                    }
                    CurrentState = State.START;
                    stateProcessed = false;
                    break;
            }
        }

        // Class-level fields
        private string lastFinalizedGesture = null;
        private DateTime lastGestureTime = DateTime.MinValue;
        private readonly TimeSpan gestureCooldown = TimeSpan.FromMilliseconds(500); // adjust as needed

        private void MapGesture(List<int> list)
        {
            if (list.Count < 3)
            {
                MessageBox.Show("Not enough data to map gesture.");
                CurrentState = State.START;
                return;
            }

            string gesture = null;

            if (list[0] > 248 && list[1] < 150 && list[2] < 170)
                gesture = Gesture.POS_X.ToString();
            //else if (list[0] < 150 && list[1] > 210 && list[2] < 170)
            //    gesture = Gesture.POS_Y.ToString();
            else if (list[0] < 200 && list[1] < 200 && list[2] > 230)
                gesture = Gesture.POS_Z.ToString();
            else if (list[0] < 20 && list[1] > 120 && list[2] > 120)
                gesture = Gesture.NEG_X.ToString();
            //else if (list[0] < 150 && list[1] < 40 && list[2] > 120)
            //    gesture = Gesture.NEG_Y.ToString();
            else if (list[0] < 140 && list[1] < 140 && list[2] < 10)
                gesture = Gesture.NEG_Z.ToString();

            if (gesture != null)
            {
                // Only accept if cooldown has passed OR it's a different gesture
                if (gesture != lastFinalizedGesture ||
                    DateTime.Now - lastGestureTime > gestureCooldown)
                {
                    finalizedGestures.Enqueue(gesture);
                    lastFinalizedGesture = gesture;
                    lastGestureTime = DateTime.Now;
                }
            }
        }

        private void identifyGesture()
        {
            var gestures = finalizedGestures.ToList();

            if (gestures.SequenceEqual(new[] { "NEG_Z" }))
                textBox_AssessedGesture.Text = "Free Fall";
            else if (gestures.SequenceEqual(new[] { "NEG_Z" , "POS_X" }))
                textBox_AssessedGesture.Text = "Grave Digger";
            else if (gestures.SequenceEqual(new[] { "POS_Z", "NEG_X", "POS_X" }))
                textBox_AssessedGesture.Text = "High-Five";
            else
                textBox_AssessedGesture.Text = "unknown move";

            detectedGestures.Clear();
            finalizedGestures.Clear();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            CurrentState = State.START;
            textBox_AssessedGesture.Text = "";
            finalizedGestures.Clear();
        }

        private string DetermineOrientation(int x, int y, int z)
        {
            if (x > 150 && y < 130 && z < 130)
                return "NEG_X is facing up";
            else if (x < 130 && y > 150 && z < 130)
                return "NEG_Y is facing up";
            else if (x < 130 && y < 130 && z > 150)
                return "POS_Z is facing up";
            else if (x < 110 && y > 120 && z > 120)
                return "POS_X is facing up";
            else if (x > 120 && y < 110 && z > 120)
                return "POS_Y is facing up";
            else if (x > 120 && y > 120 && z < 110)
                return "NEG_Z is facing up";
            else
                return "UNKNOWN";
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort_MSP430.IsOpen)
                {
                    e.Cancel = true;
                    this.Enabled = false;
                    this.Enabled = true;
                    e.Cancel = false;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error closing form: " + ex.Message);
            }
        }
    }

    
}