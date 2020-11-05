using System;
using System.Windows.Forms;
using Reed_Muller.Logic;
using Encoder = Reed_Muller.Logic.Encoder;
using Decoder = Reed_Muller.Logic.Decoder;

namespace Reed_Muller
{
    public partial class TextView : UserControl
    {
        private int M { get; set; }
        public TextView(int m)
        {
            InitializeComponent();
            pInput.Minimum = 0.00000m;
            pInput.DecimalPlaces = 5;
            pInput.Increment = 0.00001m;
            pInput.Maximum = 1;
            M = m;
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if(messageBox.Text.Length == 0)
            { 
                encodedTextBox.Text = "";
                messageTextBox.Text = "";
                return;
            }
            var p = decimal.ToDouble(Math.Truncate(pInput.Value * 100000m) / 100000m);
            var textToBinary = ConversionUtils.CovertStringToBinaryArray(messageBox.Text);

            var encodedText = Encoder.EncodeBinarySequence(textToBinary, M, out int additionalBitCount);

            var receivedEncodedText = Channel.SendBinaryMessage(encodedText, p, out _);
            var receivedMessage = Channel.SendBinaryMessage(textToBinary, p, out _);

            var decodedText = Decoder.DecodeBinarySequence(receivedEncodedText, M);

            var sentEncodedResult = ConversionUtils.ConvertBinaryArrayToString(decodedText, additionalBitCount);
            var sentMessageResult = ConversionUtils.ConvertBinaryArrayToString(receivedMessage, 0);

            encodedTextBox.Text = sentEncodedResult;
            messageTextBox.Text = sentMessageResult;
        }

        private void PValueInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
        }
    }
}
