using System;
using System.Windows.Forms;


namespace HandAQUS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var app = new HandAQUS();
            if (app.TestWintabAvailible() || app.ReadOnlyMode)
            {
                try
                {
                    Application.Run(app);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error: The HandAQUS crashed. Original error: " + ex.Message,
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}