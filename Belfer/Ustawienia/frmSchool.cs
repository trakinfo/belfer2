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

namespace Belfer
{
    public partial class frmSchool : Form
    {
        public event EventHandler TheEnd;

        public frmSchool()
        {
            InitializeComponent();
            ClearDetails();
            ListViewConfig(olvSzkola);
            GenerateColumns(olvSzkola, SpecifyCols());
            LoadSchoolType();
            cmdAddNew.Enabled = UserSession.User.Role > AppUser.UserRole.Operator;
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
            Cols.Add(new OLVColumn { Text = "Nazwa", AspectName = "Name", MinimumWidth = 100, Width = 200, FillsFreeSpace = true, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Pełna nazwa szkoły", UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "NIP", WordWrap = true, AspectName = "Nip", MinimumWidth = 100, Width = 150, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Numer identyfikacji podatkowej", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = true });
            return Cols;
        }
        private void LoadSchoolType()
        {
            try
            {
                var ST = new HashSet<School.Type>();
                ST.Add(new School.Type { ID = 0, Name = "Wszystkie typy", Description = "Pozycja wirtualna bez odpowiednika w bazie danych" });

                IEnumerable<School.Type> schoolType;
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    schoolType = dbs.FetchRecordSetAsync(SchoolSQL.SelectSchoolType(),SchoolTypeModel).Result;
                }
                foreach (var R in schoolType)
                {
                    ST.Add(new School.Type
                    {
                        ID = R.ID,
                        Name = R.Name,
                        Description = R.Description
                       
                    });
                }
    
                cbSchoolType.DataSource = ST.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private School.Type SchoolTypeModel(IDataReader R)
        {
            return new School.Type()
            {
                ID = Convert.ToInt32(R["ID"]),
                Name = R["Typ"].ToString(),
                Description = R["Opis"].ToString()
            };
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
            olv.AlwaysGroupByColumn = GetGroupColumn();
        }

        private OLVColumn GetGroupColumn()
        {
            return new OLVColumn { AspectGetter = delegate (object R) { School S = (School)R; return S.SchoolType.ID; }, GroupKeyGetter = delegate (object R) { School S = (School)R; return S.SchoolType.Name; } };
        }

        private void frmSchool_FormClosing(object sender, FormClosingEventArgs e) => TheEnd?.Invoke(sender, e);

        private void pnlRecord_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlRecord.Left - 10, pnlRecord.Height - 1, pnlRecord.Width, pnlRecord.Height - 1);
        }

