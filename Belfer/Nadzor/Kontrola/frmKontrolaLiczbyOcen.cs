using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Drawing.Printing;
using Belfer.Nadzor;
using Autofac;
using DataBaseService;
using System.Threading.Tasks;
using Belfer.Administrator.Model;

namespace Belfer
{
    public partial class frmKontrolaLiczbyOcen : Form
    {
        public frmKontrolaLiczbyOcen()
        {
            InitializeComponent();
            AppUser.UserSettings.RaiseConfigChanged += ApplyNewConfig;
            ListViewConfig(tlvStudent);
            GenerateColumns(tlvStudent, SpecifyCols());
            nudLiczbaOcen.Value = (decimal)UserSession.User.Settings.Avg;
            nudLiczbaOcen.ValueChanged += nudAbsencja_ValueChanged;
            lblRecord.Text = default(string);
            var SeekCriteria = new string[] { "Klasa", "Uczeń" };
            cbSeek.Items.AddRange(SeekCriteria);
            cbSeek.SelectedIndex = 1;
            cbSeek.SelectedIndexChanged += cbSeek_SelectedIndexChanged;
            if (DateTime.Today.Month > 8)
            { rbSemestr.Checked = true; rbOkres = rbSemestr; }
            else { rbRokSzkolny.Checked = true; rbOkres = rbRokSzkolny; }
            rbSemestr.CheckedChanged += rbSemestr_CheckedChanged;
            rbRokSzkolny.CheckedChanged += rbSemestr_CheckedChanged;
        }
        #region ----------------------------------------- class fields --------------------------------------------
        public delegate void NewRowHandler();
        public event NewRowHandler NewRow;
        public event EventHandler TheEnd;
        private dlgWait Wait = new dlgWait { Tag = "Pobieranie danych ..." };
        private Timer tmRefresh;
        private RadioButton rbOkres;
        private List<string> ReportHeader;
        private int[] Offset = new int[1];
        private bool IsPreview;
        private int PageNumber = default(int);
        private PrintHelper PH = new PrintHelper();

        private IEnumerable<IdentUnit> lstKlasa = new List<IdentUnit>();
        private IEnumerable<SchoolStudent> lstStudent = new List<SchoolStudent>();
        private IEnumerable<ClassSubject> lstPrzedmiot = new List<ClassSubject>();
        private IEnumerable<IdentUnit> lstPrzedmiotNazwa = new List<IdentUnit>();
        private IEnumerable<ScoreInfo> lstWynik = new List<ScoreInfo>();
        #endregion

        #region --------------------------------------------- private classes for storing data fetched from database -----------------------------
        class SchoolStudent
        {
            public IdentUnit Student { get; set; }
            public IdentUnit StudentClass { get; set; }
            public bool ActivationStatus { get; set; }
        }
        class ScoreInfo
        {
            public int StudentID { get; set; }
            public SubjectColumn ScoreSubject { get; set; }
            public string ScoreName { get; set; }
            public float ScoreWeight { get; set; }
        }
        class SchoolSubject
        {
            public int SubjectID { get; set; }
            public string SubjectName { get; set; }
            public byte SubjectPriority { get; set; }
            public string SubjectType { get; set; }
        }
        class ClassSubject
        {
            public int ClassID { get; set; }
            public SchoolSubject Subject { get; set; }
        }
        class SubjectColumn
        {
            public ClassSubject SubjectInfo { get; set; }
            public float ColumnWeight { get; set; }
            public bool ColumnImprove { get; set; }
        }
        #endregion
        private class ScoreBranch
        {
            public List<ScoreBranch> Children = new List<ScoreBranch>();
            public List<ScoreInfo> Score;
            //public int Index { get; set; }

            public string Label { get; set; }
            public byte Level { get; set; }
            public int ScoreCount { get; set; }
            public string ScoreList { get { return GetScoreList(); } }

            public ScoreBranch() { Score = new List<ScoreInfo>(); }
            public ScoreBranch(List<ScoreInfo> ScoreList) { Score = ScoreList; }

            private string GetScoreList()
            {
                return string.Join(", ", Score.Select(x => x.ScoreName));
            }
        }

