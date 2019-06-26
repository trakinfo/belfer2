using System;
using System.Windows.Forms;
using System.ComponentModel;
using BrightIdeasSoftware;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Printing;
using System.Drawing;
using Belfer.Nadzor;
using Autofac;
using DataBaseService;
using System.Threading.Tasks;
using System.Data;
using Belfer.Administrator.Model;
using Belfer.Helpers;

namespace Belfer
{
    public partial class frmZbiorczaAnalizaOcen : Form
    {
        public frmZbiorczaAnalizaOcen()
        {
            InitializeComponent();
            AppUser.UserSettings.RaiseConfigChanged += ApplyNewConfig;
            ListViewConfig(tlvAnaliza);
            GenerateColumns(tlvAnaliza, SpecifyCols());
        }
        public delegate void NewRowHandler();
        public event NewRowHandler NewRow;
        public delegate void AnalysisTypeHandler(AnalysisOption option);
        public event AnalysisTypeHandler SetAnalysisType;
        public event EventHandler TheEnd;
        private dlgWait Wait = new dlgWait { Tag = "Pobieranie danych ..." };
        private Timer tmRefresh;
        private RadioButton rbOkres, rbTyp;
        private int PageNumber = default(int);
        private List<string> ReportHeader;
        private int[] Offset = new int[3];
        private bool IsPreview;
        private AnalysisOption AnalysisType;
        private PrintHelper PH = new PrintHelper();
        private DateTime EndOfSemester = default(DateTime), EndOfSchoolYear = default(DateTime);
        private IEnumerable<SubjectStaff> lstObsada = new List<SubjectStaff>();
        private IEnumerable<ScoreInfo> lstLiczbaOcen = new List<ScoreInfo>();
        private IEnumerable<StudentCount> lstLiczbaUczniow = new List<StudentCount>();
        private IEnumerable<VirtualStudentCount> lstLiczbaUczniowNI = new List<VirtualStudentCount>();
        private IEnumerable<SubjectGroupCount> lstLiczbaUczniowGrupa = new List<SubjectGroupCount>();


        private void frmZbiorczaAnalizaOcen_Shown(object sender, EventArgs e)
        {
            rbSemestr.CheckedChanged += rbSemestr_CheckedChanged;
            rbRokSzkolny.CheckedChanged += rbSemestr_CheckedChanged;
            ApplyNewConfig(sender, e);
        }
        private void frmZbiorczaAnalizaOcen_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppUser.UserSettings.RaiseConfigChanged -= ApplyNewConfig;
            TheEnd?.Invoke(sender, e);
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
            olv.HeaderMinimumHeight = 50;
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
            int Year = DateTime.Today.Year;
            int.TryParse(DateTime.Today.Month > 8 ? UserSession.User.Settings.SchoolYear.Substring(0, 4) : UserSession.User.Settings.SchoolYear.Substring(5, 4), out Year);
            DateTime CurrentDate = new DateTime(Year, DateTime.Today.Month, DateTime.Today.Day);
            EndOfSemester = CalcHelper.StartDateOfSemester2(CurrentDate).AddDays(-1);
            EndOfSchoolYear = CalcHelper.EndDateOfSchoolYear(UserSession.User.Settings.SchoolYear);

            if (rbOkres == null)
            {
                if (CurrentDate <= EndOfSemester) { rbSemestr.Checked = true; } else { rbRokSzkolny.Checked = true; }
            }
            else
            {
                rbSemestr_CheckedChanged(rbOkres, null);
            }
        }

