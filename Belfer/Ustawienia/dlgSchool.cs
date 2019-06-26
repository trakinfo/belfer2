using Autofac;
using Belfer.DataBaseContext;
using Belfer.Helpers;
using Belfer.Ustawienia;
using DataBaseService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belfer
{

    public partial class dlgSchool : Form
    {
        internal bool IsNewMode;

        public event NewRecord NewRecordAdded;
        public dlgSchool()
        {
            InitializeComponent();

            cbMiejscowosc.DataSource = City.ComboItems.GetCities();
        }


        private void cbTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlSzkola.Enabled = ((School.Type)cbTyp.SelectedItem).ID > 0;
        }

        private void cmdMiejscowosc_Click(object sender, EventArgs e)
        {
            var ID = City.AddCity();
            if (ID != null)
            {
                cbMiejscowosc.DataSource = City.ComboItems.GetCities();
                cbMiejscowosc.SelectedIndex = City.ComboItems.GetCityIndex((int)ID, cbMiejscowosc.Items);
            }
        }

        private void txtNazwa_TextChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = txtNazwa.Text.Trim().Length > 0 && txtAlias.Text.Trim().Length > 0;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!IsNewMode)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                try
                {
                    var recordID = AddSchool().Result;
                    if (recordID > 0)
                    {
                        NewRecordAdded?.Invoke(recordID);
                        ClearControls();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ClearControls()
        {
            foreach (var Ctrl in pnlSzkola.Controls)
            {
                if (Ctrl is TextBox) ((TextBox)Ctrl).Text = null;
            }
        }

        async Task<long> AddSchool()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.AddRecordAsync(SchoolSQL.InsertSchool(), CreateInsertParams());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        IDictionary<string, object> CreateInsertParams()
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            string NipNumber = null;
            if (txtNip.Text.Length > 0) NipNumber = txtNip.Text;
            int? CityID = null;
            if (((City)cbMiejscowosc.SelectedItem).ID != 0) CityID = ((City)cbMiejscowosc.SelectedItem).ID;
            sqlParamWithValue.Add("@IdTyp", ((School.Type)cbTyp.SelectedItem).ID);
            sqlParamWithValue.Add("@Nazwa", txtNazwa.Text.Trim());
            sqlParamWithValue.Add("@Alias", txtAlias.Text.Trim());
            sqlParamWithValue.Add("@Nip", NipNumber);
            sqlParamWithValue.Add("@Ulica", txtUlica.Text.Trim());
            sqlParamWithValue.Add("@Nr", txtNr.Text.Trim());
            sqlParamWithValue.Add("@IdMiejscowosc", CityID);
            sqlParamWithValue.Add("@Telefon", txtTel.Text.Trim());
            sqlParamWithValue.Add("@Fax", txtFax.Text.Trim());
            sqlParamWithValue.Add("@Email", txtEmail.Text.Trim());
            sqlParamWithValue.Add("@Owner", UserSession.User.Login);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@IP", AppSession.HostIP);
            return sqlParamWithValue;
        }

        private void txtNip_Validating(object sender, CancelEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0) return;
            if (CalcHelper.ValidateNip(((TextBox)sender).Text))
                e.Cancel = false;
            else
            {
                MessageBox.Show("Nieprawidłowy numer NIP. Wpisz poprawny numer lub pozostaw pole puste!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Length == 0) return;
            if (StringHelper.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = false;
            }
            else
            {
                MessageBox.Show("Nieprawidłowy adres e-mail. Wpisz poprawny adres lub pozostaw pole puste!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
