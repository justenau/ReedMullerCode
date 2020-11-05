using System;
using System.Windows.Forms;

namespace Reed_Muller.Views
{
    public partial class ProbabilityPanel : UserControl
    {
        public double P { get { return decimal.ToDouble(Math.Truncate(pInput.Value * 100000m) / 100000m); } set { } }
        public Button SendBtn { get { return sendMessageBtn; } set { } }
        public ProbabilityPanel()
        {
            InitializeComponent();
            pInput.Minimum = 0.00000m;
            pInput.DecimalPlaces = 5;
            pInput.Increment = 0.00001m;
            pInput.Maximum = 1;
        }

        /// <summary>
        /// Allow using both '.' and ',' as decimal delimiters
        /// </summary>
        private void PValueInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
        }

        public void ChangeComponentVisibility(bool isVisible)
        {
            pInput.Visible = isVisible;
            label.Visible = isVisible;
            sendMessageBtn.Visible = isVisible;
        }
    }
}
