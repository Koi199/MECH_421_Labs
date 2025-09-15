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

namespace SavingAccDataCSV
{
    public partial class Form1 : Form
    {
        private string serialDataString = "";
        private Timer myTimer = new Timer();
        private enum DataStream { LEAD, Ax, Ay, Az };
        private DataStream nextDataStream;
        private int scaledAx, scaledAy, scaledAz;
        private int rawAx, rawAy, rawAz;
        private const int offsetAx = 126; // Adjust based on calibration
        private const int offsetAy = 127; // Adjust based on calibration
        private const int offsetAz = 127; // Adjust based on calibration

        private ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Ax = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Ay = new ConcurrentQueue<Int32>();
        private ConcurrentQueue<Int32> dataQueue_Az = new ConcurrentQueue<Int32>();

        private StreamWriter streamWriter;

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
            myTimer.Interval = 100;// Fires every 100ms
            myTimer.Tick += UpdateQueues; // Hook up the event
            myTimer.Start(); // Start the timer
        }

        // Timer Tick Event Handler
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

        private void checkBox_saveFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_saveFile.Checked)
            {
                startStreamingToFile();
            }
            else
            {
                stopWritingToFile();
            }
        }

        // Save File Dialog implementation
        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Configure the SaveFileDialog
                saveFileDialog.Title = "Save CSV Data File";
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1; // Default to CSV files
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.AddExtension = true;

                // Set initial directory
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Set default filename with timestamp
                saveFileDialog.FileName = $"AccelData_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                // If textbox already has a filename, use it
                if (!string.IsNullOrWhiteSpace(textBox_Filename.Text))
                {
                    try
                    {
                        // If it's a full path, extract filename and directory
                        if (Path.IsPathRooted(textBox_Filename.Text))
                        {
                            saveFileDialog.FileName = Path.GetFileName(textBox_Filename.Text);
                            string directory = Path.GetDirectoryName(textBox_Filename.Text);
                            if (Directory.Exists(directory))
                            {
                                saveFileDialog.InitialDirectory = directory;
                            }
                        }
                        else
                        {
                            // Just a filename
                            saveFileDialog.FileName = textBox_Filename.Text;
                        }
                    }
                    catch
                    {
                        // If there's any error with the existing path, use defaults
                    }
                }

                // Show the dialog
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Update the textbox with the selected filename
                    textBox_Filename.Text = saveFileDialog.FileName;

                    // Optional: Show confirmation message
                    MessageBox.Show($"File path selected: {saveFileDialog.FileName}",
                                  "File Selected",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
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

                    // Stop file writing
                    if (checkBox_saveFile.Checked)
                    {
                        stopWritingToFile();
                    }

                    // Re-enable form and close
                    this.Enabled = true;
                    e.Cancel = false;

                    // Close the form properly
                    this.Close();
                }
                else
                {
                    // Just stop file writing if no serial connection
                    if (checkBox_saveFile.Checked)
                    {
                        stopWritingToFile();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error but allow form to close
                System.Diagnostics.Debug.WriteLine("Error closing form: " + ex.Message);
            }
        }

        // Helper methods for file writing
        private void startStreamingToFile()
        {
            try
            {
                // Validate filename
                if (string.IsNullOrWhiteSpace(textBox_Filename.Text))
                {
                    MessageBox.Show("Please enter a filename");
                    checkBox_saveFile.Checked = false;
                    return;
                }

                // Create directory if it doesn't exist
                string directory = Path.GetDirectoryName(textBox_Filename.Text);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                streamWriter = new StreamWriter(textBox_Filename.Text);
                // Write CSV header
                streamWriter.WriteLine("Accel_x (mm/s^2),Accel_y (mm/s^2),Accel_z (mm/s^2),Timestamp");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting file writing: {ex.Message}");
                checkBox_saveFile.Checked = false;
            }
        }

        private void stopWritingToFile()
        {
            try
            {

                if (streamWriter != null)
                {
                    streamWriter.Flush();
                    streamWriter.Close();
                    streamWriter.Dispose();
                    streamWriter = null;
                }

                MessageBox.Show("File recording stopped and file closed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping file recording: {ex.Message}");
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
                        scaledAx = (value - offsetAx);
                        textBox_Ax.Text = scaledAx.ToString();
                        nextDataStream = DataStream.Ay; // Expect Ay next
                        break;
                    case DataStream.Ay:
                        dataQueue_Ay.Enqueue(value);
                        rawAy = value;
                        scaledAy = (value - offsetAy);
                        textBox_Ay.Text = scaledAy.ToString();
                        nextDataStream = DataStream.Az; // Expect Az next
                        break;
                    case DataStream.Az:
                        dataQueue_Az.Enqueue(value);
                        rawAz = value;
                        scaledAz = (value - offsetAz);
                        textBox_Az.Text = scaledAz.ToString();

                        if (checkBox_saveFile.Checked && streamWriter != null)
                        {
                            // Write the latest Ax, Ay, Az values to file with timestamp
                            string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
                            streamWriter.WriteLine($"{rawAx},{rawAy},{rawAz},{timestamp}");
                        }

                        nextDataStream = DataStream.LEAD; // Expect LEAD
                        break;
                }
            }
        }

    }
}
