namespace AlignData2._0
{
    partial class AlignData
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlignData));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDataTables = new System.Windows.Forms.TabPage();
            this.btnSaveALL = new System.Windows.Forms.Button();
            this.btnSelectTask = new System.Windows.Forms.Button();
            this.comboBoxTasks = new System.Windows.Forms.ComboBox();
            this.handWriteDataGridView = new System.Windows.Forms.DataGridView();
            this.gazeDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GazeData = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HandData = new System.Windows.Forms.Label();
            this.tabVideo = new System.Windows.Forms.TabPage();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.tabPatientInfo = new System.Windows.Forms.TabPage();
            this.txtTaskTimeStamp = new System.Windows.Forms.TextBox();
            this.lblTaskTimeStamp = new System.Windows.Forms.Label();
            this.txtBoxTotalTimeTest = new System.Windows.Forms.TextBox();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.txtUsesGlasses = new System.Windows.Forms.TextBox();
            this.labelUsesGlasses = new System.Windows.Forms.Label();
            this.txtPatientHanded = new System.Windows.Forms.TextBox();
            this.labelHanded = new System.Windows.Forms.Label();
            this.txtBackgroundImageUsed = new System.Windows.Forms.TextBox();
            this.txtPatientGender = new System.Windows.Forms.TextBox();
            this.txtPatientDateOfBirth = new System.Windows.Forms.TextBox();
            this.txtFileCreatedDate = new System.Windows.Forms.TextBox();
            this.txtAdmin = new System.Windows.Forms.TextBox();
            this.txtAditionalInfo = new System.Windows.Forms.TextBox();
            this.lblAditionalInfo = new System.Windows.Forms.Label();
            this.lblBackgroundImageUsed = new System.Windows.Forms.Label();
            this.lblPatientDateOfBirth = new System.Windows.Forms.Label();
            this.lblPatientGender = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.lblFileCreatedDate = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDataTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.handWriteDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gazeDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.tabPatientInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1837, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.archivoToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alignDataToolStripMenuItem});
            this.herramientasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.herramientasToolStripMenuItem.Text = "Tools";
            // 
            // alignDataToolStripMenuItem
            // 
            this.alignDataToolStripMenuItem.Name = "alignDataToolStripMenuItem";
            this.alignDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.alignDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.alignDataToolStripMenuItem.Text = "Align Data";
            this.alignDataToolStripMenuItem.Click += new System.EventHandler(this.alignDataToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDataTables);
            this.tabControl1.Controls.Add(this.tabVideo);
            this.tabControl1.Controls.Add(this.tabPatientInfo);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.ItemSize = new System.Drawing.Size(71, 40);
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1837, 922);
            this.tabControl1.TabIndex = 5;
            // 
            // tabDataTables
            // 
            this.tabDataTables.BackColor = System.Drawing.Color.PapayaWhip;
            this.tabDataTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDataTables.Controls.Add(this.btnSaveALL);
            this.tabDataTables.Controls.Add(this.btnSelectTask);
            this.tabDataTables.Controls.Add(this.comboBoxTasks);
            this.tabDataTables.Controls.Add(this.handWriteDataGridView);
            this.tabDataTables.Controls.Add(this.gazeDataGridView);
            this.tabDataTables.Controls.Add(this.panel1);
            this.tabDataTables.Controls.Add(this.panel2);
            this.tabDataTables.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabDataTables.Location = new System.Drawing.Point(4, 44);
            this.tabDataTables.Name = "tabDataTables";
            this.tabDataTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataTables.Size = new System.Drawing.Size(1829, 874);
            this.tabDataTables.TabIndex = 0;
            this.tabDataTables.Text = "Data Tables";
            // 
            // btnSaveALL
            // 
            this.btnSaveALL.BackColor = System.Drawing.Color.LightCyan;
            this.btnSaveALL.Location = new System.Drawing.Point(862, 15);
            this.btnSaveALL.Name = "btnSaveALL";
            this.btnSaveALL.Size = new System.Drawing.Size(186, 33);
            this.btnSaveALL.TabIndex = 10;
            this.btnSaveALL.Text = "SAVE ALL TASKS";
            this.btnSaveALL.UseVisualStyleBackColor = false;
            this.btnSaveALL.Click += new System.EventHandler(this.btnSaveALL_Click);
            // 
            // btnSelectTask
            // 
            this.btnSelectTask.Location = new System.Drawing.Point(556, 15);
            this.btnSelectTask.Name = "btnSelectTask";
            this.btnSelectTask.Size = new System.Drawing.Size(172, 33);
            this.btnSelectTask.TabIndex = 9;
            this.btnSelectTask.Text = "SELECT TASK";
            this.btnSelectTask.UseVisualStyleBackColor = true;
            this.btnSelectTask.Click += new System.EventHandler(this.btnSelectTask_Click);
            // 
            // comboBoxTasks
            // 
            this.comboBoxTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTasks.FormattingEnabled = true;
            this.comboBoxTasks.Location = new System.Drawing.Point(429, 15);
            this.comboBoxTasks.Name = "comboBoxTasks";
            this.comboBoxTasks.Size = new System.Drawing.Size(121, 33);
            this.comboBoxTasks.TabIndex = 8;
            // 
            // handWriteDataGridView
            // 
            this.handWriteDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.handWriteDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.handWriteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.handWriteDataGridView.Location = new System.Drawing.Point(5, 118);
            this.handWriteDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.handWriteDataGridView.Name = "handWriteDataGridView";
            this.handWriteDataGridView.RowHeadersWidth = 51;
            this.handWriteDataGridView.RowTemplate.Height = 29;
            this.handWriteDataGridView.Size = new System.Drawing.Size(545, 749);
            this.handWriteDataGridView.TabIndex = 1;
            // 
            // gazeDataGridView
            // 
            this.gazeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gazeDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gazeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gazeDataGridView.Location = new System.Drawing.Point(556, 118);
            this.gazeDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gazeDataGridView.Name = "gazeDataGridView";
            this.gazeDataGridView.RowHeadersWidth = 51;
            this.gazeDataGridView.RowTemplate.Height = 29;
            this.gazeDataGridView.Size = new System.Drawing.Size(1265, 749);
            this.gazeDataGridView.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.GazeData);
            this.panel1.Location = new System.Drawing.Point(556, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1265, 45);
            this.panel1.TabIndex = 6;
            // 
            // GazeData
            // 
            this.GazeData.AutoSize = true;
            this.GazeData.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.GazeData.Location = new System.Drawing.Point(604, 4);
            this.GazeData.Name = "GazeData";
            this.GazeData.Size = new System.Drawing.Size(146, 37);
            this.GazeData.TabIndex = 4;
            this.GazeData.Text = "Gaze Data ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.HandData);
            this.panel2.Location = new System.Drawing.Point(6, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 45);
            this.panel2.TabIndex = 7;
            // 
            // HandData
            // 
            this.HandData.AutoSize = true;
            this.HandData.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.HandData.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.HandData.Location = new System.Drawing.Point(134, 4);
            this.HandData.Name = "HandData";
            this.HandData.Size = new System.Drawing.Size(232, 37);
            this.HandData.TabIndex = 5;
            this.HandData.Text = "HandWriting Data";
            // 
            // tabVideo
            // 
            this.tabVideo.BackColor = System.Drawing.Color.PapayaWhip;
            this.tabVideo.Controls.Add(this.axWindowsMediaPlayer1);
            this.tabVideo.Location = new System.Drawing.Point(4, 44);
            this.tabVideo.Name = "tabVideo";
            this.tabVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideo.Size = new System.Drawing.Size(1829, 874);
            this.tabVideo.TabIndex = 1;
            this.tabVideo.Text = "Vídeo";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(6, 6);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1815, 862);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // tabPatientInfo
            // 
            this.tabPatientInfo.BackColor = System.Drawing.Color.PapayaWhip;
            this.tabPatientInfo.Controls.Add(this.txtTaskTimeStamp);
            this.tabPatientInfo.Controls.Add(this.lblTaskTimeStamp);
            this.tabPatientInfo.Controls.Add(this.txtBoxTotalTimeTest);
            this.tabPatientInfo.Controls.Add(this.labelTotalTime);
            this.tabPatientInfo.Controls.Add(this.txtUsesGlasses);
            this.tabPatientInfo.Controls.Add(this.labelUsesGlasses);
            this.tabPatientInfo.Controls.Add(this.txtPatientHanded);
            this.tabPatientInfo.Controls.Add(this.labelHanded);
            this.tabPatientInfo.Controls.Add(this.txtBackgroundImageUsed);
            this.tabPatientInfo.Controls.Add(this.txtPatientGender);
            this.tabPatientInfo.Controls.Add(this.txtPatientDateOfBirth);
            this.tabPatientInfo.Controls.Add(this.txtFileCreatedDate);
            this.tabPatientInfo.Controls.Add(this.txtAdmin);
            this.tabPatientInfo.Controls.Add(this.txtAditionalInfo);
            this.tabPatientInfo.Controls.Add(this.lblAditionalInfo);
            this.tabPatientInfo.Controls.Add(this.lblBackgroundImageUsed);
            this.tabPatientInfo.Controls.Add(this.lblPatientDateOfBirth);
            this.tabPatientInfo.Controls.Add(this.lblPatientGender);
            this.tabPatientInfo.Controls.Add(this.lblAdmin);
            this.tabPatientInfo.Controls.Add(this.lblFileCreatedDate);
            this.tabPatientInfo.Location = new System.Drawing.Point(4, 44);
            this.tabPatientInfo.Name = "tabPatientInfo";
            this.tabPatientInfo.Size = new System.Drawing.Size(1829, 874);
            this.tabPatientInfo.TabIndex = 2;
            this.tabPatientInfo.Text = "Patient Info";
            // 
            // txtTaskTimeStamp
            // 
            this.txtTaskTimeStamp.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtTaskTimeStamp.Location = new System.Drawing.Point(829, 540);
            this.txtTaskTimeStamp.Multiline = true;
            this.txtTaskTimeStamp.Name = "txtTaskTimeStamp";
            this.txtTaskTimeStamp.ReadOnly = true;
            this.txtTaskTimeStamp.Size = new System.Drawing.Size(456, 329);
            this.txtTaskTimeStamp.TabIndex = 19;
            // 
            // lblTaskTimeStamp
            // 
            this.lblTaskTimeStamp.AutoSize = true;
            this.lblTaskTimeStamp.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblTaskTimeStamp.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTaskTimeStamp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTaskTimeStamp.Location = new System.Drawing.Point(824, 509);
            this.lblTaskTimeStamp.Name = "lblTaskTimeStamp";
            this.lblTaskTimeStamp.Size = new System.Drawing.Size(169, 28);
            this.lblTaskTimeStamp.TabIndex = 18;
            this.lblTaskTimeStamp.Text = "TaskTimeStamps";
            // 
            // txtBoxTotalTimeTest
            // 
            this.txtBoxTotalTimeTest.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtBoxTotalTimeTest.Location = new System.Drawing.Point(829, 408);
            this.txtBoxTotalTimeTest.Multiline = true;
            this.txtBoxTotalTimeTest.Name = "txtBoxTotalTimeTest";
            this.txtBoxTotalTimeTest.ReadOnly = true;
            this.txtBoxTotalTimeTest.Size = new System.Drawing.Size(456, 46);
            this.txtBoxTotalTimeTest.TabIndex = 17;
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.AutoSize = true;
            this.labelTotalTime.BackColor = System.Drawing.Color.PapayaWhip;
            this.labelTotalTime.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.labelTotalTime.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelTotalTime.Location = new System.Drawing.Point(824, 377);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(398, 28);
            this.labelTotalTime.TabIndex = 16;
            this.labelTotalTime.Text = "h:min:sec:milisec - Total Time of the Test";
            // 
            // txtUsesGlasses
            // 
            this.txtUsesGlasses.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtUsesGlasses.Location = new System.Drawing.Point(41, 408);
            this.txtUsesGlasses.Multiline = true;
            this.txtUsesGlasses.Name = "txtUsesGlasses";
            this.txtUsesGlasses.ReadOnly = true;
            this.txtUsesGlasses.Size = new System.Drawing.Size(456, 46);
            this.txtUsesGlasses.TabIndex = 15;
            // 
            // labelUsesGlasses
            // 
            this.labelUsesGlasses.AutoSize = true;
            this.labelUsesGlasses.BackColor = System.Drawing.Color.PapayaWhip;
            this.labelUsesGlasses.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.labelUsesGlasses.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelUsesGlasses.Location = new System.Drawing.Point(36, 377);
            this.labelUsesGlasses.Name = "labelUsesGlasses";
            this.labelUsesGlasses.Size = new System.Drawing.Size(234, 28);
            this.labelUsesGlasses.TabIndex = 14;
            this.labelUsesGlasses.Text = "Did Patient Use Glasses";
            // 
            // txtPatientHanded
            // 
            this.txtPatientHanded.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtPatientHanded.Location = new System.Drawing.Point(41, 288);
            this.txtPatientHanded.Multiline = true;
            this.txtPatientHanded.Name = "txtPatientHanded";
            this.txtPatientHanded.ReadOnly = true;
            this.txtPatientHanded.Size = new System.Drawing.Size(456, 46);
            this.txtPatientHanded.TabIndex = 13;
            // 
            // labelHanded
            // 
            this.labelHanded.AutoSize = true;
            this.labelHanded.BackColor = System.Drawing.Color.PapayaWhip;
            this.labelHanded.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.labelHanded.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelHanded.Location = new System.Drawing.Point(36, 257);
            this.labelHanded.Name = "labelHanded";
            this.labelHanded.Size = new System.Drawing.Size(236, 28);
            this.labelHanded.TabIndex = 12;
            this.labelHanded.Text = "Patient Dominant Hand";
            // 
            // txtBackgroundImageUsed
            // 
            this.txtBackgroundImageUsed.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtBackgroundImageUsed.Location = new System.Drawing.Point(829, 59);
            this.txtBackgroundImageUsed.Multiline = true;
            this.txtBackgroundImageUsed.Name = "txtBackgroundImageUsed";
            this.txtBackgroundImageUsed.ReadOnly = true;
            this.txtBackgroundImageUsed.Size = new System.Drawing.Size(456, 46);
            this.txtBackgroundImageUsed.TabIndex = 11;
            // 
            // txtPatientGender
            // 
            this.txtPatientGender.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtPatientGender.Location = new System.Drawing.Point(41, 59);
            this.txtPatientGender.Multiline = true;
            this.txtPatientGender.Name = "txtPatientGender";
            this.txtPatientGender.ReadOnly = true;
            this.txtPatientGender.Size = new System.Drawing.Size(456, 46);
            this.txtPatientGender.TabIndex = 10;
            // 
            // txtPatientDateOfBirth
            // 
            this.txtPatientDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtPatientDateOfBirth.Location = new System.Drawing.Point(41, 175);
            this.txtPatientDateOfBirth.Multiline = true;
            this.txtPatientDateOfBirth.Name = "txtPatientDateOfBirth";
            this.txtPatientDateOfBirth.ReadOnly = true;
            this.txtPatientDateOfBirth.Size = new System.Drawing.Size(456, 46);
            this.txtPatientDateOfBirth.TabIndex = 9;
            // 
            // txtFileCreatedDate
            // 
            this.txtFileCreatedDate.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtFileCreatedDate.Location = new System.Drawing.Point(829, 175);
            this.txtFileCreatedDate.Multiline = true;
            this.txtFileCreatedDate.Name = "txtFileCreatedDate";
            this.txtFileCreatedDate.ReadOnly = true;
            this.txtFileCreatedDate.Size = new System.Drawing.Size(456, 46);
            this.txtFileCreatedDate.TabIndex = 8;
            // 
            // txtAdmin
            // 
            this.txtAdmin.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtAdmin.Location = new System.Drawing.Point(829, 288);
            this.txtAdmin.Multiline = true;
            this.txtAdmin.Name = "txtAdmin";
            this.txtAdmin.ReadOnly = true;
            this.txtAdmin.Size = new System.Drawing.Size(456, 46);
            this.txtAdmin.TabIndex = 7;
            // 
            // txtAditionalInfo
            // 
            this.txtAditionalInfo.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtAditionalInfo.Location = new System.Drawing.Point(41, 540);
            this.txtAditionalInfo.Multiline = true;
            this.txtAditionalInfo.Name = "txtAditionalInfo";
            this.txtAditionalInfo.ReadOnly = true;
            this.txtAditionalInfo.Size = new System.Drawing.Size(456, 329);
            this.txtAditionalInfo.TabIndex = 6;
            // 
            // lblAditionalInfo
            // 
            this.lblAditionalInfo.AutoSize = true;
            this.lblAditionalInfo.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblAditionalInfo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblAditionalInfo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAditionalInfo.Location = new System.Drawing.Point(36, 509);
            this.lblAditionalInfo.Name = "lblAditionalInfo";
            this.lblAditionalInfo.Size = new System.Drawing.Size(304, 28);
            this.lblAditionalInfo.TabIndex = 5;
            this.lblAditionalInfo.Text = "Additional Patient Information";
            // 
            // lblBackgroundImageUsed
            // 
            this.lblBackgroundImageUsed.AutoSize = true;
            this.lblBackgroundImageUsed.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblBackgroundImageUsed.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblBackgroundImageUsed.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblBackgroundImageUsed.Location = new System.Drawing.Point(824, 28);
            this.lblBackgroundImageUsed.Name = "lblBackgroundImageUsed";
            this.lblBackgroundImageUsed.Size = new System.Drawing.Size(241, 28);
            this.lblBackgroundImageUsed.TabIndex = 4;
            this.lblBackgroundImageUsed.Text = "Background Image Used";
            // 
            // lblPatientDateOfBirth
            // 
            this.lblPatientDateOfBirth.AutoSize = true;
            this.lblPatientDateOfBirth.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblPatientDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblPatientDateOfBirth.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPatientDateOfBirth.Location = new System.Drawing.Point(36, 144);
            this.lblPatientDateOfBirth.Name = "lblPatientDateOfBirth";
            this.lblPatientDateOfBirth.Size = new System.Drawing.Size(214, 28);
            this.lblPatientDateOfBirth.TabIndex = 3;
            this.lblPatientDateOfBirth.Text = "Patient Date Of Birth";
            // 
            // lblPatientGender
            // 
            this.lblPatientGender.AutoSize = true;
            this.lblPatientGender.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblPatientGender.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblPatientGender.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPatientGender.Location = new System.Drawing.Point(36, 28);
            this.lblPatientGender.Name = "lblPatientGender";
            this.lblPatientGender.Size = new System.Drawing.Size(154, 28);
            this.lblPatientGender.TabIndex = 2;
            this.lblPatientGender.Text = "Patient Gender";
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblAdmin.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblAdmin.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAdmin.Location = new System.Drawing.Point(824, 257);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(144, 28);
            this.lblAdmin.TabIndex = 1;
            this.lblAdmin.Text = "Administrator";
            // 
            // lblFileCreatedDate
            // 
            this.lblFileCreatedDate.AutoSize = true;
            this.lblFileCreatedDate.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblFileCreatedDate.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblFileCreatedDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblFileCreatedDate.Location = new System.Drawing.Point(824, 144);
            this.lblFileCreatedDate.Name = "lblFileCreatedDate";
            this.lblFileCreatedDate.Size = new System.Drawing.Size(101, 28);
            this.lblFileCreatedDate.TabIndex = 0;
            this.lblFileCreatedDate.Text = "Date Test";
            // 
            // AlignData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1837, 956);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AlignData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlignData";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabDataTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.handWriteDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gazeDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.tabPatientInfo.ResumeLayout(false);
            this.tabPatientInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDataTables;
        private System.Windows.Forms.Label HandData;
        private System.Windows.Forms.DataGridView handWriteDataGridView;
        private System.Windows.Forms.Label GazeData;
        private System.Windows.Forms.DataGridView gazeDataGridView;
        private System.Windows.Forms.TabPage tabVideo;
        private System.Windows.Forms.ToolStripMenuItem alignDataToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPatientInfo;
        private System.Windows.Forms.TextBox txtBackgroundImageUsed;
        private System.Windows.Forms.TextBox txtPatientGender;
        private System.Windows.Forms.TextBox txtPatientDateOfBirth;
        private System.Windows.Forms.TextBox txtFileCreatedDate;
        private System.Windows.Forms.TextBox txtAdmin;
        private System.Windows.Forms.TextBox txtAditionalInfo;
        private System.Windows.Forms.Label lblAditionalInfo;
        private System.Windows.Forms.Label lblBackgroundImageUsed;
        private System.Windows.Forms.Label lblPatientDateOfBirth;
        private System.Windows.Forms.Label lblPatientGender;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Label lblFileCreatedDate;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TextBox txtUsesGlasses;
        private System.Windows.Forms.Label labelUsesGlasses;
        private System.Windows.Forms.TextBox txtPatientHanded;
        private System.Windows.Forms.Label labelHanded;
        private System.Windows.Forms.TextBox txtBoxTotalTimeTest;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.TextBox txtTaskTimeStamp;
        private System.Windows.Forms.Label lblTaskTimeStamp;
        private System.Windows.Forms.ComboBox comboBoxTasks;
        private System.Windows.Forms.Button btnSelectTask;
        private System.Windows.Forms.Button btnSaveALL;
    }
}