        private void rbSemestr_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false) return;
            rbOkres = (RadioButton)sender;
            RefreshData();
        }

        private void rbNauczyciel_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false) return;
            rbTyp = (RadioButton)sender;
            GetData(tlvAnaliza);
        }
        private List<OLVColumn> SpecifyCols()
        {
            var Cols = new List<OLVColumn>();
            Cols.Add(new OLVColumn { Text = "Klasa", AspectName = "Label", MinimumWidth = 100, Width = 205, FillsFreeSpace = true, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center });
            Cols.Add(new OLVColumn { Text = "Wymagana\nLiczba ocen", WordWrap = true, AspectName = "StudentCount", MinimumWidth = 50, Width = 85, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba uczniów w klasie", TextAlign = HorizontalAlignment.Center, IsHeaderVertical = false });
            Cols.Add(new OLVColumn { Text = "liczba \nwyst. ocen", WordWrap = true, AspectName = "TotalScoreCount", MinimumWidth = 50, Width = 85, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba wystawionych ocen", IsHeaderVertical = false });
            Cols.Add(new OLVColumn { Text = "nkl", WordWrap = true, AspectName = "UnclassifiedCount", MinimumWidth = 50, Width = 65, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba uczniów nieklasyfikowanych" });
            Cols.Add(new OLVColumn { Text = "cel", AspectName = "ExcelentCount", MinimumWidth = 50, Width = 65, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba ocen celujących" });
            Cols.Add(new OLVColumn { Text = "bdb", AspectName = "VeryGoodCount", MinimumWidth = 50, Width = 65, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba ocen bardzo dobrych" });
            Cols.Add(new OLVColumn { Text = "db", AspectName = "GoodCount", MinimumWidth = 50, Width = 65, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba ocen dobrych" });
            Cols.Add(new OLVColumn { Text = "dst", AspectName = "SufficientCount", MinimumWidth = 50, Width = 65, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba ocen dostatecznych" });
            Cols.Add(new OLVColumn { Text = "dps", AspectName = "PassedCount", MinimumWidth = 50, Width = 65, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba ocen dopuszczających" });
            Cols.Add(new OLVColumn { Text = "ndst", AspectName = "FailedCount", MinimumWidth = 50, Width = 65, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba ocen niedostatecznych", IsHeaderVertical = false });
            Cols.Add(new OLVColumn { Text = "Średnia", AspectName = "AvgScore", MinimumWidth = 40, Width = 40, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Średnia ocen", IsHeaderVertical = true });
            Cols.Add(new OLVColumn { Text = "Mediana", AspectName = "MedianScore", MinimumWidth = 30, Width = 40, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Wartość środkowa", IsHeaderVertical = true });
            Cols.Add(new OLVColumn { Text = "Dominanta", AspectName = "DominantScore", MinimumWidth = 30, Width = 30, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Ocena występująca najczęściej", IsHeaderVertical = true });

            return Cols;
        }

        private void rbLiczbowo_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false) return;
            AnalysisType = (AnalysisOption)Enum.Parse(typeof(AnalysisOption), ((RadioButton)sender).Tag.ToString());
            SetAnalysisType?.Invoke(AnalysisType);
            tlvAnaliza.RowHeight = AnalysisType == AnalysisOption.ByBoth ? 30 : -1;
            tlvAnaliza.Refresh();
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

            tmRefresh.Start();
            bwFetchData.RunWorkerAsync();
            Wait.ShowDialog();
        }

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


        private void FetchData()
        {
            try
            {
                lstObsada = FetchSubjectStaff().Result;
                lstLiczbaOcen = FetchScoreInfo().Result;
                lstLiczbaUczniow = FetchStudentCount().Result;
                lstLiczbaUczniowNI = FetchStudentNI().Result;
                lstLiczbaUczniowGrupa = FetchSubjectGroupCount().Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        async Task<IEnumerable<SubjectGroupCount>> FetchSubjectGroupCount()
        {
            var sqlString = StatystykaSQL.CountGroupMember(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new SubjectGroupCount
                {
                    ClassID = Convert.ToInt32(R["Klasa"]),
                    Count = Convert.ToInt32(R["StanGrupy"]),
                    SubjectID = Convert.ToInt32(R["IdPrzedmiot"]),
                    SubjectIdBySchool = Convert.ToInt32(R["IdSzkolaPrzedmiot"])
                });
            }
        }

        async Task<IEnumerable<VirtualStudentCount>> FetchStudentNI()
        {
            var sqlString = StatystykaSQL.SelectStanKlasyWirtualnej(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, rbOkres.Tag.ToString() == "S" ? EndOfSemester : EndOfSchoolYear);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new VirtualStudentCount
                {
                    ClassID = Convert.ToInt32(R["Klasa"]),
                    Count = Convert.ToInt32(R["StanKlasy"]),
                    SubjectID = Convert.ToInt32(R["IdPrzedmiot"]),
                    VirtualClassID = Convert.ToInt32(R["KlasaWirtualna"])
                });
            }
        }

        async Task<IEnumerable<StudentCount>> FetchStudentCount()
        {
            var sqlString = StatystykaSQL.SelectStanKlasy(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, rbOkres.Tag.ToString() == "S" ? EndOfSemester : EndOfSchoolYear);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new StudentCount { ClassID = Convert.ToInt32(R["Klasa"]), Count = Convert.ToInt32(R["StanKlasy"]) });
            }
        }

        async Task<IEnumerable<ScoreInfo>> FetchScoreInfo()
        {
            var sqlString = StatystykaSQL.SelectLiczbaOcen(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, rbOkres.Tag.ToString());
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new ScoreInfo
                {
                    ScoreCount = Convert.ToInt32(R["LiczbaOcen"]),
                    ScoreWeight = Convert.ToInt32(R["Waga"]),
                    ClassID = Convert.ToInt32(R["Klasa"]),
                    SubjectID = Convert.ToInt32(R["IdPrzedmiot"]),
                    TeacherID = Convert.ToInt32(R["Nauczyciel"])
                });
            }
        }

        async Task<IEnumerable<SubjectStaff>> FetchSubjectStaff()
        {
            var sqlString = StatystykaSQL.SelectObsada(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, rbOkres.Tag.ToString() == "S" ? EndOfSemester : EndOfSchoolYear);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new SubjectStaff
                {
                    Class = new StaffUnit { ID = Convert.ToInt32(R["Klasa"]), Nazwa = R["Nazwa_Klasy"].ToString() },
                    Subject = new SubjectUnit
                    {
                        ID = Convert.ToInt32(R["IdPrzedmiot"]),
                        Nazwa = R["Przedmiot"].ToString(),
                        IdSzkolaPrzedmiot = Convert.ToInt32(R["IdSzkolaPrzedmiot"])
                    },
                    Teacher = new StaffUnit { ID = Convert.ToInt32(R["IdNauczyciel"]), Nazwa = R["Nauczyciel"].ToString() },
                    IsVirtual = Convert.ToBoolean(R["IsVirtual"])
                });
            }
        }

        
        private void bwFetchData_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            Wait.Close();
            tmRefresh.Stop();
            if (rbTyp == null)
            {
                rbNauczyciel.Checked = true;
            }
            else
            {
                rbNauczyciel_CheckedChanged(rbTyp, null);
            }
        }
        private void tmRefresh_tick(Object sender, EventArgs e) => Wait.Refresh();

        private void GetData(TreeListView olv)
        {
            try
            {
                pbrProgress.Visible = true;
                olv.Items.Clear();
                olv.ModelFilter = null;
                olv.BeginUpdate();
                olv.CanExpandGetter = delegate (object SB) { return ((StaffBranch)SB).Children.Count > 0; };
                olv.ChildrenGetter = delegate (object SB) { return ((StaffBranch)SB).Children; };
                olv.Roots = GetAnalysisTree();
                olv.EndUpdate();
                olv.Expand(olv.TreeModel.GetNthObject(0));
                lblRecord.Text = "0 z " + olv.Items.Count;
                olv.Enabled = olv.Items.Count > 0 ? true : false;
                pbrProgress.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<StaffBranch> GetAnalysisTree()
        {
            List<StaffBranch> AnalysisTree = new List<StaffBranch>();

            var SchoolNode = new StaffBranch();
            SetAnalysisType += SchoolNode.SetOption;
            SchoolNode.Children = GetAnalysis();
            ComputeScore(SchoolNode, AppSession.Schools.Where(x => x.ID == UserSession.User.Settings.SchoolID).FirstOrDefault().ToString());
            AnalysisTree.Add(SchoolNode);
            return AnalysisTree;
        }
        private List<StaffBranch> GetAnalysis()
        {
            if (rbTyp.Name == rbNauczyciel.Name)
            {
                return GetAnalysisByTeacher();
            }
            else
            {
                return GetAnalysisBySubject();
            }
        }
        /// <summary>
        /// Set of methods providing analysis by teacher
        /// </summary>
        /// <returns></returns>
        #region Get tree analysis by teacher
        /// <summary>
        /// Get analysis by teacher
        /// </summary>
        /// <returns>List of teacher's nodes </returns>
        private List<StaffBranch> GetAnalysisByTeacher()
        {
            List<StaffBranch> AnalysisTree = new List<StaffBranch>();
            foreach (var Belfer in lstObsada.Select(x => new { x.Teacher.ID, x.Teacher.Nazwa }).Distinct().OrderBy(x => x.Nazwa).ToList())
            {
                TeacherUnit Teacher = new TeacherUnit { ID = Belfer.ID, Nazwa = Belfer.Nazwa };
                var TeacherNode = new StaffBranch();
                SetAnalysisType += TeacherNode.SetOption;
                TeacherNode.Children = GetAnalysisBySubject(Teacher);
                ComputeScore(TeacherNode, Belfer.Nazwa);
                AnalysisTree.Add(TeacherNode);
            }
            return AnalysisTree;
        }
        /// <summary>
        /// Get analysis by subject for pointed teacher
        /// </summary>
        /// <param name="Teacher">Teacher's data consists of ID and Name</param>
        /// <returns>List of subject nodes for pointed teacher</returns>
        private List<StaffBranch> GetAnalysisBySubject(StaffUnit Teacher)
        {
            var lstSubject = lstObsada.Where(x => x.Teacher.ID == Teacher.ID).Select(x => new { x.Subject.ID, x.Subject.Nazwa }).Distinct().ToList();
            List<StaffBranch> AnalysisTree = new List<StaffBranch>();
            foreach (var Przedmiot in lstSubject)
            {
                StaffUnit Subject = new StaffUnit { ID = Przedmiot.ID, Nazwa = Przedmiot.Nazwa };
                var SubjectNode = new StaffBranch();
                SetAnalysisType += SubjectNode.SetOption;
                SubjectNode.Children = GetAnalysisByClass(Teacher, Subject);
                ComputeScore(SubjectNode, Przedmiot.Nazwa);
                AnalysisTree.Add(SubjectNode);
            }
            return AnalysisTree;
        }
        #endregion

        #region Get tree analysis by subject
        private List<StaffBranch> GetAnalysisBySubject()
        {
            List<StaffBranch> AnalysisTree = new List<StaffBranch>();
            foreach (var Przedmiot in lstObsada.Select(x => new { x.Subject.ID, x.Subject.Nazwa }).Distinct().ToList())
            {
                SubjectUnit Subject = new SubjectUnit { ID = Przedmiot.ID, Nazwa = Przedmiot.Nazwa };
                var SubjectNode = new StaffBranch();
                SetAnalysisType += SubjectNode.SetOption;
                SubjectNode.Children = GetAnalysisByTeacher(Subject);
                ComputeScore(SubjectNode, Przedmiot.Nazwa);
                AnalysisTree.Add(SubjectNode);
            }
            return AnalysisTree;
        }
        /// <summary>
        /// Get analysis by teacher for pointed subject
        /// </summary>
        /// <param name="Subject">Subject's data consists of ID and Name</param>
        /// <returns>List of teacher nodes for pointed subject</returns>
        private List<StaffBranch> GetAnalysisByTeacher(StaffUnit Subject)
        {
            var lstTeacher = lstObsada.Where(x => x.Subject.ID == Subject.ID).Select(x => new { x.Teacher.ID, x.Teacher.Nazwa }).OrderBy(x => x.Nazwa).Distinct().ToList();
            List<StaffBranch> AnalysisTree = new List<StaffBranch>();
            foreach (var Belfer in lstTeacher)
            {
                StaffUnit Teacher = new StaffUnit { ID = Belfer.ID, Nazwa = Belfer.Nazwa };
                var TeacherNode = new StaffBranch();
                SetAnalysisType += TeacherNode.SetOption;
                TeacherNode.Children = GetAnalysisByClass(Teacher, Subject);
                ComputeScore(TeacherNode, Belfer.Nazwa);
                AnalysisTree.Add(TeacherNode);
            }
            return AnalysisTree;
        }
        #endregion
        #region Common analysis for both teacher and subject
        private List<StaffBranch> GetAnalysisByClass(StaffUnit Teacher, StaffUnit Subject)
        {
            List<StaffBranch> ClassNode = new List<StaffBranch>();
            var lstClass = lstObsada.Where(T => T.Teacher.ID == Teacher.ID).Where(S => S.Subject.ID == Subject.ID).Select(x => new { x.Class.ID, x.Class.Nazwa, x.IsVirtual }).Distinct().OrderBy(K => K.Nazwa).ToList();
            foreach (var Klasa in lstClass)
            {
                ClassNode.Add(GetClassAnalysis(Teacher, Subject, new StaffUnit { ID = Klasa.ID, Nazwa = Klasa.Nazwa }, Klasa.IsVirtual));
            }
            return ClassNode;
        }
        private StaffBranch GetClassAnalysis(StaffUnit Teacher, StaffUnit Subject, StaffUnit Class, bool IsVirtual)
        {
            int StanKlasy, StanKlasyWirtualnej;
            if (!IsVirtual)
            {
                StanKlasy = lstLiczbaUczniow.Where(x => x.ClassID == Class.ID).Select(x => x.Count).FirstOrDefault();
                StanKlasyWirtualnej = lstLiczbaUczniowNI.Where(x => x.SubjectID == Subject.ID).Where(x => x.ClassID == Class.ID).Select(x => x.Count).FirstOrDefault();
                StanKlasy -= StanKlasyWirtualnej;
                if (lstLiczbaUczniowGrupa.Where(x => x.ClassID == Class.ID).Where(x => x.SubjectID == Subject.ID).Count() > 0)
                {
                    var SubtractList = lstObsada.Where(T => T.Teacher.ID == Teacher.ID).Where(S => S.Subject.ID == Subject.ID).Where(C => C.Class.ID == Class.ID).Select(x => x.Subject.IdSzkolaPrzedmiot);
                    StanKlasy -= lstLiczbaUczniowGrupa.Where(x => x.ClassID == Class.ID).Where(x => x.SubjectID == Subject.ID).Where(x => !SubtractList.Contains(x.SubjectIdBySchool)).Sum(x => x.Count);
                }
            }
            else
            {
                StanKlasy = lstLiczbaUczniowNI.Where(x => x.SubjectID == Subject.ID).Where(x => x.VirtualClassID == Class.ID).Select(x => x.Count).FirstOrDefault();
            }
            var ClassNode = new StaffBranch();
            ClassNode.Label = Class.Nazwa;
            ClassNode.StudentCount = StanKlasy;
            ClassNode.ScoreCount = ComputeScore(Teacher, Subject, Class, ClassNode.ScoreCount.Count());
            SetAnalysisType += ClassNode.SetOption;
            return ClassNode;
        }
        private int[] ComputeScore(StaffUnit Teacher, StaffUnit Subject, StaffUnit Class, int ScoreArraySize)
        {
            int[] ScoreCount = new int[ScoreArraySize];
            List<ScoreInfo> lstScoreCount = lstLiczbaOcen.Where(SI => SI.TeacherID == Teacher.ID).Where(SI => SI.SubjectID == Subject.ID).Where(SI => SI.ClassID == Class.ID).ToList();
            for (int i = 0; i < ScoreCount.Count(); i++)
            {
                ScoreCount[i] = lstScoreCount.Where(W => W.ScoreWeight == i).Sum(x => x.ScoreCount);
            }
            return ScoreCount;
        }
        private void ComputeScore(StaffBranch Node, string Label)
        {
            Node.Label = Label;
            Node.StudentCount = Node.Children.Sum(x => x.StudentCount);
            for (int i = 0; i < Node.ScoreCount.Count(); i++)
            {
                Node.ScoreCount[i] = Node.Children.Sum(x => x.ScoreCount[i]);
            }
        }
        #endregion

        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void tlvAnaliza_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                lblRecord.Text = e.ItemIndex + 1 + " z " + e.Item.ListView.Items.Count;
            }
            else
            {
                lblRecord.Text = "0 z " + e.Item.ListView.Items.Count;
            }
        }

        private void tlvAnaliza_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            e.IsBalloon = true;
            switch (e.ColumnIndex)
            {
                case 2:
                    e.Text = ((ScoreAnalyser)e.Model).TotalScoreCount.ToString() + "\n";
                    e.Text += ((ScoreAnalyserByPercent)e.Model).TotalScoreCountByPercent().ToString() + "%";
                    break;
                case 3:
                    e.Text = ((ScoreAnalyser)e.Model).UnclassifiedCount.ToString() + "\n";
                    e.Text += ((ScoreAnalyserByPercent)e.Model).UnclassifiedCountByPercent().ToString() + "%";
                    break;
                case 4:
                    e.Text = ((ScoreAnalyser)e.Model).ExcelentCount.ToString() + "\n";
                    e.Text += ((ScoreAnalyserByPercent)e.Model).ExcelentCountByPercent().ToString() + "%";
                    break;
                case 5:
                    e.Text = ((ScoreAnalyser)e.Model).VeryGoodCount.ToString() + "\n";
                    e.Text += ((ScoreAnalyserByPercent)e.Model).VeryGoodCountByPercent().ToString() + "%";
                    break;
                case 6:
                    e.Text = ((ScoreAnalyser)e.Model).GoodCount.ToString() + "\n";
                    e.Text += ((ScoreAnalyserByPercent)e.Model).GoodCountByPercent().ToString() + "%";
                    break;
                case 7:
                    e.Text = ((ScoreAnalyser)e.Model).SufficientCount.ToString() + "\n";
                    e.Text += ((ScoreAnalyserByPercent)e.Model).SufficientCountByPercent().ToString() + "%";
                    break;
                case 8:
                    e.Text = ((ScoreAnalyser)e.Model).PassedCount.ToString() + "\n";
                    e.Text += ((ScoreAnalyserByPercent)e.Model).PassedCountByPercent().ToString() + "%";
                    break;
                case 9:
                    e.Text = ((ScoreAnalyser)e.Model).FailedCount.ToString() + "\n";
                    e.Text += ((ScoreAnalyserByPercent)e.Model).FailedCountByPercent().ToString() + "%";
                    break;
                case 10:
                    e.Text = ((StaffBranch)e.Model).AvgFull.ToString();
                    break;
            }
        }
        #region ---------------------------------- Printing ------------------------------------------
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            dlgPrintPreview dlgPrint = new dlgPrintPreview();
            dlgPrint.rbHorizontal.Checked = true;
            dlgPrint.PreviewModeChanged += PreviewModeChanged;
            NewRow += dlgPrint.NewRow;
            dlgPrint.Doc.BeginPrint += PrnDoc_BeginPrint;
            dlgPrint.Doc.PrintPage += tlvAnaliza_PrintPage;
            dlgPrint.Doc.EndPrint += tlvAnaliza_EndPrint;
            ReportHeader = new List<string> { "Zbiorcza analiza wyników nauczania" };
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

        private void PreviewModeChanged(bool PreviewMode) { IsPreview = PreviewMode; }

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
            foreach (OLVColumn Col in tlvAnaliza.Columns)
            {
                Kolumna.Add(new TableCell { Name = Col.AspectName, Label = Col.Text, Size = Col.Width });
            }
            int FirstColWidth = PrintWidth - Kolumna.Where(K => K.Name != "Label").Sum(K => K.Size);
            if (FirstColWidth > 0) Kolumna.Where(K => K.Name == "Label").First().Size = FirstColWidth;
            #endregion

            #region ------------------------------- Table header --------------------------------
            float MultiplyLine = 5;
            int ColOffset = 0;
            if (PageNumber == 1)
            {
                for (int i = 0; i < Kolumna.Count() - 3; i++)
                {
                    PH.DrawText(Kolumna[i].Label, new Font(TextFont, FontStyle.Bold), x + ColOffset, y, Kolumna[i].Size, LineHeight * MultiplyLine, StringAlignment.Center, Brushes.Black);
                    ColOffset += Kolumna[i].Size;
                }
                for (int i = Kolumna.Count() - 3; i < Kolumna.Count(); i++)
                {
                    PH.DrawText(Kolumna[i].Label, new Font(TextFont, FontStyle.Bold), x + ColOffset, y, Kolumna[i].Size, LineHeight * MultiplyLine, 0, Brushes.Black, 270);
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
            MultiplyLine = 3;
            StaffBranch Level0 = (StaffBranch)tlvAnaliza.GetModelObject(0);
            if (Offset[0] == 0 & Offset[1] == 0 & Offset[2] == 0)
            {
                PrintModelObjectData(Level0, x, ref y, Kolumna, new Font(TextFont, FontStyle.Bold), LineHeight * MultiplyLine, 0, true);
                y += LineHeight * 0.5F;
            }
            int Indent = 20;

            MultiplyLine = rbLiczbowoProcentowo.Checked ? 2 : 0;
            while (y + LineHeight * (4.5f + MultiplyLine) < PrintHeight && Offset[0] < Level0.Children.Count)
            {
                MultiplyLine = rbLiczbowoProcentowo.Checked ? 2 : 1;
                StaffBranch Level1 = Level0.Children[Offset[0]];
                if (Offset[1] == 0 & Offset[2] == 0)
                {
                    PrintModelObjectData(Level1, x, ref y, Kolumna, new Font(TextFont, FontStyle.Bold), LineHeight * MultiplyLine, Indent, true);
                    y += LineHeight * 0.5F;
                }

                while (y + LineHeight * 2 * MultiplyLine < PrintHeight && Offset[1] < Level1.Children.Count)
                {
                    StaffBranch Level2 = Level1.Children[Offset[1]];
                    if (Offset[2] == 0) PrintModelObjectData(Level2, x, ref y, Kolumna, new Font(TextFont, FontStyle.Bold), LineHeight * MultiplyLine, Indent * 2, true);

                    while (y + LineHeight * MultiplyLine < PrintHeight && Offset[2] < Level2.Children.Count)
                    {
                        StaffBranch Level3 = Level2.Children[Offset[2]];
                        PrintModelObjectData(Level3, x, ref y, Kolumna, TextFont, LineHeight * MultiplyLine, Indent * 3);
                        Offset[2] += 1;
                    }
                    if (Offset[2] < Level2.Children.Count)
                    {
                        PrintNextPage(Doc, e);
                        return;
                    }
                    else
                    {
                        y += LineHeight * 0.5f;
                        Offset[2] = 0;
                        Offset[1] += 1;
                    }
                }
                if (Offset[1] < Level1.Children.Count)
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
            if (Offset[0] < ((StaffBranch)tlvAnaliza.GetModelObject(0)).Children.Count)
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
        private void PrintModelObjectData(StaffBranch Node, float x, ref float y, List<TableCell> Kolumna, Font PrintFont, float LineHeight, int TabIndent = 0, bool FillBackground = false)
        {
            List<string> AspectToPrint = new List<string>();

            AspectToPrint.Add(Node.Label);
            AspectToPrint.Add(Node.StudentCount.ToString());
            AspectToPrint.Add(Node.TotalScoreCount);
            AspectToPrint.Add(Node.UnclassifiedCount);
            AspectToPrint.Add(Node.ExcelentCount);
            AspectToPrint.Add(Node.VeryGoodCount);
            AspectToPrint.Add(Node.GoodCount);
            AspectToPrint.Add(Node.SufficientCount);
            AspectToPrint.Add(Node.PassedCount);
            AspectToPrint.Add(Node.FailedCount);
            AspectToPrint.Add(Node.AvgScore.ToString());
            AspectToPrint.Add(Node.MedianScore.ToString());
            AspectToPrint.Add(Node.DominantScore.ToString());

            PH.DrawText(Node.Label, PrintFont, x + TabIndent, y, Kolumna[0].Size - TabIndent, LineHeight, 0, Brushes.Black, true, false, FillBackground);
            x += Kolumna[0].Size;

            for (int i = 1; i < AspectToPrint.Count; i++)
            {
                PH.DrawText(AspectToPrint[i], PrintFont, x, y, Kolumna[i].Size, LineHeight, StringAlignment.Center, Brushes.Black, true, false, FillBackground);
                x += Kolumna[i].Size;
            }
            y += LineHeight;
        }

        #endregion
        /// <summary>
        /// Klasy prywatne do użytku wewnętrznego
        /// </summary>

        #region ------------------------- Private classes for storing data fetched from database ------------------
        private class StaffUnit
        {
            public int ID { get; set; }
            public string Nazwa { get; set; }
        }
        private class TeacherUnit : StaffUnit { }
        private class SubjectUnit : StaffUnit
        {
            public int IdSzkolaPrzedmiot { get; set; }
        }
        private class SubjectStaff
        {
            public StaffUnit Class { get; set; }
            public SubjectUnit Subject { get; set; }
            public StaffUnit Teacher { get; set; }
            public bool IsVirtual { get; set; }
        }
        private class ScoreInfo
        {
            public int ScoreWeight { get; set; }
            public int ScoreCount { get; set; }
            public int ClassID { get; set; }
            public int SubjectID { get; set; }
            public int TeacherID { get; set; }
        }

        private class StudentCount
        {
            public int ClassID { get; set; }
            public int Count { get; set; }
        }

        private class VirtualStudentCount : StudentCount
        {
            public int VirtualClassID { get; set; }
            public int SubjectID { get; set; }
        }

        private class SubjectGroupCount : StudentCount
        {
            public int SubjectID { get; set; }
            public int SubjectIdBySchool { get; set; }
        }
        #endregion

        private class StaffBranch : ScoreAnalyserByPercent
        {
            private AnalysisOption Opcja;
            public List<StaffBranch> Children = new List<StaffBranch>();

            public void SetOption(AnalysisOption Value) => Opcja = Value;
            public StaffBranch()
            {
                SetOption(AnalysisOption.ByNumber);
            }
            public StaffBranch(AnalysisOption AnalysisType)
            {
                SetOption(AnalysisType);
            }
            public string AvgFull
            {
                get
                {
                    return Avg();
                }
            }
            public string AvgScore
            {
                get
                {
                    return Avg(2);
                }
            }
            public string MedianScore
            {
                get
                {
                    return Median();
                }
            }
            public string DominantScore
            {
                get
                {
                    return Dominant();
                }
            }

            public new string TotalScoreCount
            {
                get
                {
                    switch (Opcja)
                    {
                        case AnalysisOption.ByNumber:
                            return base.TotalScoreCount.ToString();
                        case AnalysisOption.ByPercent:
                            return string.Concat(TotalScoreCountByPercent(2).ToString(), "%");
                        default:
                            return string.Concat(base.TotalScoreCount.ToString(), "\n", TotalScoreCountByPercent(2).ToString(), "%");
                    }
                }
            }

            public new string ExcelentCount
            {
                get
                {
                    switch (Opcja)
                    {
                        case AnalysisOption.ByNumber:
                            return base.ExcelentCount.ToString();
                        case AnalysisOption.ByPercent:
                            return string.Concat(ExcelentCountByPercent(2).ToString(), "%");
                        default:
                            return string.Concat(base.ExcelentCount.ToString(), "\n", ExcelentCountByPercent(2).ToString(), "%"); ;
                    }
                }
            }
            public new string VeryGoodCount
            {
                get
                {
                    switch (Opcja)
                    {
                        case AnalysisOption.ByNumber:
                            return base.VeryGoodCount.ToString();
                        case AnalysisOption.ByPercent:
                            return string.Concat(VeryGoodCountByPercent(2).ToString(), "%");
                        default:
                            return string.Concat(base.VeryGoodCount.ToString(), "\n", VeryGoodCountByPercent(2).ToString(), "%"); ;
                    }
                }
            }

            public new string GoodCount
            {
                get
                {
                    switch (Opcja)
                    {
                        case AnalysisOption.ByNumber:
                            return base.GoodCount.ToString();
                        case AnalysisOption.ByPercent:
                            return string.Concat(GoodCountByPercent(2).ToString(), "%");
                        default:
                            return string.Concat(base.GoodCount.ToString(), "\n", GoodCountByPercent(2).ToString(), "%"); ;
                    }
                }
            }

            public new string SufficientCount
            {
                get
                {
                    switch (Opcja)
                    {
                        case AnalysisOption.ByNumber:
                            return base.SufficientCount.ToString();
                        case AnalysisOption.ByPercent:
                            return string.Concat(SufficientCountByPercent(2).ToString(), "%");
                        default:
                            return string.Concat(base.SufficientCount.ToString(), "\n", SufficientCountByPercent(2).ToString(), "%"); ;
                    }
                }
            }

            public new string PassedCount
            {
                get
                {
                    switch (Opcja)
                    {
                        case AnalysisOption.ByNumber:
                            return base.PassedCount.ToString();
                        case AnalysisOption.ByPercent:
                            return string.Concat(PassedCountByPercent(2).ToString(), "%");
                        default:
                            return string.Concat(base.PassedCount.ToString(), "\n", PassedCountByPercent(2).ToString(), "%"); ;
                    }
                }
            }

            public new string FailedCount
            {
                get
                {
                    switch (Opcja)
                    {
                        case AnalysisOption.ByNumber:
                            return base.FailedCount.ToString();
                        case AnalysisOption.ByPercent:
                            return string.Concat(FailedCountByPercent(2).ToString(), "%");
                        default:
                            return string.Concat(base.FailedCount.ToString(), "\n", FailedCountByPercent(2).ToString(), "%"); ;
                    }
                }
            }
            public new string UnclassifiedCount
            {
                get
                {
                    switch (Opcja)
                    {
                        case AnalysisOption.ByNumber:
                            return base.UnclassifiedCount.ToString();
                        case AnalysisOption.ByPercent:
                            return string.Concat(UnclassifiedCountByPercent(2).ToString(), "%");
                        default:
                            return string.Concat(base.UnclassifiedCount.ToString(), "\n", UnclassifiedCountByPercent(2).ToString(), "%"); ;
                    }
                }
            }
            private string Avg()
            {
                var SA = new ScoreAggregate();
                SA.ScoreCount = ScoreCount;
                return SA.Avg().ToString();
            }
            private string Avg(byte decimalPlaces)
            {
                var SA = new ScoreAggregate();
                SA.ScoreCount = ScoreCount;
                return SA.Avg(decimalPlaces).ToString();
            }
            private string Median()
            {
                var SA = new ScoreAggregate();
                SA.ScoreCount = ScoreCount;
                return SA.Median().ToString();
            }
            private string Dominant()
            {
                var SA = new ScoreAggregate();
                SA.ScoreCount = ScoreCount;
                return SA.Dominant().ToString();
            }
        }
    }
}
