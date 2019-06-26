using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.IO;
using Belfer.Administrator.Model;
using Belfer.Helpers;

namespace Belfer
{
    public partial class dlgManyUsers : Form
    {
        public List<User> NewUsers = new List<User>();
        public dlgManyUsers()
        {
            InitializeComponent();
            ListViewConfig(olvUser);
            GenerateColumns(olvUser, SpecifyCols());
            NewRecord();
            GetData(olvUser);
        }

        private void ListViewConfig(ObjectListView olv)
        {
            olv.View = View.Details;
            olv.FullRowSelect = false;
            olv.GridLines = false;
            olv.AllowColumnReorder = false;
            olv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            olv.HideSelection = false;
            //olv.UseFiltering = true;
            olv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
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
            olv.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClickAlways;
            olv.ShowGroups = false;
            olv.CellEditUseWholeCell = true;
            olv.CellEditEnterChangesRows = true;
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
            Cols.Add(new OLVColumn { Text = "Login", AspectName = "Login", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Login użytkownika", UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Nazwisko", WordWrap = true, AspectName = "LastName", MinimumWidth = 100, Width = 150, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko użytkownika", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Imię", WordWrap = true, AspectName = "FirstName", MinimumWidth = 100, Width = 150, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Imię użytkownika", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Status", WordWrap = true, AspectName = "Status", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Status użytkownika", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Rola", WordWrap = true, AspectName = "Role", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Rola użytkownika", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "E-mail", WordWrap = true, AspectName = "Email", MinimumWidth = 100, Width = 200, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Adres e-mailużytkownika", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Płeć", WordWrap = true, AspectName = "Sex", MinimumWidth = 50, Width = 50, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Płeć użytkownika", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false });

            return Cols;
        }
        private void GetData(ObjectListView olv)
        {
            try
            {
                olv.BeginUpdate();
                olv.SetObjects(NewUsers);
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void NewRecord()
        {
            try
            {
                NewUsers.Add(new User());
                GetData(olvUser);
                olvUser.Select();
                //olvUser.SelectedObject = NewUsers.Last();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            NewRecord();

        }

        private void cmdCancel_Click(object sender, EventArgs e) => Close();


        private void olvUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                NewRecord();
            }
        }

        private void olvUser_CellEditValidating(object sender, CellEditEventArgs e)
        {
            try
            {
                if (e.NewValue.ToString().Length == 0) return;
                if (e.Column.AspectName == "Login")
                {
                    if (dlgUser.CheckLoginExist(e.NewValue.ToString().Trim()))
                    {
                        ((User)e.RowObject).Login = e.NewValue.ToString().ToLower();
                        e.Cancel = false;
                    }
                    else
                    {
                        MessageBox.Show("Podany login jest zajęty. Spróbuj wprowadzić inny!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else if (e.Column.AspectName == "Email")
                {
                    if (StringHelper.ValidateEmail(e.NewValue.ToString().Trim()))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        MessageBox.Show("Wprowadzony adres email jest nieprawidłowy!\nWprowadź poprawny adres lub pozostaw pole puste.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            var i = 0;
            while (i < NewUsers.Count)
            {
                if (NewUsers[i].Login == null || NewUsers[i].Login.Trim().Length == 0)
                {
                    NewUsers.RemoveAt(i);
                    continue;
                }
                i++;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void olvUser_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName != "Login") return;
            if (e.Control is TextBox) ((TextBox)e.Control).CharacterCasing = CharacterCasing.Lower;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog() { DefaultExt = "csv", AddExtension = true, Filter = "Pliki csv (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*" };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var csv = new OLVExporter() { IncludeColumnHeaders = true, ListView = olvUser, ModelObjects = NewUsers }.ExportTo(OLVExporter.ExportFormat.CSV);
                File.WriteAllText(dlg.FileName, csv);
                MessageBox.Show("Plik został zapisany!", Application.ProductName, MessageBoxButtons.OK);
            }
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog() { DefaultExt = "csv", Filter = "Pliki csv (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*" };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                NewUsers = new List<User>();
                using (var R = new CsvHelper.CsvReader(File.OpenText(dlg.FileName)))
                {
                    while (R.Read())
                    {
                        var U = new User();
                        U.Login = R.GetField("Login");
                        U.LastName = R.GetField("Nazwisko");
                        U.FirstName = R.GetField("Imię");
                        U.Status = R.GetField<User.UserStatus>("Status");
                        U.Role = R.GetField<User.UserRole>("Rola");
                        U.Email = R.GetField("E-mail");
                        U.Sex = R.GetField<User.UserSex>("Płeć");

                        NewUsers.Add(U);
                    }
                }
                GetData(olvUser);
            }
        }
    }
}
