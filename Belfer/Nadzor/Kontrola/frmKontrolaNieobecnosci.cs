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
using System.Threading.Tasks;
using Autofac;
using DataBaseService;

namespace Belfer
{
    public partial class frmKontrolaNieobecnosci : Form
    {
        public frmKontrolaNieobecnosci()
        {
            InitializeComponent();
            AppUser.UserSettings.RaiseConfigChanged += ApplyNewConfig;
            ListViewConfig(tlvStudent);
            GenerateColumns(tlvStudent, SpecifyCols());
            nudAbsencja.Value = (decimal)UserSession.User.Settings.AbsenceLevel;
            nudAbsencja.ValueChanged += nudAbsencja_ValueChanged;
            lblRecord.Text = default(string);
            var SeekCriteria = new string[] { "Klasa", "Uczeń" };
            cbSeek.Items.AddRange(SeekCriteria);
            cbSeek.SelectedIndex = 1;
            cbSeek.SelectedIndexChanged += cbSeek_SelectedIndexChanged;

        }
        #region ----------------------------------------- class fields --------------------------------------------
        public delegate void NewRowHandler();
        public event NewRowHandler NewRow;
        public event EventHandler TheEnd;
        private dlgWait Wait = new dlgWait { Tag = "Pobieranie danych ..." };
        private Timer tmRefresh;
        private List<string> ReportHeader;
        private int[] Offset = new int[1];
        private bool IsPreview;
        private int PageNumber = default(int);
        private PrintHelper PH = new PrintHelper();
        DateRange SchoolDateRange;
        DateTime CurrentDate = DateTime.Today;

        private List<IdentUnit> lstKlasa = new List<IdentUnit>();
        private IEnumerable<SchoolStudent> lstStudent = new List<SchoolStudent>();
        private IEnumerable<ClassSubject> lstPrzedmiot = new List<ClassSubject>();
        private IEnumerable<SchoolLesson> lstLekcja = new List<SchoolLesson>();
        private IEnumerable<SchoolSubjectGroup> lstGrupa = new List<SchoolSubjectGroup>();
        private IEnumerable<StudentAbsence> lstAbsencja = new List<StudentAbsence>();
        #endregion

        #region --------------------------------------------- private classes for storing data fetched from database -----------------------------
        class SchoolStudent
        {
            public IdentUnit Student { get; set; }
            public IdentUnit StudentClass { get; set; }
            public bool ActivationStatus { get; set; }
            public DateTime ActivationDate { get; set; }
            public DateTime DeactivationDate { get; set; }
            public bool MasterRecord { get; set; }
            public IndividualCourse IndividualMode { get; set; }
        }
        class IndividualCourse
        {
            public SchoolSubject SchoolSubject { get; set; }
            public int VirtualClassID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        class SchoolLesson
        {
            public int LessonID { get; set; }
            public DateTime LessonDate { get; set; }
            public ClassSubject Subject { get; set; }
        }
        class SchoolSubject
        {
            public int SubjectID { get; set; }
            public string SubjectName { get; set; }
            public byte SubjectPriority { get; set; }
        }
        class ClassSubject : SchoolSubject
        {
            public int ClassID { get; set; }
            public YesNo Group { get; set; }
        }
        class SchoolSubjectGroup
        {
            public int GroupID { get; set; }
            public int SubjectID { get; set; }
            public int StudentID { get; set; }
            public int ClassID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        class StudentAbsence
        {
            public int StudentID { get; set; }
            public int SubjectID { get; set; }
            public int AbsenceCount { get; set; }
            public string AbsenceType { get; set; }
            public DateTime AbsenceDate { get; set; }
        }

        #endregion
        private class AbsenceBranch
        {
            public List<AbsenceBranch> Children = new List<AbsenceBranch>();
            public string Label { get; set; }
            public byte Level { get; set; }
            public float StudentAbsencePercent { get { return TotalAbsenceCountByPercent(2); } }
            public int StudentAbsenceCount { get { return JustifiedAbsenceCount + UnjustifiedAbsenceCount; } }
            public int LessonCount { get; set; }
            public int JustifiedAbsenceCount { get; set; }
            public int UnjustifiedAbsenceCount { get; set; }

