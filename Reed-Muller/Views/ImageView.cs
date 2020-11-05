using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Reed_Muller.Coding;
using Reed_Muller.Views;
using Reed_Muller.Utils;
using Reed_Muller.Models;
using Encoder = Reed_Muller.Coding.Encoder;
using Decoder = Reed_Muller.Coding.Decoder;
using System.Threading;

namespace Reed_Muller
{
    public partial class ImageView : UserControl
    {
        public Bitmap UploadedImage { get; set; }
        private int M { get; set; }
        private ProbabilityPanel panel = new ProbabilityPanel();
        public Image DeconvertedNotEncoded { get; set; } = null;
        public Image DeconvertedEncoded { get; set; } = null;
        public ImageView(int m)
        {
            InitializeComponent();
            panel.SendBtn.Click += SendImageBtn_Click;
            panel.ChangeComponentVisibility(false);
            pPanel.Controls.Add(panel);
            M = m;
        }

        /// <summary>
        /// Choose and upload Bitmap file to proceed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                panel.ChangeComponentVisibility(true);
                ChangeReceivedControlsVisibility(false);
            }
        }

        /// <summary>
        /// When "Send" button is clicked, a new thread is run not to block the main thread. 
        /// "Send" button is disabled until the thread finished its job.
        /// Input image is converted to vectors, which are sent through the channel with provided
        /// error probability p. Image vectors are sent two ways - encoded and later decoded after receiving them
        /// from the channel and not encoded. 
        /// </summary>
        private void SendImageBtn_Click(object sender, EventArgs e)
        {
            panel.SendBtn.Enabled = false;
            new Thread(() =>
            {
                var p = panel.P;

                // Convert image to vectors and separate the header (it is not sent through the channel)
                var bitmapToVector = new Vector(ConversionUtils.ConvertBitmapToIntArray(UploadedImage));
                var bitmapHeader = bitmapToVector.Data.Take(54 * 8);
                var bitmapVectorToSend = new Vector(bitmapToVector.Data.Skip(54 * 8).ToArray());

                try
                {
                    // Encode input image vectors
                    var encodedVector = Encoder.EncodeBinarySequence(bitmapVectorToSend, M, out int additionalBits);

                    // Send (not)encoded vectors through the channel
                    var receivedNotEncoded = Channel.SendBinaryMessage(bitmapVectorToSend, p, out _);
                    var receivedEncoded = Channel.SendBinaryMessage(encodedVector, p, out _);

                    // Decode received encoded vectors
                    var decoded = Decoder.DecodeBinarySequence(receivedEncoded, M);

                    DeconvertedNotEncoded = ConversionUtils.ConvertIntArrayToImage(bitmapHeader.Concat(receivedNotEncoded.Data).ToArray());
                    DeconvertedNotEncoded = ConversionUtils.ConvertIntArrayToImage(bitmapHeader.Concat(decoded.Data).ToArray(), additionalBits);
                }
                // Handling 'out of memory' failure
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("System is out of memory!");
                    return;
                }
                // There can be cases where corrupted Bitmap is provided and cannot be reconverted to the image
                catch
                {
                    MessageBox.Show("Corrupted Bitmap has been provided.");
                    this.BeginInvoke((Action)(() =>
                    {
                        panel.SendBtn.Enabled = true;
                        return;
                    }));
                }

            this.BeginInvoke((Action)(() =>
            {
                notEncodedPicture.Image = DeconvertedNotEncoded;
                encodedPicture.Image = DeconvertedNotEncoded;
                panel.SendBtn.Enabled = true;
                this.ChangeReceivedControlsVisibility(true);
            }));
            }).Start();
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
