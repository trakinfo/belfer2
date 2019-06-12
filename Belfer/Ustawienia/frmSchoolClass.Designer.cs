namespace Belfer
{
	partial class frmSchoolClass
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
			this.olvKlasa = new BrightIdeasSoftware.ObjectListView();
			this.cmdImport = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAddNew = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.pnlRecord = new System.Windows.Forms.Panel();
			this.txtSeek = new System.Windows.Forms.TextBox();
			this.cbSeek = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.lblRecord = new System.Windows.Forms.Label();
			this.pnlSignature = new System.Windows.Forms.Panel();
			this.Label30 = new System.Windows.Forms.Label();
			this.Label31 = new System.Windows.Forms.Label();
			this.lblData = new System.Windows.Forms.Label();
			this.lblIP = new System.Windows.Forms.Label();
			this.lblUser = new System.Windows.Forms.Label();
			this.Label32 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.olvKlasa)).BeginInit();
			this.pnlRecord.SuspendLayout();
			this.pnlSignature.SuspendLayout();
			this.SuspendLayout();
			// 
			// olvKlasa
			// 
			this.olvKlasa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.olvKlasa.CellEditUseWholeCell = false;
			this.olvKlasa.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvKlasa.Location = new System.Drawing.Point(12, 12);
			this.olvKlasa.Name = "olvKlasa";
			this.olvKlasa.Size = new System.Drawing.Size(601, 349);
			this.olvKlasa.TabIndex = 2;
			this.olvKlasa.UseCompatibleStateImageBehavior = false;
			this.olvKlasa.View = System.Windows.Forms.View.Details;
			this.olvKlasa.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.olvKlasa_ItemChecked);
			this.olvKlasa.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.olvSzkola_ItemSelectionChanged);
			this.olvKlasa.DoubleClick += new System.EventHandler(this.olvObsada_DoubleClick);
			// 
			// cmdImport
			// 
			this.cmdImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdImport.Image = global::Belfer.Properties.Resources.Import_24T;
			this.cmdImport.Location = new System.Drawing.Point(619, 172);
			this.cmdImport.Name = "cmdImport";
			this.cmdImport.Size = new System.Drawing.Size(86, 36);
			this.cmdImport.TabIndex = 232;
			this.cmdImport.Text = "Importuj";
			this.cmdImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdImport.UseVisualStyleBackColor = true;
			this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
			// 
			// cmdPrint
			// 
			this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdPrint.Image = global::Belfer.Properties.Resources.print_24;
			this.cmdPrint.Location = new System.Drawing.Point(619, 214);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.Size = new System.Drawing.Size(86, 36);
			this.cmdPrint.TabIndex = 231;
			this.cmdPrint.Text = "Drukuj";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdPrint.UseVisualStyleBackColor = true;
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			// 
			// cmdClose
			// 
			this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdClose.Image = global::Belfer.Properties.Resources.close_22;
			this.cmdClose.Location = new System.Drawing.Point(619, 326);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(86, 35);
			this.cmdClose.TabIndex = 230;
			this.cmdClose.Text = "&Zamknij";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdClose.UseVisualStyleBackColor = true;
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdEdit.Enabled = false;
			this.cmdEdit.Image = global::Belfer.Properties.Resources.edit;
			this.cmdEdit.Location = new System.Drawing.Point(619, 54);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(86, 36);
			this.cmdEdit.TabIndex = 228;
			this.cmdEdit.Text = "Edytuj";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdEdit.UseVisualStyleBackColor = true;
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAddNew
			// 
			this.cmdAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAddNew.Image = global::Belfer.Properties.Resources.add_24;
			this.cmdAddNew.Location = new System.Drawing.Point(619, 12);
			this.cmdAddNew.Name = "cmdAddNew";
			this.cmdAddNew.Size = new System.Drawing.Size(86, 36);
			this.cmdAddNew.TabIndex = 229;
			this.cmdAddNew.Text = "Dodaj";
			this.cmdAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdAddNew.UseVisualStyleBackColor = true;
			this.cmdAddNew.Click += new System.EventHandler(this.cmdAddNew_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdDelete.Enabled = false;
			this.cmdDelete.Image = global::Belfer.Properties.Resources.del_24;
			this.cmdDelete.Location = new System.Drawing.Point(619, 96);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(86, 36);
			this.cmdDelete.TabIndex = 227;
			this.cmdDelete.Text = "&Usuń";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdDelete.UseVisualStyleBackColor = true;
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// pnlRecord
			// 
			this.pnlRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlRecord.Controls.Add(this.txtSeek);
			this.pnlRecord.Controls.Add(this.cbSeek);
			this.pnlRecord.Controls.Add(this.Label1);
			this.pnlRecord.Controls.Add(this.Label11);
			this.pnlRecord.Controls.Add(this.lblRecord);
			this.pnlRecord.Location = new System.Drawing.Point(12, 363);
			this.pnlRecord.Name = "pnlRecord";
			this.pnlRecord.Size = new System.Drawing.Size(601, 25);
			this.pnlRecord.TabIndex = 233;
			// 
			// txtSeek
			// 
			this.txtSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSeek.Location = new System.Drawing.Point(443, 3);
			this.txtSeek.Name = "txtSeek";
			this.txtSeek.Size = new System.Drawing.Size(155, 20);
			this.txtSeek.TabIndex = 152;
			this.txtSeek.TextChanged += new System.EventHandler(this.txtSeek_TextChanged);
			// 
			// cbSeek
			// 
			this.cbSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSeek.DropDownWidth = 200;
			this.cbSeek.FormattingEnabled = true;
			this.cbSeek.Location = new System.Drawing.Point(315, 3);
			this.cbSeek.Name = "cbSeek";
			this.cbSeek.Size = new System.Drawing.Size(122, 21);
			this.cbSeek.TabIndex = 151;
			this.cbSeek.SelectedIndexChanged += new System.EventHandler(this.cbSeek_SelectedIndexChanged);
			// 
			// Label1
			// 
			this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(261, 6);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(48, 13);
			this.Label1.TabIndex = 150;
			this.Label1.Text = "Filtruj wg";
			// 
			// Label11
			// 
			this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(3, 6);
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
			this.lblRecord.Location = new System.Drawing.Point(54, 6);
			this.lblRecord.Name = "lblRecord";
			this.lblRecord.Size = new System.Drawing.Size(61, 13);
			this.lblRecord.TabIndex = 146;
			this.lblRecord.Text = "lblRecord";
			// 
			// pnlSignature
			// 
			this.pnlSignature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSignature.BackColor = System.Drawing.SystemColors.Control;
			this.pnlSignature.Controls.Add(this.Label30);
			this.pnlSignature.Controls.Add(this.Label31);
			this.pnlSignature.Controls.Add(this.lblData);
			this.pnlSignature.Controls.Add(this.lblIP);
			this.pnlSignature.Controls.Add(this.lblUser);
			this.pnlSignature.Controls.Add(this.Label32);
			this.pnlSignature.Location = new System.Drawing.Point(12, 394);
			this.pnlSignature.Name = "pnlSignature";
			this.pnlSignature.Size = new System.Drawing.Size(693, 34);
			this.pnlSignature.TabIndex = 234;
			// 
			// Label30
			// 
			this.Label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label30.AutoSize = true;
			this.Label30.Enabled = false;
			this.Label30.Location = new System.Drawing.Point(474, 13);
			this.Label30.Name = "Label30";
			this.Label30.Size = new System.Drawing.Size(85, 13);
			this.Label30.TabIndex = 54;
			this.Label30.Text = "Data modyfikacji";
			// 
			// Label31
			// 
			this.Label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label31.AutoSize = true;
			this.Label31.Enabled = false;
			this.Label31.Location = new System.Drawing.Point(331, 13);
			this.Label31.Name = "Label31";
			this.Label31.Size = new System.Drawing.Size(31, 13);
			this.Label31.TabIndex = 53;
			this.Label31.Text = "Nr IP";
			// 
			// lblData
			// 
			this.lblData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblData.Enabled = false;
			this.lblData.Location = new System.Drawing.Point(565, 8);
			this.lblData.Name = "lblData";
			this.lblData.Size = new System.Drawing.Size(120, 23);
			this.lblData.TabIndex = 52;
			this.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblIP
			// 
			this.lblIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblIP.Enabled = false;
			this.lblIP.Location = new System.Drawing.Point(368, 8);
			this.lblIP.Name = "lblIP";
			this.lblIP.Size = new System.Drawing.Size(100, 23);
			this.lblIP.TabIndex = 50;
			this.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUser
			// 
			this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblUser.Enabled = false;
			this.lblUser.Location = new System.Drawing.Point(83, 8);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(242, 23);
			this.lblUser.TabIndex = 51;
			this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Label32
			// 
			this.Label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Label32.AutoSize = true;
			this.Label32.Enabled = false;
			this.Label32.Location = new System.Drawing.Point(3, 13);
			this.Label32.Name = "Label32";
			this.Label32.Size = new System.Drawing.Size(74, 13);
			this.Label32.TabIndex = 49;
			this.Label32.Text = "Zmodyfikował";
			// 
			// frmSchoolClass
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(717, 431);
			this.Controls.Add(this.pnlSignature);
			this.Controls.Add(this.pnlRecord);
			this.Controls.Add(this.cmdImport);
			this.Controls.Add(this.cmdPrint);
			this.Controls.Add(this.cmdClose);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAddNew);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.olvKlasa);
			this.Name = "frmSchoolClass";
			this.Text = "Oddziały klasowe w szkole";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmObsada_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.olvKlasa)).EndInit();
			this.pnlRecord.ResumeLayout(false);
			this.pnlRecord.PerformLayout();
			this.pnlSignature.ResumeLayout(false);
			this.pnlSignature.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public BrightIdeasSoftware.ObjectListView olvKlasa;
		internal System.Windows.Forms.Button cmdImport;
		internal System.Windows.Forms.Button cmdPrint;
		internal System.Windows.Forms.Button cmdClose;
		internal System.Windows.Forms.Button cmdEdit;
		internal System.Windows.Forms.Button cmdAddNew;
		internal System.Windows.Forms.Button cmdDelete;
		internal System.Windows.Forms.Panel pnlRecord;
		internal System.Windows.Forms.TextBox txtSeek;
		internal System.Windows.Forms.ComboBox cbSeek;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label lblRecord;
		internal System.Windows.Forms.Panel pnlSignature;
		internal System.Windows.Forms.Label Label30;
		internal System.Windows.Forms.Label Label31;
		internal System.Windows.Forms.Label lblData;
		internal System.Windows.Forms.Label lblIP;
		internal System.Windows.Forms.Label lblUser;
		internal System.Windows.Forms.Label Label32;
	}
}