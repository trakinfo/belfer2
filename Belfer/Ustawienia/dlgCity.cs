using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Belfer.Ustawienia;
using Autofac;
using DataBaseService;

namespace Belfer
{
    public partial class dlgCity : Form
    {
        public dlgCity()
        {
            InitializeComponent();

        }
        internal City NewCity = new City();

        private void cmdSimc_Click(object sender, EventArgs e)
        {
            using (var dlg = new frmSimc(CitySQL.SelectPlaceFromSimc()))
            {
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.cmdOK.Visible = true;
                dlg.cmdCancel.Text = "Anuluj";
                dlg.AcceptButton = cmdOK;
                dlg.CancelButton = cmdCancel;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadCity(dlg.City, true);
                }
            }
        }

        private void LoadCity(Simc.CityBySimc CityData, bool PL)
        {
            NewCity.Code = CityData.Code;
            NewCity.Name = CityData.Name;
            NewCity.Poland = PL;
            GetCityData(CityData);
        }

        private void GetCityData(Simc.CityBySimc city)
        {
            txtNazwa.Text = city.Name;
            txtGmina.Text = city.CommunityName;
            txtPowiat.Text = city.CountyName;
            txtWojewództwo.Text = city.ProvinceName;
        }

        private void rbSimc_CheckedChanged(object sender, EventArgs e)
        {
            var Status = ((RadioButton)sender).Checked;
            cmdSimc.Enabled = Status;
            txtNazwa.ReadOnly = Status;
            txtGmina.ReadOnly = Status;
            txtGmina.Enabled = Status;
            txtPowiat.ReadOnly = Status;
            txtPowiat.Enabled = Status;
            txtWojewództwo.ReadOnly = Status;
            txtWojewództwo.Enabled = Status;
            LoadCity(new Simc.CityBySimc(), Status);

        }

        private void txtNazwa_TextChanged(object sender, EventArgs e)
        {
            NewCity.Name = ((TextBox)sender).Text;
            cmdOK.Enabled = ((TextBox)sender).Text.Length > 0;
        }

        public long AddCity()
        {
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return dbs.AddRecordAsync(CitySQL.InsertCity(), CreateInsertParams()).Result;
            }
        }

        IDictionary<string,object> CreateInsertParams()
        {
            var sqlParamWithValue = new Dictionary<string, object>();
            sqlParamWithValue.Add("@Kod", NewCity.Code);
            sqlParamWithValue.Add("@Nazwa", NewCity.Name);
            sqlParamWithValue.Add("@Polska", NewCity.Poland);
            sqlParamWithValue.Add("@Owner", UserSession.User.Login);
            sqlParamWithValue.Add("@User", UserSession.User.Login);
            sqlParamWithValue.Add("@ComputerIP", AppSession.HostIP);
            return sqlParamWithValue;
        }
    }
}
