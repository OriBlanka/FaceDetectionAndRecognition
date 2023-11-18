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
using System.IO;
using System.Threading;
using System.Diagnostics;

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
        Image<Bgr, Byte> faceResult = null;
        List<Image<Gray, Byte>> trainedFaces = new List<Image<Gray, byte>>();
        List<int> personsLabels = new List<int>();
        bool enableSaveImage = false;
        private static bool isTrained = false;
        EigenFaceRecognizer recognizer;
        List<string> personsNames = new List<string>();

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

                        // Step 3: Add person
                        // Assign the face to the picture box face detectedPic
                        Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                        resultImage.ROI = face;
                        detectedPic.SizeMode = PictureBoxSizeMode.StretchImage;
                        detectedPic.Image = resultImage.Bitmap;

                        if (enableSaveImage)
                        {
                            // Create a directory if doesn't exists!
                            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }

                            // save 10 images with delay a second for each image
                            // to avoid GUI hangs we will use another task
                            Task.Factory.StartNew(() => {
                                for (int i = 0; i < 10; i++)
                                {
                                    //resize the image then saving it
                                    resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + personNameTxtBox.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                    Thread.Sleep(1000);
                                }
                            });
                        }
                        enableSaveImage = false;    

                        // Step 5: Recognize the face
                        if (isTrained)
                        {
                            Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                            var result = recognizer.Predict(grayFaceResult);
                           
                            // Result found known faces
                            if(result.Label > 0)
                            {
                                CvInvoke.PutText(currentFrame, personsNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyScriptSimplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                            }
                            // Results didn't found any faces
                            else
                            {
                                CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2), 
                                    FontFace.HersheyScriptSimplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                            }
                       

                        }
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

        private void addPersonBtn_Click(object sender, EventArgs e)
        {
            saveBtn.Enabled = true;
            addPersonBtn.Enabled = false;
            enableSaveImage = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveBtn.Enabled = false;
            addPersonBtn.Enabled = true;
            enableSaveImage = false;
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            TrainImagesFromDir();
        }

        //Step 4: train images - we'll use the save images from the previous example
        private bool TrainImagesFromDir()
        {
            int imageesCount = 0;
            double treshold = -1;
           
            trainedFaces.Clear();
            personsLabels.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedFaces";
                string [] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, Byte> trainedImage = new Image<Gray, byte>(file);
                    trainedFaces.Add(trainedImage);
                    personsLabels.Add(imageesCount);
                    imageesCount = imageesCount + 1;
                } 

                EigenFaceRecognizer recognizer = new EigenFaceRecognizer(imageesCount, treshold);
                recognizer.Train(trainedFaces.ToArray(), personsLabels.ToArray());
                isTrained = true;
                Debug.WriteLine(imageesCount);
                Debug.WriteLine(isTrained);
                return true;
            }
            catch (Exception ex)
            {
                return isTrained = false;
                MessageBox.Show("Error in train images: " + ex.Message);
            }
        }
    }
}
