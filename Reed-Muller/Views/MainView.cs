using System;
using System.Windows.Forms;

namespace Reed_Muller
{
    public partial class MainView : Form
    {
        private readonly Form mainForm;
        private int M { get; set; }

        public MainView(Form mainForm, int m)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            this.mainForm = mainForm;
            M = m;
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        private void VectorBtn_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.Controls.Add(new VectorView(M));
        }

        private void TextBtn_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.Controls.Add(new TextView(M));
        }

        private void ImageBtn_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.Controls.Add(new ImageView(M));
        }
    }
}
