using HandAQUS.API;
using System;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace HandAQUS
{
    //TFG
    //Tobii Pro Glasses 3 Forms.
    public partial class TobiiPROGlasses3 : Form
    {
        private G3 g3Object;
        private HandAQUS HandAQUS_instace;
        private string path;
        
        //Boolean to control how many times a recording is canceled for one Recoring Object.
        //Glasses tend to disconnect when canceled twice. They need aprox a min to function again.
        private bool cancelRecording = false;
        private string SavingDirectory = null;

        private int recordingTask = 1;
        private List<string> listTimeStampTasks= new List<string>();
        private dynamic jsonTaskInfo = new JObject();

        public TobiiPROGlasses3()
        {
            InitializeComponent();
            disableButtons("initialize");
            this.MaximumSize = new System.Drawing.Size(668, 412);
        }

        private void btnFindGlasses_Click(object sender, EventArgs e)
        {
            //Method for button "Find Glasses" that initilises the G3 object.
            try
            {
                g3Object = new G3();
                disableButtons("find");
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show(
                    @"Glasses Not connected! Please connect them via WIFI.",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Debug.WriteLine("Message :{0} ", ex.Message);
            }
            cancelRecording = false;
        }

        private void btnCallibrate_Click(object sender, EventArgs e)
        {
            //Method for button "Callibrate" that calls calibration of object, and creates new recording.
            try
            {
                g3Object.callibrate();
                g3Object.createRecording();
                disableButtons("callibrate");
            }
            catch (System.Net.WebException ex)
            {
                Debug.WriteLine("Message :{0} ", ex.Message);
            }

        }

        private void btnStartRec_Click(object sender, EventArgs e)
        {
            //Method for button "Start" that calls "start recording" of G3 object.
            try
            {
                listTimeStampTasks = new List<string>();
                g3Object.StartRecording();
                disableButtons("start");
            }
            catch (System.Net.WebException ex)
            {
                Debug.WriteLine("Message :{0} ", ex.Message);
            }

        }

        private void btnStopRec_Click(object sender, EventArgs e)
        {
            //Method for button "Stop" that calls "Stop recording" of G3 object.
            try
            {
                g3Object.StopRecording();
                disableButtons("stop");
            }
            catch (System.Net.WebException ex)
            {
                Debug.WriteLine("Message :{0} ", ex.Message);
            }
        }

        private void btnSaveRec_Click(object sender, EventArgs e)
        {
            //Method for button "Save" that calls "Save recording" of G3 object.
            disableButtons("saveStarts");
            // Set cursor as wait.
            Application.UseWaitCursor = true;
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = "C:\\Users";
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    SavingDirectory = dialog.FileName; 
                    this.path = SavingDirectory;
                    g3Object.saveRecording(SavingDirectory, "file");
                }
            }
            catch (System.Net.WebException ex)
            {
                Debug.WriteLine("Message :{0} ", ex.Message);
            }
            HandAQUS_instace = System.Windows.Forms.Application.OpenForms.OfType<HandAQUS>().FirstOrDefault();
            if (HandAQUS_instace != null)
            {
                HandAQUS_instace.saveSVCFileFromGlassesSave(path);
            }
            // Set cursor as default.
            Application.UseWaitCursor = false;
            saveFileWithPatientInfoInJSON(this.path);
            this.recordingTask = 1;
            this.lblNumberTask.Text = this.recordingTask.ToString();
            this.Close();
        }

        private void btnCancelRec_Click(object sender, EventArgs e)
        {
            //Method for button "Cancel" that calls "Cancel recording" of G3 object.
            //If this is the second time canceling, form closes.
            try
            {
                if (cancelRecording)
                {
                    this.Close();
                }
                g3Object.cancelRecording();
                disableButtons("cancel");
                cancelRecording = true;
                this.recordingTask = 1;
                this.lblNumberTask.Text = this.recordingTask.ToString();
            }
            catch (System.Net.WebException ex)
            {
                Debug.WriteLine("Message :{0} ", ex.Message);
            }

        }

        private void btnGazeOFF_Click(object sender, EventArgs e)
        {
            //A method for button "Gaze Off" that calls "GazeOff" of G3 object.
            try
            {
                g3Object.GazeOff();
                disableButtons("gazeoff");
            }
            catch (System.Net.WebException ex)
            {
                Debug.WriteLine("Message :{0} ", ex.Message);
            }
        }

        private void disableButtons(string button)
        {
            //Swtitch method to enable and disable the buttons of TobiiGlasses3 Forms.
            switch (button)
            {
                case "initialize":
                    btnCallibrate.Enabled = false;
                    btnCancelRec.Enabled = false;
                    btnSaveRecording.Enabled = false;
                    btnSTART.Enabled = false;
                    btnSTOP.Enabled = false;
                    btnGazeOFF.Enabled = false;
                    pictureBox1.Enabled = false;
                    btnAddTask.Enabled = false;
                    break;
                case "find":
                    btnCallibrate.Enabled = true;
                    btnFindGlasses.Enabled = false;
                    pictureBox1.Enabled = true;
                    LblForButtons.Text = "Glasses Found. Next Step: CALLIBRATE.";
                    break;
                case "callibrate":
                    btnSTART.Enabled = true;
                    btnCancelRec.Enabled = true;
                    btnGazeOFF.Enabled = true;
                    btnCallibrate.Enabled = false;
                    LblForButtons.Text = "Callibrated. Next Step: START Recording";
                    break;
                case "start":
                    btnSTOP.Enabled = true;
                    btnCallibrate.Enabled = false;
                    btnSTART.Enabled = false;
                    btnGazeOFF.Enabled = false;
                    btnAddTask.Enabled = true;
                    LblForButtons.Text = "Glasses Recording. Next Step: STOP Recording";
                    break;

                case "stop":
                    btnSaveRecording.Enabled = true;
                    btnSTOP.Enabled = false;
                    btnCancelRec.Enabled = false;
                    btnAddTask.Enabled = false;
                    LblForButtons.Text = "Recording Stopped. Next Step: SAVE Recording";
                    break;

                case "saveStarts":
                    btnSaveRecording.Enabled = false;
                    pictureBox1.Enabled = false;
                    LblForButtons.Text = "Recording Saving. PLEASE WAIT until data is saved";
                    break;

                case "cancel":
                    btnCallibrate.Enabled = true;
                    btnCancelRec.Enabled = false;
                    btnSaveRecording.Enabled = false;
                    btnSTART.Enabled = false;
                    btnSTOP.Enabled = false;
                    btnAddTask.Enabled = false;
                    LblForButtons.Text = "Canceling Recording. Next Step: Calibrate Glasses.";
                    break;
                case "gazeoff":
                    btnGazeOFF.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void TobiiPROGlasses3_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Method to control when form has to close, of maximize, minimize.
            this.Hide();
            e.Cancel = true;
            btnFindGlasses.Enabled = true;
            btnCallibrate.Enabled = false;
            btnCancelRec.Enabled = false;
            btnSaveRecording.Enabled = false;
            btnSTART.Enabled = false;
            btnSTOP.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Method to open web browser with TobiiGlasses3 IP, to see live video and other many API funcitons.
            System.Diagnostics.Process.Start("http://192.168.75.51/live.html");
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            //Method to add the task's number when button pressed.
            if (this.recordingTask < 9)
            {
                this.recordingTask++;
                this.lblNumberTask.Text = this.recordingTask.ToString();
                this.listTimeStampTasks.Add(DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ssffffff"));
            }
            
        }
        private void saveFileWithPatientInfoInJSON(string path)
        {
            //TFG
            //Method to save file of task's timestamps in JSON object.
            int counter = 2;
            foreach(string timeStamp in this.listTimeStampTasks)
            {
                addToJSON(counter, timeStamp);
                counter++;
            }
            var json_fname = String.Format("{0}/{1}.json", path, "fileTimeStampTasks");
            using (StreamWriter file = File.CreateText(json_fname))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                this.jsonTaskInfo.WriteTo(writer);
            }
        }

        private void addToJSON(int counter,string timeStamp)
        {
            //This methos lets adding values to json of aprox 15 jsons. Each timestamp goes with the startint time of the tasks number.
            switch (counter)
            {
                /*case 1:
                    this.jsonTaskInfo.one = timeStamp;
                    break;*/
                case 2:
                    this.jsonTaskInfo.two = timeStamp;
                    break;
                case 3:
                    this.jsonTaskInfo.three = timeStamp;
                    break;
                case 4:
                    this.jsonTaskInfo.four = timeStamp;
                    break;
                case 5:
                    this.jsonTaskInfo.five = timeStamp;
                    break;
                case 6:
                    this.jsonTaskInfo.six = timeStamp;
                    break;
                case 7:
                    this.jsonTaskInfo.seven = timeStamp;
                    break;
                case 8:
                    this.jsonTaskInfo.eight = timeStamp;
                    break;
                case 9:
                    this.jsonTaskInfo.nine = timeStamp;
                    break;
                default:
                    break;
            }
        }
    }
}
