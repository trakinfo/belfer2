using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Drawing.Printing;
using Belfer.Ustawienia;
using System.Threading.Tasks;
using DataBaseService;
using Autofac;

namespace Belfer
{
    public partial class frmObsada : Form
    {
        public event EventHandler TheEnd;
        public frmObsada()
        {
            InitializeComponent();
            AppUser.UserSettings.RaiseConfigChanged += ApplyNewConfig;
            lblRecord.Text = "";
            ListViewConfig(olvObsada);
            LoadFilterCriteria();

            GenerateColumns(olvObsada, SpecifyCols());
            //SelectString = selectQuery;
            ApplyNewConfig(this, null);
        }

        private void ApplyNewConfig(object sender, EventArgs e)
        {
            GetData(olvObsada);
        }

        private void pnlRecord_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlRecord.Left - 10, pnlRecord.Height - 1, pnlRecord.Width, pnlRecord.Height - 1);
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

            //olv.AlwaysGroupByColumn = GetGroupColumn();

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
            Cols.Add(new OLVColumn { Text = "Klasa", AspectName = "ClassName", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Oddział klasowy", UseInitialLetterForGroup = false, IsEditable = false, GroupKeyToTitleConverter = new GroupKeyToTitleConverterDelegate(x => string.Concat("Klasa ", x.ToString())), HeaderCheckBox = true });
            Cols.Add(new OLVColumn { Text = "Przedmiot", WordWrap = true, AspectName = "SubjectName", MinimumWidth = 100, Width = 150, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Przedmiot nauczania", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = false, IsEditable = false });
            Cols.Add(new OLVColumn { Text = "Podział\nna grupy", WordWrap = true, AspectName = "Group", MinimumWidth = 50, Width = 80, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Podział na grupy", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Kategoria", WordWrap = true, AspectName = "SubjectCategory", MinimumWidth = 50, Width = 80, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Kategoria przedmiotu (obowiązkowy lub nadobowiązkowy)", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = delegate (object cellValue) { return ((string)cellValue) == "o" ? "obowiązkowy" : "nieobowiąz."; } });
            Cols.Add(new OLVColumn { Text = "Uwzględnij\ndo średniej", WordWrap = true, AspectName = "ToAvg", MinimumWidth = 50, Width = 80, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Uwzględnij przedmiot przy liczeniu średniej ocen", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Data\naktywacji", WordWrap = true, AspectName = "StartDate", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data początkowa", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = delegate (object cellValue) { return ((DateTime)cellValue).ToShortDateString(); } });
            Cols.Add(new OLVColumn { Text = "Data\ndeaktywacji", WordWrap = true, AspectName = "EndDate", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data końcowa", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = delegate (object cellValue) { return ((DateTime)cellValue).ToShortDateString(); } });
            Cols.Add(new OLVColumn { Text = "Liczba godzin", WordWrap = true, AspectName = "LessonCount", MinimumWidth = 50, Width = 60, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba godzin", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false });
            Cols.Add(new OLVColumn { Text = "ID", AspectName = "ID", MinimumWidth = 0, Width = 0, MaximumWidth = 60, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Identyfikator pozycji", Groupable = false, IsEditable = false });

            return Cols;
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
        private async Task<IEnumerable<SubjectScheme>> GetSubjectList()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(SubjectSchemeSQL.SelectScheme(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear), SubjectSchemeModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private SubjectScheme SubjectSchemeModel(IDataReader R)
        {
            return new SubjectScheme
            {
                ID = Convert.ToInt32(R["ID"]),
                ClassName = R["NazwaKlasy"].ToString(),
                SubjectName = R["Nazwa"].ToString(),
                Group = (YesNo)Convert.ToInt64(R["Grupa"]),
                SubjectCategory = R["Kategoria"].ToString(),
                ToAvg = (YesNo)Convert.ToInt64(R["GetToAverage"]),
                StartDate = Convert.ToDateTime(R["DataAktywacji"]),
                EndDate = Convert.ToDateTime(R["DataDeaktywacji"]),
                LessonCount = Convert.ToSingle(R["LiczbaGodzin"]),
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
                GetSignature((SubjectScheme)((OLVListItem)e.Item).RowObject);
                //EnableButton(true);
            }
            else
            {
                lblRecord.Text = "0 z " + e.Item.ListView.Items.Count;
                ClearSignature();
                //EnableButton(false);
            }
        }

        private void GetSignature(SubjectScheme UserItem)
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
            using (var dlg = new dlgObsada(true))
            {
                //dlg.SchoolYearDateRange = new DateRange();
                dlg.cbKlasa.SelectedIndexChanged += dlg.cbKlasa_SelectedIndexChanged;
                dlg.NewRecordAdded += NewRecord;
                dlg.ShowDialog();
                dlg.NewRecordAdded -= NewRecord;
                dlg.cbKlasa.SelectedIndexChanged -= dlg.cbKlasa_SelectedIndexChanged;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            EditSubjectScheme();
        }
        private void EditSubjectScheme()
        {
            try
            {
                if (olvObsada.SelectedObject == null) return;
                var P = olvObsada.SelectedObject as SubjectScheme;
                using (var dlg = new dlgObsada(false))
                {
                    FillDialog(dlg, P);

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        //IsqlCommand cmd = new SqlCommand();
                        if (UpdateSubjectAsync(dlg, P).Result > 0)
                        {
                            //cmd.CommitTransaction();
                            NewRecord(P.ID);
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

        private async Task<int> UpdateSubjectAsync(dlgObsada dlg, SubjectScheme P)
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(SubjectSchemeSQL.UpdateScheme(), CreateUpdateParams(dlg, P));
            }
        }

        IDictionary<string, object> CreateUpdateParams(dlgObsada dlg, SubjectScheme p)
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@ID", p.ID);
            sqlParamWithValue.Add("@Grupa", dlg.chkGrupa.Checked);
            sqlParamWithValue.Add("@Kategoria", dlg.chkKategoria.Checked ? "o" : "n");
            sqlParamWithValue.Add("@Avg", dlg.chkAvg.Checked);
            sqlParamWithValue.Add("@DataAktywacji", dlg.dtStartDate.Value);
            sqlParamWithValue.Add("@DataDeaktywacji", dlg.dtEndDate.Value);
            sqlParamWithValue.Add("@LiczbaGodzin", dlg.nudLiczbaGodzin.Value);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        private void FillDialog(dlgObsada dlg, SubjectScheme P)
        {
            dlg.Text = "Edycja danych";
            dlg.cbKlasa.Enabled = false;
            dlg.cbPrzedmiot.Enabled = false;
            dlg.chkPion.Enabled = false;

            dlg.cbKlasa.Items.Add(P.ClassName);
            dlg.cbKlasa.SelectedIndex = 0;
            dlg.cbPrzedmiot.Items.Add(P.SubjectName);
            dlg.cbPrzedmiot.SelectedIndex = 0;
            dlg.chkAvg.Checked = P.ToAvg > 0;
            dlg.chkGrupa.Checked = P.Group > 0;
            dlg.chkKategoria.Checked = P.SubjectCategory == "o" ? true : false;
            dlg.dtStartDate.Value = P.StartDate;
            dlg.dtEndDate.Value = P.EndDate;
            dlg.nudLiczbaGodzin.Value = (decimal)P.LessonCount;
            dlg.cmdOK.Enabled = true;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (olvObsada.CheckedObjects.Count == 0) return;
            if (MessageBox.Show("Czy na pewno chcesz usunąć wskazane pozycje?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var recordCount = 0;
                    var sqlParamWithValue = new HashSet<Tuple<string, object>>();
                    foreach (SubjectScheme ss in olvObsada.CheckedObjects) sqlParamWithValue.Add(new Tuple<string, object>("@ID", ss.ID));
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        recordCount = dbs.RemoveManyRecordsAsync(SubjectSchemeSQL.DeleteScheme(), sqlParamWithValue).Result;
                    }
                    RefreshData();
                    MessageBox.Show($"{recordCount} rekordów zostało usuniętych.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            SeekHelper.SetListItem<SubjectScheme, long>(RecordID, "ID", olvObsada);
        }

        private void RefreshData()
        {
            //AppSession.Users = Authentication.GetUsers();
            //GetData(olvObsada);
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

        private void olvObsada_DoubleClick(object sender, EventArgs e) => cmdEdit_Click(sender, e);

        private void cmdImport_Click(object sender, EventArgs e)
        {
            using (var dlg = new dlgImportSubjectScheme())
            {
                dlg.nudStartYear.Maximum = UserSession.User.Settings.Year - 1;
                ListViewConfig(dlg.olvObsada);
                dlg.olvObsada.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClickAlways;
                dlg.olvObsada.CellEditUseWholeCell = true;
                dlg.olvObsada.CellEditEnterChangesRows = true;
                dlg.olvObsada.CheckBoxes = true;
                GenerateColumns(dlg.olvObsada, SpecifyCols());
                dlg.olvObsada.AllColumns.Where(x => x.AspectName == "ClassName").First().HeaderCheckBox = true;
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
            PH.ReportHeader = new List<string> { "Ramowy plan nauczania" };
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
            foreach (OLVColumn Col in olvObsada.AllColumns.Where(c => c.AspectName != "ID"))
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
            while (y + HeaderLineHeight * 2 < PrintHeight && PH.Offset[0] < olvObsada.Groups.Count)
            {
                if (PH.Offset[1] == 0)
                {
                    PH.DrawText(olvObsada.Groups[PH.Offset[0]].ToString(), HeaderFont, x, y, PrintWidth, HeaderLineHeight, 0, Brushes.Black, false);
                    y += HeaderLineHeight;
                    PH.DrawLine(x, y, x + PrintWidth, y);
                    y += HeaderLineHeight;
                }

                while (y + LineHeight < PrintHeight && PH.Offset[1] < olvObsada.Groups[PH.Offset[0]].Items.Count)
                {
                    PrintObjectData(olvObsada.OLVGroups[PH.Offset[0]].Items[PH.Offset[1]].RowObject as SubjectScheme, x, ref y, Kolumna, TextFont, LineHeight);
                    PH.Offset[1]++;
                }
                if (PH.Offset[1] < olvObsada.OLVGroups[PH.Offset[0]].Items.Count)
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
            if (PH.Offset[0] < olvObsada.Groups.Count)
            {
                PH.PrintNextPage(Doc, e);
            }
            #endregion
        }
        private void PrintObjectData(SubjectScheme Node, float x, ref float y, List<TableCellWithAlignment> PrintCol, Font PrintFont, float LineHeight)
        {
            List<string> AspectToPrint = new List<string>();

            AspectToPrint.Add(Node.ClassName);
            AspectToPrint.Add(Node.SubjectName);
            AspectToPrint.Add(Node.Group.ToString());
            AspectToPrint.Add(Node.SubjectCategory);
            AspectToPrint.Add(Node.ToAvg.ToString());
            AspectToPrint.Add(Node.StartDate.ToShortDateString());
            AspectToPrint.Add(Node.EndDate.ToShortDateString());
            AspectToPrint.Add(Node.LessonCount.ToString());

            for (int i = 0; i < AspectToPrint.Count; i++)
            {
                PH.DrawText(AspectToPrint[i], PrintFont, x, y, PrintCol[i].Size, LineHeight, PrintCol[i].Alignment, Brushes.Black, false, false);
                x += PrintCol[i].Size;
            }
            y += LineHeight;

        }

        private void olvObsada_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (olvObsada.CheckedObjects.Count > 0) EnableButton(true);
            else EnableButton(false);
        }
    }

    public class SubjectScheme
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public YesNo Group { get; set; }
        public string SubjectCategory { get; set; }
        public YesNo ToAvg { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float LessonCount { get; set; }
        public Signature Creator { get; set; }
    }

    public class Subject
    {
        public virtual int ID { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual int Priority { get; set; }
        public Signature Creator { get; set; }

        public override string ToString()
        {
            return Alias;
        }
    }
}
