using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.ComponentModel;
using System.Linq;
using System.Drawing.Printing;
using System.Drawing;
using Belfer.Nadzor;
using Autofac;
using System.Threading.Tasks;
using Belfer.Administrator.Model;

namespace Belfer
{
    public partial class frmZbiorczyWykazEgzaminPoprawkowy : Form
    {
        public frmZbiorczyWykazEgzaminPoprawkowy()
        {
            InitializeComponent();
			AppUser.UserSettings.RaiseConfigChanged += ApplyNewConfig;
            var SeekCriteria = new string[] { "Klasa", "Przedmiot", "Nazwisko i imię ucznia", "Nazwisko i imię nauczyciela" };
            cbSeek.Items.AddRange(SeekCriteria);
            cbSeek.SelectedIndex = 0;
            ListViewConfig(olvStudent);
            GenerateColumns(olvStudent, SpecifyCols());
            rbZakres = rbAll;
            lblRecord.Text = default(string);
        }
        #region ----------------------------------------- class fields --------------------------------------------
        public delegate void NewRowHandler();
        public event NewRowHandler NewRow;
        public event EventHandler TheEnd;
        private dlgWait Wait = new dlgWait { Tag = "Pobieranie danych ..." };
        private Timer tmRefresh;
        private RadioButton rbZakres;
        private IEnumerable<MakeUp> lstStudent = new List<MakeUp>();
        private List<string> ReportHeader;
        private int[] Offset = new int[2];
        private bool IsPreview;
        private int PageNumber = default(int);
        private PrintHelper PH = new PrintHelper(); 
        #endregion

        private void frmZbiorczyWykazEgzaminPoprawkowy_Load(object sender, EventArgs e)
        {
            ApplyNewConfig(sender,e);
        }
        private void frmZbiorczyWykazEgzaminPoprawkowy_FormClosed(object sender, FormClosedEventArgs e)
        {
			AppUser.UserSettings.RaiseConfigChanged -= ApplyNewConfig;
            TheEnd?.Invoke(sender, e);
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
            olv.HeaderMaximumHeight = 30;
            olv.HeaderMinimumHeight = 30;
            HeaderFormatStyle HeaderStyle = new HeaderFormatStyle();
            HeaderStyle.SetFont(new System.Drawing.Font(olv.Font.FontFamily, olv.Font.Size, System.Drawing.FontStyle.Bold));
            olv.HeaderFormatStyle = HeaderStyle;
        }

        private void GenerateColumns(ObjectListView olv, List<OLVColumn> Cols)
        {
            olv.AllColumns.Clear();
            olv.AllColumns.AddRange(Cols);
            olv.RebuildColumns();
        }

