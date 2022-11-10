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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Web.Security;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;
using TextBox = System.Windows.Forms.TextBox;

namespace Attendance.Forms
{
    public partial class FormGrupList : Form
    {
        public FormGrupList(MainWindows mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        MainWindows mw;

        private string Group;
        private int CenterBarX;
        private int CenterTextX;
        private int CenterLblX;

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

        private void FormGrupList_Load(object sender, EventArgs e)
        {
            Theme();

            UserData();

            CenterBarX = this.Size.Width / 2;
            CenterTextX = label1.Size.Width / 2;
            CenterLblX = CenterBarX - CenterTextX;

            label1.Location = new Point(CenterLblX, label1.Location.Y);

            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;

            LoadGridView();
        }

        private void Theme()
        {
            foreach (Button button in GetControl<Button>(this.Controls).OrderBy(c => c.Name))
            {
                button.BackColor = ThemeColor.PrimaryColor;
                button.FlatAppearance.BorderColor = ThemeColor.ScondaryColor;
                button.ForeColor = mw.colorLite;
            }

            if (Properties.Settings.Default.Theme == true)
            {
                this.BackColor = mw.colorLite;

                dataGridView1.BackgroundColor = mw.colorLite;

                foreach (Label label in GetControl<Label>(this.Controls).OrderBy(c => c.Name))
                {
                    label.ForeColor = Color.FromArgb(39, 39, 58);
                }

                foreach (Panel panel in GetControl<Panel>(this.Controls).OrderBy(c => c.Name))
                {
                    panel.BackColor = Color.FromArgb(39, 39, 58);
                }

                foreach (TextBox textBox in GetControl<TextBox>(this.Controls).OrderBy(c => c.Name))
                {
                    textBox.BackColor = mw.colorLite;
                    textBox.ForeColor = mw.colorDark;
                }
            }
            else
                if (Properties.Settings.Default.Theme == false)
            {
                this.BackColor = mw.colorDark;

                dataGridView1.BackgroundColor = mw.colorDark;

                foreach (Label label in GetControl<Label>(this.Controls).OrderBy(c => c.Name))
                {
                    label.ForeColor = Color.FromArgb(241, 241, 241);
                }

                foreach (Panel panel in GetControl<Panel>(this.Controls).OrderBy(c => c.Name))
                {
                    panel.BackColor = Color.FromArgb(241, 241, 241);
                }

                foreach (TextBox textBox in GetControl<TextBox>(this.Controls).OrderBy(c => c.Name))
                {
                    textBox.BackColor = mw.colorDark;
                    textBox.ForeColor = mw.colorLite;
                }
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.PrimaryColor;
        }

        private void UserData()
        {
            label1.Text = $"Группа: {mw.UserGroup}";

            if (mw.UserRole == "Админ" || mw.UserRole == "Студент")
            {
                foreach (Panel panel in GetControl<Panel>(this.Controls).OrderBy(c => c.Name))
                {
                    panel.Visible = true;
                }

                foreach (TextBox textBox in GetControl<TextBox>(this.Controls).OrderBy(c => c.Name))
                {
                    textBox.Visible = true;
                }

                btnAdd.Visible = true;
            }

            string Group1 = "36/2ИСд-20к";
            string Group2 = "20/СА-21к";
            string Group3 = "12ИС-22к";

            if (mw.UserGroup == Group1)
            {
                Group = "Group1";
            }
            else
            if (mw.UserGroup == Group2)
            {
                Group = "Group2";
            }
            else
            if (mw.UserGroup == Group3)
            {
                Group = "Group3";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO [{Group}] (LastName, FirstName, MiddleName, Birthday, Phone) VALUES (@LastName, @FirstName, @MiddleName, @Birthday, @Phone)", mw.Conn);

            command.Parameters.AddWithValue("LastName", textBox1.Text);
            command.Parameters.AddWithValue("FirstName", textBox2.Text);

            if (textBox3.Text == "Отчество" || textBox3.Text == "")
            {
                command.Parameters.AddWithValue("MiddleName", null);
            } else
            {
                command.Parameters.AddWithValue("MiddleName", textBox3.Text);
            }

            if (dateTimePicker1.Text == DateTime.Today.ToString())
            {
                command = new SqlCommand($"INSERT INTO [{Group}] (LastName, FirstName, MiddleName, Phone) VALUES (@LastName, @FirstName, @MiddleName, @Phone)", mw.Conn);

                command.Parameters.AddWithValue("LastName", textBox1.Text);
                command.Parameters.AddWithValue("FirstName", textBox2.Text);

                if (textBox3.Text == "Отчество" || textBox3.Text == "")
                {
                    command.Parameters.AddWithValue("MiddleName", null);
                }
                else
                {
                    command.Parameters.AddWithValue("MiddleName", textBox3.Text);
                }
            } else
            {
                DateTime date = DateTime.Parse(dateTimePicker1.Text);
                command.Parameters.AddWithValue("Birthday", $"{date.Month}/{date.Day}/{date.Year}");
            }
            
            if (textBox5.Text == "Телефон" || textBox5.Text == "")
            {
                command.Parameters.AddWithValue("Phone", null);
            } else
            {
                command.Parameters.AddWithValue("Phone", textBox5.Text);
            }
            

            command.ExecuteNonQuery();
            GridView();

            textBox1.Text = "Фамилия";
            textBox2.Text = "Имя";
            textBox3.Text = "Отчество";
            textBox5.Text = "Телефон";
        }

        public void LoadGridView()
        {
            dataGridView1.DataSource = mw.gl;
        }

        public void GridView()
        {
            mw.LoadGridView();
            dataGridView1.DataSource = mw.gl;
        }

        private void MiddleNameTextBox(object sender, EventArgs e)
        {
            if (textBox3.Text == "Отчество")
            {
                textBox3.Clear();
            }
        }

        private void PhoneTextBox(object sender, EventArgs e)
        {
            if (textBox5.Text == "Телефон")
            {
                textBox5.Clear();
            }
        }

        private void LastNameTextBox(object sender, EventArgs e)
        {
            if (textBox1.Text == "Фамилия")
            {
                textBox1.Clear();
            }
        }

        private void FirstNameTextBox(object sender, EventArgs e)
        {
            if (textBox2.Text == "Имя")
            {
                textBox2.Clear();
            }
        }
    }
}
