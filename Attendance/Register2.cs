using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Attendance
{
    public partial class Register2 : Form
    {
        public Register2(Form1 frm1)
        {
            this.frm1 = frm1;
            InitializeComponent();
        }

        Form1 frm1;

        private bool button;

        private void OnCloseClick(object sender, EventArgs e)
        {
            frm1.Close();
        }

        private void OnLoginClick(object sender, EventArgs e)
        {
            if (Login.Text == "Логин")
            {
                Login.Clear();
            }

            if (Pass.Text == "")
            {
                Pass.Text = "Пароль";
            }

            pictureBox2.BackgroundImage = Properties.Resources.user2;
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            Login.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox4.BackgroundImage = Properties.Resources.password1;
            panel3.BackColor = Color.WhiteSmoke;
            Pass.ForeColor = Color.WhiteSmoke;
        }

        private void OnPassClick(object sender, EventArgs e)
        {
            if (Pass.Text == "Пароль")
            {
                Pass.Clear();
            }

            if (Login.Text == "")
            {
                Login.Text = "Логин";
            }

            Pass.PasswordChar = '•';
            pictureBox4.BackgroundImage = Properties.Resources.password2;
            panel3.BackColor = Color.FromArgb(78, 184, 206);
            Pass.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox2.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            Login.ForeColor = Color.WhiteSmoke;
        }

        private void OnRegisterClick(object sender, EventArgs e)
        {
            frm1.login = Login.Text;
            frm1.Password = Pass.Text;

            if (Login.Text == "Логин" || Login.Text == "")
            {
                pictureBox5.Visible = true;
                button = false;
            }
            else
            {
                button = true;
            }

            if (Pass.Text == "Пароль" || Pass.Text == "")
            {
                pictureBox3.Visible = true;
                button = false;
            }
            else
            {
                button = true;
            }

            if (button)
            {
                frm1.Show();
                frm1.TopMost = false;
                frm1.Register();

                button1.Enabled = false;

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Left += 10;
            if (this.Left >= Convert.ToInt32(frm1.finMax))
            {
                timer1.Stop();
                frm1.TopMost = true;
                this.TopMost = false;
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Left -= 10;
            if (this.Left <= Convert.ToInt32(frm1.finMin))
            {
                timer2.Stop();
                frm1.button1.Enabled = true;
                frm1.button2.Enabled = true;
                this.Hide();
            }
        }

        private void Pass_TextChanged(object sender, EventArgs e)
        {
            Pass.PasswordChar = '*';
        }
    }
}
