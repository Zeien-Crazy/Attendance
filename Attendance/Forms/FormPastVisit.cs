using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;

namespace Attendance.Forms
{
    public partial class FormPastVisit : Form
    {
        MainWindows mw;

        public FormPastVisit(MainWindows mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void FormPastVisit_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Theme == true)
            {
                this.BackColor = mw.colorLite;
                label1.ForeColor = mw.colorDark;
            }
            else
                if (Properties.Settings.Default.Theme == false)
            {
                this.BackColor = mw.colorDark;
                label1.ForeColor = mw.colorLite;
            }
        }

        private void LoadingGris()
        {

        }
    }
}
