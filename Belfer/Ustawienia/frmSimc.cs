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

namespace Belfer
{
	public partial class frmSimc : Form
	{
		public event EventHandler TheEnd;
		internal Simc.CityBySimc City;
		IEnumerable<Simc.CityBySimc> SimcList;
		private dlgWait Wait = new dlgWait { Tag = "Pobieranie danych ..." };
		private Timer tmRefresh;

		public frmSimc(string SelectSimc)
		{
			InitializeComponent();
			LoadFilterCriteria();
			ListViewConfig(folvCity);
			GenerateColumns(folvCity, SpecifyCols());
			LoadSimc(SelectSimc);
			GetData(folvCity);
			
		}
		void LoadSimc(string SelectSimc)
		{
			var bwFetchData = new BackgroundWorker();
			bwFetchData.DoWork -= bwFetchData_DoWork;
			bwFetchData.DoWork += bwFetchData_DoWork;
			bwFetchData.RunWorkerCompleted -= bwFetchData_RunWorkerCompleted;
			bwFetchData.RunWorkerCompleted += bwFetchData_RunWorkerCompleted;

			tmRefresh = new Timer { Interval = 500 };
			tmRefresh.Tick -= tmRefresh_tick;
			tmRefresh.Tick += tmRefresh_tick;

			bwFetchData.RunWorkerAsync(SelectSimc);
			tmRefresh.Start();
			Wait.ShowDialog();
			
		}

		private void tmRefresh_tick(Object sender, EventArgs e) => Wait.Refresh();

		private void bwFetchData_DoWork(Object sender, DoWorkEventArgs e)
		{
			try
			{
				var S = new Simc(e.Argument.ToString());
				SimcList = S.CityListBySimc;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void bwFetchData_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
		{
			Wait.Close();
			tmRefresh.Stop();
		} 

		private void LoadFilterCriteria()
		{
			cbSeek.DataSource = new string[] { "Nazwa", "ID", "Gmina", "Powiat", "Województwo" };
		}

		private void GenerateColumns(FastObjectListView olv, List<OLVColumn> Cols)
		{
			olv.AllColumns.Clear();
			olv.AllColumns.AddRange(Cols);
			olv.RebuildColumns();
		}
		private List<OLVColumn> SpecifyCols()
		{
			var Cols = new List<OLVColumn>();
			Cols.Add(new OLVColumn { Text = "ID", AspectName = "Code", MinimumWidth = 50, Width = 70, FillsFreeSpace = false, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Identyfikator miejscowości", UseInitialLetterForGroup = false });
			Cols.Add(new OLVColumn { Text = "Nazwa", AspectName = "Name", MinimumWidth = 100, Width = 200, FillsFreeSpace = true, TextAlign = HorizontalAlignment.Left, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa miejscowości", UseInitialLetterForGroup = true });
			Cols.Add(new OLVColumn { Text = "Gmina", WordWrap = true, AspectName = "CommunityName", MinimumWidth = 100, Width = 150, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa gminy", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
			Cols.Add(new OLVColumn { Text = "Powiat", WordWrap = true, AspectName = "CountyName", MinimumWidth = 100, Width = 150, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa powiatu", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
			Cols.Add(new OLVColumn { Text = "Województwo", WordWrap = true, AspectName = "ProvinceName", MinimumWidth = 100, Width = 150, FillsFreeSpace = false, HeaderTextAlign = HorizontalAlignment.Center, ToolTipText = "Nazwa województwa", TextAlign = HorizontalAlignment.Left, UseInitialLetterForGroup = true });
			return Cols;
		}
		private void ListViewConfig(FastObjectListView olv)
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
			olv.MultiSelect = false;
			HeaderFormatStyle HeaderStyle = new HeaderFormatStyle();
			HeaderStyle.SetFont(new Font(olv.Font.FontFamily, olv.Font.Size, FontStyle.Bold));
			olv.HeaderFormatStyle = HeaderStyle;
			//olv.AlwaysGroupByColumn = GetGroupColumn();
		}

		private void frmSimc_FormClosing(object sender, FormClosingEventArgs e) => TheEnd?.Invoke(sender, e);

		private void cmdClose_Click(object sender, EventArgs e) => Close();

		private void GetData(FastObjectListView olv)
		{
			try
			{
				olv.BeginUpdate();
				olv.SetObjects(SimcList);
				olv.EndUpdate();
				olv.Enabled = olv.Items.Count > 0;
				lblRecord.Text = "0 z " + olv.Items.Count;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtSeek_TextChanged(sender, e);
			txtSeek.Select();
		}

		private void txtSeek_TextChanged(object sender, EventArgs e)
		{
			switch (cbSeek.SelectedIndex)
			{
				case 0:
					folvCity.ModelFilter = new ModelFilter(x => ((Simc.CityBySimc)x).Name.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
					break;
				case 1:
					folvCity.ModelFilter = new ModelFilter(x => ((Simc.CityBySimc)x).Code.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
					break;
				case 2:
					folvCity.ModelFilter = new ModelFilter(x => ((Simc.CityBySimc)x).CommunityName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
					break;
				case 3:
					folvCity.ModelFilter = new ModelFilter(x => ((Simc.CityBySimc)x).CountyName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
					break;
				case 4:
					folvCity.ModelFilter = new ModelFilter(x => ((Simc.CityBySimc)x).ProvinceName.StartsWith(txtSeek.Text, StringComparison.CurrentCultureIgnoreCase));
					break;
			}
			lblRecord.Text = "0 z " + folvCity.GetItemCount();
		}

		private void folvCity_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected)
			{
				lblRecord.Text = (e.ItemIndex + 1) + " z " + e.Item.ListView.Items.Count;
				cmdOK.Enabled = true;
			}
			else
			{
				lblRecord.Text = "0 z " + e.Item.ListView.Items.Count;
				cmdOK.Enabled = false;
			}
		}

		private void folvCity_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
		{
			e.IsBalloon = true;
			
			switch (e.ColumnIndex)
			{
				case 0:
					e.Text = string.Concat("Identyfikator podstawowy:\n",((Simc.CityBySimc)e.Model).PrimaryCode);
					break;
				case 1:
					var Name = SimcList.Where(x => x.Code == ((Simc.CityBySimc)e.Model).PrimaryCode).FirstOrDefault().Name;
					e.Text = string.Concat("Nazwa podstawowa:\n", Name);
					break;
				case 2:
					e.Text= string.Concat("Kod gminy:\n", ((Simc.CityBySimc)e.Model).CommunityCode);
					break;
				case 3:
					e.Text = string.Concat("Kod powiatu:\n", ((Simc.CityBySimc)e.Model).CountyCode);
					break;
				case 4:
					e.Text = string.Concat("Kod województwa:\n", ((Simc.CityBySimc)e.Model).ProvinceCode);
					break;
			}
		}

		private void folvCity_SelectionChanged(object sender, EventArgs e)
		{
			City = (Simc.CityBySimc)((FastObjectListView)sender).SelectedObject;
		}
	}
	
}
