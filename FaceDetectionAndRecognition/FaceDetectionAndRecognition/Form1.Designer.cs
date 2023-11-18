namespace FaceDetectionAndRecognition
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
            this.capturePic = new System.Windows.Forms.PictureBox();
            this.captureBtn = new System.Windows.Forms.Button();
            this.detectBtn = new System.Windows.Forms.Button();
            this.addPersonBtn = new System.Windows.Forms.Button();
            this.trainBtn = new System.Windows.Forms.Button();
            this.recognizeBtn = new System.Windows.Forms.Button();
            this.personNameTxtBox = new System.Windows.Forms.TextBox();
            this.detectedPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.capturePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectedPic)).BeginInit();
            this.SuspendLayout();
            // 
            // capturePic
            // 
            this.capturePic.Location = new System.Drawing.Point(13, 13);
            this.capturePic.Name = "capturePic";
            this.capturePic.Size = new System.Drawing.Size(612, 425);
            this.capturePic.TabIndex = 0;
            this.capturePic.TabStop = false;
            // 
            // captureBtn
            // 
            this.captureBtn.Location = new System.Drawing.Point(648, 13);
            this.captureBtn.Name = "captureBtn";
            this.captureBtn.Size = new System.Drawing.Size(140, 32);
            this.captureBtn.TabIndex = 1;
            this.captureBtn.Text = "1. Capture";
            this.captureBtn.UseVisualStyleBackColor = true;
            this.captureBtn.Click += new System.EventHandler(this.captureBtn_Click);
            // 
            // detectBtn
            // 
            this.detectBtn.Location = new System.Drawing.Point(648, 51);
            this.detectBtn.Name = "detectBtn";
            this.detectBtn.Size = new System.Drawing.Size(140, 32);
            this.detectBtn.TabIndex = 1;
            this.detectBtn.Text = "2. Detect Faces";
            this.detectBtn.UseVisualStyleBackColor = true;
            this.detectBtn.Click += new System.EventHandler(this.detectBtn_Click);
            // 
            // addPersonBtn
            // 
            this.addPersonBtn.Location = new System.Drawing.Point(648, 272);
            this.addPersonBtn.Name = "addPersonBtn";
            this.addPersonBtn.Size = new System.Drawing.Size(140, 32);
            this.addPersonBtn.TabIndex = 1;
            this.addPersonBtn.Text = "3. Add Person";
            this.addPersonBtn.UseVisualStyleBackColor = true;
            // 
            // trainBtn
            // 
            this.trainBtn.Location = new System.Drawing.Point(648, 310);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(140, 32);
            this.trainBtn.TabIndex = 1;
            this.trainBtn.Text = "4. Train Images";
            this.trainBtn.UseVisualStyleBackColor = true;
            // 
            // recognizeBtn
            // 
            this.recognizeBtn.Location = new System.Drawing.Point(648, 348);
            this.recognizeBtn.Name = "recognizeBtn";
            this.recognizeBtn.Size = new System.Drawing.Size(140, 32);
            this.recognizeBtn.TabIndex = 1;
            this.recognizeBtn.Text = "5. Recognize Persons";
            this.recognizeBtn.UseVisualStyleBackColor = true;
            // 
            // personNameTxtBox
            // 
            this.personNameTxtBox.Location = new System.Drawing.Point(648, 246);
            this.personNameTxtBox.Name = "personNameTxtBox";
            this.personNameTxtBox.Size = new System.Drawing.Size(140, 20);
            this.personNameTxtBox.TabIndex = 2;
            // 
            // detectedPic
            // 
            this.detectedPic.Location = new System.Drawing.Point(648, 100);
            this.detectedPic.Name = "detectedPic";
            this.detectedPic.Size = new System.Drawing.Size(140, 129);
            this.detectedPic.TabIndex = 3;
            this.detectedPic.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.detectedPic);
            this.Controls.Add(this.personNameTxtBox);
            this.Controls.Add(this.recognizeBtn);
            this.Controls.Add(this.trainBtn);
            this.Controls.Add(this.addPersonBtn);
            this.Controls.Add(this.detectBtn);
            this.Controls.Add(this.captureBtn);
            this.Controls.Add(this.capturePic);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.capturePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detectedPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox capturePic;
        private System.Windows.Forms.Button captureBtn;
        private System.Windows.Forms.Button detectBtn;
        private System.Windows.Forms.Button addPersonBtn;
        private System.Windows.Forms.Button trainBtn;
        private System.Windows.Forms.Button recognizeBtn;
        private System.Windows.Forms.TextBox personNameTxtBox;
        private System.Windows.Forms.PictureBox detectedPic;
    }
}

