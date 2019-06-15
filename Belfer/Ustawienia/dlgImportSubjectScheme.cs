using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Belfer.Ustawienia;
using System.Threading.Tasks;
using DataBaseService;
using Autofac;

namespace Belfer
{
    public partial class dlgImportSubjectScheme : Form
    {

        public dlgImportSubjectScheme()
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
            var Count = AddSubjectScheme().Result.Item1;
            if (Count > 0)
            {
                var msg = $"Dodano rekordów: {Count}";
                MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void LoadFilterCriteria()
        {
            cbSeek.DataSource = new string[] { "Klasa", "Przedmiot" };
        }
        private void nudStartYear_ValueChanged(object sender, EventArgs e)
        {
            nudEndYear.Value = nudStartYear.Value + 1;
            GetData(olvObsada);
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
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        async Task<IEnumerable<SubjectSchemeImport>> GetSubjectList()
        {
            try
            {
                var PreviousSchoolYear = string.Concat(nudStartYear.Value, "/", nudEndYear.Value);
                var CurrentSchoolYearDateRange = new DateRange();
                var CurrentClassList = dlgObsada.GetClassList().Result.ToList();
                string CurrentClassString = null;
                CurrentClassList.ForEach(x => CurrentClassString += $"'{x.ClassCode}',");
                CurrentClassString = CurrentClassString.Trim(',');

                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(SubjectSchemeSQL.SelectScheme(UserSession.User.Settings.SchoolID.ToString(), PreviousSchoolYear, CurrentClassString), (R) => new SubjectSchemeImport
                    {
                        ClassName = R["NazwaKlasy"].ToString(),
                        SubjectName = R["Nazwa"].ToString(),
                        Group = (YesNo)Convert.ToInt64(R["Grupa"]),
                        SubjectCategory = R["Kategoria"].ToString(),
                        ToAvg = (YesNo)Convert.ToInt64(R["GetToAverage"]),
                        StartDate = CurrentSchoolYearDateRange.StartDate,
                        EndDate = CurrentSchoolYearDateRange.EndDate,
                        LessonCount = Convert.ToSingle(R["LiczbaGodzin"]),
                        ClassID = CurrentClassList.Where(x => x.ClassCode == R["KodKlasy"].ToString()).First().ID,
                        SubjectID = Convert.ToInt32(R["Przedmiot"])
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
                case 0://Klasa
                    olvObsada.ModelFilter = new ModelFilter(x => ((SubjectScheme)x).ClassName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 1://Przedmiot
                    olvObsada.ModelFilter = new ModelFilter(x => ((SubjectScheme)x).SubjectName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
            }
            lblRecord.Text = "0 z " + olvObsada.GetItemCount();
        }

        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Select();
        }
        async Task<(int,long)> AddSubjectScheme()
        {
            try
            {
                var sqlString = SubjectSchemeSQL.InsertScheme();                
                var sqlParamWithValue = new HashSet<IDictionary<string, object>>();

                foreach (SubjectSchemeImport S in olvObsada.CheckedObjects) sqlParamWithValue.Add(CreateSubjectParams(S));

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
        private IDictionary<string, object> CreateSubjectParams(SubjectSchemeImport S)
        {
            var schemeParams = new Dictionary<string, object>();
            schemeParams.Add("@Klasa", S.ClassID);
            schemeParams.Add("@Przedmiot", S.SubjectID);
            schemeParams.Add("@Grupa", S.Group);
            schemeParams.Add("@Kategoria", S.SubjectCategory);
            schemeParams.Add("@Avg", S.ToAvg);
            schemeParams.Add("@StartDate", S.StartDate);
            schemeParams.Add("@EndDate", S.EndDate);
            schemeParams.Add("@LiczbaGodzin", S.LessonCount);
            schemeParams.Add("@Owner", UserSession.User.Login);
            schemeParams.Add("@User", UserSession.User.Login);
            schemeParams.Add("@IP", AppSession.HostIP);
            return schemeParams;
        }
        private void olvObsada_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "LessonCount")
            {
                var C = e.Control as NumericUpDown;
                C.Minimum = 0.5m;
                C.Maximum = 100m;
                C.Increment = 0.5m;
            }
            else if (e.Column.AspectName == "StartDate" || e.Column.AspectName == "EndDate")
            {
                var C = e.Control as DateTimePicker;
                var D = new DateRange();
                C.MinDate = D.StartDate;
                C.MaxDate = D.EndDate;
            }
        }

        private void olvObsada_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "LessonCount")
            {
                var R = e.RowObject as SubjectScheme;
                R.LessonCount = Convert.ToSingle(e.NewValue);
                e.Cancel = true;
                olvObsada.RefreshObject(e.RowObject);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            olvObsada.RemoveObjects(olvObsada.CheckedObjects);
        }

        private void olvObsada_CellEditValidating(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "StartDate")
            {
                var D = e.RowObject as SubjectScheme;
                if ((DateTime)e.NewValue > D.EndDate)
                {
                    e.Cancel = true;
                    MessageBox.Show("Data końcowa musi być większa lub równa od daty początkowej!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else if (e.Column.AspectName == "EndDate")
            {
                var D = e.RowObject as SubjectScheme;
                if ((DateTime)e.NewValue < D.StartDate)
                {
                    e.Cancel = true;
                    MessageBox.Show("Data końcowa musi być większa lub równa od daty początkowej!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
    public class SubjectSchemeImport : SubjectScheme
    {
        public int ClassID { get; set; }
        public int SubjectID { get; set; }
    }
}
