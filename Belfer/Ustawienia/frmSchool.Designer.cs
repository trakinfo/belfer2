namespace Belfer
{
	partial class frmSchool
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
			this.cbSchoolType = new System.Windows.Forms.ComboBox();
			this.olvSzkola = new BrightIdeasSoftware.ObjectListView();
			this.cmdClose = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAddNew = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.pnlRecord = new System.Windows.Forms.Panel();
			this.Label11 = new System.Windows.Forms.Label();
			this.lblRecord = new System.Windows.Forms.Label();
			this.pnlSignature = new System.Windows.Forms.Panel();
			this.Label30 = new System.Windows.Forms.Label();
			this.Label31 = new System.Windows.Forms.Label();
			this.lblData = new System.Windows.Forms.Label();
			this.lblIP = new System.Windows.Forms.Label();
			this.lblUser = new System.Windows.Forms.Label();
			this.Label32 = new System.Windows.Forms.Label();
			this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
			this.Label13 = new System.Windows.Forms.Label();
			this.lblAlias = new System.Windows.Forms.Label();
			this.Label16 = new System.Windows.Forms.Label();
			this.Label22 = new System.Windows.Forms.Label();
			this.lblFax = new System.Windows.Forms.Label();
			this.lblTel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblAdres = new System.Windows.Forms.Label();
			this.Label21 = new System.Windows.Forms.Label();
			this.lblEmail = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.olvSzkola)).BeginInit();
			this.pnlRecord.SuspendLayout();
			this.pnlSignature.SuspendLayout();
			this.tlpDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Typ szkoły";
			// 
			// cbSchoolType
			// 
			this.cbSchoolType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.cbSchoolType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbSchoolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSchoolType.FormattingEnabled = true;
			this.cbSchoolType.Location = new System.Drawing.Point(77, 12);
			this.cbSchoolType.Name = "cbSchoolType";
			this.cbSchoolType.Size = new System.Drawing.Size(301, 21);
			this.cbSchoolType.TabIndex = 1;
			this.cbSchoolType.SelectedIndexChanged += new System.EventHandler(this.cbSchoolType_SelectedIndexChanged);
			// 
			// olvSzkola
			// 
			this.olvSzkola.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.olvSzkola.CellEditUseWholeCell = false;
			this.olvSzkola.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvSzkola.Location = new System.Drawing.Point(12, 39);
			this.olvSzkola.Name = "olvSzkola";
			this.olvSzkola.Size = new System.Drawing.Size(659, 232);
			this.olvSzkola.TabIndex = 2;
			this.olvSzkola.UseCompatibleStateImageBehavior = false;
			this.olvSzkola.View = System.Windows.Forms.View.Details;
			this.olvSzkola.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.olvSzkola_ItemSelectionChanged);
			this.olvSzkola.DoubleClick += new System.EventHandler(this.olvSzkola_DoubleClick);
			// 
			// cmdClose
			// 
			this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdClose.Image = global::Belfer.Properties.Resources.close_22;
			this.cmdClose.Location = new System.Drawing.Point(677, 236);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(85, 35);
			this.cmdClose.TabIndex = 207;
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
			this.cmdEdit.Location = new System.Drawing.Point(677, 81);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(85, 36);
			this.cmdEdit.TabIndex = 209;
			this.cmdEdit.Text = "Edytuj";
			this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdEdit.UseVisualStyleBackColor = true;
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAddNew
			// 
			this.cmdAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAddNew.Enabled = false;
			this.cmdAddNew.Image = global::Belfer.Properties.Resources.add_24;
			this.cmdAddNew.Location = new System.Drawing.Point(677, 39);
			this.cmdAddNew.Name = "cmdAddNew";
			this.cmdAddNew.Size = new System.Drawing.Size(85, 36);
			this.cmdAddNew.TabIndex = 210;
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
			this.cmdDelete.Location = new System.Drawing.Point(677, 123);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(85, 36);
			this.cmdDelete.TabIndex = 208;
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
			this.pnlRecord.Controls.Add(this.Label11);
			this.pnlRecord.Controls.Add(this.lblRecord);
			this.pnlRecord.Location = new System.Drawing.Point(12, 272);
			this.pnlRecord.Name = "pnlRecord";
			this.pnlRecord.Size = new System.Drawing.Size(750, 25);
			this.pnlRecord.TabIndex = 211;
			this.pnlRecord.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRecord_Paint);
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
			this.pnlSignature.Location = new System.Drawing.Point(12, 357);
			this.pnlSignature.Name = "pnlSignature";
			this.pnlSignature.Size = new System.Drawing.Size(758, 34);
			this.pnlSignature.TabIndex = 212;
			this.pnlSignature.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSignature_Paint);
			// 
			// Label30
			// 
			this.Label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label30.AutoSize = true;
			this.Label30.Enabled = false;
			this.Label30.Location = new System.Drawing.Point(539, 13);
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
			this.Label31.Location = new System.Drawing.Point(396, 13);
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
			this.lblData.Location = new System.Drawing.Point(630, 8);
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
			this.lblIP.Location = new System.Drawing.Point(433, 8);
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
			this.lblUser.Size = new System.Drawing.Size(307, 23);
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
			// tlpDetails
			// 
			this.tlpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpDetails.ColumnCount = 6;
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpDetails.Controls.Add(this.Label13, 0, 0);
			this.tlpDetails.Controls.Add(this.lblAlias, 1, 0);
			this.tlpDetails.Controls.Add(this.Label16, 0, 1);
			this.tlpDetails.Controls.Add(this.Label22, 2, 1);
			this.tlpDetails.Controls.Add(this.lblFax, 3, 1);
			this.tlpDetails.Controls.Add(this.lblTel, 1, 1);
			this.tlpDetails.Controls.Add(this.label2, 4, 0);
			this.tlpDetails.Controls.Add(this.lblAdres, 5, 0);
			this.tlpDetails.Controls.Add(this.Label21, 4, 1);
			this.tlpDetails.Controls.Add(this.lblEmail, 5, 1);
			this.tlpDetails.Location = new System.Drawing.Point(12, 301);
			this.tlpDetails.Name = "tlpDetails";
			this.tlpDetails.RowCount = 2;
			this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpDetails.Size = new System.Drawing.Size(750, 44);
			this.tlpDetails.TabIndex = 213;
			// 
			// Label13
			// 
			this.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.Label13.AutoSize = true;
			this.Label13.Location = new System.Drawing.Point(3, 4);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(29, 13);
			this.Label13.TabIndex = 71;
			this.Label13.Text = "Alias";
			// 
			// lblAlias
			// 
			this.lblAlias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAlias.AutoSize = true;
			this.tlpDetails.SetColumnSpan(this.lblAlias, 3);
			this.lblAlias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblAlias.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblAlias.Location = new System.Drawing.Point(52, 4);
			this.lblAlias.Name = "lblAlias";
			this.lblAlias.Size = new System.Drawing.Size(338, 13);
			this.lblAlias.TabIndex = 50;
			this.lblAlias.Text = "Alias";
			// 
			// Label16
			// 
			this.Label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.Label16.AutoSize = true;
			this.Label16.Location = new System.Drawing.Point(3, 26);
			this.Label16.Name = "Label16";
			this.Label16.Size = new System.Drawing.Size(43, 13);
			this.Label16.TabIndex = 74;
			this.Label16.Text = "Telefon";
			// 
			// Label22
			// 
			this.Label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.Label22.AutoSize = true;
			this.Label22.Location = new System.Drawing.Point(209, 26);
			this.Label22.Name = "Label22";
			this.Label22.Size = new System.Drawing.Size(24, 13);
			this.Label22.TabIndex = 84;
			this.Label22.Text = "Fax";
			// 
			// lblFax
			// 
			this.lblFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFax.AutoSize = true;
			this.lblFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblFax.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblFax.Location = new System.Drawing.Point(239, 26);
			this.lblFax.Name = "lblFax";
			this.lblFax.Size = new System.Drawing.Size(151, 13);
			this.lblFax.TabIndex = 55;
			this.lblFax.Text = "Fax";
			// 
			// lblTel
			// 
			this.lblTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTel.AutoSize = true;
			this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblTel.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblTel.Location = new System.Drawing.Point(52, 26);
			this.lblTel.Name = "lblTel";
			this.lblTel.Size = new System.Drawing.Size(151, 13);
			this.lblTel.TabIndex = 61;
			this.lblTel.Text = "tel";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(396, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 88;
			this.label2.Text = "Adres";
			// 
			// lblAdres
			// 
			this.lblAdres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAdres.AutoSize = true;
			this.lblAdres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblAdres.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblAdres.Location = new System.Drawing.Point(437, 4);
			this.lblAdres.Name = "lblAdres";
			this.lblAdres.Size = new System.Drawing.Size(310, 13);
			this.lblAdres.TabIndex = 89;
			this.lblAdres.Text = "Adres";
			// 
			// Label21
			// 
			this.Label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.Label21.AutoSize = true;
			this.Label21.Location = new System.Drawing.Point(396, 26);
			this.Label21.Name = "Label21";
			this.Label21.Size = new System.Drawing.Size(35, 13);
			this.Label21.TabIndex = 87;
			this.Label21.Text = "E-mail";
			// 
			// lblEmail
			// 
			this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEmail.AutoSize = true;
			this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblEmail.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblEmail.Location = new System.Drawing.Point(437, 26);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(310, 13);
			this.lblEmail.TabIndex = 56;
			this.lblEmail.Text = "email";
			// 
			// frmSchool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 399);
			this.Controls.Add(this.tlpDetails);
			this.Controls.Add(this.pnlSignature);
			this.Controls.Add(this.pnlRecord);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAddNew);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdClose);
			this.Controls.Add(this.olvSzkola);
			this.Controls.Add(this.cbSchoolType);
			this.Controls.Add(this.label1);
			this.MinimumSize = new System.Drawing.Size(790, 438);
			this.Name = "frmSchool";
			this.Text = "Szkoły";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSchool_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.olvSzkola)).EndInit();
			this.pnlRecord.ResumeLayout(false);
			this.pnlRecord.PerformLayout();
			this.pnlSignature.ResumeLayout(false);
			this.pnlSignature.PerformLayout();
			this.tlpDetails.ResumeLayout(false);
			this.tlpDetails.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbSchoolType;
		private BrightIdeasSoftware.ObjectListView olvSzkola;
		internal System.Windows.Forms.Button cmdClose;
		internal System.Windows.Forms.Button cmdEdit;
		internal System.Windows.Forms.Button cmdAddNew;
		internal System.Windows.Forms.Button cmdDelete;
		internal System.Windows.Forms.Panel pnlRecord;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label lblRecord;
		internal System.Windows.Forms.Panel pnlSignature;
		internal System.Windows.Forms.Label Label30;
		internal System.Windows.Forms.Label Label31;
		internal System.Windows.Forms.Label lblData;
		internal System.Windows.Forms.Label lblIP;
		internal System.Windows.Forms.Label lblUser;
		internal System.Windows.Forms.Label Label32;
		internal System.Windows.Forms.TableLayoutPanel tlpDetails;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.Label lblAlias;
		internal System.Windows.Forms.Label Label16;
		internal System.Windows.Forms.Label Label22;
		internal System.Windows.Forms.Label lblFax;
		internal System.Windows.Forms.Label Label21;
		internal System.Windows.Forms.Label lblEmail;
		internal System.Windows.Forms.Label lblTel;
		internal System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblAdres;
	}
}