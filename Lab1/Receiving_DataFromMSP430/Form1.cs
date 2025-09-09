using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receiving_DataFromMSP430
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;
        }

        private void comboBoxCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort_MPS430.PortName = comboBoxCOMPorts.SelectedItem.ToString();
        }

        private void buttonConnectSerial_Click(object sender, EventArgs e)
        {
            string transmit = "a"; // or "A", both will work 
            byte[] TxByte = Encoding.Unicode.GetBytes(transmit);

            try
            {
                if (!serialPort_MPS430.IsOpen)
                    serialPort_MPS430.Open();
                buttonConnectSerial.Text = "Disconnect Serial.";

                serialPort_MPS430.Write(TxByte, 0, 1);
                MessageBox.Show("Successfully Connected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
    }
}
