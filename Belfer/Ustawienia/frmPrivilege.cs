using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Belfer.Ustawienia;
using Autofac;
using DataBaseService;
using Belfer.Administrator.Model;
using Belfer.Helpers;
using Belfer.Ustawienia.Model;

namespace Belfer
{
    public partial class frmPrivilege : Form
    {
        public event EventHandler TheEnd;
        byte Target = 0;
        public frmPrivilege()
        {
            InitializeComponent();
            AppUser.UserSettings.RaiseConfigChanged += ApplyNewConfig;
            lblRecord.Text = "";
            ListViewConfig(olvUser);
            ListViewConfig(olvPrivilege);
            ListViewConfig(olvExclusion);
            LoadFilterCriteria(Target);

            GenerateColumns(olvUser, SpecifyUserCols());
            GenerateColumns(olvPrivilege, SpecifyPrivilegeCols());
            GenerateColumns(olvExclusion, SpecifyExclusionCols());
            ApplyNewConfig(this, null);
        }

        private void ApplyNewConfig(object sender, EventArgs e)
        {
            GetData(olvUser, GetTeacherListAsync().Result);
        }

        private void LoadFilterCriteria(byte target)
        {
            var itemList = new List<KeyValuePair<string, string>>();
            itemList.Add(new KeyValuePair<string, string>("ClassName", "Klasa"));
            itemList.Add(new KeyValuePair<string, string>("SubjectName", "Przedmiot"));
            switch (target)
            {
                case 0:
                    itemList.Add(new KeyValuePair<string, string>("PrivilegeType", "Typ"));
                    itemList.Add(new KeyValuePair<string, string>("PrivilegeStatus", "Status"));
                    break;
                case 1:
                    itemList.Add(new KeyValuePair<string, string>("StudentName", "Nazwisko i imię ucznia"));
                    break;
            }
            cbSeek.DataSource = itemList;
            cbSeek.ValueMember = "Key";
            cbSeek.DisplayMember = "Value";
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
        }

        private void GenerateColumns(ObjectListView olv, List<OLVColumn> Cols)
        {
            olv.AllColumns.Clear();
            olv.AllColumns.AddRange(Cols);
            olv.RebuildColumns();
        }

