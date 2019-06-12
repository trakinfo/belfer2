namespace Belfer
{
	partial class dlgImportSchoolClass
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
			this.olvKlasa = new BrightIdeasSoftware.ObjectListView();
			this.Label6 = new System.Windows.Forms.Label();
			this.nudEndYear = new System.Windows.Forms.NumericUpDown();
			this.nudStartYear = new System.Windows.Forms.NumericUpDown();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtSeek = new System.Windows.Forms.TextBox();
			this.cbSeek = new System.Windows.Forms.ComboBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.lblRecord = new System.Windows.Forms.Label();
			this.cmdDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.olvKlasa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudEndYear)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudStartYear)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(538, 463);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 11;
			this.cmdCancel.Text = "Anuluj";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.Location = new System.Drawing.Point(457, 463);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 10;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// olvKlasa
			// 
			this.olvKlasa.CellEditUseWholeCell = false;
			this.olvKlasa.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvKlasa.Location = new System.Drawing.Point(12, 37);
			this.olvKlasa.Name = "olvKlasa";
			this.olvKlasa.Size = new System.Drawing.Size(601, 420);
			this.olvKlasa.TabIndex = 12;
			this.olvKlasa.UseCompatibleStateImageBehavior = false;
			this.olvKlasa.View = System.Windows.Forms.View.Details;
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Label6.Location = new System.Drawing.Point(144, 10);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(15, 24);
			this.Label6.TabIndex = 208;
			this.Label6.Text = "/";
			// 
			// nudEndYear
			// 
			this.nudEndYear.Enabled = false;
			this.nudEndYear.Location = new System.Drawing.Point(160, 12);
			this.nudEndYear.Maximum = new decimal(new int[] {
            2051,
            0,
            0,
            0});
			this.nudEndYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudEndYear.Name = "nudEndYear";
			this.nudEndYear.Size = new System.Drawing.Size(55, 20);
			this.nudEndYear.TabIndex = 207;
			this.nudEndYear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// nudStartYear
			// 
			this.nudStartYear.Location = new System.Drawing.Point(83, 12);
			this.nudStartYear.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
			this.nudStartYear.Name = "nudStartYear";
			this.nudStartYear.Size = new System.Drawing.Size(55, 20);
			this.nudStartYear.TabIndex = 206;
			this.nudStartYear.ValueChanged += new System.EventHandler(this.nudStartYear_ValueChanged);
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(12, 14);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(65, 13);
			this.Label5.TabIndex = 205;
			this.Label5.Text = "Rok szkolny";
			// 
			// txtSeek
			// 
			this.txtSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSeek.Location = new System.Drawing.Point(349, 11);
			this.txtSeek.Name = "txtSeek";
			this.txtSeek.Size = new System.Drawing.Size(264, 20);
			this.txtSeek.TabIndex = 152;
			this.txtSeek.TextChanged += new System.EventHandler(this.txtSeek_TextChanged);
			// 
			// cbSeek
			// 
			this.cbSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSeek.DropDownWidth = 200;
			this.cbSeek.FormattingEnabled = true;
			this.cbSeek.Location = new System.Drawing.Point(221, 11);
			this.cbSeek.Name = "cbSeek";
			this.cbSeek.Size = new System.Drawing.Size(122, 21);
			this.cbSeek.TabIndex = 151;
			this.cbSeek.SelectedIndexChanged += new System.EventHandler(this.cbSeek_SelectedIndexChanged);
			// 
			// Label11
			// 
			this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(12, 460);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(45, 13);
			this.Label11.TabIndex = 145;
			this.Label11.Text = "Rekord:";
			// 
			// lblRecord
			// 
			this.lblRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblRecord.AutoSize = true;
			this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblRecord.ForeColor = System.Drawing.Color.Red;
			this.lblRecord.Location = new System.Drawing.Point(63, 460);
			this.lblRecord.Name = "lblRecord";
			this.lblRecord.Size = new System.Drawing.Size(61, 13);
			this.lblRecord.TabIndex = 146;
			this.lblRecord.Text = "lblRecord";
			// 
			// cmdDelete
			// 
			this.cmdDelete.Location = new System.Drawing.Point(306, 463);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(75, 23);
			this.cmdDelete.TabIndex = 209;
			this.cmdDelete.Text = "Usuń";
			this.cmdDelete.UseVisualStyleBackColor = true;
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// dlgImportSchoolClass
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(628, 498);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.txtSeek);
			this.Controls.Add(this.cbSeek);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.nudEndYear);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this.lblRecord);
			this.Controls.Add(this.nudStartYear);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.olvKlasa);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Name = "dlgImportSchoolClass";
			this.Text = "Import oddziałów klasowych";
			((System.ComponentModel.ISupportInitialize)(this.olvKlasa)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudEndYear)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudStartYear)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmdCancel;
		protected internal System.Windows.Forms.Button cmdOK;
		public BrightIdeasSoftware.ObjectListView olvKlasa;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.NumericUpDown nudEndYear;
		internal System.Windows.Forms.NumericUpDown nudStartYear;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox txtSeek;
		internal System.Windows.Forms.ComboBox cbSeek;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label lblRecord;
		private System.Windows.Forms.Button cmdDelete;
	}
}