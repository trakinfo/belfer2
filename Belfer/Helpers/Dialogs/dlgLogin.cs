using System.Windows.Forms;

namespace Belfer
{
	public partial class dlgLogin : Form
	{
		public dlgLogin()
		{
			InitializeComponent();
			Icon = AppVars.AppIcon;
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void txtUserName_TextChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0;
		}
	}
}
