namespace LinkedIn_Applier
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtWorkType = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstLocations = new System.Windows.Forms.ListBox();
            this.btnDeleteLocation = new System.Windows.Forms.Button();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.cbOutomaticSendEmail = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAttachmentFile = new System.Windows.Forms.Label();
            this.btmOpenFile = new System.Windows.Forms.Button();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.grpEmailDetails = new System.Windows.Forms.GroupBox();
            this.btnIndent = new System.Windows.Forms.Button();
            this.btnIndentRemove = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnItalic = new System.Windows.Forms.Button();
            this.btnUnderline = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.cbHideEverything = new System.Windows.Forms.CheckBox();
            this.cbProfiles = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddProfile = new System.Windows.Forms.Button();
            this.btnDeleteProfile = new System.Windows.Forms.Button();
            this.rbSendAll = new System.Windows.Forms.RadioButton();
            this.rbSendCurrent = new System.Windows.Forms.RadioButton();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.grpEmailDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWorkType
            // 
            this.txtWorkType.Location = new System.Drawing.Point(10, 222);
            this.txtWorkType.Name = "txtWorkType";
            this.txtWorkType.Size = new System.Drawing.Size(417, 20);
            this.txtWorkType.TabIndex = 0;
            this.txtWorkType.TextChanged += new System.EventHandler(this.txtWorkType_TextChanged);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(12, 172);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(215, 20);
            this.txtLocation.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(10, 709);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(417, 28);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Step 1 - Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Work Keywords";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "@Location";
            // 
            // lstLocations
            // 
            this.lstLocations.FormattingEnabled = true;
            this.lstLocations.Location = new System.Drawing.Point(12, 68);
            this.lstLocations.Name = "lstLocations";
            this.lstLocations.Size = new System.Drawing.Size(415, 95);
            this.lstLocations.TabIndex = 10;
            // 
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.Location = new System.Drawing.Point(333, 169);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(94, 23);
            this.btnDeleteLocation.TabIndex = 11;
            this.btnDeleteLocation.Text = "Delete";
            this.btnDeleteLocation.UseVisualStyleBackColor = true;
            this.btnDeleteLocation.Click += new System.EventHandler(this.BtnDeleteLocation_Click);
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(233, 169);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(94, 23);
            this.btnAddLocation.TabIndex = 12;
            this.btnAddLocation.Text = "Add";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // cbOutomaticSendEmail
            // 
            this.cbOutomaticSendEmail.AutoSize = true;
            this.cbOutomaticSendEmail.Location = new System.Drawing.Point(10, 653);
            this.cbOutomaticSendEmail.Name = "cbOutomaticSendEmail";
            this.cbOutomaticSendEmail.Size = new System.Drawing.Size(155, 17);
            this.cbOutomaticSendEmail.TabIndex = 13;
            this.cbOutomaticSendEmail.Text = "Outomatic Send E-Mail";
            this.cbOutomaticSendEmail.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Subject";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(60, 22);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(364, 20);
            this.txtSubject.TabIndex = 24;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Mail Content";
            // 
            // lblAttachmentFile
            // 
            this.lblAttachmentFile.AutoSize = true;
            this.lblAttachmentFile.Location = new System.Drawing.Point(3, 331);
            this.lblAttachmentFile.Name = "lblAttachmentFile";
            this.lblAttachmentFile.Size = new System.Drawing.Size(95, 13);
            this.lblAttachmentFile.TabIndex = 19;
            this.lblAttachmentFile.Text = "Attachment File";
            // 
            // btmOpenFile
            // 
            this.btmOpenFile.Font = new System.Drawing.Font("Wide Latin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btmOpenFile.Location = new System.Drawing.Point(369, 345);
            this.btmOpenFile.Name = "btmOpenFile";
            this.btmOpenFile.Size = new System.Drawing.Size(52, 23);
            this.btmOpenFile.TabIndex = 18;
            this.btmOpenFile.Text = "...";
            this.btmOpenFile.UseVisualStyleBackColor = true;
            this.btmOpenFile.Click += new System.EventHandler(this.BtmOpenFile_Click);
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(6, 347);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.ReadOnly = true;
            this.txtFileLocation.Size = new System.Drawing.Size(357, 20);
            this.txtFileLocation.TabIndex = 17;
            // 
            // rtbMessage
            // 
            this.rtbMessage.Location = new System.Drawing.Point(6, 78);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(418, 250);
            this.rtbMessage.TabIndex = 16;
            this.rtbMessage.Text = "";
            this.rtbMessage.TextChanged += new System.EventHandler(this.rtbMessage_TextChanged);
            this.rtbMessage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RtbMessage_MouseDown);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Wide Latin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSend.Location = new System.Drawing.Point(10, 743);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(417, 28);
            this.btnSend.TabIndex = 31;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // grpEmailDetails
            // 
            this.grpEmailDetails.Controls.Add(this.btnIndent);
            this.grpEmailDetails.Controls.Add(this.rtbMessage);
            this.grpEmailDetails.Controls.Add(this.btnIndentRemove);
            this.grpEmailDetails.Controls.Add(this.txtFileLocation);
            this.grpEmailDetails.Controls.Add(this.btnRedo);
            this.grpEmailDetails.Controls.Add(this.btmOpenFile);
            this.grpEmailDetails.Controls.Add(this.btnUndo);
            this.grpEmailDetails.Controls.Add(this.lblAttachmentFile);
            this.grpEmailDetails.Controls.Add(this.btnSelectColor);
            this.grpEmailDetails.Controls.Add(this.label4);
            this.grpEmailDetails.Controls.Add(this.label3);
            this.grpEmailDetails.Controls.Add(this.btnBold);
            this.grpEmailDetails.Controls.Add(this.txtSubject);
            this.grpEmailDetails.Controls.Add(this.btnItalic);
            this.grpEmailDetails.Controls.Add(this.btnUnderline);
            this.grpEmailDetails.Location = new System.Drawing.Point(3, 248);
            this.grpEmailDetails.Name = "grpEmailDetails";
            this.grpEmailDetails.Size = new System.Drawing.Size(435, 376);
            this.grpEmailDetails.TabIndex = 32;
            this.grpEmailDetails.TabStop = false;
            // 
            // btnIndent
            // 
            this.btnIndent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIndent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIndent.Image = global::LinkedIn_Applier.UI.Properties.Resources.text_indent;
            this.btnIndent.Location = new System.Drawing.Point(387, 48);
            this.btnIndent.Name = "btnIndent";
            this.btnIndent.Size = new System.Drawing.Size(34, 23);
            this.btnIndent.TabIndex = 30;
            this.btnIndent.UseVisualStyleBackColor = true;
            this.btnIndent.Click += new System.EventHandler(this.BtnIndent_Click);
            // 
            // btnIndentRemove
            // 
            this.btnIndentRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIndentRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIndentRemove.Image = global::LinkedIn_Applier.UI.Properties.Resources.text_indent_remove;
            this.btnIndentRemove.Location = new System.Drawing.Point(347, 48);
            this.btnIndentRemove.Name = "btnIndentRemove";
            this.btnIndentRemove.Size = new System.Drawing.Size(34, 23);
            this.btnIndentRemove.TabIndex = 29;
            this.btnIndentRemove.UseVisualStyleBackColor = true;
            this.btnIndentRemove.Click += new System.EventHandler(this.BtnIndentRemove_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Enabled = false;
            this.btnRedo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRedo.Image = global::LinkedIn_Applier.UI.Properties.Resources.arrow_redo;
            this.btnRedo.Location = new System.Drawing.Point(143, 48);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(34, 23);
            this.btnRedo.TabIndex = 28;
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.BtnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUndo.Image = global::LinkedIn_Applier.UI.Properties.Resources.arrow_undo;
            this.btnUndo.Location = new System.Drawing.Point(103, 48);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(34, 23);
            this.btnUndo.TabIndex = 27;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelectColor.Image = global::LinkedIn_Applier.UI.Properties.Resources.text_color;
            this.btnSelectColor.Location = new System.Drawing.Point(307, 48);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(34, 23);
            this.btnSelectColor.TabIndex = 26;
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnBold
            // 
            this.btnBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBold.Image = global::LinkedIn_Applier.UI.Properties.Resources.text_bold;
            this.btnBold.Location = new System.Drawing.Point(184, 48);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(34, 23);
            this.btnBold.TabIndex = 21;
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Click += new System.EventHandler(this.BtnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnItalic.Image = global::LinkedIn_Applier.UI.Properties.Resources.text_italic;
            this.btnItalic.Location = new System.Drawing.Point(225, 48);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(34, 23);
            this.btnItalic.TabIndex = 22;
            this.btnItalic.UseVisualStyleBackColor = true;
            this.btnItalic.Click += new System.EventHandler(this.BtnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.btnUnderline.Image = global::LinkedIn_Applier.UI.Properties.Resources.text_underline;
            this.btnUnderline.Location = new System.Drawing.Point(266, 48);
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(34, 23);
            this.btnUnderline.TabIndex = 23;
            this.btnUnderline.UseVisualStyleBackColor = true;
            this.btnUnderline.Click += new System.EventHandler(this.BtnUnderline_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveSettings.Location = new System.Drawing.Point(327, 680);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(97, 23);
            this.btnSaveSettings.TabIndex = 34;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.BtnSaveSettings_Click);
            // 
            // cbHideEverything
            // 
            this.cbHideEverything.AutoSize = true;
            this.cbHideEverything.Location = new System.Drawing.Point(10, 630);
            this.cbHideEverything.Name = "cbHideEverything";
            this.cbHideEverything.Size = new System.Drawing.Size(207, 17);
            this.cbHideEverything.TabIndex = 33;
            this.cbHideEverything.Text = "Hide everything while searching";
            this.cbHideEverything.UseVisualStyleBackColor = true;
            // 
            // cbProfiles
            // 
            this.cbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfiles.FormattingEnabled = true;
            this.cbProfiles.Location = new System.Drawing.Point(12, 21);
            this.cbProfiles.Name = "cbProfiles";
            this.cbProfiles.Size = new System.Drawing.Size(215, 21);
            this.cbProfiles.TabIndex = 34;
            this.cbProfiles.SelectedIndexChanged += new System.EventHandler(this.cbProfiles_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "@ProfileName";
            // 
            // btnAddProfile
            // 
            this.btnAddProfile.Location = new System.Drawing.Point(233, 19);
            this.btnAddProfile.Name = "btnAddProfile";
            this.btnAddProfile.Size = new System.Drawing.Size(94, 23);
            this.btnAddProfile.TabIndex = 36;
            this.btnAddProfile.Text = "Add";
            this.btnAddProfile.UseVisualStyleBackColor = true;
            this.btnAddProfile.Click += new System.EventHandler(this.btnAddProfile_Click);
            // 
            // btnDeleteProfile
            // 
            this.btnDeleteProfile.Location = new System.Drawing.Point(333, 19);
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(94, 23);
            this.btnDeleteProfile.TabIndex = 37;
            this.btnDeleteProfile.Text = "Delete";
            this.btnDeleteProfile.UseVisualStyleBackColor = true;
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // rbSendAll
            // 
            this.rbSendAll.AutoSize = true;
            this.rbSendAll.Checked = true;
            this.rbSendAll.Location = new System.Drawing.Point(10, 676);
            this.rbSendAll.Name = "rbSendAll";
            this.rbSendAll.Size = new System.Drawing.Size(112, 17);
            this.rbSendAll.TabIndex = 38;
            this.rbSendAll.TabStop = true;
            this.rbSendAll.Text = "Send All Profile";
            this.rbSendAll.UseVisualStyleBackColor = true;
            // 
            // rbSendCurrent
            // 
            this.rbSendCurrent.AutoSize = true;
            this.rbSendCurrent.Location = new System.Drawing.Point(128, 676);
            this.rbSendCurrent.Name = "rbSendCurrent";
            this.rbSendCurrent.Size = new System.Drawing.Size(139, 17);
            this.rbSendCurrent.TabIndex = 39;
            this.rbSendCurrent.Text = "Send Current Profile";
            this.rbSendCurrent.UseVisualStyleBackColor = true;
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveProfile.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveProfile.FlatAppearance.BorderSize = 2;
            this.btnSaveProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProfile.Location = new System.Drawing.Point(233, 42);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(191, 23);
            this.btnSaveProfile.TabIndex = 40;
            this.btnSaveProfile.Text = "Save Profile";
            this.btnSaveProfile.UseVisualStyleBackColor = false;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 778);
            this.Controls.Add(this.btnSaveProfile);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.rbSendCurrent);
            this.Controls.Add(this.rbSendAll);
            this.Controls.Add(this.btnDeleteProfile);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cbOutomaticSendEmail);
            this.Controls.Add(this.btnAddProfile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbProfiles);
            this.Controls.Add(this.cbHideEverything);
            this.Controls.Add(this.grpEmailDetails);
            this.Controls.Add(this.btnAddLocation);
            this.Controls.Add(this.btnDeleteLocation);
            this.Controls.Add(this.lstLocations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtWorkType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linked In";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpEmailDetails.ResumeLayout(false);
            this.grpEmailDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWorkType;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstLocations;
        private System.Windows.Forms.Button btnDeleteLocation;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.CheckBox cbOutomaticSendEmail;
        private System.Windows.Forms.Button btnIndent;
        private System.Windows.Forms.Button btnIndentRemove;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Button btnUnderline;
        private System.Windows.Forms.Button btnItalic;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAttachmentFile;
        private System.Windows.Forms.Button btmOpenFile;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox grpEmailDetails;
        private System.Windows.Forms.CheckBox cbHideEverything;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.ComboBox cbProfiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddProfile;
        private System.Windows.Forms.Button btnDeleteProfile;
        private System.Windows.Forms.RadioButton rbSendAll;
        private System.Windows.Forms.RadioButton rbSendCurrent;
        private System.Windows.Forms.Button btnSaveProfile;
    }
}

