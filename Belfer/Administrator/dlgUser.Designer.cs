namespace Belfer
{
	partial class dlgUser
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
			this.pnlUser = new System.Windows.Forms.Panel();
			this.cmdPwdGen = new System.Windows.Forms.Button();
			this.chkShowPassword = new System.Windows.Forms.CheckBox();
			this.txtPassword2 = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pbFaximile = new System.Windows.Forms.PictureBox();
			this.chkSex = new System.Windows.Forms.CheckBox();
			this.chkStatus = new System.Windows.Forms.CheckBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.cbRola = new System.Windows.Forms.ComboBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtImie = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtNazwisko = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.pnlUser.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbFaximile)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(521, 188);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 10;
			this.cmdCancel.Text = "Anuluj";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(440, 188);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 9;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// pnlUser
			// 
			this.pnlUser.Controls.Add(this.cmdPwdGen);
			this.pnlUser.Controls.Add(this.chkShowPassword);
			this.pnlUser.Controls.Add(this.txtPassword2);
			this.pnlUser.Controls.Add(this.txtPassword);
			this.pnlUser.Controls.Add(this.label7);
			this.pnlUser.Controls.Add(this.label6);
			this.pnlUser.Controls.Add(this.label1);
			this.pnlUser.Controls.Add(this.pbFaximile);
			this.pnlUser.Controls.Add(this.chkSex);
			this.pnlUser.Controls.Add(this.chkStatus);
			this.pnlUser.Controls.Add(this.txtEmail);
			this.pnlUser.Controls.Add(this.Label5);
			this.pnlUser.Controls.Add(this.cbRola);
			this.pnlUser.Controls.Add(this.Label4);
			this.pnlUser.Controls.Add(this.txtImie);
			this.pnlUser.Controls.Add(this.Label3);
			this.pnlUser.Controls.Add(this.txtNazwisko);
			this.pnlUser.Controls.Add(this.Label2);
			this.pnlUser.Controls.Add(this.label10);
			this.pnlUser.Controls.Add(this.txtLogin);
			this.pnlUser.Location = new System.Drawing.Point(12, 12);
			this.pnlUser.Name = "pnlUser";
			this.pnlUser.Size = new System.Drawing.Size(592, 156);
			this.pnlUser.TabIndex = 24;
			// 
			// cmdPwdGen
			// 
			this.cmdPwdGen.Location = new System.Drawing.Point(408, 37);
			this.cmdPwdGen.Name = "cmdPwdGen";
			this.cmdPwdGen.Size = new System.Drawing.Size(84, 23);
			this.cmdPwdGen.TabIndex = 45;
			this.cmdPwdGen.Text = "Generuj hasło";
			this.cmdPwdGen.UseVisualStyleBackColor = true;
			this.cmdPwdGen.Click += new System.EventHandler(this.cmdPwdGen_Click);
			// 
			// chkShowPassword
			// 
			this.chkShowPassword.AutoSize = true;
			this.chkShowPassword.Location = new System.Drawing.Point(498, 40);
			this.chkShowPassword.Name = "chkShowPassword";
			this.chkShowPassword.Size = new System.Drawing.Size(86, 17);
			this.chkShowPassword.TabIndex = 44;
			this.chkShowPassword.Text = "Pokaż hasło";
			this.chkShowPassword.UseVisualStyleBackColor = true;
			this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
			// 
			// txtPassword2
			// 
			this.txtPassword2.Location = new System.Drawing.Point(276, 38);
			this.txtPassword2.Name = "txtPassword2";
			this.txtPassword2.PasswordChar = '*';
			this.txtPassword2.Size = new System.Drawing.Size(126, 20);
			this.txtPassword2.TabIndex = 4;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(63, 38);
			this.txtPassword.MaxLength = 20;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(126, 20);
			this.txtPassword.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(195, 42);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(75, 13);
			this.label7.TabIndex = 41;
			this.label7.Text = "Powtórz hasło";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 42);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(36, 13);
			this.label6.TabIndex = 40;
			this.label6.Text = "Hasło";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(297, 114);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 39;
			this.label1.Text = "Faximile";
			// 
			// pbFaximile
			// 
			this.pbFaximile.Location = new System.Drawing.Point(347, 111);
			this.pbFaximile.Name = "pbFaximile";
			this.pbFaximile.Size = new System.Drawing.Size(230, 20);
			this.pbFaximile.TabIndex = 38;
			this.pbFaximile.TabStop = false;
			// 
			// chkSex
			// 
			this.chkSex.AutoSize = true;
			this.chkSex.Location = new System.Drawing.Point(507, 87);
			this.chkSex.Name = "chkSex";
			this.chkSex.Size = new System.Drawing.Size(79, 17);
			this.chkSex.TabIndex = 7;
			this.chkSex.Text = "Mężczyzna";
			this.chkSex.UseVisualStyleBackColor = true;
			// 
			// chkStatus
			// 
			this.chkStatus.AutoSize = true;
			this.chkStatus.Checked = true;
			this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkStatus.Location = new System.Drawing.Point(498, 12);
			this.chkStatus.Name = "chkStatus";
			this.chkStatus.Size = new System.Drawing.Size(66, 17);
			this.chkStatus.TabIndex = 2;
			this.chkStatus.Text = "Aktywny";
			this.chkStatus.UseVisualStyleBackColor = true;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(63, 111);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(228, 20);
			this.txtEmail.TabIndex = 8;
			this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(3, 114);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(35, 13);
			this.Label5.TabIndex = 30;
			this.Label5.Text = "E-mail";
			// 
			// cbRola
			// 
			this.cbRola.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.cbRola.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbRola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRola.FormattingEnabled = true;
			this.cbRola.Location = new System.Drawing.Point(276, 9);
			this.cbRola.Name = "cbRola";
			this.cbRola.Size = new System.Drawing.Size(216, 21);
			this.cbRola.TabIndex = 1;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(241, 13);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(29, 13);
			this.Label4.TabIndex = 27;
			this.Label4.Text = "Rola";
			// 
			// txtImie
			// 
			this.txtImie.Location = new System.Drawing.Point(301, 85);
			this.txtImie.MaxLength = 45;
			this.txtImie.Name = "txtImie";
			this.txtImie.Size = new System.Drawing.Size(200, 20);
			this.txtImie.TabIndex = 6;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(269, 88);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(26, 13);
			this.Label3.TabIndex = 24;
			this.Label3.Text = "Imię";
			// 
			// txtNazwisko
			// 
			this.txtNazwisko.Location = new System.Drawing.Point(63, 85);
			this.txtNazwisko.MaxLength = 45;
			this.txtNazwisko.Name = "txtNazwisko";
			this.txtNazwisko.Size = new System.Drawing.Size(200, 20);
			this.txtNazwisko.TabIndex = 5;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(4, 88);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(53, 13);
			this.Label2.TabIndex = 21;
			this.Label2.Text = "Nazwisko";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(4, 13);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(33, 13);
			this.label10.TabIndex = 20;
			this.label10.Text = "Login";
			// 
			// txtLogin
			// 
			this.txtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.txtLogin.Location = new System.Drawing.Point(63, 10);
			this.txtLogin.MaxLength = 10;
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(172, 20);
			this.txtLogin.TabIndex = 0;
			this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
			this.txtLogin.Validating += new System.ComponentModel.CancelEventHandler(this.txtLogin_Validating);
			// 
			// dlgUser
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(608, 223);
			this.Controls.Add(this.pnlUser);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Nowy użytkownik";
			this.pnlUser.ResumeLayout(false);
			this.pnlUser.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbFaximile)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmdCancel;
		protected internal System.Windows.Forms.Button cmdOK;
		internal System.Windows.Forms.Panel pnlUser;
		internal System.Windows.Forms.TextBox txtEmail;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.ComboBox cbRola;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox txtImie;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox txtNazwisko;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.CheckBox chkStatus;
		internal System.Windows.Forms.CheckBox chkSex;
		internal System.Windows.Forms.PictureBox pbFaximile;
		internal System.Windows.Forms.TextBox txtPassword2;
		internal System.Windows.Forms.TextBox txtPassword;
		internal System.Windows.Forms.CheckBox chkShowPassword;
		internal System.Windows.Forms.Button cmdPwdGen;
	}
}