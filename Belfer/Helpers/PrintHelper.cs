using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

namespace Belfer.Helpers
{
    /// <summary>
    /// Dostarcza metody umożliwiające wydruk tekstu
    /// </summary>
    public class PrintHelper
    {
        public Graphics G { get; set; }
        public delegate void NewRowHandler();
        public event NewRowHandler NewRow;
        public delegate void NextPageHandler(PrintDocument Doc, PrintPageEventArgs ppea);
        public event NextPageHandler NextPage;
        public bool IsPreview;
        public int PageNumber = default(int);
        public List<string> ReportHeader;
        public int[] Offset;
        public void PreviewModeChanged(bool PreviewMode) => IsPreview = PreviewMode;

        public void PrintNextPage(PrintDocument Doc, PrintPageEventArgs ppea)
        {
            if (IsPreview)
            {
                ppea.HasMorePages = true;
                NewRow?.Invoke();
                return;
            }
            if (ppea.PageSettings.PrinterSettings.PrintRange == PrintRange.SomePages)
            {
                if (!PageInRange(ppea.PageSettings.PrinterSettings.FromPage, ppea.PageSettings.PrinterSettings.ToPage))
                {
                    ppea.Graphics.Clear(Color.White);
                    //doc_PrintPage(Doc, ppea);
                    NextPage?.Invoke(Doc, ppea);
                }
                ppea.HasMorePages = PageNumber < ppea.PageSettings.PrinterSettings.ToPage;
                return;
            }
            ppea.HasMorePages = true;
        }
        private bool PageInRange(int RangeStart, int RangeEnd)
        {
            bool IsPageInRange = PageNumber >= RangeStart;
            IsPageInRange = IsPageInRange && (PageNumber <= RangeEnd);
            return IsPageInRange;
        }

