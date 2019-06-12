namespace Belfer
{
	partial class dlgSchoolClass
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
			this.cbKlasa = new System.Windows.Forms.ComboBox();
			this.chkVirtual = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNazwa = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(292, 99);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 13;
			this.cmdCancel.Text = "Anuluj";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(211, 99);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 12;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "Kod klasy";
			// 
			// cbKlasa
			// 
			this.cbKlasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbKlasa.Enabled = false;
			this.cbKlasa.FormattingEnabled = true;
			this.cbKlasa.Location = new System.Drawing.Point(85, 12);
			this.cbKlasa.Name = "cbKlasa";
			this.cbKlasa.Size = new System.Drawing.Size(174, 21);
			this.cbKlasa.TabIndex = 17;
			this.cbKlasa.SelectedIndexChanged += new System.EventHandler(this.cbKlasa_SelectedIndexChanged);
			// 
			// chkVirtual
			// 
			this.chkVirtual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkVirtual.AutoSize = true;
			this.chkVirtual.Location = new System.Drawing.Point(265, 14);
			this.chkVirtual.Name = "chkVirtual";
			this.chkVirtual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkVirtual.Size = new System.Drawing.Size(97, 17);
			this.chkVirtual.TabIndex = 26;
			this.chkVirtual.Text = "Klasa wirtualna";
			this.chkVirtual.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 27;
			this.label2.Text = "Nazwa klasy";
			// 
			// txtNazwa
			// 
			this.txtNazwa.Location = new System.Drawing.Point(85, 39);
			this.txtNazwa.MaxLength = 45;
			this.txtNazwa.Name = "txtNazwa";
			this.txtNazwa.Size = new System.Drawing.Size(277, 20);
			this.txtNazwa.TabIndex = 28;
			this.txtNazwa.TextChanged += new System.EventHandler(this.txtNazwa_TextChanged);
			// 
			// dlgSchoolClass
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(379, 134);
			this.Controls.Add(this.txtNazwa);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.chkVirtual);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbKlasa);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Name = "dlgSchoolClass";
			this.Text = "Dodaj oddział";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmdCancel;
		protected internal System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.ComboBox cbKlasa;
		public System.Windows.Forms.CheckBox chkVirtual;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtNazwa;
	}
}