namespace Belfer
{
	partial class frmStudent
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
            this.cmdImport = new System.Windows.Forms.Button();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdAddNew = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.olvStudent = new BrightIdeasSoftware.ObjectListView();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdStrikeOut = new System.Windows.Forms.Button();
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
            this.tblDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDataDeaktywacji = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDataAktywacji = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTelKom2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblTelKom1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblMatka = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblOjciec = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAdres = new System.Windows.Forms.Label();
            this.cmdNumber = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.olvStudent)).BeginInit();
            this.pnlRecord.SuspendLayout();
            this.pnlSignature.SuspendLayout();
            this.tblDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdImport
            // 
            this.cmdImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImport.Enabled = false;
            this.cmdImport.Image = global::Belfer.Properties.Resources.Import_24T;
            this.cmdImport.Location = new System.Drawing.Point(872, 244);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(86, 36);
            this.cmdImport.TabIndex = 231;
            this.cmdImport.Text = "Importuj";
            this.cmdImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.CmdImport_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.Enabled = false;
            this.cmdPrint.Image = global::Belfer.Properties.Resources.print_24;
            this.cmdPrint.Location = new System.Drawing.Point(872, 286);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(86, 36);
            this.cmdPrint.TabIndex = 230;
            this.cmdPrint.Text = "Drukuj";
            this.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdPrint.UseVisualStyleBackColor = true;
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Enabled = false;
            this.cmdEdit.Image = global::Belfer.Properties.Resources.edit;
            this.cmdEdit.Location = new System.Drawing.Point(872, 54);
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
            this.cmdAddNew.Enabled = false;
            this.cmdAddNew.Image = global::Belfer.Properties.Resources.add_24;
            this.cmdAddNew.Location = new System.Drawing.Point(872, 12);
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
            this.cmdDelete.Location = new System.Drawing.Point(872, 96);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(86, 36);
            this.cmdDelete.TabIndex = 227;
            this.cmdDelete.Text = "&Usuń";
            this.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // olvStudent
            // 
            this.olvStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvStudent.CellEditUseWholeCell = false;
            this.olvStudent.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvStudent.Location = new System.Drawing.Point(12, 12);
            this.olvStudent.Name = "olvStudent";
            this.olvStudent.Size = new System.Drawing.Size(854, 354);
            this.olvStudent.TabIndex = 232;
            this.olvStudent.UseCompatibleStateImageBehavior = false;
            this.olvStudent.View = System.Windows.Forms.View.Details;
            this.olvStudent.AboutToCreateGroups += new System.EventHandler<BrightIdeasSoftware.CreateGroupsEventArgs>(this.olvStudent_AboutToCreateGroups);
            this.olvStudent.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.olvStudent_CellToolTipShowing);
            this.olvStudent.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvStudent_FormatRow);
            this.olvStudent.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.olvObsada_ItemSelectionChanged);
            this.olvStudent.DoubleClick += new System.EventHandler(this.olvStudent_DoubleClick);
            this.olvStudent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.olvStudent_KeyUp);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Image = global::Belfer.Properties.Resources.close_22;
            this.cmdClose.Location = new System.Drawing.Point(872, 328);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(86, 35);
            this.cmdClose.TabIndex = 233;
            this.cmdClose.Text = "&Zamknij";
            this.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdStrikeOut
            // 
            this.cmdStrikeOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStrikeOut.Enabled = false;
            this.cmdStrikeOut.Image = global::Belfer.Properties.Resources.strikeout_24;
            this.cmdStrikeOut.Location = new System.Drawing.Point(872, 138);
            this.cmdStrikeOut.Name = "cmdStrikeOut";
            this.cmdStrikeOut.Size = new System.Drawing.Size(86, 36);
            this.cmdStrikeOut.TabIndex = 234;
            this.cmdStrikeOut.Text = "&Skreśl";
            this.cmdStrikeOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdStrikeOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdStrikeOut.UseVisualStyleBackColor = true;
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
            this.pnlRecord.Location = new System.Drawing.Point(12, 369);
            this.pnlRecord.Name = "pnlRecord";
            this.pnlRecord.Size = new System.Drawing.Size(946, 29);
            this.pnlRecord.TabIndex = 235;
            this.pnlRecord.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRecord_Paint);
            // 
            // txtSeek
            // 
            this.txtSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeek.Location = new System.Drawing.Point(612, 3);
            this.txtSeek.Name = "txtSeek";
            this.txtSeek.Size = new System.Drawing.Size(242, 20);
            this.txtSeek.TabIndex = 152;
            this.txtSeek.TextChanged += new System.EventHandler(this.txtSeek_TextChanged);
            // 
            // cbSeek
            // 
            this.cbSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeek.DropDownWidth = 200;
            this.cbSeek.FormattingEnabled = true;
            this.cbSeek.Location = new System.Drawing.Point(484, 1);
            this.cbSeek.Name = "cbSeek";
            this.cbSeek.Size = new System.Drawing.Size(122, 21);
            this.cbSeek.TabIndex = 151;
            this.cbSeek.SelectedIndexChanged += new System.EventHandler(this.cbSeek_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(430, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(48, 13);
            this.Label1.TabIndex = 150;
            this.Label1.Text = "Filtruj wg";
            // 
            // Label11
            // 
            this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(4, 6);
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
            this.pnlSignature.Location = new System.Drawing.Point(12, 478);
            this.pnlSignature.Name = "pnlSignature";
            this.pnlSignature.Size = new System.Drawing.Size(946, 34);
            this.pnlSignature.TabIndex = 236;
            this.pnlSignature.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSignature_Paint);
            // 
            // Label30
            // 
            this.Label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label30.AutoSize = true;
            this.Label30.Enabled = false;
            this.Label30.Location = new System.Drawing.Point(727, 13);
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
            this.Label31.Location = new System.Drawing.Point(584, 13);
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
            this.lblData.Location = new System.Drawing.Point(818, 8);
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
            this.lblIP.Location = new System.Drawing.Point(621, 8);
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
            this.lblUser.Size = new System.Drawing.Size(495, 23);
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
            // tblDetails
            // 
            this.tblDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblDetails.ColumnCount = 8;
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.11221F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.58746F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.58746F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tblDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.71287F));
            this.tblDetails.Controls.Add(this.lblStatus, 5, 2);
            this.tblDetails.Controls.Add(this.label6, 4, 2);
            this.tblDetails.Controls.Add(this.lblDataDeaktywacji, 3, 2);
            this.tblDetails.Controls.Add(this.label5, 2, 2);
            this.tblDetails.Controls.Add(this.lblDataAktywacji, 1, 2);
            this.tblDetails.Controls.Add(this.label4, 0, 2);
            this.tblDetails.Controls.Add(this.lblTelKom2, 7, 1);
            this.tblDetails.Controls.Add(this.label20, 6, 1);
            this.tblDetails.Controls.Add(this.lblTelKom1, 3, 1);
            this.tblDetails.Controls.Add(this.label18, 2, 1);
            this.tblDetails.Controls.Add(this.lblTelefon, 7, 0);
            this.tblDetails.Controls.Add(this.label16, 6, 0);
            this.tblDetails.Controls.Add(this.lblMatka, 5, 1);
            this.tblDetails.Controls.Add(this.label12, 4, 1);
            this.tblDetails.Controls.Add(this.lblOjciec, 1, 1);
            this.tblDetails.Controls.Add(this.label3, 0, 1);
            this.tblDetails.Controls.Add(this.label2, 0, 0);
            this.tblDetails.Controls.Add(this.lblAdres, 1, 0);
            this.tblDetails.Location = new System.Drawing.Point(12, 400);
            this.tblDetails.Name = "tblDetails";
            this.tblDetails.Padding = new System.Windows.Forms.Padding(2);
            this.tblDetails.RowCount = 3;
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblDetails.Size = new System.Drawing.Size(946, 75);
            this.tblDetails.TabIndex = 237;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(543, 50);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(144, 21);
            this.lblStatus.TabIndex = 29;
            this.lblStatus.Text = "lblStatus";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(463, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 28;
            this.label6.Text = "Status";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDataDeaktywacji
            // 
            this.lblDataDeaktywacji.AutoSize = true;
            this.lblDataDeaktywacji.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataDeaktywacji.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDataDeaktywacji.ForeColor = System.Drawing.Color.Blue;
            this.lblDataDeaktywacji.Location = new System.Drawing.Point(315, 50);
            this.lblDataDeaktywacji.Margin = new System.Windows.Forms.Padding(2);
            this.lblDataDeaktywacji.Name = "lblDataDeaktywacji";
            this.lblDataDeaktywacji.Size = new System.Drawing.Size(144, 21);
            this.lblDataDeaktywacji.TabIndex = 27;
            this.lblDataDeaktywacji.Text = "lblDataAktywacji";
            this.lblDataDeaktywacji.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(221, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 26;
            this.label5.Text = "Data deaktywacji";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDataAktywacji
            // 
            this.lblDataAktywacji.AutoSize = true;
            this.lblDataAktywacji.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataAktywacji.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDataAktywacji.ForeColor = System.Drawing.Color.Blue;
            this.lblDataAktywacji.Location = new System.Drawing.Point(88, 50);
            this.lblDataAktywacji.Margin = new System.Windows.Forms.Padding(2);
            this.lblDataAktywacji.Name = "lblDataAktywacji";
            this.lblDataAktywacji.Size = new System.Drawing.Size(129, 21);
            this.lblDataAktywacji.TabIndex = 25;
            this.lblDataAktywacji.Text = "lblDataAktywacji";
            this.lblDataAktywacji.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "Data aktywacji";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelKom2
            // 
            this.lblTelKom2.AutoSize = true;
            this.lblTelKom2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelKom2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTelKom2.ForeColor = System.Drawing.Color.Blue;
            this.lblTelKom2.Location = new System.Drawing.Point(771, 27);
            this.lblTelKom2.Margin = new System.Windows.Forms.Padding(2);
            this.lblTelKom2.Name = "lblTelKom2";
            this.lblTelKom2.Size = new System.Drawing.Size(171, 19);
            this.lblTelKom2.TabIndex = 19;
            this.lblTelKom2.Text = "lblTelKom2";
            this.lblTelKom2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(691, 27);
            this.label20.Margin = new System.Windows.Forms.Padding(2);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 19);
            this.label20.TabIndex = 18;
            this.label20.Text = "Telefon kom.";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelKom1
            // 
            this.lblTelKom1.AutoSize = true;
            this.lblTelKom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelKom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTelKom1.ForeColor = System.Drawing.Color.Blue;
            this.lblTelKom1.Location = new System.Drawing.Point(315, 27);
            this.lblTelKom1.Margin = new System.Windows.Forms.Padding(2);
            this.lblTelKom1.Name = "lblTelKom1";
            this.lblTelKom1.Size = new System.Drawing.Size(144, 19);
            this.lblTelKom1.TabIndex = 17;
            this.lblTelKom1.Text = "lblTelKom1";
            this.lblTelKom1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(221, 27);
            this.label18.Margin = new System.Windows.Forms.Padding(2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 19);
            this.label18.TabIndex = 16;
            this.label18.Text = "Telefon kom.";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTelefon.ForeColor = System.Drawing.Color.Blue;
            this.lblTelefon.Location = new System.Drawing.Point(771, 4);
            this.lblTelefon.Margin = new System.Windows.Forms.Padding(2);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(171, 19);
            this.lblTelefon.TabIndex = 15;
            this.lblTelefon.Text = "lblTelefon";
            this.lblTelefon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(691, 4);
            this.label16.Margin = new System.Windows.Forms.Padding(2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 19);
            this.label16.TabIndex = 14;
            this.label16.Text = "Telefon";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMatka
            // 
            this.lblMatka.AutoSize = true;
            this.lblMatka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMatka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMatka.ForeColor = System.Drawing.Color.Blue;
            this.lblMatka.Location = new System.Drawing.Point(543, 27);
            this.lblMatka.Margin = new System.Windows.Forms.Padding(2);
            this.lblMatka.Name = "lblMatka";
            this.lblMatka.Size = new System.Drawing.Size(144, 19);
            this.lblMatka.TabIndex = 11;
            this.lblMatka.Text = "lblMatka";
            this.lblMatka.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(463, 27);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 19);
            this.label12.TabIndex = 10;
            this.label12.Text = "Matka";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOjciec
            // 
            this.lblOjciec.AutoSize = true;
            this.lblOjciec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOjciec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOjciec.ForeColor = System.Drawing.Color.Blue;
            this.lblOjciec.Location = new System.Drawing.Point(88, 27);
            this.lblOjciec.Margin = new System.Windows.Forms.Padding(2);
            this.lblOjciec.Name = "lblOjciec";
            this.lblOjciec.Size = new System.Drawing.Size(129, 19);
            this.lblOjciec.TabIndex = 7;
            this.lblOjciec.Text = "lblOjciec";
            this.lblOjciec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ojciec";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Adres";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.tblDetails.SetColumnSpan(this.lblAdres, 5);
            this.lblAdres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAdres.ForeColor = System.Drawing.Color.Blue;
            this.lblAdres.Location = new System.Drawing.Point(88, 4);
            this.lblAdres.Margin = new System.Windows.Forms.Padding(2);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(599, 19);
            this.lblAdres.TabIndex = 1;
            this.lblAdres.Text = "lblAdres";
            this.lblAdres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdNumber
            // 
            this.cmdNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNumber.Enabled = false;
            this.cmdNumber.Image = global::Belfer.Properties.Resources.sorting_24;
            this.cmdNumber.Location = new System.Drawing.Point(872, 180);
            this.cmdNumber.Name = "cmdNumber";
            this.cmdNumber.Size = new System.Drawing.Size(86, 36);
            this.cmdNumber.TabIndex = 238;
            this.cmdNumber.Text = "Numeruj";
            this.cmdNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdNumber.UseVisualStyleBackColor = true;
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 523);
            this.Controls.Add(this.cmdNumber);
            this.Controls.Add(this.tblDetails);
            this.Controls.Add(this.pnlSignature);
            this.Controls.Add(this.pnlRecord);
            this.Controls.Add(this.cmdStrikeOut);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.olvStudent);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAddNew);
            this.Controls.Add(this.cmdDelete);
            this.Name = "frmStudent";
            this.Text = "Dane uczniów";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStudent_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.olvStudent)).EndInit();
            this.pnlRecord.ResumeLayout(false);
            this.pnlRecord.PerformLayout();
            this.pnlSignature.ResumeLayout(false);
            this.pnlSignature.PerformLayout();
            this.tblDetails.ResumeLayout(false);
            this.tblDetails.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.Button cmdImport;
		internal System.Windows.Forms.Button cmdPrint;
		internal System.Windows.Forms.Button cmdEdit;
		internal System.Windows.Forms.Button cmdAddNew;
		internal System.Windows.Forms.Button cmdDelete;
		public BrightIdeasSoftware.ObjectListView olvStudent;
		internal System.Windows.Forms.Button cmdClose;
		internal System.Windows.Forms.Button cmdStrikeOut;
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
		private System.Windows.Forms.TableLayoutPanel tblDetails;
		private System.Windows.Forms.Label lblDataDeaktywacji;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblDataAktywacji;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblTelKom2;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label lblTelKom1;
		private System.Windows.Forms.Label lblTelefon;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lblMatka;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label lblOjciec;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblAdres;
		private System.Windows.Forms.Label label18;
		internal System.Windows.Forms.Button cmdNumber;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label label6;
	}
}