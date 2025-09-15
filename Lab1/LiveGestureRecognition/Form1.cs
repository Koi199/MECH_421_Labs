using System;
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
        private string serialDataString = "";
        private Timer myTimer = new Timer();
        private Timer GestureTimeout = new Timer();
        private enum DataStream { LEAD, Ax, Ay, Az };
        private DataStream nextDataStream;
        private int scaledAx, scaledAy, scaledAz;
        private int rawAx = 0, rawAy = 0, rawAz = 0;
        private const int offsetAx = 126; // Adjust based on calibration
        private const int offsetAy = 127; // Adjust based on calibration
        private const int offsetAz = 127; // Adjust based on calibration

        private ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Ax = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Ay = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Az = new ConcurrentQueue<Int32>();

        private List<int> gestureBuffer = new List<int>();
        private Queue<String> detectedGestures = new Queue<String>();
        private Queue<String> finalizedGestures = new Queue<String>();

        private const int GESTURE_TIMEOUT_MS = 5000; // 2 seconds
        private State CurrentState = 0;
        private bool stateProcessed = false;

        // Define states and gestures
        enum State
        {
            IDLE = 0,
            START,
            GESTUREDETECTED,
            WAITFORMOREGESTURES,
            GESTURECOMPLETED, 
            TESTING
        }
        enum Gesture
        {
            NONE = 0,
            POS_X, POS_Y, POS_Z, NEG_X, NEG_Y, NEG_Z
        }

        public Form1()
        {
            InitializeComponent();

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
                
            // Initialize button text
            buttonConnectSerial.Text = "Connect Serial";

            // Setting up timeout timer
            GestureTimeout.Interval = GESTURE_TIMEOUT_MS; // 5 seconds timeout
            GestureTimeout.Tick += (s, args) =>
            {
                // Handle timeout event
                // For example, reset state or notify user
                GestureTimeout.Stop(); // Stop the timer after timeout
            };

            // Setting up a timer
            myTimer.Interval = 100;// Fires every 100ms
            myTimer.Tick += UpdateDataStream; // Hook up the event
            myTimer.Start(); // Start the timer
        }

        // Timer Tick Event Handler
        private void UpdateDataStream(object sender, EventArgs e)
        {
            textBox_CurrentState.Text = CurrentState.ToString();
            textBox_gesturebuffercount.Text = string.Join(", ", finalizedGestures.ToList());

            // Display contents of queue container
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
                    // Connect to serial port
                    string transmit = "a"; // or "A", both will work 
                    byte[] TxByte = Encoding.Unicode.GetBytes(transmit);

                    serialPort_MSP430.Open();
                    serialPort_MSP430.Write(TxByte, 0, 1);

                    buttonConnectSerial.Text = "Disconnect Serial";
                    comboBoxCOMPorts.Enabled = false; // Disable port selection while connected
                    CurrentState = State.START; // Move to START state
                    //MessageBox.Show("Successfully Connected.");
                }
                else
                {
                    // Disconnect from serial port
                    string transmit = "z";
                    byte[] TxByte = Encoding.Unicode.GetBytes(transmit);
                    serialPort_MSP430.Write(TxByte, 0, 1);
                    serialPort_MSP430.Close();
                    
                    buttonConnectSerial.Text = "Connect Serial";
                    comboBoxCOMPorts.Enabled = true; // Re-enable port selection
                    CurrentState = State.IDLE; // Move to IDLE state
                    //MessageBox.Show("Successfully Disconnected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                // Ensure UI state is consistent even if an error occurs
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                if (serialPort_MSP430.IsOpen)
                {
                    // Cancel the close temporarily to do async cleanup
                    e.Cancel = true;

                    // Disable the form to prevent user interaction
                    this.Enabled = false;

                    // Re-enable form and close
                    this.Enabled = true;
                    e.Cancel = false;

                    // Close the form properly
                    this.Close();
                }
                else
                {
                    // Placeholder
                }
            }
            catch (Exception ex)
            {
                // Log error but allow form to close
                System.Diagnostics.Debug.WriteLine("Error closing form: " + ex.Message);
            }
        }

        // Process incoming data stream and display instantaneous values
        private void processDataQueue(int value)
        {
            // Check for LEAD byte
            if (value == 255)
            {
                nextDataStream = DataStream.Ax; // Expect Ax next
            }
            else
            {
                switch (nextDataStream)
                {
                    case DataStream.Ax:
                        dataQueue_Ax.Enqueue(value);
                        rawAx = value;
                        textBox_Ax.Text = rawAx.ToString();
                        nextDataStream = DataStream.Ay; // Expect Ay next
                        break;
                    case DataStream.Ay:
                        dataQueue_Ay.Enqueue(value);
                        rawAy = value;
                        textBox_Ay.Text = rawAy.ToString();
                        nextDataStream = DataStream.Az; // Expect Az next
                        break;
                    case DataStream.Az:
                        dataQueue_Az.Enqueue(value);
                        rawAz = value;
                        textBox_Az.Text = rawAz.ToString();

                        if (dataQueue_Ax.TryDequeue(out int ax))
                            gestureBuffer.Add(ax);

                        if (dataQueue_Ay.TryDequeue(out int ay))
                            gestureBuffer.Add(ay);

                        if (dataQueue_Az.TryDequeue(out int az))
                            gestureBuffer.Add(az);
                            stateMachine();

                        nextDataStream = DataStream.LEAD; // Expect LEAD
                        break;
                }
            }
        }

        private void stateMachine()
        {
            // State machine
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

                    // waiting for gesture
                    for (int i = 0; i < gestureBuffer.Count; i++)
                    {
                        if ((gestureBuffer[i] > 200) || (gestureBuffer[i] < 45))
                        {
                            CurrentState = State.GESTUREDETECTED;
                            stateProcessed = false; // Reset for next state
                            break;
                        }
                    }
                    gestureBuffer.Clear();
                    break;

                case State.GESTUREDETECTED:
                    if (!stateProcessed)
                    {
                        // process gesture
                        MapGesture(gestureBuffer);
                        gestureBuffer.Clear();
                        // wait for more gestures or timeout
                        GestureTimeout.Start();
                        stateProcessed = true;
                    }
                    CurrentState = State.WAITFORMOREGESTURES;
                    stateProcessed = false; // Reset for next state
                    break;

                case State.WAITFORMOREGESTURES:
                    // if new gesture detected, process it
                    for (int i = 0; i < gestureBuffer.Count; i++)
                    {
                        if ((gestureBuffer[i] > 200) || (gestureBuffer[i] < 45))
                        {
                            GestureTimeout.Stop();
                            GestureTimeout.Start();
                            CurrentState = State.GESTUREDETECTED;
                            stateProcessed = false; // Reset for next state
                            break;
                        }
                    }
                    gestureBuffer.Clear();

                    // if timeout occurs, move to gesture completed state
                    if (!GestureTimeout.Enabled)
                    {
                        CurrentState = State.GESTURECOMPLETED;
                        stateProcessed = false; // Reset for next state
                    }
                    break;

                case State.GESTURECOMPLETED:
                    if (!stateProcessed)
                    {
                        // finalize gesture sequence
                        GestureTimeout.Stop();
                        identifyGesture(); // Clears the detectedGestures
                        stateProcessed = true;
                    }
                    CurrentState = State.START;
                    stateProcessed = false; // Reset for next state
                    break;
            }
        }

        private void MapGesture(List<int> list)
        {
            if (list.Count < 3)
            {
                MessageBox.Show("Not enough data to map gesture.");
                CurrentState = State.START;
            }

            if (list[0] > 200 && list[1] < 180 && list[2] < 180)
            {
                detectedGestures.Enqueue(Gesture.POS_X.ToString());
            }
            else if (list[0] < 180 && list[1] > 200 && list[2] < 180)
            {
                detectedGestures.Enqueue(Gesture.POS_Y.ToString());
            }
            else if (list[0] < 180 && list[1] < 180 && list[2] > 200)
            {
                detectedGestures.Enqueue(Gesture.POS_Z.ToString());
            }
            else if (list[0] < 45 && list[1] > 100 && list[2] > 100)
            {
                detectedGestures.Enqueue(Gesture.NEG_X.ToString());
            }
            else if (list[0] > 100 && list[1] < 45 && list[2] > 100)
            {
                detectedGestures.Enqueue(Gesture.NEG_Y.ToString());
            }
            else if (list[0] > 100 && list[1] > 100 && list[2] < 45)
            {
                detectedGestures.Enqueue(Gesture.NEG_Z.ToString());
            }
            //else
            //{
            //    detectedGestures.Enqueue(Gesture.NONE.ToString());
            //}
            
            textBox_LatestGesture.Text = detectedGestures.Last();
            if (detectedGestures.Last() != finalizedGestures.LastOrDefault())
                finalizedGestures.Enqueue(detectedGestures.Last());
            return;
        }

        private void identifyGesture()
        {
            var gestures = finalizedGestures.ToList();
            
            if (gestures.SequenceEqual(new[] { "POS_X", "POS_Y" }))
                textBox_AssessedGesture.Text = "right hook";
            else if (gestures.SequenceEqual(new[] { "POS_X" }))
                textBox_AssessedGesture.Text = "simple punch";
            else if (gestures.SequenceEqual(new[] { "POS_X", "POS_Z", "POS_Y" }))
                textBox_AssessedGesture.Text = "right uppercut";
            else
                textBox_AssessedGesture.Text = "unknown move";

            detectedGestures.Clear();
            finalizedGestures.Clear();
        }

    }
}
