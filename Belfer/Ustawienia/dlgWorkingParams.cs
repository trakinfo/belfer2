using System.Windows.Forms;
using System;
using System.Linq;
using Belfer.Administrator.Model;

namespace Belfer
{
    public partial class dlgWorkingParams : Form
	{
		public static event EventHandler ConfigurationChanged;
		public dlgWorkingParams(AppUser.UserSettings Settings)
		{
			InitializeComponent();
			LoadSchool();
			nudStartYear.Value = Settings.Year; 
			cbSzkola.SelectedItem = AppSession.Schools.Where(x => x.ID == Settings.SchoolID).FirstOrDefault();
			nudStartYear.Select();
		}

		void LoadSchool()
		{
			UserSession.User.SchoolTokenList.ToList().ForEach(t => cbSzkola.Items.Add(AppSession.Schools.Where(s => s.ID == t.SchoolID).FirstOrDefault()));
			cbSzkola.Enabled = cbSzkola.Items.Count > 0;
		}
		private void cbSzkola_SelectedIndexChanged(object sender, EventArgs e)
		{
			OK_Button.Enabled = cbSzkola.SelectedItem != null;
		}

		private void OK_Button_Click(object sender, EventArgs e)
		{
			ConfigurationChanged?.Invoke(sender, e);
			DialogResult = DialogResult.OK;
		}

		private void nudStartYear_ValueChanged(object sender, EventArgs e)
		{
			nudEndYear.Value = nudStartYear.Value + 1;
		}

		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
