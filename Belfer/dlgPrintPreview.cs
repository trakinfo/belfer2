using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using Belfer.Properties;

namespace Belfer
{
    public partial class dlgPrintPreview : Form
    {
        public dlgPrintPreview()
        {
            InitializeComponent();
            pvWydruk.Document = Doc;
            pvWydruk.Zoom = (double)nudZoom.Value * 0.01;
            GetPageSettings();
            GetFontSettings();
            SetMargins();
        }
        public PrintDocument Doc = new PrintDocument();
        public delegate void PreviewModeDelegate(bool IsPreview);
        public event PreviewModeDelegate PreviewModeChanged;

        private void OK_Button_Click(object sender, EventArgs e)
        {
            var dlgPrint = new PrintDialog();
            dlgPrint.AllowSomePages = true;
            dlgPrint.PrinterSettings.FromPage = 1;
            dlgPrint.PrinterSettings.ToPage = 1;
            if (dlgPrint.ShowDialog() == DialogResult.OK)
            {
                PreviewModeChanged?.Invoke(false);
                pvWydruk.Document.PrinterSettings.PrintRange=dlgPrint.PrinterSettings.PrintRange;
                pvWydruk.Document.PrinterSettings.FromPage = dlgPrint.PrinterSettings.FromPage;
                pvWydruk.Document.PrinterSettings.ToPage = dlgPrint.PrinterSettings.ToPage;               
                pvWydruk.Document.PrinterSettings.PrinterName = dlgPrint.PrinterSettings.PrinterName;
                for (int i = 0; i < dlgPrint.PrinterSettings.Copies; i++)
                {
                    pvWydruk.Document.Print();
                }
                PreviewModeChanged?.Invoke(true);                
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GetPageSettings()
        {
            if (UserSession.User.Settings.Landscape) { rbHorizontal.Checked = true; } else { rbVertical.Checked = true; }
           
            nudLeftMargin.Value = (decimal)Math.Round(CalcHelper.Math.INtoMM(UserSession.User.Settings.LeftMargin));
            nudTopMargin.Value = (decimal)Math.Round(CalcHelper.Math.INtoMM(UserSession.User.Settings.TopMargin));
        }

        private void GetFontSettings()
        {
            txtStyle.Font = UserSession.User.Settings.TextFont;
            txtStyle.Text = UserSession.User.Settings.TextFont.FontFamily.Name+"; ";
            txtStyle.Text += UserSession.User.Settings.TextFont.Size+"pt; ";
            if (UserSession.User.Settings.TextFont.Bold) { txtStyle.Text += "pogrubienie,"; }
            if (UserSession.User.Settings.TextFont.Italic) { txtStyle.Text += "kursywa"; }

            txtSHStyle.Font = UserSession.User.Settings.SubHeaderFont;
            txtSHStyle.Text = UserSession.User.Settings.SubHeaderFont.FontFamily.Name+"; ";
            txtSHStyle.Text += UserSession.User.Settings.SubHeaderFont.Size+"pt; ";
            if (UserSession.User.Settings.SubHeaderFont.Bold) { txtSHStyle.Text += "pogrubienie,"; }
            if (UserSession.User.Settings.SubHeaderFont.Italic) { txtSHStyle.Text += "kursywa"; }

            txtHStyle.Font = UserSession.User.Settings.HeaderFont;
            txtHStyle.Text = UserSession.User.Settings.HeaderFont.FontFamily.Name+"; ";
            txtHStyle.Text += UserSession.User.Settings.HeaderFont.Size+"pt; ";
            if (UserSession.User.Settings.HeaderFont.Bold) { txtHStyle.Text += "pogrubienie,"; }
            if (UserSession.User.Settings.HeaderFont.Italic) { txtHStyle.Text += "kursywa"; }
        }

        private void nudZoom_ValueChanged(object sender, EventArgs e)
        {
            tbZoom.Value = (int)nudZoom.Value;
            pvWydruk.Zoom = (double)nudZoom.Value * 0.01;
        }

        private void tbZoom_Scroll(object sender, EventArgs e)
        {
            nudZoom.Value = tbZoom.Value;
            pvWydruk.Zoom = tbZoom.Value * 0.01;
        }
        public void NewRow() => pvWydruk.Rows += 1;
       
        private void pvWydruk_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Shift || ModifierKeys == Keys.Control)
            {
                if ((double)nudZoom.Minimum <= pvWydruk.Zoom * 100 / 2)
                {
                    pvWydruk.Zoom = pvWydruk.Zoom / 2.0;
                    nudZoom.Value = (decimal)pvWydruk.Zoom * 100;
                }                
            }
            else
            {
                if ((double)nudZoom.Maximum >= pvWydruk.Zoom * 100 * 2)
                {
                    pvWydruk.Zoom = pvWydruk.Zoom * 2.0;
                    nudZoom.Value = (decimal)pvWydruk.Zoom * 100;
                }
            }
        }

