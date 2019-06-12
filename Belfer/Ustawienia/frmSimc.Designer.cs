namespace Belfer
{
	partial class frmSimc
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
			this.folvCity = new BrightIdeasSoftware.FastObjectListView();
			this.cbSeek = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSeek = new System.Windows.Forms.TextBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.lblRecord = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.folvCity)).BeginInit();
			this.SuspendLayout();
			// 
			// folvCity
			// 
			this.folvCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.folvCity.CellEditUseWholeCell = false;
			this.folvCity.Location = new System.Drawing.Point(12, 39);
			this.folvCity.Name = "folvCity";
			this.folvCity.ShowGroups = false;
			this.folvCity.Size = new System.Drawing.Size(755, 328);
			this.folvCity.TabIndex = 0;
			this.folvCity.UseCompatibleStateImageBehavior = false;
			this.folvCity.View = System.Windows.Forms.View.Details;
			this.folvCity.VirtualMode = true;
			this.folvCity.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.folvCity_CellToolTipShowing);
			this.folvCity.SelectionChanged += new System.EventHandler(this.folvCity_SelectionChanged);
			this.folvCity.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.folvCity_ItemSelectionChanged);
			// 
			// cbSeek
			// 
			this.cbSeek.FormattingEnabled = true;
			this.cbSeek.Location = new System.Drawing.Point(78, 12);
			this.cbSeek.Name = "cbSeek";
			this.cbSeek.Size = new System.Drawing.Size(131, 21);
			this.cbSeek.TabIndex = 215;
			this.cbSeek.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 214;
			this.label1.Text = "Filtruj wg";
			// 
			// txtSeek
			// 
			this.txtSeek.Location = new System.Drawing.Point(215, 12);
			this.txtSeek.Name = "txtSeek";
			this.txtSeek.Size = new System.Drawing.Size(259, 20);
			this.txtSeek.TabIndex = 213;
			this.txtSeek.TextChanged += new System.EventHandler(this.txtSeek_TextChanged);
			// 
			// Label11
			// 
			this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(12, 373);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(45, 13);
			this.Label11.TabIndex = 216;
			this.Label11.Text = "Rekord:";
			// 
			// lblRecord
			// 
			this.lblRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblRecord.AutoSize = true;
			this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblRecord.ForeColor = System.Drawing.Color.Red;
			this.lblRecord.Location = new System.Drawing.Point(63, 373);
			this.lblRecord.Name = "lblRecord";
			this.lblRecord.Size = new System.Drawing.Size(61, 13);
			this.lblRecord.TabIndex = 217;
			this.lblRecord.Text = "lblRecord";
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Location = new System.Drawing.Point(611, 373);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 218;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Visible = false;
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(692, 373);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 219;
			this.cmdCancel.Text = "Zamknij";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// frmSimc
			// 
			this.AcceptButton = this.cmdCancel;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(779, 400);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this.lblRecord);
			this.Controls.Add(this.cbSeek);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSeek);
			this.Controls.Add(this.folvCity);
			this.Name = "frmSimc";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Rejestr nazw miejscowości wg GUS";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSimc_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.folvCity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox cbSeek;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSeek;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label lblRecord;
		internal System.Windows.Forms.Button cmdOK;
		internal System.Windows.Forms.Button cmdCancel;
		internal BrightIdeasSoftware.FastObjectListView folvCity;
	}
}