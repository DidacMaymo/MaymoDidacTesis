using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HandAQUS
{
    public partial class admin_window : Form
    {

        // Prepare logger
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public admin_window()
        {
            InitializeComponent();
        }

        private void Admin_button_Click(object sender, EventArgs e)
        {
            Submit_data();
        }

        private void Admin_button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Submit_data();
            }
        }

        private void Submit_data()
        {
            // Check if there is Administrator name filled proeprly
            if (admin_name_box.TextLength < 3)
            {
                _logger.Error($"Administrator name is not set properly {admin_name_box.Text}");

                // Close the Window
                Close();

                MessageBox.Show(
                    @"Please set the Administrator name correctly.",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

            }
            // Setup the name
            HandAQUS.Administrator = admin_name_box.Text;

            // Close the Window
            Close();

        }

    }
}
