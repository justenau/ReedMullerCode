using System;
using System.Windows.Forms;
using Reed_Muller.Coding;
using Encoder = Reed_Muller.Coding.Encoder;
using Decoder = Reed_Muller.Coding.Decoder;
using Reed_Muller.Views;
using Reed_Muller.Utils;
using Reed_Muller.Models;
using System.Threading;

namespace Reed_Muller
{
    public partial class TextView : UserControl
    {
        private int M { get; set; }
        private readonly ProbabilityPanel probabilityPanel = new ProbabilityPanel();
        public string SentEncodedResult { get; set; }
        public string SentNotEncodedResult { get; set; }
        public TextView(int m)
        {
            InitializeComponent();
            probabilityPanel.SendBtn.Click += SendBtn_Click;
            pPanel.Controls.Add(probabilityPanel);
            M = m;
        }

        /// <summary>
        /// When "Send" button is clicked, a new thread is run not to block the main thread. 
        /// "Send" button is disabled until the thread finished its job.
        /// Input text is converted to vectors, which are sent through the channel with provided
        /// error probability p. Text is sent two ways - encoded and later decoded after receiving it
        /// from the channel and not encoded. 
        /// </summary>
        private void SendBtn_Click(object sender, EventArgs e)
        {
            probabilityPanel.SendBtn.Enabled = false;
            new Thread(() =>
            {
                // If no text is provided, cancel further processes
                if (messageBox.Text.Length == 0)
                {
                    BeginInvoke((Action)(() =>
                    {
                        encodedTextBox.Text = "";
                        notEncodedTextBox.Text = "";
                        probabilityPanel.SendBtn.Enabled = true;
                        return;
                    }));
                }

                var p = probabilityPanel.P;
                var textToBinary = ConversionUtils.CovertStringToBinaryArray(messageBox.Text);
                var inputTextVector = new Vector(textToBinary);

                // Handling 'out of memory' failure
                try
                {
                    // Ecode input text vectors
                    var encodedTextVectors = Encoder.EncodeBinarySequence(inputTextVector, M, out int additionalBitCount);

                    // Sent (not)encoded text vectors through the channel
                    var receivedEncodedTextVector = Channel.SendBinaryMessage(encodedTextVectors, p, out _);
                    var receivedNotEncodedTextVector = Channel.SendBinaryMessage(inputTextVector, p, out _);

                    // Decoded received encoded text vector
                    var decodedText = Decoder.DecodeBinarySequence(receivedEncodedTextVector, M);

                    SentEncodedResult = ConversionUtils.ConvertBinaryArrayToString(decodedText.Data, additionalBitCount);
                    SentNotEncodedResult = ConversionUtils.ConvertBinaryArrayToString(receivedNotEncodedTextVector.Data, 0);
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("System is out of memory!");
                    return;
                }

                BeginInvoke((Action)(()=>{
                    encodedTextBox.Text = SentEncodedResult;
                    notEncodedTextBox.Text = SentNotEncodedResult;
                    probabilityPanel.SendBtn.Enabled = true;
                }));
            }).Start();
        }

    }
}
