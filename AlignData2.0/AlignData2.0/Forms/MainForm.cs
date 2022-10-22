using System;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace AlignData2._0
{
    public partial class AlignData : Form
    {
        //Data tables
        private DataTable handWriting = new DataTable();
        private DataTable gaze = new DataTable();
        //Align Data Object
        private alignData alignDataObject = null;
        //Timestamps used for aligning files.
        private int firstTimeStampHand = 0;
        private int lastTimeStampHand = 0;
        //Json that obtains data from the Json patient info.
        private dynamic JsonPatientInfo = new JObject();
        //Used in case user selects a folder with no data
        private Boolean canVisualizeData;
        //
        private dynamic JsonTaskTimestamp = new JObject();

        private string SavingDirectory;

        public AlignData()
        {
            InitializeComponent();
            alignDataObject = new alignData();
        }

        private void visualizeData()
        {
            //Method that calls all necessary methods to open all the data from the opened folder
            handWriting = alignDataObject.GetHandrwitingData();
            handWriteDataGridView.DataSource = handWriting;

            gaze = alignDataObject.GetGazeData();
            gazeDataGridView.DataSource = gaze;

            if(handWriting.Rows.Count>0)
            {
                firstTimeStampHand = (int)(int.Parse(handWriting.Rows[0][3].ToString(), CultureInfo.InvariantCulture.NumberFormat));
                lastTimeStampHand = (int)(int.Parse(handWriting.Rows[handWriting.Rows.Count - 1][3].ToString(), CultureInfo.InvariantCulture.NumberFormat));
            }
            OpenVideoFile();
            OpenJsonData(GetAlignDataObject());
        }

        private alignData GetAlignDataObject()
        {
            return alignDataObject;
        }

        private void OpenJsonData(alignData alignDataObject)
        {
            //Mehtod that fills all txtx boxes for the "Patient Info" Tab, from the Json: patientInfo.
            JsonPatientInfo = alignDataObject.dataFromJsonPatientInfo();
            this.txtPatientGender.Text = JsonPatientInfo.PatientGender;
            this.txtPatientDateOfBirth.Text = JsonPatientInfo.PatientDateOfBirth;
            this.txtAditionalInfo.Text = JsonPatientInfo.AditionalInfo;
            this.txtBackgroundImageUsed.Text = JsonPatientInfo.BackgroundImageUsed;
            this.txtFileCreatedDate.Text = JsonPatientInfo.NewFileCreated;
            this.txtAdmin.Text = JsonPatientInfo.Administrator;
            this.txtPatientHanded.Text = JsonPatientInfo.PatientHandeness;
            this.txtUsesGlasses.Text = JsonPatientInfo.PatientUseOfGlasses;
            this.txtBoxTotalTimeTest.Text = alignDataObject.getTimeStampToShow(this.lastTimeStampHand - this.firstTimeStampHand);
            JsonTaskTimestamp = alignDataObject.dataFromJsonTaskTimeStamps();
            if (alignDataObject.getIsThereTasTimeStamp())
            {
                this.txtTaskTimeStamp.Text = Newtonsoft.Json.JsonConvert.SerializeObject(JsonTaskTimestamp);
                initializeComboBoxTasks();
            }
            else
            {
                this.txtTaskTimeStamp.Text = "No information provided";
            }
        }

        private void initializeComboBoxTasks()
        {
            List<string> items = new List<string>();
            items.Add("General");
            for (int i=0;i<= alignDataObject.getTaskTimestampDataLength();i++)
            {
                items.Add("Task " + (i+1).ToString());
            }
            comboBoxTasks.DataSource = items;
        }

        private void OpenVideoFile()
        {
            //Method that opens the video from the folder selected. Starts on stop mode.
            axWindowsMediaPlayer1.URL = alignDataObject.getVideoPath();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exectures from "File Open". Opens a folder to let the user select the folder where the data is saved.
            canVisualizeData = true;
            CommonOpenFileDialog openFolderdialog = new CommonOpenFileDialog();
            openFolderdialog.IsFolderPicker = true;
            openFolderdialog.AllowNonFileSystemItems = true;
            openFolderdialog.Multiselect = true;
            openFolderdialog.Title = "Select the folder with HandAQUS files";
            if (openFolderdialog.ShowDialog() != CommonFileDialogResult.Ok)
            {
                MessageBox.Show(@"No Folder was selected!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    alignDataObject.setPath(openFolderdialog.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Folder has no HandWriting Files! Open another.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    canVisualizeData = false;
                }
            }
            if (canVisualizeData)
            {
                try
                {
                    visualizeData();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Folder has no Gaze Data Files! Open another.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    canVisualizeData = false;
                }
            }
            
        }

        private void alignDataToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            //Method that calls to align both files.
            alignDataObject.alignGazeDataFile(this.firstTimeStampHand,this.lastTimeStampHand);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //A message box with info of the student doing the application.
            string messageBoxText = "TFG Dídac Maymo GEISI.";
            string caption = "Align Data APP";
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Method that calls two other methods to save the data from both datatables to CSV files.
            
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = alignDataObject.getPath();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
            {
                MessageBox.Show(@"No Folder was selected!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                SavingDirectory = dialog.FileName;
                if (handWriting.Rows.Count > 0 && gaze.Rows.Count > 0)
                {
                    alignDataObject.saveGazeFileToCSV(SavingDirectory);
                    alignDataObject.saveHandWritingFileToCSV(SavingDirectory);
                    MessageBox.Show(string.Format("Data was saved successfully"), @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show(@"Cannot save null Data Tables!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSelectTask_Click(object sender, EventArgs e)
        {
            //Method to get the selected value from the combo box next to it, used to show data from the selected value.
            if (alignDataObject.getIsThereTasTimeStamp())
            {
                string value = comboBoxTasks.Text;
                selectTaskToAlign(value);
            }
        }

        private void selectTaskToAlign(string value)
        {
            //Method that shows data depending of the task chosen.
            Cursor.Current = Cursors.WaitCursor;
            string start;
            string end;
            int tasks = alignDataObject.getTaskTimestampDataLength() + 1;
            Boolean lessThan9Task = false;
            switch (value)
            {
                case "General":
                    visualizeData();
                    break;
                case "Task 1":
                    end = JsonTaskTimestamp.two;
                    alignDataObject.alignDataForTask(1, this.firstTimeStampHand.ToString(), end, lessThan9Task);
                    break;
                case "Task 2":
                    start = JsonTaskTimestamp.two;
                    if (tasks == 2)
                    {
                        end = this.lastTimeStampHand.ToString(); lessThan9Task = true;
                    }
                    else
                        end = JsonTaskTimestamp.three;
                    alignDataObject.alignDataForTask(2, start, end, lessThan9Task);
                    break;
                case "Task 3":
                    start = JsonTaskTimestamp.three;
                    if (tasks == 3) {
                        end = this.lastTimeStampHand.ToString(); lessThan9Task = true;
                    }
                    else
                        end = JsonTaskTimestamp.four;
                    alignDataObject.alignDataForTask(3, start, end, lessThan9Task);
                    break;
                case "Task 4":
                    start = JsonTaskTimestamp.four;
                    if (tasks == 4)
                    {
                        end = this.lastTimeStampHand.ToString(); lessThan9Task = true;
                    }
                    else
                        end = JsonTaskTimestamp.five;
                    alignDataObject.alignDataForTask(4, start, end, lessThan9Task);
                    break;
                case "Task 5":
                    start = JsonTaskTimestamp.five;
                    if (tasks == 5)
                    {
                        end = this.lastTimeStampHand.ToString(); lessThan9Task = true;
                    }
                    else
                        end = JsonTaskTimestamp.six;
                    alignDataObject.alignDataForTask(5, start, end, lessThan9Task);
                    break;
                case "Task 6":
                    start = JsonTaskTimestamp.six;
                    if (tasks == 6)
                    {
                        end = this.lastTimeStampHand.ToString(); lessThan9Task = true;
                    }
                    else
                        end = JsonTaskTimestamp.seven;
                    alignDataObject.alignDataForTask(6, start, end, lessThan9Task);
                    break;
                case "Task 7":
                    start = JsonTaskTimestamp.seven;
                    if (tasks == 7)
                    {
                        end = this.lastTimeStampHand.ToString(); lessThan9Task = true;
                    }
                    else
                        end = JsonTaskTimestamp.eight;
                    alignDataObject.alignDataForTask(7, start, end, lessThan9Task);
                    break;
                case "Task 8":
                    start = JsonTaskTimestamp.eight;
                    if (tasks == 8)
                    {
                        end = this.lastTimeStampHand.ToString(); lessThan9Task = true;
                    }
                    else
                        end = JsonTaskTimestamp.nine;
                    alignDataObject.alignDataForTask(8, start, end, lessThan9Task);
                    break;
                case "Task 9":
                    start = JsonTaskTimestamp.nine;
                    alignDataObject.alignDataForTask(9, start, this.lastTimeStampHand.ToString(), lessThan9Task);
                    break;
                default:
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnSaveALL_Click(object sender, EventArgs e)
        { //method to save authomatic all tasks
            string text = "Task ";
            for (int i = 1; i <= alignDataObject.getTaskTimestampDataLength()+1; i++)
            {
                text = text + i;
                selectTaskToAlign(text);
                System.Threading.Thread.Sleep(1000);
                saveAutomatic(text);
                System.Threading.Thread.Sleep(1000);
                selectTaskToAlign("General");
                System.Threading.Thread.Sleep(1000);
                text = "Task ";
            }
            MessageBox.Show(string.Format("Data was saved successfully"), @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void saveAutomatic(string task)
        {
            string path = alignDataObject.getPath();
            string newPath = path+@"\"+task;
            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(newPath);
            if (handWriting.Rows.Count > 0 && gaze.Rows.Count > 0)
            {
                alignDataObject.saveGazeFileToCSV(newPath);
                alignDataObject.saveHandWritingFileToCSV(newPath);
            }
            else MessageBox.Show(@"Cannot save null Data Tables!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
