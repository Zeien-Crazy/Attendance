using LiveCharts.Definitions.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace Attendance.Forms
{
    public partial class FormLive : Form
    {
        MainWindows mw;

        public int TablePos1;
        public int TableNo1;
        public int Tables1;
        private bool pie = false;

        public FormLive(MainWindows mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void FormLive_Load(object sender, EventArgs e)
        {
            LoadTheme();

            TablePos1 = mw.tablePos;
            TableNo1 = mw.tablesNo;
            Tables1 = mw.tables;

            labelPris.Text = TablePos1.ToString();
            labelNo.Text = TableNo1.ToString();
            labelBol.Text = Tables1.ToString();

            PieChart();
            LoadVisition();
        }

        public void PieChart()
        {
            //Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            SeriesCollection piechartData = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Присутствует",
                    Values = new ChartValues<double> {TablePos1},
                    DataLabels = false,
                    //LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Отсутствует",
                    Values = new ChartValues<double> {TableNo1 - Tables1},
                    DataLabels = false,
                    //LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Болеет",
                    Values = new ChartValues<double> {Tables1},
                    DataLabels = false,
                    //LabelPoint = labelPoint
                }
            };

            PieChart1.Series = piechartData;

            //PieChart1.LegendLocation = LegendLocation.Top;
        }

        private void LoadVisition()
        {
            if (pie)
            {
                pie = false;
                PieChart();
            }

            UpdateAsync();
            UpdateAsinc2();
        }

        public async void UpdateAsinc2()
        {
            await Task.Run(() => mw.LoadVisitor());
            await Task.Delay(1000);

            try
            {
                if (dataGridView2.DataSource != mw.dt)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        dataGridView2.DataSource = mw.dt;
                        dataGridView2.AutoSize = true;
                    });
                }
            }
            catch { }
        }

        public async void UpdateAsync()
        {
            await Task.Run(() => mw.LoadLiveVisition());
            await Task.Delay(3000);

            try
            {
                if (TablePos1 != mw.tablePos || Tables1 != mw.tables)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        TablePos1 = mw.tablePos;
                        TableNo1 = mw.tablesNo;
                        Tables1 = mw.tables;

                        labelPris.Text = TablePos1.ToString();
                        labelNo.Text = TableNo1.ToString();
                        labelBol.Text = Tables1.ToString();

                        pie = true;
                    });
                }

                Invoke((MethodInvoker)delegate
                {
                    LoadVisition();
                });
            }
            catch{ }
        }

        private void LoadTheme()
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
                dataGridView2.BackgroundColor = mw.colorLite;

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
                dataGridView2.BackgroundColor = mw.colorDark;

                foreach (Label label in GetControl<Label>(this.Controls).OrderBy(c => c.Name))
                {
                    label.ForeColor = Color.FromArgb(241, 241, 241);
                }
            }

            btnCloseGrid.BackColor = Color.IndianRed;
            btnCloseGrid.ForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.PrimaryColor;

            btnCloseGrid2.BackColor = Color.IndianRed;
            btnCloseGrid2.ForeColor = Color.White;

            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
            dataGridView2.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.PrimaryColor;

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

        private void btnCloseGrid_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnCloseGrid2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void btnPris_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = mw.tablePosGrid;
            panel1.Visible = true;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = mw.tablesNoGrid;
            panel1.Visible = true;
        }

        private void btnBol_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = mw.tablesGrid;
            panel1.Visible = true;
        }

        private void BtnDey_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }
    }
}
