using Belfer.Administrator.SQL;
using Belfer.Ustawienia;
using System;
using System.Windows.Forms;


namespace Belfer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
			InitializeComponent();
			//AppSession.Conn.StateChange += SetConnectionStatus;
			SetApplicationInfo();
		}

		private void tsbZamknij_Click(object sender, EventArgs e)
		{
			ZamknijtoolStripMenuItem_Click(sender, e);
		}

		private void ZamknijtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			Authentication.Logout().Wait();
			Application.Exit();
		}

		private void ProgramInfotoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var About = new AboutBelfer();
			About.ShowDialog();
		}

		private void tsbWyloguj_Click(object sender, EventArgs e)
		{
			Logout();
		}

		private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			Authentication.ChangePassword();
		}

		private void ChangeUserPasswordtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			Authentication.ChangePassword(UserSession.User, false);
		}

		private void WylogujtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			Logout();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
			CenterToScreen();
			ResetUserSessionInfo();
			Login();
		}

		private void tsbUstawienia_Click(object sender, EventArgs e)
		{
			if (Authentication.GetWorkingParams(UserSession.User.Settings))
			{
				SetApplicationPrivileges(false);
				ReviseUserRole();
				SetUserSessionInfo();
				SetApplicationPrivileges(true);
			}
			
		}

		private void lblSchoolName_DoubleClick(object sender, EventArgs e)
		{
			tsbUstawienia_Click(sender, e);
		}

		private void KonfiguracjatoolStripMenuItem_Click(object sender, EventArgs e)
		{
			tsbUstawienia_Click(sender, e);
		}

		private void DaneSzkolytoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmSchool();

			SetFormProperties(frm);

			SzkolatoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => SzkolatoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void SimctoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmSimc(CitySQL.SelectAllPlaceFromSimc());

			SetFormProperties(frm);

			SimctoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => SimctoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void ZarzadzanieUzytkownikamitoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmUser(UserSQL.SelectAllUsers());

			SetFormProperties(frm);

			ZarzadzanieUzytkownikamitoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => ZarzadzanieUzytkownikamitoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void PrzydzialNauczycielitoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmNauczyciel();

			SetFormProperties(frm);

			PrzydzialNauczycielitoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => PrzydzialNauczycielitoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void PrzywilejtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmPrivilege();

			SetFormProperties(frm);

			PrzywilejtoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => PrzywilejtoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void ObsadatoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmObsada();

			SetFormProperties(frm);

			ObsadatoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => ObsadatoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void PrzydzialKlastoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmSchoolClass();

			SetFormProperties(frm);

			PrzydzialKlastoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => PrzydzialKlastoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void DaneUczniowtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmStudent();

			SetFormProperties(frm);

			DaneUczniowtoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => DaneUczniowtoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void KontrolaOcentoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmKontrolaLiczbyOcen();
			SetFormProperties(frm);
			KontrolaOcentoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => KontrolaOcentoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void KontrolaAbsencjatoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmKontrolaNieobecnosci();
			SetFormProperties(frm);
			KontrolaAbsencjatoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => KontrolaAbsencjatoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void KontrolaWynikitoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmKontrolaOcen();
			SetFormProperties(frm);
			KontrolaWynikitoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => KontrolaWynikitoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void ZbiorczaAnalizaWynikowtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmZbiorczaAnalizaOcen();
			SetFormProperties(frm);
			ZbiorczaAnalizaWynikowtoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => ZbiorczaAnalizaWynikowtoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void ZbiorczyWykazDoEgzaminuPoprawkowegotoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmZbiorczyWykazEgzaminPoprawkowy();
			SetFormProperties(frm);
			ZbiorczyWykazDoEgzaminuPoprawkowegotoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => ZbiorczyWykazDoEgzaminuPoprawkowegotoolStripMenuItem.Enabled = true;
			frm.Show();
		}

		private void WychowawstwotoolStripMenuItem_Click(object sender, EventArgs e)
		{
			var frm = new frmTutor();
			SetFormProperties(frm);
			WychowawstwotoolStripMenuItem.Enabled = false;
			frm.TheEnd += (s, ex) => WychowawstwotoolStripMenuItem.Enabled = true;
			frm.Show();
		}

        private void TypySzkoltoolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSchoolType();
            SetFormProperties(frm);
            TypySzkoltoolStripMenuItem.Enabled = false;
            frm.TheEnd += (s, ex) => TypySzkoltoolStripMenuItem.Enabled = true;
            frm.Show();
        }
    }
}
