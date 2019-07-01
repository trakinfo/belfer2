using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Autofac;
using DataBaseService;
using System.Data;
using Belfer.Administrator.SQL;
using Belfer.Administrator.Model;
using Belfer.Helpers;
using Belfer.Ustawienia.SQL;
using Belfer.Ustawienia.Model;

namespace Belfer
{
    public partial class frmSchoolSubject : Form
    {
        public event EventHandler TheEnd;

        public frmSchoolSubject()
        {
            InitializeComponent();
            lblRecord.Text = "";
            ListViewConfig(olvSubject);

            GenerateColumns(olvSubject, SpecifyCols());
            GetData(olvSubject);
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();
        private void pnlRecord_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlRecord.Left - 10, pnlRecord.Height - 1, pnlRecord.Width, pnlRecord.Height - 1);
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
            Cols.Add(new OLVColumn { Text = "Nazwa przedmiotu", WordWrap = true, AspectName = "Name", MinimumWidth = 100, Width = 300, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa przedmiotu", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true, HeaderCheckBox = true });

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
                olv.SetObjects(GetSchoolSubjectList().Result);
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
                lblRecord.Text = "0 z " + olv.Items.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<IEnumerable<SchoolSubjectModel>> GetSchoolSubjectList()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(SubjectSQL.SelectSchoolSubject(UserSession.User.Settings.SchoolID.ToString()), SchoolSubjectModel.CreateSchoolSubject);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new HashSet<SchoolSubjectModel>();
            }
        }



        private void olvSzkola_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                lblRecord.Text = (e.ItemIndex + 1) + " z " + e.Item.ListView.Items.Count;
                GetSignature((SchoolSubjectModel)((OLVListItem)e.Item).RowObject);
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

        private void GetSignature(SchoolSubjectModel SchoolItem)
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
                        GetData(olvSubject);
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
                    foreach (Teacher t in olvSubject.CheckedObjects) sqlParamWithValue.Add(new Tuple<string, object>("@ID", t.ID));
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        recordCount = dbs.RemoveManyRecordsAsync(TeacherSQL.DeleteTeacher(), sqlParamWithValue).Result;
                    }
                    GetData(olvSubject);
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
                if (olvSubject.SelectedObject == null) return;
                using (var dlg = new dlgTeacher())
                {
                    var T = (Teacher)olvSubject.SelectedObject;
                    FillDialog(dlg, T);

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        //IsqlCommand cmd = new SqlCommand();
                        if (UpdateTeacherAsync(dlg, T.ID).Result > 0)
                        {
                            //cmd.CommitTransaction();
                            GetData(olvSubject);
                            SeekHelper.SetListItem<Teacher, int>(T.ID, "ID", olvSubject);
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
            olvSubject.ModelFilter = new ModelFilter(x => ((SchoolSubjectModel)x).Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
            lblRecord.Text = "0 z " + olvSubject.GetItemCount();
        }

        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Select();
        }

        private void olvTeacher_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            cmdDelete.Enabled = olvSubject.CheckedObjects.Count > 0;
        }
    }


}
