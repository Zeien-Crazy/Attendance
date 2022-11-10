namespace Attendance
{
    partial class MainWindows
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindows));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.buttonAdministration = new System.Windows.Forms.Button();
            this.buttonPastVisit = new System.Windows.Forms.Button();
            this.buttonGrupList = new System.Windows.Forms.Button();
            this.btnVisitor = new System.Windows.Forms.Button();
            this.btnLive = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCloseCgildForm = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.UserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Controls.Add(this.buttonAdministration);
            this.panelMenu.Controls.Add(this.buttonPastVisit);
            this.panelMenu.Controls.Add(this.buttonGrupList);
            this.panelMenu.Controls.Add(this.btnVisitor);
            this.panelMenu.Controls.Add(this.btnLive);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 606);
            this.panelMenu.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(67)))));
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSettings.Image = global::Attendance.Properties.Resources.settings;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 546);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(220, 60);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "      Настройки";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.ButtonSett_Click);
            // 
            // buttonAdministration
            // 
            this.buttonAdministration.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdministration.FlatAppearance.BorderSize = 0;
            this.buttonAdministration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdministration.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdministration.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonAdministration.Image = global::Attendance.Properties.Resources.monarch;
            this.buttonAdministration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdministration.Location = new System.Drawing.Point(0, 320);
            this.buttonAdministration.Name = "buttonAdministration";
            this.buttonAdministration.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonAdministration.Size = new System.Drawing.Size(220, 60);
            this.buttonAdministration.TabIndex = 5;
            this.buttonAdministration.Text = "      Комната Админа";
            this.buttonAdministration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdministration.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdministration.UseVisualStyleBackColor = true;
            this.buttonAdministration.Visible = false;
            this.buttonAdministration.Click += new System.EventHandler(this.ButtonAdministration_Click);
            // 
            // buttonPastVisit
            // 
            this.buttonPastVisit.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPastVisit.FlatAppearance.BorderSize = 0;
            this.buttonPastVisit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPastVisit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPastVisit.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonPastVisit.Image = ((System.Drawing.Image)(resources.GetObject("buttonPastVisit.Image")));
            this.buttonPastVisit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPastVisit.Location = new System.Drawing.Point(0, 260);
            this.buttonPastVisit.Name = "buttonPastVisit";
            this.buttonPastVisit.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonPastVisit.Size = new System.Drawing.Size(220, 60);
            this.buttonPastVisit.TabIndex = 4;
            this.buttonPastVisit.Text = "      История                          Посещений";
            this.buttonPastVisit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPastVisit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPastVisit.UseVisualStyleBackColor = true;
            this.buttonPastVisit.Click += new System.EventHandler(this.ButtonPastVisit_Click);
            // 
            // buttonGrupList
            // 
            this.buttonGrupList.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGrupList.FlatAppearance.BorderSize = 0;
            this.buttonGrupList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGrupList.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGrupList.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonGrupList.Image = global::Attendance.Properties.Resources.icons8_list_view_34px;
            this.buttonGrupList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGrupList.Location = new System.Drawing.Point(0, 200);
            this.buttonGrupList.Name = "buttonGrupList";
            this.buttonGrupList.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonGrupList.Size = new System.Drawing.Size(220, 60);
            this.buttonGrupList.TabIndex = 3;
            this.buttonGrupList.Text = "      Список группы";
            this.buttonGrupList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGrupList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGrupList.UseVisualStyleBackColor = true;
            this.buttonGrupList.Click += new System.EventHandler(this.ButtonGrupList_Click);
            // 
            // btnVisitor
            // 
            this.btnVisitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVisitor.FlatAppearance.BorderSize = 0;
            this.btnVisitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitor.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVisitor.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVisitor.Image = ((System.Drawing.Image)(resources.GetObject("btnVisitor.Image")));
            this.btnVisitor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisitor.Location = new System.Drawing.Point(0, 140);
            this.btnVisitor.Name = "btnVisitor";
            this.btnVisitor.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnVisitor.Size = new System.Drawing.Size(220, 60);
            this.btnVisitor.TabIndex = 2;
            this.btnVisitor.Text = "     Заполнение                    Посещаемости";
            this.btnVisitor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisitor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVisitor.UseVisualStyleBackColor = true;
            this.btnVisitor.Visible = false;
            this.btnVisitor.Click += new System.EventHandler(this.ButtonVisitor_Click);
            // 
            // btnLive
            // 
            this.btnLive.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLive.FlatAppearance.BorderSize = 0;
            this.btnLive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLive.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLive.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLive.Image = global::Attendance.Properties.Resources.liveView;
            this.btnLive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLive.Location = new System.Drawing.Point(0, 80);
            this.btnLive.Name = "btnLive";
            this.btnLive.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLive.Size = new System.Drawing.Size(220, 60);
            this.btnLive.TabIndex = 1;
            this.btnLive.Text = "     Live";
            this.btnLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLive.UseVisualStyleBackColor = true;
            this.btnLive.Click += new System.EventHandler(this.BtnLive_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(85, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(46, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attendance";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.btnMinimize);
            this.panelTitleBar.Controls.Add(this.btnMaximize);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.btnCloseCgildForm);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(864, 80);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindows_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(777, 10);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(21, 21);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.btnMinSizeHoverOff);
            this.btnMinimize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMinSizeHoverOn);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximize.Image")));
            this.btnMaximize.Location = new System.Drawing.Point(804, 10);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(21, 21);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.BtnMaximize_Click);
            this.btnMaximize.MouseLeave += new System.EventHandler(this.btnMaxSizeHoverOff);
            this.btnMaximize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMaxSizeHoverOn);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(831, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 21);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnCloseHoverOff);
            this.btnClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCloseHoverOn);
            // 
            // btnCloseCgildForm
            // 
            this.btnCloseCgildForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseCgildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseCgildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseCgildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseCgildForm.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCloseCgildForm.Location = new System.Drawing.Point(0, 0);
            this.btnCloseCgildForm.Name = "btnCloseCgildForm";
            this.btnCloseCgildForm.Size = new System.Drawing.Size(75, 80);
            this.btnCloseCgildForm.TabIndex = 1;
            this.btnCloseCgildForm.Text = "X";
            this.btnCloseCgildForm.UseVisualStyleBackColor = true;
            this.btnCloseCgildForm.Click += new System.EventHandler(this.BtnCloseCgildForm_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lblTitle.Location = new System.Drawing.Point(393, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(79, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HOME";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.BackColor = System.Drawing.Color.White;
            this.panelDesktopPane.Controls.Add(this.UserName);
            this.panelDesktopPane.Controls.Add(this.label3);
            this.panelDesktopPane.Controls.Add(this.pictureBox2);
            this.panelDesktopPane.Controls.Add(this.label2);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(220, 80);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(864, 526);
            this.panelDesktopPane.TabIndex = 2;
            // 
            // UserName
            // 
            this.UserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserName.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.UserName.Location = new System.Drawing.Point(308, 352);
            this.UserName.Margin = new System.Windows.Forms.Padding(10);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(248, 49);
            this.UserName.TabIndex = 2;
            this.UserName.Text = "f3f";
            this.UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.label3.Location = new System.Drawing.Point(308, 300);
            this.label3.Margin = new System.Windows.Forms.Padding(10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Добро пожаловать";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(365, 93);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bauhaus 93", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.label2.Location = new System.Drawing.Point(336, 241);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Attendance";
            // 
            // MainWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(27)))));
            this.CancelButton = this.btnCloseCgildForm;
            this.ClientSize = new System.Drawing.Size(1084, 606);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance";
            this.Load += new System.EventHandler(this.MainWindows_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktopPane.ResumeLayout(false);
            this.panelDesktopPane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button buttonGrupList;
        private System.Windows.Forms.Button btnVisitor;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Button buttonPastVisit;
        private System.Windows.Forms.Button btnCloseCgildForm;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAdministration;
        private System.Windows.Forms.Button btnSettings;
    }
}