using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace Attendance.Forms
{
    public partial class AdministrationForm : Form
    {
        public AdministrationForm(MainWindows mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        MainWindows mw;

        private void AdministrationForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db_a8e5b9_attendancedbDataSet1.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.db_a8e5b9_attendancedbDataSet1.Users);
            if (Properties.Settings.Default.Theme == true)
            {
                this.BackColor = Color.White;
            }
            else
                if (Properties.Settings.Default.Theme == false)
            {
                this.BackColor = Color.FromArgb(19, 19, 30);
            }

            GridView();
            LoadTheme();
        }

        private void LoadTheme()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.PrimaryColor;

            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            dataGridView2.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.PrimaryColor;

            dataGridView1.BackgroundColor = ThemeColor.ScondaryColor;
            dataGridView2.BackgroundColor = ThemeColor.ScondaryColor;
        }

        private void GridView()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT Username AS 'Пользователь', Status AS 'Статус' FROM Users WHERE Status='Online'",
                mw.Conn);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            dataGridView2.DataSource = dataSet.Tables[0];
        }
    }
}
