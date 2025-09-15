namespace LiveGestureRecognition
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Data = new System.Windows.Forms.TextBox();
            this.label_SerialDataStream = new System.Windows.Forms.Label();
            this.textBox_AssessedGesture = new System.Windows.Forms.TextBox();
            this.textBox_CurrentState = new System.Windows.Forms.TextBox();
            this.label_ItemsInQueue = new System.Windows.Forms.Label();
            this.label_CurrentState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnectSerial = new System.Windows.Forms.Button();
            this.label_LatestMove = new System.Windows.Forms.Label();
            this.textBox_LatestGesture = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Az = new System.Windows.Forms.TextBox();
            this.textBox_Ay = new System.Windows.Forms.TextBox();
            this.label_Az = new System.Windows.Forms.Label();
            this.label_Ay = new System.Windows.Forms.Label();
            this.label_Ax = new System.Windows.Forms.Label();
            this.textBox_Ax = new System.Windows.Forms.TextBox();
            this.serialPort_MSP430 = new System.IO.Ports.SerialPort(this.components);
            this.textBox_gesturebuffercount = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.72199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.27801F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_Data, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label_SerialDataStream, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox_AssessedGesture, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_CurrentState, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_ItemsInQueue, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_CurrentState, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCOMPorts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConnectSerial, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_LatestMove, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_LatestGesture, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.textBox_gesturebuffercount, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.572383F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.781737F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.7951F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.240535F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.685968F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.658375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.572383F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.79287F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 603);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox_Data
            // 
            this.textBox_Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_Data, 2);
            this.textBox_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Data.Location = new System.Drawing.Point(3, 231);
            this.textBox_Data.Multiline = true;
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.Size = new System.Drawing.Size(476, 298);
            this.textBox_Data.TabIndex = 21;
            // 
            // label_SerialDataStream
            // 
            this.label_SerialDataStream.AutoSize = true;
            this.label_SerialDataStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SerialDataStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SerialDataStream.Location = new System.Drawing.Point(3, 188);
            this.label_SerialDataStream.Name = "label_SerialDataStream";
            this.label_SerialDataStream.Size = new System.Drawing.Size(170, 40);
            this.label_SerialDataStream.TabIndex = 16;
            this.label_SerialDataStream.Text = "Serial Data Stream:";
            this.label_SerialDataStream.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_AssessedGesture
            // 
            this.textBox_AssessedGesture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_AssessedGesture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_AssessedGesture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_AssessedGesture.Location = new System.Drawing.Point(179, 137);
            this.textBox_AssessedGesture.Multiline = true;
            this.textBox_AssessedGesture.Name = "textBox_AssessedGesture";
            this.textBox_AssessedGesture.Size = new System.Drawing.Size(300, 40);
            this.textBox_AssessedGesture.TabIndex = 12;
            // 
            // textBox_CurrentState
            // 
            this.textBox_CurrentState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_CurrentState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_CurrentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CurrentState.Location = new System.Drawing.Point(179, 93);
            this.textBox_CurrentState.Multiline = true;
            this.textBox_CurrentState.Name = "textBox_CurrentState";
            this.textBox_CurrentState.Size = new System.Drawing.Size(300, 38);
            this.textBox_CurrentState.TabIndex = 11;
            // 
            // label_ItemsInQueue
            // 
            this.label_ItemsInQueue.AutoSize = true;
            this.label_ItemsInQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ItemsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ItemsInQueue.Location = new System.Drawing.Point(3, 134);
            this.label_ItemsInQueue.Name = "label_ItemsInQueue";
            this.label_ItemsInQueue.Size = new System.Drawing.Size(170, 46);
            this.label_ItemsInQueue.TabIndex = 8;
            this.label_ItemsInQueue.Text = "Overall Assessed Gesture:";
            this.label_ItemsInQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CurrentState
            // 
            this.label_CurrentState.AutoSize = true;
            this.label_CurrentState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_CurrentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurrentState.Location = new System.Drawing.Point(3, 90);
            this.label_CurrentState.Name = "label_CurrentState";
            this.label_CurrentState.Size = new System.Drawing.Size(170, 44);
            this.label_CurrentState.TabIndex = 6;
            this.label_CurrentState.Text = "Current State (Debug):";
            this.label_CurrentState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 9);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(3, 3);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(170, 24);
            this.comboBoxCOMPorts.TabIndex = 0;
            this.comboBoxCOMPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxCOMPorts_SelectedIndexChanged);
            // 
            // buttonConnectSerial
            // 
            this.buttonConnectSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConnectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnectSerial.Location = new System.Drawing.Point(179, 3);
            this.buttonConnectSerial.Name = "buttonConnectSerial";
            this.buttonConnectSerial.Size = new System.Drawing.Size(300, 34);
            this.buttonConnectSerial.TabIndex = 1;
            this.buttonConnectSerial.Text = "Connect Serial";
            this.buttonConnectSerial.UseVisualStyleBackColor = true;
            this.buttonConnectSerial.Click += new System.EventHandler(this.buttonConnectSerial_Click);
            // 
            // label_LatestMove
            // 
            this.label_LatestMove.AutoSize = true;
            this.label_LatestMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LatestMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LatestMove.Location = new System.Drawing.Point(3, 49);
            this.label_LatestMove.Name = "label_LatestMove";
            this.label_LatestMove.Size = new System.Drawing.Size(170, 41);
            this.label_LatestMove.TabIndex = 2;
            this.label_LatestMove.Text = "Latest Move:";
            this.label_LatestMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_LatestGesture
            // 
            this.textBox_LatestGesture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_LatestGesture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_LatestGesture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_LatestGesture.Location = new System.Drawing.Point(179, 52);
            this.textBox_LatestGesture.Multiline = true;
            this.textBox_LatestGesture.Name = "textBox_LatestGesture";
            this.textBox_LatestGesture.Size = new System.Drawing.Size(300, 35);
            this.textBox_LatestGesture.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel2.Controls.Add(this.textBox_Az, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Ay, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Az, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Ay, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Ax, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Ax, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 549);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(476, 51);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // textBox_Az
            // 
            this.textBox_Az.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Az.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Az.Location = new System.Drawing.Point(367, 3);
            this.textBox_Az.Multiline = true;
            this.textBox_Az.Name = "textBox_Az";
            this.textBox_Az.Size = new System.Drawing.Size(106, 45);
            this.textBox_Az.TabIndex = 7;
            // 
            // textBox_Ay
            // 
            this.textBox_Ay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Ay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ay.Location = new System.Drawing.Point(209, 3);
            this.textBox_Ay.Multiline = true;
            this.textBox_Ay.Name = "textBox_Ay";
            this.textBox_Ay.Size = new System.Drawing.Size(104, 45);
            this.textBox_Ay.TabIndex = 6;
            // 
            // label_Az
            // 
            this.label_Az.AutoSize = true;
            this.label_Az.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Az.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Az.Location = new System.Drawing.Point(319, 0);
            this.label_Az.Name = "label_Az";
            this.label_Az.Size = new System.Drawing.Size(42, 51);
            this.label_Az.TabIndex = 4;
            this.label_Az.Text = "Az:";
            this.label_Az.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Ay
            // 
            this.label_Ay.AutoSize = true;
            this.label_Ay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Ay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ay.Location = new System.Drawing.Point(161, 0);
            this.label_Ay.Name = "label_Ay";
            this.label_Ay.Size = new System.Drawing.Size(42, 51);
            this.label_Ay.TabIndex = 2;
            this.label_Ay.Text = "Ay:";
            this.label_Ay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Ax
            // 
            this.label_Ax.AutoSize = true;
            this.label_Ax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Ax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ax.Location = new System.Drawing.Point(3, 0);
            this.label_Ax.Name = "label_Ax";
            this.label_Ax.Size = new System.Drawing.Size(42, 51);
            this.label_Ax.TabIndex = 0;
            this.label_Ax.Text = "Ax:";
            this.label_Ax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Ax
            // 
            this.textBox_Ax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Ax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ax.Location = new System.Drawing.Point(51, 3);
            this.textBox_Ax.Multiline = true;
            this.textBox_Ax.Name = "textBox_Ax";
            this.textBox_Ax.Size = new System.Drawing.Size(104, 45);
            this.textBox_Ax.TabIndex = 5;
            // 
            // serialPort_MSP430
            // 
            this.serialPort_MSP430.PortName = "COM7";
            this.serialPort_MSP430.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_MSP430_DataReceived);
            // 
            // textBox_gesturebuffercount
            // 
            this.textBox_gesturebuffercount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_gesturebuffercount.Location = new System.Drawing.Point(179, 191);
            this.textBox_gesturebuffercount.Multiline = true;
            this.textBox_gesturebuffercount.Name = "textBox_gesturebuffercount";
            this.textBox_gesturebuffercount.Size = new System.Drawing.Size(300, 34);
            this.textBox_gesturebuffercount.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button buttonConnectSerial;
        private System.Windows.Forms.Label label_LatestMove;
        private System.Windows.Forms.Label label_ItemsInQueue;
        private System.Windows.Forms.Label label_CurrentState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_LatestGesture;
        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.Label label_SerialDataStream;
        private System.Windows.Forms.TextBox textBox_AssessedGesture;
        private System.Windows.Forms.TextBox textBox_CurrentState;
        private System.IO.Ports.SerialPort serialPort_MSP430;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_Az;
        private System.Windows.Forms.Label label_Ay;
        private System.Windows.Forms.Label label_Ax;
        private System.Windows.Forms.TextBox textBox_Ax;
        private System.Windows.Forms.TextBox textBox_Az;
        private System.Windows.Forms.TextBox textBox_Ay;
        private System.Windows.Forms.TextBox textBox_gesturebuffercount;
    }
}