            public float TotalAbsenceCountByPercent()
            {
                return (float)StudentAbsenceCount * 100 / LessonCount;
            }
            public float TotalAbsenceCountByPercent(byte decimalPlaces)
            {
                return (float)Math.Round(TotalAbsenceCountByPercent(), decimalPlaces);
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
            Cols.Add(new OLVColumn { Text = "Uczeń", AspectName = "Label", MinimumWidth = 100, Width = 200, FillsFreeSpace = true, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię ucznia" });
            Cols.Add(new OLVColumn { Text = "Absencja", WordWrap = true, AspectName = "StudentAbsencePercent", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Absencja ucznia wyrażona procentowo", TextAlign = HorizontalAlignment.Center, IsHeaderVertical = false, AspectToStringConverter = delegate (object x) { return string.Concat(x, " %"); } });
            Cols.Add(new OLVColumn { Text = "Liczba\nlekcji", AspectName = "LessonCount", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Łączna liczba zajęć lekcyjnych" });
            Cols.Add(new OLVColumn { Text = "Liczba godz.\nopuszczonych", WordWrap = true, AspectName = "StudentAbsenceCount", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Łączna liczba nieobecności", IsHeaderVertical = false });
            Cols.Add(new OLVColumn { Text = "Liczba godz.\nusprawied.", WordWrap = true, AspectName = "JustifiedAbsenceCount", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba nieobecności usprawiedliwionych" });
            Cols.Add(new OLVColumn { Text = "Liczba godz.\nnieusprawied.", AspectName = "UnjustifiedAbsenceCount", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Liczba nieobecności nieusprawiedliwionych" });

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
            SetDateParams();
            RefreshData();
        }
        private void SetDateParams()
        {
            SchoolDateRange = new DateRange(UserSession.User.Settings.SchoolYear);
            int Year = CurrentDate.Year;
            int.TryParse(CurrentDate.Month > 8 ? UserSession.User.Settings.SchoolYear.Substring(0, 4) : UserSession.User.Settings.SchoolYear.Substring(5, 4), out Year);
            CurrentDate = new DateTime(Year, CurrentDate.Month, CurrentDate.Day);
            SetDateTimePickerParams();
        }
        private void SetDateTimePickerParams()
        {
            if (CurrentDate > dtpData.MaxDate)
            {
                dtpData.MaxDate = SchoolDateRange.EndDate;
                dtpData.Value = CurrentDate;
                dtpData.MinDate = SchoolDateRange.StartDate;
            }
            else
            {
                dtpData.MinDate = SchoolDateRange.StartDate;
                dtpData.Value = CurrentDate;
                dtpData.MaxDate = SchoolDateRange.EndDate;
            }
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
                MessageBox.Show(ex.Message);
            }
        }
        private void bwFetchData_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            //Wait.Hide();
            Wait.Close();
            tmRefresh.Stop();
            dtpData_CloseUp(dtpData, null);
        }
        private void FetchData()
        {
            try
            {
                lstStudent = FetchStudentList().Result;
                lstPrzedmiot = FetchSubjectList().Result;
                lstLekcja = FetchLessonList().Result;
                lstGrupa = FetchGroupList().Result;
                lstAbsencja = FetchAbsenceList().Result;
                #region Stara wersja kodu
                //            var sqlString = new Dictionary<string, string>();
                //            sqlString.Add("GetStudentList",KontrolaSQL.SelectStudent(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear));
                //            sqlString.Add("GetSubjectList",KontrolaSQL.SelectPrzedmiot(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear));
                //sqlString.Add("GetLessonList",KontrolaSQL.SelectLekcja(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, SchoolDateRange));
                //sqlString.Add("GetGroupList",KontrolaSQL.SelectGrupaPrzedmiotowaBySchool(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear));
                //sqlString.Add("GetAbsenceList",KontrolaSQL.CountAbsence(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, SchoolDateRange));

                //IsqlCommand cmd = new SqlCommand();
                //foreach (var o in sqlString)
                //{
                //	var lst = cmd.FetchDataAsync(o.Value);
                //	await (Task) GetType().GetMethod(o.Key).Invoke(this,new object[] { lst });
                //}
                //cmd.CommitTransaction(); 
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }
        //ToDo: Sprawdzić działanie wszystkich metod, szczególnie ComputeAbsence
        async Task<IEnumerable<StudentAbsence>> FetchAbsenceList()
        {
            var sqlString = KontrolaSQL.CountAbsence(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, SchoolDateRange);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new StudentAbsence
                {
                    StudentID = Convert.ToInt32(R["IdUczen"]),
                    SubjectID = Convert.ToInt32(R["Przedmiot"]),
                    AbsenceType = R["Typ"].ToString(),
                    AbsenceCount = Convert.ToInt32(R["Abs"]),
                    AbsenceDate = Convert.ToDateTime(R["Data"])
                });
            }
        }

        async Task<IEnumerable<SchoolSubjectGroup>> FetchGroupList()
        {
            var sqlString = KontrolaSQL.SelectGrupaPrzedmiotowaBySchool(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new SchoolSubjectGroup
                {
                    GroupID = Convert.ToInt32(R["ID"]),
                    ClassID = Convert.ToInt32(R["IdKlasa"]),
                    SubjectID = Convert.ToInt32(R["Przedmiot"]),
                    StudentID = Convert.ToInt32(R["IdUczen"]),
                    StartDate = Convert.ToDateTime(R["StartDate"]),
                    EndDate = Convert.ToDateTime(R["EndDate"])
                });
            }

        }

        async Task<IEnumerable<SchoolLesson>> FetchLessonList()
        {
            var sqlString = KontrolaSQL.SelectLekcja(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear, SchoolDateRange);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new SchoolLesson
                {
                    LessonID = Convert.ToInt32(R["ID"]),
                    LessonDate = Convert.ToDateTime(R["Data"]),
                    Subject = new ClassSubject
                    {
                        ClassID = Convert.ToInt32(R["Klasa"]),
                        SubjectID = Convert.ToInt32(R["Przedmiot"]),
                        Group = (YesNo)Convert.ToUInt64(R["Grupa"]),
                        SubjectName = R["Nazwa"].ToString(),
                        SubjectPriority = Convert.ToByte(R["Priorytet"])
                    }
                });
            }
        }

        async Task<IEnumerable<ClassSubject>> FetchSubjectList()
        {
            var sqlString = KontrolaSQL.SelectPrzedmiot(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) => new ClassSubject
                {
                    ClassID = Convert.ToInt32(R["Klasa"]),
                    SubjectID = Convert.ToInt32(R["Przedmiot"]),
                    Group = (YesNo)Convert.ToUInt64(R["Grupa"]),
                    SubjectName = R["Nazwa"].ToString(),
                    SubjectPriority = Convert.ToByte(R["Priorytet"])

                });
            }
            //lstPrzedmiot.Clear();

            //foreach (var R in await lst)
            //{
            //	lstPrzedmiot.Add(new ClassSubject
            //	{
            //		ClassID = Convert.ToInt32(R["Klasa"]),
            //		SubjectID = Convert.ToInt32(R["Przedmiot"]),
            //		Group = (YesNo)Convert.ToUInt64(R["Grupa"]),
            //		SubjectName = R["Nazwa"].ToString(),
            //		SubjectPriority = Convert.ToByte(R["Priorytet"])
            //	});
            //}
        }

        async Task<IEnumerable<SchoolStudent>> FetchStudentList()
        {
            var sqlString = KontrolaSQL.SelectStudent(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear);
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.FetchRecordSetAsync(sqlString, (R) =>
                {
                    DateTime.TryParse(R["DataDeaktywacji"].ToString(), out var dd);
                    return new SchoolStudent
                    {
                        Student = new IdentUnit { ID = Convert.ToInt32(R["IdUczen"]), Name = R["Student"].ToString() },
                        StudentClass = new IdentUnit { ID = Convert.ToInt32(R["IdKlasa"]), Name = R["NazwaKlasy"].ToString() },
                        ActivationStatus = Convert.ToBoolean(R["StatusAktywacji"]),
                        ActivationDate = Convert.ToDateTime(R["DataAktywacji"]),
                        DeactivationDate = dd,
                        MasterRecord = Convert.ToBoolean(R["MasterRecord"])
                    };
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
                //tlvStudent.CanExpandGetter = delegate (object AB) { return ((AbsenceBranch)AB).Children.Count > 0; };
                tlvStudent.CanExpandGetter = (AB) => ((AbsenceBranch)AB).Children.Count > 0; 
                tlvStudent.ChildrenGetter = delegate (object AB) { return ((AbsenceBranch)AB).Children; };
                tlvStudent.BeginUpdate();
                tlvStudent.Roots = GetAbsenceTree();
                tlvStudent.EndUpdate();
                tlvStudent.ExpandAll();

                pnlProgress.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<AbsenceBranch> GetAbsenceTree()
        {
            List<AbsenceBranch> AbsenceTree = new List<AbsenceBranch>();

            pbrKlasa.Maximum = lstKlasa.Count;
            pbrKlasa.Value = 0;
            lblKlasa.Text = "";
            foreach (var K in lstKlasa)
            {
                //IdentUnit Klasa = new IdentUnit { ID = K.ID, Name = K.Name };
                var lstSubjectByClass = lstPrzedmiot.Where(x => x.ClassID == K.ID).OrderBy(x => x.SubjectPriority).ToList();
                var ClassNode = new AbsenceBranch();
                ClassNode.Level = 0;
                ClassNode.Children = GetClassAbsence(K, lstSubjectByClass);
                ComputeAbsence(ClassNode, K.Name);
                pbrKlasa.Value++;
                lblKlasa.Text = pbrKlasa.Value.ToString() + "/" + pbrKlasa.Maximum;
                Refresh();
                AbsenceTree.Add(ClassNode);
                //tlvStudent.Expand(ClassNode);
            }
            return AbsenceTree;
        }

        private List<AbsenceBranch> GetClassAbsence(IdentUnit Klasa, List<ClassSubject> lstPrzedmiot)
        {
            List<AbsenceBranch> ClassAbsence = new List<AbsenceBranch>();
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
            foreach (var S in lstFilteredStudent)
            {
                IdentUnit Student = new IdentUnit { ID = S.Student.ID, Name = S.Student.Name };
                var lstStudentByAllocation = lstStudent.Where(x => x.Student.ID == Student.ID).ToList();
                var StudentNode = new AbsenceBranch();
                StudentNode.Level = 1;
                StudentNode.Children = GetStudentAbsence(Klasa, Student, lstStudentByAllocation, lstPrzedmiot);
                ComputeAbsence(StudentNode, S.Student.Name);
                pbrStudent.Value++;
                lblStudent.Text = pbrStudent.Value.ToString() + "/" + pbrStudent.Maximum;
                Refresh();
                ClassAbsence.Add(StudentNode);
            }
            return ClassAbsence;
        }
        private List<AbsenceBranch> GetStudentAbsence(IdentUnit Klasa, IdentUnit Student, List<SchoolStudent> StudentAllocation, List<ClassSubject> lstPrzedmiot)
        {
            List<AbsenceBranch> StudentAbsence = new List<AbsenceBranch>();
            var lstAbsenceByStudent = lstAbsencja.Where(A => A.AbsenceDate <= CurrentDate).Where(x => x.StudentID == Student.ID).ToList();
            List<int> ClassID = new List<int>();
            StudentAllocation.Select(x => new { x.StudentClass.ID }).Distinct().ToList().ForEach(x => ClassID.Add(x.ID));
            var lstLessonByClass = lstLekcja.Where(x => ClassID.Contains(x.Subject.ClassID)).Where(L => L.LessonDate <= CurrentDate).ToList();
            foreach (var P in lstPrzedmiot)
            {
                var lstSubjectGroup = lstGrupa.Where(sbj => sbj.SubjectID == P.SubjectID).ToList();
                var lstLesson = lstLessonByClass.Where(x => x.Subject.SubjectID == P.SubjectID).ToList();
                var SubjectNode = GetStudentAbsenceBySubject(P, StudentAllocation, lstLesson, lstAbsenceByStudent, lstSubjectGroup);
                StudentAbsence.Add(SubjectNode);
            }
            return StudentAbsence;
        }

        private AbsenceBranch GetStudentAbsenceBySubject(ClassSubject przedmiot, List<SchoolStudent> StudentAllocation, List<SchoolLesson> LessonByClass, List<StudentAbsence> AbsenceByStudent, List<SchoolSubjectGroup> lstSubjectGroup)
        {
            AbsenceBranch StudentAbsenceBySubject = new AbsenceBranch();

            var lstAbsenceByStudent = AbsenceByStudent.Where(x => x.SubjectID == przedmiot.SubjectID).ToList();
            var Absencja = ComputeAbsence(StudentAllocation, lstAbsenceByStudent, LessonByClass, przedmiot, lstSubjectGroup);
            StudentAbsenceBySubject.Level = 2;
            StudentAbsenceBySubject.Label = przedmiot.SubjectName;
            StudentAbsenceBySubject.LessonCount = Absencja.LessonCount;
            StudentAbsenceBySubject.JustifiedAbsenceCount = Absencja.JustifiedCount;
            StudentAbsenceBySubject.UnjustifiedAbsenceCount = Absencja.UnjustifiedCount;
            return StudentAbsenceBySubject;
        }

        private void ComputeAbsence(AbsenceBranch Node, string Label)
        {
            Node.Label = Label;
            Node.LessonCount = Node.Children.Sum(x => x.LessonCount);
            Node.JustifiedAbsenceCount = Node.Children.Sum(x => x.JustifiedAbsenceCount);
            Node.UnjustifiedAbsenceCount = Node.Children.Sum(x => x.UnjustifiedAbsenceCount);
        }

        private Absence ComputeAbsence(List<SchoolStudent> lstStudent, List<StudentAbsence> lstAbsencja, List<SchoolLesson> lstLekcja, ClassSubject przedmiot, List<SchoolSubjectGroup> lstGrupaWgPrzedmiotu)
        {
            try
            {
                Absence Absencja = new Absence();
                foreach (var S in lstStudent)
                {
                    if (przedmiot.Group == YesNo.Nie)
                    {
                        CountAbsence(ref Absencja, S.ActivationDate, S.DeactivationDate, lstLekcja, lstAbsencja);
                    }
                    else
                    {
                        foreach (var G in lstGrupaWgPrzedmiotu.Where(x => x.StudentID == S.Student.ID && x.ClassID == S.StudentClass.ID))
                        {
                            CountAbsence(ref Absencja, G.StartDate, G.EndDate, lstLekcja, lstAbsencja);
                        }
                    }
                }
                return Absencja;
            }
            catch (Exception)
            {
                throw;
            }
        }
        void CountAbsence(ref Absence absencja, DateTime StartDate, DateTime EndDate, List<SchoolLesson> lstLekcja, List<StudentAbsence> lstAbsencja)
        {
            absencja.LessonCount += lstLekcja.
                Where(L => L.LessonDate >= StartDate && L.LessonDate <= EndDate).
                Count();

            absencja.JustifiedCount += lstAbsencja.
                Where(A => A.AbsenceType == "u").
                Where(A => A.AbsenceDate >= StartDate && A.AbsenceDate <= EndDate).
                Sum(A => A.AbsenceCount);

            absencja.UnjustifiedCount += lstAbsencja.
                Where(A => A.AbsenceType == "n").
                Where(A => A.AbsenceDate >= StartDate && A.AbsenceDate <= EndDate).
                Sum(A => A.AbsenceCount);
        }
        //   private Absence ComputeAbsence(List<SchoolStudent> lstStudent, List<StudentAbsence> lstAbsencja, List<SchoolLesson> lstLekcja, ClassSubject przedmiot, List<SchoolSubjectGroup> lstGrupa)
        //   {
        //       try
        //       {
        //           Absence Absencja = new Absence();
        //           foreach (var S in lstStudent) 
        //           {

        //               if (przedmiot.Group == YesNo.Nie || lstGrupa.Any(G => G.ClassID == S.StudentClass.ID && G.StudentID == S.Student.ID))
        //               {
        //                   Absencja.LessonCount += lstLekcja.Where(L => L.LessonDate >= S.ActivationDate && (L.LessonDate <= S.DeactivationDate || S.DeactivationDate == DateTime.MinValue)).Where(L => L.Subject.ClassID == S.StudentClass.ID).Count();

        //                   Absencja.JustifiedCount += lstAbsencja.Where(A => A.AbsenceType == "u").Where(A => A.AbsenceDate >= S.ActivationDate && (A.AbsenceDate <= S.DeactivationDate || S.DeactivationDate == DateTime.MinValue)).Sum(A => A.AbsenceCount);

        //                   Absencja.UnjustifiedCount += lstAbsencja.Where(A => A.AbsenceType == "n").Where(A => A.AbsenceDate >= S.ActivationDate && (A.AbsenceDate <= S.DeactivationDate || S.DeactivationDate == DateTime.MinValue)).Sum(A => A.AbsenceCount);
        //               }
        //           }
        //           return Absencja;
        //           }
        //       catch (Exception)
        //       {
        //           throw;
        //       }
        //   }

        private void nudAbsencja_ValueChanged(object sender, EventArgs e)
        {
            tlvStudent.ModelFilter = new ModelFilter(delegate (object x)
            {
                var Filter = ((AbsenceBranch)x).StudentAbsencePercent >= (float)((NumericUpDown)sender).Value;
                return Filter;
            });

            lblRecord.Text = "0 z " + tlvStudent.GetItemCount();

            UserSession.User.Settings.AbsenceLevel = (float)((NumericUpDown)sender).Value;
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            CurrentDate = dtpData.Value;
        }

        private void dtpData_CloseUp(object sender, EventArgs e)
        {
            lstKlasa.Clear();
            switch (cbSeek.SelectedIndex)
            {
                case 0:
                    lstStudent.Where(x => x.StudentClass.Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase)).Select(x => new { x.StudentClass.ID, x.StudentClass.Name }).Distinct().OrderBy(x => x.Name).ToList().ForEach(x => lstKlasa.Add(new IdentUnit { ID = x.ID, Name = x.Name }));
                    break;
                case 1:
                    lstStudent.Where(x => x.Student.Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase)).Select(x => new { x.StudentClass.ID, x.StudentClass.Name }).Distinct().OrderBy(x => x.Name).ToList().ForEach(x => lstKlasa.Add(new IdentUnit { ID = x.ID, Name = x.Name }));
                    break;
            }
            GetData();
            nudAbsencja_ValueChanged(nudAbsencja, null);
        }

        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek.Focus();
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
        private void txtSeek_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpData_CloseUp(dtpData, null);
            }
        }
        #region ---------------------------------- Printing ------------------------------------------
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            dlgPrintPreview dlgPrint = new dlgPrintPreview();
            //dlgPrint.rbHorizontal.Checked = true;
            dlgPrint.PreviewModeChanged += PreviewModeChanged;
            NewRow += dlgPrint.NewRow;
            dlgPrint.Doc.BeginPrint += PrnDoc_BeginPrint;
            dlgPrint.Doc.PrintPage += tlvAnaliza_PrintPage;
            dlgPrint.Doc.EndPrint += tlvAnaliza_EndPrint;
            ReportHeader = new List<string> { "Absencja uczniów na zajęciach lekcyjnych" };
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
                Kolumna.Add(new TableCell { Name = Col.AspectName, Label = Col.Text, Size = Col.Width });
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
            var ListItems = tlvStudent.FilteredObjects.Cast<AbsenceBranch>();
            while (y + LineHeight * 2 < PrintHeight && Offset[0] < ListItems.Count())
            {
                AbsenceBranch ListItem = ListItems.ToArray()[Offset[0]];
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
        private void PrintModelObjectData(AbsenceBranch Node, float x, ref float y, List<TableCell> Kolumna, Font PrintFont, float LineHeight, int TabIndent = 0, bool FillBackground = false)
        {
            List<string> AspectToPrint = new List<string>();

            AspectToPrint.Add(Node.Label);
            AspectToPrint.Add(Node.StudentAbsencePercent.ToString());
            AspectToPrint.Add(Node.LessonCount.ToString());
            AspectToPrint.Add(Node.StudentAbsenceCount.ToString());
            AspectToPrint.Add(Node.JustifiedAbsenceCount.ToString());
            AspectToPrint.Add(Node.UnjustifiedAbsenceCount.ToString());

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


    }
    public class IdentUnit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static IdentUnit Empty { get { return new IdentUnit { ID = -1, Name = "" }; } }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Absence
    {
        /// <summary>Liczba lekcji, które się odbyły w klasie, do której uczeń jest przypisany</summary>
        public int LessonCount { get; set; }
        /// <summary>
        /// Liczba usprawiedliwionych nieobecności ucznia
        /// </summary>
        public int JustifiedCount { get; set; }
        /// <summary>
        /// Liczba nieusprawiedliwionych nieobecności ucznia
        /// </summary>
        public int UnjustifiedCount { get; set; }
    }

}
