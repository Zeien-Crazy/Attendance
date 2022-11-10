using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;
using System.Windows.Markup;

namespace Attendance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            frm2 = new Register1(this);
            mw = new MainWindows(this);
            InitializeComponent();

            panel4.Dock = DockStyle.Fill;
            this.Opacity = 0.0;

            this.AllowTransparency = true;
            panel4.BackColor = Color.FromArgb(36, 36, 45);//цвет фона  
            this.TransparencyKey = panel4.BackColor;//он же будет заменен на прозрачный цвет

            Login.Text = "Логин";
            Pass.Text = "Пароль";
            Pass.TextChanged += new System.EventHandler(this.Pass_TextChanged);
            checkBox1.Checked = Properties.Settings.Default.checkBox;

            Login.ForeColor = Color.FromArgb(34, 36, 49);
            panel1.BackColor = Color.FromArgb(34, 36, 49);
            Pass.ForeColor = Color.FromArgb(34, 36, 49);
            panel3.BackColor = Color.FromArgb(34, 36, 49);

            button1.BackColor = Color.FromArgb(34, 36, 49);
            button2.ForeColor = Color.FromArgb(34, 36, 49);
            button2.FlatAppearance.BorderColor = Color.FromArgb(34, 36, 49);

            pictureBox1.Controls.Add(pictureBox3);
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.BackgroundImage = null;
            pictureBox3.BackColor = Color.Transparent;

            pictureBox2.Controls.Add(pictureBox5);
            pictureBox5.Location = new Point(0, 0);
            pictureBox5.BackgroundImage = null;
            pictureBox5.BackColor = Color.Transparent;

            pictureBox4.Controls.Add(pictureBox6);
            pictureBox6.Location = new Point(0, 0);
            pictureBox6.BackgroundImage = null;
            pictureBox6.BackColor = Color.Transparent;

            pictureBox3.BackColor = Color.FromArgb(34, 36, 49);
            pictureBox5.BackColor = Color.FromArgb(34, 36, 49);
            pictureBox6.BackColor = Color.FromArgb(34, 36, 49);
        }

        public SqlConnection Conn = null;

        public Register1 frm2;
        public MainWindows mw;

        public string Username = "";
        public string Role = "";
        public string login = "";
        public string Password = "";
        public string UserName = "";
        public string Group = "";

        public string UserGroupId;
        public string UserRole;
        public string UserLogin;
        public string UserPass;

        public int finMax;
        public int finMin;

        private async void Form1_Load(object sender, EventArgs e)
        {
            int l_i;
            double o;

            for (o = 0.0, l_i = pictureBox7.Location.Y - 10; o <= 1.0 & l_i <= pictureBox7.Location.Y + 10; o += 0.1, l_i++, await Task.Delay(30))
            {
                this.Opacity = o;
                pictureBox7.Location = new Point(pictureBox7.Location.X, l_i);
            }

            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AttendanceDb"].ConnectionString);

            Conn.Open();

            checkBox1.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y - 10);
            panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + 2);
