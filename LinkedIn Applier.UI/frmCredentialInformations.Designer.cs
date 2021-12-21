namespace LinkedIn_Applier.UI
{
    partial class frmCredentialInformations
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRequireSSL = new System.Windows.Forms.CheckBox();
            this.txtMailAdress = new System.Windows.Forms.TextBox();
            this.txtCredentialPassword = new System.Windows.Forms.TextBox();
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.nudSmtpPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail Adress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Credential Pass";
            // 
            // cbRequireSSL
            // 
            this.cbRequireSSL.AutoSize = true;
            this.cbRequireSSL.Location = new System.Drawing.Point(110, 157);
            this.cbRequireSSL.Name = "cbRequireSSL";
            this.cbRequireSSL.Size = new System.Drawing.Size(87, 19);
            this.cbRequireSSL.TabIndex = 3;
            this.cbRequireSSL.Text = "Require SSL";
            this.cbRequireSSL.UseVisualStyleBackColor = true;
            this.cbRequireSSL.CheckedChanged += new System.EventHandler(this.cbRequireSSL_CheckedChanged);
            // 
            // txtMailAdress
            // 
            this.txtMailAdress.Location = new System.Drawing.Point(110, 41);
            this.txtMailAdress.Name = "txtMailAdress";
            this.txtMailAdress.Size = new System.Drawing.Size(269, 23);
            this.txtMailAdress.TabIndex = 4;
            this.txtMailAdress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtObjects_KeyUp);
            // 
            // txtCredentialPassword
            // 
            this.txtCredentialPassword.Location = new System.Drawing.Point(110, 70);
            this.txtCredentialPassword.Name = "txtCredentialPassword";
            this.txtCredentialPassword.Size = new System.Drawing.Size(269, 23);
            this.txtCredentialPassword.TabIndex = 5;
            this.txtCredentialPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtObjects_KeyUp);
            // 
            // txtSmtpServer
            // 
            this.txtSmtpServer.Location = new System.Drawing.Point(110, 99);
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.Size = new System.Drawing.Size(269, 23);
            this.txtSmtpServer.TabIndex = 6;
            this.txtSmtpServer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtObjects_KeyUp);
            // 
            // nudSmtpPort
            // 
            this.nudSmtpPort.Location = new System.Drawing.Point(110, 128);
            this.nudSmtpPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.nudSmtpPort.Name = "nudSmtpPort";
            this.nudSmtpPort.Size = new System.Drawing.Size(269, 23);
            this.nudSmtpPort.TabIndex = 7;
            this.nudSmtpPort.ValueChanged += new System.EventHandler(this.nudSmtpPort_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "SMTP Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(110, 12);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(269, 23);
            this.txtDisplayName.TabIndex = 11;
            this.txtDisplayName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtObjects_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Display Name";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(131, 194);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 48);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Maroon;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(258, 194);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 48);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTest.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTest.ForeColor = System.Drawing.Color.White;
            this.btnTest.Location = new System.Drawing.Point(4, 194);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(121, 48);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "&TEST";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // frmCredentialInformations
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(402, 267);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudSmtpPort);
            this.Controls.Add(this.txtSmtpServer);
            this.Controls.Add(this.txtCredentialPassword);
            this.Controls.Add(this.txtMailAdress);
            this.Controls.Add(this.cbRequireSSL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCredentialInformations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credential Informations";
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox cbRequireSSL;
        private TextBox txtMailAdress;
        private TextBox txtCredentialPassword;
        private TextBox txtSmtpServer;
        private NumericUpDown nudSmtpPort;
        private Label label3;
        private Label label4;
        private TextBox txtDisplayName;
        private Label label5;
        private Button btnSave;
        private Button btnCancel;
        private Button btnTest;
    }
}