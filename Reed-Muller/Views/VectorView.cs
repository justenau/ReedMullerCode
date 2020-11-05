using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Reed_Muller.Logic;
using Decoder = Reed_Muller.Logic.Decoder;

namespace Reed_Muller
{
    public partial class VectorView : UserControl
    {
        private int M { get; set; }
        private int VectorLength { get; set; }
        private int[] EncodedVector { get; set; }
        private int[] ReceivedVector { get; set; }

        public VectorView(int m)
        {
            InitializeComponent();
            M = m;
            VectorLength = m + 1;
            pValueInput.Minimum = 0.00000m;
            pValueInput.DecimalPlaces = 5;
            pValueInput.Increment = 0.00001m;
            pValueInput.Maximum = 1;
            vectorLengthLabel.Text = VectorLength.ToString();
            inputField.MaxLength = VectorLength;
        }

        private void EncodeBtn_Click(object sender, EventArgs e)
        {
            var input = inputField.Text;
            if (input.Length != VectorLength)
            {
                MessageBox.Show($"Vector length must be {VectorLength}!");
                return;
            }
            if (!new Regex($"^[01]+$").IsMatch(input))
            {
                MessageBox.Show($"Vector can contain only 0 or 1.");
                return;
            }

            EncodedVector = Encoder.EncodeSingleVector(input.Select(n => int.Parse(n.ToString())).ToArray(), M);
            encodedVectorLabel.Text = string.Join("", EncodedVector);
            ChangeEncodingFieldVisibility(true);
            ChangeDecodingFieldVisibility(false);
            ChangeDecodingFieldVisibility(false);

        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            var p = decimal.ToDouble(Math.Truncate(pValueInput.Value * 100000m) / 100000m);
            ReceivedVector = Channel.SendBinaryMessage(EncodedVector, p, out List<int> distortedPlaces);

            receivedVectorField.Text = ConversionUtils.ConvertIntegerArrayToString(ReceivedVector);
            distortionPlaceholder.Text = string.Join(",", distortedPlaces);
            ChangeDecodingFieldVisibility(true);
            ChangeDecodedFieldVisibility(false);

        }

        private void DecodeBtn_Click(object sender, EventArgs e)
        {
            var vector = receivedVectorField.Text;
            if (vector.Length != ReceivedVector.Length)
            {
                MessageBox.Show($"Vector length must be {ReceivedVector.Length}!");
                return;
            }
            if (!new Regex($"^[01]+$").IsMatch(vector))
            {
                MessageBox.Show($"Vector can contain only 0 or 1.");
                return;
            }
            var decodedVector = Decoder.Decode(ConversionUtils.ConvertStringToIntegerArray(vector), M);
            decodedField.Text = ConversionUtils.ConvertIntegerArrayToString(decodedVector);
            ChangeDecodedFieldVisibility(true);
        }

        private void ChangeEncodingFieldVisibility(bool isVisible)
        {
            ChangeDecodingFieldVisibility(false);
            encodedLabel.Visible = isVisible;
            encodedVectorLabel.Visible = isVisible;
            pLabel.Visible = isVisible;
            pValueInput.Visible = isVisible;
            sendBtn.Visible = isVisible;
        }

        private void ChangeDecodingFieldVisibility(bool isVisible)
        {
            receivedVectorLabel.Visible = isVisible;
            receivedVectorField.Visible = isVisible;
            distortionLabel.Visible = isVisible;
            distortionPlaceholder.Visible = isVisible;
            decodeBtn.Visible = isVisible;
        }

        private void ChangeDecodedFieldVisibility(bool isVisible)
        {
            decodedField.Visible = isVisible;
            decodedLabel.Visible = isVisible;
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
