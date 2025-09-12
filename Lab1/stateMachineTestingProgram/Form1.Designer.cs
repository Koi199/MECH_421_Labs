namespace stateMachineTestingProgram
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_CurrentState = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_Az = new System.Windows.Forms.TextBox();
            this.textBox_Ay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_Ax = new System.Windows.Forms.Label();
            this.textBox_Ax = new System.Windows.Forms.TextBox();
            this.button_ProcessNewDataPoint = new System.Windows.Forms.Button();
            this.textBox_CurrentState = new System.Windows.Forms.TextBox();
            this.label_DataHistory = new System.Windows.Forms.Label();
            this.textBox_DataHistory = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_GestureReg = new System.Windows.Forms.TextBox();
            this.label_Gesture = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.label_CurrentState, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_ProcessNewDataPoint, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_CurrentState, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_DataHistory, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_DataHistory, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 591);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_CurrentState
            // 
            this.label_CurrentState.AutoSize = true;
            this.label_CurrentState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_CurrentState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_CurrentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurrentState.Location = new System.Drawing.Point(163, 118);
            this.label_CurrentState.Name = "label_CurrentState";
            this.label_CurrentState.Size = new System.Drawing.Size(154, 59);
            this.label_CurrentState.TabIndex = 3;
            this.label_CurrentState.Text = "Current State:";
            this.label_CurrentState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.Controls.Add(this.textBox_Az, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Ay, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_Ax, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_Ax, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(476, 53);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textBox_Az
            // 
            this.textBox_Az.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Az.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Az.Location = new System.Drawing.Point(369, 3);
            this.textBox_Az.Multiline = true;
            this.textBox_Az.Name = "textBox_Az";
            this.textBox_Az.Size = new System.Drawing.Size(104, 47);
            this.textBox_Az.TabIndex = 7;
            // 
            // textBox_Ay
            // 
            this.textBox_Ay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Ay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ay.Location = new System.Drawing.Point(212, 3);
            this.textBox_Ay.Multiline = true;
            this.textBox_Ay.Name = "textBox_Ay";
            this.textBox_Ay.Size = new System.Drawing.Size(99, 47);
            this.textBox_Ay.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(317, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 53);
            this.label4.TabIndex = 4;
            this.label4.Text = "Az: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 53);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ay: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Ax
            // 
            this.label_Ax.AutoSize = true;
            this.label_Ax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Ax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Ax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ax.Location = new System.Drawing.Point(3, 0);
            this.label_Ax.Name = "label_Ax";
            this.label_Ax.Size = new System.Drawing.Size(46, 53);
            this.label_Ax.TabIndex = 0;
            this.label_Ax.Text = "Ax: ";
            this.label_Ax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Ax
            // 
            this.textBox_Ax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Ax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ax.Location = new System.Drawing.Point(55, 3);
            this.textBox_Ax.Multiline = true;
            this.textBox_Ax.Name = "textBox_Ax";
            this.textBox_Ax.Size = new System.Drawing.Size(99, 47);
            this.textBox_Ax.TabIndex = 5;
            this.textBox_Ax.TextChanged += new System.EventHandler(this.textBox_Ax_TextChanged);
            // 
            // button_ProcessNewDataPoint
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button_ProcessNewDataPoint, 3);
            this.button_ProcessNewDataPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ProcessNewDataPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ProcessNewDataPoint.Location = new System.Drawing.Point(3, 62);
            this.button_ProcessNewDataPoint.Name = "button_ProcessNewDataPoint";
            this.button_ProcessNewDataPoint.Size = new System.Drawing.Size(476, 53);
            this.button_ProcessNewDataPoint.TabIndex = 1;
            this.button_ProcessNewDataPoint.Text = "Process New Data Point";
            this.button_ProcessNewDataPoint.UseVisualStyleBackColor = true;
            this.button_ProcessNewDataPoint.Click += new System.EventHandler(this.button_ProcessNewDataPoint_Click);
            // 
            // textBox_CurrentState
            // 
            this.textBox_CurrentState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_CurrentState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CurrentState.Location = new System.Drawing.Point(323, 121);
            this.textBox_CurrentState.Multiline = true;
            this.textBox_CurrentState.Name = "textBox_CurrentState";
            this.textBox_CurrentState.Size = new System.Drawing.Size(156, 53);
            this.textBox_CurrentState.TabIndex = 4;
            this.textBox_CurrentState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_DataHistory
            // 
            this.label_DataHistory.AutoSize = true;
            this.label_DataHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_DataHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DataHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DataHistory.Location = new System.Drawing.Point(3, 177);
            this.label_DataHistory.Name = "label_DataHistory";
            this.label_DataHistory.Size = new System.Drawing.Size(154, 59);
            this.label_DataHistory.TabIndex = 5;
            this.label_DataHistory.Text = "Data History:";
            this.label_DataHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_DataHistory
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_DataHistory, 3);
            this.textBox_DataHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_DataHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DataHistory.Location = new System.Drawing.Point(3, 239);
            this.textBox_DataHistory.Multiline = true;
            this.textBox_DataHistory.Name = "textBox_DataHistory";
            this.textBox_DataHistory.Size = new System.Drawing.Size(476, 349);
            this.textBox_DataHistory.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.textBox_GestureReg, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label_Gesture, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(163, 180);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(154, 53);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // textBox_GestureReg
            // 
            this.textBox_GestureReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_GestureReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_GestureReg.Location = new System.Drawing.Point(4, 30);
            this.textBox_GestureReg.Multiline = true;
            this.textBox_GestureReg.Name = "textBox_GestureReg";
            this.textBox_GestureReg.Size = new System.Drawing.Size(146, 19);
            this.textBox_GestureReg.TabIndex = 10;
            this.textBox_GestureReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Gesture
            // 
            this.label_Gesture.AutoSize = true;
            this.label_Gesture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Gesture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Gesture.Location = new System.Drawing.Point(4, 1);
            this.label_Gesture.Name = "label_Gesture";
            this.label_Gesture.Size = new System.Drawing.Size(146, 25);
            this.label_Gesture.TabIndex = 11;
            this.label_Gesture.Text = "Gesture: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 591);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_Ax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Ax;
        private System.Windows.Forms.TextBox textBox_Az;
        private System.Windows.Forms.TextBox textBox_Ay;
        private System.Windows.Forms.Button button_ProcessNewDataPoint;
        private System.Windows.Forms.Label label_CurrentState;
        private System.Windows.Forms.TextBox textBox_CurrentState;
        private System.Windows.Forms.Label label_DataHistory;
        private System.Windows.Forms.TextBox textBox_DataHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBox_GestureReg;
        private System.Windows.Forms.Label label_Gesture;
    }
}

