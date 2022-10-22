using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace HandAQUS
{
    public partial class object_info : Form
    {
        // Prepare logger
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public object_info()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void Submit_data()
        {
            // Check if there is Administrator name filled proeprly
            if (gender_box.SelectedItem == null)
            {
                _logger.Error($"Gender has not been set!");
                MessageBox.Show( @"Please set the Gender of the Subject.",@"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                // Set a gender
                HandAQUS.ObjectGender = gender_box.SelectedItem.ToString();
            }
            if (PatientUsesGlassesBox.SelectedItem == null)
            {
                _logger.Error($"Patient use of Glasses has not been set");
                MessageBox.Show(@"Please set if Subject uses Glasses.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //TFG  Set patient use of glasses
                HandAQUS.PatientUseOfGlasses = PatientUsesGlassesBox.SelectedItem.ToString();
            }
            if (HandedNessOfPatientBox.SelectedItem == null)
            {
                _logger.Error($"Hadnedness has not been set!");
                MessageBox.Show(@"Please set the Hadnedness of the Subject.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //TFG  Set patient Handeness
                HandAQUS.PatientHandeness = HandedNessOfPatientBox.SelectedItem.ToString();
            }
            if (dateTimePicker1.Value.Date == DateTime.Now.Date)
            {
                _logger.Error($"Date of birth set to today!");
                MessageBox.Show(@"Please select a day of birth of the Subject.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Set a date
                HandAQUS.ObjectDateOfBirth = dateTimePicker1.Value.Date;
                // Close the Window
                Close();
            }
        }

        private void object_info_button_Click(object sender, EventArgs e)
        {
            Submit_data();
            submit_aditional_data();
        }

        private void object_info_KeyDown(object sender, KeyEventArgs e)
        {
            Submit_data();
            submit_aditional_data();
        }

        private void submit_aditional_data()
        {
            if (txtBox_aditional_Info != null)
            {
                HandAQUS.txtBox_aditional_Info = txtBox_aditional_Info.Text.ToString();
            }
        }
    }
}
