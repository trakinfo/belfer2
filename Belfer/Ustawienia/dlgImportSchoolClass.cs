using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Belfer.Ustawienia;
using Autofac;
using DataBaseService;
using Belfer.DataBaseContext;
using System.Threading.Tasks;

namespace Belfer
{
    public partial class dlgImportSchoolClass : Form
    {

        public dlgImportSchoolClass()
        {
            InitializeComponent();
            SetDialog();
            LoadFilterCriteria();
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
            if (AddSubjectScheme() > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void LoadFilterCriteria()
        {
            cbSeek.DataSource = new string[] { "Kod klasy", "Nazwa klasy", "Klasa wirtualna" };
        }
        private void nudStartYear_ValueChanged(object sender, EventArgs e)
        {
            nudEndYear.Value = nudStartYear.Value + 1;
            GetData(olvKlasa);
        }
        private void GetData(ObjectListView olv)
        {
            try
            {
                olv.BeginUpdate();
                olv.SetObjects(GetSubjectList().Result);
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
                lblRecord.Text = "0 z " + olv.Items.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        async Task<IEnumerable<SchoolClass>> GetSubjectList()
        {
            try
            {
                var PreviousSchoolYear = $"{nudStartYear.Value}/{nudEndYear.Value}";
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(SchoolClassSQL.SelectSchoolClassList(UserSession.User.Settings.SchoolID.ToString(), PreviousSchoolYear), (R) => new SchoolClass
                    {
                        ClassName = R["NazwaKlasy"].ToString(),
                        ClassCode = R["KodKlasy"].ToString(),
                        IsVirtual = (YesNo)Convert.ToInt64(R["IsVirtual"])
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void txtSeek_TextChanged(object sender, EventArgs e)
        {
            switch (cbSeek.SelectedIndex)
            {
                case 0://Kod klasy
                    olvKlasa.ModelFilter = new ModelFilter(x => ((SchoolClass)x).ClassCode.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 1://Nazwa klasy
                    olvKlasa.ModelFilter = new ModelFilter(x => ((SchoolClass)x).ClassName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 2: //IsVirtual
                    olvKlasa.ModelFilter = new ModelFilter(x => ((SchoolClass)x).IsVirtual.ToString().StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
            }
            lblRecord.Text = "0 z " + olvKlasa.GetItemCount();
        }

        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Select();
        }
        int AddSubjectScheme()
        {
            try
            {
                var sqlParamWithValue = new HashSet<IDictionary<string, object>>();
                foreach (SchoolClass S in olvKlasa.FilteredObjects)
                    sqlParamWithValue.Add(new Dictionary<string, object>()
                    {
                        {"@IdSzkola", UserSession.User.Settings.SchoolID },
                        {"@KodKlasy", S.ClassCode },
                        {"@RokSzkolny", UserSession.User.Settings.SchoolYear },
                        {"@NazwaKlasy", S.ClassName },
                        {"@IsVirtual", S.IsVirtual },
                        {"@Owner", UserSession.User.Login },
                        {"@User", UserSession.User.Login },
                        {"@IP", AppSession.HostIP }
                    });
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return dbs.AddManyRecordsAsync(SchoolClassSQL.InsertSchoolClass(), sqlParamWithValue).Result.RecordCount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            olvKlasa.RemoveObjects(olvKlasa.SelectedObjects);
        }
    }

}
