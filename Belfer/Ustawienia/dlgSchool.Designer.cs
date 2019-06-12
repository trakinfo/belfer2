namespace Belfer
{
	partial class dlgSchool
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
			this.cbTyp = new System.Windows.Forms.ComboBox();
			this.pnlSzkola = new System.Windows.Forms.Panel();
			this.cmdMiejscowosc = new System.Windows.Forms.Button();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtFax = new System.Windows.Forms.TextBox();
			this.txtTel = new System.Windows.Forms.TextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.txtNr = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.txtUlica = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.cbMiejscowosc = new System.Windows.Forms.ComboBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtNip = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtAlias = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtNazwa = new System.Windows.Forms.TextBox();
			this.pnlSzkola.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(521, 201);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.Text = "Anuluj";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(440, 201);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 6;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Typ szkoły";
			// 
			// cbTyp
			// 
			this.cbTyp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.cbTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTyp.FormattingEnabled = true;
			this.cbTyp.Location = new System.Drawing.Point(77, 12);
			this.cbTyp.Name = "cbTyp";
			this.cbTyp.Size = new System.Drawing.Size(324, 21);
			this.cbTyp.TabIndex = 9;
			this.cbTyp.SelectedIndexChanged += new System.EventHandler(this.cbTyp_SelectedIndexChanged);
			// 
			// pnlSzkola
			// 
			this.pnlSzkola.Controls.Add(this.cmdMiejscowosc);
			this.pnlSzkola.Controls.Add(this.txtEmail);
			this.pnlSzkola.Controls.Add(this.txtFax);
			this.pnlSzkola.Controls.Add(this.txtTel);
			this.pnlSzkola.Controls.Add(this.Label9);
			this.pnlSzkola.Controls.Add(this.Label8);
			this.pnlSzkola.Controls.Add(this.Label7);
			this.pnlSzkola.Controls.Add(this.txtNr);
			this.pnlSzkola.Controls.Add(this.Label6);
			this.pnlSzkola.Controls.Add(this.txtUlica);
			this.pnlSzkola.Controls.Add(this.Label5);
			this.pnlSzkola.Controls.Add(this.cbMiejscowosc);
			this.pnlSzkola.Controls.Add(this.Label4);
			this.pnlSzkola.Controls.Add(this.txtNip);
			this.pnlSzkola.Controls.Add(this.Label3);
			this.pnlSzkola.Controls.Add(this.txtAlias);
			this.pnlSzkola.Controls.Add(this.Label2);
			this.pnlSzkola.Controls.Add(this.label10);
			this.pnlSzkola.Controls.Add(this.txtNazwa);
			this.pnlSzkola.Enabled = false;
			this.pnlSzkola.Location = new System.Drawing.Point(12, 39);
			this.pnlSzkola.Name = "pnlSzkola";
			this.pnlSzkola.Size = new System.Drawing.Size(584, 146);
			this.pnlSzkola.TabIndex = 23;
			// 
			// cmdMiejscowosc
			// 
			this.cmdMiejscowosc.Location = new System.Drawing.Point(428, 61);
			this.cmdMiejscowosc.Name = "cmdMiejscowosc";
			this.cmdMiejscowosc.Size = new System.Drawing.Size(147, 23);
			this.cmdMiejscowosc.TabIndex = 36;
			this.cmdMiejscowosc.Text = "Dodaj nową miejscowość";
			this.cmdMiejscowosc.UseVisualStyleBackColor = true;
			this.cmdMiejscowosc.Click += new System.EventHandler(this.cmdMiejscowosc_Click);
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(360, 115);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(215, 20);
			this.txtEmail.TabIndex = 10;
			this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
			// 
			// txtFax
			// 
			this.txtFax.Location = new System.Drawing.Point(213, 115);
			this.txtFax.Name = "txtFax";
			this.txtFax.Size = new System.Drawing.Size(100, 20);
			this.txtFax.TabIndex = 9;
			// 
			// txtTel
			// 
			this.txtTel.Location = new System.Drawing.Point(77, 115);
			this.txtTel.Name = "txtTel";
			this.txtTel.Size = new System.Drawing.Size(100, 20);
			this.txtTel.TabIndex = 8;
			// 
			// Label9
			// 
			this.Label9.AutoSize = true;
			this.Label9.Location = new System.Drawing.Point(319, 118);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(35, 13);
			this.Label9.TabIndex = 35;
			this.Label9.Text = "E-mail";
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.Location = new System.Drawing.Point(183, 118);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(24, 13);
			this.Label8.TabIndex = 34;
			this.Label8.Text = "Fax";
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(4, 118);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(43, 13);
			this.Label7.TabIndex = 33;
			this.Label7.Text = "Telefon";
			// 
			// txtNr
			// 
			this.txtNr.Location = new System.Drawing.Point(512, 89);
			this.txtNr.Name = "txtNr";
			this.txtNr.Size = new System.Drawing.Size(63, 20);
			this.txtNr.TabIndex = 7;
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(488, 92);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(18, 13);
			this.Label6.TabIndex = 32;
			this.Label6.Text = "Nr";
			// 
			// txtUlica
			// 
			this.txtUlica.Location = new System.Drawing.Point(77, 89);
			this.txtUlica.Name = "txtUlica";
			this.txtUlica.Size = new System.Drawing.Size(405, 20);
			this.txtUlica.TabIndex = 6;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(4, 92);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(31, 13);
			this.Label5.TabIndex = 30;
			this.Label5.Text = "Ulica";
			// 
			// cbMiejscowosc
			// 
			this.cbMiejscowosc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.cbMiejscowosc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbMiejscowosc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMiejscowosc.FormattingEnabled = true;
			this.cbMiejscowosc.Location = new System.Drawing.Point(77, 62);
			this.cbMiejscowosc.Name = "cbMiejscowosc";
			this.cbMiejscowosc.Size = new System.Drawing.Size(345, 21);
			this.cbMiejscowosc.TabIndex = 5;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(3, 65);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(68, 13);
			this.Label4.TabIndex = 27;
			this.Label4.Text = "Miejscowość";
			// 
			// txtNip
			// 
			this.txtNip.Location = new System.Drawing.Point(406, 36);
			this.txtNip.MaxLength = 10;
			this.txtNip.Name = "txtNip";
			this.txtNip.Size = new System.Drawing.Size(169, 20);
			this.txtNip.TabIndex = 3;
			this.txtNip.Validating += new System.ComponentModel.CancelEventHandler(this.txtNip_Validating);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(375, 39);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(25, 13);
			this.Label3.TabIndex = 24;
			this.Label3.Text = "NIP";
			// 
			// txtAlias
			// 
			this.txtAlias.Location = new System.Drawing.Point(77, 36);
			this.txtAlias.Name = "txtAlias";
			this.txtAlias.Size = new System.Drawing.Size(292, 20);
			this.txtAlias.TabIndex = 2;
			this.txtAlias.TextChanged += new System.EventHandler(this.txtNazwa_TextChanged);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(4, 39);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(29, 13);
			this.Label2.TabIndex = 21;
			this.Label2.Text = "Alias";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 13);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 13);
			this.label10.TabIndex = 20;
			this.label10.Text = "Nazwa";
			// 
			// txtNazwa
			// 
			this.txtNazwa.Location = new System.Drawing.Point(77, 10);
			this.txtNazwa.Name = "txtNazwa";
			this.txtNazwa.Size = new System.Drawing.Size(498, 20);
			this.txtNazwa.TabIndex = 1;
			this.txtNazwa.TextChanged += new System.EventHandler(this.txtNazwa_TextChanged);
			// 
			// dlgSchool
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(611, 231);
			this.Controls.Add(this.pnlSzkola);
			this.Controls.Add(this.cbTyp);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgSchool";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dodawanie nowej szkoły";
			this.pnlSzkola.ResumeLayout(false);
			this.pnlSzkola.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Panel pnlSzkola;
		internal System.Windows.Forms.TextBox txtEmail;
		internal System.Windows.Forms.TextBox txtFax;
		internal System.Windows.Forms.TextBox txtTel;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.TextBox txtNr;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox txtUlica;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.ComboBox cbMiejscowosc;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox txtNip;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox txtAlias;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.TextBox txtNazwa;
		internal System.Windows.Forms.ComboBox cbTyp;
		private System.Windows.Forms.Button cmdMiejscowosc;
		protected internal System.Windows.Forms.Button cmdOK;
	}
}