using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Belfer.DataBaseContext;
using Belfer.Helpers;
using Belfer.Ustawienia;
using Belfer.Ustawienia.SQL;
using DataBaseService;

namespace Belfer
{
    public partial class dlgObsada : Form
    {
        bool IsNewMode;
        //public delegate void NewRecord(int RecordID);
        public event NewRecord NewRecordAdded;
        //public DateRange SchoolYearDateRange;
        public dlgObsada(bool NewMode)
        {
            InitializeComponent();
            IsNewMode = NewMode;
            SetDialog();
            SetDate();
            if (IsNewMode) LoadComboBox(cbKlasa, GetClassList().Result.ToArray());
            chkKategoria.Checked = true;
            chkAvg.Checked = true;
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
        void SetDate()
        {
            var SchoolYearDateRange = new DateRange();
            dtStartDate.MinDate = SchoolYearDateRange.StartDate;
            dtStartDate.MaxDate = SchoolYearDateRange.EndDate;
            dtEndDate.MinDate = SchoolYearDateRange.StartDate;
            dtEndDate.MaxDate = SchoolYearDateRange.EndDate;

            dtStartDate.Value = SchoolYearDateRange.StartDate;
            dtEndDate.Value = SchoolYearDateRange.EndDate;
        }
        void LoadComboBox(ComboBox cb, Object[] comboList)
        {
            cb.Items.Clear();
            cb.Items.AddRange(comboList);
            cb.Enabled = cb.Items.Count > 0;
            cb.SelectedIndex = -1;
        }
        public static async Task<IEnumerable<SchoolClass>> GetClassList()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(SchoolClassSQL.SelectSchoolClassCombo(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear), (R) => new SchoolClass()
                    {
                        ID = Convert.ToInt32(R["ID"]),
                        ClassCode = R["KodKlasy"].ToString(),
                        ClassName = R["NazwaKlasy"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new HashSet<SchoolClass>();
            }
        }

        public void cbKlasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ClassId = ((SchoolClass)(((ComboBox)sender).SelectedItem)).ID;
            LoadComboBox(cbPrzedmiot, GetSubjectList(ClassId.ToString()).Result.ToArray());
            cmdOK.Enabled = false;
        }

        async Task<IEnumerable<Subject>> GetSubjectList(string ClassId)
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(SubjectSQL.SelectSchoolSubject(UserSession.User.Settings.SchoolID.ToString(), ClassId), (R) => new Subject()
                    {
                        ID = Convert.ToInt32(R["ID"]),
                        Alias = R["Alias"].ToString()
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new HashSet<Subject>();
            }
        }

        private void cbPrzedmiot_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = true;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (IsNewMode)
            {
                var IdList = new List<int>();
                if (chkPion.Checked)
                {
                    IdList = cbKlasa.Items.Cast<SchoolClass>().Where(x => x.ClassCode.Substring(0, 1) == ((SchoolClass)cbKlasa.SelectedItem).ClassCode.Substring(0, 1)).Select(x => x.ID).ToList();
                }
                else
                {
                    IdList.Add(((SchoolClass)cbKlasa.SelectedItem).ID);
                }
                var RecordID = AddSubjectScheme(IdList).Result.Item2;
                if (RecordID > 0)
                {
                    NewRecordAdded?.Invoke(RecordID);
                    cmdOK.Enabled = false;
                    cbKlasa_SelectedIndexChanged(cbKlasa, e);
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        async Task<(int,long)> AddSubjectScheme(List<int> ClassId)
        {
            try
            {
                var sqlString = SubjectSchemeSQL.InsertScheme();

                var sqlParamWithValue = new HashSet<IDictionary<string, object>>();
                foreach (var ID in ClassId) sqlParamWithValue.Add(CreateSubjectParams(ID));

                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.AddManyRecordsAsync(sqlString, sqlParamWithValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0,-1);
            }

        }

        private IDictionary<string, object> CreateSubjectParams(int idClass)
        {
            var schemeParams = new Dictionary<string, object>();
            schemeParams.Add("@Klasa", idClass);
            schemeParams.Add("@Przedmiot", ((Subject)cbPrzedmiot.SelectedItem).ID);
            schemeParams.Add("@Grupa", chkGrupa.Checked);
            schemeParams.Add("@Kategoria", chkKategoria.Checked ? "o" : "n");
            schemeParams.Add("@Avg", chkAvg.Checked);
            schemeParams.Add("@StartDate", dtStartDate.Value);
            schemeParams.Add("@EndDate", dtEndDate.Value);
            schemeParams.Add("@LiczbaGodzin", nudLiczbaGodzin.Value);
            schemeParams.Add("@Owner", UserSession.User.Login);
            schemeParams.Add("@User", UserSession.User.Login);
            schemeParams.Add("@IP", AppSession.HostIP);
            return schemeParams;
        }
    }
}
