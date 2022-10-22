using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HandAQUS.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using Ookii.Dialogs.WinForms;

namespace HandAQUS
{
    public partial class HandAQUS : Form
    {
        // This keep loaded data from *svc file
        private readonly List<long[]> _openFileList = new List<long[]>();

        // Variables for autoSave
        private string _saveFolderPath;
        private string _saveFolderName;
        private string _saveFileName;
        private uint _saveFileCounter;
        private string _administrator;
        private string _objectGender;
        private DateTime _objectDateOfBirth;
        private string _stateBeforeDebug;


        // Public variables
        public static string Administrator;
        public static string ObjectGender;
        public static DateTime ObjectDateOfBirth;
        public static string txtBox_aditional_Info;
        public static string PatientUseOfGlasses;
        public static string PatientHandeness;

        // Prepare logger
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        // Wacom Manager object
        private readonly WacomManager _wacomManager;

        private TobiiPROGlasses3 tobiiPROGlasses;
        private Image imageBackgroundTest;
        private string svcPath;
        private string pathBackgroundTestImage;
        private dynamic JsonPatientInfo  = new JObject();

        public HandAQUS()
        {
            InitializeComponent();
            Shown += OpenScrible;
            _logger.Info("HandAQUS started.");
            _wacomManager = new WacomManager(scribblePanel, stateLabel);
            tobiiPROGlasses = new TobiiPROGlasses3();
            imageBackgroundTest = Resources.handwiriting_test;
        }

        public bool ReadOnlyMode { get; private set; }

        private void OpenScrible(object sender, EventArgs e)
        {
            // If read only mode is selected shows environment only for reading
            if (ReadOnlyMode)
            {
                _logger.Info("Read-only mode is active.");
                _logger.Debug($"Size of scribble panel is: {scribblePanel.Size}");
                saveButton.Visible = false;
                autoSaveButton.Visible = false;
                addFolderButton.Visible = false;
                switchModeButton.Visible = true;
                switchModeButton.Enabled = true;
                debugButton.Visible = false;
                objectInfo.Visible = false;
                stateLabel.Text = @"Read-only mode is active";
                stateLabel.ForeColor = Color.DarkGreen;
                
            }
            // If Tablet is connected Acquisition is allowed
            else
            {
                StartFullMode();
            }
        }

        private void StartFullMode()
        {
            // Set administrator name, otherwise do not allow do continue
            while (_administrator == null || _administrator.Length < 3)
            {
                SetAdmin();
            }

            _logger.Info($"Administrar name is set to: {_administrator}");
            stateLabel.Text = $@"Administrator: {_administrator}";

            //Setup the axis and max pressure from tablet data
            _wacomManager.SetAxisAndPressureMax();
            //Start scribble
            _wacomManager.StartScribble();

            _logger.Info("Full mode is active.");
            _logger.Debug($"Size of scribble panel is: {scribblePanel.Size}");
        }

        private void SetAdmin()
        {
            // Call window for admin name
            var adminForm = new admin_window();
            adminForm.ShowDialog();
            
            // Save to private
            _administrator = Administrator;            
        }

        private string GetFileName()
        {
            var currentDate = $"{DateTime.Now:dd-MM-yyyy}";
            if (_objectDateOfBirth == DateTime.MinValue || _objectGender == null)
            {
                return $"{_saveFolderName}_{_saveFileCounter.ToString().PadLeft(4, '0')}_{_administrator}_{currentDate}.svc";
            }
            return $"{_saveFolderName}_{_objectDateOfBirth:dd-MM-yyyy}_{_objectGender[0]}" +
                   $"_{_saveFileCounter.ToString().PadLeft(4, '0')}_{_administrator}_{currentDate}.svc";

        }


