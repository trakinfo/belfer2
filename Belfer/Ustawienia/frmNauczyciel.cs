using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Belfer.Ustawienia;
using Autofac;
using DataBaseService;
using System.Data;
using Belfer.Administrator.SQL;
using Belfer.Administrator.Model;
using Belfer.Helpers;
using Belfer.Ustawienia.SQL;

namespace Belfer
{
    public partial class frmNauczyciel : Form
    {
        public event EventHandler TheEnd;

        public frmNauczyciel()
        {
            InitializeComponent();
            lblRecord.Text = "";
            ListViewConfig(olvTeacher);
            LoadFilterCriteria();

            GenerateColumns(olvTeacher, SpecifyCols());
            GetData(olvTeacher);
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();
        private void pnlRecord_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlRecord.Left - 10, pnlRecord.Height - 1, pnlRecord.Width, pnlRecord.Height - 1);
        }

        private void LoadFilterCriteria()
        {
            cbSeek.DataSource = new string[] { "Nazwisko i imię", "Rola", "Status" };
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
            Cols.Add(new OLVColumn { Text = "Nazwisko i imię", WordWrap = true, AspectName = "Name", MinimumWidth = 100, Width = 300, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię użytkownika", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true, HeaderCheckBox = true });
            Cols.Add(new OLVColumn { Text = "Status", WordWrap = true, AspectName = "Status", MinimumWidth = 100, Width = 150, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Status użytkownika", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Rola", WordWrap = true, AspectName = "Role", MinimumWidth = 100, Width = 150, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Rola użytkownika", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = true });

            return Cols;
        }
        private void EnableButton(bool v)
        {
            cmdDelete.Enabled = v;
            cmdEdit.Enabled = v;
        }

        private void GetData(ObjectListView olv)
        {
            try
            {
                EnableButton(false);
                olv.BeginUpdate();
                olv.SetObjects(GetSchoolTeacherList().Result);
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
                lblRecord.Text = "0 z " + olv.Items.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<IEnumerable<Teacher>> GetSchoolTeacherList()
        {
            try
            {               
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(TeacherSQL.SelectTeacher(UserSession.User.Settings.SchoolID.ToString()), TeacherModel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new HashSet<Teacher>();
            }
        }

        private Teacher TeacherModel(IDataReader R)
        {
            return new Teacher
            {
                ID = Convert.ToInt32(R["ID"]),
                Login = R["Login"].ToString(),
                FirstName = R["Imie"].ToString(),
                LastName = R["Nazwisko"].ToString(),
                Status = (User.UserStatus)Convert.ToInt64(R["Status"]),
                Role = (User.UserRole)Convert.ToByte(R["Role"]),
                Creator = new Signature
                {
                    Owner = R["Owner"].ToString(),
                    User = R["User"].ToString(),
                    IP = R["ComputerIP"].ToString(),
                    Version = Convert.ToDateTime(R["Version"])
                }
            };
        }

        private void olvSzkola_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                lblRecord.Text = (e.ItemIndex + 1) + " z " + e.Item.ListView.Items.Count;
                GetSignature((Teacher)((OLVListItem)e.Item).RowObject);
                //EnableButton(true);
                cmdEdit.Enabled = true;
            }
            else
            {
                lblRecord.Text = "0 z " + e.Item.ListView.Items.Count;
                ClearSignature();
                EnableButton(false);
            }
        }

        private void GetSignature(Teacher SchoolItem)
        {
            lblUser.Text = SchoolItem.Creator.ToString();
            lblIP.Text = SchoolItem.Creator.IP;
            lblData.Text = SchoolItem.Creator.Version.ToString();
        }

        private void ClearSignature()
        {
            foreach (Label lbl in pnlSignature.Controls)
            {
                if (lbl.Name.StartsWith("lbl")) lbl.Text = "";
            }
        }

        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            using (var dlg = new frmUser(UserSQL.SelectSomeUsers(UserSession.User.Settings.SchoolID.ToString())))
            {
                dlg.cmdClose.Text = "Anuluj";
                dlg.cmdSave.Enabled = false;
                dlg.cmdSave.Visible = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var TeacherList = new List<Teacher>();
                    foreach (User U in dlg.olvUser.CheckedObjects)
                    {
                        TeacherList.Add(new Teacher { Login = U.Login, Role = U.Role, Status = U.Status, FirstName = U.FirstName, LastName = U.LastName });
                    }
                    if (TeacherList.Count == 0) return;
                    var Rec = AddSchoolTeacher(TeacherList);
                    if (Rec > 0)
                    {
                        GetData(olvTeacher);
                        MessageBox.Show("Dodano rekordów: " + Rec.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ups! Coś poszło nie tak.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }
        int AddSchoolTeacher(List<Teacher> tcr)
        {
            try
            {
                var sqlParamWithValue = new HashSet<IDictionary<string, object>>();
                foreach (var t in tcr) sqlParamWithValue.Add(CreateParamWithValue(t));
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return dbs.AddManyRecordsAsync(TeacherSQL.InsertTeacher(), sqlParamWithValue).Result.RecordCount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }

        private Dictionary<string, object> CreateParamWithValue(Teacher t)
        {
            var d = new Dictionary<string, object>();
            d.Add("@SchoolID", UserSession.User.Settings.SchoolID);
            d.Add("@Login", t.Login);
            d.Add("@Status", t.Status);
            d.Add("@Role", t.Role);
            d.Add("@Owner", UserSession.User.Login);
            d.Add("@User", UserSession.User.Login);
            d.Add("@IP", AppSession.HostIP);
            return d;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wskazane pozycje?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var recordCount = 0;
                    var sqlParamWithValue = new HashSet<Tuple<string, object>>();
                    foreach (Teacher t in olvTeacher.CheckedObjects) sqlParamWithValue.Add(new Tuple<string, object>("@ID", t.ID));
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        recordCount = dbs.RemoveManyRecordsAsync(TeacherSQL.DeleteTeacher(), sqlParamWithValue).Result;
                    }
                    GetData(olvTeacher);
                    MessageBox.Show($"Liczba usuniętych rekordów: {recordCount}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void frmSchool_FormClosing(object sender, FormClosingEventArgs e) => TheEnd?.Invoke(sender, e);

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            EditTeacher();
        }
        void EditTeacher()
        {
            try
            {
                if (olvTeacher.SelectedObject == null) return;
                using (var dlg = new dlgTeacher())
                {
                    var T = (Teacher)olvTeacher.SelectedObject;
                    FillDialog(dlg, T);

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        //IsqlCommand cmd = new SqlCommand();
                        if (UpdateTeacherAsync(dlg, T.ID).Result > 0)
                        {
                            //cmd.CommitTransaction();
                            GetData(olvTeacher);
                            SeekHelper.SetListItem<Teacher, int>(T.ID, "ID", olvTeacher);
                            return;
                        }
                        throw new Exception("Aktualizacja danych nie powiodła się!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<int> UpdateTeacherAsync(dlgTeacher dlg, int id)
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(TeacherSQL.UpdateTeacher(), CreateUpdateParams(dlg, id));
            }
        }
        IDictionary<string, object> CreateUpdateParams(dlgTeacher dlg, int id)
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            User.UserRole R = (User.UserRole)Enum.Parse(typeof(User.UserRole), dlg.cbRole.SelectedValue.ToString());
            sqlParamWithValue.Add("@ID", id);
            sqlParamWithValue.Add("@Rola", R);
            sqlParamWithValue.Add("@Status", dlg.chkStatus.Checked);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        private void FillDialog(dlgTeacher dlg, Teacher T)
        {
            dlg.txtTeacher.Text = T.Name;
            dlg.cbRole.DataSource = Enum.GetNames(typeof(User.UserRole));
            dlg.cbRole.Text = T.Role.ToString();
            dlg.chkStatus.Checked = (int)T.Status > 0;
        }

        private void olvTeacher_DoubleClick(object sender, EventArgs e)
        {
            EditTeacher();
        }

        private void txtSeek_TextChanged(object sender, EventArgs e)
        {
            switch (cbSeek.SelectedIndex)
            {
                case 0://Nazwisko i imię
                    olvTeacher.ModelFilter = new ModelFilter(x => ((Teacher)x).Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 1://Rola
                    olvTeacher.ModelFilter = new ModelFilter(x => ((Teacher)x).Role.ToString().StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 2: //Status
                    olvTeacher.ModelFilter = new ModelFilter(x => ((Teacher)x).Status.ToString().StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
            }
            lblRecord.Text = "0 z " + olvTeacher.GetItemCount();
        }

        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Select();
        }

        private void olvTeacher_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            cmdDelete.Enabled = olvTeacher.CheckedObjects.Count > 0;
        }
    }
    public class Teacher
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User.UserRole Role { get; set; }
        public User.UserStatus Status { get; set; }
        public Signature Creator { get; set; }

        public string Name { get { return string.Concat(LastName, " ", FirstName); } }
        public override string ToString() { return string.Concat(Name, " (", Status, " ", Role, ")"); }
    }

}
