using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace Queues
{
    public partial class Form1 : Form
    {
        private ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        private string LatestDequeuedVal;
        private Timer myTimer = new Timer();

        public Form1()
        {
            InitializeComponent();
            myTimer.Interval = 100; // Fires every 100ms
            myTimer.Tick += UpdateQueue; // Hook up the event
            myTimer.Start(); // Start the timer
        }
        private void UpdateQueue(object sender, EventArgs e)
        {
            textBox_QueueContent.Clear();
            int count = dataQueue.Count;
            int index = 0;

            textBox_NumberOfItems.Text = count.ToString();

            foreach (int i in dataQueue)
            {
                textBox_QueueContent.AppendText(i.ToString());
                index++;

                if (index < count)
                {
                    textBox_QueueContent.AppendText(", ");
                }
            }

        }

        private void button_Enqueue_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox_Enqueue.Text))
            {
                if (int.TryParse(textBox_Enqueue.Text, out int value))
                {
                    dataQueue.Enqueue(value);
                    textBox_Enqueue.Clear();
                }
                else
                {
                    MessageBox.Show("Please enter a valid integer.");
                }
            }
        }

        private void button_Dequeue_Click(object sender, EventArgs e)
        {
            if (dataQueue.Count > 0)
            {
                if (dataQueue.TryDequeue(out int Value))
                {
                    LatestDequeuedVal = Convert.ToString(Value.ToString());
                    textBox_Dequeue.Text = LatestDequeuedVal;
                }
                else
                {
                    MessageBox.Show("Dequeuing Failed.");
                }

            }
            else {
                MessageBox.Show("Dequeuing Failed; Not enough items in the queue.");
            }
                
        }

        private void button_Dequeue_And_Average_Click(object sender, EventArgs e)
        {
            int N;

            if (int.TryParse(textBox_N.Text, out int value))
            {
                N = value;
            }
            else
            {
                MessageBox.Show("Please enter a valid integer for N.");
                return;
            }

            // Safety check: do we have enough items?
            if (dataQueue.Count > 0)
            {
                if (dataQueue.Count >= N)
                {
                    List<int> temp = new List<int>();

                    for (int i = 0; i < N; i++)
                    {
                        if (dataQueue.TryDequeue(out int Value))
                        {
                            temp.Add(Value);
                        }
                        else
                        {
                            MessageBox.Show("Dequeuing Failed.");
                            break;
                        }

                    }

                    double average = temp.Average();

                    textBox_Average.Text = average.ToString();
                }
                else
                {
                    MessageBox.Show("Not enough items in the queue.");
                }
            }
            else
            {
                MessageBox.Show("Not enough items in the queue.");
            }
            
        }
    }
}
