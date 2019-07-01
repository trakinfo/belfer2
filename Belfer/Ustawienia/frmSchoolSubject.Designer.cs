namespace Belfer
{
	partial class frmSchoolSubject
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
            this.cmdAddNew = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.olvSubject = new BrightIdeasSoftware.ObjectListView();
            this.pnlRecord = new System.Windows.Forms.Panel();
            this.txtSeek = new System.Windows.Forms.TextBox();
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
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdUp = new System.Windows.Forms.Button();
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdEnd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.olvSubject)).BeginInit();
            this.pnlRecord.SuspendLayout();
            this.pnlSignature.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAddNew
            // 
            this.cmdAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddNew.Image = global::Belfer.Properties.Resources.AddTeacher_24T;
            this.cmdAddNew.Location = new System.Drawing.Point(466, 12);
            this.cmdAddNew.Name = "cmdAddNew";
            this.cmdAddNew.Size = new System.Drawing.Size(98, 36);
            this.cmdAddNew.TabIndex = 215;
            this.cmdAddNew.Text = "Dodaj";
            this.cmdAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdAddNew.UseVisualStyleBackColor = true;
            this.cmdAddNew.Click += new System.EventHandler(this.cmdAddNew_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Enabled = false;
            this.cmdEdit.Image = global::Belfer.Properties.Resources.EditTeacher_24T;
            this.cmdEdit.Location = new System.Drawing.Point(466, 54);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(98, 36);
            this.cmdEdit.TabIndex = 218;
            this.cmdEdit.Text = "Edytuj";
            this.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDelete.Enabled = false;
            this.cmdDelete.Image = global::Belfer.Properties.Resources.DelTeacher_24T;
            this.cmdDelete.Location = new System.Drawing.Point(466, 96);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(98, 36);
            this.cmdDelete.TabIndex = 217;
            this.cmdDelete.Text = "&Usuń";
            this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Image = global::Belfer.Properties.Resources.close_22;
            this.cmdClose.Location = new System.Drawing.Point(466, 406);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(98, 35);
            this.cmdClose.TabIndex = 216;
            this.cmdClose.Text = "&Zamknij";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // olvSubject
            // 
            this.olvSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvSubject.CellEditUseWholeCell = false;
            this.olvSubject.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvSubject.Location = new System.Drawing.Point(12, 12);
            this.olvSubject.Name = "olvSubject";
            this.olvSubject.Size = new System.Drawing.Size(448, 429);
            this.olvSubject.TabIndex = 219;
            this.olvSubject.UseCompatibleStateImageBehavior = false;
            this.olvSubject.View = System.Windows.Forms.View.Details;
            this.olvSubject.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.olvTeacher_ItemChecked);
            this.olvSubject.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.olvSzkola_ItemSelectionChanged);
            this.olvSubject.DoubleClick += new System.EventHandler(this.olvTeacher_DoubleClick);
            // 
            // pnlRecord
            // 
            this.pnlRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRecord.Controls.Add(this.txtSeek);
            this.pnlRecord.Controls.Add(this.Label1);
            this.pnlRecord.Controls.Add(this.Label11);
            this.pnlRecord.Controls.Add(this.lblRecord);
            this.pnlRecord.Location = new System.Drawing.Point(12, 444);
            this.pnlRecord.Name = "pnlRecord";
            this.pnlRecord.Size = new System.Drawing.Size(552, 25);
            this.pnlRecord.TabIndex = 220;
            // 
            // txtSeek
            // 
            this.txtSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeek.Location = new System.Drawing.Point(310, 3);
            this.txtSeek.Name = "txtSeek";
            this.txtSeek.Size = new System.Drawing.Size(150, 20);
            this.txtSeek.TabIndex = 152;
            this.txtSeek.TextChanged += new System.EventHandler(this.txtSeek_TextChanged);
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(273, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(31, 13);
            this.Label1.TabIndex = 150;
            this.Label1.Text = "Filtruj";
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
            this.pnlSignature.Location = new System.Drawing.Point(12, 477);
            this.pnlSignature.Name = "pnlSignature";
            this.pnlSignature.Size = new System.Drawing.Size(552, 34);
            this.pnlSignature.TabIndex = 221;
            // 
            // Label30
            // 
            this.Label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label30.AutoSize = true;
            this.Label30.Enabled = false;
            this.Label30.Location = new System.Drawing.Point(333, 13);
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
            this.Label31.Location = new System.Drawing.Point(190, 13);
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
            this.lblData.Location = new System.Drawing.Point(424, 8);
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
            this.lblIP.Location = new System.Drawing.Point(227, 8);
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
            this.lblUser.Size = new System.Drawing.Size(101, 23);
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
            // cmdStart
            // 
            this.cmdStart.Image = global::Belfer.Properties.Resources.Top16;
            this.cmdStart.Location = new System.Drawing.Point(466, 250);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(98, 23);
            this.cmdStart.TabIndex = 222;
            this.cmdStart.Text = "Na początek";
            this.cmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStart.UseVisualStyleBackColor = true;
            // 
            // cmdUp
            // 
            this.cmdUp.Image = global::Belfer.Properties.Resources.UpDown16;
            this.cmdUp.Location = new System.Drawing.Point(466, 279);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(98, 23);
            this.cmdUp.TabIndex = 223;
            this.cmdUp.Text = "W górę";
            this.cmdUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUp.UseVisualStyleBackColor = true;
            // 
            // cmdDown
            // 
            this.cmdDown.Image = global::Belfer.Properties.Resources.UpDown16a;
            this.cmdDown.Location = new System.Drawing.Point(466, 308);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(98, 23);
            this.cmdDown.TabIndex = 224;
            this.cmdDown.Text = "W dół";
            this.cmdDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDown.UseVisualStyleBackColor = true;
            // 
            // cmdEnd
            // 
            this.cmdEnd.Image = global::Belfer.Properties.Resources.Down16;
            this.cmdEnd.Location = new System.Drawing.Point(466, 337);
            this.cmdEnd.Name = "cmdEnd";
            this.cmdEnd.Size = new System.Drawing.Size(98, 23);
            this.cmdEnd.TabIndex = 225;
            this.cmdEnd.Text = "Na koniec";
            this.cmdEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdEnd.UseVisualStyleBackColor = true;
            // 
            // frmSchoolSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 523);
            this.Controls.Add(this.cmdEnd);
            this.Controls.Add(this.cmdDown);
            this.Controls.Add(this.cmdUp);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.pnlSignature);
            this.Controls.Add(this.pnlRecord);
            this.Controls.Add(this.olvSubject);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdAddNew);
            this.Name = "frmSchoolSubject";
            this.Text = "Przedmioty szkolne";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSchool_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.olvSubject)).EndInit();
            this.pnlRecord.ResumeLayout(false);
            this.pnlRecord.PerformLayout();
            this.pnlSignature.ResumeLayout(false);
            this.pnlSignature.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.Button cmdAddNew;
		internal System.Windows.Forms.Button cmdEdit;
		internal System.Windows.Forms.Button cmdDelete;
		internal System.Windows.Forms.Button cmdClose;
		private BrightIdeasSoftware.ObjectListView olvSubject;
		internal System.Windows.Forms.Panel pnlRecord;
		internal System.Windows.Forms.TextBox txtSeek;
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
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdUp;
        private System.Windows.Forms.Button cmdDown;
        private System.Windows.Forms.Button cmdEnd;
    }
}