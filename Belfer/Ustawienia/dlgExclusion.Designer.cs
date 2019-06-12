namespace Belfer
{
	partial class dlgExclusion
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
			this.olvStudent = new BrightIdeasSoftware.ObjectListView();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdClose = new System.Windows.Forms.Button();
			this.txtSeek = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.lblRecord = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.olvStudent)).BeginInit();
			this.SuspendLayout();
			// 
			// olvStudent
			// 
			this.olvStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.olvStudent.CellEditUseWholeCell = false;
			this.olvStudent.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvStudent.Location = new System.Drawing.Point(15, 31);
			this.olvStudent.Name = "olvStudent";
			this.olvStudent.Size = new System.Drawing.Size(537, 329);
			this.olvStudent.TabIndex = 17;
			this.olvStudent.UseCompatibleStateImageBehavior = false;
			this.olvStudent.View = System.Windows.Forms.View.Details;
			this.olvStudent.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvObsada_CellEditStarting);
			this.olvStudent.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.olvObsada_CellEditValidating);
			this.olvStudent.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.olvStudent_ItemChecked);
			// 
			// cmdOK
			// 
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(396, 366);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 237;
			this.cmdOK.Text = "Zapisz";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdClose
			// 
			this.cmdClose.Location = new System.Drawing.Point(477, 366);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(75, 23);
			this.cmdClose.TabIndex = 238;
			this.cmdClose.Text = "Zamknij";
			this.cmdClose.UseVisualStyleBackColor = true;
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// txtSeek
			// 
			this.txtSeek.Location = new System.Drawing.Point(326, 5);
			this.txtSeek.Name = "txtSeek";
			this.txtSeek.Size = new System.Drawing.Size(226, 20);
			this.txtSeek.TabIndex = 240;
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(289, 8);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(31, 13);
			this.Label1.TabIndex = 239;
			this.Label1.Text = "Filtruj";
			// 
			// Label11
			// 
			this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(12, 369);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(45, 13);
			this.Label11.TabIndex = 241;
			this.Label11.Text = "Rekord:";
			// 
			// lblRecord
			// 
			this.lblRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblRecord.AutoSize = true;
			this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblRecord.ForeColor = System.Drawing.Color.Red;
			this.lblRecord.Location = new System.Drawing.Point(63, 369);
			this.lblRecord.Name = "lblRecord";
			this.lblRecord.Size = new System.Drawing.Size(61, 13);
			this.lblRecord.TabIndex = 242;
			this.lblRecord.Text = "lblRecord";
			// 
			// dlgExclusion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 398);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this.lblRecord);
			this.Controls.Add(this.txtSeek);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.cmdClose);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.olvStudent);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgExclusion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dodaj wykluczenie";
			((System.ComponentModel.ISupportInitialize)(this.olvStudent)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdClose;
		internal System.Windows.Forms.TextBox txtSeek;
		internal System.Windows.Forms.Label Label1;
		internal BrightIdeasSoftware.ObjectListView olvStudent;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label lblRecord;
	}
}