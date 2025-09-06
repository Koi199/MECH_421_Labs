namespace Queues
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
            this.textBox_QueueContent = new System.Windows.Forms.TextBox();
            this.label_QueueContent = new System.Windows.Forms.Label();
            this.textBox_NumberOfItems = new System.Windows.Forms.TextBox();
            this.textBox_Dequeue = new System.Windows.Forms.TextBox();
            this.textBox_Enqueue = new System.Windows.Forms.TextBox();
            this.button_Enqueue = new System.Windows.Forms.Button();
            this.button_Dequeue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Dequeue_And_Average = new System.Windows.Forms.Button();
            this.label_N = new System.Windows.Forms.Label();
            this.textBox_N = new System.Windows.Forms.TextBox();
            this.label_Average = new System.Windows.Forms.Label();
            this.textBox_Average = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.17881F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.82119F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_QueueContent, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label_QueueContent, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox_NumberOfItems, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Dequeue, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Enqueue, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Enqueue, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Dequeue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_Dequeue_And_Average, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_N, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_N, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_Average, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Average, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.777778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.777778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.777778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.777778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.856833F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.941432F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.04989F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 461);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // textBox_QueueContent
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_QueueContent, 4);
            this.textBox_QueueContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_QueueContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_QueueContent.Location = new System.Drawing.Point(3, 200);
            this.textBox_QueueContent.Multiline = true;
            this.textBox_QueueContent.Name = "textBox_QueueContent";
            this.textBox_QueueContent.Size = new System.Drawing.Size(378, 258);
            this.textBox_QueueContent.TabIndex = 21;
            // 
            // label_QueueContent
            // 
            this.label_QueueContent.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label_QueueContent, 2);
            this.label_QueueContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_QueueContent.Location = new System.Drawing.Point(3, 166);
            this.label_QueueContent.Name = "label_QueueContent";
            this.label_QueueContent.Size = new System.Drawing.Size(134, 31);
            this.label_QueueContent.TabIndex = 19;
            this.label_QueueContent.Text = "Queue Contents: ";
            this.label_QueueContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_NumberOfItems
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_NumberOfItems, 2);
            this.textBox_NumberOfItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_NumberOfItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NumberOfItems.Location = new System.Drawing.Point(143, 73);
            this.textBox_NumberOfItems.Multiline = true;
            this.textBox_NumberOfItems.Name = "textBox_NumberOfItems";
            this.textBox_NumberOfItems.Size = new System.Drawing.Size(238, 29);
            this.textBox_NumberOfItems.TabIndex = 14;
            // 
            // textBox_Dequeue
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_Dequeue, 2);
            this.textBox_Dequeue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Dequeue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Dequeue.Location = new System.Drawing.Point(143, 38);
            this.textBox_Dequeue.Multiline = true;
            this.textBox_Dequeue.Name = "textBox_Dequeue";
            this.textBox_Dequeue.Size = new System.Drawing.Size(238, 29);
            this.textBox_Dequeue.TabIndex = 13;
            // 
            // textBox_Enqueue
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_Enqueue, 2);
            this.textBox_Enqueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Enqueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Enqueue.Location = new System.Drawing.Point(143, 3);
            this.textBox_Enqueue.Multiline = true;
            this.textBox_Enqueue.Name = "textBox_Enqueue";
            this.textBox_Enqueue.Size = new System.Drawing.Size(238, 29);
            this.textBox_Enqueue.TabIndex = 11;
            // 
            // button_Enqueue
            // 
            this.button_Enqueue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.SetColumnSpan(this.button_Enqueue, 2);
            this.button_Enqueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Enqueue.Location = new System.Drawing.Point(3, 3);
            this.button_Enqueue.Name = "button_Enqueue";
            this.button_Enqueue.Size = new System.Drawing.Size(134, 29);
            this.button_Enqueue.TabIndex = 1;
            this.button_Enqueue.Text = "Enqueue";
            this.button_Enqueue.UseVisualStyleBackColor = false;
            this.button_Enqueue.Click += new System.EventHandler(this.button_Enqueue_Click);
            // 
            // button_Dequeue
            // 
            this.button_Dequeue.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.SetColumnSpan(this.button_Dequeue, 2);
            this.button_Dequeue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Dequeue.Location = new System.Drawing.Point(3, 38);
            this.button_Dequeue.Name = "button_Dequeue";
            this.button_Dequeue.Size = new System.Drawing.Size(134, 29);
            this.button_Dequeue.TabIndex = 2;
            this.button_Dequeue.Text = "Dequeue";
            this.button_Dequeue.UseVisualStyleBackColor = false;
            this.button_Dequeue.Click += new System.EventHandler(this.button_Dequeue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "Items in Queue";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Dequeue_And_Average
            // 
            this.button_Dequeue_And_Average.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.SetColumnSpan(this.button_Dequeue_And_Average, 4);
            this.button_Dequeue_And_Average.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Dequeue_And_Average.Location = new System.Drawing.Point(3, 108);
            this.button_Dequeue_And_Average.Name = "button_Dequeue_And_Average";
            this.button_Dequeue_And_Average.Size = new System.Drawing.Size(378, 29);
            this.button_Dequeue_And_Average.TabIndex = 9;
            this.button_Dequeue_And_Average.Text = "Dequeue and Average First N Data points";
            this.button_Dequeue_And_Average.UseVisualStyleBackColor = false;
            this.button_Dequeue_And_Average.Click += new System.EventHandler(this.button_Dequeue_And_Average_Click);
            // 
            // label_N
            // 
            this.label_N.AutoSize = true;
            this.label_N.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_N.Location = new System.Drawing.Point(3, 140);
            this.label_N.Name = "label_N";
            this.label_N.Size = new System.Drawing.Size(26, 26);
            this.label_N.TabIndex = 15;
            this.label_N.Text = "N:";
            this.label_N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_N
            // 
            this.textBox_N.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_N.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_N.Location = new System.Drawing.Point(35, 143);
            this.textBox_N.Name = "textBox_N";
            this.textBox_N.Size = new System.Drawing.Size(102, 21);
            this.textBox_N.TabIndex = 16;
            // 
            // label_Average
            // 
            this.label_Average.AutoSize = true;
            this.label_Average.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Average.Location = new System.Drawing.Point(143, 140);
            this.label_Average.Name = "label_Average";
            this.label_Average.Size = new System.Drawing.Size(97, 26);
            this.label_Average.TabIndex = 17;
            this.label_Average.Text = "Average: ";
            this.label_Average.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Average
            // 
            this.textBox_Average.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Average.Location = new System.Drawing.Point(246, 143);
            this.textBox_Average.Name = "textBox_Average";
            this.textBox_Average.Size = new System.Drawing.Size(135, 20);
            this.textBox_Average.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_Enqueue;
        private System.Windows.Forms.Button button_Dequeue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Dequeue_And_Average;
        private System.Windows.Forms.TextBox textBox_NumberOfItems;
        private System.Windows.Forms.TextBox textBox_Dequeue;
        private System.Windows.Forms.TextBox textBox_Enqueue;
        private System.Windows.Forms.Label label_N;
        private System.Windows.Forms.TextBox textBox_N;
        private System.Windows.Forms.Label label_Average;
        private System.Windows.Forms.Label label_QueueContent;
        private System.Windows.Forms.TextBox textBox_Average;
        private System.Windows.Forms.TextBox textBox_QueueContent;
    }
}

