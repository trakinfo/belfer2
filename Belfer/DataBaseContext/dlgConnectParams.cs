using System;
using System.Windows.Forms;
using Enigma;
using Newtonsoft.Json.Linq;

namespace Belfer.DataBaseContext
{
    public partial class dlgConnectParams : Form
	{
		public dlgConnectParams()
		{
			InitializeComponent();
			LoadSslMode();
			LoadCommonParams();
		}
		private ConnectionParams ConnectParams;
		private bool[] IsDirty = new bool[5];
		private void cmdOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (rbFromFile.Checked)
				{
					SetConnectParams(txtFileIn.Text);
				}
				else
				{
					SetConnectParams();
				}
				SaveConnectParams();
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (InvalidCastException)
			{
				MessageBox.Show("Plik configuracyjny jest niezgodny z wymaganym schematem!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void SetConnectParams(string FilePath)
		{
			try
			{
				//JSonHelper.ReadConfigFile(txtFileIn.Text, out ConnectParams);
				ConnectParams = new ConnectionParams();
				JObject ECP = JSonHelper.ReadConfigFile(txtFileIn.Text);
				if (JSonHelper.ValidateParams(ECP, typeof(ConnectionParams)))
				{
					ConnectParams = (ConnectionParams)ECP.ToObject(typeof(ConnectionParams));
				}
				else
				{
					throw new InvalidCastException();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		private void SetConnectParams()
		{
			var sslMode = cbSslMode.SelectedIndex;
			//Enum.TryParse(cbSslMode.SelectedIndex.ToString(), out sslMode);
			ConnectParams = new ConnectionParams()
			{
				ServerAddress = CryptoHelper.Encrypt(txtSerwerIP.Text),
				DBName = CryptoHelper.Encrypt(txtDBName.Text),
				UserName = CryptoHelper.Encrypt(txtUserName.Text),
				Password = CryptoHelper.Encrypt(txtPassword.Text),
				SSLMode = sslMode,
				CharSet = txtCharset.Text,
				KeepAlive = (int)nudKeepAlive.Value
			};
		}
		private void cmdCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
		private void LoadCommonParams()
		{
			cbSslMode.SelectedIndex = 0;
			txtCharset.Text = Properties.Settings.Default.Charset;
			nudKeepAlive.Value = Properties.Settings.Default.KeepAlive;
		}
		private void SaveConnectParams()
		{
			Properties.Settings.Default.ServerIP = ConnectParams.ServerAddress;
			Properties.Settings.Default.DBName = ConnectParams.DBName;
			Properties.Settings.Default.SysUser = ConnectParams.UserName;
			Properties.Settings.Default.SysPassword = ConnectParams.Password;
			Properties.Settings.Default.Charset = ConnectParams.CharSet;
			Properties.Settings.Default.KeepAlive = ConnectParams.KeepAlive;
			Properties.Settings.Default.SSL = ConnectParams.SSLMode;
			
			Properties.Settings.Default.Save();
		}

		private void rbFromFile_CheckedChanged(object sender, EventArgs e)
		{
			txtFileIn.Enabled = ((RadioButton)sender).Checked;
			cmdOpen.Enabled=((RadioButton)sender).Checked;
			txtFileIn_TextChanged(txtFileIn, null);
		}

		private void rbByHand_CheckedChanged(object sender, EventArgs e)
		{
			gbConnectParams.Enabled = ((RadioButton)sender).Checked;
			if (!((RadioButton)sender).Checked) return;
			txtSerwerIP_TextChanged(txtSerwerIP, null);
		}

		private void LoadSslMode()
		{
			string[] SslMode = { "None", "Preferred", "Required", "VerifyCA", "VerifyFull" };
			cbSslMode.Items.Clear();
			cbSslMode.Items.AddRange(SslMode);
		}

		private void cmdOpen_Click(object sender, EventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.DefaultExt = "json";
			dlg.Filter = "Pliki json (*.json)|*.json|Wszystkie pliki (*.*)|*.*";
			if (dlg.ShowDialog()==DialogResult.OK)
			{
				txtFileIn.Text = dlg.FileName;
				cmdOK.Enabled = true;
			}
		}

		private void cmdSaveToFile_Click(object sender, EventArgs e)
		{
			var dlg = new SaveFileDialog();
			dlg.DefaultExt = "json";
			dlg.AddExtension = true;
			dlg.Filter = "Pliki json (*.json)|*.json|Wszystkie pliki (*.*)|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SetConnectParams();
				if (JSonHelper.CreateConfigFile(dlg.FileName, ConnectParams))
				{
					MessageBox.Show("Plik został zapisany!", Application.ProductName, MessageBoxButtons.OK);
				}
			}
		}

		private void txtSerwerIP_TextChanged(object sender, EventArgs e)
		{
			int index = 0;
			int.TryParse(((TextBox)sender).Tag.ToString(), out index);
			if (((TextBox)sender).Text.Length > 0) IsDirty[index] = true; else IsDirty[index] = false;
			cmdOK.Enabled = IsDirty[0] && IsDirty[1] && IsDirty[2] && IsDirty[3] && IsDirty[4];
			cmdSaveToFile.Enabled = IsDirty[0] && IsDirty[1] && IsDirty[2] && IsDirty[3] && IsDirty[4];
		}

		private void txtFileIn_TextChanged(object sender, EventArgs e)
		{
			if (rbFromFile.Checked && ((TextBox)sender).Text.Length > 0) cmdOK.Enabled = true; else cmdOK.Enabled = false;
		}
	}
}
