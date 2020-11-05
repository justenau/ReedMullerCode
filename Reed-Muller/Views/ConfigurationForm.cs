using Reed_Muller.Logic.Matrixes;
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

        private void continueBtn_Click(object sender, EventArgs e)
        {
            // Calculate matrix before launching program
            GeneratorMatrix.GetGeneratorMatrix(decimal.ToInt32(mValue.Value));
            //var a = HadamardTransformMatrix.GetTransformedMatrix(3, 3);
            new MainView(this, decimal.ToInt32(mValue.Value)).Show();
            this.Hide();
        }
    }
}
