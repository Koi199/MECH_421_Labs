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
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;


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

        // OpenTK related variables
        private GLControl glControl;
        private Timer renderTimer;

        // Accelerometer data variables
        private float pitch = 0, roll = 0, yaw = 0;
        private float currentAx = 0, currentAy = 0, currentAz = 0;

        public Form1()
        {
            InitializeComponent();
            SetupOpenGL();

        }

        private void SetupOpenGL()
        {
            // Create GLControl with appropriate graphics mode
            glControl = new GLControl(new GraphicsMode(32, 24, 0, 8));

            // Set size and position - adjust these based on your form layout
            glControl.Size = new Size(400, 300);
            glControl.Location = new Point(500, 50); // Position it where you want on the form
            glControl.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Optional: anchor it

            // Hook up events
            glControl.Paint += GlControl_Paint;
            glControl.Resize += GlControl_Resize;
            glControl.Load += GlControl_Load;

            // Add to form
            this.Controls.Add(glControl);

            // Setup render timer for smooth animation
            renderTimer = new Timer();
            renderTimer.Interval = 33; // ~30 FPS
            renderTimer.Tick += RenderTimer_Tick;
            renderTimer.Start();
        }

        private void GlControl_Load(object sender, EventArgs e)
        {
            // Initialize OpenGL settings
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);

            // Set up lighting
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.2f, 0.2f, 0.2f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 0.8f, 0.8f, 0.8f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 1.0f, 1.0f, 1.0f, 0.0f });
        }

        private void GlControl_Resize(object sender, EventArgs e)
        {
            if (glControl.ClientSize.Height == 0)
                return;

            GL.Viewport(0, 0, glControl.ClientSize.Width, glControl.ClientSize.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            float aspect = (float)glControl.ClientSize.Width / (float)glControl.ClientSize.Height;
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45.0f), aspect, 0.1f, 100.0f);
            GL.LoadMatrix(ref perspective);
        }

        private void GlControl_Paint(object sender, PaintEventArgs e)
        {
            RenderScene();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            glControl.Invalidate(); // Trigger redraw
        }

        private void RenderScene()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Position camera
            GL.Translate(0.0f, 0.0f, -5.0f);

            // Apply rotations from accelerometer data
            GL.Rotate(pitch, 1.0f, 0.0f, 0.0f);  // Pitch around X-axis
            GL.Rotate(roll, 0.0f, 0.0f, 1.0f);   // Roll around Z-axis
            GL.Rotate(yaw, 0.0f, 1.0f, 0.0f);    // Yaw around Y-axis

            // Draw the accelerometer board representation
            DrawBoard();

            // Draw coordinate axes for reference
            DrawAxes();

            glControl.SwapBuffers();
        }

        private void DrawBoard()
        {
            // Draw a simple rectangular board
            GL.Color3(0.0f, 0.5f, 1.0f); // Blue color

            GL.Begin(PrimitiveType.Quads);

            // Top face
            GL.Normal3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(-1.0f, 0.1f, -0.5f);
            GL.Vertex3(1.0f, 0.1f, -0.5f);
            GL.Vertex3(1.0f, 0.1f, 0.5f);
            GL.Vertex3(-1.0f, 0.1f, 0.5f);

            // Bottom face
            GL.Normal3(0.0f, -1.0f, 0.0f);
            GL.Vertex3(-1.0f, -0.1f, -0.5f);
            GL.Vertex3(-1.0f, -0.1f, 0.5f);
            GL.Vertex3(1.0f, -0.1f, 0.5f);
            GL.Vertex3(1.0f, -0.1f, -0.5f);

            // Side faces
            GL.Normal3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(-1.0f, -0.1f, 0.5f);
            GL.Vertex3(-1.0f, 0.1f, 0.5f);
            GL.Vertex3(1.0f, 0.1f, 0.5f);
            GL.Vertex3(1.0f, -0.1f, 0.5f);

            GL.Normal3(0.0f, 0.0f, -1.0f);
            GL.Vertex3(-1.0f, -0.1f, -0.5f);
            GL.Vertex3(1.0f, -0.1f, -0.5f);
            GL.Vertex3(1.0f, 0.1f, -0.5f);
            GL.Vertex3(-1.0f, 0.1f, -0.5f);

            GL.Normal3(-1.0f, 0.0f, 0.0f);
            GL.Vertex3(-1.0f, -0.1f, -0.5f);
            GL.Vertex3(-1.0f, 0.1f, -0.5f);
            GL.Vertex3(-1.0f, 0.1f, 0.5f);
            GL.Vertex3(-1.0f, -0.1f, 0.5f);

            GL.Normal3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(1.0f, -0.1f, -0.5f);
            GL.Vertex3(1.0f, -0.1f, 0.5f);
            GL.Vertex3(1.0f, 0.1f, 0.5f);
            GL.Vertex3(1.0f, 0.1f, -0.5f);

            GL.End();
        }

        private void DrawAxes()
        {
            GL.Begin(PrimitiveType.Lines);

            // X-axis (Red)
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(1.5f, 0.0f, 0.0f);

            // Y-axis (Green)
            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 1.5f, 0.0f);

            // Z-axis (Blue)
            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 1.5f);

            GL.End();
        }

        private void UpdateAccelerometerData(int ax, int ay, int az)
        {
            // Store raw values
            currentAx = ax;
            currentAy = ay;
            currentAz = az;

            // Convert to normalized values (assuming your data is in some range, adjust as needed)
            float normalizedX = ax / 128.0f; // Adjust divisor based on your data range
            float normalizedY = ay / 128.0f;
            float normalizedZ = az / 128.0f;

            // Calculate pitch and roll from accelerometer data
            // Note: This assumes standard accelerometer orientation
            pitch = (float)(Math.Atan2(normalizedY, Math.Sqrt(normalizedX * normalizedX + normalizedZ * normalizedZ)) * 180.0 / Math.PI);
            roll = (float)(Math.Atan2(-normalizedX, Math.Sqrt(normalizedY * normalizedY + normalizedZ * normalizedZ)) * 180.0 / Math.PI);

            // Yaw cannot be determined from accelerometer alone, would need magnetometer
            // For now, keep yaw at 0 or add manual control
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

            int latestAx = 0, latestAy = 0, latestAz = 0;
            bool hasNewData = false;

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
                            latestAx = value;
                            nextDataStream = DataStream.Ay; // Expect Ay next
                            break;
                        case DataStream.Ay:
                            dataQueue_Ay.Enqueue(value);
                            textBox_Ay.Text = value.ToString();
                            latestAy = value;
                            nextDataStream = DataStream.Az; // Expect Az next
                            break;
                        case DataStream.Az:
                            dataQueue_Az.Enqueue(value);
                            textBox_Az.Text = value.ToString();
                            latestAz = value;
                            hasNewData = true;
                            nextDataStream = DataStream.Ax; // Expect Ax next
                            break;
                    }
                }
            }

            // Update 3D visualization if we have new complete data
            if (hasNewData)
            {
                UpdateAccelerometerData(latestAx, latestAy, latestAz);
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
