namespace Belfer
{
	partial class dlgPassword
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
			this.txtRepeatPassword = new System.Windows.Forms.TextBox();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.txtNewPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtOldPassword = new System.Windows.Forms.TextBox();
			this.lblOldPassword = new System.Windows.Forms.Label();
			this.cbUserName = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nazwa użytkownika";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(49, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Nowe hasło";
			// 
			// txtRepeatPassword
			// 
			this.txtRepeatPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRepeatPassword.Location = new System.Drawing.Point(120, 102);
			this.txtRepeatPassword.Name = "txtRepeatPassword";
			this.txtRepeatPassword.PasswordChar = '*';
			this.txtRepeatPassword.Size = new System.Drawing.Size(226, 20);
			this.txtRepeatPassword.TabIndex = 3;
			this.txtRepeatPassword.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(190, 137);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 4;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(271, 137);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "Anuluj";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// txtNewPassword
			// 
			this.txtNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNewPassword.Location = new System.Drawing.Point(120, 76);
			this.txtNewPassword.Name = "txtNewPassword";
			this.txtNewPassword.PasswordChar = '*';
			this.txtNewPassword.Size = new System.Drawing.Size(226, 20);
			this.txtNewPassword.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(39, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Powtórz hasło";
			// 
			// txtOldPassword
			// 
			this.txtOldPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOldPassword.Location = new System.Drawing.Point(120, 38);
			this.txtOldPassword.Name = "txtOldPassword";
			this.txtOldPassword.PasswordChar = '*';
			this.txtOldPassword.Size = new System.Drawing.Size(226, 20);
			this.txtOldPassword.TabIndex = 1;
			this.txtOldPassword.Visible = false;
			// 
			// lblOldPassword
			// 
			this.lblOldPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblOldPassword.AutoSize = true;
			this.lblOldPassword.Location = new System.Drawing.Point(49, 41);
			this.lblOldPassword.Name = "lblOldPassword";
			this.lblOldPassword.Size = new System.Drawing.Size(62, 13);
			this.lblOldPassword.TabIndex = 8;
			this.lblOldPassword.Text = "Stare hasło";
			this.lblOldPassword.Visible = false;
			// 
			// cbUserName
			// 
			this.cbUserName.FormattingEnabled = true;
			this.cbUserName.Location = new System.Drawing.Point(120, 12);
			this.cbUserName.Name = "cbUserName";
			this.cbUserName.Size = new System.Drawing.Size(226, 21);
			this.cbUserName.TabIndex = 0;
			// 
			// dlgPassword
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(358, 172);
			this.Controls.Add(this.cbUserName);
			this.Controls.Add(this.lblOldPassword);
			this.Controls.Add(this.txtOldPassword);
			this.Controls.Add(this.txtNewPassword);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.txtRepeatPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgPassword";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Zmiana hasła (tryb administratora)";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		internal System.Windows.Forms.TextBox txtRepeatPassword;
		internal System.Windows.Forms.TextBox txtNewPassword;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtOldPassword;
		private System.Windows.Forms.Label lblOldPassword;
		internal System.Windows.Forms.ComboBox cbUserName;
	}
}