;
            finMin = this.Left;
            finMax = this.Left + this.Size.Width;

            if (Properties.Settings.Default.checkBox == true)
            {
                Login.Text = Properties.Settings.Default.Login.ToString();
                Pass.Text = Properties.Settings.Default.Password.ToString();
            }
            ShowToWidjet();
        }

        public async void ShowToWidjet()
        {
            //groound - 34; 36; 49

            //label, panel - 245; 245; 245

            //button - 78; 184; 206

            byte r, g, b, a;
            int l_t, l_p, l_b, l_i, l_c;
            int loc = checkBox1.Location.Y;
            double o;

            for (o = 1.0, l_i = pictureBox7.Location.Y - 10; o >= 0.0 & l_i <= pictureBox7.Location.Y + 10; o -= 0.1, l_i++, await Task.Delay(30))
            {
                this.Opacity = o;
            }
            panel4.Dispose();

            //Появление Формы
            for (double i = 0.0; i <= 1.0; i += 0.1, await Task.Delay(30))
            {
                this.Opacity = i;
            }

            //Повление лога
            for (a = 255, l_i = pictureBox1.Location.Y - 10; a >= 1 & l_i <= pictureBox1.Location.Y + 10; a -= 17, l_i++, await Task.Delay(5))
            {
                pictureBox3.BackColor = Color.FromArgb(a, 34, 36, 49);
                pictureBox1.Location = new Point(pictureBox1.Location.X, l_i);
            }

            //Появление 1-й строки
            for (r = 34, g = 36, b = 49, a = 255, l_i = pictureBox2.Location.Y - 10, l_t = Login.Location.Y - 10, l_p = panel1.Location.Y - 10; r <= 245 & g <= 245 & b <= 245 & a >= 1 & l_i <= pictureBox2.Location.Y + 10 & l_t <= Login.Location.Y + 10 & l_p <= panel1.Location.Y + 10; r += 21, g += 21, b += 20, a -= 17, l_i++, l_t++, l_p++, await Task.Delay(5))
            {
                Login.ForeColor = Color.FromArgb(r, g, b);
                Login.Location = new Point(Login.Location.X, l_t);

                panel1.BackColor = Color.FromArgb(r, g, b);
                panel1.Location = new Point(panel1.Location.X, l_p);

                pictureBox5.BackColor = Color.FromArgb(a, 34, 36, 49);
                pictureBox2.Location = new Point(pictureBox2.Location.X, l_i);
            }
            pictureBox5.BackColor = Color.FromArgb(0, 34, 36, 49);

            //Появление 2-й строки
            for (r = 34, g = 36, b = 49, a = 255, l_i = pictureBox4.Location.Y - 10, l_t = Pass.Location.Y - 10, l_p = panel3.Location.Y - 10; r <= 245 & g <= 245 & b <= 245 & a >= 1 & l_i <= pictureBox4.Location.Y + 10 & l_t <= Pass.Location.Y + 10 & l_p <= panel3.Location.Y + 10; r += 21, g += 21, b += 20, a -= 17, l_i++, l_t++, l_p++, await Task.Delay(5))
            {
                Pass.ForeColor = Color.FromArgb(r, g, b);
                Pass.Location = new Point(Pass.Location.X, l_t);

                panel3.BackColor = Color.FromArgb(r, g, b);
                panel3.Location = new Point(panel3.Location.X, l_p);

                pictureBox6.BackColor = Color.FromArgb(a, 34, 36, 49);
                pictureBox4.Location = new Point(pictureBox4.Location.X, l_i);
            }
            pictureBox6.BackColor = Color.FromArgb(0, 34, 36, 49);


            //Появление checkBox1
            for (l_c = loc; l_c <= loc + 12; l_c++, await Task.Delay(5))
            {
                checkBox1.Location = new Point(checkBox1.Location.X, l_c);
            }
            //panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - 2);


            //Появление button1
            for (r = 34, g = 36, b = 49, l_b = button1.Location.Y - 10; r <= 78 & g <= 184 & b <= 206 & l_b <= button1.Location.Y + 10; r += 4, g += 15, b += 16, l_b++, await Task.Delay(5))
            {
                button1.BackColor = Color.FromArgb(r, g, b);
                button1.Location = new Point(button1.Location.X, l_b);
            }


            //Появление button2
            for (r = 34, g = 36, b = 49, l_b = button2.Location.Y - 10; r <= 245 & g <= 245 & b <= 245 & l_b <= button2.Location.Y + 10; r += 21, g += 21, b += 20, l_b++, await Task.Delay(5))
            {
                button2.ForeColor = Color.FromArgb(r, g, b);
                button2.FlatAppearance.BorderColor = Color.FromArgb(r, g, b);
                button2.Location = new Point(button2.Location.X, l_b);
            }
        }

        private void OnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClickLogin(object sender, EventArgs e)
        {
            if (Login.Text == "Логин")
            {
                Login.Clear();
            }

            /*if (Pass.Text == "")
            {
                Pass.Text = "Пароль";
            }*/

            pictureBox2.Image = Properties.Resources.user2;
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            Login.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox4.BackgroundImage = Properties.Resources.password1;
            panel3.BackColor = Color.WhiteSmoke;
            Pass.ForeColor = Color.WhiteSmoke;
        }

        private void OnClickPass(object sender, EventArgs e)
        {
            if (Pass.Text == "Пароль" || Pass.Text == "Password")
            {
                Pass.Clear();
            }

            /*if (Login.Text == "")
            {
                Login.Text = "Логин";
            }*/

            pictureBox4.BackgroundImage = Properties.Resources.password2;
            panel3.BackColor = Color.FromArgb(78, 184, 206);
            Pass.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox2.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            Login.ForeColor = Color.WhiteSmoke;
        }

        private void Pass_TextChanged(object sender, EventArgs e)
        {
            Pass.PasswordChar = '•';
        }

        private void OnRegisterClck(object sender, EventArgs e)
        {
            frm2.Show();
            frm2.TopMost = false;
            frm2.button1.Enabled = false;
            frm2.button2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frm2.Left += 10;
            if (frm2.Left >= Convert.ToInt32(finMax))
            {
                timer1.Stop();
                this.TopMost = false;
                frm2.TopMost = true;
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            frm2.Left -= 10;
            if (frm2.Left == Convert.ToInt32(finMin))
            {
                timer2.Stop();
                frm2.button1.Enabled = true;
                frm2.button2.Enabled = true;
                this.Hide();
            }
        }

        private void OnSingInClick(object sender, EventArgs e)
        {
            LogIn();
        }

        public void LogIn()
        {
            pictureBox2.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            Login.ForeColor = Color.WhiteSmoke;

            pictureBox4.BackgroundImage = Properties.Resources.password1;
            panel3.BackColor = Color.WhiteSmoke;
            Pass.ForeColor = Color.WhiteSmoke;

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(
                        $"SELECT Username FROM Users WHERE Login = '{Login.Text}' AND Password = '{Pass.Text}'",
                        Conn);

            SqlCommand CommUserLogin = new SqlCommand(
                        $"SELECT Login FROM Users WHERE Login = '{Login.Text}' AND Password = '{Pass.Text}'",
                        Conn);

            SqlCommand CommUserPassword = new SqlCommand(
                        $"SELECT Password FROM Users WHERE Login = '{Login.Text}' AND Password = '{Pass.Text}'",
                        Conn);

            SqlCommand CommGroup = new SqlCommand(
                        $"SELECT [UserGroup] FROM Users WHERE Login = '{Login.Text}' AND Password = '{Pass.Text}'",
                        Conn);

            SqlCommand CommUserRole = new SqlCommand(
                       $"SELECT Role FROM Users WHERE Login = '{Login.Text}' AND Password = '{Pass.Text}'",
                       Conn);

            SqlCommand CommUserStatus = new SqlCommand(
                        $"UPDATE Users SET Status='Online' WHERE Login = '{Login.Text}' AND Password = '{Pass.Text}'",
                        Conn);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                UserName = Convert.ToString(command.ExecuteScalar().ToString());
                UserGroupId = Convert.ToString(CommGroup.ExecuteScalar().ToString());
                UserRole = Convert.ToString(CommUserRole.ExecuteScalar().ToString());
                UserLogin = Convert.ToString(CommUserLogin.ExecuteScalar().ToString());
                UserPass = Convert.ToString(CommUserPassword.ExecuteScalar().ToString());

                CommUserStatus.ExecuteNonQuery();

                if (checkBox1.Checked == true)
                {
                    Properties.Settings.Default.Login = UserLogin;
                    Properties.Settings.Default.Password = UserPass;
                    Properties.Settings.Default.checkBox = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Login = "-";
                    Properties.Settings.Default.Password = "-";
                    Properties.Settings.Default.checkBox = false;
                    Properties.Settings.Default.Save();
                }

                if (mw != null)
                {
                    mw.LoadForm();
                }

                mw.Show();
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }

        public void Register()
        {
            SqlCommand command = new SqlCommand(
                            $"INSERT INTO [Users] (Login, Password, Username, Role, UserGroup, Status) VALUES (@Login, @Password, @Name, @Role, @UserGroup, 'Offline')",
                            Conn);

            command.Parameters.AddWithValue("Login", login);
            command.Parameters.AddWithValue("Password", Password);
            command.Parameters.AddWithValue("Name", Username);
            command.Parameters.AddWithValue("Role", Role);
            command.Parameters.AddWithValue("UserGroup", Group);

            command.ExecuteNonQuery();
        }
    }
}
