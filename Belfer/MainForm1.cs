using System.Windows.Forms;
using System.Linq;
using System;
using Belfer.DataBaseContext;

namespace Belfer
{
    public partial class MainForm
	{
		private void SetFormProperties(Form frm)
		{
			frm.Icon = AppVars.AppIcon;
			frm.MdiParent = this;
			frm.MaximizeBox = true;
			frm.StartPosition = FormStartPosition.CenterScreen;
			frm.FormBorderStyle = FormBorderStyle.Sizable;
			frm.WindowState = FormWindowState.Normal;
		}
		void SetApplicationInfo()
		{
			Icon = AppVars.AppIcon;
			Text = Text + " - wersja " + AppVars.AppVersion.ToString();
            SetConnectionStatus(null, new System.Data.StateChangeEventArgs(System.Data.ConnectionState.Closed, System.Data.ConnectionState.Closed));
            statServer.Text = Enigma.CryptoHelper.Decrypt(Properties.Settings.Default.ServerIP);
			statBaza.Text = Enigma.CryptoHelper.Decrypt(Properties.Settings.Default.DBName);
			statStacja.Text = $"{AppSession.HostIP} ({AppSession.HostName})";
		}
		void SetUserSessionInfo()
		{
			statUser.Text = UserSession.User.ToString();
			statRola.Text = UserSession.User.Role.ToString();
			//statStacja.Text = string.Concat(AppSession.HostIP, " (", AppSession.HostName, ")");
			SetWorkingParams();
		}
		void ResetUserSessionInfo()
		{
			ResetWorkingParams();
			statUser.Text = null;
			statRola.Text = null;
			//statStacja.Text = null;
		}
		void SetWorkingParams()
		{
			try
			{
				lblRokSzkolny.Text = UserSession.User.Settings.SchoolYear;
				var SchoolId = UserSession.User.SchoolTokenList.Where(x => x.SchoolID == UserSession.User.Settings.SchoolID).FirstOrDefault().SchoolID;
				var School = AppSession.Schools.Where(x => x.ID == SchoolId).FirstOrDefault();
				lblSchoolName.Text = School.Name;
			}
			catch (NullReferenceException)
			{
				UserSession.User.Settings.SchoolID = 0;
				lblSchoolName.Text = "";
			}
			catch (Exception)
			{

				throw;
			}
		
		}
		void ResetWorkingParams()
		{
			lblRokSzkolny.Text = null;
			lblSchoolName.Text = null;
		}

		void SetConnectionStatus(object sender, System.Data.StateChangeEventArgs e)
		{
			switch (e.CurrentState)
			{
				case System.Data.ConnectionState.Closed:
					statConn.Image = Properties.Resources.ConnClosed;
					statConn.ForeColor = System.Drawing.Color.Red;
					statConn.Text = "Zamknięte";
					statSSL.Image = null;
					statSSL.Text = null;
					break;
				case System.Data.ConnectionState.Open:
					statConn.Image = Properties.Resources.ConnOpen;
					statConn.ForeColor = System.Drawing.Color.Green;
					statConn.Text = "Otwarte";
					SetSslStatus();
					break;
				case System.Data.ConnectionState.Connecting:
					statConn.Image = Properties.Resources.ConnConnecting;
					statConn.ForeColor = System.Drawing.Color.Blue;
					statConn.Text = "Łączenie...";
					break;
				case System.Data.ConnectionState.Executing:
					statConn.ForeColor = System.Drawing.Color.Green;
					statConn.Text = "Wykonywanie polecenia";
					break;
				case System.Data.ConnectionState.Fetching:
					statConn.ForeColor = System.Drawing.Color.Green;
					statConn.Text = "Pobieranie danych";
					break;
				case System.Data.ConnectionState.Broken:
					lblConn.Image = Properties.Resources.ConnClosed;
					statConn.ForeColor = System.Drawing.Color.Red;
					statConn.Text = "Zerwane";
					break;
				default:
					break;
			}
		}

