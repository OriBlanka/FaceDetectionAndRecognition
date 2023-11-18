namespace FaceDetectionAndRecognition
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cameraBox = new PictureBox();
            startButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cameraBox).BeginInit();
            SuspendLayout();
            // 
            // cameraBox
            // 
            cameraBox.Location = new Point(12, 22);
            cameraBox.Name = "cameraBox";
            cameraBox.Size = new Size(408, 404);
            cameraBox.TabIndex = 0;
            cameraBox.TabStop = false;
            // 
            // startButton
            // 
            startButton.Location = new Point(560, 78);
            startButton.Name = "startButton";
            startButton.Size = new Size(105, 43);
            startButton.TabIndex = 1;
            startButton.Text = "Start Detection and Recognition";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startButton);
            Controls.Add(cameraBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)cameraBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox cameraBox;
        private Button startButton;
    }
}
