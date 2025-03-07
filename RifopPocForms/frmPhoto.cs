using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


namespace RifopPocForms
{
    public partial class frmPhoto : Form
    {
        private VideoCaptureDevice videoSource;

        public Bitmap CapturedImage {get; private set; }    

        private float zoomFactor = 1.0f;
        private Point scrollPosition = new Point(0, 0);
        private bool isCapturing = true;

        public frmPhoto()
        {
            InitializeComponent();

            buttonZoomIn.Enabled = false;
            buttonZoomOut.Enabled = false;
            hScrollBar1.Enabled = false;
            vScrollBar1.Enabled = false;
        }

        private void frmPhoto_Load(object sender, EventArgs e)
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("Aucune webcam détectée.");
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (isCapturing)
            {
                Bitmap newFrame = (Bitmap)eventArgs.Frame.Clone();
                picPhoto.BeginInvoke((MethodInvoker)delegate
                {
                    
                    picPhoto.Image = newFrame;
                });
            }
        }

        private void UpdatePictureBox()
        {
            if (CapturedImage != null)
            {
                // Créer une image zoomée
                Bitmap zoomedImage = new Bitmap((int)(CapturedImage.Width * zoomFactor), (int)(CapturedImage.Height * zoomFactor));
                using (Graphics g = Graphics.FromImage(zoomedImage))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(CapturedImage, new Rectangle(0, 0, zoomedImage.Width, zoomedImage.Height));
                }

                // Créer une image cadrée
                Bitmap croppedImage = new Bitmap(picPhoto.Width, picPhoto.Height);
                using (Graphics g = Graphics.FromImage(croppedImage))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(zoomedImage, new Rectangle(0, 0, picPhoto.Width, picPhoto.Height), new Rectangle(scrollPosition, picPhoto.Size), GraphicsUnit.Pixel);
                }

                picPhoto.Image = croppedImage;
            }
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            zoomFactor += 0.1f;
            UpdatePictureBox();
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            zoomFactor -= 0.1f;
            if (zoomFactor < 0.1f) zoomFactor = 0.1f;
            UpdatePictureBox();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            scrollPosition.X = e.NewValue;
            UpdatePictureBox();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            scrollPosition.Y = e.NewValue;
            UpdatePictureBox();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (isCapturing)
            {

                StopCapture();
                CapturedImage = (Bitmap)picPhoto.Image.Clone();
                btnCapture.Text = "Nouvelle Capture";
                isCapturing = false;
            }
            else
            {
                StartCapture();
                isCapturing = true;
                btnCapture.Text = "Capturer";
                CapturedImage = null;
            }
            
            // Stockage de l'image capturée
            

           

            // Activation des contrôles de zoom et de cadrage
            buttonZoomIn.Enabled = true;
            buttonZoomOut.Enabled = true;
            hScrollBar1.Enabled = true;
            vScrollBar1.Enabled = true;
        }

        private void StartCapture()
        {
            if (videoSource != null)
                videoSource.Start();
        }

        private void StopCapture()
        {
           
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }

       


        private void frmPhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCapture();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if(CapturedImage != null)
            {
                picPhoto.Image = Image.FromFile(@"D:\Sides International\MEF-HAITI\2024\test api\1456673639_photo.png");
                CapturedImage= (Bitmap)picPhoto.Image.Clone();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
