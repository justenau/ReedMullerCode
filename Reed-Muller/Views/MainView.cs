using Reed_Muller.Logic.Matrixes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reed_Muller
{
    public partial class MainView : Form
    {
        private Form mainForm;
        private int m { get; set; }

        public MainView(Form mainForm, int m)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            this.mainForm = mainForm;
            this.m = m;
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
            GeneratorMatrix.RefreshMatrixes();
            HadamardTransformMatrix.RefreshMatrixes();
        }

        private void vectorBtn_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.Controls.Add(new VectorView(m));
        }

        private void textBtn_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.Controls.Add(new TextView(m));
        }

        private void imageBtn_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.Controls.Add(new ImageView(m));
        }
    }
}
