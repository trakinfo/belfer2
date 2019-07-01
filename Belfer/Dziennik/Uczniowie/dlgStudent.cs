using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Belfer.Dziennik;
using Belfer.Helpers;
using Belfer.Ustawienia;
using Belfer.Ustawienia.SQL;
using DataBaseService;

namespace Belfer
{
    public partial class dlgStudent : Form
    {
        bool IsNewMode;
        public event NewRecord NewRecordAdded;
        public dlgStudent(bool NewMode)
        {
            InitializeComponent();
            IsNewMode = NewMode;
            SetDate();
            if (IsNewMode)
            {
                LoadSchoolClass();
                dtDataUr.Value = dtDataUr.MinDate;
            }
        }
        void SetDate()
        {
            var SchoolYearDateRange = new DateRange();
            dtDataAktywacji.MinDate = SchoolYearDateRange.StartDate;
            dtDataAktywacji.MaxDate = SchoolYearDateRange.EndDate;
            dtDataDeaktywacji.MinDate = SchoolYearDateRange.StartDate;
            dtDataDeaktywacji.MaxDate = SchoolYearDateRange.EndDate;

            dtDataAktywacji.Value = SchoolYearDateRange.StartDate;
            dtDataDeaktywacji.Value = SchoolYearDateRange.EndDate;

            dtDataUr.MinDate = new DateTime(1900, 1, 1);
        }
        void LoadSchoolClass()
        {
            cbKlasa.DataSource = GetClassList().ToList();
            cbKlasa.Enabled = cbKlasa.Items.Count > 0;
            cbKlasa.SelectedIndex = -1;
        }
        public static IEnumerable<SchoolClass> GetClassList()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return dbs.FetchRecordSetAsync(SchoolClassSQL.SelectSchoolClassCombo(UserSession.User.Settings.SchoolID.ToString(), UserSession.User.Settings.SchoolYear), SchoolClassModel).Result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        static SchoolClass SchoolClassModel(IDataReader R)
        {
            return new SchoolClass
            {
                ID = Convert.ToInt32(R["ID"]),
                ClassCode = R["KodKlasy"].ToString(),
                ClassName = R["NazwaKlasy"].ToString()
            };
        }

        public void cbKlasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var ClassId = ((SchoolClass)(((ComboBox)sender).SelectedItem)).ID;
            txtNazwisko_TextChanged(sender, e);
        }

        private void txtNazwisko_TextChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = cbKlasa.SelectedItem != null && txtNazwisko.Text.Length > 0;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (IsNewMode)
            {
                var StudentId = AddStudent().Result;
                if (StudentId > 0)
                {
                    if (AddStudentAllocation(StudentId).Result > 0)
                    {
                        NewRecordAdded?.Invoke(StudentId);
                        cmdOK.Enabled = false;
                        ClearData();
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas dodawania przydziału ucznia.\nOperacja została anulowana.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawania ucznia.\nOperacja została anulowana.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ClearData()
        {
            foreach (var ctrl in Controls) if (ctrl is TextBox) (ctrl as TextBox).Text = null;
        }


        private async Task<long> AddStudentAllocation(long studentId)
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.AddRecordAsync(StudentSQL.InsertStudentAllocation(), CreateInsertParams(studentId));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        IDictionary<string,object> CreateInsertParams(long studentId)
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            int? Nr = null;
            if (nudNrwDzienniku.Value > 0) Nr = (int)nudNrwDzienniku.Value;
            sqlParamWithValue.Add("@IdUczen", studentId);
            sqlParamWithValue.Add("@IdKlasa", ((SchoolClass)cbKlasa.SelectedItem).ID);
            sqlParamWithValue.Add("@NrwDzienniku", Nr);
            sqlParamWithValue.Add("@Promocja", false);
            sqlParamWithValue.Add("@StatusAktywacji", true);
            sqlParamWithValue.Add("@DataAktywacji", dtDataAktywacji.Value);
            sqlParamWithValue.Add("@DataDeaktywacji", dtDataDeaktywacji.Value);
            sqlParamWithValue.Add("@MasterRecord", true);
            sqlParamWithValue.Add("@Owner", UserSession.User.Login);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        async Task<long> AddStudent()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.AddRecordAsync(StudentSQL.InsertStudent(), CreateInsertParams());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private IDictionary<string, object> CreateInsertParams()
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@Nazwisko", txtNazwisko.Text.Trim());
            sqlParamWithValue.Add("@Imie", txtImie.Text.Trim());
            sqlParamWithValue.Add("@Imie2", txtImie2.Text.Trim());
            string Nr = null;
            if (txtNrArkusza.Text.Trim().Length > 0) Nr = txtNrArkusza.Text.Trim();
            sqlParamWithValue.Add("@NrArkusza", Nr);
            sqlParamWithValue.Add("@ImieOjca", txtImieOjca.Text.Trim());
            sqlParamWithValue.Add("@NazwiskoOjca",txtNazwiskoOjca.Text.Trim());
            sqlParamWithValue.Add("@ImieMatki", txtImieMatki.Text.Trim());
            sqlParamWithValue.Add("@NazwiskoMatki", txtNazwiskoMatki.Text.Trim());
            sqlParamWithValue.Add("@DataUr",dtDataUr.Value);
            sqlParamWithValue.Add("@Pesel", txtPesel.Text.Trim()); 
                int? CityID = null;
            if (((City)cbMiejsceUr.SelectedItem).ID != 0) CityID = ((City)cbMiejsceUr.SelectedItem).ID;
            sqlParamWithValue.Add("@IdMiejsceUr", CityID);
            CityID = null;
            if (((City)cbMiejsceZam.SelectedItem).ID != 0) CityID = ((City)cbMiejsceZam.SelectedItem).ID;
            sqlParamWithValue.Add("@IdMiejsceZam", CityID);
            sqlParamWithValue.Add("@Ulica", txtUlica.Text.Trim());
            sqlParamWithValue.Add("@NrDomu", txtNrDomu.Text.Trim());
            sqlParamWithValue.Add("@NrMieszkania", txtNrMieszkania.Text.Trim());
            sqlParamWithValue.Add("@Tel", txtTelefon.Text.Trim());
            sqlParamWithValue.Add("@TelKom1", txtTelKom1.Text.Trim());
            sqlParamWithValue.Add("@TelKom2", txtTelKom2.Text.Trim());
            sqlParamWithValue.Add("@Man", chkSex.Checked);
            sqlParamWithValue.Add("@Owner", UserSession.User.Login);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        private void cmdAddNewPlace_Click(object sender, EventArgs e)
        {
            var ID = City.AddCity();
            if (ID != null)
            {
                cbMiejsceUr.DataSource = City.ComboItems.GetCities();
                cbMiejsceZam.DataSource = City.ComboItems.GetCities();
                //(sender as ComboBox).SelectedIndex = City.ComboItems.GetCityIndex((int)ID, (sender as ComboBox).Items);
            }
        }

        private void txtPesel_Validating(object sender, CancelEventArgs e)
        {
            if (txtPesel.Text.Length == 0) return;
            if (!CalcHelper.ValidatePesel(txtPesel.Text))
            {
                MessageBox.Show("Nr PESEL jest nieprawidłowy!\nWpisz poprawny nr PESEL lub pozostaw pole puste.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
