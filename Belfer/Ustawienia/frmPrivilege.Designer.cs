namespace Belfer
{
	partial class frmPrivilege
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
			this.olvUser = new BrightIdeasSoftware.ObjectListView();
			this.pnlSignature = new System.Windows.Forms.Panel();
			this.Label30 = new System.Windows.Forms.Label();
			this.Label31 = new System.Windows.Forms.Label();
			this.lblData = new System.Windows.Forms.Label();
			this.lblIP = new System.Windows.Forms.Label();
			this.lblUser = new System.Windows.Forms.Label();
			this.Label32 = new System.Windows.Forms.Label();
			this.olvPrivilege = new BrightIdeasSoftware.ObjectListView();
			this.cmdClose = new System.Windows.Forms.Button();
			this.olvExclusion = new BrightIdeasSoftware.ObjectListView();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAddNew = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdExclude = new System.Windows.Forms.Button();
			this.tcPrivilege = new System.Windows.Forms.TabControl();
			this.tpPrzywilej = new System.Windows.Forms.TabPage();
			this.tpWykluczenie = new System.Windows.Forms.TabPage();
			this.txtSeek = new System.Windows.Forms.TextBox();
			this.cbSeek = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.Label11 = new System.Windows.Forms.Label();
			this.lblRecord = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.olvUser)).BeginInit();
			this.pnlSignature.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.olvPrivilege)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.olvExclusion)).BeginInit();
			this.tcPrivilege.SuspendLayout();
			this.tpPrzywilej.SuspendLayout();
			this.tpWykluczenie.SuspendLayout();
			this.SuspendLayout();
			// 
			// olvUser
			// 
			this.olvUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.olvUser.CellEditUseWholeCell = false;
			this.olvUser.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvUser.Location = new System.Drawing.Point(12, 9);
			this.olvUser.MultiSelect = false;
			this.olvUser.Name = "olvUser";
			this.olvUser.Size = new System.Drawing.Size(241, 467);
			this.olvUser.TabIndex = 1;
			this.olvUser.Tag = "0";
			this.olvUser.UseCompatibleStateImageBehavior = false;
			this.olvUser.View = System.Windows.Forms.View.Details;
			this.olvUser.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.olvUser_ItemSelectionChanged);
			this.olvUser.Enter += new System.EventHandler(this.olvUser_Enter);
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
			this.pnlSignature.Size = new System.Drawing.Size(960, 34);
			this.pnlSignature.TabIndex = 217;
			// 
			// Label30
			// 
			this.Label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label30.AutoSize = true;
			this.Label30.Enabled = false;
			this.Label30.Location = new System.Drawing.Point(741, 13);
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
			this.Label31.Location = new System.Drawing.Point(598, 13);
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
			this.lblData.Location = new System.Drawing.Point(832, 8);
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
			this.lblIP.Location = new System.Drawing.Point(635, 8);
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
			this.lblUser.Size = new System.Drawing.Size(509, 23);
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
			// olvPrivilege
			// 
			this.olvPrivilege.CellEditUseWholeCell = false;
			this.olvPrivilege.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvPrivilege.Dock = System.Windows.Forms.DockStyle.Fill;
			this.olvPrivilege.Location = new System.Drawing.Point(3, 3);
			this.olvPrivilege.Name = "olvPrivilege";
			this.olvPrivilege.Size = new System.Drawing.Size(607, 415);
			this.olvPrivilege.TabIndex = 218;
			this.olvPrivilege.Tag = "1";
			this.olvPrivilege.UseCompatibleStateImageBehavior = false;
			this.olvPrivilege.View = System.Windows.Forms.View.Details;
			this.olvPrivilege.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.olvPrivilege_ItemSelectionChanged);
			this.olvPrivilege.DoubleClick += new System.EventHandler(this.olvPrivilege_DoubleClick);
			// 
			// cmdClose
			// 
			this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdClose.Image = global::Belfer.Properties.Resources.close_22;
			this.cmdClose.Location = new System.Drawing.Point(886, 417);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(86, 35);
			this.cmdClose.TabIndex = 219;
			this.cmdClose.Text = "&Zamknij";
			this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdClose.UseVisualStyleBackColor = true;
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// olvExclusion
			// 
			this.olvExclusion.CellEditUseWholeCell = false;
			this.olvExclusion.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvExclusion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.olvExclusion.Location = new System.Drawing.Point(3, 3);
			this.olvExclusion.Name = "olvExclusion";
			this.olvExclusion.Size = new System.Drawing.Size(607, 415);
			this.olvExclusion.TabIndex = 220;
			this.olvExclusion.Tag = "2";
			this.olvExclusion.UseCompatibleStateImageBehavior = false;
			this.olvExclusion.View = System.Windows.Forms.View.Details;
			this.olvExclusion.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.olvExclusion_ItemSelectionChanged);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdEdit.Enabled = false;
			this.cmdEdit.Image = global::Belfer.Properties.Resources.edit;
			this.cmdEdit.Location = new System.Drawing.Point(887, 120);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(85, 36);
			this.cmdEdit.TabIndex = 227;
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
			this.cmdAddNew.Location = new System.Drawing.Point(887, 36);
			this.cmdAddNew.Name = "cmdAddNew";
			this.cmdAddNew.Size = new System.Drawing.Size(85, 36);
			this.cmdAddNew.TabIndex = 228;
			this.cmdAddNew.Text = "Dodaj upraw.";
			this.cmdAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdAddNew.UseVisualStyleBackColor = true;
			this.cmdAddNew.Click += new System.EventHandler(this.cmdAddNew_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdDelete.Enabled = false;
			this.cmdDelete.Image = global::Belfer.Properties.Resources.del_24;
			this.cmdDelete.Location = new System.Drawing.Point(887, 162);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(85, 36);
			this.cmdDelete.TabIndex = 226;
			this.cmdDelete.Text = "&Usuń";
			this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdDelete.UseVisualStyleBackColor = true;
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdExclude
			// 
			this.cmdExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdExclude.Enabled = false;
			this.cmdExclude.Image = global::Belfer.Properties.Resources.users_delete_24T;
			this.cmdExclude.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.cmdExclude.Location = new System.Drawing.Point(887, 78);
			this.cmdExclude.Name = "cmdExclude";
			this.cmdExclude.Size = new System.Drawing.Size(85, 36);
			this.cmdExclude.TabIndex = 230;
			this.cmdExclude.Text = "Dodaj wyklucz.";
			this.cmdExclude.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdExclude.UseVisualStyleBackColor = true;
			this.cmdExclude.Click += new System.EventHandler(this.cmdExclude_Click);
			// 
			// tcPrivilege
			// 
			this.tcPrivilege.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tcPrivilege.Controls.Add(this.tpPrzywilej);
			this.tcPrivilege.Controls.Add(this.tpWykluczenie);
			this.tcPrivilege.Location = new System.Drawing.Point(259, 9);
			this.tcPrivilege.Name = "tcPrivilege";
			this.tcPrivilege.SelectedIndex = 0;
			this.tcPrivilege.Size = new System.Drawing.Size(621, 447);
			this.tcPrivilege.TabIndex = 234;
			this.tcPrivilege.SelectedIndexChanged += new System.EventHandler(this.tcPrivilege_SelectedIndexChanged);
			// 
			// tpPrzywilej
			// 
			this.tpPrzywilej.Controls.Add(this.olvPrivilege);
			this.tpPrzywilej.Location = new System.Drawing.Point(4, 22);
			this.tpPrzywilej.Name = "tpPrzywilej";
			this.tpPrzywilej.Padding = new System.Windows.Forms.Padding(3);
			this.tpPrzywilej.Size = new System.Drawing.Size(613, 421);
			this.tpPrzywilej.TabIndex = 0;
			this.tpPrzywilej.Text = "Uprawnienia";
			this.tpPrzywilej.UseVisualStyleBackColor = true;
			// 
			// tpWykluczenie
			// 
			this.tpWykluczenie.Controls.Add(this.olvExclusion);
			this.tpWykluczenie.Location = new System.Drawing.Point(4, 22);
			this.tpWykluczenie.Name = "tpWykluczenie";
			this.tpWykluczenie.Padding = new System.Windows.Forms.Padding(3);
			this.tpWykluczenie.Size = new System.Drawing.Size(613, 421);
			this.tpWykluczenie.TabIndex = 1;
			this.tpWykluczenie.Text = "Wykluczenia";
			this.tpWykluczenie.UseVisualStyleBackColor = true;
			// 
			// txtSeek
			// 
			this.txtSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSeek.Location = new System.Drawing.Point(699, 456);
			this.txtSeek.Name = "txtSeek";
			this.txtSeek.Size = new System.Drawing.Size(177, 20);
			this.txtSeek.TabIndex = 237;
			this.txtSeek.TextChanged += new System.EventHandler(this.txtSeek_TextChanged);
			// 
			// cbSeek
			// 
			this.cbSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSeek.DropDownWidth = 200;
			this.cbSeek.FormattingEnabled = true;
			this.cbSeek.Location = new System.Drawing.Point(571, 455);
			this.cbSeek.Name = "cbSeek";
			this.cbSeek.Size = new System.Drawing.Size(122, 21);
			this.cbSeek.TabIndex = 236;
			this.cbSeek.SelectedIndexChanged += new System.EventHandler(this.cbSeek_SelectedIndexChanged);
			// 
			// Label1
			// 
			this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(517, 459);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(48, 13);
			this.Label1.TabIndex = 235;
			this.Label1.Text = "Filtruj wg";
			// 
			// cmdPrint
			// 
			this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdPrint.Enabled = false;
			this.cmdPrint.Image = global::Belfer.Properties.Resources.print_24;
			this.cmdPrint.Location = new System.Drawing.Point(887, 204);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.Size = new System.Drawing.Size(85, 36);
			this.cmdPrint.TabIndex = 243;
			this.cmdPrint.Text = "Drukuj";
			this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cmdPrint.UseVisualStyleBackColor = true;
			// 
			// Label11
			// 
			this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(259, 455);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(45, 13);
			this.Label11.TabIndex = 244;
			this.Label11.Text = "Rekord:";
			// 
			// lblRecord
			// 
			this.lblRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblRecord.AutoSize = true;
			this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblRecord.ForeColor = System.Drawing.Color.Red;
			this.lblRecord.Location = new System.Drawing.Point(310, 455);
			this.lblRecord.Name = "lblRecord";
			this.lblRecord.Size = new System.Drawing.Size(61, 13);
			this.lblRecord.TabIndex = 245;
			this.lblRecord.Text = "lblRecord";
			// 
			// frmPrivilege
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 523);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this.lblRecord);
			this.Controls.Add(this.cmdPrint);
			this.Controls.Add(this.txtSeek);
			this.Controls.Add(this.cbSeek);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.tcPrivilege);
			this.Controls.Add(this.cmdExclude);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAddNew);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdClose);
			this.Controls.Add(this.pnlSignature);
			this.Controls.Add(this.olvUser);
			this.MinimumSize = new System.Drawing.Size(986, 562);
			this.Name = "frmPrivilege";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Uprawnienia i wykluczenia";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrivilege_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.olvUser)).EndInit();
			this.pnlSignature.ResumeLayout(false);
			this.pnlSignature.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.olvPrivilege)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.olvExclusion)).EndInit();
			this.tcPrivilege.ResumeLayout(false);
			this.tpPrzywilej.ResumeLayout(false);
			this.tpWykluczenie.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public BrightIdeasSoftware.ObjectListView olvUser;
		internal System.Windows.Forms.Panel pnlSignature;
		internal System.Windows.Forms.Label Label30;
		internal System.Windows.Forms.Label Label31;
		internal System.Windows.Forms.Label lblData;
		internal System.Windows.Forms.Label lblIP;
		internal System.Windows.Forms.Label lblUser;
		internal System.Windows.Forms.Label Label32;
		public BrightIdeasSoftware.ObjectListView olvPrivilege;
		internal System.Windows.Forms.Button cmdClose;
		public BrightIdeasSoftware.ObjectListView olvExclusion;
		internal System.Windows.Forms.Button cmdEdit;
		internal System.Windows.Forms.Button cmdAddNew;
		internal System.Windows.Forms.Button cmdDelete;
		internal System.Windows.Forms.Button cmdExclude;
		private System.Windows.Forms.TabPage tpPrzywilej;
		internal System.Windows.Forms.TextBox txtSeek;
		internal System.Windows.Forms.ComboBox cbSeek;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TabControl tcPrivilege;
		internal System.Windows.Forms.TabPage tpWykluczenie;
		internal System.Windows.Forms.Button cmdPrint;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label lblRecord;
	}
}