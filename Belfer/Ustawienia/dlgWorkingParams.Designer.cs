namespace Belfer
{
	partial class dlgWorkingParams
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
			this.cbSzkola = new System.Windows.Forms.ComboBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.nudEndYear = new System.Windows.Forms.NumericUpDown();
			this.nudStartYear = new System.Windows.Forms.NumericUpDown();
			this.Label5 = new System.Windows.Forms.Label();
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.OK_Button = new System.Windows.Forms.Button();
			this.Cancel_Button = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nudEndYear)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudStartYear)).BeginInit();
			this.TableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbSzkola
			// 
			this.cbSzkola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSzkola.Enabled = false;
			this.cbSzkola.FormattingEnabled = true;
			this.cbSzkola.Location = new System.Drawing.Point(82, 41);
			this.cbSzkola.Name = "cbSzkola";
			this.cbSzkola.Size = new System.Drawing.Size(318, 21);
			this.cbSzkola.TabIndex = 208;
			this.cbSzkola.SelectedIndexChanged += new System.EventHandler(this.cbSzkola_SelectedIndexChanged);
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(12, 45);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(41, 13);
			this.Label7.TabIndex = 207;
			this.Label7.Text = "Szkoła";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Label6.Location = new System.Drawing.Point(143, 14);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(15, 24);
			this.Label6.TabIndex = 204;
			this.Label6.Text = "/";
			// 
			// nudEndYear
			// 
			this.nudEndYear.Enabled = false;
			this.nudEndYear.Location = new System.Drawing.Point(159, 16);
			this.nudEndYear.Maximum = new decimal(new int[] {
            2051,
            0,
            0,
            0});
			this.nudEndYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudEndYear.Name = "nudEndYear";
			this.nudEndYear.Size = new System.Drawing.Size(55, 20);
			this.nudEndYear.TabIndex = 203;
			this.nudEndYear.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// nudStartYear
			// 
			this.nudStartYear.Location = new System.Drawing.Point(82, 16);
			this.nudStartYear.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
			this.nudStartYear.Name = "nudStartYear";
			this.nudStartYear.Size = new System.Drawing.Size(55, 20);
			this.nudStartYear.TabIndex = 202;
			this.nudStartYear.ValueChanged += new System.EventHandler(this.nudStartYear_ValueChanged);
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(11, 18);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(65, 13);
			this.Label5.TabIndex = 201;
			this.Label5.Text = "Rok szkolny";
			// 
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Location = new System.Drawing.Point(257, 90);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
			this.TableLayoutPanel1.TabIndex = 200;
			// 
			// OK_Button
			// 
			this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.OK_Button.Enabled = false;
			this.OK_Button.Location = new System.Drawing.Point(3, 3);
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size(67, 23);
			this.OK_Button.TabIndex = 0;
			this.OK_Button.Text = "OK";
			this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_Button.Location = new System.Drawing.Point(76, 3);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
			this.Cancel_Button.TabIndex = 1;
			this.Cancel_Button.Text = "Anuluj";
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
			// 
			// dlgWorkingParams
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(416, 133);
			this.Controls.Add(this.cbSzkola);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.nudEndYear);
			this.Controls.Add(this.nudStartYear);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.TableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgWorkingParams";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Parametry pracy";
			((System.ComponentModel.ISupportInitialize)(this.nudEndYear)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudStartYear)).EndInit();
			this.TableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ComboBox cbSzkola;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.NumericUpDown nudEndYear;
		internal System.Windows.Forms.NumericUpDown nudStartYear;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal System.Windows.Forms.Button OK_Button;
		internal System.Windows.Forms.Button Cancel_Button;
	}
}