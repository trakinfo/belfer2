using Autofac;
using Belfer.Ustawienia;
using DataBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belfer
{
    public partial class dlgSchoolClass : Form
    {
        bool IsNewMode;
        public delegate void NewRecord(int RecordID);
        public event NewRecord NewRecordAdded;

        public dlgSchoolClass(bool NewMode)
        {
            InitializeComponent();
            IsNewMode = NewMode;
            SetDialog();
            if (IsNewMode) LoadSchoolClass();
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
        void LoadSchoolClass()
        {
            try
            {
                //cbKlasa.DataSource = GetClassList().Result;
                cbKlasa.DataSource = GetClassList().Result.ToList();
                cbKlasa.Enabled = cbKlasa.Items.Count > 0;
                cbKlasa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static async Task<IEnumerable<string>> GetClassList()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(SchoolClassSQL.SelectClassCombo(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear), (R) => R["Kod"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cbKlasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNazwa.Text = cbKlasa.Text;
        }

        private void txtNazwa_TextChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = txtNazwa.Text.Length > 0;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (IsNewMode)
            {
                try
                {
                    var recordID = AddSchoolClass().Result;
                    if (recordID > 0)
                    {
                        NewRecordAdded?.Invoke(recordID);
                        cmdOK.Enabled = false;
                        LoadSchoolClass();
                        cbKlasa_SelectedIndexChanged(cbKlasa, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        async Task<int> AddSchoolClass()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.AddRecordAsync(SchoolClassSQL.InsertSchoolClass(), CreateInsertParams());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        IDictionary<string,object> CreateInsertParams()
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@IdSzkola", UserSession.User.Settings.SchoolID);
            sqlParamWithValue.Add("@KodKlasy", cbKlasa.Text);
            sqlParamWithValue.Add("@RokSzkolny", UserSession.User.Settings.SchoolYear);
            sqlParamWithValue.Add("@NazwaKlasy", txtNazwa.Text.Trim());
            sqlParamWithValue.Add("@IsVirtual", chkVirtual.Checked);
            sqlParamWithValue.Add("@Owner", UserSession.User.Login);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }
    }
}
