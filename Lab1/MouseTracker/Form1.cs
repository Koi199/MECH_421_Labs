using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseTracker
{
    public partial class Form1 : Form
    {
        private Point cursorlocation;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cursorlocation = e.Location;
            textBox_XCoord.Text = cursorlocation.X.ToString();
            textBox_YCoord.Text = cursorlocation.Y.ToString();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            String Temp = "(" + cursorlocation.X.ToString() + ", " + cursorlocation.Y.ToString() + ")\r\n";

            textBox_recordedClicks.AppendText(Temp);
        }
    }
}
