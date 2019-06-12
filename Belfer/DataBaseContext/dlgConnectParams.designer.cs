namespace Belfer.DataBaseContext
{
    partial class dlgConnectParams
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerwerIP = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.rbFromFile = new System.Windows.Forms.RadioButton();
            this.rbByHand = new System.Windows.Forms.RadioButton();
            this.txtFileIn = new System.Windows.Forms.TextBox();
            this.gbConnectParams = new System.Windows.Forms.GroupBox();
            this.nudKeepAlive = new System.Windows.Forms.NumericUpDown();
            this.cmdSaveToFile = new System.Windows.Forms.Button();
            this.cbSslMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCharset = new System.Windows.Forms.TextBox();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.gbConnectParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeepAlive)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(394, 333);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 0;
            this.cmdCancel.Text = "&Anuluj";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.Location = new System.Drawing.Point(313, 333);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "&OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adres serwera (IP)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baza danych";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Użytkownik";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hasło";
            // 
            // txtSerwerIP
            // 
            this.txtSerwerIP.Location = new System.Drawing.Point(123, 22);
            this.txtSerwerIP.Name = "txtSerwerIP";
            this.txtSerwerIP.Size = new System.Drawing.Size(328, 20);
            this.txtSerwerIP.TabIndex = 6;
            this.txtSerwerIP.Tag = "0";
            this.txtSerwerIP.TextChanged += new System.EventHandler(this.txtSerwerIP_TextChanged);
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(123, 48);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(328, 20);
            this.txtDBName.TabIndex = 7;
            this.txtDBName.Tag = "1";
            this.txtDBName.TextChanged += new System.EventHandler(this.txtSerwerIP_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(123, 74);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(328, 20);
            this.txtUserName.TabIndex = 8;
            this.txtUserName.Tag = "2";
            this.txtUserName.TextChanged += new System.EventHandler(this.txtSerwerIP_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(123, 100);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(328, 20);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.Tag = "3";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtSerwerIP_TextChanged);
            // 
            // rbFromFile
            // 
            this.rbFromFile.AutoSize = true;
            this.rbFromFile.Checked = true;
            this.rbFromFile.Location = new System.Drawing.Point(12, 12);
            this.rbFromFile.Name = "rbFromFile";
            this.rbFromFile.Size = new System.Drawing.Size(200, 17);
            this.rbFromFile.TabIndex = 12;
            this.rbFromFile.TabStop = true;
            this.rbFromFile.Text = "Załaduj parametry połączenia z pliku";
            this.rbFromFile.UseVisualStyleBackColor = true;
            this.rbFromFile.CheckedChanged += new System.EventHandler(this.rbFromFile_CheckedChanged);
            // 
            // rbByHand
            // 
            this.rbByHand.AutoSize = true;
            this.rbByHand.Location = new System.Drawing.Point(12, 61);
            this.rbByHand.Name = "rbByHand";
            this.rbByHand.Size = new System.Drawing.Size(218, 17);
            this.rbByHand.TabIndex = 13;
            this.rbByHand.Text = "Wprowadź parametry połączenia ręcznie";
            this.rbByHand.UseVisualStyleBackColor = true;
            this.rbByHand.CheckedChanged += new System.EventHandler(this.rbByHand_CheckedChanged);
            // 
            // txtFileIn
            // 
            this.txtFileIn.Location = new System.Drawing.Point(12, 35);
            this.txtFileIn.Name = "txtFileIn";
            this.txtFileIn.ReadOnly = true;
            this.txtFileIn.Size = new System.Drawing.Size(422, 20);
            this.txtFileIn.TabIndex = 14;
            this.txtFileIn.TextChanged += new System.EventHandler(this.txtFileIn_TextChanged);
            // 
            // gbConnectParams
            // 
            this.gbConnectParams.Controls.Add(this.nudKeepAlive);
            this.gbConnectParams.Controls.Add(this.cmdSaveToFile);
            this.gbConnectParams.Controls.Add(this.cbSslMode);
            this.gbConnectParams.Controls.Add(this.txtSerwerIP);
            this.gbConnectParams.Controls.Add(this.label1);
            this.gbConnectParams.Controls.Add(this.label2);
            this.gbConnectParams.Controls.Add(this.label3);
            this.gbConnectParams.Controls.Add(this.txtDBName);
            this.gbConnectParams.Controls.Add(this.label7);
            this.gbConnectParams.Controls.Add(this.label6);
            this.gbConnectParams.Controls.Add(this.label5);
            this.gbConnectParams.Controls.Add(this.label4);
            this.gbConnectParams.Controls.Add(this.txtUserName);
            this.gbConnectParams.Controls.Add(this.txtCharset);
            this.gbConnectParams.Controls.Add(this.txtPassword);
            this.gbConnectParams.Enabled = false;
            this.gbConnectParams.Location = new System.Drawing.Point(12, 84);
            this.gbConnectParams.Name = "gbConnectParams";
            this.gbConnectParams.Size = new System.Drawing.Size(457, 243);
            this.gbConnectParams.TabIndex = 16;
            this.gbConnectParams.TabStop = false;
            this.gbConnectParams.Text = "Parametry połączenia";
            // 
            // nudKeepAlive
            // 
            this.nudKeepAlive.Location = new System.Drawing.Point(123, 180);
            this.nudKeepAlive.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nudKeepAlive.Name = "nudKeepAlive";
            this.nudKeepAlive.Size = new System.Drawing.Size(120, 20);
            this.nudKeepAlive.TabIndex = 13;
            // 
            // cmdSaveToFile
            // 
            this.cmdSaveToFile.Enabled = false;
            this.cmdSaveToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdSaveToFile.Image = global::Belfer.Properties.Resources.Save_24;
            this.cmdSaveToFile.Location = new System.Drawing.Point(123, 205);
            this.cmdSaveToFile.Name = "cmdSaveToFile";
            this.cmdSaveToFile.Size = new System.Drawing.Size(328, 32);
            this.cmdSaveToFile.TabIndex = 12;
            this.cmdSaveToFile.Text = "Zapisz parametry połączenia do pliku konfiguracyjnego";
            this.cmdSaveToFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSaveToFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdSaveToFile.UseVisualStyleBackColor = true;
            this.cmdSaveToFile.Click += new System.EventHandler(this.cmdSaveToFile_Click);
            // 
            // cbSslMode
            // 
            this.cbSslMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSslMode.FormattingEnabled = true;
            this.cbSslMode.Location = new System.Drawing.Point(123, 126);
            this.cbSslMode.Name = "cbSslMode";
            this.cbSslMode.Size = new System.Drawing.Size(328, 21);
            this.cbSslMode.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Interwał podtrzymania";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Kodowanie znaków";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tryb SSL";
            // 
            // txtCharset
            // 
            this.txtCharset.Location = new System.Drawing.Point(123, 153);
            this.txtCharset.Name = "txtCharset";
            this.txtCharset.Size = new System.Drawing.Size(328, 20);
            this.txtCharset.TabIndex = 11;
            this.txtCharset.Tag = "4";
            this.txtCharset.TextChanged += new System.EventHandler(this.txtSerwerIP_TextChanged);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmdOpen.Image = global::Belfer.Properties.Resources.open_24;
            this.cmdOpen.Location = new System.Drawing.Point(440, 28);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(29, 32);
            this.cmdOpen.TabIndex = 15;
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // dlgConnectParams
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 365);
            this.Controls.Add(this.gbConnectParams);
            this.Controls.Add(this.cmdOpen);
            this.Controls.Add(this.txtFileIn);
            this.Controls.Add(this.rbByHand);
            this.Controls.Add(this.rbFromFile);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgConnectParams";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametry połączenia";
            this.gbConnectParams.ResumeLayout(false);
            this.gbConnectParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeepAlive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbFromFile;
        private System.Windows.Forms.RadioButton rbByHand;
        private System.Windows.Forms.TextBox txtFileIn;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.GroupBox gbConnectParams;
        internal System.Windows.Forms.TextBox txtSerwerIP;
        internal System.Windows.Forms.TextBox txtDBName;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ComboBox cbSslMode;
        private System.Windows.Forms.Button cmdSaveToFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtCharset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudKeepAlive;
    }
}