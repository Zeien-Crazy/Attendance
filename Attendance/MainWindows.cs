using Attendance.Forms;
using Attendance.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Windows.Controls;

namespace Attendance
{
    public partial class MainWindows : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm; 

        public string UserGroup;
        public string UserRole;
        public DataTable GroupSet;
        private string Group;
        public SqlConnection Conn = null;


        public DataTable dt;
        public DataTable gl;
        public DataSet visit;

        public SqlDataAdapter dataAdapterPos;

        public Color colorDark = Color.FromArgb(19, 19, 30);
        public Color colorLite = Color.FromArgb(241, 241, 241);

        int CenterBarX;
        int CenterTextX;
        int CenterLblX;

        int CenterBarY;
        int CenterTextY;
        int CenterLblY;

        public int tablePos;
        public int tablesNo;
        public int tables;
        public DataTable tablePosGrid;
        public DataTable tablesNoGrid;
        public DataTable tablesGrid;

        public int Coloum;


        //Constructor
        public MainWindows(Form1 frm1)
        {
            gr = new FormGrupList(this);
            admin = new AdministrationForm(this);
            setting = new FormSettings(this);
            live = new FormLive(this);
            past = new FormPastVisit(this);
            visitor = new VisitorForm(this);
            this.frm1 = frm1;
            InitializeComponent();
            random = new Random();
            btnCloseCgildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public Form1 frm1;
        FormGrupList gr;
        AdministrationForm admin;
        FormSettings setting;
        FormLive live;
        FormPastVisit past;
        VisitorForm visitor;

        //Methods

        public void MainWindows_Load(object sender, EventArgs e)
        {
            LoadForm();

            //LoadGridView();
        }

        public void LoadForm()
        {
            Conn = frm1.Conn;

            UserName.Text = frm1.UserName;
            UserGroup = frm1.UserGroupId;
            UserRole = frm1.UserRole;

            if (UserRole == "Студент" || UserRole == "Админ")
            {
                btnVisitor.Visible = true;
            }
            else
            {
                btnVisitor.Visible = false;
            }

            if (UserRole == "Админ")
            {
                buttonAdministration.Visible = true;
            }
            else
            {
                buttonAdministration.Visible = false;
            }

            string Group1 = "36/2ИСд-20к";
            string Group2 = "20/СА-21к";
            string Group3 = "12ИС-22к";

            if (UserGroup == Group1)
            {
                Group = "Group1";
            }
            else
            if (UserGroup == Group2)
            {
                Group = "Group2";
            }
            else
            if (UserGroup == Group3)
            {
                Group = "Group3";
            }

            CenterTitle();

            Theme();

            LoadLiveVisition();

            LoadVisitor();

            LoadGroupList();

            ShowWindiw();
        }

        public async void ShowWindiw()
        {
            double o;

            for (o = 1.0; o >= 0.0; o -= 0.1, await Task.Delay(30))
            {
                frm1.Opacity = o;
            }
            frm1.Hide();

            for (o = 0.0; o <= 1.0; o += 0.1, await Task.Delay(30))
            {
                this.Opacity = o;
            }
        }

        public void LoadLiveVisition()
        {
            try
            {
                SqlCommand NumColums = new SqlCommand(
                    $"SELECT count(*) FROM sys.columns WHERE object_id = OBJECT_ID(N'[{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}]')",
                    Conn);

                Coloum = Convert.ToInt32(NumColums.ExecuteScalar()) - 1;

                //Pos
                dataAdapterPos = new SqlDataAdapter(
                    $"SELECT [{Group}].LastName AS 'Фамилия', [{Group}].FirstName AS 'Имя' " +
                    $"FROM [{Group}] JOIN [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}] " +
                    $"ON [{Group}].Id = [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Id AND [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple{Coloum} = '+'",
                    frm1.Conn);

                DataSet Pos = new DataSet();

                dataAdapterPos.Fill(Pos);

                tablePos = Pos.Tables[0].Rows.Count;
                tablePosGrid = Pos.Tables[0];
                //

                //No
                SqlDataAdapter dataAdapterNo = new SqlDataAdapter(
                    $"SELECT [{Group}].LastName AS 'Фамилия', [{Group}].FirstName AS 'Имя' " +
                    $"FROM [{Group}] JOIN [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}] " +
                    $"ON [{Group}].Id = [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Id AND [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple{Coloum} != '+' ",
                    Conn);

                DataSet dataSetNo = new DataSet();

                dataAdapterNo.Fill(dataSetNo);

                SqlDataAdapter dataAdapterNoNum = new SqlDataAdapter(
                    $"SELECT Id FROM [{Group}]", Conn);
                DataSet NumNo = new DataSet();

                dataAdapterNoNum.Fill(NumNo);

                tablesNo = NumNo.Tables[0].Rows.Count - tablePos;
                tablesNoGrid = dataSetNo.Tables[0];
                //

                //Bol
                SqlDataAdapter dataAdapter = new SqlDataAdapter(
                    $"SELECT [{Group}].LastName AS 'Фамилия', [{Group}].FirstName AS 'Имя' " +
                    $"FROM [{Group}] JOIN [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}] " +
                    $"ON [{Group}].Id = [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Id AND [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple{Coloum} != '' AND [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple{Coloum} != '+'",
                    Conn);

                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);

                tables = dataSet.Tables[0].Rows.Count;
                tablesGrid = dataSet.Tables[0];
                //
            }
            catch
            {
                tablePos = 0;
                tablesNo = 0;
                tables = 0;
            }
        }

