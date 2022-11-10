using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Attendance
{
    public partial class Register1 : Form
    {
        public Register1(Form1 frm1)
        {
            this.frm1 = frm1;
            frm3 = new Register2(frm1);
            InitializeComponent();
        }

        Form1 frm1;
        Register2 frm3;

        private bool button;

        private void Register1_Load(object sender, EventArgs e)
        {

        }

        private void CloseButtob(object sender, EventArgs e)
        {
            frm1.Close();
        }

        private void OnNameClick(object sender, EventArgs e)
        {
            if (Username.Text == "Имя пользователя")
            {
                Username.Clear();
            }

            pictureBox2.BackgroundImage = Properties.Resources.user2;
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            Username.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox4.BackgroundImage = Properties.Resources.role1;
            panel3.BackColor = Color.WhiteSmoke;
            Role.ForeColor = Color.WhiteSmoke;

            pictureBox3.BackgroundImage = Properties.Resources.group1;
            panel6.BackColor = Color.WhiteSmoke;
            GroupBox.ForeColor = Color.WhiteSmoke;
        }

        private void OnRoleClick(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                Username.Text = "Имя пользователя";
            }

            pictureBox4.BackgroundImage = Properties.Resources.role2;
            panel3.BackColor = Color.FromArgb(78, 184, 206);
            Role.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox2.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            Username.ForeColor = Color.WhiteSmoke;

            pictureBox3.BackgroundImage = Properties.Resources.group1;
            panel6.BackColor = Color.WhiteSmoke;
            GroupBox.ForeColor = Color.WhiteSmoke;
        }

        private void OnGroupClick(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                Username.Text = "Имя пользователя";
            }

            pictureBox3.BackgroundImage = Properties.Resources.group2;
            panel6.BackColor = Color.FromArgb(78, 184, 206);
            GroupBox.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox2.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            Username.ForeColor = Color.WhiteSmoke;

            pictureBox4.BackgroundImage = Properties.Resources.role1;
            panel3.BackColor = Color.WhiteSmoke;
            Role.ForeColor = Color.WhiteSmoke;
        }

        private void OnBackClick(object sender, EventArgs e)
        {
            frm1.Show();
            frm1.TopMost = false;
            button1.Enabled = false;
            button2.Enabled = false;
            timer1.Start();
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
                this.Hide();
                frm1.button1.Enabled = true;
                frm1.button2.Enabled = true;
            }
        }

        private void OnNextButton(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.user1;
            panel1.BackColor = Color.WhiteSmoke;
            Username.ForeColor = Color.WhiteSmoke;

            pictureBox4.BackgroundImage = Properties.Resources.role1;
            panel3.BackColor = Color.WhiteSmoke;
            Role.ForeColor = Color.WhiteSmoke;

            frm1.Username = Username.Text;
            frm1.Role = Role.Text;
            frm1.Group = GroupBox.Text;

            if (Username.Text == "Имя пользователя" || Username.Text == "")
            {
                pictureBox5.Visible = true;
                button = false;
            } else
            {
                button = true;
            }

            if (Role.Text == "Роль")
            {
                pictureBox7.Visible = true;
                button = false;
            }
            else
            {
                button = true;
            }

            if (GroupBox.Text == "Группа")
            {
                pictureBox6.Visible = true;
                button = false;
            }
            else
            {
                button = true;
            }

            if (button)
            {
                frm3.Show();
                frm3.Opacity = 0.0;
                frm3.TopMost = true;
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            frm3.Opacity += 0.1;

            if (frm3.Opacity == 1.0)
            {
                timer3.Stop();
                this.Hide();
            }
        }
    }
}
