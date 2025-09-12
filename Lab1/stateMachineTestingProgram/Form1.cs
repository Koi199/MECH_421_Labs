using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stateMachineTestingProgram
{
    public partial class Form1 : Form
    {
        private Timer timerWaitingForNextGesture = new Timer();
        private Timer myTimer = new Timer();
        private ConcurrentQueue<string> GestureQueue = new ConcurrentQueue<string>();
        private List<int> gestureBuffer = new List<int>();
        private Queue<String> detectedGestures = new Queue<String>();

        private const int GESTURE_TIMEOUT_MS = 5000; // 2 seconds
        private State CurrentState = 0;

        // Define states and gestures
        enum State
        {
            IDLE = 0,
            GESTUREDETECTED,
            WAITFORMOREGESTURES,
            GESTURECOMPLETED
        }
        enum Gesture
        {
            NONE = 0,
            POS_X, POS_Y, POS_Z, NEG_X, NEG_Y, NEG_Z
        }

        // Define Data Structure
        private struct DataPoint
        {
            public string axis { get; set; }
            public int acc { get; set; }

            public DataPoint(string axis, int acc)
            {
                this.axis = axis;
                this.acc = acc;
            }
        }

        //Dictionary<Gesture, DataPoint> gestureDataPoints = new Dictionary<Gesture, DataPoint>()
        //{
        //    { Gesture.POS_X, new DataPoint("Ax", 180) },
        //    { Gesture.POS_Y, new DataPoint("Ay", 180) },
        //    { Gesture.POS_Z, new DataPoint("Az", 180) },
        //    { Gesture.NEG_X, new DataPoint("Ax", -180) },
        //    { Gesture.NEG_Y, new DataPoint("Ay", -180) },
        //    { Gesture.NEG_Z, new DataPoint("Az", -180) }
        //};

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerWaitingForNextGesture.Interval = GESTURE_TIMEOUT_MS;
            timerWaitingForNextGesture.Tick += TimerWaitingForNextGesture_Tick;

            myTimer.Interval = 100; // 100 ms
            myTimer.Tick += MyTimer_Tick;
            myTimer.Start();
        }

        private void button_ProcessNewDataPoint_Click(object sender, EventArgs e)
        {
            gestureBuffer.Add(!string.IsNullOrEmpty(textBox_Ax.Text) ? int.Parse(textBox_Ax.Text) : 0);
            gestureBuffer.Add(!string.IsNullOrEmpty(textBox_Ay.Text) ? int.Parse(textBox_Ay.Text) : 0);
            gestureBuffer.Add(!string.IsNullOrEmpty(textBox_Az.Text) ? int.Parse(textBox_Az.Text) : 0);

        }

        private void TimerWaitingForNextGesture_Tick(object sender, EventArgs e)
        {
            timerWaitingForNextGesture.Stop();

        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {   
            textBox_CurrentState.Text = CurrentState.ToString();
            stateMachine();
        }

        private void stateMachine()
        {   if (gestureBuffer.Count >= 3)
            {   
                GestureQueue.Enqueue(gestureBuffer.Count >= 3 ? $"({gestureBuffer[0]}, {gestureBuffer[1]}, {gestureBuffer[2]}, {(int)CurrentState})" : "");
                textBox_DataHistory.AppendText($"({gestureBuffer[0]}, {gestureBuffer[1]}, {gestureBuffer[2]}, {(int)CurrentState}), ");
            }
            
            // State machine
            switch (CurrentState)
            {
                case State.IDLE:
                    // waiting for gesture
                    for (int i = 0; i < gestureBuffer.Count; i++)
                    {
                        if (gestureBuffer[i] > 150)
                        {
                            CurrentState = State.GESTUREDETECTED;
                            break;
                        }
                    }
                    //gestureBuffer.Clear();

                    break;

                case State.GESTUREDETECTED:
                    // process gesture
                    MapGesture(gestureBuffer);
                    gestureBuffer.Clear();
                    // wait for more gestures or timeout
                    timerWaitingForNextGesture.Start();

                    CurrentState = State.WAITFORMOREGESTURES;
                    break;
                
                case State.WAITFORMOREGESTURES:
                    // if new gesture detected, process it
                    for (int i = 0; i < gestureBuffer.Count; i++)
                    {
                        if (gestureBuffer[i] > 150)
                        {
                            timerWaitingForNextGesture.Stop();
                            timerWaitingForNextGesture.Start();
                            CurrentState = State.GESTUREDETECTED;
                            break;
                        }
                    }

                    // if timeout occurs, move to gesture completed state
                    if (!timerWaitingForNextGesture.Enabled)
                    {
                        CurrentState = State.GESTURECOMPLETED;
                    }

                    break;

                case State.GESTURECOMPLETED:
                    // finalize gesture sequence
                    timerWaitingForNextGesture.Stop();
                    identifyGesture();
                    CurrentState = State.IDLE;
                    break;

            }
        }

        // Prevent Letters to be inserted in the TextBox
        private void textBox_Ax_TextChanged(object sender, EventArgs e)
        {
            // Allow only digits, backspace, and delete
            if (!textBox_Ax.Text.All(char.IsDigit) && !textBox_Ax.Text.All(char.IsControl))
            {
                MessageBox.Show("Please enter only numeric values.");
            }
        }

        private void textBox_Ay_TextChanged(object sender, EventArgs e)
        {
            // Allow only digits, backspace, and delete
            if (!textBox_Ay.Text.All(char.IsDigit) && !textBox_Ay.Text.All(char.IsControl))
            {
                MessageBox.Show("Please enter only numeric values.");
            }
        }

        private void textBox_Az_TextChanged(object sender, EventArgs e)
        {
            // Allow only digits, backspace, and delete
            if (!textBox_Az.Text.All(char.IsDigit) && !textBox_Az.Text.All(char.IsControl))
            {
                MessageBox.Show("Please enter only numeric values.");
            }
        }

        private void MapGesture(List<int> list)
        {
            if(list.Count < 3)
            {   
                MessageBox.Show("Not enough data to map gesture.");
                return;
            }
            
            if (list[0] > 160 && list[1] < 130 && list[2] < 130)
            {
                detectedGestures.Enqueue(Gesture.POS_X.ToString());
            }
            else if(list[0] < 130 && list[1] > 160 && list[2] < 130)
            {
                detectedGestures.Enqueue(Gesture.POS_Y.ToString());
            }
            else if (list[0] < 130 && list[1] < 130 && list[2] > 160)
            {
                detectedGestures.Enqueue(Gesture.POS_Z.ToString());
            }
            else if (list[0] < -160 && list[1] < 130 && list[2] < 130)
            {
                detectedGestures.Enqueue(Gesture.NEG_X.ToString());
            }
            else if (list[0] < 130 && list[1] < -160 && list[2] < 130)
            {
                detectedGestures.Enqueue(Gesture.NEG_Y.ToString());
            }
            else if (list[0] < 130 && list[1] < 130 && list[2] < -160)
            {
                detectedGestures.Enqueue(Gesture.NEG_Z.ToString());
            }
            else
            {
                detectedGestures.Enqueue(Gesture.NONE.ToString());
            }

        }

        private void identifyGesture()
        {
            var gestures = detectedGestures.ToArray();

            if (gestures.SequenceEqual(new[] { "POS_X", "POS_Y" }))
                textBox_GestureReg.Text = "right hook";
            else if (gestures.SequenceEqual(new[] { "POS_X" }))
                textBox_GestureReg.Text = "simple punch";
            else if (gestures.SequenceEqual(new[] { "POS_X", "POS_Z", "POS_Y" }))
                textBox_GestureReg.Text = "right uppercut";
            else
                textBox_GestureReg.Text = "unknown move";

            detectedGestures.Clear();
        }

    }

}