        private void ApplyNewConfig(object sender, EventArgs e)
        {
            RefreshData();
            rbAll_CheckedChanged(rbZakres, new EventArgs());
        }
        private List<OLVColumn> SpecifyCols()
        {
            var Cols = new List<OLVColumn>();
            Cols.Add(new OLVColumn { Text = "Uczeń", AspectName = "StudentName", MinimumWidth = 150, Width = 200, FillsFreeSpace = true, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię ucznia", UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Klasa", AspectName = "StudentClass", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center,ToolTipText="Przydział klasowy" });
            Cols.Add(new OLVColumn { Text = "Przedmiot", AspectName = "SubjectName", MinimumWidth = 150, Width = 200, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię nauczyciela prowadzącego", TextAlign = HorizontalAlignment.Left, IsHeaderVertical = false });
            Cols.Add(new OLVColumn { Text = "Nauczyciel", AspectName = "TeacherName", MinimumWidth = 150, Width = 200, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię nauczyciela prowadzącego", TextAlign = HorizontalAlignment.Left, IsHeaderVertical = false });

            return Cols;
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false) return;
            if (!rbZakres.Equals(sender)) rbZakres = (RadioButton)sender;           
            GetData(olvStudent);
        }
        private void GetData(ObjectListView olv)
        {
            try
            {
                olv.BeginUpdate();
                olv.Items.Clear();
                olv.SetObjects(GetStudentList());
                olv.EndUpdate();
                lblRecord.Text = "0 z " + olv.Items.Count;
                olv.Enabled = olv.Items.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<MakeUp> GetStudentList()
        {
            var Students = new List<MakeUp>();
            if (rbZakres.Name==rbAll.Name)
            {
                Students.AddRange(lstStudent.OrderBy(S=>S.StudentName).ToList());
            }
            else
            {
                var GroupCount = lstStudent.GroupBy(S => S.StudentID).Select(S => new { StudentID = S.Key, StudentCount = S.Count() });
                byte FailedCount;
                byte.TryParse(rbZakres.Tag.ToString(), out FailedCount);
                GroupCount = GroupCount.Where(G => G.StudentCount == FailedCount);
                foreach (var G in GroupCount)
                {
                    Students.AddRange(lstStudent.Where(S => S.StudentID == G.StudentID).OrderBy(S => S.StudentName).ToList());
                }
            }
            return Students;
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();
        private void RefreshData()
        {
            var bwFetchData = new BackgroundWorker();
            bwFetchData.DoWork -= bwFetchData_DoWork;
            bwFetchData.DoWork += bwFetchData_DoWork;
            bwFetchData.RunWorkerCompleted -= bwFetchData_RunWorkerCompleted;
            bwFetchData.RunWorkerCompleted += bwFetchData_RunWorkerCompleted;

            tmRefresh = new Timer { Interval = 500 };
            tmRefresh.Tick -= tmRefresh_tick;
            tmRefresh.Tick += tmRefresh_tick;

            tmRefresh.Start();
            bwFetchData.RunWorkerAsync();
            Wait.ShowDialog();
        }
        private void cmdRefresh_Click(object sender, EventArgs e) => ApplyNewConfig(sender, e);

        private void bwFetchData_DoWork(Object sender, DoWorkEventArgs e)
        {
            try
            {
                FetchData().Wait();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        async Task FetchData()
        {
            try
            {
                //string SqlString;
                var sqlString = PoprawkaSQL.SelectStudent(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear);
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<DataBaseService.IDataBaseService>();
                    lstStudent = await dbs.FetchRecordSetAsync(sqlString, (R) => new MakeUp
                    {
                        StudentID = Convert.ToInt32(R["Klasa"]),
                        StudentName = R["Student"].ToString(),
                        StudentClass = R["Klasa"].ToString(),
                        SubjectName = R["Przedmiot"].ToString(),
                        TeacherName = R["Nauczyciel"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void bwFetchData_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            Wait.Close();
            tmRefresh.Stop();
        }
        private void tmRefresh_tick(Object sender, EventArgs e) => Wait.Refresh();



        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Focus();
        }

        private void txtSeek_TextChanged(object sender, EventArgs e)
        {
            switch (cbSeek.SelectedIndex)
            {
                case 0:
                    olvStudent.ModelFilter = new ModelFilter(x => ((MakeUp)x).StudentClass.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 1:
                    olvStudent.ModelFilter = new ModelFilter(x => ((MakeUp)x).SubjectName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 2:
                    olvStudent.ModelFilter = new ModelFilter(x => ((MakeUp)x).StudentName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 3:
                    olvStudent.ModelFilter = new ModelFilter(x => ((MakeUp)x).TeacherName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;

            }

            lblRecord.Text = "0 z " + olvStudent.GetItemCount();
        }

        private class MakeUp
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public string StudentClass { get; set; }
            public string SubjectName { get; set; }
            public string TeacherName { get; set; }
        }

        #region ----------------------------------------- Printing ----------------------------------------
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            dlgPrintPreview dlgPrint = new dlgPrintPreview();
            //dlgPrint.rbHorizontal.Checked = true;
            dlgPrint.PreviewModeChanged += PreviewModeChanged;
            NewRow += dlgPrint.NewRow;
            dlgPrint.Doc.BeginPrint += prnDoc_BeginPrint;
            dlgPrint.Doc.PrintPage += prnDoc_PrintPage;
            dlgPrint.Doc.EndPrint += prnDoc_EndPrint;
            ReportHeader = new List<string> { "Wykaz uczniów dopuszczonych do egzaminu poprawkowego" };
            dlgPrint.ShowDialog();
        }
        private void prnDoc_EndPrint(object sender, PrintEventArgs e)
        {
            PageNumber = 0;
            for (int i = 0; i < Offset.GetLength(0); i++)
            {
                Offset[i] = 0;
            }
        }

        private void prnDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter) IsPreview = false; else IsPreview = true;
        }

        private void PreviewModeChanged(bool PreviewMode) => IsPreview = PreviewMode;

        private void prnDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            #region -------------------------- Print variables definitions -----------------------
            PH.G = e.Graphics;
            PrintDocument Doc = (PrintDocument)sender;
            float x = IsPreview ? UserSession.User.Settings.LeftMargin : UserSession.User.Settings.LeftMargin - e.PageSettings.PrintableArea.Left;
            float y = IsPreview ? UserSession.User.Settings.TopMargin : UserSession.User.Settings.TopMargin - e.PageSettings.PrintableArea.Top;
            Font TextFont = UserSession.User.Settings.TextFont;
            Font SubHeaderFont = UserSession.User.Settings.SubHeaderFont;
            Font HeaderFont = UserSession.User.Settings.HeaderFont;
            float LineHeight = TextFont.GetHeight(e.Graphics);
            float SubHeaderLineHeight = SubHeaderFont.GetHeight(e.Graphics);
            float HeaderLineHeight = HeaderFont.GetHeight(e.Graphics);
            int PrintWidth = e.MarginBounds.Width;
            int PrintHeight = e.MarginBounds.Bottom;
            #endregion

            PageNumber += 1;

            #region --------------------------- Document header and footer -----------------------
            PH.DrawHeader(x, y, PrintWidth);
            PH.DrawFooter(x, PrintHeight, PrintWidth);
            PH.DrawPageNumber("- " + PageNumber.ToString() + " -", x, PrintHeight, PrintWidth, PageNumberLocation.Footer);
            #endregion
            #region ------------------------------ Report header -----------------------------------
            if (PageNumber == 1)
            {
                y += LineHeight;
                PH.DrawText(ReportHeader[0], HeaderFont, x, y, PrintWidth, HeaderLineHeight, StringAlignment.Center, Brushes.Black, false);
                y += HeaderLineHeight * 2;
            }
            #endregion
            #region ------------------------------- Column Settings --------------------------
            List<TableCell> Kolumna = new List<TableCell>();
            foreach (OLVColumn Col in olvStudent.Columns)
            {
                Kolumna.Add(new TableCell { Name = Col.AspectName, Label = Col.Text, Size = Col.Width });
            }
            int SpaceWidth = PrintWidth - Kolumna.Sum(K => K.Size);
            int Space = SpaceWidth / Kolumna.Count;
            foreach (var col in Kolumna)
            {
                col.Size += Space;
            }
            #endregion

            #region ------------------------------- Table header --------------------------------
            float MultiplyLine = 2;
            int ColOffset = 0;
            if (PageNumber == 1)
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
            #region ------------------------ Table body --------------------------------
            MultiplyLine = 2.2f;
            while (y + LineHeight * MultiplyLine < PrintHeight && Offset[0] < olvStudent.Groups.Count)
            {
                if (Offset[1] == 0)
                {
                    PH.DrawText(olvStudent.Groups[Offset[0]].Header, SubHeaderFont, x, y, PrintWidth, SubHeaderLineHeight, 0, Brushes.Black, false);
                    y += LineHeight * 1.2f;
                    PH.DrawLine(x, y, x + PrintWidth, y);
                    y += LineHeight * 0.5f;
                }
                MultiplyLine = 1;
                while (y + LineHeight * MultiplyLine < PrintHeight && Offset[1] < olvStudent.Groups[Offset[0]].Items.Count)
                {
                    int colSize = 0;
                    for (int i = 0; i < Kolumna.Count; i++)
                    {
                        PH.DrawText(olvStudent.Groups[Offset[0]].Items[Offset[1]].SubItems[i].Text, TextFont, x + colSize, y, Kolumna[i].Size, LineHeight * MultiplyLine, i == 1 ? StringAlignment.Center : StringAlignment.Near, Brushes.Black, false);
                        colSize += Kolumna[i].Size;
                    }
                    y += LineHeight;
                    Offset[1] += 1;
                }
                y += LineHeight;

                if (Offset[1] < olvStudent.Groups[Offset[0]].Items.Count)
                {
                    PrintNextPage(Doc, e);
                    return;
                }
                else
                {
                    Offset[1] = 0;
                    Offset[0] += 1;
                }
            }
            if (Offset[0] < olvStudent.Groups.Count) PrintNextPage(Doc, e);

            #endregion
        }
        private void PrintNextPage(PrintDocument Doc, PrintPageEventArgs ppea)
        {
            if (IsPreview)
            {
                ppea.HasMorePages = true;
                NewRow?.Invoke();
                return;
            }
            if (ppea.PageSettings.PrinterSettings.PrintRange == PrintRange.SomePages)
            {
                if (!PageInRange(ppea.PageSettings.PrinterSettings.FromPage, ppea.PageSettings.PrinterSettings.ToPage))
                {
                    ppea.Graphics.Clear(Color.White);
                    prnDoc_PrintPage(Doc, ppea);
                }
                ppea.HasMorePages = PageNumber < ppea.PageSettings.PrinterSettings.ToPage;
                return;
            }
            ppea.HasMorePages = true;
        }
        private bool PageInRange(int RangeStart, int RangeEnd)
        {
            bool IsPageInRange = PageNumber >= RangeStart;
            IsPageInRange = IsPageInRange && (PageNumber <= RangeEnd);
            return IsPageInRange;
        }

        #endregion

    }
}
