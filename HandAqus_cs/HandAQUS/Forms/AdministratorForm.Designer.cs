using System.Windows.Forms;

namespace HandAQUS
{
    partial class admin_window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin_window));
            this.admin_name_box = new System.Windows.Forms.TextBox();
            this.admin_label = new System.Windows.Forms.Label();
            this.admin_button = new System.Windows.Forms.Button();
            this.administratorPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.administratorPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // admin_name_box
            // 
            this.admin_name_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.admin_name_box.Font = new System.Drawing.Font("Sitka Text", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.admin_name_box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.admin_name_box.Location = new System.Drawing.Point(111, 38);
            this.admin_name_box.MaxLength = 25;
            this.admin_name_box.Name = "admin_name_box";
            this.admin_name_box.Size = new System.Drawing.Size(236, 27);
            this.admin_name_box.TabIndex = 0;
            this.admin_name_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Admin_button_KeyDown);
            // 
            // admin_label
            // 
            this.admin_label.AutoSize = true;
            this.admin_label.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.admin_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.admin_label.Location = new System.Drawing.Point(103, 75);
            this.admin_label.Name = "admin_label";
            this.admin_label.Size = new System.Drawing.Size(244, 28);
            this.admin_label.TabIndex = 1;
            this.admin_label.Text = "Administrator last name";
            this.admin_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // admin_button
            // 
            this.admin_button.AutoSize = true;
            this.admin_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.admin_button.FlatAppearance.BorderSize = 2;
            this.admin_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin_button.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.admin_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.admin_button.Location = new System.Drawing.Point(165, 110);
            this.admin_button.Name = "admin_button";
            this.admin_button.Size = new System.Drawing.Size(100, 42);
            this.admin_button.TabIndex = 2;
            this.admin_button.Text = "SET";
            this.admin_button.UseVisualStyleBackColor = false;
            this.admin_button.Click += new System.EventHandler(this.Admin_button_Click);
            // 
            // administratorPicture
            // 
            this.administratorPicture.Image = ((System.Drawing.Image)(resources.GetObject("administratorPicture.Image")));
            this.administratorPicture.Location = new System.Drawing.Point(27, 22);
            this.administratorPicture.Name = "administratorPicture";
            this.administratorPicture.Size = new System.Drawing.Size(79, 67);
            this.administratorPicture.TabIndex = 3;
            this.administratorPicture.TabStop = false;
            // 
            // admin_window
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 161);
            this.Controls.Add(this.admin_label);
            this.Controls.Add(this.administratorPicture);
            this.Controls.Add(this.admin_name_box);
            this.Controls.Add(this.admin_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "admin_window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HandAQUS";
            ((System.ComponentModel.ISupportInitialize)(this.administratorPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox admin_name_box;
        private System.Windows.Forms.Label admin_label;
        private System.Windows.Forms.Button admin_button;
        private PictureBox administratorPicture;
    }
}