        private void pnlSignature_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlRecord.Left - 10, 1, pnlRecord.Width, 1);
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void cbSchoolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearDetails();

            var T = new List<AppUser.UserSchoolToken>();
            var stID = ((School.Type)((ComboBox)sender).SelectedItem).ID;
            if (stID == 0)
            {
                T = UserSession.User.SchoolTokenList.ToList();
            }
            else
            {
                foreach (var S in AppSession.Schools.Where(x => x.SchoolType.ID == stID))
                {
                    UserSession.User.SchoolTokenList.Where(x => x.SchoolID == S.ID).ToList().ForEach(x => T.Add(x));
                }
            }
            GetData(olvSzkola, T);
        }

        private void EnableButton(bool v)
        {
            cmdDelete.Enabled = v;
            cmdEdit.Enabled = v;
        }

        private void GetData(ObjectListView olv, List<AppUser.UserSchoolToken> SchoolToken)
        {
            try
            {
                var ST = SchoolToken.Where(x => x.UserRole > User.UserRole.Nauczyciel).ToList();
                olv.BeginUpdate();
                olv.SetObjects(GetSchoolList(ST));
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
                lblRecord.Text = "0 z " + olv.Items.Count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ISet<School> GetSchoolList(List<AppUser.UserSchoolToken> SchoolToken)
        {
            var SchoolList = new HashSet<School>();
            foreach (var ST in SchoolToken)
            {
                SchoolList.Add(AppSession.Schools.Where(x => x.ID == ST.SchoolID).FirstOrDefault());
            }
            return SchoolList;
        }

        private void olvSzkola_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                lblRecord.Text = (e.ItemIndex + 1) + " z " + e.Item.ListView.Items.Count;
                GetDetails(((OLVListItem)e.Item));
                EnableButton(true);
            }
            else
            {
                lblRecord.Text = "0 z " + e.Item.ListView.Items.Count;
                ClearDetails();
                EnableButton(false);
            }
        }

        private void GetDetails(OLVListItem SchoolItem)
        {
            var R = (School)SchoolItem.RowObject;
            lblAdres.Text = R.Address;
            lblAlias.Text = R.Alias;
            lblEmail.Text = R.Email;
            lblFax.Text = R.FaxNo;
            lblTel.Text = R.PhoneNo;
            GetSignature(R);
        }

        private void GetSignature(School SchoolItem)
        {
            lblUser.Text = SchoolItem.Creator.ToString();
            lblIP.Text = SchoolItem.Creator.IP;
            lblData.Text = SchoolItem.Creator.Version.ToString();
        }

        private void ClearDetails()
        {
            lblRecord.Text = "";
            foreach (Label lbl in tlpDetails.Controls)
            {
                if (lbl.Name.StartsWith("lbl")) lbl.Text = "";
            }
            ClearSignature();
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
            using (var dlg = new dlgSchool())
            {
                dlg.IsNewMode = true;
                dlg.cbTyp.DataSource = cbSchoolType.DataSource;
                dlg.cbTyp.SelectedItem = cbSchoolType.SelectedItem;
                dlg.NewRecordAdded += NewRecord;
                dlg.ShowDialog();
                dlg.NewRecordAdded -= NewRecord;
            }
        }

        private void NewRecord(long RecordID)
        {
            RefreshData();
            SeekHelper.SetListItem<School, long>(RecordID, "ID", olvSzkola);
            //SetListViewItem(RecordID);
        }

        //private void SetListViewItem(int recordID)
        //{
        //	var Item = ((List<School>)olvSzkola.Objects).Where(x => x.ID == recordID).First();
        //	olvSzkola.SelectObject(Item);
        //	olvSzkola.SelectedItem.EnsureVisible();
        //}

        private void RefreshData()
        {
            AppSession.Schools = Authentication.GetSchools(SchoolSQL.SelectSchool()).Result;
            UserSession.User.SchoolTokenList = Authentication.LoadUserToken(UserSession.User).Result;
            cbSchoolType_SelectedIndexChanged(cbSchoolType, new EventArgs());
        }
        private void cmdEdit_Click(object sender, EventArgs e) => EditSchool();

        private void EditSchool()
        {
            try
            {
                using (var dlg = new dlgSchool())
                {
                    var S = olvSzkola.SelectedObject as School;
                    FillDialog(dlg, S);

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        //IsqlCommand cmd = new SqlCommand();
                        if (UpdateDataAsync(dlg, S.ID).Result > 0)
                        {
                            NewRecord(S.ID);
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

        private async Task<int> UpdateDataAsync(dlgSchool dlg, int id)
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(SchoolSQL.UpdateSchool(), CreateUpdateParams(dlg,id));
            }

        }
        IDictionary<string,object>CreateUpdateParams(dlgSchool dlg, int id)
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            string NipNumber = null;
            if (dlg.txtNip.Text.Length > 0) NipNumber = dlg.txtNip.Text;
            int? CityID = null;
            if (((City)dlg.cbMiejscowosc.SelectedItem).ID != 0) CityID = ((City)dlg.cbMiejscowosc.SelectedItem).ID;
            sqlParamWithValue.Add("@ID", id);
            sqlParamWithValue.Add("@Nazwa", dlg.txtNazwa.Text.Trim());
            sqlParamWithValue.Add("@Alias",dlg.txtAlias.Text.Trim());
            sqlParamWithValue.Add("@Nip", NipNumber);
            sqlParamWithValue.Add("@Ulica", dlg.txtUlica.Text.Trim());
            sqlParamWithValue.Add("@Nr", dlg.txtNr.Text.Trim());
            sqlParamWithValue.Add("@IdMiejscowosc",CityID);
            sqlParamWithValue.Add("@Telefon", dlg.txtTel.Text.Trim());
            sqlParamWithValue.Add("@Fax", dlg.txtFax.Text.Trim());
            sqlParamWithValue.Add("@Email",dlg.txtEmail.Text.Trim());
            sqlParamWithValue.Add("@User",  UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        private void FillDialog(dlgSchool dlg, School S)
        {
            dlg.Text = "Edycja danych szkoły";
            dlg.IsNewMode = false;
            dlg.cbTyp.Enabled = false;

            dlg.cbTyp.DataSource = cbSchoolType.DataSource;
            SetSchoolType(S.SchoolType.ID, dlg.cbTyp);
            dlg.txtNazwa.Text = S.Name;
            dlg.txtAlias.Text = S.Alias;
            dlg.txtEmail.Text = S.Email;
            dlg.txtFax.Text = S.FaxNo;
            dlg.txtNip.Text = S.Nip;
            dlg.txtNr.Text = S.PlaceNo;
            dlg.txtTel.Text = S.PlaceNo;
            dlg.txtUlica.Text = S.StreetName;
            //dlgSchool.SetCity(S.Location.ID, dlg.cbMiejscowosc);
            dlg.cbMiejscowosc.SelectedIndex = City.ComboItems.GetCityIndex(S.Location.ID, dlg.cbMiejscowosc.Items);
        }

        private void SetSchoolType(int ID, ComboBox cb)
        {
            foreach (var item in cb.Items)
            {
                if (((School.Type)item).ID == ID)
                {
                    cb.SelectedIndex = cb.Items.IndexOf(item);
                    return;
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wskazane pozycje?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var sqlString = SchoolSQL.DeleteSchool();
                    var count = 0;
                    var sqlParamWithValue = new HashSet<Tuple<string,object>>();
                    foreach (School S in olvSzkola.SelectedObjects) sqlParamWithValue.Add(new Tuple<string,object> ("@ID", S.ID));
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        count = dbs.RemoveManyRecordsAsync(sqlString, sqlParamWithValue).Result;
                    }
                    RefreshData();
                    MessageBox.Show($"Liczba usuniętych rekordów: {count}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void olvSzkola_DoubleClick(object sender, EventArgs e)
        {
            EditSchool();
        }
    }
}
