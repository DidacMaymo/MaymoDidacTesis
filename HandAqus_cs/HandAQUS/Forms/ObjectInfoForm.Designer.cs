namespace HandAQUS
{
    partial class object_info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(object_info));
            this.date_birth_picture = new System.Windows.Forms.PictureBox();
            this.picture_gender = new System.Windows.Forms.PictureBox();
            this.main_label = new System.Windows.Forms.Label();
            this.gender_label = new System.Windows.Forms.Label();
            this.date_label = new System.Windows.Forms.Label();
            this.object_info_button = new System.Windows.Forms.Button();
            this.gender_box = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtBox_aditional_Info = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PatientUsesGlassesBox = new System.Windows.Forms.ComboBox();
            this.labelGlassesPatient = new System.Windows.Forms.Label();
            this.labelHandUsed = new System.Windows.Forms.Label();
            this.HandedNessOfPatientBox = new System.Windows.Forms.ComboBox();
            this.pictureBoxPatientGlasses = new System.Windows.Forms.PictureBox();
            this.HandedNess = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.date_birth_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_gender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPatientGlasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HandedNess)).BeginInit();
            this.SuspendLayout();
            // 
            // date_birth_picture
            // 
            this.date_birth_picture.Image = ((System.Drawing.Image)(resources.GetObject("date_birth_picture.Image")));
            this.date_birth_picture.Location = new System.Drawing.Point(350, 58);
            this.date_birth_picture.Name = "date_birth_picture";
            this.date_birth_picture.Size = new System.Drawing.Size(65, 71);
            this.date_birth_picture.TabIndex = 1;
            this.date_birth_picture.TabStop = false;
            // 
            // picture_gender
            // 
            this.picture_gender.Image = ((System.Drawing.Image)(resources.GetObject("picture_gender.Image")));
            this.picture_gender.Location = new System.Drawing.Point(27, 59);
            this.picture_gender.Name = "picture_gender";
            this.picture_gender.Size = new System.Drawing.Size(69, 70);
            this.picture_gender.TabIndex = 2;
            this.picture_gender.TabStop = false;
            // 
            // main_label
            // 
            this.main_label.AutoSize = true;
            this.main_label.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.main_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.main_label.Location = new System.Drawing.Point(167, 9);
            this.main_label.Name = "main_label";
            this.main_label.Size = new System.Drawing.Size(295, 30);
            this.main_label.TabIndex = 3;
            this.main_label.Text = "Add/Change the object info";
            // 
            // gender_label
            // 
            this.gender_label.AutoSize = true;
            this.gender_label.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gender_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.gender_label.Location = new System.Drawing.Point(97, 58);
            this.gender_label.Name = "gender_label";
            this.gender_label.Size = new System.Drawing.Size(151, 30);
            this.gender_label.TabIndex = 4;
            this.gender_label.Text = "Select gender";
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.date_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.date_label.Location = new System.Drawing.Point(421, 58);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(146, 30);
            this.date_label.TabIndex = 5;
            this.date_label.Text = "Date of birth";
            // 
            // object_info_button
            // 
            this.object_info_button.AutoSize = true;
            this.object_info_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.object_info_button.FlatAppearance.BorderSize = 2;
            this.object_info_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.object_info_button.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.object_info_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.object_info_button.Location = new System.Drawing.Point(264, 403);
            this.object_info_button.Name = "object_info_button";
            this.object_info_button.Size = new System.Drawing.Size(100, 42);
            this.object_info_button.TabIndex = 6;
            this.object_info_button.Text = "SAVE";
            this.object_info_button.UseVisualStyleBackColor = false;
            this.object_info_button.Click += new System.EventHandler(this.object_info_button_Click);
            // 
            // gender_box
            // 
            this.gender_box.AllowDrop = true;
            this.gender_box.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gender_box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.gender_box.FormattingEnabled = true;
            this.gender_box.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.gender_box.Location = new System.Drawing.Point(102, 93);
            this.gender_box.Name = "gender_box";
            this.gender_box.Size = new System.Drawing.Size(125, 36);
            this.gender_box.TabIndex = 7;
            this.gender_box.Text = "...";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dateTimePicker1.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dateTimePicker1.Location = new System.Drawing.Point(426, 98);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 31);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Value = new System.DateTime(2020, 10, 8, 17, 3, 3, 0);
            // 
            // txtBox_aditional_Info
            // 
            this.txtBox_aditional_Info.Location = new System.Drawing.Point(27, 315);
            this.txtBox_aditional_Info.Multiline = true;
            this.txtBox_aditional_Info.Name = "txtBox_aditional_Info";
            this.txtBox_aditional_Info.Size = new System.Drawing.Size(599, 74);
            this.txtBox_aditional_Info.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(191, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Additional Information";
            // 
            // PatientUsesGlassesBox
            // 
            this.PatientUsesGlassesBox.AllowDrop = true;
            this.PatientUsesGlassesBox.DropDownWidth = 125;
            this.PatientUsesGlassesBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.PatientUsesGlassesBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.PatientUsesGlassesBox.FormattingEnabled = true;
            this.PatientUsesGlassesBox.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.PatientUsesGlassesBox.Location = new System.Drawing.Point(102, 224);
            this.PatientUsesGlassesBox.Name = "PatientUsesGlassesBox";
            this.PatientUsesGlassesBox.Size = new System.Drawing.Size(121, 36);
            this.PatientUsesGlassesBox.TabIndex = 7;
            this.PatientUsesGlassesBox.Text = "...";
            // 
            // labelGlassesPatient
            // 
            this.labelGlassesPatient.AutoSize = true;
            this.labelGlassesPatient.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGlassesPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.labelGlassesPatient.Location = new System.Drawing.Point(97, 176);
            this.labelGlassesPatient.Name = "labelGlassesPatient";
            this.labelGlassesPatient.Size = new System.Drawing.Size(228, 30);
            this.labelGlassesPatient.TabIndex = 11;
            this.labelGlassesPatient.Text = "Patient Uses Glasses";
            // 
            // labelHandUsed
            // 
            this.labelHandUsed.AutoSize = true;
            this.labelHandUsed.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHandUsed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.labelHandUsed.Location = new System.Drawing.Point(421, 176);
            this.labelHandUsed.Name = "labelHandUsed";
            this.labelHandUsed.Size = new System.Drawing.Size(140, 30);
            this.labelHandUsed.TabIndex = 12;
            this.labelHandUsed.Text = "Handedness";
            // 
            // HandedNessOfPatientBox
            // 
            this.HandedNessOfPatientBox.AllowDrop = true;
            this.HandedNessOfPatientBox.DropDownWidth = 125;
            this.HandedNessOfPatientBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold);
            this.HandedNessOfPatientBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.HandedNessOfPatientBox.FormattingEnabled = true;
            this.HandedNessOfPatientBox.Items.AddRange(new object[] {
            "Right-handed",
            "Left-handed"});
            this.HandedNessOfPatientBox.Location = new System.Drawing.Point(421, 224);
            this.HandedNessOfPatientBox.Name = "HandedNessOfPatientBox";
            this.HandedNessOfPatientBox.Size = new System.Drawing.Size(205, 36);
            this.HandedNessOfPatientBox.TabIndex = 13;
            this.HandedNessOfPatientBox.Text = "...";
            // 
            // pictureBoxPatientGlasses
            // 
            this.pictureBoxPatientGlasses.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPatientGlasses.Image")));
            this.pictureBoxPatientGlasses.Location = new System.Drawing.Point(27, 190);
            this.pictureBoxPatientGlasses.Name = "pictureBoxPatientGlasses";
            this.pictureBoxPatientGlasses.Size = new System.Drawing.Size(69, 70);
            this.pictureBoxPatientGlasses.TabIndex = 14;
            this.pictureBoxPatientGlasses.TabStop = false;
            // 
            // HandedNess
            // 
            this.HandedNess.Image = ((System.Drawing.Image)(resources.GetObject("HandedNess.Image")));
            this.HandedNess.Location = new System.Drawing.Point(350, 189);
            this.HandedNess.Name = "HandedNess";
            this.HandedNess.Size = new System.Drawing.Size(65, 71);
            this.HandedNess.TabIndex = 15;
            this.HandedNess.TabStop = false;
            // 
            // object_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(652, 457);
            this.Controls.Add(this.HandedNess);
            this.Controls.Add(this.pictureBoxPatientGlasses);
            this.Controls.Add(this.HandedNessOfPatientBox);
            this.Controls.Add(this.labelHandUsed);
            this.Controls.Add(this.labelGlassesPatient);
            this.Controls.Add(this.PatientUsesGlassesBox);
            this.Controls.Add(this.date_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.main_label);
            this.Controls.Add(this.txtBox_aditional_Info);
            this.Controls.Add(this.picture_gender);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.date_birth_picture);
            this.Controls.Add(this.gender_label);
            this.Controls.Add(this.object_info_button);
            this.Controls.Add(this.gender_box);
            this.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "object_info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HandAQUS";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.object_info_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.date_birth_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_gender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPatientGlasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HandedNess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox date_birth_picture;
        private System.Windows.Forms.PictureBox picture_gender;
        private System.Windows.Forms.Label main_label;
        private System.Windows.Forms.Label gender_label;
        private System.Windows.Forms.Label date_label;
        private System.Windows.Forms.Button object_info_button;
        private System.Windows.Forms.ComboBox gender_box;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtBox_aditional_Info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PatientUsesGlassesBox;
        private System.Windows.Forms.Label labelGlassesPatient;
        private System.Windows.Forms.Label labelHandUsed;
        private System.Windows.Forms.ComboBox HandedNessOfPatientBox;
        private System.Windows.Forms.PictureBox pictureBoxPatientGlasses;
        private System.Windows.Forms.PictureBox HandedNess;
    }
}