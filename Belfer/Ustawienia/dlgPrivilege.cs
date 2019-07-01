using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Belfer.Ustawienia;
using System.Threading.Tasks;
using Autofac;
using DataBaseService;
using Belfer.Administrator.Model;
using Belfer.Ustawienia.Model;
using Belfer.Ustawienia.SQL;

namespace Belfer
{
    public partial class dlgPrivilege : Form
    {
        //public delegate void NewRecord(int RecordID);
        public event NewRecord NewRecordAdded;
        int TeacherId;
        public dlgPrivilege(int TeacherId)
        {
            InitializeComponent();
            this.TeacherId = TeacherId;
            SetDialog();
            ListViewConfig(olvObsada);
            LoadFilterCriteria();
            GenerateColumns(olvObsada, SpecifyCols());
            GetData(olvObsada);
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
        private void LoadFilterCriteria()
        {
            cbSeek.DataSource = new string[] { "Klasa", "Przedmiot" };
        }

        private void ListViewConfig(ObjectListView olv)
        {
            olv.View = View.Details;
            olv.FullRowSelect = true;
            olv.GridLines = true;
            olv.AllowColumnReorder = false;
            olv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            olv.HideSelection = false;
            olv.UseFiltering = true;
            olv.HeaderStyle = ColumnHeaderStyle.Clickable;
            olv.ShowItemToolTips = true;
            olv.HeaderWordWrap = true;
            olv.UseHotItem = true;
            olv.UseTranslucentHotItem = true;
            olv.HeaderMaximumHeight = 80;
            olv.HeaderMinimumHeight = 0;
            HeaderFormatStyle HeaderStyle = new HeaderFormatStyle();
            HeaderStyle.SetFont(new Font(olv.Font.FontFamily, olv.Font.Size, FontStyle.Bold));
            olv.HeaderFormatStyle = HeaderStyle;
            olv.CheckBoxes = true;
        }

        private void GenerateColumns(ObjectListView olv, List<OLVColumn> Cols)
        {
            olv.AllColumns.Clear();
            olv.AllColumns.AddRange(Cols);
            olv.RebuildColumns();
        }

        private List<OLVColumn> SpecifyCols()
        {
            var Cols = new List<OLVColumn>();
            Cols.Add(new OLVColumn { Text = "Klasa", AspectName = "ClassName", MinimumWidth = 100, Width = 150, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Oddział klasowy", UseInitialLetterForGroup = false, IsEditable = false, GroupKeyToTitleConverter = new GroupKeyToTitleConverterDelegate(x => string.Concat("Klasa ", x.ToString())), HeaderCheckBox = true });
            Cols.Add(new OLVColumn { Text = "Przedmiot", WordWrap = true, AspectName = "SubjectName", MinimumWidth = 100, Width = 200, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Przedmiot nauczania", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = false, IsEditable = false });
            Cols.Add(new OLVColumn { Text = "Początek\nuprawnienia", WordWrap = true, AspectName = "StartDate", MinimumWidth = 50, Width = 150, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data początkowa obowiązywania przywieleju dostępu", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = delegate (object cellValue) { return ((DateTime)cellValue).ToShortDateString(); }, IsEditable = true });
            Cols.Add(new OLVColumn { Text = "Koniec\nuprawnienia", WordWrap = true, AspectName = "EndDate", MinimumWidth = 50, Width = 150, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data końcowa obowiązywania przywileju dostępu", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = delegate (object cellValue) { return ((DateTime)cellValue).ToShortDateString(); }, IsEditable = true });
            Cols.Add(new OLVColumn { Text = "Typ", WordWrap = true, AspectName = "PrivilegeType", MinimumWidth = 50, Width = 80, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Rodzaj przywileju", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, IsEditable = true });
            Cols.Add(new OLVColumn { Text = "Status", WordWrap = true, AspectName = "PrivilegeStatus", MinimumWidth = 50, Width = 80, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Status aktywacji przywileju", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = true, IsEditable = true });
            Cols.Add(new OLVColumn { Text = "ID", AspectName = "ID", MinimumWidth = 0, Width = 0, MaximumWidth = 60, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Identyfikator pozycji", Groupable = false, IsEditable = false });

            return Cols;
        }
        private void GetData(ObjectListView olv)
        {
            try
            {
                olv.BeginUpdate();
                olv.SetObjects(GetPrivilegeList().Result);
                olv.EndUpdate();
                //olv.Enabled = olv.Items.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        async Task<IEnumerable<Privilege>> GetPrivilegeList()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(PrivilegeSQL.SelectScheme(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, TeacherId.ToString()), PrivilageModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Privilege PrivilageModel(IDataReader R)
        {
            DateTime.TryParse(R["DataAktywacji"].ToString(), out DateTime startDate);
            DateTime.TryParse(R["DataDeaktywacji"].ToString(), out DateTime endDate);
            return new Privilege()
            {
                ID = Convert.ToInt32(R["ID"]),
                ClassName = R["NazwaKlasy"].ToString(),
                SubjectName = R["Nazwa"].ToString(),
                PrivilegeType = PrivilegeAspect.Główny,
                PrivilegeStatus = User.UserStatus.Aktywny,
                StartDate = startDate,
                EndDate = endDate,
                Creator = new Signature
                {
                    Owner = UserSession.User.Login,
                    User = UserSession.User.Login,
                    IP = AppSession.HostIP
                }
            };
        }

        private void txtSeek_TextChanged(object sender, EventArgs e)
        {
            switch (cbSeek.SelectedIndex)
            {
                case 0://Klasa
                    olvObsada.ModelFilter = new ModelFilter(x => ((Privilege)x).ClassName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 1://Przedmiot
                    olvObsada.ModelFilter = new ModelFilter(x => ((Privilege)x).SubjectName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
            }
        }

        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Select();
        }
        private void olvObsada_CellEditValidating(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "StartDate")
            {
                var D = e.RowObject as Privilege;
                if ((DateTime)e.NewValue > D.EndDate)
                {
                    e.Cancel = true;
                    MessageBox.Show("Data końcowa musi być większa lub równa niż data początkowa!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else if (e.Column.AspectName == "EndDate")
            {
                var D = e.RowObject as Privilege;
                if ((DateTime)e.NewValue < D.StartDate)
                {
                    e.Cancel = true;
                    MessageBox.Show("Data końcowa musi być większa lub równa niż data początkowa!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void olvObsada_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "StartDate" || e.Column.AspectName == "EndDate")
            {
                var C = e.Control as DateTimePicker;
                //var D = new DateRange();
                C.MinDate = (e.RowObject as Privilege).StartDate;
                C.MaxDate = (e.RowObject as Privilege).EndDate;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (AddPrivilege())
            {
                GetData(olvObsada);
                olvObsada.UncheckHeaderCheckBox(olvObsada.AllColumns.Where(x => x.AspectName == "ClassName").First());
            }
        }

        bool AddPrivilege()
        {
            try
            {
                long recordId = 0;
                int recordCount = 0;
                var sqlString = PrivilegeSQL.InsertPrivilege();
                var sqlParamWithValue = new HashSet<IDictionary<string, object>>();
                foreach (Privilege P in olvObsada.CheckedObjects) sqlParamWithValue.Add(CreatePrivilegeParams(P));

                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    var value = dbs.AddManyRecordsAsync(sqlString, sqlParamWithValue).Result;
                    recordCount = value.RecordCount;
                    recordId = value.InsertedRecordId;
                }

                NewRecordAdded?.Invoke(recordId);
                MessageBox.Show($"{recordCount} rekordów zostało dodanych.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private IDictionary<string, object> CreatePrivilegeParams(Privilege p)
        {
            return new Dictionary<string, object>()
            {
                {"@SchemeId", p.ID},
                {"@TeacherId", TeacherId},
                {"@Type", p.PrivilegeType},
                {"@Status", p.PrivilegeStatus},
                {"@StartDate", p.StartDate},
                {"@EndDate", p.EndDate},
                {"@Owner", p.Creator.Owner},
                {"@User", p.Creator.User},
                {"@IP", p.Creator.IP},
            };
        }
    }
}
