using Emgu.CV;
using Emgu.CV.Structure;


namespace FaceDetectionAndRecognition
{
    public partial class Form1 : Form
    {
        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
        HaarCascade faceDetected;
        Image<Bgr, Byte> frame;
        Capture camera;
        Image<Gray, byte> result;
        Image<Gray, byte> TrainedFace = null;
        Image<Gray, byte> grayFace = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> users = new List<string>();
        int count, numLabels, t;
        string name, names = null;
        public Form1()
        {
            InitializeComponent();
            //HaarCasade is for the face detection
            faceDetected = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                string labelsinf = File.ReadAllText(Application.StartupPath + "/Faces/Faces.txt");
                string[] Labels = labelsinf.Split(',');

                // The first label before, eill be the number of faces saved
                numLabels = Convert.ToInt16(Labels[0]);
                count = numLabels;

                string facesLoad;
                for (int i = 1; i < numLabels + 1; i++)
                {
                    facesLoad = "face" + i + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/Faces/Faces.txt"));
                    labels.Add(Labels[i]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nothing in the Database");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            camera = new Capture();
            camera.QueryFrame();
            Application.Idle += new EventHandler(FrameProcedure);
        }

        private void FrameProcedure(object sender, EventArgs e)
        {
            users.Add("");
            frame = camera.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            grayFace = frame.Convert<Gray, Byte>();
            MCvAvgComp[][] faceDetectedNow = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp face in faceDetectedNow[0])
            {
                result = frame.Copy(face.rect).Convert<Gray, Byte>().Resize(100,100,Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                frame.Draw(face.rect, new Bgr(Color.Green), 3);
                if (trainingImages.ToArray().Length != 0)
                {
                    MCvTermCriteria termCriterias = new MCvTermCriteria(count, 0.001);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 1500, ref termCriterias);
                    name = recognizer.Recognize(result);
                    frame.Draw(name, ref font, new Point(face.rect.X - 2, face.rect.Y - 2), new Bgr(Color.Red));
                }

                users[t - 1] = name;
                users.Add("");
            }

            cameraBox.Image = frame.ToBitmap();
            names = "";
            users.Clear();
        }
    }
}
