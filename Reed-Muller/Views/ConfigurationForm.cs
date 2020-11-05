using Reed_Muller.Models;
using System;
using System.Windows.Forms;

namespace Reed_Muller
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mValue.Minimum = 1;
            mValue.DecimalPlaces = 0;
        }
        /// <summary>
        /// Clear old matrixes and calculate generator and identity matrixes before launching next view.
        /// </summary>
        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            var m = decimal.ToInt32(mValue.Value);
            GeneratorMatrix.PrepareMatrixes(m);
            HadamardTransformMatrix.PrepareHadamardTransformMatrixes(m);

            new MainView(this, m).Show();
            Hide();
        }
    }
}
