namespace MouseTracker
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
            this.Label_XCoord = new System.Windows.Forms.Label();
            this.Label_YCoord = new System.Windows.Forms.Label();
            this.textBox_XCoord = new System.Windows.Forms.TextBox();
            this.textBox_YCoord = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_recordedClicks = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_XCoord
            // 
            this.Label_XCoord.AutoSize = true;
            this.Label_XCoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_XCoord.Location = new System.Drawing.Point(10, 10);
            this.Label_XCoord.Name = "Label_XCoord";
            this.Label_XCoord.Size = new System.Drawing.Size(18, 15);
            this.Label_XCoord.TabIndex = 0;
            this.Label_XCoord.Text = "X:";
            // 
            // Label_YCoord
            // 
            this.Label_YCoord.AutoSize = true;
            this.Label_YCoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_YCoord.Location = new System.Drawing.Point(10, 30);
            this.Label_YCoord.Name = "Label_YCoord";
            this.Label_YCoord.Size = new System.Drawing.Size(17, 15);
            this.Label_YCoord.TabIndex = 1;
            this.Label_YCoord.Text = "Y:";
            // 
            // textBox_XCoord
            // 
            this.textBox_XCoord.Location = new System.Drawing.Point(30, 10);
            this.textBox_XCoord.Name = "textBox_XCoord";
            this.textBox_XCoord.Size = new System.Drawing.Size(78, 20);
            this.textBox_XCoord.TabIndex = 2;
            // 
            // textBox_YCoord
            // 
            this.textBox_YCoord.Location = new System.Drawing.Point(30, 30);
            this.textBox_YCoord.Name = "textBox_YCoord";
            this.textBox_YCoord.Size = new System.Drawing.Size(78, 20);
            this.textBox_YCoord.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(114, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(430, 441);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Recorded Clicks:";
            // 
            // textBox_recordedClicks
            // 
            this.textBox_recordedClicks.Location = new System.Drawing.Point(1, 91);
            this.textBox_recordedClicks.Multiline = true;
            this.textBox_recordedClicks.Name = "textBox_recordedClicks";
            this.textBox_recordedClicks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_recordedClicks.Size = new System.Drawing.Size(110, 350);
            this.textBox_recordedClicks.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 441);
            this.Controls.Add(this.textBox_recordedClicks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_YCoord);
            this.Controls.Add(this.textBox_XCoord);
            this.Controls.Add(this.Label_YCoord);
            this.Controls.Add(this.Label_XCoord);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_XCoord;
        private System.Windows.Forms.Label Label_YCoord;
        private System.Windows.Forms.TextBox textBox_XCoord;
        private System.Windows.Forms.TextBox textBox_YCoord;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_recordedClicks;
    }
}

