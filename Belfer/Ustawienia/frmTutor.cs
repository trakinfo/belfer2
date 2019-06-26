using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Belfer.Administrator.Model;
using Belfer.Helpers;
using BrightIdeasSoftware;
using DataBaseService;

namespace Belfer.Ustawienia
{
    public partial class frmTutor : Form
    {
        public event EventHandler TheEnd;

        public frmTutor()
        {
            InitializeComponent();
            AppUser.UserSettings.RaiseConfigChanged += ApplyNewConfig;
            ListViewConfig(olvTutor);
            LoadFilterCriteria();
            GenerateColumns(olvTutor, SpecifyCols());

            ApplyNewConfig(this, null);
        }
        private void ApplyNewConfig(object sender, EventArgs e)
        {
            try
            {
                lblRecord.Text = "";
                ClearSignature();
                cmdAddNew.Enabled = true;

                cmdPrint.Enabled = true;
                EnableButton(false);

                GetData(olvTutor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pnlRecord_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlRecord.Left - 10, pnlRecord.Height - 1, pnlRecord.Width, pnlRecord.Height - 1);
        }
        private void pnlSignature_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlSignature.Left - 10, 1, pnlSignature.Width, 1);
        }
        private void LoadFilterCriteria()
        {
            cbSeek.DataSource = new string[] { "Nazwisko i imię", "Klasa", "Typ", "Status" };
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

        private List<OLVColumn> SpecifyCols()
        {
            var Cols = new List<OLVColumn>();
            Cols.Add(new OLVColumn { Name = "ClassName", Text = "Klasa", AspectName = "SchoolClass.ClassName", MinimumWidth = 30, Width = 100, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Oddział klasowy", UseInitialLetterForGroup = false, IsEditable = false, GroupKeyToTitleConverter = new GroupKeyToTitleConverterDelegate(x => string.Concat("Klasy ", x.ToString())), GroupKeyGetter = (x) => { int.TryParse(((Tutor)x).SchoolClass.ClassCode.Substring(0, 1), out int k); return SchoolClass.ClassLine[k]; } });
            Cols.Add(new OLVColumn { Name = "TutorName", Text = "Nazwisko i imię", WordWrap = true, AspectName = "Teacher.Name", MinimumWidth = 100, Width = 150, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię wychowawcy", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Typ", WordWrap = true, AspectName = "PrivilegeType", MinimumWidth = 30, Width = 90, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Rodzaj uprawnienia", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, IsEditable = false });
            Cols.Add(new OLVColumn { Name = "Status", Text = "Status", WordWrap = true, AspectName = "PrivilegeStatus", MinimumWidth = 90, Width = 50, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Status aktywacji", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false });
            Cols.Add(new OLVColumn { Text = "Data\naktywacji", WordWrap = true, AspectName = "ValidityInterval.StartDate", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data aktywacji uprawnienia", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = (cellValue) => ((DateTime)cellValue).ToShortDateString() });
            Cols.Add(new OLVColumn { Text = "Data\ndeaktywacji", WordWrap = true, AspectName = "ValidityInterval.EndDate", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data deaktywacji uprawnienia", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = (cellValue) => ((DateTime)cellValue).ToShortDateString() });
            Cols.Add(new OLVColumn { Text = "ID", AspectName = "ID", MinimumWidth = 0, Width = 0, MaximumWidth = 60, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Identyfikator pozycji", Groupable = false, IsEditable = false });

            return Cols;
        }

        private void GetData(ObjectListView olv)
        {
            try
            {
                olv.BeginUpdate();
                olv.SetObjects(GetTutorListAsync().Result);
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
                lblRecord.Text = "0 z " + olv.Items.Count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<IEnumerable<Tutor>> GetTutorListAsync()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(TutorSQL.SelectTutor(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear), TutorModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Tutor TutorModel(IDataReader T)
        {
            return new Tutor
            {
                ID = Convert.ToInt32(T["ID"]),
                SchoolClass = new SchoolClass
                {
                    ID = Convert.ToInt32(T["IdKlasa"]),
                    ClassCode = T["KodKlasy"].ToString(),
                    ClassName = T["NazwaKlasy"].ToString()
                },
                Teacher = new Teacher
                {
                    ID = Convert.ToInt32(T["IdNauczyciel"]),
                    FirstName = T["Imie"].ToString(),
                    LastName = T["Nazwisko"].ToString(),
                    Status = (User.UserStatus)Convert.ToInt64(T["NauczycielStatus"]),
                    Role = (User.UserRole)Convert.ToInt64(T["Role"]),
                    Login = T["Login"].ToString()
                },
                ValidityInterval = new DateRange(Convert.ToDateTime(T["StartDate"]), Convert.ToDateTime(T["EndDate"])),
                Creator = new Signature
                {
                    Owner = T["Owner"].ToString(),
                    User = T["User"].ToString(),
                    IP = T["ComputerIP"].ToString(),
                    Version = Convert.ToDateTime(T["Version"])
                },
                PrivilegeType = (PrivilegeAspect)Convert.ToInt64(T["Typ"]),
                PrivilegeStatus = (User.UserStatus)Convert.ToInt64(T["Status"])
            };
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();


        private void frmStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            TheEnd?.Invoke(sender, e);
            AppUser.UserSettings.RaiseConfigChanged -= ApplyNewConfig;
        }

        private void olvObsada_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                lblRecord.Text = (e.ItemIndex + 1) + " z " + e.Item.ListView.Items.Count;
                GetSignature((Tutor)((OLVListItem)e.Item).RowObject);
                EnableButton(true);
            }
            else
            {
                lblRecord.Text = "0 z " + e.Item.ListView.Items.Count;
                ClearSignature();
                EnableButton(false);
            }
        }

        private void GetSignature(Tutor UserItem)
        {
            lblData.Text = UserItem.Creator.Version.ToString();
            lblIP.Text = UserItem.Creator.IP;
            lblUser.Text = UserItem.Creator.ToString();
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
            cmdDelete.Enabled = v;
            cmdEdit.Enabled = v;
        }

        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }
        void AddNew()
        {
            using (var frm = new frmPrivilege())
            {
                frm.cbSeek.SelectedIndex = -1;
                frm.cbSeek.Enabled = false;
                frm.txtSeek.Enabled = false;
                frm.tcPrivilege.TabPages.RemoveAt(1);
                frm.olvPrivilege.ModelFilter = new ModelFilter(x => ((Privilege)x).SubjectType.ToUpper().Equals("Z"));
                frm.ShowDialog();
            }
        }
        private void txtSeek_TextChanged(object sender, EventArgs e)
        {
            switch (cbSeek.SelectedIndex)
            {
                case 0://Nazwisko i imię
                    olvTutor.ModelFilter = new ModelFilter(x => ((Tutor)x).Teacher.Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 1://Klasa
                    olvTutor.ModelFilter = new ModelFilter(x => ((Tutor)x).SchoolClass.ClassName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 2: //Typ
                    olvTutor.ModelFilter = new ModelFilter(x => ((Tutor)x).PrivilegeType.ToString().StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 3: //Status
                    olvTutor.ModelFilter = new ModelFilter(x => ((Tutor)x).PrivilegeStatus.ToString().StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
            }
            lblRecord.Text = "0 z " + olvTutor.GetItemCount();
        }

        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Select();
        }

        private void RefreshData()
        {
            ClearSignature();
            GetData(olvTutor);
        }

        //private void SetListViewItem(int recordID)
        //{
        //	var Item = ((HashSet<Tutor>)olvTutor.Objects).Where(x => x.ID == recordID).FirstOrDefault();
        //	if (Item != null)
        //	{
        //		olvTutor.SelectObject(Item);
        //		olvTutor.SelectedItem.EnsureVisible();
        //	}
        //}

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            EditPrivilege();
        }
        private void EditPrivilege()
        {

            if (olvTutor.SelectedObject == null) return;
            var T = olvTutor.SelectedObject as Tutor;
            using (var dlg = new dlgPrivilegeEdition())
            {
                FillTutorData(dlg, T);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (UpdateTutorAsync(dlg, T.ID).Result > 0)
                        {
                            RefreshData();
                            SeekHelper.SetListItem<Tutor, int>(T.ID, "ID", olvTutor);
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
        void FillTutorData(dlgPrivilegeEdition dlg, Tutor T)
        {
            dlg.txtKlasa.Text = T.SchoolClass.ToString();
            dlg.lblPrzedmiot.Text = "Nauczyciel";
            dlg.txtPrzedmiot.Text = T.Teacher.Name;
            var dt = new DateRange();
            dlg.dtStartDate.MinDate = dt.StartDate;
            dlg.dtStartDate.MaxDate = dt.EndDate;
            dlg.dtEndDate.MinDate = dt.StartDate;
            dlg.dtEndDate.MaxDate = dt.EndDate;

            dlg.dtStartDate.Value = T.ValidityInterval.StartDate;
            dlg.dtEndDate.Value = T.ValidityInterval.EndDate;
            dlg.cbStatus.DataSource = Enum.GetValues(typeof(User.UserStatus));
            dlg.cbTyp.DataSource = Enum.GetValues(typeof(PrivilegeAspect));
            dlg.cbStatus.Text = T.PrivilegeStatus.ToString();
            dlg.cbTyp.Text = T.PrivilegeType.ToString();
            dlg.cmdOK.Enabled = true;
        }

        async Task<int> UpdateTutorAsync(dlgPrivilegeEdition dlg, int IdPrivilege)
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(PrivilegeSQL.UpdatePrivilege(), CreateUpdateParams(dlg,IdPrivilege));
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

        private void cmdDelete_Click(object sender, EventArgs e) => DeleteTutor();
        private void olvStudent_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    DeleteTutor();
                    break;
                case Keys.Insert:
                    AddNew();
                    break;
                default:
                    break;
            }
        }
        void DeleteTutor()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wskazane pozycje?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var recordCount = 0;
                    var sqlParamWithValue = new HashSet<Tuple<string,object>>();
                    foreach (Tutor T in olvTutor.SelectedObjects) sqlParamWithValue.Add(new Tuple<string, object>("@ID", T.ID));
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        recordCount = dbs.RemoveManyRecordsAsync(PrivilegeSQL.DeletePrivilege(), sqlParamWithValue).Result;
                    }
                    MessageBox.Show($"{recordCount} rekordów zostało usuniętych.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void olvTutor_DoubleClick(object sender, EventArgs e)
        {
            EditPrivilege();
        }
    }
    public class Tutor
    {
        public int ID { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public Teacher Teacher { get; set; }
        public PrivilegeAspect PrivilegeType { get; set; }
        public User.UserStatus PrivilegeStatus { get; set; }
        public DateRange ValidityInterval { get; set; }
        public Signature Creator { get; set; }

    }
}
