using Autofac;
using Belfer.Administrator.Model;
using Belfer.Dziennik;
using Belfer.Ustawienia;
using BrightIdeasSoftware;
using DataBaseService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belfer
{
    public partial class frmStudent : Form
    {
        public event EventHandler TheEnd;
        IEnumerable<Simc.CityBySimc> SimcList;
        IEnumerable<StudentAllocation> StudentList;
        IEnumerable<int> RepeaterList;
        IEnumerable<Tutor> TutorList;

        public frmStudent()
        {
            InitializeComponent();
            AppUser.UserSettings.RaiseConfigChanged += ApplyNewConfig;
            ListViewConfig(olvStudent);
            LoadFilterCriteria();
            GenerateColumns(olvStudent, SpecifyCols());
            LoadSimc();
            ApplyNewConfig(this, null);
        }
        void LoadSimc()
        {
            var S = new Simc(CitySQL.SelectSomePlaceFromSimc());
            SimcList = S.CityListBySimc;
        }
        private void ApplyNewConfig(object sender, EventArgs e)
        {
            try
            {
                lblRecord.Text = "";
                ClearDetails();
                ClearSignature();
                cmdPrint.Enabled = true;
                EnableButton(false);
                FetchData();
                GetData(olvStudent);
                cmdAddNew.Enabled = HasWritePrivilage();
                cmdImport.Enabled = SeekHelper.HasOperatorPrivilage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pnlRecord_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlRecord.Left - 10, pnlRecord.Height - 1, pnlRecord.Width, pnlRecord.Height - 1);
        }
        private void pnlSignature_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlSignature.Left - 10, 1, pnlSignature.Width, 1);
        }
        private void LoadFilterCriteria()
        {
            cbSeek.DataSource = new string[] { "Nazwisko i imię", "Klasa", "Nr ewidencyjny", "Pesel", "Data urodzenia", "Miejsce urodzenia", "Miejsce zamieszkania" };
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
            Cols.Add(new OLVColumn { Name = "FullName", Text = "Nazwisko i imiona", WordWrap = true, AspectName = "Student.FullName", MinimumWidth = 100, Width = 150, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imiona ucznia", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Name = "ClassName", Text = "Klasa", AspectName = "StudentClass.ClassName", MinimumWidth = 30, Width = 100, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Oddział klasowy", UseInitialLetterForGroup = false, IsEditable = false, GroupKeyToTitleConverter = new GroupKeyToTitleConverterDelegate(x => string.Concat("Klasa ", x.ToString())) });
            Cols.Add(new OLVColumn { Text = "Nr kol.", WordWrap = true, AspectName = "StudentNo", MinimumWidth = 30, Width = 80, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nr ucznia w dzienniku lekcyjnym", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, IsEditable = false, Groupable = false, AspectToStringConverter = new AspectToStringConverterDelegate(x => (int)x == 0 ? "" : x.ToString()) });
            Cols.Add(new OLVColumn { Text = "Nr ewid.", WordWrap = true, AspectName = "Student.RegistryNo", MinimumWidth = 50, Width = 80, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nr ewidencyjny w arkuszu ocen", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = true, Groupable = false });
            Cols.Add(new OLVColumn { Text = "Data\nurodzenia", WordWrap = true, AspectName = "Student.BirthDate", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data urodzenia", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = (cellValue) => { if (((DateTime)cellValue).Year == 1900) return string.Empty; return ((DateTime)cellValue).ToShortDateString(); }, GroupKeyToTitleConverter = new GroupKeyToTitleConverterDelegate(x => ((int)x) == 1900 ? string.Empty : $"Rocznik {x.ToString()}"), GroupKeyGetter = delegate (object R) { var SA = R as StudentAllocation; return SA.Student.BirthDate.Year; } });
            Cols.Add(new OLVColumn { Text = "Miejsce\nurodzenia", WordWrap = true, AspectName = "Student.BirthPlace.Name", MinimumWidth = 50, Width = 150, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Miejsce urodzenia", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = false });
            Cols.Add(new OLVColumn { Text = "Pesel", WordWrap = true, AspectName = "Student.Pesel", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nr pesel", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = true, Groupable = false });
            Cols.Add(new OLVColumn { Name = "Sex", Text = "Płeć", WordWrap = true, AspectName = "Student.Sex", MinimumWidth = 50, Width = 50, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Płeć", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, GroupKeyToTitleConverter = new GroupKeyToTitleConverterDelegate(x => x.ToString() == "K" ? "Kobieta" : "Mężczyzna") });
            Cols.Add(new OLVColumn { Text = "ID", AspectName = "Student.ID", MinimumWidth = 0, Width = 0, MaximumWidth = 60, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Identyfikator pozycji", Groupable = false, IsEditable = false });

            return Cols;
        }



        private void GetData(ObjectListView olv)
        {
            try
            {
                olv.BeginUpdate();
                olv.SetObjects(StudentList);
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
                lblRecord.Text = "0 z " + olv.Items.Count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FetchData()
        {
            try
            {
                StudentList = GetStudentListAsync().Result;
                RepeaterList = GetRepeaterListAsync().Result;
                TutorList = GetTutorListAsync().Result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private async Task<IEnumerable<StudentAllocation>> GetStudentListAsync()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(StudentSQL.SelectStudent(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear), StudentAllocationModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private StudentAllocation StudentAllocationModel(IDataReader R)
        {
            DateTime.TryParse(R["DataUr"].ToString(), out DateTime birthDate);
            DateTime.TryParse(R["DataAktywacji"].ToString(), out DateTime startDate);
            DateTime.TryParse(R["DataDeaktywacji"].ToString(), out DateTime endDate);
            return new StudentAllocation
            {
                ID = Convert.ToInt32(R["ID"]),
                Student = new Student
                {
                    ID = Convert.ToInt32(R["IdUczen"]),
                    FirstName = R["Imie"].ToString(),
                    SecondName = R["Imie2"].ToString(),
                    LastName = R["Nazwisko"].ToString(),
                    ApartmentNo = R["NrMieszkania"].ToString(),
                    BirthDate = birthDate,
                    BirthPlace = GetCity(R["IdMiejsceUr"].ToString(), R["KodUr"].ToString(), R["NazwaUr"].ToString(), R["KodPocztowyUr"].ToString(), R["PocztaUr"].ToString(), R["PolskaUr"].ToString()),
                    ResidencePlace = GetCity(R["IdMiejsceZam"].ToString(), R["KodZam"].ToString(), R["NazwaZam"].ToString(), R["KodPocztowyZam"].ToString(), R["PocztaZam"].ToString(), R["PolskaZam"].ToString()),
                    FatherFirstName = R["ImieOjca"].ToString(),
                    FatherLastName = R["NazwiskoOjca"].ToString(),
                    MobilePhoneNo = R["TelKom1"].ToString(),
                    MobilePhoneNo2 = R["TelKom2"].ToString(),
                    MotherFirstName = R["ImieMatki"].ToString(),
                    MotherLastName = R["NazwiskoMatki"].ToString(),
                    Pesel = R["Pesel"].ToString(),
                    PhoneNo = R["Tel"].ToString(),
                    PropertyNo = R["NrDomu"].ToString(),
                    RegistryNo = R["NrArkusza"].ToString(),
                    Sex = (User.UserSex)Convert.ToInt32(R["Man"]),
                    StreetName = R["Ulica"].ToString(),
                    Creator = new Signature
                    {
                        Owner = R["Owner"].ToString(),
                        User = R["User"].ToString(),
                        IP = R["ComputerIP"].ToString(),
                        Version = Convert.ToDateTime(R["Version"])
                    }
                },
                StudentClass = new SchoolClass
                {
                    ID = Convert.ToInt32(R["IdKlasa"]),
                    ClassCode = R["KodKlasy"].ToString(),
                    ClassName = R["NazwaKlasy"].ToString()
                },
                IsPromoted = (YesNo)Convert.ToInt64(R["Promocja"]),
                MasterRecord = (YesNo)Convert.ToInt64(R["MasterRecord"]),
                Status = (User.UserStatus)Convert.ToInt64(R["StatusAktywacji"]),
                StudentNo = Convert.ToInt32(R["NrwDzienniku"]),
                StartDate = startDate,
                EndDate = endDate
            };
        }

        private City GetCity(string ID, string Code, string Name, string PostalCode, string PostOffice, string Poland)
        {
            var C = new City();
            int id;
            int.TryParse(ID, out id);
            C.ID = id;
            C.Code = Code;
            C.Name = Name;
            C.PostalCode = PostalCode;
            C.PostOffice = PostOffice;
            bool Pl;
            bool.TryParse(Poland.Equals("1").ToString(), out Pl);
            C.Poland = Pl;
            if (C.Poland)
            {
                var P = SimcList.Where(x => x.Code == Code).FirstOrDefault();
                C.CommunityName = P.CommunityName;
                C.CountyName = P.CountyName;
                C.ProvinceName = P.ProvinceName;
            }
            return C;
        }

        private async Task<IEnumerable<int>> GetRepeaterListAsync()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(StudentSQL.SelectRepeater(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear), (R) => R.GetInt32(0));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<IEnumerable<Tutor>> GetTutorListAsync()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(TutorSQL.SelectTutor(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear), TutorModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Tutor TutorModel(IDataReader T)
        {
            return new Tutor
            {
                ID = Convert.ToInt32(T["ID"]),
                SchoolClass = new SchoolClass
                {
                    ID = Convert.ToInt32(T["IdKlasa"]),
                    ClassCode = T["KodKlasy"].ToString(),
                    ClassName = T["NazwaKlasy"].ToString()
                },
                Teacher = new Teacher
                {
                    ID = Convert.ToInt32(T["IdNauczyciel"]),
                    FirstName = T["Imie"].ToString(),
                    LastName = T["Nazwisko"].ToString(),
                    Status = (User.UserStatus)Convert.ToInt64(T["NauczycielStatus"]),
                    Role = (User.UserRole)Convert.ToInt64(T["Role"]),
                    Login = T["Login"].ToString()
                },
                ValidityInterval = new DateRange(Convert.ToDateTime(T["StartDate"]), Convert.ToDateTime(T["EndDate"])),
                Creator = new Signature
                {
                    Owner = T["Owner"].ToString(),
                    User = T["User"].ToString(),
                    IP = T["ComputerIP"].ToString(),
                    Version = Convert.ToDateTime(T["Version"])
                },
                PrivilegeType = (PrivilegeAspect)Convert.ToInt64(T["Typ"]),
                PrivilegeStatus = (User.UserStatus)Convert.ToInt64(T["Status"]),
            };
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void frmStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            TheEnd?.Invoke(sender, e);
            AppUser.UserSettings.RaiseConfigChanged -= ApplyNewConfig;
        }

        private void olvObsada_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                lblRecord.Text = (e.ItemIndex + 1) + " z " + e.Item.ListView.Items.Count;
                var listItem = (StudentAllocation)((OLVListItem)e.Item).RowObject;
                GetDetails(listItem);
                GetSignature(listItem);
                if (HasWritePrivilage(listItem.StudentClass.ID)) EnableButton(true);
            }
            else
            {
                lblRecord.Text = "0 z " + e.Item.ListView.Items.Count;
                ClearDetails();
                ClearSignature();
                EnableButton(false);
            }
        }

        private void GetDetails(StudentAllocation R)
        {
            lblAdres.Text = R.Student.FullAddress;
            lblDataAktywacji.Text = R.StartDate.ToShortDateString();
            lblDataDeaktywacji.Text = R.EndDate.ToShortDateString();
            lblMatka.Text = R.Student.MotherFirstName;
            lblOjciec.Text = R.Student.FatherFirstName;
            lblMatka.Text = R.Student.MotherFullName;
            lblOjciec.Text = R.Student.FatherFullName;
            lblTelefon.Text = R.Student.PhoneNo;
            lblTelKom1.Text = R.Student.MobilePhoneNo;
            lblTelKom2.Text = R.Student.MobilePhoneNo2;
            lblStatus.Text = R.Status.ToString();
        }

        private void GetSignature(StudentAllocation UserItem)
        {
            lblData.Text = UserItem.Student.Creator.Version.ToString();
            lblIP.Text = UserItem.Student.Creator.IP;
            lblUser.Text = UserItem.Student.Creator.ToString();
        }

        private void ClearSignature()
        {
            foreach (Label lbl in pnlSignature.Controls)
            {
                if (lbl.Name.StartsWith("lbl")) lbl.Text = "";
            }
        }
        private void ClearDetails()
        {
            foreach (Label lbl in tblDetails.Controls)
            {
                if (lbl.Name.StartsWith("lbl")) lbl.Text = "";
            }
        }
        private void EnableButton(bool v)
        {
            cmdDelete.Enabled = v;
            cmdEdit.Enabled = v;
            cmdStrikeOut.Enabled = v;
            cmdNumber.Enabled = v;
        }

        private void olvStudent_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Text = $"Identyfikator ucznia: {(e.Model as StudentAllocation).Student.ID}\nIdentyfikator przydziału do klasy: {(e.Model as StudentAllocation).ID}";
                    break;
                case 5:
                    e.Text = (e.Model as StudentAllocation).Student.BirthPlace.ToString();
                    break;
                default:
                    break;
            }
        }

        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            AddNew();
        }
        void AddNew()
        {
            if (!HasWritePrivilage()) return;
            using (var dlg = new dlgStudent(true))
            {
                dlg.cbMiejsceUr.DataSource = City.ComboItems.GetCities();
                dlg.cbMiejsceZam.DataSource = City.ComboItems.GetCities();

                dlg.cbKlasa.SelectedIndexChanged += dlg.cbKlasa_SelectedIndexChanged;
                dlg.NewRecordAdded += NewRecord;
                dlg.ShowDialog();
                dlg.NewRecordAdded -= NewRecord;
                dlg.cbKlasa.SelectedIndexChanged -= dlg.cbKlasa_SelectedIndexChanged;
            }
        }
        private void NewRecord(long RecordID)
        {
            RefreshData();
            SetListViewItem(RecordID);
        }

        private void SetListViewItem(long recordID)
        {
            var Item = ((HashSet<StudentAllocation>)olvStudent.Objects).Where(x => x.Student.ID == recordID).FirstOrDefault();
            if (Item != null)
            {
                olvStudent.SelectObject(Item);
                olvStudent.SelectedItem.EnsureVisible();
            }
        }
        private void RefreshData()
        {
            ClearDetails();
            ClearSignature();
            FetchData();
            GetData(olvStudent);
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            EditStudent();
        }
        void EditStudent()
        {
            var S = olvStudent.SelectedObject as StudentAllocation;
            if (S == null) return;
            if (!HasWritePrivilage(S.StudentClass.ID)) return;
            using (var dlg = new dlgStudent(false))
            {
                FillStudentData(dlg, S);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var Student = UpdateStudentAsync(dlg, S.Student.ID);
                        var Allocation = UpdateStudentAllocationAsync(dlg, S.ID);
                        if (Student.Result > 0 && Allocation.Result > 0)
                        {
                            NewRecord(S.Student.ID);
                            return;
                        }
                        throw new Exception("Aktualizacja danych nie powiodła się!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        void FillStudentData(dlgStudent dlg, StudentAllocation S)
        {
            dlg.Text = "Edytuj dane ucznia";
            dlg.cbKlasa.Enabled = false;
            dlg.cbKlasa.Items.Add(S.StudentClass);
            dlg.cbKlasa.SelectedIndex = 0;
            dlg.cbMiejsceUr.DataSource = City.ComboItems.GetCities();
            dlg.cbMiejsceZam.DataSource = City.ComboItems.GetCities();
            dlg.cbMiejsceUr.SelectedIndex = City.ComboItems.GetCityIndex(S.Student.BirthPlace.ID, dlg.cbMiejsceUr.Items);
            dlg.cbMiejsceZam.SelectedIndex = City.ComboItems.GetCityIndex(S.Student.ResidencePlace.ID, dlg.cbMiejsceZam.Items);
            dlg.txtImie.Text = S.Student.FirstName;
            dlg.txtImie2.Text = S.Student.SecondName;
            dlg.txtImieMatki.Text = S.Student.MotherFirstName;
            dlg.txtImieOjca.Text = S.Student.FatherFirstName;
            dlg.txtNazwisko.Text = S.Student.LastName;
            dlg.txtNazwiskoMatki.Text = S.Student.MotherLastName;
            dlg.txtNazwiskoOjca.Text = S.Student.FatherLastName;
            dlg.txtNrArkusza.Text = S.Student.RegistryNo;
            dlg.txtUlica.Text = S.Student.StreetName;
            dlg.txtNrDomu.Text = S.Student.PropertyNo;
            dlg.txtNrMieszkania.Text = S.Student.ApartmentNo;
            dlg.txtPesel.Text = S.Student.Pesel;
            dlg.txtTelefon.Text = S.Student.PhoneNo;
            dlg.txtTelKom1.Text = S.Student.MobilePhoneNo;
            dlg.txtTelKom2.Text = S.Student.MobilePhoneNo2;
            dlg.txtUlica.Text = S.Student.SecondName;
            dlg.dtDataAktywacji.Value = S.StartDate;
            dlg.dtDataDeaktywacji.Value = S.EndDate;
            dlg.nudNrwDzienniku.Value = S.StudentNo;
            dlg.chkSex.Checked = S.Student.Sex > 0;
            dlg.dtDataUr.Value = S.Student.BirthDate;
        }

        async Task<int> UpdateStudentAsync(dlgStudent dlg, int idStudent)
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(StudentSQL.UpdateStudent(), CreateStudentParamWithValue(idStudent, dlg));
            }
        }
         IDictionary<string,object> CreateStudentParamWithValue(int idStudent, dlgStudent dlg)
        {
            var sqlParamWithValue = new Dictionary<string, object>();

            sqlParamWithValue.Add("@ID", idStudent);
            sqlParamWithValue.Add("@Nazwisko", dlg.txtNazwisko.Text.Trim());
            sqlParamWithValue.Add("@Imie", dlg.txtImie.Text.Trim());
            sqlParamWithValue.Add("@Imie2", dlg.txtImie2.Text.Trim());
            string Nr = null;
            if (dlg.txtNrArkusza.Text.Trim().Length > 0) Nr = dlg.txtNrArkusza.Text.Trim();
            sqlParamWithValue.Add("@NrArkusza", Nr);
            sqlParamWithValue.Add("@ImieOjca", dlg.txtImieOjca.Text.Trim());
            sqlParamWithValue.Add("@NazwiskoOjca", dlg.txtNazwiskoOjca.Text.Trim());
            sqlParamWithValue.Add("@ImieMatki", dlg.txtImieMatki.Text.Trim());
            sqlParamWithValue.Add("@NazwiskoMatki", dlg.txtNazwiskoMatki.Text.Trim());
            sqlParamWithValue.Add("@DataUr", dlg.dtDataUr.Value);
            sqlParamWithValue.Add("@Pesel", dlg.txtPesel.Text.Trim());
            int? CityID = null;
            if (((City)dlg.cbMiejsceUr.SelectedItem).ID != 0) CityID = ((City)dlg.cbMiejsceUr.SelectedItem).ID;
            sqlParamWithValue.Add("@IdMiejsceUr", CityID);
            CityID = null;
            if (((City)dlg.cbMiejsceZam.SelectedItem).ID != 0) CityID = ((City)dlg.cbMiejsceZam.SelectedItem).ID;
            sqlParamWithValue.Add("@IdMiejsceZam", CityID);
            sqlParamWithValue.Add("@Ulica", dlg.txtUlica.Text.Trim());
            sqlParamWithValue.Add("@NrDomu", dlg.txtNrDomu.Text.Trim());
            sqlParamWithValue.Add("@NrMieszkania", dlg.txtNrMieszkania.Text.Trim());
            sqlParamWithValue.Add("@Tel", dlg.txtTelefon.Text.Trim());
            sqlParamWithValue.Add("@TelKom1", dlg.txtTelKom1.Text.Trim());
            sqlParamWithValue.Add("@TelKom2", dlg.txtTelKom2.Text.Trim());
            sqlParamWithValue.Add("@Man", dlg.chkSex.Checked);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP",AppSession.HostIP);

            return sqlParamWithValue;
        }
        
        async Task<int> UpdateStudentAllocationAsync(dlgStudent dlg, int idAllocation)
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(StudentSQL.UpdateStudentAllocation(), CreateAllocationParamWithValue(dlg,idAllocation));
            }
        }

        IDictionary<string,object> CreateAllocationParamWithValue(dlgStudent dlg, int idAllocation)
        {
            var sqlParamWithValue = new Dictionary<string,object>();

            byte? Nr = null;
            if (dlg.nudNrwDzienniku.Value > 0) Nr = (byte)dlg.nudNrwDzienniku.Value;

            sqlParamWithValue.Add("@ID", idAllocation);
            sqlParamWithValue.Add("@NrwDzienniku", Nr);
            sqlParamWithValue.Add("@DataAktywacji", dlg.dtDataAktywacji.Value);
            sqlParamWithValue.Add("@DataDeaktywacji", dlg.dtDataDeaktywacji.Value);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);

            return sqlParamWithValue;
        }

        private void olvStudent_DoubleClick(object sender, EventArgs e) => EditStudent();

        void DeleteStudent()
        {
            if (!HasWritePrivilage()) return;
            if (MessageBox.Show("Czy na pewno chcesz usunąć wskazanego ucznia?\nPotwierdzenie tej operacji spowoduje usunięcie ucznia z bazy danych oraz wszystkich danych z nim powiązanych (przydziały ucznia do oddziałów klasowych we wszystkich okresach, jego nieobecności na zajęciach oraz wszystkie oceny przedmiotowe z całego okresu kształcenia)!", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var recordCount = 0;
                    var sqlParamWithValue = new HashSet<Tuple<string, object>>();
                    foreach (StudentAllocation S in olvStudent.SelectedObjects)
                    {
                        if (!HasWritePrivilage(S.StudentClass.ID)) continue;
                        sqlParamWithValue.Add(new Tuple<string, object>("@ID", S.Student.ID));
                    }
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        recordCount = dbs.RemoveManyRecordsAsync(StudentSQL.DeleteStudent(), sqlParamWithValue).Result;
                    }
                    MessageBox.Show($"{recordCount} rekordów zostało usuniętych.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool HasWritePrivilage()
        {
            if (SeekHelper.HasOperatorPrivilage()) return true;
            return TutorList.Any(x => x.Teacher.Login == UserSession.User.Login);
        }
        private bool HasWritePrivilage(int classID)
        {
            if (SeekHelper.HasOperatorPrivilage()) return true;
            return TutorList.Where(k => k.SchoolClass.ID == classID).Any(x => x.Teacher.Login == UserSession.User.Login);
        }


        private void cmdDelete_Click(object sender, EventArgs e) => DeleteStudent();

        private void olvStudent_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    DeleteStudent();
                    break;
                case Keys.Insert:
                    AddNew();
                    break;
                case Keys.Enter:
                    EditStudent();
                    break;
                default:
                    break;
            }
        }

        private void olvStudent_AboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            foreach (var G in e.Groups)
            {
                G.Header = $"{G.Header} [{ G.Items.Count}]";

                switch (e.Parameters.GroupByColumn.Name)
                {
                    case "ClassName":
                        G.Subtitle = $"Wychowawca klasy: {GetTutor(G.Key.ToString()).ToUpper()}";
                        break;
                    default:

                        break;
                }
            }
        }

        private string GetTutor(string Klasa)
        {
            var tutor = from x in TutorList
                        where x.SchoolClass.ClassCode == Klasa
                        where x.PrivilegeStatus == User.UserStatus.Aktywny
                        where AppSession.CurrentDateAndTime.Date >= x.ValidityInterval.StartDate.Date
                        where AppSession.CurrentDateAndTime.Date <= x.ValidityInterval.EndDate.Date
                        orderby x.PrivilegeType descending
                        select x.Teacher;
            if (tutor.Count() == 0) return string.Empty;
            return tutor.First().Name;
        }

        private void txtSeek_TextChanged(object sender, EventArgs e)
        {
            switch (cbSeek.SelectedIndex)
            {
                case 0://Nazwisko i imię
                    olvStudent.ModelFilter = new ModelFilter(x => ((StudentAllocation)x).Student.FullName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 1://Klasa
                    olvStudent.ModelFilter = new ModelFilter(x => ((StudentAllocation)x).StudentClass.ClassName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 2: //Nr ewidencyjny
                    olvStudent.ModelFilter = new ModelFilter(x => ((StudentAllocation)x).Student.RegistryNo.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 3: //Nr Pesel
                    olvStudent.ModelFilter = new ModelFilter(x => ((StudentAllocation)x).Student.Pesel.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 4: //Data urodzenia
                    olvStudent.ModelFilter = new ModelFilter(x => ((StudentAllocation)x).Student.BirthDate.ToShortDateString().StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 5: //Miejsce urodzenia
                    olvStudent.ModelFilter = new ModelFilter(x => ((StudentAllocation)x).Student.BirthPlace.Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 6: //Miejsce zamieszkania
                    olvStudent.ModelFilter = new ModelFilter(x => ((StudentAllocation)x).Student.ResidencePlace.Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
            }
            lblRecord.Text = "0 z " + olvStudent.GetItemCount();
        }

        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Select();
        }

        private void olvStudent_FormatRow(object sender, FormatRowEventArgs e)
        {
            if ((e.Model as StudentAllocation).Status == 0)
            {
                e.Item.ForeColor = Color.DarkGray;
                e.Item.Font = new Font(e.Item.Font, FontStyle.Strikeout);
            }
            else if (RepeaterList.Contains((e.Model as StudentAllocation).Student.ID))
            {
                e.Item.ForeColor = Color.Red;
            }
        }

        private void CmdImport_Click(object sender, EventArgs e)
        {

        }
    }

    

}

