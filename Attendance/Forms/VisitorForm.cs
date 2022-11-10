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
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;

namespace Attendance.Forms
{
    public partial class VisitorForm : Form
    {
        MainWindows mw;

        private string Group;
        private int CenterBarX;
        private int CenterTextX;
        private int CenterLblX;

        private SqlDataAdapter adapter;
        private DataSet dataSet;


        public VisitorForm(MainWindows mw)
        {
            InitializeComponent();
            this.mw = mw;
            label1.Text = $"Сегодня: {DateTime.Today.Day}.{DateTime.Today.Month}.{DateTime.Today.Year}";
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
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.PrimaryColor;
        }

        private void VisitorForm_Load(object sender, EventArgs e)
        {
            CenterBarX = this.Size.Width / 2;
            CenterTextX = label1.Size.Width / 2;
            CenterLblX = CenterBarX - CenterTextX;

            label1.Location = new Point(CenterLblX, label1.Location.Y);

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

            label2.Visible = true;
            pictureBox1.Visible = true;

            Theme();

            LoadGridView();
        }

        private void LoadGridView()
        {
            if(mw.dt == null)
            {
                button1.Visible = true;
                dataGridView1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
            else
            {
                dataGridView1.DataSource = mw.dt;
                dataGridView1.AutoSize = true;

                button1.Visible = false;
                dataGridView1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;

                Task.Run(() => UpdateAsinc());
            }
        }

        public async void UpdateAsinc()
        {
            await Task.Run(() => mw.LoadVisitor());
            await Task.Delay(1000);

            try
            {
                if (dataGridView1.DataSource != mw.dt)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        dataGridView1.DataSource = mw.dt;
                        dataGridView1.AutoSize = true;
                    });
                }
            }
            catch  { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "Выполняется создание таблицы на сегодня, пожалуйста подождите";
            panel1.Visible = true;

            SqlCommand Command = new SqlCommand(
                $"CREATE TABLE [dbo].[{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}]" +
                "(Id INT NOT NULL IDENTITY (1, 1) PRIMARY KEY," +
                "Couple1 NVARCHAR(2) NOT NULL)",
                mw.Conn);

            Command.ExecuteNonQuery();

            SqlDataAdapter dataAdapterNoNum = new SqlDataAdapter(
                    $"SELECT Id FROM [{Group}]", mw.Conn);
            DataSet NumNo = new DataSet();

            dataAdapterNoNum.Fill(NumNo);

            SqlCommand CommandAddColumn = new SqlCommand(
                $"INSERT INTO [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}]  (Couple1) VALUES ('')",
                mw.Conn);

            for (int i = 0; i < NumNo.Tables[0].Rows.Count; i++)
            {
                CommandAddColumn.ExecuteNonQuery();
            }

            mw.LoadVisitor();

            dataGridView1.DataSource = mw.dt;

            button1.Visible = false;
            dataGridView1.Visible = true;
            button2.Visible = true;
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "Выполняется обновление таблицы, пожалуйста подождите";
            panel1.Visible = true;

            try
            {
                adapter = new SqlDataAdapter($"SELECT Id, Couple1, Couple2, Couple3, Couple4 FROM [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}]",
                mw.Conn);

                dataSet = new DataSet();

                adapter.Fill(dataSet, "Visit");

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataSet.Tables["Visit"].Rows[i]["Couple1"] = dataGridView1.Rows[i].Cells["Пара 1"].Value;
                    dataSet.Tables["Visit"].Rows[i]["Couple2"] = dataGridView1.Rows[i].Cells["Пара 2"].Value;
                    dataSet.Tables["Visit"].Rows[i]["Couple3"] = dataGridView1.Rows[i].Cells["Пара 3"].Value;
                    dataSet.Tables["Visit"].Rows[i]["Couple4"] = dataGridView1.Rows[i].Cells["Пара 4"].Value;
                }
            }
            catch
            {
                try
                {
                    adapter = new SqlDataAdapter($"SELECT Id, Couple1, Couple2, Couple3 FROM [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}]",
                        mw.Conn);

                    dataSet = new DataSet();

                    adapter.Fill(dataSet, "Visit");

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataSet.Tables["Visit"].Rows[i]["Couple1"] = dataGridView1.Rows[i].Cells["Пара 1"].Value;
                        dataSet.Tables["Visit"].Rows[i]["Couple2"] = dataGridView1.Rows[i].Cells["Пара 2"].Value;
                        dataSet.Tables["Visit"].Rows[i]["Couple3"] = dataGridView1.Rows[i].Cells["Пара 3"].Value;
                    }
                }
                catch
                {
                    try
                    {
                        adapter = new SqlDataAdapter($"SELECT Id, Couple1, Couple2 FROM [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}]",
                            mw.Conn);

                        dataSet = new DataSet();

                        adapter.Fill(dataSet, "Visit");

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataSet.Tables["Visit"].Rows[i]["Couple1"] = dataGridView1.Rows[i].Cells["Пара 1"].Value;
                            dataSet.Tables["Visit"].Rows[i]["Couple2"] = dataGridView1.Rows[i].Cells["Пара 2"].Value;
                        }
                    }
                    catch
                    {
                        adapter = new SqlDataAdapter($"SELECT Id, Couple1 FROM [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}]",
                            mw.Conn);

                        dataSet = new DataSet();

                        adapter.Fill(dataSet, "Visit");

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataSet.Tables["Visit"].Rows[i]["Couple1"] = dataGridView1.Rows[i].Cells["Пара 1"].Value;
                        }
                    }
                }
            }

            SqlCommandBuilder sqlBuilderStudens = new SqlCommandBuilder(adapter);

            sqlBuilderStudens.GetUpdateCommand();

            adapter.UpdateCommand = sqlBuilderStudens.GetUpdateCommand(true);

            adapter.Update(dataSet, "Visit");

            mw.LoadVisitor();

            dataGridView1.DataSource = mw.dt;

            panel1.Visible = false;
        }

        private void BtnAddColumns(object sender, EventArgs e)
        {
            label2.Text = "Выполняется добавление пары в таблицу, пожалуйста подождите";
            panel1.Visible = true;

            try
            {
                SqlCommand Command = new SqlCommand(
                    $"ALTER TABLE [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}] ADD Couple{dataGridView1.ColumnCount - 2} NVARCHAR(2) NOT NULL DEFAULT ''",
                    mw.Conn);
                Command.ExecuteNonQuery();
            }
            catch
            {
                panel1.Visible = false;
                MessageBox.Show("Достигнуто максимальное колличество пар!", "Ошика!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
            mw.LoadVisitor();

            dataGridView1.DataSource = mw.dt;
            panel1.Visible = false;
        }
    }
}
