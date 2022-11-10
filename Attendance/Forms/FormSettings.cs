using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;

namespace Attendance.Forms
{
    public partial class FormSettings : Form
    {
        private MainWindows mw;

        

        public FormSettings(MainWindows mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private IEnumerable<T> GetControl<T>(Control.ControlCollection controls) where T : Control
        {
            foreach (Control control in controls)
            {
                if (control is T)
                {
                    yield return (T)control;
                }
                foreach (Control c in GetControl<T>(control.Controls))
                {
                    if (c is T)
                    {
                        yield return (T)c;
                    }
                }
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            radioButton1.ForeColor = Color.White;
            radioButton2.ForeColor = Color.White;

            panel1.BackColor = ThemeColor.ScondaryColor;
            panel2.BackColor = ThemeColor.ScondaryColor;

            foreach (Label label in GetControl<Label>(this.Controls).OrderBy(c => c.Name))
            {
                label.ForeColor = mw.colorLite;
            }

            foreach (Button button in GetControl<Button>(this.Controls).OrderBy(c => c.Name))
            {
                button.BackColor = ThemeColor.PrimaryColor;
                button.FlatAppearance.BorderColor = ThemeColor.ScondaryColor;
                button.ForeColor = mw.colorLite;
            }

            if (Properties.Settings.Default.Theme == true)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                this.BackColor = Color.White;
            } else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
                this.BackColor = Color.FromArgb(19, 19, 30);
            }
        }

        private void ThemeLoad(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                Properties.Settings.Default.Theme = true;
            } else
                if (radioButton2.Checked == true)
            {
                Properties.Settings.Default.Theme = false;
            }

            Properties.Settings.Default.Save();

            if (Properties.Settings.Default.Theme == true)
            {
                this.BackColor = Color.White;
            }
            else
                if (Properties.Settings.Default.Theme == false)
            {
                this.BackColor = Color.FromArgb(19, 19, 30);
            }
        }

        private void BtnExitToAkk(object sender, EventArgs e)
        {
            SqlCommand CommUserStatus = new SqlCommand(
                        $"UPDATE Users SET Status='Offline' WHERE Login = '{mw.frm1.UserLogin}' AND Password = '{mw.frm1.UserPass}'",
                        mw.Conn);

            CommUserStatus.ExecuteNonQuery();

            Properties.Settings.Default.Login = "-";
            Properties.Settings.Default.Password = "-";

            Properties.Settings.Default.checkBox = false;
            Properties.Settings.Default.Save();

            mw.frm1.checkBox1.Checked = false;

            mw.frm1.Show();
            mw.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand CommUserStatus = new SqlCommand(
                       $"UPDATE Users SET Login='{textBox1.Text}' WHERE Login = '{mw.frm1.UserLogin}' AND Password = '{mw.frm1.UserPass}'",
                       mw.Conn);

            CommUserStatus.ExecuteNonQuery();

            SqlCommand CommUserLogin = new SqlCommand(
                        $"SELECT Login FROM Users WHERE Login = '{textBox1.Text}' AND Password = '{mw.frm1.UserPass}'",
                        mw.Conn);

            SqlCommand CommUserPassword = new SqlCommand(
                        $"SELECT Password FROM Users WHERE Login = '{textBox1.Text}' AND Password = '{mw.frm1.UserPass}'",
                        mw.Conn);

            mw.frm1.UserLogin = Convert.ToString(CommUserLogin.ExecuteScalar().ToString());
            mw.frm1.UserPass = Convert.ToString(CommUserPassword.ExecuteScalar().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand CommUserStatus = new SqlCommand(
                       $"UPDATE Users SET Login='{textBox2.Text}' WHERE Login = '{mw.frm1.UserLogin}' AND Password = '{mw.frm1.UserPass}'",
                       mw.Conn);

            CommUserStatus.ExecuteNonQuery();

            SqlCommand CommUserLogin = new SqlCommand(
                        $"SELECT Login FROM Users WHERE Login = '{mw.frm1.UserLogin}' AND Password = '{textBox2.Text}'",
                        mw.Conn);

            SqlCommand CommUserPassword = new SqlCommand(
                        $"SELECT Password FROM Users WHERE Login = '{mw.frm1.UserLogin}' AND Password = '{textBox2.Text}'",
                        mw.Conn);

            mw.frm1.UserLogin = Convert.ToString(CommUserLogin.ExecuteScalar().ToString());
            mw.frm1.UserPass = Convert.ToString(CommUserPassword.ExecuteScalar().ToString());
        }
    }
}
