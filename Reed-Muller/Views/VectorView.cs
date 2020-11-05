using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Reed_Muller.Coding;
using Reed_Muller.Views;
using Reed_Muller.Models;
using Reed_Muller.Utils;

namespace Reed_Muller
{
    public partial class VectorView : UserControl
    {
        private int M { get; set; }
        private int VectorLength { get; set; }
        private Vector EncodedVector { get; set; }
        private Vector ReceivedVector { get; set; }

        private readonly ProbabilityPanel panel = new ProbabilityPanel();

        public VectorView(int m)
        {
            InitializeComponent();
            panel.SendBtn.Click += SendBtn_Click;
            panel.ChangeComponentVisibility(false);
            pPanel.Controls.Add(panel);
            M = m;
            VectorLength = m + 1;
            vectorLengthLabel.Text = VectorLength.ToString();
            inputField.MaxLength = VectorLength;
        }

        /// <summary>
        /// Convert input text to vector and encode it. Handle cases of incorrect format input.
        /// </summary>
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
            var inputVector = new Vector(input);
            EncodedVector = inputVector.Encode(M);
            encodedVectorLabel.Text = ConversionUtils.ConvertIntegerArrayToString(EncodedVector.Data);
            ChangeEncodingFieldVisibility(true);
            ChangeDecodedFieldVisibility(false);
            ChangeDecodingFieldVisibility(false);
        }

        /// <summary>
        /// Send encoded vector through the channel with provided error probability p.
        /// </summary>
        private void SendBtn_Click(object sender, EventArgs e)
        {
            var p = panel.P;
            ReceivedVector = Channel.SendBinaryMessage(EncodedVector, p, out List<int> distortedPlaces);

            receivedVectorField.Text = ConversionUtils.ConvertIntegerArrayToString(ReceivedVector.Data);
            distortionPlaceholder.Text = string.Join(",", distortedPlaces);
            ChangeDecodingFieldVisibility(true);
            ChangeDecodedFieldVisibility(false);

        }

        /// <summary>
        /// Decode the vector which was received through the channel or altered by the user.
        /// Handle cases where after user modifications vector length is incorrect or it contains other digits than 0s or 1s
        /// </summary>
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
            ReceivedVector.Data = ConversionUtils.ConvertStringToIntegerArray(vector);
            var decodedVector = ReceivedVector.Decode(M);
            decodedField.Text = ConversionUtils.ConvertIntegerArrayToString(decodedVector.Data);
            ChangeDecodedFieldVisibility(true);
        }

        private void ChangeEncodingFieldVisibility(bool isVisible)
        {
            encodedLabel.Visible = isVisible;
            encodedVectorLabel.Visible = isVisible;
            panel.ChangeComponentVisibility(isVisible);
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
    }
}
