namespace Belfer
{
	partial class dlgStudent
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.cbKlasa = new System.Windows.Forms.ComboBox();
			this.txtNrArkusza = new System.Windows.Forms.TextBox();
			this.cbMiejsceUr = new System.Windows.Forms.ComboBox();
			this.chkSex = new System.Windows.Forms.CheckBox();
			this.dtDataUr = new System.Windows.Forms.DateTimePicker();
			this.txtTelKom1 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtImieOjca = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNazwiskoOjca = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtPesel = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtImie2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtImie = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNazwisko = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtTelKom2 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtImieMatki = new System.Windows.Forms.TextBox();
			this.txtNazwiskoMatki = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.nudNrwDzienniku = new System.Windows.Forms.NumericUpDown();
			this.cbMiejsceZam = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.txtUlica = new System.Windows.Forms.TextBox();
			this.txtNrDomu = new System.Windows.Forms.TextBox();
			this.txtNrMieszkania = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtTelefon = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.dtDataAktywacji = new System.Windows.Forms.DateTimePicker();
			this.dtDataDeaktywacji = new System.Windows.Forms.DateTimePicker();
			this.cmdAddNewPlace = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudNrwDzienniku)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(84, 3);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.Text = "Anuluj";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// cmdOK
			// 
			this.cmdOK.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cmdOK.Enabled = false;
			this.cmdOK.Location = new System.Drawing.Point(3, 3);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(75, 23);
			this.cmdOK.TabIndex = 0;
			this.cmdOK.Text = "OK";
			this.cmdOK.UseVisualStyleBackColor = true;
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.cmdOK, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cmdCancel, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(568, 255);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(162, 29);
			this.tableLayoutPanel1.TabIndex = 23;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "Klasa";
			// 
			// cbKlasa
			// 
			this.cbKlasa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.cbKlasa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbKlasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbKlasa.FormattingEnabled = true;
			this.cbKlasa.Location = new System.Drawing.Point(86, 6);
			this.cbKlasa.Name = "cbKlasa";
			this.cbKlasa.Size = new System.Drawing.Size(195, 21);
			this.cbKlasa.TabIndex = 0;
			// 
			// txtNrArkusza
			// 
			this.txtNrArkusza.Location = new System.Drawing.Point(376, 6);
			this.txtNrArkusza.Name = "txtNrArkusza";
			this.txtNrArkusza.Size = new System.Drawing.Size(100, 20);
			this.txtNrArkusza.TabIndex = 1;
			// 
			// cbMiejsceUr
			// 
			this.cbMiejsceUr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.cbMiejsceUr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbMiejsceUr.DropDownHeight = 500;
			this.cbMiejsceUr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMiejsceUr.DropDownWidth = 400;
			this.cbMiejsceUr.FormattingEnabled = true;
			this.cbMiejsceUr.IntegralHeight = false;
			this.cbMiejsceUr.Location = new System.Drawing.Point(86, 85);
			this.cbMiejsceUr.Name = "cbMiejsceUr";
			this.cbMiejsceUr.Size = new System.Drawing.Size(644, 21);
			this.cbMiejsceUr.TabIndex = 9;
			// 
			// chkSex
			// 
			this.chkSex.AutoSize = true;
			this.chkSex.Location = new System.Drawing.Point(503, 61);
			this.chkSex.Name = "chkSex";
			this.chkSex.Size = new System.Drawing.Size(83, 17);
			this.chkSex.TabIndex = 8;
			this.chkSex.Text = "Płeć męska";
			this.chkSex.UseVisualStyleBackColor = true;
			// 
			// dtDataUr
			// 
			this.dtDataUr.Location = new System.Drawing.Point(319, 59);
			this.dtDataUr.Name = "dtDataUr";
			this.dtDataUr.Size = new System.Drawing.Size(170, 20);
			this.dtDataUr.TabIndex = 7;
			// 
			// txtTelKom1
			// 
			this.txtTelKom1.Location = new System.Drawing.Point(587, 112);
			this.txtTelKom1.Name = "txtTelKom1";
			this.txtTelKom1.Size = new System.Drawing.Size(143, 20);
			this.txtTelKom1.TabIndex = 12;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 115);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 13);
			this.label9.TabIndex = 33;
			this.label9.Text = "Imię ojca";
			// 
			// txtImieOjca
			// 
			this.txtImieOjca.Location = new System.Drawing.Point(86, 112);
			this.txtImieOjca.Name = "txtImieOjca";
			this.txtImieOjca.Size = new System.Drawing.Size(164, 20);
			this.txtImieOjca.TabIndex = 10;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(291, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(79, 13);
			this.label8.TabIndex = 31;
			this.label8.Text = "Nr ewidencyjny";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(268, 62);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 13);
			this.label7.TabIndex = 30;
			this.label7.Text = "Data ur.";
			// 
			// txtNazwiskoOjca
			// 
			this.txtNazwiskoOjca.Location = new System.Drawing.Point(341, 111);
			this.txtNazwiskoOjca.Name = "txtNazwiskoOjca";
			this.txtNazwiskoOjca.Size = new System.Drawing.Size(180, 20);
			this.txtNazwiskoOjca.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(58, 13);
			this.label6.TabIndex = 28;
			this.label6.Text = "Miejsce ur.";
			// 
			// txtPesel
			// 
			this.txtPesel.Location = new System.Drawing.Point(86, 59);
			this.txtPesel.Name = "txtPesel";
			this.txtPesel.Size = new System.Drawing.Size(176, 20);
			this.txtPesel.TabIndex = 6;
			this.txtPesel.Validating += new System.ComponentModel.CancelEventHandler(this.txtPesel_Validating);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(33, 13);
			this.label5.TabIndex = 26;
			this.label5.Text = "Pesel";
			// 
			// txtImie2
			// 
			this.txtImie2.Location = new System.Drawing.Point(560, 33);
			this.txtImie2.Name = "txtImie2";
			this.txtImie2.Size = new System.Drawing.Size(170, 20);
			this.txtImie2.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(495, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 13);
			this.label4.TabIndex = 24;
			this.label4.Text = "Drugie imię";
			// 
			// txtImie
			// 
			this.txtImie.Location = new System.Drawing.Point(319, 33);
			this.txtImie.Name = "txtImie";
			this.txtImie.Size = new System.Drawing.Size(170, 20);
			this.txtImie.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(287, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(26, 13);
			this.label3.TabIndex = 22;
			this.label3.Text = "Imię";
			// 
			// txtNazwisko
			// 
			this.txtNazwisko.Location = new System.Drawing.Point(86, 33);
			this.txtNazwisko.Name = "txtNazwisko";
			this.txtNazwisko.Size = new System.Drawing.Size(195, 20);
			this.txtNazwisko.TabIndex = 3;
			this.txtNazwisko.TextChanged += new System.EventHandler(this.txtNazwisko_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Nazwisko";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(254, 115);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(76, 13);
			this.label10.TabIndex = 38;
			this.label10.Text = "Nazwisko ojca";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(534, 115);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(51, 13);
			this.label11.TabIndex = 39;
			this.label11.Text = "Tel. kom.";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(535, 141);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(51, 13);
			this.label12.TabIndex = 45;
			this.label12.Text = "Tel. kom.";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(254, 141);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(81, 13);
			this.label13.TabIndex = 44;
			this.label13.Text = "Nazwisko matki";
			// 
			// txtTelKom2
			// 
			this.txtTelKom2.Location = new System.Drawing.Point(587, 138);
			this.txtTelKom2.Name = "txtTelKom2";
			this.txtTelKom2.Size = new System.Drawing.Size(143, 20);
			this.txtTelKom2.TabIndex = 15;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(12, 141);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(54, 13);
			this.label14.TabIndex = 42;
			this.label14.Text = "Imię matki";
			// 
			// txtImieMatki
			// 
			this.txtImieMatki.Location = new System.Drawing.Point(86, 138);
			this.txtImieMatki.Name = "txtImieMatki";
			this.txtImieMatki.Size = new System.Drawing.Size(164, 20);
			this.txtImieMatki.TabIndex = 13;
			// 
			// txtNazwiskoMatki
			// 
			this.txtNazwiskoMatki.Location = new System.Drawing.Point(341, 138);
			this.txtNazwiskoMatki.Name = "txtNazwiskoMatki";
			this.txtNazwiskoMatki.Size = new System.Drawing.Size(180, 20);
			this.txtNazwiskoMatki.TabIndex = 14;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(485, 9);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(77, 13);
			this.label15.TabIndex = 46;
			this.label15.Text = "Nr w dzienniku";
			// 
			// nudNrwDzienniku
			// 
			this.nudNrwDzienniku.Location = new System.Drawing.Point(568, 7);
			this.nudNrwDzienniku.Name = "nudNrwDzienniku";
			this.nudNrwDzienniku.Size = new System.Drawing.Size(66, 20);
			this.nudNrwDzienniku.TabIndex = 2;
			// 
			// cbMiejsceZam
			// 
			this.cbMiejsceZam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.cbMiejsceZam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbMiejsceZam.DropDownHeight = 500;
			this.cbMiejsceZam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMiejsceZam.DropDownWidth = 400;
			this.cbMiejsceZam.FormattingEnabled = true;
			this.cbMiejsceZam.IntegralHeight = false;
			this.cbMiejsceZam.Location = new System.Drawing.Point(86, 164);
			this.cbMiejsceZam.Name = "cbMiejsceZam";
			this.cbMiejsceZam.Size = new System.Drawing.Size(644, 21);
			this.cbMiejsceZam.TabIndex = 16;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(12, 167);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(68, 13);
			this.label16.TabIndex = 49;
			this.label16.Text = "Miejsce zam.";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(13, 194);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(31, 13);
			this.label17.TabIndex = 50;
			this.label17.Text = "Ulica";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(315, 194);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(47, 13);
			this.label18.TabIndex = 51;
			this.label18.Text = "Nr domu";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(414, 194);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(73, 13);
			this.label19.TabIndex = 52;
			this.label19.Text = "Nr mieszkania";
			// 
			// txtUlica
			// 
			this.txtUlica.Location = new System.Drawing.Point(86, 191);
			this.txtUlica.Name = "txtUlica";
			this.txtUlica.Size = new System.Drawing.Size(223, 20);
			this.txtUlica.TabIndex = 17;
			// 
			// txtNrDomu
			// 
			this.txtNrDomu.Location = new System.Drawing.Point(368, 191);
			this.txtNrDomu.Name = "txtNrDomu";
			this.txtNrDomu.Size = new System.Drawing.Size(40, 20);
			this.txtNrDomu.TabIndex = 18;
			// 
			// txtNrMieszkania
			// 
			this.txtNrMieszkania.Location = new System.Drawing.Point(493, 191);
			this.txtNrMieszkania.Name = "txtNrMieszkania";
			this.txtNrMieszkania.Size = new System.Drawing.Size(40, 20);
			this.txtNrMieszkania.TabIndex = 19;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(539, 194);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(43, 13);
			this.label20.TabIndex = 57;
			this.label20.Text = "Telefon";
			// 
			// txtTelefon
			// 
			this.txtTelefon.Location = new System.Drawing.Point(587, 191);
			this.txtTelefon.Name = "txtTelefon";
			this.txtTelefon.Size = new System.Drawing.Size(143, 20);
			this.txtTelefon.TabIndex = 20;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(11, 221);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(65, 13);
			this.label21.TabIndex = 58;
			this.label21.Text = "Data Aktyw.";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(246, 221);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(76, 13);
			this.label22.TabIndex = 59;
			this.label22.Text = "Data deaktyw.";
			// 
			// dtDataAktywacji
			// 
			this.dtDataAktywacji.Location = new System.Drawing.Point(86, 217);
			this.dtDataAktywacji.Name = "dtDataAktywacji";
			this.dtDataAktywacji.Size = new System.Drawing.Size(154, 20);
			this.dtDataAktywacji.TabIndex = 21;
			// 
			// dtDataDeaktywacji
			// 
			this.dtDataDeaktywacji.Location = new System.Drawing.Point(328, 217);
			this.dtDataDeaktywacji.Name = "dtDataDeaktywacji";
			this.dtDataDeaktywacji.Size = new System.Drawing.Size(154, 20);
			this.dtDataDeaktywacji.TabIndex = 22;
			// 
			// cmdAddNewPlace
			// 
			this.cmdAddNewPlace.Location = new System.Drawing.Point(86, 258);
			this.cmdAddNewPlace.Name = "cmdAddNewPlace";
			this.cmdAddNewPlace.Size = new System.Drawing.Size(143, 23);
			this.cmdAddNewPlace.TabIndex = 24;
			this.cmdAddNewPlace.Text = "Dodaj nową miejscowość";
			this.cmdAddNewPlace.UseVisualStyleBackColor = true;
			this.cmdAddNewPlace.Click += new System.EventHandler(this.cmdAddNewPlace_Click);
			// 
			// dlgStudent
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(742, 296);
			this.Controls.Add(this.cmdAddNewPlace);
			this.Controls.Add(this.dtDataDeaktywacji);
			this.Controls.Add(this.dtDataAktywacji);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.txtTelefon);
			this.Controls.Add(this.txtNrMieszkania);
			this.Controls.Add(this.txtNrDomu);
			this.Controls.Add(this.txtUlica);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.cbMiejsceZam);
			this.Controls.Add(this.nudNrwDzienniku);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.txtTelKom2);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.txtImieMatki);
			this.Controls.Add(this.txtNazwiskoMatki);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.cbMiejsceUr);
			this.Controls.Add(this.chkSex);
			this.Controls.Add(this.dtDataUr);
			this.Controls.Add(this.txtTelKom1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtImieOjca);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtNazwiskoOjca);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtPesel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtImie2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtImie);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtNazwisko);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbKlasa);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.txtNrArkusza);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgStudent";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dodaj ucznia";
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudNrwDzienniku)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button cmdAddNewPlace;
		internal System.Windows.Forms.ComboBox cbKlasa;
		internal System.Windows.Forms.ComboBox cbMiejsceUr;
		internal System.Windows.Forms.ComboBox cbMiejsceZam;
		internal System.Windows.Forms.TextBox txtNrArkusza;
		internal System.Windows.Forms.CheckBox chkSex;
		internal System.Windows.Forms.DateTimePicker dtDataUr;
		internal System.Windows.Forms.TextBox txtTelKom1;
		internal System.Windows.Forms.TextBox txtImieOjca;
		internal System.Windows.Forms.TextBox txtNazwiskoOjca;
		internal System.Windows.Forms.TextBox txtPesel;
		internal System.Windows.Forms.TextBox txtImie2;
		internal System.Windows.Forms.TextBox txtImie;
		internal System.Windows.Forms.TextBox txtNazwisko;
		internal System.Windows.Forms.TextBox txtTelKom2;
		internal System.Windows.Forms.TextBox txtImieMatki;
		internal System.Windows.Forms.TextBox txtNazwiskoMatki;
		internal System.Windows.Forms.NumericUpDown nudNrwDzienniku;
		internal System.Windows.Forms.TextBox txtUlica;
		internal System.Windows.Forms.TextBox txtNrDomu;
		internal System.Windows.Forms.TextBox txtNrMieszkania;
		internal System.Windows.Forms.TextBox txtTelefon;
		internal System.Windows.Forms.DateTimePicker dtDataAktywacji;
		internal System.Windows.Forms.DateTimePicker dtDataDeaktywacji;
	}
}