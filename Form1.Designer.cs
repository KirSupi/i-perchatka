namespace UIPerchatka
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox logListBox;


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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            frameCaptureTimer = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            button2 = new Button();
            logListBox = new ListBox();
            textBox1 = new TextBox();
            button3 = new Button();
            CollisionsListBox = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(384, 241);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(404, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(384, 241);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // frameCaptureTimer
            // 
            frameCaptureTimer.Tick += FrameCaptureTimer_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 273);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Start Capture";
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(112, 273);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "Stop Capture";
            button2.Click += Button2_Click;
            // 
            // logListBox
            // 
            logListBox.Location = new Point(12, 310);
            logListBox.Name = "logListBox";
            logListBox.Size = new Size(384, 104);
            logListBox.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(663, 273);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(583, 273);
            button3.Name = "button3";
            button3.Size = new Size(61, 29);
            button3.TabIndex = 5;
            button3.Text = "Enter";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // CollisionsListBox
            // 
            CollisionsListBox.Location = new Point(404, 310);
            CollisionsListBox.Name = "CollisionsListBox";
            CollisionsListBox.Size = new Size(384, 104);
            CollisionsListBox.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 442);
            Controls.Add(CollisionsListBox);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(logListBox);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(button2);
            Name = "Form1";
            Text = "UIPerchatka";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button3;
        private ListBox CollisionsListBox;
    }
}
