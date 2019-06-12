using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belfer
{
	public partial class dlgTeacher : Form
	{
		public dlgTeacher()
		{
			InitializeComponent();
			SetDialog();
		}
		void SetDialog()
		{
			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterParent;
			MinimizeBox = false;
			MaximizeBox = false;
			CancelButton = cmdCancel;
			AcceptButton = cmdOK;
			cmdOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			cmdCancel.Anchor= AnchorStyles.Bottom | AnchorStyles.Right;
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
    }
}
