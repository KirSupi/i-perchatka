using AForge.Video;
using AForge.Video.DirectShow;
using System.Text.Json;


namespace UIPerchatka
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private System.Windows.Forms.Timer frameCaptureTimer;
        private CCR.Recognizer r;
        public int radius { get; private set; }

        public Form1()
        {
            var redColor = new CCR.Color(
               new[]
               {
                new CCR.Range(0, 15), new CCR.Range(340, 360)
               },
               new[]
               {
                new CCR.Range(90, 100)
               },
               new[]
               {
                new CCR.Range(80, 100)
               }
           );

            var blueColor = new CCR.Color(
              new[]
              {
               new CCR.Range(200,250)
              },
              new[]
              {
                new CCR.Range(80, 100)
              },
              new[]
              {
                new CCR.Range(60, 100)
              }
          );

            var colors = new Dictionary<string, CCR.Color>();
            colors["red"] = redColor;
            colors["blue"] = blueColor;
            r = new CCR.Recognizer(colors);

            Console.WriteLine("Recognizer created");
            Console.WriteLine(r);
            InitializeComponent();
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (webcam.Count == 0)
            {
                throw new Exception("��� ��������� ��������� ������� �����");
            }
            cam = new VideoCaptureDevice(webcam[0].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            // ������������� �������
            frameCaptureTimer = new System.Windows.Forms.Timer();
            frameCaptureTimer.Interval = 100; // ������ ����� ������ 100 ��
        }
        private void FrameCaptureTimer_Tick(object sender, EventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                ProcessFrameAndDisplayResults();
            }
        }


        private Bitmap previousBitmap = null;
        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (pictureBox1.IsDisposed || pictureBox1.Disposing || this.IsDisposed || this.Disposing)
                return;

            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            bit.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Bitmap resized = new Bitmap(bit, new Size(pictureBox1.Width, pictureBox1.Height));

            this.Invoke(new MethodInvoker(() =>
            {
                if (!pictureBox1.IsDisposed && !pictureBox1.Disposing)
                {
                    pictureBox1.Image = resized;
                }
            }));

            previousBitmap?.Dispose();
            previousBitmap = resized;
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            if (cam != null && !cam.IsRunning)
            {
                cam.Start();
                frameCaptureTimer.Tick += new EventHandler(FrameCaptureTimer_Tick);
                frameCaptureTimer.Start(); // ������ ������� ��� ������ �������
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.SignalToStop();
                cam.WaitForStop();
                pictureBox1.Image = null;
                frameCaptureTimer.Stop(); // ��������� ������� ��� ��������� �������
            }
        }
        private void ProcessFrameAndDisplayResults()
        {
            if (pictureBox1.Image != null)
            {
                // ��������� ����������� ��� ���������
                Bitmap clonedImage = new Bitmap(pictureBox1.Image);
                var recognizedColors = new Dictionary<string, bool>();

                // ��������� ������������� �� ������������� �����������
                Bitmap processedImage = r.SuperimposeRecognizedPoints(ref clonedImage, out recognizedColors);

                // ��������� UI � ������, � ������� �� ��� ������
                this.Invoke(new MethodInvoker(() =>
                {
                    pictureBox2.Image = processedImage;
                    UpdateCollisionListAndLogs(clonedImage, recognizedColors);
                }));

                clonedImage.Dispose();
            }
        }

        private void UpdateCollisionListAndLogs(Bitmap processedImage, Dictionary<string, bool> recognizedColors)
        {
            CollisionsListBox.Items.Clear();
            CollisionsListBox.Items.Add(
                JsonSerializer.Serialize(
                    r.RecognizeColorCollisions(ref processedImage),
                    new JsonSerializerOptions()
                )
            );
            DisplayRecognitionLogs(recognizedColors);
        }

   

        private void DisplayRecognitionLogs(Dictionary<string, bool> logs)
        {
            logListBox.Items.Clear();
            foreach (var log in logs)
            {
                logListBox.Items.Add($"{log.Key}: {(log.Value ? "Detected" : "Not Detected")}");
            }
        }

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.SignalToStop();
                cam.WaitForStop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int newRadius) && newRadius > 0)
            {
                radius = newRadius;
            }
            else
            {
                MessageBox.Show("������� ���������� �������� �������.");
            }
        }

    }
}
