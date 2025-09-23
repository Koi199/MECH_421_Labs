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
            this.textBox_gesturebuffercount = new System.Windows.Forms.TextBox();
            this.textBox_Data = new System.Windows.Forms.TextBox();
            this.label_SerialDataStream = new System.Windows.Forms.Label();
            this.textBox_AssessedGesture = new System.Windows.Forms.TextBox();
            this.textBox_CurrentState = new System.Windows.Forms.TextBox();
            this.label_ItemsInQueue = new System.Windows.Forms.Label();
            this.label_CurrentState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnectSerial = new System.Windows.Forms.Button();
            this.label_DataQSize = new System.Windows.Forms.Label();
            this.textBox_DataQSize = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Az = new System.Windows.Forms.TextBox();
            this.textBox_Ay = new System.Windows.Forms.TextBox();
            this.label_Az = new System.Windows.Forms.Label();
            this.label_Ay = new System.Windows.Forms.Label();
            this.label_Ax = new System.Windows.Forms.Label();
            this.textBox_Ax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_AxesAverage = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label_AverageAx = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Miny100 = new System.Windows.Forms.TextBox();
            this.label_AverageAz = new System.Windows.Forms.Label();
            this.textBox_Minz100 = new System.Windows.Forms.TextBox();
            this.button_reset = new System.Windows.Forms.Button();
            this.textBox_Orientation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.serialPort_MSP430 = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Minx100 = new System.Windows.Forms.TextBox();
            this.textBox_Maxx100 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Maxy100 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Maxz100 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label = new System.Windows.Forms.Label();
            this.textBox_TotalAcc = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_gesturebuffercount, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Data, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label_SerialDataStream, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox_AssessedGesture, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_CurrentState, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_ItemsInQueue, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_CurrentState, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCOMPorts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConnectSerial, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_DataQSize, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_DataQSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label_AxesAverage, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.button_reset, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Orientation, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 14);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 16;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.032733F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.417111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.032733F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.032733F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.032733F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.256801F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.032733F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.38342F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.977794F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.251909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.581542F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.427829F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.473248F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.120195F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.9465F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 603);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox_gesturebuffercount
            // 
            this.textBox_gesturebuffercount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_gesturebuffercount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_gesturebuffercount.Location = new System.Drawing.Point(244, 291);
            this.textBox_gesturebuffercount.Multiline = true;
            this.textBox_gesturebuffercount.Name = "textBox_gesturebuffercount";
            this.textBox_gesturebuffercount.Size = new System.Drawing.Size(235, 36);
            this.textBox_gesturebuffercount.TabIndex = 30;
            // 
            // textBox_Data
            // 
            this.textBox_Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_Data, 2);
            this.textBox_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Data.Location = new System.Drawing.Point(3, 182);
            this.textBox_Data.Multiline = true;
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.Size = new System.Drawing.Size(476, 52);
            this.textBox_Data.TabIndex = 21;
            // 
            // label_SerialDataStream
            // 
            this.label_SerialDataStream.AutoSize = true;
            this.label_SerialDataStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_SerialDataStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SerialDataStream.Location = new System.Drawing.Point(3, 146);
            this.label_SerialDataStream.Name = "label_SerialDataStream";
            this.label_SerialDataStream.Size = new System.Drawing.Size(235, 33);
            this.label_SerialDataStream.TabIndex = 16;
            this.label_SerialDataStream.Text = "Serial Data Stream:";
            this.label_SerialDataStream.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_AssessedGesture
            // 
            this.textBox_AssessedGesture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_AssessedGesture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_AssessedGesture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_AssessedGesture.Location = new System.Drawing.Point(244, 109);
            this.textBox_AssessedGesture.Multiline = true;
            this.textBox_AssessedGesture.Name = "textBox_AssessedGesture";
            this.textBox_AssessedGesture.Size = new System.Drawing.Size(235, 27);
            this.textBox_AssessedGesture.TabIndex = 12;
            // 
            // textBox_CurrentState
            // 
            this.textBox_CurrentState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_CurrentState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_CurrentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CurrentState.Location = new System.Drawing.Point(244, 76);
            this.textBox_CurrentState.Multiline = true;
            this.textBox_CurrentState.Name = "textBox_CurrentState";
            this.textBox_CurrentState.Size = new System.Drawing.Size(235, 27);
            this.textBox_CurrentState.TabIndex = 11;
            // 
            // label_ItemsInQueue
            // 
            this.label_ItemsInQueue.AutoSize = true;
            this.label_ItemsInQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ItemsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ItemsInQueue.Location = new System.Drawing.Point(3, 106);
            this.label_ItemsInQueue.Name = "label_ItemsInQueue";
            this.label_ItemsInQueue.Size = new System.Drawing.Size(235, 33);
            this.label_ItemsInQueue.TabIndex = 8;
            this.label_ItemsInQueue.Text = "Overall Assessed Gesture:";
            this.label_ItemsInQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CurrentState
            // 
            this.label_CurrentState.AutoSize = true;
            this.label_CurrentState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_CurrentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurrentState.Location = new System.Drawing.Point(3, 73);
            this.label_CurrentState.Name = "label_CurrentState";
            this.label_CurrentState.Size = new System.Drawing.Size(235, 33);
            this.label_CurrentState.TabIndex = 6;
            this.label_CurrentState.Text = "Serial Buffer Size:";
            this.label_CurrentState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 7);
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
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(235, 24);
            this.comboBoxCOMPorts.TabIndex = 0;
            this.comboBoxCOMPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxCOMPorts_SelectedIndexChanged);
            // 
            // buttonConnectSerial
            // 
            this.buttonConnectSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConnectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnectSerial.Location = new System.Drawing.Point(244, 3);
            this.buttonConnectSerial.Name = "buttonConnectSerial";
            this.buttonConnectSerial.Size = new System.Drawing.Size(235, 27);
            this.buttonConnectSerial.TabIndex = 1;
            this.buttonConnectSerial.Text = "Connect Serial";
            this.buttonConnectSerial.UseVisualStyleBackColor = true;
            this.buttonConnectSerial.Click += new System.EventHandler(this.buttonConnectSerial_Click);
            // 
            // label_DataQSize
            // 
            this.label_DataQSize.AutoSize = true;
            this.label_DataQSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DataQSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DataQSize.Location = new System.Drawing.Point(3, 40);
            this.label_DataQSize.Name = "label_DataQSize";
            this.label_DataQSize.Size = new System.Drawing.Size(235, 33);
            this.label_DataQSize.TabIndex = 2;
            this.label_DataQSize.Text = "Data queue size:";
            this.label_DataQSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_DataQSize
            // 
            this.textBox_DataQSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_DataQSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_DataQSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DataQSize.Location = new System.Drawing.Point(244, 43);
            this.textBox_DataQSize.Multiline = true;
            this.textBox_DataQSize.Name = "textBox_DataQSize";
            this.textBox_DataQSize.Size = new System.Drawing.Size(235, 27);
            this.textBox_DataQSize.TabIndex = 9;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 251);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(476, 34);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // textBox_Az
            // 
            this.textBox_Az.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Az.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Az.Location = new System.Drawing.Point(367, 3);
            this.textBox_Az.Multiline = true;
            this.textBox_Az.Name = "textBox_Az";
            this.textBox_Az.Size = new System.Drawing.Size(106, 28);
            this.textBox_Az.TabIndex = 7;
            // 
            // textBox_Ay
            // 
            this.textBox_Ay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Ay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ay.Location = new System.Drawing.Point(209, 3);
            this.textBox_Ay.Multiline = true;
            this.textBox_Ay.Name = "textBox_Ay";
            this.textBox_Ay.Size = new System.Drawing.Size(104, 28);
            this.textBox_Ay.TabIndex = 6;
            // 
            // label_Az
            // 
            this.label_Az.AutoSize = true;
            this.label_Az.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Az.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Az.Location = new System.Drawing.Point(319, 0);
            this.label_Az.Name = "label_Az";
            this.label_Az.Size = new System.Drawing.Size(42, 34);
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
            this.label_Ay.Size = new System.Drawing.Size(42, 34);
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
            this.label_Ax.Size = new System.Drawing.Size(42, 34);
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
            this.textBox_Ax.Size = new System.Drawing.Size(104, 28);
            this.textBox_Ax.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 42);
            this.label2.TabIndex = 31;
            this.label2.Text = "Gestures recorded:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_AxesAverage
            // 
            this.label_AxesAverage.AutoSize = true;
            this.label_AxesAverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_AxesAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AxesAverage.Location = new System.Drawing.Point(3, 330);
            this.label_AxesAverage.Name = "label_AxesAverage";
            this.label_AxesAverage.Size = new System.Drawing.Size(235, 35);
            this.label_AxesAverage.TabIndex = 32;
            this.label_AxesAverage.Text = "Min and Max Values (g):";
            this.label_AxesAverage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel3.Controls.Add(this.label_AverageAx, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_Minx100, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_Miny100, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_AverageAz, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_Minz100, 5, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 368);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(476, 41);
            this.tableLayoutPanel3.TabIndex = 33;
            // 
            // label_AverageAx
            // 
            this.label_AverageAx.AutoSize = true;
            this.label_AverageAx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_AverageAx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AverageAx.Location = new System.Drawing.Point(3, 0);
            this.label_AverageAx.Name = "label_AverageAx";
            this.label_AverageAx.Size = new System.Drawing.Size(42, 41);
            this.label_AverageAx.TabIndex = 0;
            this.label_AverageAx.Text = "Min Ax:";
            this.label_AverageAx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(161, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 41);
            this.label4.TabIndex = 2;
            this.label4.Text = "Min Ay:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Miny100
            // 
            this.textBox_Miny100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Miny100.Location = new System.Drawing.Point(209, 3);
            this.textBox_Miny100.Multiline = true;
            this.textBox_Miny100.Name = "textBox_Miny100";
            this.textBox_Miny100.Size = new System.Drawing.Size(104, 35);
            this.textBox_Miny100.TabIndex = 3;
            // 
            // label_AverageAz
            // 
            this.label_AverageAz.AutoSize = true;
            this.label_AverageAz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_AverageAz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AverageAz.Location = new System.Drawing.Point(319, 0);
            this.label_AverageAz.Name = "label_AverageAz";
            this.label_AverageAz.Size = new System.Drawing.Size(42, 41);
            this.label_AverageAz.TabIndex = 4;
            this.label_AverageAz.Text = "Min Az:";
            this.label_AverageAz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Minz100
            // 
            this.textBox_Minz100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Minz100.Location = new System.Drawing.Point(367, 3);
            this.textBox_Minz100.Multiline = true;
            this.textBox_Minz100.Name = "textBox_Minz100";
            this.textBox_Minz100.Size = new System.Drawing.Size(106, 35);
            this.textBox_Minz100.TabIndex = 5;
            // 
            // button_reset
            // 
            this.button_reset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_reset.Location = new System.Drawing.Point(243, 332);
            this.button_reset.Margin = new System.Windows.Forms.Padding(2);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(237, 31);
            this.button_reset.TabIndex = 36;
            this.button_reset.Text = "Reset Gestures";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // textBox_Orientation
            // 
            this.textBox_Orientation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Orientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Orientation.Location = new System.Drawing.Point(244, 554);
            this.textBox_Orientation.Multiline = true;
            this.textBox_Orientation.Name = "textBox_Orientation";
            this.textBox_Orientation.Size = new System.Drawing.Size(235, 46);
            this.textBox_Orientation.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 551);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 52);
            this.label5.TabIndex = 38;
            this.label5.Text = "Orientation:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPort_MSP430
            // 
            this.serialPort_MSP430.PortName = "COM7";
            this.serialPort_MSP430.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_MSP430_DataReceived);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel4.Controls.Add(this.textBox_Maxz100, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBox_Maxy100, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBox_Maxx100, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 415);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(476, 39);
            this.tableLayoutPanel4.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "Max Ax:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Minx100
            // 
            this.textBox_Minx100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Minx100.Location = new System.Drawing.Point(51, 3);
            this.textBox_Minx100.Multiline = true;
            this.textBox_Minx100.Name = "textBox_Minx100";
            this.textBox_Minx100.Size = new System.Drawing.Size(104, 35);
            this.textBox_Minx100.TabIndex = 1;
            // 
            // textBox_Maxx100
            // 
            this.textBox_Maxx100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Maxx100.Location = new System.Drawing.Point(51, 3);
            this.textBox_Maxx100.Multiline = true;
            this.textBox_Maxx100.Name = "textBox_Maxx100";
            this.textBox_Maxx100.Size = new System.Drawing.Size(104, 33);
            this.textBox_Maxx100.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(161, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 39);
            this.label6.TabIndex = 3;
            this.label6.Text = "Max Ay:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Maxy100
            // 
            this.textBox_Maxy100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Maxy100.Location = new System.Drawing.Point(209, 3);
            this.textBox_Maxy100.Multiline = true;
            this.textBox_Maxy100.Name = "textBox_Maxy100";
            this.textBox_Maxy100.Size = new System.Drawing.Size(104, 33);
            this.textBox_Maxy100.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(319, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 39);
            this.label7.TabIndex = 5;
            this.label7.Text = "Max Az:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Maxz100
            // 
            this.textBox_Maxz100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Maxz100.Location = new System.Drawing.Point(367, 3);
            this.textBox_Maxz100.Multiline = true;
            this.textBox_Maxz100.Name = "textBox_Maxz100";
            this.textBox_Maxz100.Size = new System.Drawing.Size(106, 33);
            this.textBox_Maxz100.TabIndex = 6;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 2);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.87395F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.31933F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.23232F));
            this.tableLayoutPanel5.Controls.Add(this.textBox_TotalAcc, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 460);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(476, 88);
            this.tableLayoutPanel5.TabIndex = 40;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(110, 70);
            this.label.TabIndex = 2;
            this.label.Text = "Total Acc:";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_TotalAcc
            // 
            this.textBox_TotalAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_TotalAcc.Location = new System.Drawing.Point(147, 3);
            this.textBox_TotalAcc.Multiline = true;
            this.textBox_TotalAcc.Name = "textBox_TotalAcc";
            this.textBox_TotalAcc.Size = new System.Drawing.Size(326, 82);
            this.textBox_TotalAcc.TabIndex = 3;
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
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button buttonConnectSerial;
        private System.Windows.Forms.Label label_DataQSize;
        private System.Windows.Forms.Label label_ItemsInQueue;
        private System.Windows.Forms.Label label_CurrentState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_DataQSize;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label_AverageAx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Miny100;
        private System.Windows.Forms.Label label_AverageAz;
        private System.Windows.Forms.TextBox textBox_Minz100;
        private System.Windows.Forms.TextBox textBox_gesturebuffercount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_AxesAverage;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.TextBox textBox_Orientation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Minx100;
        private System.Windows.Forms.TextBox textBox_Maxz100;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Maxy100;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Maxx100;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox textBox_TotalAcc;
        private System.Windows.Forms.Label label;
    }
}

