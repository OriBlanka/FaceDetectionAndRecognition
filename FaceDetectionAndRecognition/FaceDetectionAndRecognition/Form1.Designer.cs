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
            picCapture = new PictureBox();
            caputureBtn = new Button();
            detectFacesBtn = new Button();
            personNameTxtBox = new TextBox();
            addPersonBtn = new Button();
            trainBtn = new Button();
            recognizeBtn = new Button();
            ditectedPic = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picCapture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ditectedPic).BeginInit();
            SuspendLayout();
            // 
            // picCapture
            // 
            picCapture.Location = new Point(12, 12);
            picCapture.Name = "picCapture";
            picCapture.Size = new Size(749, 492);
            picCapture.TabIndex = 0;
            picCapture.TabStop = false;
            // 
            // caputureBtn
            // 
            caputureBtn.Location = new Point(805, 12);
            caputureBtn.Name = "caputureBtn";
            caputureBtn.Size = new Size(166, 31);
            caputureBtn.TabIndex = 1;
            caputureBtn.Text = "1. Capture";
            caputureBtn.UseVisualStyleBackColor = true;
            // 
            // detectFacesBtn
            // 
            detectFacesBtn.Location = new Point(805, 49);
            detectFacesBtn.Name = "detectFacesBtn";
            detectFacesBtn.Size = new Size(166, 31);
            detectFacesBtn.TabIndex = 1;
            detectFacesBtn.Text = "2. Detect Faces";
            detectFacesBtn.UseVisualStyleBackColor = true;
            // 
            // personNameTxtBox
            // 
            personNameTxtBox.Location = new Point(805, 262);
            personNameTxtBox.Name = "personNameTxtBox";
            personNameTxtBox.Size = new Size(166, 23);
            personNameTxtBox.TabIndex = 2;
            // 
            // addPersonBtn
            // 
            addPersonBtn.Location = new Point(805, 306);
            addPersonBtn.Name = "addPersonBtn";
            addPersonBtn.Size = new Size(166, 31);
            addPersonBtn.TabIndex = 1;
            addPersonBtn.Text = "3. Add Person";
            addPersonBtn.UseVisualStyleBackColor = true;
            // 
            // trainBtn
            // 
            trainBtn.Location = new Point(805, 343);
            trainBtn.Name = "trainBtn";
            trainBtn.Size = new Size(166, 31);
            trainBtn.TabIndex = 1;
            trainBtn.Text = "4. Train Images";
            trainBtn.UseVisualStyleBackColor = true;
            // 
            // recognizeBtn
            // 
            recognizeBtn.Location = new Point(805, 394);
            recognizeBtn.Name = "recognizeBtn";
            recognizeBtn.Size = new Size(166, 31);
            recognizeBtn.TabIndex = 1;
            recognizeBtn.Text = "5. Recognize Person";
            recognizeBtn.UseVisualStyleBackColor = true;
            // 
            // ditectedPic
            // 
            ditectedPic.Location = new Point(805, 86);
            ditectedPic.Name = "ditectedPic";
            ditectedPic.Size = new Size(166, 170);
            ditectedPic.TabIndex = 3;
            ditectedPic.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 516);
            Controls.Add(ditectedPic);
            Controls.Add(personNameTxtBox);
            Controls.Add(recognizeBtn);
            Controls.Add(trainBtn);
            Controls.Add(addPersonBtn);
            Controls.Add(detectFacesBtn);
            Controls.Add(caputureBtn);
            Controls.Add(picCapture);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picCapture).EndInit();
            ((System.ComponentModel.ISupportInitialize)ditectedPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picCapture;
        private Button caputureBtn;
        private Button detectFacesBtn;
        private TextBox personNameTxtBox;
        private Button addPersonBtn;
        private Button trainBtn;
        private Button recognizeBtn;
        private PictureBox ditectedPic;
    }
}
