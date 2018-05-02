namespace TuringMachine
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
            this.DrawingArea = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MultiplierTxtEntry = new System.Windows.Forms.TextBox();
            this.RunButton = new System.Windows.Forms.Button();
            this.Speed = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawingArea
            // 
            this.DrawingArea.BackColor = System.Drawing.SystemColors.Window;
            this.DrawingArea.Location = new System.Drawing.Point(12, 12);
            this.DrawingArea.Name = "DrawingArea";
            this.DrawingArea.Size = new System.Drawing.Size(1304, 561);
            this.DrawingArea.TabIndex = 0;
            this.DrawingArea.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 622);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // MultiplierTxtEntry
            // 
            this.MultiplierTxtEntry.Location = new System.Drawing.Point(41, 633);
            this.MultiplierTxtEntry.Name = "MultiplierTxtEntry";
            this.MultiplierTxtEntry.Size = new System.Drawing.Size(364, 20);
            this.MultiplierTxtEntry.TabIndex = 2;
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(552, 622);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(80, 40);
            this.RunButton.TabIndex = 3;
            this.RunButton.Text = "Start & Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // Speed
            // 
            this.Speed.Location = new System.Drawing.Point(654, 617);
            this.Speed.Maximum = 1000;
            this.Speed.Minimum = 500;
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(184, 45);
            this.Speed.TabIndex = 4;
            this.Speed.Value = 500;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 814);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.MultiplierTxtEntry);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DrawingArea);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawingArea;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox MultiplierTxtEntry;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.TrackBar Speed;
    }
}