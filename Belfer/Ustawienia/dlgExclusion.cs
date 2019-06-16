using Autofac;
using Belfer.Administrator.Model;
using Belfer.DataBaseContext;
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
    public partial class dlgExclusion : Form
    {
        public delegate void NewExclusion(Exclusion e);
        public event NewExclusion NewRecordAdded;
        //int classID, privilegeID;
        Privilege privilege;
        public dlgExclusion(Privilege privilege)
        {
            InitializeComponent();
            //classID = ClassID;
            //privilegeID = PrivilegeID;
            this.privilege = privilege;

            GenerateColumns(olvStudent, SpecifyStudentCols());
            ListViewConfig(olvStudent);
            GetData(olvStudent, GetStudentListAsync(privilege.ClassID, privilege.ID));
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
            olv.AlwaysGroupByColumn = olv.AllColumns[1];
        }

        private void GenerateColumns(ObjectListView olv, List<OLVColumn> Cols)
        {
            olv.AllColumns.Clear();
            olv.AllColumns.AddRange(Cols);
            olv.RebuildColumns();
        }
        private List<OLVColumn> SpecifyStudentCols()
        {
            var Cols = new List<OLVColumn>();
            Cols.Add(new OLVColumn { Text = "Nr", AspectName = "StudentNo", MinimumWidth = 50, MaximumWidth = 100, Width = 50, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Center, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nr ucznia w dzienniku", UseInitialLetterForGroup = false, Groupable = false, HeaderCheckBox = true });
            Cols.Add(new OLVColumn { Text = "Nazwisko i imię", WordWrap = true, AspectName = "Student.FullName", MinimumWidth = 100, Width = 200, FillsFreeSpace = true, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwisko i imię ucznia", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
            Cols.Add(new OLVColumn { Text = "Początek\nwykluczenia", WordWrap = true, AspectName = "StartDate", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data początkowa wykluczenia ucznia z uprawnienia", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = (cellValue) => ((DateTime)cellValue).ToShortDateString() });
            Cols.Add(new OLVColumn { Text = "Początek\nwykluczenia", WordWrap = true, AspectName = "EndDate", MinimumWidth = 50, Width = 100, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Data końcowa wykluczenia ucznia z uprawnienia", TextAlign = HorizontalAlignment.Center, UseInitialLetterForGroup = false, AspectToStringConverter = (cellValue) => ((DateTime)cellValue).ToShortDateString() });
            Cols.Add(new OLVColumn { Text = "ID", AspectName = "ID", MinimumWidth = 0, Width = 0, MaximumWidth = 60, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Identyfikator pozycji", Groupable = false, IsEditable = false });

            return Cols;
        }
        private void GetData(ObjectListView olv, Task<IEnumerable<StudentAllocation>> ItemList)
        {
            try
            {
                olv.BeginUpdate();
                olv.SetObjects(ItemList.Result);
                olv.EndUpdate();
                olv.Enabled = olv.Items.Count > 0;
                lblRecord.Text = "0 z " + olv.Items.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task<IEnumerable<StudentAllocation>> GetStudentListAsync(int ClassID, int PrivilegeID)
        {
            try
            {
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    return await dbs.FetchRecordSetAsync(PrivilegeSQL.SelectStudent(ClassID, PrivilegeID), (R) =>
                    {
                        int.TryParse(R["NrwDzienniku"].ToString(), out int Nr);
                        var startDate = new DateTime[2];
                        var endDate = new DateTime[2];
                        startDate[0] = privilege.StartDate;
                        endDate[0] = privilege.EndDate;
                        DateTime.TryParse(R["DataAktywacji"].ToString(), out startDate[1]);
                        DateTime.TryParse(R["DataDeaktywacji"].ToString(), out endDate[1]);
                        return new StudentAllocation
                        {
                            ID = Convert.ToInt32(R["ID"]),
                            StudentNo = Nr,
                            Student = new Student { LastName = R["Nazwisko"].ToString(), FirstName = R["Imie"].ToString() },
                            StartDate = startDate.Max(),
                            EndDate = endDate.Min(),
                            Status = (User.UserStatus)Convert.ToInt64(R["StatusAktywacji"]),
                            Creator = new Signature()
                            {
                                Owner = UserSession.User.Login,
                                User = UserSession.User.Login,
                                IP = AppSession.HostIP
                            }
                        };
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddNewExclusion())
                {
                    GetData(olvStudent, GetStudentListAsync(privilege.ClassID, privilege.ID));
                    olvStudent.UncheckHeaderCheckBox(olvStudent.AllColumns.Where(x => x.AspectName == "StudentNo").First());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AddNewExclusion()
        {
            try
            {
                int recordCount = 0;
                var sqlString = PrivilegeSQL.InsertExclusion();
                var sqlParamWithValue = new HashSet<IDictionary<string, object>>();
                foreach (StudentAllocation S in olvStudent.CheckedObjects) sqlParamWithValue.Add(new Dictionary<string, object>
                {
                    {"@AllocationID",S.ID},
                    {"@PrivilegeID",privilege.ID},
                    {"@StartDate",S.StartDate},
                    {"@EndDate",S.EndDate},
                    {"@Owner",S.Creator.Owner},
                    {"@User",S.Creator.User},
                    {"@IP",S.Creator.IP}
                });
                using (var scope = AppSession.TypeContainer.BeginLifetimeScope())
                {
                    var dbs = scope.Resolve<IDataBaseService>();
                    recordCount = dbs.AddManyRecordsAsync(sqlString, sqlParamWithValue).Result.RecordCount;
                }
                if (recordCount > 0)
                {
                    MessageBox.Show($"{recordCount} rekordów zostało dodanych.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NewRecordAdded?.Invoke(new Exclusion
                    {
                        AllocationID = (int)sqlParamWithValue.Last().Where(x => x.Key == "@AllocationID").First().Value,
                        PrivilegeID = (int)sqlParamWithValue.Last().Where(x => x.Key == "@PrivilegeID").First().Value
                    });
                    return true;
                }
                throw new Exception($"Wystąpił błąd podczas dodawania wykluczenia.\nOperacja została anulowana.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e) => Close();

        private void olvStudent_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            cmdOK.Enabled = olvStudent.CheckedObjects.Count > 0;
        }

        private void olvObsada_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column.AspectName == "StartDate" || e.Column.AspectName == "EndDate")
            {
                var C = e.Control as DateTimePicker;
                C.MinDate = privilege.StartDate;
                C.MaxDate = privilege.EndDate;
            }
        }

        private void olvObsada_CellEditValidating(object sender, CellEditEventArgs e)
        {
            var D = e.RowObject as StudentAllocation;
            if (e.Column.AspectName == "StartDate")
            {
                if ((DateTime)e.NewValue > D.EndDate)
                {
                    e.Cancel = true;
                    MessageBox.Show("Data końcowa musi być większa lub równa niż data początkowa!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else if (e.Column.AspectName == "EndDate")
            {
                if ((DateTime)e.NewValue < D.StartDate)
                {
                    e.Cancel = true;
                    MessageBox.Show("Data końcowa musi być większa lub równa niż data początkowa!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
}