        private void frmKontrolaNieobecnosci_Shown(object sender, EventArgs e)
        {
            ApplyNewConfig(sender, null);
        }
        private void frmKontrolaNieobecnosci_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppUser.UserSettings.RaiseConfigChanged -= ApplyNewConfig;
            TheEnd?.Invoke(sender, e);
        }
        private List<OLVColumn> SpecifyCols()
        {
            var Cols = new List<OLVColumn>();
            Cols.Add(new OLVColumn { Text = "Uczeń", AspectName = "Label", MinimumWidth = 100, Width = 200, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię ucznia" });
            Cols.Add(new OLVColumn { Text = "Liczba ocen", WordWrap = true, AspectName = "ScoreCount", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Łączna liczba ocen", TextAlign = HorizontalAlignment.Center, IsHeaderVertical = false });
            Cols.Add(new OLVColumn { Text = "Lista ocen", AspectName = "ScoreList", MinimumWidth = 50, Width = 100, FillsFreeSpace = true, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Lista ocen" });

            return Cols;
        }
        private void ListViewConfig(TreeListView olv)
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
            olv.HeaderMinimumHeight = 30;
            HeaderFormatStyle HeaderStyle = new HeaderFormatStyle();
            HeaderStyle.SetFont(new Font(olv.Font.FontFamily, olv.Font.Size, FontStyle.Bold));
            olv.HeaderFormatStyle = HeaderStyle;
        }

        private void GenerateColumns(TreeListView olv, List<OLVColumn> Cols)
        {
            olv.AllColumns.Clear();
            olv.AllColumns.AddRange(Cols);
            olv.RebuildColumns();
        }

        private void ApplyNewConfig(object sender, EventArgs e)
        {
            rbSemestr_CheckedChanged(rbOkres, null);
        }
        private void rbSemestr_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false) return;
            rbOkres = (RadioButton)sender;
            RefreshData();
        }

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

            bwFetchData.RunWorkerAsync();
            tmRefresh.Start();
            Wait.ShowDialog();
        }
        private void tmRefresh_tick(Object sender, EventArgs e) => Wait.Refresh();

        private void cmdRefresh_Click(object sender, EventArgs e) => RefreshData();

        private void bwFetchData_DoWork(Object sender, DoWorkEventArgs e)
        {
            try
            {
                FetchData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bwFetchData_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            Wait.Close();
            tmRefresh.Stop();
            LoadSubject();
            RestrictData();
        }

        private void LoadSubject()
        {
            cbPrzedmiot.Items.Clear();
            lstPrzedmiotNazwa = lstPrzedmiot.Where(x => x.Subject.SubjectType != "Z").OrderBy(x => x.Subject.SubjectPriority).Select(x => new { x.Subject.SubjectID, x.Subject.SubjectName }).Distinct().ToList().Select(x => new IdentUnit { ID = x.SubjectID, Name = x.SubjectName }).ToList();
            //lstPrzedmiotNazwa.ForEach(x => cbPrzedmiot.Items.Add(x));
            cbPrzedmiot.Items.AddRange(lstPrzedmiotNazwa.ToArray());
            cbPrzedmiot.Items.Insert(0, IdentUnit.Empty);
        }

        private void FetchData()
        {
            try
            {
                lstStudent = FetchStudent().Result;
                lstPrzedmiot = FetchSubject().Result;
                lstWynik = FetchScoreInfo().Result;

                #region Stara wersja kodu
                //string sqlString;
                //sqlString = KontrolaSQL.SelectStudent(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear);
                //sqlString += KontrolaSQL.SelectPrzedmiot(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear);
                //sqlString += KontrolaSQL.SelectWynik(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, rbOkres.Tag.ToString());

                //using (var R = new MySqlCommand(SqlString, AppSession.Conn).ExecuteReader())
                //{
                //lstStudent.Clear();
                //while (R.Read())
                //{
                //    lstStudent.Add(new SchoolStudent
                //    {
                //        Student = new IdentUnit { ID = R.GetInt32("IdUczen"), Name = R.GetString("Student") },
                //        ActivationStatus = R.GetBoolean("StatusAktywacji"),
                //        StudentClass = new IdentUnit { ID = R.GetInt32("IdKlasa"), Name = R.GetString("NazwaKlasy") }
                //    }
                //                );
                //}
                //R.NextResult();

                //lstPrzedmiot.Clear();
                //while (R.Read())
                //{
                //    lstPrzedmiot.Add(new ClassSubject
                //    {
                //        ClassID = R.GetInt32("Klasa"),
                //        Subject = new SchoolSubject
                //        {
                //            SubjectID = R.GetInt32("ID"),
                //            SubjectName = R.GetString("Nazwa"),
                //            SubjectPriority = R.GetByte("Priorytet"),
                //            SubjectType = R.GetString("Typ")
                //        }
                //    });
                //}
                //R.NextResult();

                //lstWynik.Clear();
                //while (R.Read())
                //{
                //lstWynik.Add(new ScoreInfo
                //{
                //    StudentID = R.GetInt32("IdUczen"),
                //    ScoreName = R.GetString("Ocena"),
                //    ScoreWeight = R.GetFloat("WagaOceny"),
                //    ScoreSubject = new SubjectColumn
                //    {
                //        ColumnWeight = R.GetFloat("WagaKolumny"),
                //        SubjectInfo = new ClassSubject
                //        {
                //            ClassID = R.GetInt32("Klasa"),
                //            Subject = new SchoolSubject
                //            {
                //                SubjectID = R.GetInt32("IdPrzedmiot")
                //            }
                //        }
                //    }
                //});
                //}
                //}
                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<IEnumerable<ScoreInfo>> FetchScoreInfo()
        {
            var sqlString = KontrolaSQL.SelectWynik(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, rbOkres.Tag.ToString());
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new ScoreInfo
                {
                    StudentID = Convert.ToInt32(R["IdUczen"]),
                    ScoreName = R["Ocena"].ToString(),
                    ScoreWeight = Convert.ToSingle(R["WagaOceny"]),
                    ScoreSubject = new SubjectColumn
                    {
                        ColumnWeight = Convert.ToSingle(R["WagaKolumny"]),
                        SubjectInfo = new ClassSubject
                        {
                            ClassID = Convert.ToInt32(R["Klasa"]),
                            Subject = new SchoolSubject
                            {
                                SubjectID = Convert.ToInt32(R["IdPrzedmiot"])
                            }
                        }
                    }
                });
            }
        }

        async Task<IEnumerable<ClassSubject>> FetchSubject()
        {
            var sqlString = KontrolaSQL.SelectPrzedmiot(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new ClassSubject
                {
                    ClassID = Convert.ToInt32(R["Klasa"]),
                    Subject = new SchoolSubject
                    {
                        SubjectID = Convert.ToInt32(R["ID"]),
                        SubjectName = R["Nazwa"].ToString(),
                        SubjectPriority = Convert.ToByte(R["Priorytet"]),
                        SubjectType = R["Typ"].ToString()
                    }
                });
            }
        }

        async Task<IEnumerable<SchoolStudent>> FetchStudent()
        {
            var sqlString = StatystykaSQL.CountGroupMember(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new SchoolStudent
                {
                    Student = new IdentUnit { ID = Convert.ToInt32(R["IdUczen"]), Name = R["Student"].ToString() },
                    ActivationStatus = Convert.ToBoolean(R["StatusAktywacji"]),
                    StudentClass = new IdentUnit { ID = Convert.ToInt32(R["IdKlasa"]), Name = R["NazwaKlasy"].ToString() }
                });
            }
        }

        private void GetData()
        {
            try
            {
                pnlProgress.Visible = true;
                tlvStudent.Items.Clear();
                tlvStudent.ModelFilter = null;
                tlvStudent.CanExpandGetter = delegate (object SC) { return ((ScoreBranch)SC).Children.Count > 0; };
                tlvStudent.ChildrenGetter = delegate (object SC) { return ((ScoreBranch)SC).Children; };
                tlvStudent.BeginUpdate();
                tlvStudent.Roots = GetScoreTree();
                tlvStudent.EndUpdate();
                pnlProgress.Visible = false;
                Cursor = Cursors.WaitCursor;
                tlvStudent.ExpandAll();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ScoreBranch> GetScoreTree()
        {
            List<ScoreBranch> ScoreTree = new List<ScoreBranch>();

            pbrKlasa.Maximum = lstKlasa.ToList().Count;
            pbrKlasa.Value = 0;
            lblKlasa.Text = "";
            //int Index = -1;
            foreach (var K in lstKlasa)
            {
                var lstSubjectByClass = lstPrzedmiot.Where(x => x.Subject.SubjectType != "Z" & x.ClassID == K.ID).OrderBy(x => x.Subject.SubjectPriority).Select(x => new { x.Subject.SubjectID, x.Subject.SubjectName }).Distinct().ToList().Select(x => new IdentUnit { ID = x.SubjectID, Name = x.SubjectName }).ToList();
                var ClassNode = new ScoreBranch();
                ClassNode.Level = 0;
                //ClassNode.Index = ++Index;
                ClassNode.Label = K.Name;
                ClassNode.Children = GetClassScore(K, lstSubjectByClass);
                //ClassNode.Children.ForEach(x => ClassNode.Score.AddRange(x.Score));
                ClassNode.ScoreCount = ClassNode.Children.Sum(x => x.ScoreCount);
                pbrKlasa.Value++;
                lblKlasa.Text = pbrKlasa.Value.ToString() + "/" + pbrKlasa.Maximum;
                Refresh();
                ScoreTree.Add(ClassNode);
            }
            return ScoreTree;
        }

        private List<ScoreBranch> GetClassScore(IdentUnit Klasa, List<IdentUnit> lstPrzedmiot)
        {
            List<ScoreBranch> ClassScore = new List<ScoreBranch>();
            List<SchoolStudent> lstFilteredStudent = new List<SchoolStudent>();
            switch (cbSeek.SelectedIndex)
            {
                case 0:
                    lstFilteredStudent = lstStudent.Where(x => x.StudentClass.ID == Klasa.ID).Where(x => x.ActivationStatus == true).ToList();
                    break;
                case 1:
                    lstFilteredStudent = lstStudent.Where(x => x.StudentClass.ID == Klasa.ID).Where(x => x.ActivationStatus == true).Where(x => x.Student.Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();
                    break;
            }

            pbrStudent.Maximum = lstFilteredStudent.Count;
            pbrStudent.Value = 0;
            lblStudent.Text = "";
            //int Index = -1;
            foreach (var FS in lstFilteredStudent.OrderBy(x => x.Student.Name))
            {
                var StudentNode = new ScoreBranch();
                StudentNode.Level = 1;
                //StudentNode.Index = ++Index;
                StudentNode.Label = FS.Student.Name;
                StudentNode.Children = GetStudentScore(Klasa, FS.Student.ID, lstPrzedmiot);
                StudentNode.ScoreCount = StudentNode.Children.Sum(x => x.ScoreCount);
                pbrStudent.Value++;
                lblStudent.Text = pbrStudent.Value.ToString() + "/" + pbrStudent.Maximum;
                Refresh();
                ClassScore.Add(StudentNode);
            }
            return ClassScore;
        }
        private List<ScoreBranch> GetStudentScore(IdentUnit Klasa, int StudentID, List<IdentUnit> lstPrzedmiot)
        {
            List<ScoreBranch> StudentScore = new List<ScoreBranch>();
            //int Index = -1;
            foreach (var P in lstPrzedmiot)
            {
                var SubjectScore = new ScoreBranch();
                SubjectScore.Label = P.Name;
                SubjectScore.Level = 2;
                //SubjectScore.Index = ++Index;
                SubjectScore.Score = lstWynik.Where(x => x.StudentID == StudentID).Where(x => x.ScoreSubject.SubjectInfo.Subject.SubjectID == P.ID).Select(x => x).ToList();
                SubjectScore.ScoreCount = SubjectScore.Score.Count;
                StudentScore.Add(SubjectScore);
            }
            return StudentScore;
        }
        private void tlvStudent_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                lblRecord.Text = e.ItemIndex + 1 + " z " + ((TreeListView)e.Item.ListView).GetItemCount();
            }
            else
            {
                lblRecord.Text = "0 z " + ((TreeListView)e.Item.ListView).GetItemCount();
            }
        }
        private void nudAbsencja_ValueChanged(object sender, EventArgs e)
        {
            tlvStudent.ModelFilter = new ModelFilter(delegate (object x)
            {
                var Filter = ((ScoreBranch)x).ScoreCount <= (float)((NumericUpDown)sender).Value;
                if (cbPrzedmiot.SelectedItem != null)
                {
                    Filter = Filter & ((ScoreBranch)x).Label.StartsWith(((IdentUnit)cbPrzedmiot.SelectedItem).Name, StringComparison.CurrentCultureIgnoreCase);
                }

                return Filter;
            });

            lblRecord.Text = "0 z " + tlvStudent.GetItemCount();

            UserSession.User.Settings.ScoreCount = (byte)((NumericUpDown)sender).Value;
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void RestrictData()
        {
            //lstKlasa.Clear();
            switch (cbSeek.SelectedIndex)
            {
                case 0:
                    lstKlasa = lstStudent.Where(x => x.StudentClass.Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase)).Select(x => new { x.StudentClass.ID, x.StudentClass.Name }).Distinct().OrderBy(x => x.Name).Select(x => new IdentUnit { ID = x.ID, Name = x.Name }).AsEnumerable();
                    break;
                case 1:
                    lstKlasa = lstStudent.Where(x => x.Student.Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase)).Select(x => new { x.StudentClass.ID, x.StudentClass.Name }).Distinct().OrderBy(x => x.Name).Select(x => new IdentUnit { ID = x.ID, Name = x.Name }).AsEnumerable();
                    break;
            }
            GetData();
            nudAbsencja_ValueChanged(nudLiczbaOcen, null);
        }
        private void cbPrzedmiot_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudAbsencja_ValueChanged(nudLiczbaOcen, null);
        }
        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek.Focus();
        }

        private void txtSeek_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                RestrictData();
            }
        }
        #region ---------------------------------- Printing ------------------------------------------
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            dlgPrintPreview dlgPrint = new dlgPrintPreview();
            dlgPrint.PreviewModeChanged += PreviewModeChanged;
            NewRow += dlgPrint.NewRow;
            dlgPrint.Doc.BeginPrint += PrnDoc_BeginPrint;
            dlgPrint.Doc.PrintPage += tlvAnaliza_PrintPage;
            dlgPrint.Doc.EndPrint += tlvAnaliza_EndPrint;
            ReportHeader = new List<string> { "Systematyczność oceniania" };
            dlgPrint.ShowDialog();
        }

        private void tlvAnaliza_EndPrint(object sender, PrintEventArgs e)
        {
            PageNumber = 0;
            for (int i = 0; i < Offset.GetLength(0); i++)
            {
                Offset[i] = 0;
            }
        }

        private void PrnDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter) IsPreview = false; else IsPreview = true;
        }

        private void PreviewModeChanged(bool PreviewMode) => IsPreview = PreviewMode;

        private void tlvAnaliza_PrintPage(object sender, PrintPageEventArgs e)
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
            foreach (OLVColumn Col in tlvStudent.Columns)
            {
                Kolumna.Add(new TableCell { Name = Col.AspectName, Label = Col.Text, Size = Col.Width - 20 });
            }
            int FirstColWidth = PrintWidth - Kolumna.Where(K => K.Name != "Label").Sum(K => K.Size);
            if (FirstColWidth > 0) Kolumna.Where(K => K.Name == "Label").First().Size = FirstColWidth;
            #endregion

            #region ------------------------------- Table header --------------------------------
            float MultiplyLine = 3;
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
            ColOffset = 0;
            for (int i = 0; i < Kolumna.Count(); i++)
            {
                PH.DrawText((i + 1).ToString(), new Font(TextFont, FontStyle.Bold | FontStyle.Italic), x + ColOffset, y, Kolumna[i].Size, LineHeight, StringAlignment.Center, Brushes.Black);
                ColOffset += Kolumna[i].Size;
            }
            y += LineHeight * 1.5F;
            #endregion

            #region ------------------------ Table body --------------------------------
            int index = 0;
            int Indent = 0;
            bool Shade = false;
            Font PrintFont = null;
            var ListItems = tlvStudent.FilteredObjects.Cast<ScoreBranch>();
            while (y + LineHeight * 2 < PrintHeight && Offset[0] < ListItems.Count())
            {
                var ListItem = ListItems.ToArray()[Offset[0]];
                y += LineHeight * 0.5f;
                PrintFont = new Font(TextFont, FontStyle.Bold);
                switch (ListItem.Level)
                {
                    case 0:
                        Indent = 0;
                        MultiplyLine = 2;
                        Shade = true;
                        index = 0;
                        break;
                    case 1:
                        Indent = 20;
                        MultiplyLine = 2;
                        Shade = false;
                        index = 0;
                        break;
                    case 2:
                        Indent = 40;
                        MultiplyLine = 1;
                        Shade = false;
                        PrintFont = TextFont;
                        if (index > 0) { y -= LineHeight * 0.5f; }
                        index++;
                        break;
                }
                PrintModelObjectData(ListItem, x, ref y, Kolumna, PrintFont, LineHeight * MultiplyLine, Indent, Shade);
                Offset[0]++;
            }
            if (Offset[0] < ListItems.Count())
            {
                PrintNextPage(Doc, e);
            }

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
                    tlvAnaliza_PrintPage(Doc, ppea);
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
        private void PrintModelObjectData(ScoreBranch Node, float x, ref float y, List<TableCell> Kolumna, Font PrintFont, float LineHeight, int TabIndent = 0, bool FillBackground = false)
        {
            List<string> AspectToPrint = new List<string>();

            AspectToPrint.Add(Node.Label);
            AspectToPrint.Add(Node.ScoreCount.ToString());
            AspectToPrint.Add(Node.ScoreList);

            for (int i = 0; i < AspectToPrint.Count; i++)
            {
                PH.DrawText(AspectToPrint[i], PrintFont, i == 0 ? x + TabIndent : x, y, i == 0 ? Kolumna[i].Size - TabIndent : Kolumna[i].Size, LineHeight, i == 1 ? StringAlignment.Center : StringAlignment.Near, Brushes.Black, true, false, FillBackground);
                x += Kolumna[i].Size;
            }
            y += LineHeight;
        }




        #endregion


    }

}
