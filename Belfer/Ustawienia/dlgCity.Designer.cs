namespace Belfer
{
	partial class dlgCity
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
			this.rbSimc = new System.Windows.Forms.RadioButton();
			this.rbByHand = new System.Windows.Forms.RadioButton();
			this.txtNazwa = new System.Windows.Forms.TextBox();
			this.cmdSimc = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtWojewództwo = new System.Windows.Forms.TextBox();
			this.txtPowiat = new System.Windows.Forms.TextBox();
			this.txtGmina = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// rbSimc
			// 
			this.rbSimc.AutoSize = true;
			this.rbSimc.Location = new System.Drawing.Point(12, 12);
			this.rbSimc.Name = "rbSimc";
			this.rbSimc.Size = new System.Drawing.Size(167, 17);
			this.rbSimc.TabIndex = 0;
			this.rbSimc.TabStop = true;
			this.rbSimc.Text = "Miejscowość na terenie Polski";
			this.rbSimc.UseVisualStyleBackColor = true;
			this.rbSimc.CheckedChanged += new System.EventHandler(this.rbSimc_CheckedChanged);
			// 
			// rbByHand
			// 
			this.rbByHand.AutoSize = true;
			this.rbByHand.Location = new System.Drawing.Point(185, 12);
			this.rbByHand.Name = "rbByHand";
			this.rbByHand.Size = new System.Drawing.Size(191, 17);
			this.rbByHand.TabIndex = 1;
			this.rbByHand.TabStop = true;
			this.rbByHand.Text = "Miejscowość poza granicami Polski";
			this.rbByHand.UseVisualStyleBackColor = true;
			// 
			// txtNazwa
			// 
			this.txtNazwa.Location = new System.Drawing.Point(92, 35);
			this.txtNazwa.Name = "txtNazwa";
			this.txtNazwa.ReadOnly = true;
			this.txtNazwa.Size = new System.Drawing.Size(275, 20);
			this.txtNazwa.TabIndex = 2;
			this.txtNazwa.TextChanged += new System.EventHandler(this.txtNazwa_TextChanged);
			// 
			// cmdSimc
			// 
			this.cmdSimc.Location = new System.Drawing.Point(92, 139);
			this.cmdSimc.Name = "cmdSimc";
			this.cmdSimc.Size = new System.Drawing.Size(275, 23);
			this.cmdSimc.TabIndex = 3;
			this.cmdSimc.Text = "Wybierz z katalogu GUS (SIMC)";
			this.cmdSimc.UseVisualStyleBackColor = true;
			this.cmdSimc.Click += new System.EventHandler(this.cmdSimc_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Nazwa";
			// 
			// txtWojewództwo
			// 
			this.txtWojewództwo.Location = new System.Drawing.Point(92, 113);
			this.txtWojewództwo.Name = "txtWojewództwo";
			this.txtWojewództwo.ReadOnly = true;
			this.txtWojewództwo.Size = new System.Drawing.Size(275, 20);
			this.txtWojewództwo.TabIndex = 5;
			// 
			// txtPowiat
			// 
			this.txtPowiat.Location = new System.Drawing.Point(92, 87);
			this.txtPowiat.Name = "txtPowiat";
			this.txtPowiat.ReadOnly = true;
			this.txtPowiat.Size = new System.Drawing.Size(275, 20);
			this.txtPowiat.TabIndex = 6;
			// 
			// txtGmina
			// 
			this.txtGmina.Location = new System.Drawing.Point(92, 61);
			this.txtGmina.Name = "txtGmina";
			this.txtGmina.ReadOnly = true;
			this.txtGmina.Size = new System.Drawing.Size(275, 20);
			this.txtGmina.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Województwo";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Gmina";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Powiat";
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(292, 186);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 221;
			this.cmdCancel.Text = "Zamknij";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// cmdOK
			// 
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(211, 186);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 220;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			// 
			// dlgCity
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(381, 221);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtGmina);
			this.Controls.Add(this.txtPowiat);
			this.Controls.Add(this.txtWojewództwo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmdSimc);
			this.Controls.Add(this.txtNazwa);
			this.Controls.Add(this.rbByHand);
			this.Controls.Add(this.rbSimc);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgCity";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Miejscowości";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rbSimc;
		private System.Windows.Forms.RadioButton rbByHand;
		private System.Windows.Forms.TextBox txtNazwa;
		private System.Windows.Forms.Button cmdSimc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtWojewództwo;
		private System.Windows.Forms.TextBox txtPowiat;
		private System.Windows.Forms.TextBox txtGmina;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Button cmdCancel;
		internal System.Windows.Forms.Button cmdOK;
	}
}