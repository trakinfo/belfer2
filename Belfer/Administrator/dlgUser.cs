using Autofac;
using Belfer.Administrator;
using Belfer.DataBaseContext;
using DataBaseService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belfer
{
    public partial class dlgUser : Form
    {
        public dlgUser()
        {
            InitializeComponent();
        }
        internal bool IsNewMode;
        public delegate void NewRecord(string RecordID);
        public event NewRecord NewRecordAdded;

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = txtLogin.Text.Trim().Length > 0;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!IsNewMode)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                try
                {
                    if (!CompareStrings(txtPassword.Text.Trim(), txtPassword2.Text.Trim())) return;
                    if (!StringHelper.ValidatePassword(txtPassword.Text.Trim()))
                    {
                        var msg = "Hasło musi mieć co najmniej " + AppVars.MinPwdLength.ToString() + " znaków, w tym co najmniej jedną cyfrę, jedną wielką i jedną małą literę!";
                        MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var RecordID = AddUser().Result;
                    if (RecordID > 0)
                    {
                        NewRecordAdded?.Invoke(txtLogin.Text.Trim());
                        ClearControls();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        bool CompareStrings(string S1, string S2)
        {
            if (string.Equals(S1, S2)) return true;
            MessageBox.Show("Wartości pól 'Hasło' i 'Powtórz hasło' muszą być takie same!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        private void ClearControls()
        {
            foreach (var Ctrl in pnlUser.Controls)
            {
                if (Ctrl is TextBox) ((TextBox)Ctrl).Text = null;
            }
        }

        async Task<long> AddUser()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.AddRecordAsync(UserSQL.InsertUser(), CreateInsertParams());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        IDictionary<string, object> CreateInsertParams()
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            var SaltedPasswordHash = Enigma.HashHelper.CreatePassword(txtPassword.Text.Trim());
            User.UserRole R = (User.UserRole)Enum.Parse(typeof(User.UserRole), cbRola.SelectedValue.ToString());
            sqlParamWithValue.Add("@Login", txtLogin.Text.Trim());
            sqlParamWithValue.Add("@LastName", txtNazwisko.Text.Trim());
            sqlParamWithValue.Add("@FirstName", txtImie.Text.Trim());
            sqlParamWithValue.Add("@Password", Convert.ToBase64String(SaltedPasswordHash));
            sqlParamWithValue.Add("@Role", R);
            sqlParamWithValue.Add("@Status", chkStatus.Checked);
            sqlParamWithValue.Add("@Sex", chkSex.Checked);
            sqlParamWithValue.Add("@Faximile", pbFaximile.Image);
            sqlParamWithValue.Add("@Email", txtEmail.Text.Trim());
            sqlParamWithValue.Add("@Owner", UserSession.User.Login);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtPassword2.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtPassword2.PasswordChar = '*';
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Length == 0) return;
            if (StringHelper.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("Nieprawidłowy adres e-mail. Wpisz poprawny adres lub pozostaw pole puste!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void cmdPwdGen_Click(object sender, EventArgs e)
        {
            try
            {
                txtPassword.Text = StringHelper.RandomizePassword();
                txtPassword2.Text = txtPassword.Text;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtLogin_Validating(object sender, CancelEventArgs e)
        {
            if (txtLogin.Text.Trim().Length == 0 || !IsNewMode) return;
            if (CheckLoginExist(txtLogin.Text.Trim()))
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("Podany login jest zajęty. Spróbuj wprowadzić inny!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        internal static bool CheckLoginExist(string Login)
        {
            //int UserCount = 0;
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    int.TryParse(dbs.FetchSingleValueAsync(UserSQL.CountUser(Login)).Result, out int userCount);
                    return userCount == 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            //using (var cmd = new MySql.Data.MySqlClient.MySqlCommand() { CommandText = UserSQL.CountUser(Login), Connection = AppSession.Conn })
            //{
            //    int.TryParse(cmd.ExecuteScalar().ToString(), out UserCount);
            //    return UserCount == 0;
            //}
        }

    }
}
