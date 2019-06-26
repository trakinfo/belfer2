using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Drawing.Printing;
using Belfer.Ustawienia;
using Autofac;
using DataBaseService;
using Belfer.Administrator.Model;
using Belfer.Helpers;

namespace Belfer
{
    public partial class frmSchoolClass : Form
    {
        public event EventHandler TheEnd;
        public frmSchoolClass()
        {
            InitializeComponent();
            AppUser.UserSettings.RaiseConfigChanged += ApplyNewConfig;
            lblRecord.Text = "";
            ListViewConfig(olvKlasa);
            LoadFilterCriteria();

            GenerateColumns(olvKlasa, SpecifyCols());
            ApplyNewConfig(this, null);
        }

        private void ApplyNewConfig(object sender, EventArgs e)
        {
            GetData(olvKlasa);
        }

        private void pnlRecord_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlRecord.Left - 10, pnlRecord.Height - 1, pnlRecord.Width, pnlRecord.Height - 1);
        }

        private void LoadFilterCriteria()
        {
            cbSeek.DataSource = new string[] { "Kod klasy", "Nazwa klasy", "Klasa wirtualna" };
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
            //olv.AlwaysGroupByColumn = GetGroupColumn();
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
            Cols.Add(new OLVColumn { Text = "Kod klasy", AspectName = "ClassCode", MinimumWidth = 100, Width = 150, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Maksymalnie trzyznakowy kod", UseInitialLetterForGroup = true, IsEditable = false, GroupKeyToTitleConverter = new GroupKeyToTitleConverterDelegate(x => string.Concat("Klasa ", x.ToString())), HeaderCheckBox = true });
            Cols.Add(new OLVColumn { Text = "Nazwa klasy", WordWrap = true, AspectName = "ClassName", MinimumWidth = 100, Width = 150, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa klasy w danym roku szkolnym", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true, IsEditable = true });
            Cols.Add(new OLVColumn { Text = "Klasa wirtualna", WordWrap = true, AspectName = "IsVirtual", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Przeznaczenie kontenera", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, IsEditable = true });

            return Cols;
        }
        private void GetData(ObjectListView olv)
        {
            try
            {
                olv.BeginUpdate();
                olv.SetObjects(GetClassList().Result);
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
                lblRecord.Text = "0 z " + olv.Items.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task<IEnumerable<SchoolClass>> GetClassList()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(SchoolClassSQL.SelectSchoolClassList(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear), SchoolClassModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private SchoolClass SchoolClassModel(IDataReader R)
        {
            return new SchoolClass
            {
                ID = Convert.ToInt32(R["ID"]),
                ClassCode = R["KodKlasy"].ToString(),
                ClassName = R["NazwaKlasy"].ToString(),
                IsVirtual = (YesNo)Convert.ToInt64(R["IsVirtual"]),
                Creator = new Signature
                {
                    Owner = R["Owner"].ToString(),
                    User = R["User"].ToString(),
                    IP = R["ComputerIP"].ToString(),
                    Version = Convert.ToDateTime(R["Version"])
                }
            };
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void olvSzkola_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                lblRecord.Text = (e.ItemIndex + 1) + " z " + e.Item.ListView.Items.Count;
                GetSignature((SchoolClass)((OLVListItem)e.Item).RowObject);
                EnableButton(true);
            }
            else
            {
                lblRecord.Text = "0 z " + e.Item.ListView.Items.Count;
                ClearSignature();
                EnableButton(false);
            }
        }

        private void GetSignature(SchoolClass UserItem)
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
            //cmdDelete.Enabled = v;
            cmdEdit.Enabled = v;

        }

        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            using (var dlg = new dlgSchoolClass(true))
            {
                dlg.NewRecordAdded += NewRecord;
                dlg.ShowDialog();
                dlg.NewRecordAdded -= NewRecord;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (olvKlasa.SelectedObject == null) return;
            EditSchoolClass();
        }
        private void EditSchoolClass()
        {
            try
            {
                var SC = olvKlasa.SelectedObject as SchoolClass;
                using (var dlg = new dlgSchoolClass(false))
                {
                    FillDialog(dlg, SC);

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (UpdateData(dlg, SC).Result > 0)
                        {
                            NewRecord(SC.ID);
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

        private async Task<int> UpdateData(dlgSchoolClass dlg, SchoolClass SC)
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(SchoolClassSQL.UpdateSchoolClass(), CreateUpdateParams(dlg, SC.ID));
            }
        }

        IDictionary<string, Object> CreateUpdateParams(dlgSchoolClass dlg, int id)
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@ID", id);
            sqlParamWithValue.Add("@NazwaKlasy", dlg.txtNazwa.Text.Trim());
            sqlParamWithValue.Add("@IsVirtual", dlg.chkVirtual.Checked);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        private void FillDialog(dlgSchoolClass dlg, SchoolClass SC)
        {
            dlg.Text = "Edycja danych";
            dlg.cbKlasa.Enabled = false;

            dlg.cbKlasa.Items.Add(SC.ClassCode);
            dlg.cbKlasa.SelectedIndex = 0;
            dlg.chkVirtual.Checked = SC.IsVirtual > 0;
            dlg.cmdOK.Enabled = true;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wskazane pozycje?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var sqlString = SchoolClassSQL.DeleteSchoolClass();
                    var count = 0;
                    var sqlParamWithValue = new HashSet<Tuple<string, object>>();
                    foreach (SchoolClass SC in olvKlasa.CheckedObjects) sqlParamWithValue.Add(new Tuple<string, object>("@ID", SC.ID));
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        count = dbs.RemoveManyRecordsAsync(sqlString, sqlParamWithValue).Result;
                    }
                    RefreshData();
                    MessageBox.Show($"{count} rekordów zostało usuniętych.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NewRecord(long RecordID)
        {
            RefreshData();
            //SetListViewItem(RecordID);
            SeekHelper.SetListItem<SchoolClass, long>(RecordID, "ID", olvKlasa);
        }

        private void RefreshData()
        {
            ClearSignature();
            ApplyNewConfig(this, null);
        }

        private void frmObsada_FormClosing(object sender, FormClosingEventArgs e)
        {
            TheEnd?.Invoke(sender, e);
            AppUser.UserSettings.RaiseConfigChanged -= ApplyNewConfig;
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

        private void olvObsada_DoubleClick(object sender, EventArgs e) => cmdEdit_Click(sender, e);

        private void cmdImport_Click(object sender, EventArgs e)
        {
            using (var dlg = new dlgImportSchoolClass())
            {
                dlg.nudStartYear.Maximum = UserSession.User.Settings.Year - 1;
                ListViewConfig(dlg.olvKlasa);
                dlg.olvKlasa.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClickAlways;
                dlg.olvKlasa.CellEditUseWholeCell = true;
                dlg.olvKlasa.CellEditEnterChangesRows = true;
                GenerateColumns(dlg.olvKlasa, SpecifyCols());
                dlg.nudStartYear.Value = UserSession.User.Settings.Year - 1;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    RefreshData();
                }
            }
        }



        private PrintHelper PH;

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            PH = new PrintHelper();
            PH.ReportHeader = new List<string> { "Oddziały klasowe dostępne w szkole" };
            PH.Offset = new int[2];
            PrintPlanList();
        }
        private void PrintPlanList()
        {
            try
            {
                using (var dlgPrint = new dlgPrintPreview())
                {
                    dlgPrint.PreviewModeChanged += PH.PreviewModeChanged;
                    PH.NewRow += dlgPrint.NewRow;
                    PH.NextPage += doc_PrintPage;

                    dlgPrint.Doc.BeginPrint += PH.PrnDoc_BeginPrint;
                    dlgPrint.Doc.PrintPage += doc_PrintPage;
                    dlgPrint.Doc.EndPrint += PH.doc_EndPrint;

                    dlgPrint.ShowDialog();

                    dlgPrint.PreviewModeChanged -= PH.PreviewModeChanged;
                    PH.NewRow -= dlgPrint.NewRow;
                    PH.NextPage -= doc_PrintPage;
                }
                //dlgPrintPreview dlgPrint = new dlgPrintPreview();

            }
            catch (InvalidPrinterException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            #region -------------------------- Print variables definitions -----------------------
            PH.G = e.Graphics;
            PrintDocument Doc = (PrintDocument)sender;
            float x = PH.IsPreview ? UserSession.User.Settings.LeftMargin : UserSession.User.Settings.LeftMargin - e.PageSettings.PrintableArea.Left;
            float y = PH.IsPreview ? UserSession.User.Settings.TopMargin : UserSession.User.Settings.TopMargin - e.PageSettings.PrintableArea.Top;
            float y0 = y;
            Font TextFont = UserSession.User.Settings.TextFont;
            Font HeaderFont = UserSession.User.Settings.HeaderFont;

            float LineHeight = TextFont.GetHeight(e.Graphics);
            float HeaderLineHeight = HeaderFont.GetHeight(e.Graphics);

            int PrintWidth = e.MarginBounds.Width;
            int PrintHeight = e.MarginBounds.Bottom;
            //int ColOffset = (PrintWidth + (int)x) * -1;
            #endregion

            PH.PageNumber += 1;

            #region --------------------------- Document header and footer -----------------------
            PH.DrawHeader(x, y, PrintWidth);
            PH.DrawFooter(x, PrintHeight, PrintWidth);
            PH.DrawPageNumber("- " + PH.PageNumber.ToString() + " -", x, PrintHeight, PrintWidth, PageNumberLocation.Footer);
            #endregion

            #region ------------------------------ Report header -----------------------------------
            if (PH.PageNumber == 1)
            {
                y += LineHeight;
                PH.DrawText(PH.ReportHeader[0], HeaderFont, x, y, PrintWidth, HeaderLineHeight, StringAlignment.Center, Brushes.Black, false);
                y += HeaderLineHeight * 2;
            }
            #endregion
            #region ------------------------------- Column Settings --------------------------
            List<TableCellWithAlignment> Kolumna = new List<TableCellWithAlignment>();
            foreach (OLVColumn Col in olvKlasa.AllColumns.Where(c => c.AspectName != "ID"))
            {
                var Align = StringAlignment.Near;
                Enum.TryParse<StringAlignment>(Col.TextAlign.ToString(), out Align);
                Kolumna.Add(new TableCellWithAlignment { Name = Col.AspectName, Label = Col.Text, Size = Col.Width, Alignment = Align });
            }
            int SpaceWidth = PrintWidth - Kolumna.Sum(K => K.Size);
            int Space = SpaceWidth / Kolumna.Count;
            foreach (var col in Kolumna)
            {
                col.Size += Space;
            }
            #endregion

            #region ------------------------------- Table header --------------------------------
            float MultiplyLine = 3;
            int ColOffset = 0;
            if (PH.PageNumber == 1)
            {
                for (int i = 0; i < Kolumna.Count(); i++)
                {
                    PH.DrawText(Kolumna[i].Label, new Font(TextFont, FontStyle.Bold), x + ColOffset, y, Kolumna[i].Size, LineHeight * MultiplyLine, StringAlignment.Center, Brushes.Black);
                    ColOffset += Kolumna[i].Size;
                }
                y += LineHeight * MultiplyLine;
            }

            #endregion
            y += LineHeight;
            #region ---------------------------- Document body -----------------------------------
            while (y + HeaderLineHeight * 2 < PrintHeight && PH.Offset[0] < olvKlasa.Groups.Count)
            {
                if (PH.Offset[1] == 0)
                {
                    PH.DrawText(olvKlasa.Groups[PH.Offset[0]].ToString(), HeaderFont, x, y, PrintWidth, HeaderLineHeight, 0, Brushes.Black, false);
                    y += HeaderLineHeight;
                    PH.DrawLine(x, y, x + PrintWidth, y);
                    y += HeaderLineHeight;
                }

                while (y + LineHeight < PrintHeight && PH.Offset[1] < olvKlasa.Groups[PH.Offset[0]].Items.Count)
                {
                    PrintObjectData(olvKlasa.OLVGroups[PH.Offset[0]].Items[PH.Offset[1]].RowObject as SchoolClass, x, ref y, Kolumna, TextFont, LineHeight);
                    PH.Offset[1]++;
                }
                if (PH.Offset[1] < olvKlasa.OLVGroups[PH.Offset[0]].Items.Count)
                {
                    PH.PrintNextPage(Doc, e);
                }
                else
                {
                    y += LineHeight;
                    PH.Offset[1] = 0;
                    PH.Offset[0]++;
                }
            }
            if (PH.Offset[0] < olvKlasa.Groups.Count)
            {
                PH.PrintNextPage(Doc, e);
            }
            #endregion
        }
        private void PrintObjectData(SchoolClass Node, float x, ref float y, List<TableCellWithAlignment> PrintCol, Font PrintFont, float LineHeight)
        {
            List<string> AspectToPrint = new List<string>();

            AspectToPrint.Add(Node.ClassCode);
            AspectToPrint.Add(Node.ClassName);
            AspectToPrint.Add(Node.IsVirtual.ToString());

            for (int i = 0; i < AspectToPrint.Count; i++)
            {
                PH.DrawText(AspectToPrint[i], PrintFont, x, y, PrintCol[i].Size, LineHeight, PrintCol[i].Alignment, Brushes.Black, false, false);
                x += PrintCol[i].Size;
            }
            y += LineHeight;

        }

        private void olvKlasa_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            cmdDelete.Enabled = olvKlasa.CheckedObjects.Count > 0;
        }
    }
    public class SchoolClass
    {
        readonly static string[] classLineDescription = new string[] { "zerowe", "pierwsze", "drugie", "trzecie", "czwarte", "piąte", "szóste", "siódme", "ósme", "dziewiąte", "dziesiąte" };
        public static IDictionary<int, string> ClassLine { get; } = new Dictionary<int, string>();
        static SchoolClass()
        {
            IEnumerable<int> classLine;
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                classLine = dbs.FetchRecordSetAsync(SchoolClassSQL.SelectSchoolClassLine(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear), (R) => Convert.ToInt32(R[0])).Result;
            }
            foreach (var Line in classLine)
            {
                ClassLine.Add(Line, classLineDescription[Line]);
            }
        }

        public int ID { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public YesNo IsVirtual { get; set; }
        public Signature Creator { get; set; }
        public override string ToString() => ClassName;
    }
}
