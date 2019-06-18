using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Drawing.Printing;
using System.Threading.Tasks;
using Autofac;
using DataBaseService;
using Belfer.Administrator.SQL;
using Belfer.Administrator.Model;

namespace Belfer
{
    public partial class frmUser : Form
    {
        public event EventHandler TheEnd;
        public string SelectString;

        public frmUser(string selectQuery)
        {
            InitializeComponent();
            lblRecord.Text = "";
            ListViewConfig(olvUser);
            LoadFilterCriteria();

            GenerateColumns(olvUser, SpecifyCols());
            SelectString = selectQuery;
            GetData(olvUser);
        }

        private void pnlRecord_Paint(object sender, PaintEventArgs e)
        {
            var LinePen = new Pen(Color.White);
            e.Graphics.DrawLine(LinePen, pnlRecord.Left - 10, pnlRecord.Height - 1, pnlRecord.Width, pnlRecord.Height - 1);
        }

        private void LoadFilterCriteria()
        {
            cbSeek.DataSource = new string[] { "Login", "Nazwisko i imię", "Rola", "Status" };
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
            olv.CheckBoxes = true;
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
            Cols.Add(new OLVColumn { Text = "Login", AspectName = "Login", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Login użytkownika", UseInitialLetterForGroup = true, HeaderCheckBox = true });
            Cols.Add(new OLVColumn { Text = "Nazwisko i imię", WordWrap = true, AspectName = "Name", MinimumWidth = 100, Width = 250, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię użytkownika", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Status", WordWrap = true, AspectName = "Status", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Status użytkownika", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Rola", WordWrap = true, AspectName = "Role", MinimumWidth = 100, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Rola użytkownika", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "E-mail", WordWrap = true, AspectName = "Email", MinimumWidth = 100, Width = 200, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Adres e-mailużytkownika", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Płeć", WordWrap = true, AspectName = "Sex", MinimumWidth = 50, Width = 50, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Płeć użytkownika", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false });

            return Cols;
        }
        //private OLVColumn GetGroupColumn()
        //{
        //	return new OLVColumn { AspectGetter = delegate (object R) { User U = (User)R; return U.Login; }, GroupKeyGetter = delegate (object R) { User U = (User)R; return U.Role; } };
        //}

        private void GetData(ObjectListView olv)
        {
            try
            {
                olv.BeginUpdate();
                olv.SetObjects(GetUserList());
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
                lblRecord.Text = "0 z " + olv.Items.Count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private IEnumerable<User> GetUserList()
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return dbs.FetchRecordSetAsync(SelectString, UserModel).Result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        User UserModel(IDataReader U)
        {
            return new User
            {
                Login = U["Login"].ToString(),
                FirstName = U["Imie"].ToString(),
                LastName = U["Nazwisko"].ToString(),
                Sex = (User.UserSex)Convert.ToUInt64(U["Sex"]),
                Status = (User.UserStatus)Convert.ToUInt64(U["Status"]),
                Role = (User.UserRole)Convert.ToByte(U["Role"]),
                Password = U["Password"].ToString(),
                Email = U["email"].ToString(),
                Faximile = U["Faximile"] as Image,
                Creator = new Signature
                {
                    Owner = U["Owner"].ToString(),
                    User = U["User"].ToString(),
                    IP = U["ComputerIP"].ToString(),
                    Version = Convert.ToDateTime(U["Version"])
                }
            };
        }

        private void olvSzkola_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                lblRecord.Text = (e.ItemIndex + 1) + " z " + e.Item.ListView.Items.Count;
                GetSignature(((e.Item as OLVListItem).RowObject as User).Creator);
                EnableButton(true);
            }
            else
            {
                lblRecord.Text = "0 z " + e.Item.ListView.Items.Count;
                ClearSignature();
                EnableButton(false);
            }
        }

        private void GetSignature(Signature itemCreator)
        {
            lblData.Text = itemCreator.Version.ToString();
            lblIP.Text = itemCreator.IP;
            lblUser.Text = itemCreator.ToString();
        }

        private void ClearSignature()
        {
            foreach (Label lbl in pnlSignature.Controls)
            {
                if (lbl.Name.StartsWith("lbl")) lbl.Text = "";
            }
        }

        private void EnableButton(bool v)
        {
            //cmdDelete.Enabled = v;
            cmdEdit.Enabled = v;
            cmdPassword.Enabled = v;
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            using (var dlg = new dlgUser())
            {
                dlg.IsNewMode = true;
                dlg.cbRola.DataSource = Enum.GetNames(typeof(User.UserRole));
                dlg.txtLogin.Select();
                dlg.NewRecordAdded += NewRecord;
                dlg.ShowDialog();
                dlg.NewRecordAdded -= NewRecord;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (olvUser.SelectedObject as User == null) return;
            EditUser();
        }
        private void EditUser()
        {
            try
            {
                var U = olvUser.SelectedObject as User;
                using (var dlg = new dlgUser())
                {
                    FillDialog(dlg, U);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (UpdateUserAsync(dlg, U.Login).Result > 0)
                        {
                            NewRecord(U.Login);
                            return;
                        }
                        throw new Exception("Aktualizacja danych nie powiodła się!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task<int> UpdateUserAsync(dlgUser dlg, string login)
        {
            User.UserRole R = User.UserRole.Rodzic; // = (User.UserRole)Enum.Parse(typeof(User.UserRole), dlg.cbRola.SelectedValue.ToString());
            Enum.TryParse(dlg.cbRola.SelectedValue.ToString(), out R);
            var sqlParamWithValue = new Dictionary<string, object>()
            {
                {"@Login", login},
                {"@Nazwisko", dlg.txtNazwisko.Text.Trim()},
                {"@Imie", dlg.txtImie.Text.Trim()},
                {"@Rola", R},
                {"@Email", dlg.txtEmail.Text.Trim()},
                {"@Status", dlg.chkStatus.Checked},
                {"@Sex", dlg.chkSex.Checked},
                {"@User", UserSession.User.Login},
                {"@IP", AppSession.HostIP}
            };
            using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
            {
                var dbs = scope.Resolve<IDataBaseService>();
                return await dbs.UpdateRecordAsync(UserSQL.UpdateUser(), sqlParamWithValue);
            }
        }
        void FillDialog(dlgUser dlg, User U)
        {
            dlg.IsNewMode = false;
            dlg.Text = "Edycja danych użytkownika";
            dlg.txtPassword.Enabled = false;
            dlg.txtPassword2.Enabled = false;
            dlg.cmdPwdGen.Enabled = false;
            dlg.chkShowPassword.Enabled = false;
            dlg.txtLogin.Enabled = false;

            dlg.cbRola.DataSource = Enum.GetNames(typeof(User.UserRole));
            dlg.txtLogin.Text = U.Login;
            dlg.cbRola.Text = U.Role.ToString();
            dlg.chkStatus.Checked = (int)U.Status > 0;
            dlg.txtNazwisko.Text = U.LastName;
            dlg.txtImie.Text = U.FirstName;
            dlg.chkSex.Checked = (int)U.Sex > 0;
            dlg.txtEmail.Text = U.Email;
            dlg.pbFaximile.Image = U.Faximile;

            dlg.txtLogin.Select();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }
        void DeleteUser()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wskazane pozycje?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var sqlString = UserSQL.DeleteUser();
                    var RecordCount = 0;
                    var sqlParamWithValue = new HashSet<Tuple<string, object>>();

                    foreach (User U in olvUser.CheckedObjects) sqlParamWithValue.Add(new Tuple<string, object>("@Login", U.Login));
                    using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                    {
                        var dbs = scope.Resolve<IDataBaseService>();
                        RecordCount = dbs.RemoveManyRecordsAsync(sqlString, sqlParamWithValue).Result;
                    }
                    RefreshData();
                    MessageBox.Show($"{RecordCount} rekordów zostało usuniętych.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void NewRecord(string RecordID)
        {
            RefreshData();
            SeekHelper.SetListItem<User, string>(RecordID, "Login", olvUser);
        }

        private void RefreshData()
        {
            AppSession.Users = Authentication.GetUsers().Result;
            GetData(olvUser);
        }

        private void frmSchool_FormClosing(object sender, FormClosingEventArgs e)
        {
            TheEnd?.Invoke(sender, e);
        }

        private void txtSeek_TextChanged(object sender, EventArgs e)
        {
            switch (cbSeek.SelectedIndex)
            {
                case 0://Login
                    olvUser.ModelFilter = new ModelFilter(x => ((User)x).Login.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 1://Nazwisko i imię
                    olvUser.ModelFilter = new ModelFilter(x => ((User)x).Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 2://Rola
                    olvUser.ModelFilter = new ModelFilter(x => ((User)x).Role.ToString().StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
                case 3://Status
                    olvUser.ModelFilter = new ModelFilter(x => ((User)x).Status.ToString().StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
                    break;
            }
            lblRecord.Text = "0 z " + olvUser.GetItemCount();
        }

        private void cbSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeek_TextChanged(sender, e);
            txtSeek.Select();
        }

        private void cmdAddMany_Click(object sender, EventArgs e)
        {
            using (var dlg = new dlgManyUsers())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    UsersToPrint = new List<User>();
                    var Rec = AddUser(dlg.NewUsers);
                    if (Rec > 0)
                    {
                        GetData(olvUser);
                        MessageBox.Show($"Dodano rekordów: {Rec.ToString()}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void olvUser_DoubleClick(object sender, EventArgs e) => cmdEdit_Click(sender, e);

        private void cmdPassword_Click(object sender, EventArgs e)
        {
            var U = (olvUser.SelectedObject as User);
            if (U == null) return;
            if (Authentication.ChangePassword(U))
            {
                var AU = AppSession.Users.Where(x => x.Login == U.Login).FirstOrDefault();
                if (AU != null) AU.Password = U.Password;
            }
        }
        int AddUser(List<User> usr)
        {
            try
            {
                var count = 0;
                var sqlString = UserSQL.InsertUser();
                var sqlParamWithValue = new HashSet<IDictionary<string, object>>();
                foreach (var U in usr)
                {
                    var plainPwd = StringHelper.RandomizePassword();
                    var SaltedPasswordHash = Enigma.HashHelper.CreatePassword(plainPwd);
                    U.Password = Convert.ToBase64String(SaltedPasswordHash);

                    sqlParamWithValue.Add(new Dictionary<string, object>
                    {
                        { "@Login", U.Login },
                        { "@LastName", U.LastName },
                        { "@FirstName", U.FirstName },
                        { "@Password", U.Password },
                        { "@Role", U.Role },
                        { "@Status", U.Status },
                        { "@Sex", U.Sex },
                        { "@Email", U.Email },
                        { "@Owner", UserSession.User.Login },
                        { "@User", UserSession.User.Login },
                        { "@IP", AppSession.HostIP },
                    });
                    U.Password = plainPwd;
                    UsersToPrint.Add(U);
                }
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    count = dbs.AddManyRecordsAsync(sqlString, sqlParamWithValue).Result.RecordCount;
                }
                if (count > 0) PrintAccountInfo();
                return count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }

        private List<User> UsersToPrint;

        private PrintHelper PH = new PrintHelper();

        private void PrintAccountInfo()
        {
            try
            {
                PH.Offset = new int[1];
                dlgPrintPreview dlgPrint = new dlgPrintPreview();
                dlgPrint.PreviewModeChanged += PH.PreviewModeChanged;
                PH.NewRow += dlgPrint.NewRow;
                PH.NextPage += doc_PrintPage;
                dlgPrint.Doc.BeginPrint += PH.PrnDoc_BeginPrint;
                dlgPrint.Doc.PrintPage += doc_PrintPage;
                dlgPrint.Doc.EndPrint += PH.doc_EndPrint;

                dlgPrint.ShowDialog();

                dlgPrint.PreviewModeChanged -= PH.PreviewModeChanged;
                PH.NewRow -= dlgPrint.NewRow;
                PH.NextPage -= doc_PrintPage;
            }
            catch (InvalidPrinterException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception)
            {

                throw;
            }

        }
        //private void PreviewModeChanged(bool PreviewMode) => IsPreview = PreviewMode;
        //private void PrnDoc_BeginPrint(object sender, PrintEventArgs e)
        //{
        //	if (e.PrintAction == PrintAction.PrintToPrinter) IsPreview = false; else IsPreview = true;
        //}
        //private void doc_EndPrint(object sender, PrintEventArgs e)
        //{
        //	PageNumber = 0;
        //	for (int i = 0; i < Offset.GetLength(0); i++)
        //	{
        //		Offset[i] = 0;
        //	}
        //}
        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            #region -------------------------- Print variables definitions -----------------------
            PH.G = e.Graphics;
            PrintDocument Doc = (PrintDocument)sender;
            float x = PH.IsPreview ? UserSession.User.Settings.LeftMargin : UserSession.User.Settings.LeftMargin - e.PageSettings.PrintableArea.Left;
            float y = PH.IsPreview ? UserSession.User.Settings.TopMargin : UserSession.User.Settings.TopMargin - e.PageSettings.PrintableArea.Top;
            float y0 = y;
            Font TextFont = UserSession.User.Settings.TextFont;

            float LineHeight = TextFont.GetHeight(e.Graphics);

            int PrintWidth = e.MarginBounds.Width / 2;
            int PrintHeight = e.MarginBounds.Bottom;
            int ColOffset = (PrintWidth + (int)x) * -1;
            #endregion

            PH.PageNumber += 1;

            #region --------------------------- Document header and footer -----------------------
            PH.DrawHeader(x, y, PrintWidth * 2);
            PH.DrawFooter(x, PrintHeight, PrintWidth * 2);
            PH.DrawPageNumber("- " + PH.PageNumber.ToString() + " -", x, PrintHeight, PrintWidth * 2, PageNumberLocation.Footer);
            #endregion

            PH.DrawLine(x + PrintWidth, y, x + PrintWidth, PrintHeight - LineHeight);
            #region ---------------------------- Document body -----------------------------------
            while (y + LineHeight * 4 < PrintHeight && PH.Offset[0] < UsersToPrint.Count())
            {
                PrintObjectData(UsersToPrint[PH.Offset[0]], x, ref y, PrintWidth, TextFont, LineHeight);
                ColOffset *= -1;
                x += ColOffset;
                if (ColOffset > 0) y = y0; else y0 = y;
                PH.Offset[0]++;
            }
            if (PH.Offset[0] < UsersToPrint.Count())
            {
                PH.PrintNextPage(Doc, e);
            }
            #endregion
        }


        private void PrintObjectData(User Node, float x, ref float y, float PrintWidth, Font PrintFont, float LineHeight)
        {
            PH.DrawText("Nazwisko i imię: ", PrintFont, x, y, PrintWidth, LineHeight, StringAlignment.Near, Brushes.Black, false, false);
            var Indent = PH.G.MeasureString("Nazwisko i imię: ", PrintFont).Width;
            PH.DrawText(Node.Name, new Font(PrintFont, FontStyle.Bold), x + Indent, y, PrintWidth - Indent, LineHeight, 0, Brushes.Black, false, false);
            y += LineHeight;

            PH.DrawText("Rola: ", PrintFont, x, y, PrintWidth, LineHeight, 0, Brushes.Black, false, false);
            Indent = PH.G.MeasureString("Rola: ", PrintFont).Width;
            PH.DrawText(Node.Role.ToString(), new Font(PrintFont, FontStyle.Bold), x + Indent, y, PrintWidth - Indent, LineHeight, 0, Brushes.Black, false, false);
            Indent += PH.G.MeasureString(Node.Role.ToString(), new Font(PrintFont, FontStyle.Bold)).Width;
            Indent += 20;
            PH.DrawText("Status: ", PrintFont, x + Indent, y, PrintWidth - Indent, LineHeight, 0, Brushes.Black, false, false);
            Indent += PH.G.MeasureString("Status: ", PrintFont).Width;
            PH.DrawText(Node.Status.ToString(), new Font(PrintFont, FontStyle.Bold), x + Indent, y, PrintWidth - Indent, LineHeight, 0, Brushes.Black, false, false);
            y += LineHeight * 2;

            PH.DrawText("Login: ", PrintFont, x, y, PrintWidth, LineHeight, 0, Brushes.Black, false, false);
            Indent = PH.G.MeasureString("Login: ", PrintFont).Width;
            PH.DrawText(Node.Login.ToString(), new Font(PrintFont, FontStyle.Bold), x + Indent, y, PrintWidth - Indent, LineHeight, 0, Brushes.Black, false, false);
            Indent += PH.G.MeasureString(Node.Login.ToString(), new Font(PrintFont, FontStyle.Bold)).Width;
            Indent += 20;
            PH.DrawText("Hasło: ", PrintFont, x + Indent, y, PrintWidth - Indent, LineHeight, 0, Brushes.Black, false, false);
            Indent += PH.G.MeasureString("Hasło: ", PrintFont).Width;
            PH.DrawText(Node.Password.ToString(), new Font(PrintFont, FontStyle.Bold), x + Indent, y, PrintWidth - Indent, LineHeight, 0, Brushes.Black, false, false);
            PH.DrawLine(x, y + LineHeight * 1.5f, x + PrintWidth, y + LineHeight * 1.5f);

            y += LineHeight * 2;
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void olvUser_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            cmdSave.Enabled = olvUser.CheckedObjects.Count > 0;
            cmdDelete.Enabled = olvUser.CheckedObjects.Count > 0;
        }
    }
}
