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
using Belfer.Helpers;

namespace Belfer
{
    public partial class frmSchoolType : Form
    {
        public event EventHandler TheEnd;

        public frmSchoolType()
        {
            InitializeComponent();
            lblRecord.Text = "";
            ListViewConfig(olvSchoolType);
            LoadFilterCriteria();

            GenerateColumns(olvSchoolType, SpecifyCols());
            GetData(olvSchoolType);
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();
        private void pnlRecord_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlRecord.Left - 10, pnlRecord.Height - 1, pnlRecord.Width, pnlRecord.Height - 1);
        }

        private void LoadFilterCriteria()
        {
            cbSeek.DataSource = new string[] { "Typ", "Opis" };
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
            Cols.Add(new OLVColumn { Text = "Typ", WordWrap = false, AspectName = "Name", MinimumWidth = 100, Width = 200, MaximumWidth = 300, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa typu szkoły", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true, HeaderCheckBox = true });
            Cols.Add(new OLVColumn { Text = "Opis", WordWrap = false, AspectName = "Description", MinimumWidth = 200, Width = 440, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Opis typu szkoły lub pełna nazwa typu", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });

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
                olv.SetObjects(GetSchoolTypeList().Result);
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
                lblRecord.Text = "0 z " + olv.Items.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<IEnumerable<SchoolType>> GetSchoolTypeList()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(SchoolSQL.SelectSchoolType(), SchoolTypeModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private SchoolType SchoolTypeModel(IDataReader R)
        {
            return new SchoolType
            {
                ID = Convert.ToInt32(R["ID"]),
                Name = R["Typ"].ToString(),
                Description = R["Opis"].ToString(),
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
                GetSignature((SchoolType)((OLVListItem)e.Item).RowObject);
                EnableButton(true);
                //cmdEdit.Enabled = true;
            }
            else
            {
                lblRecord.Text = "0 z " + e.Item.ListView.Items.Count;
                ClearSignature();
                EnableButton(false);
            }
        }

        private void GetSignature(SchoolType SchoolItem)
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
            using (var dlg = new dlgSchoolType())
            {
                dlg.IsNewMode = true;
                dlg.NewRecordAdded += RefreshData;
                dlg.ShowDialog();
                dlg.NewRecordAdded -= RefreshData;
            }
        }

        private void RefreshData(long RecordID)
        {
            GetData(olvSchoolType);
            SeekHelper.SetListItem<SchoolType, long>(RecordID, "ID", olvSchoolType);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wskazane pozycje?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var sqlString = SchoolSQL.DeleteSchoolType();
                    var recordCount = 0;
                    var sqlParamWithValue = new HashSet<Tuple<string, object>>();
                    foreach (SchoolType T in olvSchoolType.CheckedObjects) sqlParamWithValue.Add(new Tuple<string, object>("@ID", T.ID));
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        recordCount = dbs.RemoveManyRecordsAsync(sqlString, sqlParamWithValue).Result;
                    }
                    GetData(olvSchoolType);
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
            EditSchoolType();
        }
        void EditSchoolType()
        {
            try
            {
                if (olvSchoolType.SelectedObject == null) return;
                using (var dlg = new dlgSchoolType())
                {
                    var T = (SchoolType)olvSchoolType.SelectedObject;
                    FillDialog(dlg, T);

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (UpdateSchoolTypeAsync(dlg, T.ID).Result > 0)
                        {
                            GetData(olvSchoolType);
                            SeekHelper.SetListItem<SchoolType, int>(T.ID, "ID", olvSchoolType);
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

        private async Task<int> UpdateSchoolTypeAsync(dlgSchoolType dlg, int id)
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(SchoolSQL.UpdateSchoolType(), CreateUpdateParams(dlg, id));
            }
        }

        IDictionary<string, object> CreateUpdateParams(dlgSchoolType dlg, int id)
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@ID", id);
            sqlParamWithValue.Add("@Nazwa", dlg.txtNazwa.Text.Trim());
            sqlParamWithValue.Add("@Opis", dlg.txtOpis.Text.Trim());
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        private void FillDialog(dlgSchoolType dlg, SchoolType T)
        {
            dlg.txtNazwa.Text = T.Name;
            dlg.txtOpis.Text = T.Description;
        }

        private void olvTeacher_DoubleClick(object sender, EventArgs e)
        {
            EditSchoolType();
        }

        private void txtSeek_TextChanged(object sender, EventArgs e)
        {
            switch (cbSeek.SelectedIndex)
            {
                case 0://Typ szkoły
                    olvSchoolType.ModelFilter = new ModelFilter(x => ((SchoolType)x).Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 1://Opis
                    olvSchoolType.ModelFilter = new ModelFilter(x => ((SchoolType)x).Description.ToString().StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
            }
            lblRecord.Text = "0 z " + olvSchoolType.GetItemCount();
        }

        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Select();
        }

        private void olvTeacher_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            cmdDelete.Enabled = olvSchoolType.CheckedObjects.Count > 0;
        }
    }
    public class SchoolType : School.Type
    {
        public Signature Creator { get; set; }

        public override string ToString() { return $"{Name} - {Description}"; }
    }

}