        public void LoadVisitor()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(
                    $"SELECT [{Group}].Id AS '№', [{Group}].LastName AS 'Фамилия', [{Group}].FirstName AS 'Имя', [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple1 AS 'Пара 1', [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple2 AS 'Пара 2', [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple3 AS 'Пара 3', [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple4 AS 'Пара 4' " +
                    $"FROM [{Group}] JOIN [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}] " +
                    $"ON [{Group}].Id = [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Id",
                    Conn);

                visit = new DataSet();

                dataAdapter.Fill(visit);

                dt = visit.Tables[0];
            }
            catch
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(
                        $"SELECT [{Group}].Id AS '№', [{Group}].LastName AS 'Фамилия', [{Group}].FirstName AS 'Имя', [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple1 AS 'Пара 1', [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple2 AS 'Пара 2', [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple3 AS 'Пара 3'" +
                        $"FROM [{Group}] JOIN [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}] " +
                        $"ON [{Group}].Id = [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Id",
                        Conn);

                    visit = new DataSet();

                    dataAdapter.Fill(visit);

                    dt = visit.Tables[0];
                }
                catch
                {
                    try
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(
                            $"SELECT [{Group}].Id AS '№', [{Group}].LastName AS 'Фамилия', [{Group}].FirstName AS 'Имя', [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple1 AS 'Пара 1', [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple2 AS 'Пара 2'" +
                            $"FROM [{Group}] JOIN [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}] " +
                            $"ON [{Group}].Id = [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Id",
                            Conn);

                        visit = new DataSet();

                        dataAdapter.Fill(visit);

                        dt = visit.Tables[0];
                    }
                    catch
                    {
                        try
                        {
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                                $"SELECT [{Group}].Id AS '№', [{Group}].LastName AS 'Фамилия', [{Group}].FirstName AS 'Имя', [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Couple1 AS 'Пара 1'" +
                                $"FROM [{Group}] JOIN [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}] " +
                                $"ON [{Group}].Id = [{Group}_{DateTime.Today.Day}_{DateTime.Today.Month}_{DateTime.Today.Year}].Id",
                                Conn);

                            visit = new DataSet();

                            dataAdapter.Fill(visit);

                            dt = visit.Tables[0];
                        }
                        catch
                        {
                            dt = null;
                        }
                    }
                }
            }

            
        }

        public void LoadGroupList()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                $"SELECT Id AS Номер, LastName AS Фамилия, FirstName AS Имя, MiddleName AS 'Отчество', Birthday AS 'Дата рождения', Phone AS Телефон FROM {Group}",
                Conn);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            gl = dataSet.Tables[0];
        }

        private void CenterTitle()
        {
            CenterBarX = panelTitleBar.Size.Width / 2;
            CenterTextX = lblTitle.Size.Width / 2;
            CenterLblX = CenterBarX - CenterTextX;

            CenterBarY = panelTitleBar.Size.Height / 2;
            CenterTextY = lblTitle.Size.Height / 2;
            CenterLblY = CenterBarY - CenterTextY;

            lblTitle.Location = new Point(CenterLblX, CenterLblY);
        }

        private void Theme()
        {
            if (Properties.Settings.Default.Theme == true)
            {
                this.panelDesktopPane.BackColor = colorLite;
                label2.ForeColor = Color.FromArgb(39, 39, 58);
                label3.ForeColor = Color.FromArgb(39, 39, 58);
                UserName.ForeColor = Color.FromArgb(39, 39, 58);
            }
            else
                if (Properties.Settings.Default.Theme == false)
            {
                this.panelDesktopPane.BackColor = colorDark;
                label2.ForeColor = Color.FromArgb(241, 241, 241);
                label3.ForeColor = Color.FromArgb(241, 241, 241);
                UserName.ForeColor = Color.FromArgb(241, 241, 241);
            }
        }

        public void LoadGridView()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                $"SELECT Id AS Номер, LastName AS Фамилия, FirstName AS Имя, MiddleName AS 'Фамилия', Birthday AS 'Дата рождения', Phone AS Телефон FROM {Group}",
                Conn);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            GroupSet = dataSet.Tables[0];
        }
        
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);

            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }

            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;

                    if (currentButton.Text == "     Заполнение                    Посещаемости")
                    {
                        currentButton.Text = "     Заполнение                   Посещаемости";
                    } else if (currentButton.Text == "      История                          Посещений")
                    {
                        currentButton.Text = "      История                         Посещений";
                    }

                    currentButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.ScondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseCgildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;

                    if (previousBtn.Text == "     Заполнение                   Посещаемости")
                    {
                        previousBtn.Text = "     Заполнение                    Посещаемости";
                    }
                    else if (previousBtn.Text == "      История                         Посещений")
                    {
                        previousBtn.Text = "      История                          Посещений";
                    }

                    previousBtn.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                }
            }
        }

        private void OpenChildForm(Form childForm,string textButton, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lblTitle.Text = textButton;

            CenterBarX = panelTitleBar.Size.Width / 2;
            CenterTextX = lblTitle.Size.Width / 2;
            CenterLblX = CenterBarX - CenterTextX;

            CenterBarY = panelTitleBar.Size.Height / 2;
            CenterTextY = lblTitle.Size.Height / 2;
            CenterLblY = CenterBarY - CenterTextY;

            lblTitle.Location = new Point(CenterLblX, CenterLblY);

        }

        private void BtnLive_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormLive(this), btnLive.Text, sender);
        }

        private void ButtonVisitor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.VisitorForm(this), "Заполнение посещаемости", sender);
        }

        private void ButtonGrupList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormGrupList(this), "Список группы", sender);
        }

        private void ButtonPastVisit_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPastVisit(this), "История посещений", sender);
        }

        private void ButtonAdministration_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AdministrationForm(this), "Комната Админа", sender);
        }

        private void ButtonSett_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSettings(this), "Настройки", sender);
        }

        private void BtnCloseCgildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();
            }

            if (Properties.Settings.Default.Theme == true)
            {
                panelDesktopPane.BackColor = Color.White;
                label2.ForeColor = Color.FromArgb(39, 39, 58);
                label3.ForeColor = Color.FromArgb(39, 39, 58);
                UserName.ForeColor = Color.FromArgb(39, 39, 58);
            }
            else
                if (Properties.Settings.Default.Theme == false)
            {
                panelDesktopPane.BackColor = Color.FromArgb(19, 19, 30);
                label2.ForeColor = Color.FromArgb(241, 241, 241);
                label3.ForeColor = Color.FromArgb(241, 241, 241);
                UserName.ForeColor = Color.FromArgb(241, 241, 241);
            }
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseCgildForm.Visible = false;
        }

        private void MainWindows_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            SqlCommand CommUserStatus = new SqlCommand(
                        $"UPDATE Users SET Status='Offline' WHERE Login = '{frm1.UserLogin}' AND Password = '{frm1.UserPass}'",
                        Conn);

            CommUserStatus.ExecuteNonQuery();

            frm1.Close();
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCloseHoverOn(object sender, MouseEventArgs e)
        {
            btnClose.FlatAppearance.MouseDownBackColor = panelTitleBar.BackColor;
            btnClose.FlatAppearance.MouseOverBackColor = panelTitleBar.BackColor;
            btnClose.Image = Properties.Resources.btnClose2;
        }

        private void btnCloseHoverOff(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.btnClose1;
        }

        private void btnMaxSizeHoverOn(object sender, MouseEventArgs e)
        {
            btnMaximize.FlatAppearance.MouseDownBackColor = panelTitleBar.BackColor;
            btnMaximize.FlatAppearance.MouseOverBackColor = panelTitleBar.BackColor;
            btnMaximize.Image = Properties.Resources.btnMaxSize2;
        }

        private void btnMaxSizeHoverOff(object sender, EventArgs e)
        {
            btnMaximize.Image = Properties.Resources.btnMaxSize1;
        }

        private void btnMinSizeHoverOn(object sender, MouseEventArgs e)
        {
            btnMinimize.FlatAppearance.MouseDownBackColor = panelTitleBar.BackColor;
            btnMinimize.FlatAppearance.MouseOverBackColor = panelTitleBar.BackColor;
            btnMinimize.Image = Properties.Resources.btnMinSize2;
        }

        private void btnMinSizeHoverOff(object sender, EventArgs e)
        {
            btnMinimize.Image = Properties.Resources.btnMinSize1;
        }
    }
}