        public void PrnDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter) PreviewModeChanged(false); else PreviewModeChanged(true);
            //if (e.PrintAction == PrintAction.PrintToPrinter) PH.IsPreview = false; else PH.IsPreview = true;
        }
        public void doc_EndPrint(object sender, PrintEventArgs e)
        {
            PageNumber = 0;
            for (int i = 0; i < Offset.GetLength(0); i++)
            {
                Offset[i] = 0;
            }
        }

        public void DrawText(string Text, Font TextFont, float x, float y, float PrintWidth, float PrintHeight, StringAlignment PrintAlignment, Brush FontColor, bool DrawLines = true, bool VerticalLayout = false, bool FillBackgroud = false)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = PrintAlignment;
            strFormat.LineAlignment = StringAlignment.Center;
            if (VerticalLayout) strFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            if (DrawLines) G.DrawRectangle(Pens.Black, x, y, PrintWidth, PrintHeight);
            if (FillBackgroud) G.FillRectangle(Brushes.LightGray, new RectangleF(x, y, PrintWidth, PrintHeight));
            G.DrawString(Text, TextFont, FontColor, new RectangleF(x, y, PrintWidth, PrintHeight), strFormat);
        }
        public void DrawText(string Text, Font TextFont, float x, float y, float PrintWidth, float PrintHeight, byte PrintAlignment, Brush FontColor, int PrintAngle, bool DrawLines = true)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = (StringAlignment)PrintAlignment;
            strFormat.LineAlignment = StringAlignment.Center;
            if (DrawLines) G.DrawRectangle(Pens.Black, x, y, PrintWidth, PrintHeight);
            G.TranslateTransform(x, y + PrintHeight, System.Drawing.Drawing2D.MatrixOrder.Append);
            G.RotateTransform(PrintAngle);
            G.DrawString(Text, TextFont, FontColor, new RectangleF(0, 0, PrintHeight, PrintWidth), strFormat);
            G.ResetTransform();
        }
        /// <summary>
        /// Umożliwia wydruk tekstu zawijanego do następnego wiersza
        /// </summary>
        /// <param name="PrintText">Text do wydrukowania w formie tablicy znaków</param>
        /// <param name="PrintFont">Czcionka</param>
        /// <param name="WordOffset">Wskaźnik położenia ostatnio wydrukowanego słowa przekazany przez referencję</param>
        /// <param name="x">współrzędna x przekazana przez wartość</param>
        /// <param name="y">Współrzędna y przekazana przez referencję</param>
        /// <param name="PrintWidth">Szerokość obszaru wydruku</param>
        /// <param name="PrintHeight">Wysokość obszaru wydruku</param>
        /// <param name="TextLineHeight">Wysokość linii tekstu</param>
        /// <param name="TabIndent">Wielkość wysunięcia tekstu</param>
        /// <returns></returns>
        public bool DrawWrappedText(string[] PrintText, Font PrintFont, ref int WordOffset, float x, ref float y, float PrintWidth, float PrintHeight, float TextLineHeight, int TabIndent = 0)
        {
            StringBuilder TextLine = new StringBuilder();
            do
            {
                TextLine.Append(String.Concat(PrintText[WordOffset], " "));
                if ((G.MeasureString(TextLine.ToString(), PrintFont).Width + TabIndent) > PrintWidth)
                {
                    TextLine.Remove(TextLine.ToString().Length - PrintText[WordOffset].Length - 1, PrintText[WordOffset].Length);
                    DrawText(TextLine.ToString(), PrintFont, x + TabIndent, y, PrintWidth, TextLineHeight, 0, Brushes.Black, false);
                    y += TextLineHeight;
                    WordOffset -= 1;
                    TextLine = new StringBuilder();
                }
                WordOffset += 1;
            } while (PrintText.GetUpperBound(0) >= WordOffset && PrintHeight >= y + TextLineHeight);
            if (PrintHeight >= (y + TextLineHeight))
            {
                DrawText(TextLine.ToString(), PrintFont, x + TabIndent, y, PrintWidth, TextLineHeight, 0, Brushes.Black, false);
                y += TextLineHeight;
                WordOffset = 0;
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Drukuje nr strony na górnym lub dolnym marginesie
        /// </summary>
        /// <param name="PageNumber">Nr strony</param>
        /// <param name="x">współrzędna x</param>
        /// <param name="y">współrzędna y</param>
        /// <param name="PrintWidth">Szerokość obszaru wydruku</param>
        /// <param name="Location">Lokalizacja nr strony (górny lub dolny margines)</param>
        /// <param name="HorizontalAlignment">Poziome położenie nr strony</param>
        public void DrawPageNumber(string PageNumber, float x, float y, float PrintWidth, PageNumberLocation Location, byte HorizontalAlignment = 1)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            //var M = new CalcHelper.Math();
            var BaseFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            if (Location == PageNumberLocation.Header) { y -= CalcHelper.Math.MMtoIN(5) + BaseFont.GetHeight(G); } else { y += CalcHelper.Math.MMtoIN(5) + BaseFont.GetHeight(G); }
            var strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Alignment = (StringAlignment)HorizontalAlignment;
            G.DrawString(PageNumber, BaseFont, Brushes.Black, new Rectangle((int)x, (int)y, (int)PrintWidth, (int)BaseFont.GetHeight(G)), strFormat);
        }
        /// <summary>
        /// Drukuje nagłówek dokumentu na górnym marginesie strony
        /// </summary>
        /// <param name="x">Współrzędna początkowa pozioma</param>
        /// <param name="y">Współrzędna początkowa pionowa</param>
        /// <param name="PrintWidth">Szerokość obszaru wydruku</param>
        public void DrawHeader(float x, float y, float PrintWidth)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            var DotPen = new Pen(Color.Black);
            //var M = new CalcHelper.Math();
            var HeaderFont = new Font("Arial", 8, FontStyle.Italic, GraphicsUnit.Point);
            y -= CalcHelper.Math.MMtoIN(5);
            G.DrawLine(DotPen, x, y, x + PrintWidth, y);
            y -= HeaderFont.GetHeight(G);
            var strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Alignment = StringAlignment.Near;
            G.DrawString(AppSession.Schools.Where(s => s.ID == UserSession.User.Settings.SchoolID).FirstOrDefault().Name, HeaderFont, Brushes.Black, new Rectangle((int)x, (int)y, (int)PrintWidth, (int)HeaderFont.GetHeight(G)), strFormat);
            strFormat.Alignment = StringAlignment.Far;
            G.DrawString("Rok szkolny: " + UserSession.User.Settings.SchoolYear, HeaderFont, Brushes.Black, new Rectangle((int)x, (int)y, (int)PrintWidth, (int)HeaderFont.GetHeight(G)), strFormat);
        }
        /// <summary>
        /// Drukuje stopkę dokumentu na dolnym marginesie strony
        /// </summary>
        /// <param name="x">Współrzędna początkowa pozioma</param>
        /// <param name="y">Współrzędna początkowa pionowa</param>
        /// <param name="PrintWidth">Szerokość obszaru wydruku</param>
        public void DrawFooter(float x, float y, float PrintWidth)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            var DotPen = new Pen(Color.Black);
            //var M = new CalcHelper.Math();
            var FooterFont = new Font("Arial", 8, FontStyle.Italic, GraphicsUnit.Point);
            y += CalcHelper.Math.MMtoIN(5);
            G.DrawLine(DotPen, x, y, x + PrintWidth, y);
            y += FooterFont.GetHeight(G) / 2;
            var strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Alignment = StringAlignment.Near;
            G.DrawString(System.Windows.Forms.Application.ProductName + " (wersja " + System.Windows.Forms.Application.ProductVersion + ")", FooterFont, Brushes.Black, new Rectangle((int)x, (int)y, (int)PrintWidth, (int)FooterFont.GetHeight(G)), strFormat);
            strFormat.Alignment = StringAlignment.Far;
            G.DrawString(DateTime.Now.ToString(), FooterFont, Brushes.Black, new Rectangle((int)x, (int)y, (int)PrintWidth, (int)FooterFont.GetHeight(G)), strFormat);
        }
        public void DrawLine(float x0, float y0, float x1, float y1, float PenWidth = 1)
        {
            x0 += UserSession.User.Settings.XCaliber;
            y0 += UserSession.User.Settings.YCaliber;
            x1 += UserSession.User.Settings.XCaliber;
            y1 += UserSession.User.Settings.YCaliber;
            G.DrawLine(new Pen(Brushes.Black, PenWidth), x0, y0, x1, y1);
        }
        public void DrawRectangle(float PenWidth, float x0, float y0, float Width, float Height)
        {
            x0 += UserSession.User.Settings.XCaliber;
            y0 += UserSession.User.Settings.YCaliber;
            G.DrawRectangle(new Pen(Brushes.Black, PenWidth), x0, y0, Width, Height);
        }
        public void DrawImage(System.Drawing.Image img, float x, float y, float Width, float Height)
        {
            x += UserSession.User.Settings.XCaliber;
            y += UserSession.User.Settings.YCaliber;
            G.DrawImage(img, x, y, Width, Height);
        }
    }
}
