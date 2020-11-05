using System;
using System.Windows.Forms;

namespace Reed_Muller
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try { Application.Run(new ConfigurationForm()); }
            catch(OutOfMemoryException)
            {
                MessageBox.Show("System is out of memory");
            }
        }
    }
}
