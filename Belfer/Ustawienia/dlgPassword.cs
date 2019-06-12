using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;

namespace Belfer
{
	public partial class dlgPassword : Form
	{
		bool AdminMode;
		public dlgPassword()
		{
			InitializeComponent();
			AdminMode = true;
			Height = 185;
			LoadUserList();
		}
		public dlgPassword(User UserData, bool adminMode)
		{
			InitializeComponent();
			AdminMode = adminMode;
			cbUserName.Items.Add(UserData);
			cbUserName.SelectedItem = UserData;
			cbUserName.Enabled = false;
			if (!AdminMode)
			{
				ShowControls();
				Text = "Zmiana hasła";
			}
		}
		void ShowControls()
		{
			txtOldPassword.Visible = true;
			lblOldPassword.Visible = true;
			txtOldPassword.Text = "";
			Height = 211;
		}
		void LoadUserList()
		{
			//cbUserName.SelectionChangeCommitted += (s, e) => txtNewPassword.Focus();
			cbUserName.AutoCompleteMode = AutoCompleteMode.Append;
			cbUserName.AutoCompleteSource = AutoCompleteSource.ListItems;
			cbUserName.DataSource = AppSession.Users.ToList();
			cbUserName.DropDownStyle = ComboBoxStyle.DropDownList;
			cbUserName.SelectedIndex = -1;
		}
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!AdminMode)
				{
					AuthenticateUser(txtOldPassword.Text);
					VerifyPassword(txtNewPassword.Text);
				}
				if (CompareStrings(txtNewPassword.Text, txtRepeatPassword.Text)) DialogResult = DialogResult.OK;
			}

			catch (System.ArgumentNullException ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			catch (System.ArgumentOutOfRangeException ex)
			{
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			catch (System.Exception)
			{
				throw;
			}
			
		}

		void AuthenticateUser(string pwd)
		{
			var msg = "Procedura zmiany hasła wymaga autoryzacji użytkownika! \nW polu 'Stare hasło' podaj hasło dotychczasowe.";
			if (!Authentication.AuthenticateUser(UserSession.User.Password, pwd)) throw new System.ArgumentNullException("Password", msg);
		}

		void VerifyPassword(string pwd)
		{
			var MinLength = AppVars.MinPwdLength;
			var pattern = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{" + MinLength + ",}";
			Regex rgx = new Regex(pattern);
			var msg = "Hasło musi mieć co najmniej " + MinLength.ToString() + " znaków, w tym co najmniej jedną cyfrę, jedną wielką i jedną małą literę!\n";
			if (!rgx.IsMatch(pwd)) throw new System.ArgumentOutOfRangeException("PasswordLength", msg);
		}

		bool CompareStrings(string S1, string S2)
		{
			if (string.Equals(S1, S2)) return true;
			MessageBox.Show("Wartości pól 'Nowe hasło' i 'Powtórz hasło' muszą być takie same!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return false;
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void txtUserName_TextChanged(object sender, System.EventArgs e)
		{
			cmdOK.Enabled = txtNewPassword.Text.Length > 0 && txtRepeatPassword.Text.Length > 0;
		}
	}
}
