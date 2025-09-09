using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParsingDataFromMSP430
{
    public partial class Form1 : Form
    {
        private string serialDataString = "";
        private Timer myTimer = new Timer();
        private enum DataStream { LEAD, Ax, Ay, Az };
        private DataStream currentDataStream;
        private DataStream nextDataStream;

        private ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Ax = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Ay = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Az = new ConcurrentQueue<Int32>();

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

            // Setting up a timer
            myTimer.Interval = 100; // Fires every 100ms
            myTimer.Tick += UpdateQueues; // Hook up the event
            myTimer.Start(); // Start the timer
        }

        private void UpdateQueues(object sender, EventArgs e)
        {
            if (serialPort_MSP430.IsOpen)
                textBox_SerialBytestoRead.Text = serialPort_MSP430.BytesToRead.ToString();
            textBox_TempStringLength.Text = serialDataString.Length.ToString();
            ItemsInQueue.Text = dataQueue.Count.ToString(); // counting characters in the Queue
            serialDataString = "";

            // Display contents of queue container
            while (dataQueue.TryDequeue(out int value))
            {
                textBox_Data.AppendText(value.ToString() + ", ");
                
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
                            textBox_Ax.Text = value.ToString();
                            nextDataStream = DataStream.Ay; // Expect Ay next
                            break;
                        case DataStream.Ay:
                            dataQueue_Ay.Enqueue(value);
                            textBox_Ay.Text = value.ToString();
                            nextDataStream = DataStream.Az; // Expect Az next
                            break;
                        case DataStream.Az:
                            dataQueue_Az.Enqueue(value);
                            textBox_Az.Text = value.ToString();
                            nextDataStream = DataStream.Ax; // Expect Ax next
                            break;
                    }
                }
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
            int bytesToRead;
            bytesToRead = serialPort_MSP430.BytesToRead;
            while (bytesToRead != 0)
            {
                newByte = serialPort_MSP430.ReadByte();
                dataQueue.Enqueue(newByte);
                serialDataString = serialDataString + newByte.ToString() + ", ";
                bytesToRead = serialPort_MSP430.BytesToRead;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort_MSP430.IsOpen)
                {
                    string transmit_close = "z"; // or "Z", both will work 
                    byte[] TxByte = Encoding.Unicode.GetBytes(transmit_close);
                    serialPort_MSP430.Write(TxByte, 0, 1);
                    serialPort_MSP430.Close();

                }
            }
            catch (Exception ex)
            {
                // Log error if needed, but don't prevent form from closing
                System.Diagnostics.Debug.WriteLine("Error closing serial port: " + ex.Message);

            }
        }

    }
}
