namespace Belfer
{
	partial class dlgPrivilege
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
			this.olvObsada = new BrightIdeasSoftware.ObjectListView();
			this.txtSeek = new System.Windows.Forms.TextBox();
			this.cbSeek = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.lblRecord = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.olvObsada)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(721, 348);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 13;
			this.cmdCancel.Text = "Zamknij";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOK.Location = new System.Drawing.Point(640, 348);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 12;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// olvObsada
			// 
			this.olvObsada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.olvObsada.CellEditUseWholeCell = false;
			this.olvObsada.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvObsada.Location = new System.Drawing.Point(12, 35);
			this.olvObsada.Name = "olvObsada";
			this.olvObsada.Size = new System.Drawing.Size(784, 307);
			this.olvObsada.TabIndex = 30;
			this.olvObsada.UseCompatibleStateImageBehavior = false;
			this.olvObsada.View = System.Windows.Forms.View.Details;
			this.olvObsada.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvObsada_CellEditStarting);
			this.olvObsada.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.olvObsada_CellEditValidating);
			// 
			// txtSeek
			// 
			this.txtSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSeek.Location = new System.Drawing.Point(549, 9);
			this.txtSeek.Name = "txtSeek";
			this.txtSeek.Size = new System.Drawing.Size(247, 20);
			this.txtSeek.TabIndex = 155;
			this.txtSeek.TextChanged += new System.EventHandler(this.txtSeek_TextChanged);
			// 
			// cbSeek
			// 
			this.cbSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSeek.DropDownWidth = 200;
			this.cbSeek.FormattingEnabled = true;
			this.cbSeek.Location = new System.Drawing.Point(421, 9);
			this.cbSeek.Name = "cbSeek";
			this.cbSeek.Size = new System.Drawing.Size(122, 21);
			this.cbSeek.TabIndex = 154;
			this.cbSeek.SelectedIndexChanged += new System.EventHandler(this.cbSeek_SelectedIndexChanged);
			// 
			// Label1
			// 
			this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(367, 12);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(48, 13);
			this.Label1.TabIndex = 153;
			this.Label1.Text = "Filtruj wg";
			// 
			// Label11
			// 
			this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(12, 345);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(45, 13);
			this.Label11.TabIndex = 243;
			this.Label11.Text = "Rekord:";
			// 
			// lblRecord
			// 
			this.lblRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblRecord.AutoSize = true;
			this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblRecord.ForeColor = System.Drawing.Color.Red;
			this.lblRecord.Location = new System.Drawing.Point(63, 345);
			this.lblRecord.Name = "lblRecord";
			this.lblRecord.Size = new System.Drawing.Size(61, 13);
			this.lblRecord.TabIndex = 244;
			this.lblRecord.Text = "lblRecord";
			// 
			// dlgPrivilege
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(808, 383);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this.lblRecord);
			this.Controls.Add(this.txtSeek);
			this.Controls.Add(this.cbSeek);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.olvObsada);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Name = "dlgPrivilege";
			this.Text = "Dodaj uprawnienie";
			((System.ComponentModel.ISupportInitialize)(this.olvObsada)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmdCancel;
		protected internal System.Windows.Forms.Button cmdOK;
		public BrightIdeasSoftware.ObjectListView olvObsada;
		internal System.Windows.Forms.TextBox txtSeek;
		internal System.Windows.Forms.ComboBox cbSeek;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label lblRecord;
	}
}