namespace Belfer
{
	partial class dlgPrivilegeEdition
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.lblPrzedmiot = new System.Windows.Forms.Label();
			this.txtKlasa = new System.Windows.Forms.TextBox();
			this.txtPrzedmiot = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dtStartDate = new System.Windows.Forms.DateTimePicker();
			this.dtEndDate = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cbTyp = new System.Windows.Forms.ComboBox();
			this.cbStatus = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(84, 3);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 15;
			this.cmdCancel.Text = "Anuluj";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// cmdOK
			// 
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(3, 3);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 14;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.cmdOK, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cmdCancel, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(354, 123);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(162, 29);
			this.tableLayoutPanel1.TabIndex = 16;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(70, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "Klasa";
			// 
			// lblPrzedmiot
			// 
			this.lblPrzedmiot.AutoSize = true;
			this.lblPrzedmiot.Location = new System.Drawing.Point(307, 15);
			this.lblPrzedmiot.Name = "lblPrzedmiot";
			this.lblPrzedmiot.Size = new System.Drawing.Size(53, 13);
			this.lblPrzedmiot.TabIndex = 18;
			this.lblPrzedmiot.Text = "Przedmiot";
			this.lblPrzedmiot.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtKlasa
			// 
			this.txtKlasa.Enabled = false;
			this.txtKlasa.Location = new System.Drawing.Point(109, 12);
			this.txtKlasa.Name = "txtKlasa";
			this.txtKlasa.Size = new System.Drawing.Size(148, 20);
			this.txtKlasa.TabIndex = 19;
			// 
			// txtPrzedmiot
			// 
			this.txtPrzedmiot.Enabled = false;
			this.txtPrzedmiot.Location = new System.Drawing.Point(368, 12);
			this.txtPrzedmiot.Name = "txtPrzedmiot";
			this.txtPrzedmiot.Size = new System.Drawing.Size(148, 20);
			this.txtPrzedmiot.TabIndex = 20;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Data początkowa";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(285, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 13);
			this.label4.TabIndex = 22;
			this.label4.Text = "Data końcowa";
			// 
			// dtStartDate
			// 
			this.dtStartDate.Location = new System.Drawing.Point(109, 38);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new System.Drawing.Size(148, 20);
			this.dtStartDate.TabIndex = 23;
			this.dtStartDate.Value = new System.DateTime(2017, 11, 24, 18, 22, 0, 0);
			// 
			// dtEndDate
			// 
			this.dtEndDate.Location = new System.Drawing.Point(368, 38);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new System.Drawing.Size(148, 20);
			this.dtEndDate.TabIndex = 24;
			this.dtEndDate.Value = new System.DateTime(2017, 10, 24, 18, 22, 0, 0);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "Typ uprawnienia";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(265, 67);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(97, 13);
			this.label6.TabIndex = 26;
			this.label6.Text = "Status uprawnienia";
			// 
			// cbTyp
			// 
			this.cbTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTyp.FormattingEnabled = true;
			this.cbTyp.Location = new System.Drawing.Point(109, 64);
			this.cbTyp.Name = "cbTyp";
			this.cbTyp.Size = new System.Drawing.Size(148, 21);
			this.cbTyp.TabIndex = 27;
			// 
			// cbStatus
			// 
			this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStatus.FormattingEnabled = true;
			this.cbStatus.Location = new System.Drawing.Point(368, 64);
			this.cbStatus.Name = "cbStatus";
			this.cbStatus.Size = new System.Drawing.Size(148, 21);
			this.cbStatus.TabIndex = 28;
			// 
			// dlgPrivilegeEdition
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(528, 164);
			this.Controls.Add(this.cbStatus);
			this.Controls.Add(this.cbTyp);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dtEndDate);
			this.Controls.Add(this.dtStartDate);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtPrzedmiot);
			this.Controls.Add(this.txtKlasa);
			this.Controls.Add(this.lblPrzedmiot);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgPrivilegeEdition";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edycja uprawnienia";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.TextBox txtKlasa;
		internal System.Windows.Forms.TextBox txtPrzedmiot;
		internal System.Windows.Forms.ComboBox cbStatus;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Button cmdOK;
		internal System.Windows.Forms.DateTimePicker dtStartDate;
		internal System.Windows.Forms.DateTimePicker dtEndDate;
		internal System.Windows.Forms.ComboBox cbTyp;
		internal System.Windows.Forms.Label lblPrzedmiot;
	}
}