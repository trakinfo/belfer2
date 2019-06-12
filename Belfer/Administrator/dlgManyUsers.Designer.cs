namespace Belfer
{
	partial class dlgManyUsers
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
			this.cmdExport = new System.Windows.Forms.Button();
			this.cmdImport = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdAddNew = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.olvUser)).BeginInit();
			this.SuspendLayout();
			// 
			// olvUser
			// 
			this.olvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.olvUser.CellEditUseWholeCell = false;
			this.olvUser.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvUser.Location = new System.Drawing.Point(12, 12);
			this.olvUser.Name = "olvUser";
			this.olvUser.ShowItemCountOnGroups = true;
			this.olvUser.Size = new System.Drawing.Size(854, 421);
			this.olvUser.TabIndex = 0;
			this.olvUser.UseCompatibleStateImageBehavior = false;
			this.olvUser.View = System.Windows.Forms.View.Details;
			this.olvUser.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvUser_CellEditStarting);
			this.olvUser.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.olvUser_CellEditValidating);
			this.olvUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.olvUser_KeyUp);
			// 
			// cmdExport
			// 
			this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdExport.Location = new System.Drawing.Point(380, 439);
			this.cmdExport.Name = "cmdExport";
			this.cmdExport.Size = new System.Drawing.Size(126, 23);
			this.cmdExport.TabIndex = 4;
			this.cmdExport.Text = "Eksportuj listę do pliku";
			this.cmdExport.UseVisualStyleBackColor = true;
			this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
			// 
			// cmdImport
			// 
			this.cmdImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdImport.Location = new System.Drawing.Point(512, 439);
			this.cmdImport.Name = "cmdImport";
			this.cmdImport.Size = new System.Drawing.Size(126, 23);
			this.cmdImport.TabIndex = 5;
			this.cmdImport.Text = "Importuj listę z pliku";
			this.cmdImport.UseVisualStyleBackColor = true;
			this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.Location = new System.Drawing.Point(699, 439);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(86, 23);
			this.cmdOK.TabIndex = 2;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(791, 439);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Text = "Anuluj";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdAddNew
			// 
			this.cmdAddNew.Location = new System.Drawing.Point(12, 439);
			this.cmdAddNew.Name = "cmdAddNew";
			this.cmdAddNew.Size = new System.Drawing.Size(86, 23);
			this.cmdAddNew.TabIndex = 1;
			this.cmdAddNew.Text = "Dodaj rekord";
			this.cmdAddNew.UseVisualStyleBackColor = true;
			this.cmdAddNew.Click += new System.EventHandler(this.cmdAddNew_Click);
			// 
			// dlgManyUsers
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(878, 474);
			this.Controls.Add(this.cmdAddNew);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.cmdImport);
			this.Controls.Add(this.cmdExport);
			this.Controls.Add(this.olvUser);
			this.Name = "dlgManyUsers";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dodawanie użytkowników";
			((System.ComponentModel.ISupportInitialize)(this.olvUser)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private BrightIdeasSoftware.ObjectListView olvUser;
		private System.Windows.Forms.Button cmdExport;
		private System.Windows.Forms.Button cmdImport;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdAddNew;
	}
}