		private void SetSslStatus()
		{
			var SSL = AppSession.SslCipher;
			if (string.IsNullOrEmpty(SSL))
			{
				statSSL.Image = Properties.Resources.NoSSL;
				statSSL.Text = "Brak szyfrowania";
			}
			else
			{
				statSSL.Image = Properties.Resources.SSL;
				statSSL.Text = SSL;
			}
		}
		//private void Reconnect()
		//{
		//	try
		//	{
		//		if (AppSession.Conn.State==System.Data.ConnectionState.Closed)
		//		{
		//			AppSession.Conn.Open();
		//		}
		//	}
		//	catch (MySql.Data.MySqlClient.MySqlException ex)
		//	{
		//		MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
		//	}
		//	catch (Exception)
		//	{

		//		throw;
		//	}

		//}
		void Logout()
		{
			CloseForms();
			ResetUserSessionInfo();
			SetApplicationPrivileges(false);
			EnableControls(false);
			Authentication.Logout().Wait();
			Opacity = 0.7;
			WindowState = FormWindowState.Normal;
			Login();
		}

		private void CloseForms()
		{
			var OF = Application.OpenForms.Cast<Form>().Where(form => form.Name != this.Name).ToList();
			OF.ForEach(x => x.Close());
		}

		void Login()
		{
			try
			{
				if (Authentication.Login().Result)
				{
					ReviseUserRole();
					SetUserSessionInfo();
					EnableControls(true);
					SetApplicationPrivileges(true);
					Opacity = 1;
					WindowState = FormWindowState.Maximized;
					return;
				}
				Application.Exit();
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			
		}

		private void ReviseUserRole()
		{
			try
			{
				var SchoolRole = UserSession.User.SchoolTokenList.Where(x => x.SchoolID == UserSession.User.Settings.SchoolID).FirstOrDefault().UserRole;
				if (SchoolRole != UserSession.User.Role) UserSession.User.Role = SchoolRole;
			}
			catch (NullReferenceException)
			{
				return;
			}

		}

		private void SetApplicationPrivileges(bool enable)
		{
			switch (UserSession.User.Role)
			{
				case AppUser.UserRole.Czytelnik:
					EnableMenu(enable);
					break;
				case AppUser.UserRole.Nauczyciel:
					EnableEditorMenu(enable);
					break;
				case AppUser.UserRole.Operator:
					EnableOperatorMenu(enable);
					break;
				case AppUser.UserRole.Administrator:
					EnableAdminMenu(enable);
					break;
				default:
					break;
			}
		}

		private void EnableAdminMenu(bool v)
		{
			ZasobytoolStripMenuItem.Enabled = v;
			AdmintoolStripMenuItem.Enabled = v;
            StrukturatoolStripMenuItem.Enabled = v;
			SzkolatoolStripMenuItem.Enabled = v;
			EnableOperatorMenu(v);
		}

		private void EnableOperatorMenu(bool v)
		{
			if (UserSession.User.Settings.SchoolID > 0)
			{
				NadzortoolStripMenuItem.Enabled = v;
				ZasobySzkolytoolStripMenuItem.Enabled = v;
				ObsadatoolStripMenuItem.Enabled = v;
				PrzywilejtoolStripMenuItem.Enabled = v;
				WychowawstwotoolStripMenuItem.Enabled = v;
				HarmonogramtoolStripMenuItem.Enabled = v;
				SkalaOcentoolStripMenuItem.Enabled = v;
			}
			//SzkolytoolStripMenuItem.Enabled = v;
			//DaneSzkolytoolStripMenuItem.Enabled = v;
			EnableEditorMenu(v);
		}

		private void EnableEditorMenu(bool v)
		{
			if (UserSession.User.Settings.SchoolID > 0)
			{
				tsQuickAccess.Enabled = v;
				DzienniktoolStripMenuItem.Enabled = v;
			}
			EnableMenu(v);
		}

		private void EnableMenu(bool v)
		{
			if (UserSession.User.Settings.SchoolID > 0)
			{
				StatystykatoolStripMenuItem.Enabled = v;
			}
			UstawieniatoolStripMenuItem.Enabled = v;
		}


		void EnableControls(bool Status)
		{
			MainMenu.Enabled = Status;
			tlpParametersInfo.Enabled = Status;
			tlpQuickAccess.Enabled = Status;
			tlpStatus.Enabled = Status;
		}

	}
}