        private List<OLVColumn> SpecifyUserCols()
        {
            var Cols = new List<OLVColumn>();
            Cols.Add(new OLVColumn { Text = "Nazwisko i imię", WordWrap = true, AspectName = "Name", MinimumWidth = 100, Width = 240, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię użytkownika", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "ID", AspectName = "ID", MinimumWidth = 0, MaximumWidth = 50, Width = 0, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Identyfikator użytkownika w szkole", UseInitialLetterForGroup = false });
            return Cols;
        }
        private List<OLVColumn> SpecifyPrivilegeCols()
        {
            var Cols = new List<OLVColumn>();
            Cols.Add(new OLVColumn { Name = "Klasa", Text = "Klasa", WordWrap = true, AspectName = "ClassName", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa oddziału klasowego", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = false, GroupKeyToTitleConverter = (x) => { return string.Concat("Klasa ", x.ToString()); } });
            Cols.Add(new OLVColumn { Text = "Przedmiot", WordWrap = true, AspectName = "SubjectName", MinimumWidth = 100, Width = 100, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa przedmiotu nauczania", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = false });
            Cols.Add(new OLVColumn { Text = "Typ", WordWrap = true, AspectName = "PrivilegeType", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Rodzaj przywileju", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false });
            Cols.Add(new OLVColumn { Text = "Status", WordWrap = true, AspectName = "PrivilegeStatus", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Status przywileju", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false });
            Cols.Add(new OLVColumn { Text = "Data początkowa", WordWrap = true, AspectName = "StartDate", MinimumWidth = 50, Width = 90, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data początkowa obowiązywania przywileju", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = delegate (object cellValue) { return ((DateTime)cellValue).ToShortDateString(); } });
            Cols.Add(new OLVColumn { Text = "Data końcowa", WordWrap = true, AspectName = "EndDate", MinimumWidth = 50, Width = 90, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data końcowa obowiązywania przywileju", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = delegate (object cellValue) { return ((DateTime)cellValue).ToShortDateString(); } });
            Cols.Add(new OLVColumn { Text = "ID", AspectName = "ID", MinimumWidth = 0, MaximumWidth = 50, Width = 0, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Identyfikator przywileju", UseInitialLetterForGroup = false });

            return Cols;
        }
        private List<OLVColumn> SpecifyExclusionCols()
        {
            var Cols = new List<OLVColumn>();
            Cols.Add(new OLVColumn { Name = "Klasa", Text = "Klasa", WordWrap = true, AspectName = "ClassName", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa oddziału klasowego", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = false, GroupKeyToTitleConverter = delegate (object x) { return string.Concat("Klasa ", x.ToString()); } });
            Cols.Add(new OLVColumn { Text = "Przedmiot", WordWrap = true, AspectName = "SubjectName", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa przedmiotu nauczania", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = false });
            Cols.Add(new OLVColumn { Text = "Nazwisko i imię", WordWrap = true, AspectName = "StudentName", MinimumWidth = 100, Width = 120, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię ucznia", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Data początkowa", WordWrap = true, AspectName = "StartDate", MinimumWidth = 50, Width = 90, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data początkowa obowiązywania wykluczenia", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = delegate (object cellValue) { return ((DateTime)cellValue).ToShortDateString(); } });
            Cols.Add(new OLVColumn { Text = "Data końcowa", WordWrap = true, AspectName = "EndDate", MinimumWidth = 50, Width = 90, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data końcowa obowiązywania wykluczenia", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = delegate (object cellValue) { return ((DateTime)cellValue).ToShortDateString(); } });
            Cols.Add(new OLVColumn { Text = "ID", AspectName = "ID", MinimumWidth = 0, MaximumWidth = 50, Width = 0, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Identyfikator wykluczenia", UseInitialLetterForGroup = false });
            return Cols;
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void frmPrivilege_FormClosing(object sender, FormClosingEventArgs e)
        {
            TheEnd?.Invoke(sender, e);
            AppUser.UserSettings.RaiseConfigChanged -= ApplyNewConfig;
        }
        private void GetData(ObjectListView olv, IEnumerable<object> ItemList)
        {
            try
            {
                olv.BeginUpdate();
                olv.SetObjects(ItemList);
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<IEnumerable<Teacher>> GetTeacherListAsync()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(PrivilegeSQL.SelectTeacher(UserSession.User.Settings.SchoolID.ToString()), TeacherModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Teacher TeacherModel(IDataReader R)
        {
            return new Teacher
            {
                ID = Convert.ToInt32(R["ID"]),
                FirstName = R["Imie"].ToString(),
                LastName = R["Nazwisko"].ToString(),
                Status = (User.UserStatus)Convert.ToInt64(R["Status"]),
                Role = (User.UserRole)Convert.ToInt64(R["Role"]),
            };
        }

        private async Task<IEnumerable<Privilege>> GetPrivilegeListAsync(int TeacherId)
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(PrivilegeSQL.SelectPrivilege(TeacherId, UserSession.User.Settings.SchoolYear), Privilege.CreatePrivilege);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private async Task<IEnumerable<ExclusionDetails>> GetExclusionListAsync(int TeacherId)
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(PrivilegeSQL.SelectExclusion(TeacherId, UserSession.User.Settings.SchoolYear), ExclusionDetails.CreateExclusionDetails);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        private void olvPrivilege_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                EnableButton(true);
                GetSignature((((OLVListItem)e.Item).RowObject as Privilege).Creator);
            }
            else
            {
                ClearSignature();
                EnableButton(false);
                cmdAddNew.Enabled = true;
            }
        }

        private void GetSignature(Signature itemCreator)
        {
            lblData.Text = itemCreator.Version.ToString();
            lblIP.Text = itemCreator.IP;
            lblUser.Text = itemCreator.ToString();
        }

        private void ClearSignature()
        {
            foreach (Label lbl in pnlSignature.Controls)
            {
                if (lbl.Name.StartsWith("lbl")) lbl.Text = "";
            }
        }

        private void EnableButton(bool v)
        {
            cmdAddNew.Enabled = v;
            cmdDelete.Enabled = v;
            cmdEdit.Enabled = v;
            cmdExclude.Enabled = v;
        }

        private void olvUser_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ClearSignature();
            if (e.IsSelected)
            {
                EnableButton(false);
                cmdAddNew.Enabled = true;
                var teacher = (e.Item as OLVListItem).RowObject as Teacher;
                var privileges = GetPrivilegeListAsync(teacher.ID);
                var exclusions = GetExclusionListAsync(teacher.ID);
                GetData(olvPrivilege, privileges.Result);
                GetData(olvExclusion, exclusions.Result);
            }
            else
            {
                EnableButton(false);
                olvPrivilege.ClearObjects();
                olvExclusion.ClearObjects();
            }
        }

        private void olvExclusion_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                EnableButton(true);
                GetSignature((((OLVListItem)e.Item).RowObject as ExclusionDetails).Creator);
            }
            else
            {
                EnableButton(false);
                cmdAddNew.Enabled = true;
                cmdExclude.Enabled = true;
                ClearSignature();
            }
        }
        private void txtSeek_TextChanged(object sender, EventArgs e)
        {
            switch (Target)
            {
                case 0:
                    Filter(olvPrivilege);
                    break;
                case 1:
                    Filter(olvExclusion);
                    break;
            }
        }

        void Filter(ObjectListView olv)
        {
            olv.ModelFilter = new ModelFilter(x => x.GetType().GetProperty(cbSeek.SelectedValue.ToString()).GetValue(x).ToString().StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
            lblRecord.Text = olv.FilteredObjects.Cast<object>().Count().ToString();
        }
        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Select();
        }

        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            using (var dlg = new dlgPrivilege((olvUser.SelectedObject as Teacher).ID))
            {
                dlg.olvObsada.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClickAlways;
                dlg.olvObsada.CellEditUseWholeCell = true;
                dlg.olvObsada.CellEditEnterChangesRows = true;
                dlg.NewRecordAdded += NewPrivilegeRecord;
                dlg.ShowDialog();
                dlg.NewRecordAdded -= NewPrivilegeRecord;
            }
        }
        private void NewPrivilegeRecord(long RecordID)
        {
            GetData(olvPrivilege, GetPrivilegeListAsync((olvUser.SelectedObject as Teacher).ID).Result);
            SeekHelper.SetListItem<Privilege, long>(RecordID, "ID", olvPrivilege);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Target)
                {
                    case 0:
                        DeletePrivilege();
                        break;
                    case 1:
                        DeleteExclusion();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void DeletePrivilege()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wskazane pozycje?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var recordCount = 0;
                    var sqlParamWithValue = new HashSet<Tuple<string, object>>();
                    foreach (Privilege P in olvPrivilege.SelectedObjects) sqlParamWithValue.Add(new Tuple<string, object>("@ID", P.ID));
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        recordCount = dbs.RemoveManyRecordsAsync(PrivilegeSQL.DeletePrivilege(), sqlParamWithValue).Result;
                    }
                    MessageBox.Show($"{recordCount} rekordów zostało usuniętych.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetData(olvPrivilege, GetPrivilegeListAsync((olvUser.SelectedObject as Teacher).ID).Result);
                    GetData(olvExclusion, GetExclusionListAsync((olvUser.SelectedObject as Teacher).ID).Result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        void DeleteExclusion()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wskazane pozycje?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var recordCount = 0;
                    var sqlParamWithValue = new HashSet<IDictionary<string, object>>();
                    foreach (ExclusionDetails E in olvExclusion.SelectedObjects) sqlParamWithValue.Add(new Dictionary<string, object>()
                    {
                        { "@AllocationID", E.AllocationID },
                        { "@PrivilegeID", E.PrivilegeID }
                    });
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        recordCount = dbs.RemoveManyRecordsAsync(PrivilegeSQL.DeleteExclusion(), sqlParamWithValue).Result;
                    }
                    MessageBox.Show($"{recordCount} rekordów zostało usuniętych.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetData(olvExclusion, GetExclusionListAsync((olvUser.SelectedObject as Teacher).ID).Result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Target)
                {
                    case 0:
                        if (olvPrivilege.SelectedObject == null) return;
                        EditPrivilege();
                        break;
                    case 1:
                        if (olvExclusion.SelectedObject == null) return;
                        EditExclusion();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EditExclusion()
        {
            var E = olvExclusion.SelectedObject as ExclusionDetails;
            var P = (olvPrivilege.Objects as ISet<Privilege>).Where(x => x.ID == E.PrivilegeID).First();
            using (var dlg = new dlgExclusionEdition())
            {
                FillDialog(dlg, E, P);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (UpdateExclusionAsync(dlg, E.AllocationID, E.PrivilegeID).Result > 0)
                        {
                            GetData(olvExclusion, GetExclusionListAsync(P.TeacherID).Result);
                            SeekHelper.SetListItem<ExclusionDetails, int, int>(E.AllocationID, E.PrivilegeID, "AllocationID", "PrivilegeID", olvExclusion);
                            return;
                        }
                        throw new Exception("Aktualizacja danych nie powiodła się!");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private async Task<int> UpdateExclusionAsync(dlgExclusionEdition dlg, int AllocationId, int PrivilegeId)
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(PrivilegeSQL.UpdateExclusion(), CreateUpdateParams(dlg, AllocationId, PrivilegeId));
            }
        }
        IDictionary<string, object> CreateUpdateParams(dlgExclusionEdition dlg, int AllocationId, int PrivilegeId)
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@IdPrzydzial", AllocationId);
            sqlParamWithValue.Add("@IdPrzywilej", PrivilegeId);
            sqlParamWithValue.Add("@DataAktywacji", dlg.dtStartDate.Value);
            sqlParamWithValue.Add("@DataDeaktywacji", dlg.dtEndDate.Value);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }
        private void FillDialog(dlgExclusionEdition dlg, ExclusionDetails e, Privilege p)
        {
            dlg.txtKlasa.Text = e.ClassName;
            dlg.txtPrzedmiot.Text = e.SubjectName;
            dlg.txtStudent.Text = e.StudentName;

            //var dt = new DateRange(p.StartDate, p.EndDate);
            dlg.dtStartDate.MinDate = p.StartDate;
            dlg.dtStartDate.MaxDate = p.EndDate;
            dlg.dtEndDate.MinDate = p.StartDate;
            dlg.dtEndDate.MaxDate = p.EndDate;

            dlg.dtStartDate.Value = e.StartDate;
            dlg.dtEndDate.Value = e.EndDate;

            dlg.cmdOK.Enabled = true;
        }

        private void EditPrivilege()
        {
            var P = olvPrivilege.SelectedObject as Privilege;
            using (var dlg = new dlgPrivilegeEdition())
            {
                FillDialog(dlg, P);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (UpdatePrivilegeAsync(dlg, P.ID).Result > 0)
                        {
                            GetData(olvPrivilege, GetPrivilegeListAsync(P.TeacherID).Result);
                            SeekHelper.SetListItem<Privilege, int>(P.ID, "ID", olvPrivilege);
                            return;
                        }
                        throw new Exception("Aktualizacja danych nie powiodła się!");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private async Task<int> UpdatePrivilegeAsync(dlgPrivilegeEdition dlg, int ID)
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(PrivilegeSQL.UpdatePrivilege(), CreateUpdateParams(dlg, ID));
            }
        }

        IDictionary<string,object> CreateUpdateParams(dlgPrivilegeEdition dlg, int id)
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@ID", id);
            sqlParamWithValue.Add("@Typ", dlg.cbTyp.SelectedValue);
            sqlParamWithValue.Add("@Status", dlg.cbStatus.SelectedValue);
            sqlParamWithValue.Add("@DataAktywacji", dlg.dtStartDate.Value);
            sqlParamWithValue.Add("@DataDeaktywacji", dlg.dtEndDate.Value);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        private void FillDialog(dlgPrivilegeEdition dlg, Privilege P)
        {
            dlg.txtKlasa.Text = P.ClassName;
            dlg.txtPrzedmiot.Text = P.SubjectName;
            var dt = new DateRange();
            dlg.dtStartDate.MinDate = dt.StartDate;
            dlg.dtStartDate.MaxDate = dt.EndDate;
            dlg.dtEndDate.MinDate = dt.StartDate;
            dlg.dtEndDate.MaxDate = dt.EndDate;

            dlg.dtStartDate.Value = P.StartDate;
            dlg.dtEndDate.Value = P.EndDate;
            dlg.cbStatus.DataSource = Enum.GetValues(typeof(User.UserStatus));
            dlg.cbTyp.DataSource = Enum.GetValues(typeof(PrivilegeAspect));
            dlg.cbStatus.Text = P.PrivilegeStatus.ToString();
            dlg.cbTyp.Text = P.PrivilegeType.ToString();
            dlg.cmdOK.Enabled = true;
        }

        private void olvUser_Enter(object sender, EventArgs e)
        {
            cmdAddNew.Enabled = (sender as ObjectListView).SelectedObject != null;
        }

        private void olvPrivilege_DoubleClick(object sender, EventArgs e) => cmdEdit_Click(sender, e);

        private void cmdExclude_Click(object sender, EventArgs e)
        {
            using (var dlg = new dlgExclusion(olvPrivilege.SelectedObject as Privilege))
            {
                dlg.olvStudent.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClickAlways;
                dlg.olvStudent.CellEditUseWholeCell = true;
                dlg.olvStudent.CellEditEnterChangesRows = true;
                dlg.NewRecordAdded += NewExclusionRecord;
                dlg.ShowDialog();
                dlg.NewRecordAdded -= NewExclusionRecord;
            }
        }

        private void NewExclusionRecord(Exclusion e)
        {
            GetData(olvExclusion, GetExclusionListAsync((olvUser.SelectedObject as Teacher).ID).Result);
            SeekHelper.SetListItem<ExclusionDetails, int, int>(e.AllocationID, e.PrivilegeID, "AllocationID", "PrivilegeID", olvExclusion);
        }

        private void tcPrivilege_SelectedIndexChanged(object sender, EventArgs e)
        {
            Target = (byte)tcPrivilege.SelectedIndex;
            ClearSignature();
            LoadFilterCriteria(Target);
        }
    }
    

}
