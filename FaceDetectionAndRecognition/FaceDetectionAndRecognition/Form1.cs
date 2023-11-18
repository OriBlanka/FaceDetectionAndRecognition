using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;

namespace FaceDetectionAndRecognition
{
    public partial class Form1 : Form
    {
        #region Variables
        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        private bool faceDetectionEnabled = false;
        CascadeClassifier faceCascadeClassifier = new CascadeClassifier(@"C:\haarcascades\haarcascade_frontalface_alt_tree.xml");

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void captureBtn_Click(object sender, EventArgs e)
        {
            videoCapture = new Capture();
            videoCapture.ImageGrabbed += ProcessFrame;
            videoCapture.Start();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            // Step 1: Video Capture
            videoCapture.Retrieve(frame, 0);
            currentFrame = frame.ToImage<Bgr, Byte>().Resize(capturePic.Width, capturePic.Height, Inter.Cubic);

            // Step 2: Face Detection
            if (faceDetectionEnabled)
            {
                // Convert the Bgr to Gray Image
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                // Enhance the image to get better result
                CvInvoke.EqualizeHist(grayImage, grayImage);

                Rectangle[] faces = faceCascadeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                // If faces detected
                if (faces.Length > 0)
                {
                    foreach (var face in faces)
                    {
                        // Draw squrae around each face
                        CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);
                    }
                }
            }

            // Render the video into the Picture Box capturePic
            capturePic.Image = currentFrame.Bitmap;
        }

        private void detectBtn_Click(object sender, EventArgs e)
        {
            faceDetectionEnabled = true;

        }
    }
}
