namespace Belfer
{
	partial class dlgObsada
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
			this.chkKategoria = new System.Windows.Forms.CheckBox();
			this.cbKlasa = new System.Windows.Forms.ComboBox();
			this.cbPrzedmiot = new System.Windows.Forms.ComboBox();
			this.chkAvg = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.chkGrupa = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dtStartDate = new System.Windows.Forms.DateTimePicker();
			this.dtEndDate = new System.Windows.Forms.DateTimePicker();
			this.nudLiczbaGodzin = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.chkPion = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nudLiczbaGodzin)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(418, 175);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 11;
			this.cmdCancel.Text = "Anuluj";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(337, 175);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 10;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// chkKategoria
			// 
			this.chkKategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkKategoria.AutoSize = true;
			this.chkKategoria.Location = new System.Drawing.Point(401, 41);
			this.chkKategoria.Name = "chkKategoria";
			this.chkKategoria.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkKategoria.Size = new System.Drawing.Size(92, 17);
			this.chkKategoria.TabIndex = 12;
			this.chkKategoria.Text = "Obowiązkowy";
			this.chkKategoria.UseVisualStyleBackColor = true;
			// 
			// cbKlasa
			// 
			this.cbKlasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbKlasa.Enabled = false;
			this.cbKlasa.FormattingEnabled = true;
			this.cbKlasa.Location = new System.Drawing.Point(71, 12);
			this.cbKlasa.Name = "cbKlasa";
			this.cbKlasa.Size = new System.Drawing.Size(311, 21);
			this.cbKlasa.TabIndex = 13;
			// 
			// cbPrzedmiot
			// 
			this.cbPrzedmiot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPrzedmiot.Enabled = false;
			this.cbPrzedmiot.FormattingEnabled = true;
			this.cbPrzedmiot.Location = new System.Drawing.Point(71, 39);
			this.cbPrzedmiot.Name = "cbPrzedmiot";
			this.cbPrzedmiot.Size = new System.Drawing.Size(311, 21);
			this.cbPrzedmiot.TabIndex = 14;
			this.cbPrzedmiot.SelectedIndexChanged += new System.EventHandler(this.cbPrzedmiot_SelectedIndexChanged);
			// 
			// chkAvg
			// 
			this.chkAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkAvg.AutoSize = true;
			this.chkAvg.Location = new System.Drawing.Point(290, 90);
			this.chkAvg.Name = "chkAvg";
			this.chkAvg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkAvg.Size = new System.Drawing.Size(203, 17);
			this.chkAvg.TabIndex = 15;
			this.chkAvg.Text = "Uwzględnij przy liczeniu średniej ocen";
			this.chkAvg.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Klasa";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "Przedmiot";
			// 
			// chkGrupa
			// 
			this.chkGrupa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkGrupa.AutoSize = true;
			this.chkGrupa.Location = new System.Drawing.Point(387, 67);
			this.chkGrupa.Name = "chkGrupa";
			this.chkGrupa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkGrupa.Size = new System.Drawing.Size(106, 17);
			this.chkGrupa.TabIndex = 18;
			this.chkGrupa.Text = "Podział na grupy";
			this.chkGrupa.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(251, 131);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "Data deaktywacji";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 131);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 13);
			this.label4.TabIndex = 20;
			this.label4.Text = "Data aktywacji";
			// 
			// dtStartDate
			// 
			this.dtStartDate.Location = new System.Drawing.Point(95, 127);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new System.Drawing.Size(150, 20);
			this.dtStartDate.TabIndex = 21;
			// 
			// dtEndDate
			// 
			this.dtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtEndDate.Location = new System.Drawing.Point(343, 127);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new System.Drawing.Size(150, 20);
			this.dtEndDate.TabIndex = 22;
			this.dtEndDate.Value = new System.DateTime(2017, 10, 2, 11, 35, 0, 0);
			// 
			// nudLiczbaGodzin
			// 
			this.nudLiczbaGodzin.DecimalPlaces = 1;
			this.nudLiczbaGodzin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.nudLiczbaGodzin.Location = new System.Drawing.Point(200, 66);
			this.nudLiczbaGodzin.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.nudLiczbaGodzin.Name = "nudLiczbaGodzin";
			this.nudLiczbaGodzin.Size = new System.Drawing.Size(86, 20);
			this.nudLiczbaGodzin.TabIndex = 23;
			this.nudLiczbaGodzin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(182, 13);
			this.label5.TabIndex = 24;
			this.label5.Text = "Tygodniowa liczba godzin lekcyjnych";
			// 
			// chkPion
			// 
			this.chkPion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkPion.AutoSize = true;
			this.chkPion.Location = new System.Drawing.Point(422, 14);
			this.chkPion.Name = "chkPion";
			this.chkPion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.chkPion.Size = new System.Drawing.Size(71, 17);
			this.chkPion.TabIndex = 25;
			this.chkPion.Text = "Cały pion";
			this.chkPion.UseVisualStyleBackColor = true;
			// 
			// dlgObsada
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 210);
			this.Controls.Add(this.chkPion);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.nudLiczbaGodzin);
			this.Controls.Add(this.dtEndDate);
			this.Controls.Add(this.dtStartDate);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkGrupa);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chkAvg);
			this.Controls.Add(this.cbPrzedmiot);
			this.Controls.Add(this.cbKlasa);
			this.Controls.Add(this.chkKategoria);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Name = "dlgObsada";
			this.Text = "Dodaj przedmiot";
			((System.ComponentModel.ISupportInitialize)(this.nudLiczbaGodzin)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmdCancel;
		protected internal System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.CheckBox chkKategoria;
		public System.Windows.Forms.ComboBox cbKlasa;
		public System.Windows.Forms.ComboBox cbPrzedmiot;
		public System.Windows.Forms.CheckBox chkAvg;
		public System.Windows.Forms.CheckBox chkGrupa;
		public System.Windows.Forms.DateTimePicker dtStartDate;
		public System.Windows.Forms.DateTimePicker dtEndDate;
		public System.Windows.Forms.NumericUpDown nudLiczbaGodzin;
		public System.Windows.Forms.CheckBox chkPion;
	}
}