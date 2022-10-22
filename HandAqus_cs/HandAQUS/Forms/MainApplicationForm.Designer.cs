namespace HandAQUS
{
    partial class HandAQUS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ToolStripMenuItem exitButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HandAQUS));
            this.scribblePanel = new System.Windows.Forms.Panel();
            this.lines_button_remove = new System.Windows.Forms.Button();
            this.lines_button_add = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnChangeBackgroundImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTobbiGlasses = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderButton = new System.Windows.Forms.ToolStripMenuItem();
            this.objectInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSaveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.loadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.clearButton = new System.Windows.Forms.ToolStripMenuItem();
            this.switchModeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.debugButton = new System.Windows.Forms.ToolStripMenuItem();
            this.stateLabel = new System.Windows.Forms.Label();
            exitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.scribblePanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            exitButton.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            exitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(91, 96);
            exitButton.Text = "Exit";
            exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // scribblePanel
            // 
            this.scribblePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scribblePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.scribblePanel.BackColor = System.Drawing.Color.OldLace;
            this.scribblePanel.Controls.Add(this.lines_button_remove);
            this.scribblePanel.Controls.Add(this.lines_button_add);
            this.scribblePanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.scribblePanel.Location = new System.Drawing.Point(0, 0);
            this.scribblePanel.Margin = new System.Windows.Forms.Padding(5);
            this.scribblePanel.Name = "scribblePanel";
            this.scribblePanel.Padding = new System.Windows.Forms.Padding(5);
            this.scribblePanel.Size = new System.Drawing.Size(1920, 769);
            this.scribblePanel.TabIndex = 0;
            // 
            // lines_button_remove
            // 
            this.lines_button_remove.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.lines_button_remove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lines_button_remove.Image = ((System.Drawing.Image)(resources.GetObject("lines_button_remove.Image")));
            this.lines_button_remove.Location = new System.Drawing.Point(120, 987);
            this.lines_button_remove.Name = "lines_button_remove";
            this.lines_button_remove.Size = new System.Drawing.Size(49, 42);
            this.lines_button_remove.TabIndex = 1;
            this.lines_button_remove.Visible = false;
            this.lines_button_remove.Click += new System.EventHandler(this.lines_button_remove_Click);
            // 
            // lines_button_add
            // 
            this.lines_button_add.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.lines_button_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lines_button_add.Image = ((System.Drawing.Image)(resources.GetObject("lines_button_add.Image")));
            this.lines_button_add.Location = new System.Drawing.Point(120, 987);
            this.lines_button_add.Name = "lines_button_add";
            this.lines_button_add.Size = new System.Drawing.Size(49, 42);
            this.lines_button_add.TabIndex = 0;
            this.lines_button_add.Click += new System.EventHandler(this.lines_button_add_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(215)))), ((int)(((byte)(204)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(5);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChangeBackgroundImage,
            this.btnTobbiGlasses,
            this.addFolderButton,
            this.objectInfo,
            this.autoSaveButton,
            this.saveButton,
            this.loadButton,
            this.clearButton,
            this.switchModeButton,
            exitButton,
            this.debugButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(5);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(98, 690);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnChangeBackgroundImage
            // 
            this.btnChangeBackgroundImage.Font = new System.Drawing.Font("Sitka Text", 8F, System.Drawing.FontStyle.Bold);
            this.btnChangeBackgroundImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnChangeBackgroundImage.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeBackgroundImage.Image")));
            this.btnChangeBackgroundImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnChangeBackgroundImage.Name = "btnChangeBackgroundImage";
            this.btnChangeBackgroundImage.Size = new System.Drawing.Size(91, 84);
            this.btnChangeBackgroundImage.Text = "Change Image";
            this.btnChangeBackgroundImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnChangeBackgroundImage.Click += new System.EventHandler(this.btnChangeBackgroundImage_Click);
            // 
            // btnTobbiGlasses
            // 
            this.btnTobbiGlasses.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnTobbiGlasses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnTobbiGlasses.Image = ((System.Drawing.Image)(resources.GetObject("btnTobbiGlasses.Image")));
            this.btnTobbiGlasses.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTobbiGlasses.Name = "btnTobbiGlasses";
            this.btnTobbiGlasses.Size = new System.Drawing.Size(91, 96);
            this.btnTobbiGlasses.Text = "Glasses";
            this.btnTobbiGlasses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTobbiGlasses.Click += new System.EventHandler(this.btnTobbiGlasses_Click);
            // 
            // addFolderButton
            // 
            this.addFolderButton.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.addFolderButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.addFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("addFolderButton.Image")));
            this.addFolderButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addFolderButton.Name = "addFolderButton";
            this.addFolderButton.Size = new System.Drawing.Size(91, 96);
            this.addFolderButton.Text = "Folder";
            this.addFolderButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addFolderButton.Click += new System.EventHandler(this.addFolderButton_Click);
            // 
            // objectInfo
            // 
            this.objectInfo.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.objectInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.objectInfo.Image = ((System.Drawing.Image)(resources.GetObject("objectInfo.Image")));
            this.objectInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.objectInfo.Name = "objectInfo";
            this.objectInfo.Size = new System.Drawing.Size(91, 96);
            this.objectInfo.Text = "Info";
            this.objectInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.objectInfo.Click += new System.EventHandler(this.objectInfo_Click);
            // 
            // autoSaveButton
            // 
            this.autoSaveButton.Enabled = false;
            this.autoSaveButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.autoSaveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.autoSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("autoSaveButton.Image")));
            this.autoSaveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.autoSaveButton.Name = "autoSaveButton";
            this.autoSaveButton.Size = new System.Drawing.Size(91, 91);
            this.autoSaveButton.Text = "AutoSave";
            this.autoSaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.autoSaveButton.Click += new System.EventHandler(this.autoSaveButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(91, 96);
            this.saveButton.Text = "Save As..";
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.loadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.loadButton.Image = ((System.Drawing.Image)(resources.GetObject("loadButton.Image")));
            this.loadButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(91, 96);
            this.loadButton.Text = "Load";
            this.loadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.clearButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
            this.clearButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(91, 96);
            this.clearButton.Text = "Clear";
            this.clearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // switchModeButton
            // 
            this.switchModeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.switchModeButton.Enabled = false;
            this.switchModeButton.Font = new System.Drawing.Font("Sitka Text", 10F);
            this.switchModeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.switchModeButton.Image = ((System.Drawing.Image)(resources.GetObject("switchModeButton.Image")));
            this.switchModeButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.switchModeButton.Name = "switchModeButton";
            this.switchModeButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.switchModeButton.Size = new System.Drawing.Size(91, 88);
            this.switchModeButton.Text = "Switch mode";
            this.switchModeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.switchModeButton.Visible = false;
            this.switchModeButton.Click += new System.EventHandler(this.switchModeButton_Click);
            // 
            // debugButton
            // 
            this.debugButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.debugButton.AutoToolTip = true;
            this.debugButton.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.debugButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.debugButton.Image = ((System.Drawing.Image)(resources.GetObject("debugButton.Image")));
            this.debugButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.debugButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 100);
            this.debugButton.Name = "debugButton";
            this.debugButton.Padding = new System.Windows.Forms.Padding(0);
            this.debugButton.Size = new System.Drawing.Size(91, 96);
            this.debugButton.Text = "Debug";
            this.debugButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.stateLabel.Location = new System.Drawing.Point(106, 4);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(294, 23);
            this.stateLabel.TabIndex = 2;
            this.stateLabel.Text = "Folder for autosave was not selcted";
            // 
            // HandAQUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(215)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1904, 690);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.scribblePanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HandAQUS";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HandAQUS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.scribblePanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel scribblePanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveButton;
        private System.Windows.Forms.ToolStripMenuItem objectInfo;
        private System.Windows.Forms.ToolStripMenuItem clearButton;
        private System.Windows.Forms.ToolStripMenuItem addFolderButton;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.ToolStripMenuItem autoSaveButton;
        private System.Windows.Forms.ToolStripMenuItem switchModeButton;
        private System.Windows.Forms.ToolStripMenuItem debugButton;
        private System.Windows.Forms.ToolStripMenuItem loadButton;
        private System.Windows.Forms.Button lines_button_add;
        private System.Windows.Forms.Button lines_button_remove;
        private System.Windows.Forms.ToolStripMenuItem btnTobbiGlasses;
        private System.Windows.Forms.ToolStripMenuItem btnChangeBackgroundImage;
    }
}