        private void cmdFontSetup_Click(object sender, EventArgs e)
        {
            var fd = new FontDialog();
            fd.FontMustExist = true;
            fd.Font = UserSession.User.Settings.TextFont;
            fd.MinSize = 8;
            fd.MaxSize = 16;
            if (fd.ShowDialog() == DialogResult.OK)
            {
				//UserSession.User.Settings.IsDirty = true;
                UserSession.User.Settings.TextFont = fd.Font;
                UserSession.User.Settings.SubHeaderFont = new Font(UserSession.User.Settings.SubHeaderFont.FontFamily, UserSession.User.Settings.TextFont.Size + 1, FontStyle.Bold);
                UserSession.User.Settings.HeaderFont = new Font(UserSession.User.Settings.HeaderFont.FontFamily, UserSession.User.Settings.TextFont.Size + 2, FontStyle.Bold);
                GetFontSettings();
                pvWydruk.Rows = 1;
                pvWydruk.InvalidatePreview();
            }
        }

        private void rbVertical_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked) return;
			//UserSession.User.Settings.IsDirty = true;
			UserSession.User.Settings.Landscape = ((RadioButton)sender).Name == rbHorizontal.Name ? ((RadioButton)sender).Checked : !((RadioButton)sender).Checked;
            pvWydruk.Document.DefaultPageSettings.Landscape = UserSession.User.Settings.Landscape;
            pvWydruk.Rows = 1;
            pvWydruk.InvalidatePreview();
        }

        private void nudLeftMargin_ValueChanged(object sender, EventArgs e)
        {
			UserSession.User.Settings.LeftMargin = (int)CalcHelper.Math.MMtoIN(((float)((NumericUpDown)sender).Value));
			//UserSession.User.Settings.IsDirty = true;
			SetHorizontalMargins();
            pvWydruk.Rows = 1;
            pvWydruk.InvalidatePreview();
        }

        private void nudTopMargin_ValueChanged(object sender, EventArgs e)
        {
			UserSession.User.Settings.TopMargin = (int)CalcHelper.Math.MMtoIN(((float)((NumericUpDown)sender).Value));
			//UserSession.User.Settings.IsDirty = true;
            SetVerticalMargins();
            pvWydruk.Rows = 1;
            pvWydruk.InvalidatePreview();
        }
        private void SetMargins()
        {
            SetHorizontalMargins();
            SetHorizontalMargins();
        }
        private void SetHorizontalMargins()
        {
            Doc.DefaultPageSettings.Margins.Left = UserSession.User.Settings.LeftMargin;
            Doc.DefaultPageSettings.Margins.Right = UserSession.User.Settings.LeftMargin;
        }
        private void SetVerticalMargins()
        {
            Doc.DefaultPageSettings.Margins.Top = UserSession.User.Settings.TopMargin;
            Doc.DefaultPageSettings.Margins.Bottom = UserSession.User.Settings.TopMargin;
        }
    }
}