        private void addFolderButton_Click(object sender, EventArgs e)
        {
            // Prepare folder browser dialog
            var folderBrowser = new VistaFolderBrowserDialog();

            // If previously, folder was open then put it as actual folder
            if (_saveFolderPath != null)
            {
                folderBrowser.SelectedPath = _saveFolderPath;
            }

            // Now map folder for autosave
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                _saveFileCounter = 1;
                _objectGender = null;
                _objectDateOfBirth = DateTime.MinValue;

                // Set Folder path
                _saveFolderPath = folderBrowser.SelectedPath;

                // First, check if directory is empty
                if (Directory.GetFiles(_saveFolderPath).Length != 0 ||
                    Directory.GetDirectories(_saveFolderPath).Length != 0)
                {
                    
                    _logger.Info($"Folder {_saveFolderPath} is not Empty!");

                    // If it is not empty ask if wish to continue
                    var dialogResult = MessageBox.Show(
                        @$"Folder {_saveFolderPath} is not empty! Do you wish to continue acquisition after last saved file?",
                        @"Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);


                    // If Yes, use last file name and get its task number to continue acquisition from there
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Get last file
                        var file = new DirectoryInfo(_saveFolderPath).GetFiles().OrderByDescending(o => o.CreationTime).FirstOrDefault();

                        // Check if file is not null
                        if (file == null)
                        {
                            var message = $"There is no appropriate file in folder {_saveFolderPath}.";
                            _logger.Error($"File is null. {message}");

                            MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Get object data
                        var objectData = file.Name.Split('_');

                        // Check for data format
                        if (objectData.Length == 6)
                        {
                            _objectDateOfBirth = Convert.ToDateTime(objectData[1]);
                            _objectGender = objectData[2];
                            _saveFileCounter = UInt32.Parse(objectData[3]) + 1;
                        }
                        // Check for data format
                        else if (objectData.Length == 4)
                        {

                            _objectGender = null;
                            _objectDateOfBirth = DateTime.MinValue;
                            _saveFileCounter = UInt32.Parse(objectData[1]) + 1;
                        }
                        // Notify user
                        else
                        {
                            var message = $"There is no appropriate file in folder {_saveFolderPath}.";
                            _logger.Error($"{message}");

                            MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        _logger.Info($"Folder {_saveFolderPath} was selected, but there are some files!");
                        _logger.Info($"Acqusition will continue from file number {_saveFileCounter}.");
                        _logger.Info($"Object data has been overwritten from file: " +
                                     $"admin: {_administrator}, " +
                                     $"date of birth: {_objectDateOfBirth}, " +
                                     $"gender: {_objectGender}, " +
                                     $"file counter: {_saveFileCounter}.");
                    }
                    else
                    {
                        _logger.Info($"Folder {_saveFolderPath} was not selected.");
                        return;
                    }
                }


                // Set Folder name
                _saveFolderName = _saveFolderPath.Split('\\').Last();
                // Set File name
                _saveFileName = GetFileName();
                // Show name of file
                stateLabel.Text = _saveFileName;
                autoSaveButton.Enabled = true;

                _logger.Info($"Folder {_saveFolderPath}, has been mapped.");
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            // If there are some unsaved captured data, ask to continue
            if (_wacomManager.SessionData.Any())
            {
                var dialogResult = MessageBox.Show(
                    @"All captured data will be lost.
Do you want to continue?",
                    @"Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                // If yes delete data and continue with loading
                if (dialogResult == DialogResult.Yes)
                {
                    _wacomManager.StopScribble();
                    _logger.Debug("Scribble Panel has been cleared. (loadButton_Click)");
                }
                else
                {
                    return;
                }
            }

            // There are no data captured so *.svc file can be loaded.
            // Initialize File Dialog for file selection
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"svc files (*.svc)|*.svc|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            // Filter .svc files only
            // Restore from last directory

            // Initial clear of list variable 
            _openFileList.Clear();

            // Choose file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Open stream for file processing
                    using var myStream = openFileDialog.OpenFile();
                    // Clear panel
                    scribblePanel.Invalidate();

                    // Read file line by line and store it to var
                    var lines = File.ReadAllLines(openFileDialog.FileName);

                    // Convert lines (strings) to numbers and store them into List
                    foreach (var line in lines)
                    {
                        // Trim spaces on begin and end of string
                        var tLine = line.Trim();
                        // Split by space (' ') and convert to number
                        var numbers = Array.ConvertAll(tLine.Split(' '), long.Parse);

                        // Revert y-axis.
                        // Y-axis has been reverted while reading packet due to proper visualization on windows screen
                        if (numbers.Length > 1)
                        {
                            numbers[1] = _wacomManager.GetMaxTabletY() - numbers[1];
                        }

                        // Add values to List
                        _openFileList.Add(numbers);
                    }

                    _logger.Debug(
                        $"Data from file {openFileDialog.FileName} has been loaded, size is: {_openFileList.Count}.");
                    // Now draw data
                    _wacomManager.DrawDataFromFile(_openFileList);
                    // Disable possibility to save again loaded data
                    saveButton.Enabled = false;
                    autoSaveButton.Enabled = false;

                    // Clear data
                    _openFileList.Clear();
                    _logger.Debug($"File has been cleared, the size is: {_openFileList.Count}.");
                    // Close stream
                    myStream.Close();

                    // Disable option to capture data from tablet
                    _wacomManager.StopScribble();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $@"Error: Could not read file from disk (line: {_openFileList.Count}). Original error: {ex.Message}",
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveSVCFile(); 
        }
        private void saveSVCFile()
        {
            // This cause that no other data will be captured
            // Also cursor control by pen stay disabled
            _wacomManager.PauseScribble();
            _logger.Debug("Attempt to save a file.");

            _saveFileName = _administrator;

            // First check if there is some data, than continue
            if (_wacomManager.SessionData.Any())
            {
                // Initialize File Dialog for save file
                var saveFile = new SaveFileDialog
                {
                    Filter = @"svc files (*.svc)|*.svc|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    FileName = _saveFileName
                };
                // Force to save in .svc format
                // Restore last directory

                // Save file
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    svcPath = Path.GetDirectoryName(saveFile.FileName);
                    // Stop scrible
                    _wacomManager.StopScribble();
                    // Prepare stream
                    using var myStream = saveFile.OpenFile();
                    // Create stream writer and ensure that this stream writer is used
                    using var sw = new StreamWriter(myStream);
                    // Store data to file
                    if (StoreData(sw))
                    {
                        _logger.Info(
                            $"Data has been saved to file: {saveFile.FileName} with size of: {_wacomManager.SessionData.Count}");
                    }

                    // Allow scribble after file is saved and panel is cleared
                    _wacomManager.StartScribble();
                }
                else
                {
                    // Continue in scribble
                    _wacomManager.ContinueScribble();
                    _logger.Info(
                        $"Data has not been saved. Continue in scribble: data size = {_wacomManager.SessionData.Count}");
                }
            }
            else // No Data to save
            {
                _logger.Error($"No data to save : data size = {_wacomManager.SessionData.Count}");
                MessageBox.Show(
                    @"No data to save!",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _wacomManager.ContinueScribble();
            }
        }

        private void autoSaveButton_Click(object sender, EventArgs e)
        {
            _logger.Debug("Attempt to auto_save.");

            // This cause that no other data will be captured
            // Also cursor control by pen stay disabled
            _wacomManager.PauseScribble();

            // Check if there are any capture data
            if (_wacomManager.SessionData.Any())
            {
                // Update FileName
                _saveFileName = GetFileName();

                // Prepare path
                var path = Path.Combine(
                    _saveFolderPath, _saveFileName);
                if (File.Exists(path))
                {
                    var dialogResult = MessageBox.Show(
                        @"File already exist. Do you want to rewrite file?",
                        @"Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.No)
                    {
                        // Continue in scribble
                        _wacomManager.ContinueScribble();
                        return;
                    }
                }

                // Create stream writer and ensure that this stream writer is used
                using var sw = new StreamWriter(path);
                // Store data to file
                if (StoreData(sw))
                {
                    _logger.Info(
                        $"Data has been saved to file(autosave): {path} with size of: {_wacomManager.SessionData.Count}");
                    // Close file stream                        
                }

                // Allow scribble after file is saved and panel is cleared                
                _wacomManager.StartScribble();
            }
            else // No Data to save
            {
                _logger.Error($"No data to save (autosave): data size = {_wacomManager.SessionData.Count}");
                MessageBox.Show(
                    @"No data to save!",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _wacomManager.ContinueScribble();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(
                @"Do you want to exit HandAQUS?",
                @"Important Note",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                _logger.Info("Exit HandAQUS");
                this.Close();
                Application.Exit();
            }
        }

        // Set debug On/Off
        private void debugButton_Click(object sender, EventArgs e)
        {   
            if (_wacomManager.GetDebug())
            {
                // deactivate debug mode
                _wacomManager.SetDebug(false);
                stateLabel.Text = _stateBeforeDebug;
                _logger.Info("Debug mode deactivated");
            }
            else
            {
                // activate debug mode
                _wacomManager.SetDebug(true);
                _stateBeforeDebug = stateLabel.Text;
                stateLabel.Text = @"Debug mode activated.";
                _logger.Info("Debug mode activated");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Ask first for sure.
            var dialogResult = MessageBox.Show(
                @"Do you want to clear panel?",
                @"Important Note",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            // If yes clear panel and remove data
            if (dialogResult == DialogResult.Yes)
            {
                // Stop data capturing
                _wacomManager.StopScribble();

                // If read only mode is activated do not allow to start Scribble
                if (!ReadOnlyMode)
                {
                    // After Load button, this options are disabled so enable it
                    saveButton.Enabled = true;
                    if (_saveFolderName != null)
                    {
                        autoSaveButton.Enabled = true;
                    }

                    // Start data capturing
                    _wacomManager.StartScribble();
                }
            }
        }

        private void switchModeButton_Click(object sender, EventArgs e)
        {
            // Ask for mode change to Acquisition
            var dialogResult = MessageBox.Show(
                @"Activate acquisition mode?
",
                @"Important Note",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                try
                {
                    // If yes look if Wintab is available
                    if (TestWintabAvailible())
                    {
                        _logger.Info("Wintab is available. Switching to Full Mode");
                        // If yes, open Acquisition mode
                        ReadOnlyMode = false;
                        DefaultEnviroment();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "switchModeButton_Click");
                    throw new Exception($"Can't access Wintab driver: {ex}");
                }
        }

        private static void ShowSavedFile(string filename)
        {
            AutoClosingMessageBox.Show(string.Format($"File {filename} was saved successfully"), "Info", 2000);
        }

        private void DefaultEnviroment()
        {
            // Set default environment for data Acquisition mode
            saveButton.Visible = true;
            saveButton.Enabled = true;
            autoSaveButton.Visible = true;
            autoSaveButton.Enabled = false;
            addFolderButton.Visible = true;
            switchModeButton.Visible = false;
            switchModeButton.Enabled = false;
            debugButton.Visible = true;
            objectInfo.Visible = true;
            stateLabel.Text = @"Folder for autosave was not selected";
            stateLabel.ForeColor = Color.Black;

            StartFullMode();
        }

        private bool StoreData(StreamWriter sw)
        {
            try
            {
                // read values from sessionData packet by packet!!
                // REMOVE FIRST AND LAST IN AIR DATA
                _wacomManager.RemoveFirstInAirData();
                _wacomManager.RemoveLastInAirData();

                // First line is number of samples (one number)
                sw.Write($"{_wacomManager.SessionData.Count}\n");

                int wacom_tzero = -1;

                // Write packets into file line by line in following order:
                // X   Y   TimeStamp   ButtonStatus    Azimuth     Altitude    Pressure         
                foreach (var packet in _wacomManager.SessionData)
                {
                    // Revert y-axis before storage.
                    // Y-axis has been reverted while reading packet due to proper visualization on windows screen
                    var y_value = _wacomManager.GetMaxTabletY() - packet.pkY;

                    if (wacom_tzero == -1)
                    {
                        wacom_tzero = (int)packet.pkTime;
                    }
                    // save timstamp as milliseconds passed since 00:00
                    int time = (int)packet.pkTime + (int)_wacomManager.StartTime.TotalMilliseconds - wacom_tzero;

                    sw.Write(
                        $"{packet.pkX} {y_value} {time} {packet.pkButtons} {packet.pkOrientation.orAzimuth} {packet.pkOrientation.orAltitude} {packet.pkNormalPressure}\n",
                        Text);
                }

                // Close stream writer
                sw.Flush();
                sw.Close();
                // Show info box with saved file for 2 second
                ShowSavedFile(_saveFileName);

                // If folder for autosave is mapped, update file name
                if (_saveFolderName != null)
                {
                    // Increment file Counter
                    _saveFileCounter++;
                    // Set File name
                    _saveFileName = GetFileName();
                    // Show file name on status label
                    stateLabel.Text = _saveFileName;
                }
                saveFileWithPatientInfo();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "StoreData");
                MessageBox.Show(
                    $@"Not possible to write a stream! Original exception: {ex.Message}",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
        }

        // Test if Wintab driver is available. If Yes look if device is connected and if also yes open Acquisition mode.
        // If Wintab is not available or device is not connected ask for read-only mode
        public bool TestWintabAvailible()
        {
            _logger.Debug("Test WintabAvailible: ");
            // Check if driver or device is connected
            if (!WacomManager.IsWintabAvailable() || WacomManager.GetNumberOfDevices() == 0)
            {
                _logger.Debug("WinTab is not availiable!");
                // If no, Ask for read-only mode
                var dialogResult = MessageBox.Show(
                    @"Wacom Tablet is not connected!
 Do you want to continue in ""read only"" mode?.
",
                    @"Info",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    // Activate read-only mode
                    ReadOnlyMode = true;
                }
                if (dialogResult == DialogResult.No)
                {
                    _logger.Info("Exit HandAQUS");
                    Application.Exit();
                }

                return false;
            }

            // If driver is available, check for device
            if (WacomManager.GetNumberOfDevices() != 0)
            {
                _logger.Debug("Device is connected: {0}.", WacomManager.GetDeviceInfo());
                // If device is connected, return true and set Axis maximal value to set Gird
                _wacomManager.SetAxisAndPressureMax();
                return true;
            }

            _logger.Debug("Device is NOT connected: {0}.", WacomManager.GetDeviceInfo());
            MessageBox.Show(
                @"Wintab was not found!
                Check if tablet driver service is running.
                ",
                @"ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }
        
        private void objectInfo_Click(object sender, EventArgs e)
        {
            var objectInfoForm = new object_info();
            objectInfoForm.ShowDialog();

            _logger.Info($"Setting the Subject Info: Gender: {ObjectGender}; Date of Birth: {ObjectDateOfBirth.ToShortDateString()}");
            _objectGender = ObjectGender;
            _objectDateOfBirth = ObjectDateOfBirth;

            stateLabel.Text = $@"Subject Gender: {_objectGender}; Subject Date of Birth: {_objectDateOfBirth.ToShortDateString()}";
        }
        
        private void lines_button_add_Click(object sender, EventArgs e)
        {
            // Make lines remove button visible
            lines_button_remove.Visible = true;
            // Make lines add button invisible
            lines_button_add.Visible = false;

            // Set the background image by adding lines
            
            // scribblePanel.BackgroundImage = Resources.lines1;
            scribblePanel.BackgroundImage = imageBackgroundTest;

            // Re-draw task
            _wacomManager.ReDrawTask();

        }

        private void lines_button_remove_Click(object sender, EventArgs e)
        {

            // Make lines add button visible
            lines_button_add.Visible = true;
            // Make lines remove button invisible
            lines_button_remove.Visible = false;

            // Remove background image
            scribblePanel.BackgroundImage = null;

            // Re-draw task
            _wacomManager.ReDrawTask();
        }

        
        private void btnTobbiGlasses_Click(object sender, EventArgs e)
        {
            //TFG
            //opens Tobii Pro Glasses 3 Forms 
            //in case button is clicked and glasses 3 window form is minimized, to maximize it
            if (this.tobiiPROGlasses.WindowState == FormWindowState.Minimized)
            {
                this.tobiiPROGlasses.WindowState = FormWindowState.Maximized;
            }
            this.tobiiPROGlasses.Show();
            this.tobiiPROGlasses.TopMost = true;
        }

        
        private void btnChangeBackgroundImage_Click(object sender, EventArgs e)
        {
            //TFG
            //Method used to change the background Image.
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Open stream for file processing
                string text = openFileDialog.FileName;
                this.pathBackgroundTestImage = text;
                this.imageBackgroundTest = Image.FromFile(text);
                
                scribblePanel.BackgroundImage = imageBackgroundTest;
                // Re-draw task
                _wacomManager.ReDrawTask();

                // Make lines remove button visible
                lines_button_remove.Visible = true;
                // Make lines add button invisible
                lines_button_add.Visible = false;
            }
        }

        
        private void saveFileWithPatientInfo()
        {
            //TFG
            //Create a text file with Patient info
            saveFileWithPatientInfoInJSON();
            string file = @Path.Combine(this.svcPath, "filePatient.txt");
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                // Create a new file     
                using (StreamWriter sw = File.CreateText(file))
                {
                    //Check if there is patient info
                    if (_objectDateOfBirth == DateTime.MinValue || _objectGender == null)
                    {
                        sw.WriteLine("New file created: {0}", $"{DateTime.Now:dd-MM-yyyy}");
                        sw.WriteLine("Administrator: {0} ", _administrator);
                    }
                    else
                    {
                        sw.WriteLine("New file created: {0}", $"{DateTime.Now:dd-MM-yyyy}");
                        sw.WriteLine("Administrator: {0} ", _administrator);
                        sw.WriteLine("Patient Gender: {0}", _objectGender[0]);
                        sw.WriteLine("Patient date of Birth: {0} ", $"{_objectDateOfBirth:dd-MM-yyyy}");
                        if (pathBackgroundTestImage != null) sw.WriteLine("Background Image used: {0} ", pathBackgroundTestImage + "");
                        if (txtBox_aditional_Info != null) sw.WriteLine("Aditional Info: {0}", txtBox_aditional_Info);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("error in savetxt"+Ex.ToString());
            }
        }

        private void saveFileWithPatientInfoInJSON()
        {
            //TFG
            //Method to save file from patient in JSON object.
            this.JsonPatientInfo.NewFileCreated = $"{DateTime.Now:dd-MM-yyyy}";
            this.JsonPatientInfo.Administrator = _administrator;
            if (_objectDateOfBirth == DateTime.MinValue || _objectGender == null)
            {
                this.JsonPatientInfo.PatientGender = "Not Provided";
                this.JsonPatientInfo.PatientDateOfBirth = "Not Provided";
            }
            else
            {
                this.JsonPatientInfo.PatientGender = _objectGender;
                this.JsonPatientInfo.PatientDateOfBirth = $"{_objectDateOfBirth:dd-MM-yyyy}";
            }
            if (pathBackgroundTestImage != null) JsonPatientInfo.BackgroundImageUsed = pathBackgroundTestImage;
            else JsonPatientInfo.BackgroundImageUsed = "Default HandWriting Test Image";
            if (txtBox_aditional_Info != null) this.JsonPatientInfo.AditionalInfo = txtBox_aditional_Info;
            else JsonPatientInfo.AditionalInfo = "Not Provided";
            if (PatientHandeness != null) JsonPatientInfo.PatientHandeness = PatientHandeness;
            else JsonPatientInfo.PatientHandeness = "Not Provided";
            if (PatientUseOfGlasses != null) this.JsonPatientInfo.PatientUseOfGlasses = PatientUseOfGlasses;
            else JsonPatientInfo.PatientUseOfGlasses = "Not Provided";
            var json_fname = String.Format("{0}/{1}.json", this.svcPath, "filePatient");
            using (StreamWriter file = File.CreateText(json_fname))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                this.JsonPatientInfo.WriteTo(writer);
            }
        }

        public void saveSVCFileFromGlassesSave(string path)
        {
            //TFG
            //Method called from Tobii Glasses 3 Forms, to save writing data when gaze data is saved.
            saveSVCFile();
        }
    }
}