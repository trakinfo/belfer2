using Autofac;
using Belfer.DataBaseContext;
using Belfer.Ustawienia;
using Belfer.Ustawienia.SQL;
using DataBaseService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belfer
{
    public partial class dlgSchoolType : Form
    {
        internal bool IsNewMode;

        public event NewRecord NewRecordAdded;
        public dlgSchoolType()
        {
            InitializeComponent();
            SetDialog();
        }
        void SetDialog()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MinimizeBox = false;
            MaximizeBox = false;
            CancelButton = cmdCancel;
            AcceptButton = cmdOK;
            cmdOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmdCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
                    var recordID = AddSchoolType(txtNazwa.Text, txtOpis.Text).Result;
                    if (recordID > 0)
                    {
                        NewRecordAdded?.Invoke(recordID);
                        ClearControls();
                        txtNazwa.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ClearControls()
        {
            txtNazwa.Text = string.Empty;
            txtOpis.Text = string.Empty;
        }

        private void TxtNazwa_TextChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = txtNazwa.Text.Trim().Length > 0;
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        async Task<long> AddSchoolType(string nazwa, string opis)
        {
            try
            {
                var sqlString = SchoolSQL.InsertSchoolType();
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.AddRecordAsync(sqlString, CreateInsertParams(nazwa,opis));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        IDictionary<string,object> CreateInsertParams(string nazwa, string opis)
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@Typ", nazwa);
            sqlParamWithValue.Add("@Opis", opis);
            sqlParamWithValue.Add("@Owner", UserSession.User.Login);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }
    }
}
