using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reed_Muller.Logic;

namespace Reed_Muller
{
    public partial class ImageView : UserControl
    {
        public Bitmap UploadedImage { get; set; }
        private int M { get; set; }
        public ImageView(int m)
        {
            InitializeComponent();
            pInput.Minimum = 0.00000m;
            pInput.DecimalPlaces = 5;
            pInput.Increment = 0.00001m;
            pInput.Maximum = 1;
            M = m;
        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {
            var opnfd = new OpenFileDialog
            {
                Filter = "BMP | *.bmp"
            };
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                UploadedImage = new Bitmap(opnfd.FileName);
                uploadedPic.Image = UploadedImage;
                ChangeSendControlsVisibility(true);
                ChangeReceivedControlsVisibility(false);
            }
        }

        private void SendImageBtn_Click(object sender, EventArgs e)
        {
            var bitmapToVector = ConversionUtils.ConvertBitmapToIntArray(UploadedImage);
            ChangeReceivedControlsVisibility(true);
        }

        private void ChangeSendControlsVisibility(bool isVisible)
        {
            pInput.Visible = isVisible;
            pLabel.Visible = isVisible;
            sendImageBtn.Visible = isVisible;
        }

        private void ChangeReceivedControlsVisibility(bool isVisible)
        {
            encodedLabel.Visible = isVisible;
            notEncodedLabel.Visible = isVisible;
            encodedPicture.Visible = isVisible;
            notEncodedPicture.Visible = isVisible;
        }

    }
}
