using System;
using System.Windows.Forms;

namespace MBS
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.Main_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslReportDB = new System.Windows.Forms.ToolStripStatusLabel();
            this.slReportDB_ConnSts = new System.Windows.Forms.ToolStripStatusLabel();
            this.Empty1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWinCCAlarm = new System.Windows.Forms.ToolStripStatusLabel();
            this.slWinCCAlarm_ConnSts = new System.Windows.Forms.ToolStripStatusLabel();
            this.Empty3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Empty = new System.Windows.Forms.ToolStripStatusLabel();
            this.lOperation = new System.Windows.Forms.ToolStripStatusLabel();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.Empty2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.User = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.Mode = new System.Windows.Forms.ToolStripStatusLabel();
            this.DateAndTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.Main_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmi_1_Main = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_2_OpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_2_CloseProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_2_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_2_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_1_Reports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_2_Orders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_2_Batchs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_1_Service = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_2_BD = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_3_SetConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_NewBD = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_3_CopyBD = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_2_Users = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_3_AddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_3_EditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_3_Enter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_1_Documentation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_2_UserManual = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_2_AdminManual = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_1_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_2_About = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_1_Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_tsc = new System.Windows.Forms.ToolStripContainer();
            this.scReports = new System.Windows.Forms.SplitContainer();
            this.bDATFiltr_BWD = new System.Windows.Forms.Button();
            this.bDATFiltr_FWD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lDAT_Filtr_End = new System.Windows.Forms.Label();
            this.lDAT_Filtr_Start = new System.Windows.Forms.Label();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Begin = new System.Windows.Forms.DateTimePicker();
            this.rbHour = new System.Windows.Forms.RadioButton();
            this.rbShift = new System.Windows.Forms.RadioButton();
            this.rbPeriod = new System.Windows.Forms.RadioButton();
            this.rbYear = new System.Windows.Forms.RadioButton();
            this.rbHalfYear = new System.Windows.Forms.RadioButton();
            this.rbQuarter = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.rbDay = new System.Windows.Forms.RadioButton();
            this.rbWeek = new System.Windows.Forms.RadioButton();
            this.Technology_lUnit = new System.Windows.Forms.Label();
            this.Main_TabControl = new System.Windows.Forms.TabControl();
            this.tbOrders = new System.Windows.Forms.TabPage();
            this.edgvOrders = new MBS.EDGV();
            this.tbBatchs = new System.Windows.Forms.TabPage();
            this.edgvBatchs = new MBS.EDGV();
            this.tbDosing = new System.Windows.Forms.TabPage();
            this.edgvDosing = new MBS.EDGV();
            this.tbMessages = new System.Windows.Forms.TabPage();
            this.dgvWinCCAlarm = new MBS.WinCCAlarmView();
            this.tbReport = new System.Windows.Forms.TabPage();
            this.Report = new MBS.ReportsControl();
            this.DS = new System.Data.DataSet();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.DA = new System.Data.SqlClient.SqlDataAdapter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Main_StatusStrip.SuspendLayout();
            this.Main_MenuStrip.SuspendLayout();
            this.Main_tsc.BottomToolStripPanel.SuspendLayout();
            this.Main_tsc.ContentPanel.SuspendLayout();
            this.Main_tsc.TopToolStripPanel.SuspendLayout();
            this.Main_tsc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scReports)).BeginInit();
            this.scReports.Panel1.SuspendLayout();
            this.scReports.Panel2.SuspendLayout();
            this.scReports.SuspendLayout();
            this.Main_TabControl.SuspendLayout();
            this.tbOrders.SuspendLayout();
            this.tbBatchs.SuspendLayout();
            this.tbDosing.SuspendLayout();
            this.tbMessages.SuspendLayout();
            this.tbReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_StatusStrip
            // 
            this.Main_StatusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.Main_StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Main_StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslReportDB,
            this.slReportDB_ConnSts,
            this.Empty1,
            this.tsslWinCCAlarm,
            this.slWinCCAlarm_ConnSts,
            this.Empty3,
            this.Empty,
            this.lOperation,
            this.Progress,
            this.Empty2,
            this.tsslUser,
            this.User,
            this.tsslMode,
            this.Mode,
            this.DateAndTime});
            this.Main_StatusStrip.Location = new System.Drawing.Point(0, 0);
            this.Main_StatusStrip.Name = "Main_StatusStrip";
            this.Main_StatusStrip.Size = new System.Drawing.Size(1272, 31);
            this.Main_StatusStrip.TabIndex = 8;
            this.Main_StatusStrip.Text = "MainState";
            // 
            // tsslReportDB
            // 
            this.tsslReportDB.Name = "tsslReportDB";
            this.tsslReportDB.Size = new System.Drawing.Size(68, 26);
            this.tsslReportDB.Text = "БД отчетов";
            // 
            // slReportDB_ConnSts
            // 
            this.slReportDB_ConnSts.BackColor = System.Drawing.SystemColors.Control;
            this.slReportDB_ConnSts.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.slReportDB_ConnSts.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.slReportDB_ConnSts.Name = "slReportDB_ConnSts";
            this.slReportDB_ConnSts.Size = new System.Drawing.Size(20, 26);
            this.slReportDB_ConnSts.Text = "...";
            this.slReportDB_ConnSts.ToolTipText = "Состояние подключения";
            this.slReportDB_ConnSts.Click += new System.EventHandler(this.slReportDB_ConnSts_Click);
            // 
            // Empty1
            // 
            this.Empty1.AutoSize = false;
            this.Empty1.Name = "Empty1";
            this.Empty1.Size = new System.Drawing.Size(50, 26);
            this.Empty1.Text = "   ";
            // 
            // tsslWinCCAlarm
            // 
            this.tsslWinCCAlarm.Name = "tsslWinCCAlarm";
            this.tsslWinCCAlarm.Size = new System.Drawing.Size(75, 26);
            this.tsslWinCCAlarm.Text = "БД Событий";
            // 
            // slWinCCAlarm_ConnSts
            // 
            this.slWinCCAlarm_ConnSts.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.slWinCCAlarm_ConnSts.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.slWinCCAlarm_ConnSts.Name = "slWinCCAlarm_ConnSts";
            this.slWinCCAlarm_ConnSts.Size = new System.Drawing.Size(20, 26);
            this.slWinCCAlarm_ConnSts.Text = "...";
            this.slWinCCAlarm_ConnSts.ToolTipText = "Состояние подключения";
            this.slWinCCAlarm_ConnSts.Click += new System.EventHandler(this.slWinCCAlarm_ConnSts_Click);
            // 
            // Empty3
            // 
            this.Empty3.Name = "Empty3";
            this.Empty3.Size = new System.Drawing.Size(0, 26);
            // 
            // Empty
            // 
            this.Empty.Name = "Empty";
            this.Empty.Size = new System.Drawing.Size(684, 26);
            this.Empty.Spring = true;
            // 
            // lOperation
            // 
            this.lOperation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lOperation.Name = "lOperation";
            this.lOperation.Size = new System.Drawing.Size(16, 26);
            this.lOperation.Text = "...";
            this.lOperation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lOperation.ToolTipText = "Текущая операция";
            // 
            // Progress
            // 
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 25);
            this.Progress.Step = 1;
            // 
            // Empty2
            // 
            this.Empty2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Empty2.Name = "Empty2";
            this.Empty2.Size = new System.Drawing.Size(22, 26);
            this.Empty2.Tag = "";
            this.Empty2.Text = "     ";
            // 
            // tsslUser
            // 
            this.tsslUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslUser.Name = "tsslUser";
            this.tsslUser.Size = new System.Drawing.Size(91, 26);
            this.tsslUser.Text = "Пользователь:";
            // 
            // User
            // 
            this.User.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.User.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(20, 26);
            this.User.Text = "...";
            this.User.ToolTipText = "Пользователь";
            // 
            // tsslMode
            // 
            this.tsslMode.Name = "tsslMode";
            this.tsslMode.Size = new System.Drawing.Size(48, 26);
            this.tsslMode.Text = "Режим:";
            // 
            // Mode
            // 
            this.Mode.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.Mode.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(20, 26);
            this.Mode.Text = "...";
            this.Mode.ToolTipText = "Режим";
            // 
            // DateAndTime
            // 
            this.DateAndTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.DateAndTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.DateAndTime.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.DateAndTime.Name = "DateAndTime";
            this.DateAndTime.Size = new System.Drawing.Size(20, 31);
            this.DateAndTime.Text = "...";
            this.DateAndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Main_MenuStrip
            // 
            this.Main_MenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.Main_MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Main_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_1_Main,
            this.tsmi_1_Reports,
            this.tsmi_1_Service,
            this.tsmi_1_Documentation,
            this.tsmi_1_Help,
            this.tsmi_1_Setting});
            this.Main_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.Main_MenuStrip.Name = "Main_MenuStrip";
            this.Main_MenuStrip.Size = new System.Drawing.Size(1272, 28);
            this.Main_MenuStrip.TabIndex = 4;
            this.Main_MenuStrip.Text = "menuStrip1";
            // 
            // tsmi_1_Main
            // 
            this.tsmi_1_Main.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_2_OpenProject,
            this.tsmi_2_CloseProject,
            this.toolStripSeparator1,
            this.tsmi_2_Login,
            this.tsmi_2_Logout});
            this.tsmi_1_Main.Image = global::MBS.Properties.Resources._1439314419_home;
            this.tsmi_1_Main.Name = "tsmi_1_Main";
            this.tsmi_1_Main.Size = new System.Drawing.Size(73, 24);
            this.tsmi_1_Main.Text = "Меню";
            // 
            // tsmi_2_OpenProject
            // 
            this.tsmi_2_OpenProject.Image = global::MBS.Properties.Resources._1439314019_folder_open;
            this.tsmi_2_OpenProject.Name = "tsmi_2_OpenProject";
            this.tsmi_2_OpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmi_2_OpenProject.Size = new System.Drawing.Size(209, 26);
            this.tsmi_2_OpenProject.Text = "Открыть проект";
            this.tsmi_2_OpenProject.ToolTipText = "Открыть существующий проект";
            this.tsmi_2_OpenProject.Click += new System.EventHandler(this.toolStripMenuItem_OpenProject_Click);
            // 
            // tsmi_2_CloseProject
            // 
            this.tsmi_2_CloseProject.Image = global::MBS.Properties.Resources._1439314340_folder_close;
            this.tsmi_2_CloseProject.Name = "tsmi_2_CloseProject";
            this.tsmi_2_CloseProject.Size = new System.Drawing.Size(209, 26);
            this.tsmi_2_CloseProject.Text = "Закрыть проект";
            this.tsmi_2_CloseProject.ToolTipText = "Закрыть проект";
            this.tsmi_2_CloseProject.Click += new System.EventHandler(this.toolStripMenuItem_CloseProject_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // tsmi_2_Login
            // 
            this.tsmi_2_Login.Image = global::MBS.Properties.Resources._1439314055_login;
            this.tsmi_2_Login.Name = "tsmi_2_Login";
            this.tsmi_2_Login.Size = new System.Drawing.Size(209, 26);
            this.tsmi_2_Login.Text = "Сменить пользователя";
            this.tsmi_2_Login.Click += new System.EventHandler(this.сменитьПользователяToolStripMenuItem_Click);
            // 
            // tsmi_2_Logout
            // 
            this.tsmi_2_Logout.Image = global::MBS.Properties.Resources._1439314064_logout;
            this.tsmi_2_Logout.Name = "tsmi_2_Logout";
            this.tsmi_2_Logout.Size = new System.Drawing.Size(209, 26);
            this.tsmi_2_Logout.Text = "Выйти из системы";
            // 
            // tsmi_1_Reports
            // 
            this.tsmi_1_Reports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_2_Orders,
            this.tsmi_2_Batchs});
            this.tsmi_1_Reports.Name = "tsmi_1_Reports";
            this.tsmi_1_Reports.Size = new System.Drawing.Size(60, 24);
            this.tsmi_1_Reports.Text = "Отчеты";
            // 
            // tsmi_2_Orders
            // 
            this.tsmi_2_Orders.Image = global::MBS.Properties.Resources._1439314741_application_spec;
            this.tsmi_2_Orders.Name = "tsmi_2_Orders";
            this.tsmi_2_Orders.Size = new System.Drawing.Size(117, 22);
            this.tsmi_2_Orders.Text = "Заказы";
            // 
            // tsmi_2_Batchs
            // 
            this.tsmi_2_Batchs.Image = global::MBS.Properties.Resources._1439314706_script;
            this.tsmi_2_Batchs.Name = "tsmi_2_Batchs";
            this.tsmi_2_Batchs.Size = new System.Drawing.Size(117, 22);
            this.tsmi_2_Batchs.Text = "Замесы";
            // 
            // tsmi_1_Service
            // 
            this.tsmi_1_Service.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_2_BD,
            this.tsmi_2_Users});
            this.tsmi_1_Service.Name = "tsmi_1_Service";
            this.tsmi_1_Service.Size = new System.Drawing.Size(59, 24);
            this.tsmi_1_Service.Text = "Сервис";
            // 
            // tsmi_2_BD
            // 
            this.tsmi_2_BD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_3_SetConnection,
            this.tsmi_NewBD,
            this.tsmi_3_CopyBD});
            this.tsmi_2_BD.Image = global::MBS.Properties.Resources._1439314386_cog;
            this.tsmi_2_BD.Name = "tsmi_2_BD";
            this.tsmi_2_BD.Size = new System.Drawing.Size(184, 26);
            this.tsmi_2_BD.Text = "Параметры";
            // 
            // tsmi_3_SetConnection
            // 
            this.tsmi_3_SetConnection.Name = "tsmi_3_SetConnection";
            this.tsmi_3_SetConnection.Size = new System.Drawing.Size(238, 22);
            this.tsmi_3_SetConnection.Text = "Настроить подключение к БД";
            this.tsmi_3_SetConnection.Click += new System.EventHandler(this.toolStripMenuItem_OpenProject_Click);
            // 
            // tsmi_NewBD
            // 
            this.tsmi_NewBD.Name = "tsmi_NewBD";
            this.tsmi_NewBD.Size = new System.Drawing.Size(238, 22);
            this.tsmi_NewBD.Text = "Создать БД";
            this.tsmi_NewBD.Click += new System.EventHandler(this.toolStripMenuItem_NewProject_Click);
            // 
            // tsmi_3_CopyBD
            // 
            this.tsmi_3_CopyBD.Name = "tsmi_3_CopyBD";
            this.tsmi_3_CopyBD.Size = new System.Drawing.Size(238, 22);
            this.tsmi_3_CopyBD.Text = "Создать копию БД";
            this.tsmi_3_CopyBD.Click += new System.EventHandler(this.tsmi_3_CopyBD_Click);
            // 
            // tsmi_2_Users
            // 
            this.tsmi_2_Users.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_3_AddUser,
            this.tsmi_3_EditUser,
            this.tsmi_3_Enter});
            this.tsmi_2_Users.Image = global::MBS.Properties.Resources._1439314044_user;
            this.tsmi_2_Users.Name = "tsmi_2_Users";
            this.tsmi_2_Users.Size = new System.Drawing.Size(184, 26);
            this.tsmi_2_Users.Text = "Пользователи";
            // 
            // tsmi_3_AddUser
            // 
            this.tsmi_3_AddUser.Name = "tsmi_3_AddUser";
            this.tsmi_3_AddUser.Size = new System.Drawing.Size(154, 22);
            this.tsmi_3_AddUser.Text = "Добавить";
            this.tsmi_3_AddUser.Click += new System.EventHandler(this.tsmi_3_AddUser_Click);
            // 
            // tsmi_3_EditUser
            // 
            this.tsmi_3_EditUser.Name = "tsmi_3_EditUser";
            this.tsmi_3_EditUser.Size = new System.Drawing.Size(154, 22);
            this.tsmi_3_EditUser.Text = "Редактировать";
            this.tsmi_3_EditUser.Click += new System.EventHandler(this.tsmi_3_EditUser_Click);
            // 
            // tsmi_3_Enter
            // 
            this.tsmi_3_Enter.Name = "tsmi_3_Enter";
            this.tsmi_3_Enter.Size = new System.Drawing.Size(154, 22);
            this.tsmi_3_Enter.Text = "Войти";
            // 
            // tsmi_1_Documentation
            // 
            this.tsmi_1_Documentation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_2_UserManual,
            this.tsmi_2_AdminManual});
            this.tsmi_1_Documentation.Name = "tsmi_1_Documentation";
            this.tsmi_1_Documentation.Size = new System.Drawing.Size(99, 24);
            this.tsmi_1_Documentation.Text = "Документация";
            // 
            // tsmi_2_UserManual
            // 
            this.tsmi_2_UserManual.Image = global::MBS.Properties.Resources._2000px_PDF_file_icon_svg__1980x2432;
            this.tsmi_2_UserManual.Name = "tsmi_2_UserManual";
            this.tsmi_2_UserManual.Size = new System.Drawing.Size(302, 26);
            this.tsmi_2_UserManual.Text = "Руководство оператора";
            // 
            // tsmi_2_AdminManual
            // 
            this.tsmi_2_AdminManual.Image = global::MBS.Properties.Resources._2000px_PDF_file_icon_svg__1980x2432;
            this.tsmi_2_AdminManual.Name = "tsmi_2_AdminManual";
            this.tsmi_2_AdminManual.Size = new System.Drawing.Size(302, 26);
            this.tsmi_2_AdminManual.Text = "Руководство системного администатора";
            // 
            // tsmi_1_Help
            // 
            this.tsmi_1_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_2_About});
            this.tsmi_1_Help.Name = "tsmi_1_Help";
            this.tsmi_1_Help.Size = new System.Drawing.Size(65, 24);
            this.tsmi_1_Help.Text = "Справка";
            // 
            // tsmi_2_About
            // 
            this.tsmi_2_About.Name = "tsmi_2_About";
            this.tsmi_2_About.Size = new System.Drawing.Size(180, 22);
            this.tsmi_2_About.Text = "О программе";
            this.tsmi_2_About.Click += new System.EventHandler(this.tsmi_2_About_Click);
            // 
            // tsmi_1_Setting
            // 
            this.tsmi_1_Setting.Name = "tsmi_1_Setting";
            this.tsmi_1_Setting.Size = new System.Drawing.Size(78, 24);
            this.tsmi_1_Setting.Text = "Настройка";
            this.tsmi_1_Setting.Click += new System.EventHandler(this.tsmi_1_Setting_Click);
            // 
            // Main_tsc
            // 
            // 
            // Main_tsc.BottomToolStripPanel
            // 
            this.Main_tsc.BottomToolStripPanel.Controls.Add(this.Main_StatusStrip);
            // 
            // Main_tsc.ContentPanel
            // 
            this.Main_tsc.ContentPanel.AutoScroll = true;
            this.Main_tsc.ContentPanel.Controls.Add(this.scReports);
            this.Main_tsc.ContentPanel.Size = new System.Drawing.Size(1272, 634);
            this.Main_tsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_tsc.LeftToolStripPanelVisible = false;
            this.Main_tsc.Location = new System.Drawing.Point(0, 0);
            this.Main_tsc.Name = "Main_tsc";
            this.Main_tsc.RightToolStripPanelVisible = false;
            this.Main_tsc.Size = new System.Drawing.Size(1272, 693);
            this.Main_tsc.TabIndex = 13;
            this.Main_tsc.Text = "toolStripContainer1";
            // 
            // Main_tsc.TopToolStripPanel
            // 
            this.Main_tsc.TopToolStripPanel.Controls.Add(this.Main_MenuStrip);
            this.Main_tsc.TopToolStripPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // scReports
            // 
            this.scReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scReports.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scReports.IsSplitterFixed = true;
            this.scReports.Location = new System.Drawing.Point(0, 0);
            this.scReports.Margin = new System.Windows.Forms.Padding(2);
            this.scReports.Name = "scReports";
            this.scReports.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scReports.Panel1
            // 
            this.scReports.Panel1.Controls.Add(this.bDATFiltr_BWD);
            this.scReports.Panel1.Controls.Add(this.bDATFiltr_FWD);
            this.scReports.Panel1.Controls.Add(this.label1);
            this.scReports.Panel1.Controls.Add(this.lDAT_Filtr_End);
            this.scReports.Panel1.Controls.Add(this.lDAT_Filtr_Start);
            this.scReports.Panel1.Controls.Add(this.dateTimePicker_End);
            this.scReports.Panel1.Controls.Add(this.dateTimePicker_Begin);
            this.scReports.Panel1.Controls.Add(this.rbHour);
            this.scReports.Panel1.Controls.Add(this.rbShift);
            this.scReports.Panel1.Controls.Add(this.rbPeriod);
            this.scReports.Panel1.Controls.Add(this.rbYear);
            this.scReports.Panel1.Controls.Add(this.rbHalfYear);
            this.scReports.Panel1.Controls.Add(this.rbQuarter);
            this.scReports.Panel1.Controls.Add(this.rbMonth);
            this.scReports.Panel1.Controls.Add(this.rbDay);
            this.scReports.Panel1.Controls.Add(this.rbWeek);
            this.scReports.Panel1.Controls.Add(this.Technology_lUnit);
            // 
            // scReports.Panel2
            // 
            this.scReports.Panel2.Controls.Add(this.Main_TabControl);
            this.scReports.Size = new System.Drawing.Size(1272, 634);
            this.scReports.SplitterDistance = 80;
            this.scReports.SplitterWidth = 3;
            this.scReports.TabIndex = 13;
            // 
            // bDATFiltr_BWD
            // 
            this.bDATFiltr_BWD.Location = new System.Drawing.Point(599, 54);
            this.bDATFiltr_BWD.Name = "bDATFiltr_BWD";
            this.bDATFiltr_BWD.Size = new System.Drawing.Size(75, 23);
            this.bDATFiltr_BWD.TabIndex = 24;
            this.bDATFiltr_BWD.Text = "Назад";
            this.bDATFiltr_BWD.UseVisualStyleBackColor = true;
            this.bDATFiltr_BWD.Click += new System.EventHandler(this.bDATFiltr_BWD_Click);
            // 
            // bDATFiltr_FWD
            // 
            this.bDATFiltr_FWD.Location = new System.Drawing.Point(871, 54);
            this.bDATFiltr_FWD.Name = "bDATFiltr_FWD";
            this.bDATFiltr_FWD.Size = new System.Drawing.Size(75, 23);
            this.bDATFiltr_FWD.TabIndex = 23;
            this.bDATFiltr_FWD.Text = "Вперед";
            this.bDATFiltr_FWD.UseVisualStyleBackColor = true;
            this.bDATFiltr_FWD.Click += new System.EventHandler(this.bDATFiltr_FWD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(596, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Выбранный период:";
            // 
            // lDAT_Filtr_End
            // 
            this.lDAT_Filtr_End.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lDAT_Filtr_End.Location = new System.Drawing.Point(786, 30);
            this.lDAT_Filtr_End.Name = "lDAT_Filtr_End";
            this.lDAT_Filtr_End.Size = new System.Drawing.Size(160, 20);
            this.lDAT_Filtr_End.TabIndex = 21;
            // 
            // lDAT_Filtr_Start
            // 
            this.lDAT_Filtr_Start.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lDAT_Filtr_Start.Location = new System.Drawing.Point(599, 30);
            this.lDAT_Filtr_Start.Name = "lDAT_Filtr_Start";
            this.lDAT_Filtr_Start.Size = new System.Drawing.Size(160, 20);
            this.lDAT_Filtr_Start.TabIndex = 20;
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(786, 30);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker_End.TabIndex = 19;
            this.dateTimePicker_End.ValueChanged += new System.EventHandler(this.dateTimePicker_End_ValueChanged);
            // 
            // dateTimePicker_Begin
            // 
            this.dateTimePicker_Begin.Location = new System.Drawing.Point(599, 30);
            this.dateTimePicker_Begin.Name = "dateTimePicker_Begin";
            this.dateTimePicker_Begin.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker_Begin.TabIndex = 18;
            this.dateTimePicker_Begin.ValueChanged += new System.EventHandler(this.dateTimePicker_Begin_ValueChanged);
            // 
            // rbHour
            // 
            this.rbHour.AutoSize = true;
            this.rbHour.Location = new System.Drawing.Point(13, 33);
            this.rbHour.Name = "rbHour";
            this.rbHour.Size = new System.Drawing.Size(45, 17);
            this.rbHour.TabIndex = 17;
            this.rbHour.Text = "Час";
            this.rbHour.UseVisualStyleBackColor = true;
            this.rbHour.CheckedChanged += new System.EventHandler(this.rbDAT_CheckedChanged);
            // 
            // rbShift
            // 
            this.rbShift.AutoSize = true;
            this.rbShift.Location = new System.Drawing.Point(13, 54);
            this.rbShift.Name = "rbShift";
            this.rbShift.Size = new System.Drawing.Size(63, 17);
            this.rbShift.TabIndex = 16;
            this.rbShift.Text = "8 часов";
            this.rbShift.UseVisualStyleBackColor = true;
            this.rbShift.CheckedChanged += new System.EventHandler(this.rbDAT_CheckedChanged);
            // 
            // rbPeriod
            // 
            this.rbPeriod.AutoSize = true;
            this.rbPeriod.Location = new System.Drawing.Point(421, 33);
            this.rbPeriod.Name = "rbPeriod";
            this.rbPeriod.Size = new System.Drawing.Size(77, 17);
            this.rbPeriod.TabIndex = 13;
            this.rbPeriod.Text = "За период";
            this.rbPeriod.UseVisualStyleBackColor = true;
            this.rbPeriod.CheckedChanged += new System.EventHandler(this.rbDAT_CheckedChanged);
            // 
            // rbYear
            // 
            this.rbYear.AutoSize = true;
            this.rbYear.Location = new System.Drawing.Point(321, 54);
            this.rbYear.Name = "rbYear";
            this.rbYear.Size = new System.Drawing.Size(43, 17);
            this.rbYear.TabIndex = 12;
            this.rbYear.Text = "Год";
            this.rbYear.UseVisualStyleBackColor = true;
            this.rbYear.CheckedChanged += new System.EventHandler(this.rbDAT_CheckedChanged);
            // 
            // rbHalfYear
            // 
            this.rbHalfYear.AutoSize = true;
            this.rbHalfYear.Location = new System.Drawing.Point(321, 33);
            this.rbHalfYear.Name = "rbHalfYear";
            this.rbHalfYear.Size = new System.Drawing.Size(68, 17);
            this.rbHalfYear.TabIndex = 11;
            this.rbHalfYear.Text = "Полгода";
            this.rbHalfYear.UseVisualStyleBackColor = true;
            this.rbHalfYear.CheckedChanged += new System.EventHandler(this.rbDAT_CheckedChanged);
            // 
            // rbQuarter
            // 
            this.rbQuarter.AutoSize = true;
            this.rbQuarter.Location = new System.Drawing.Point(207, 54);
            this.rbQuarter.Name = "rbQuarter";
            this.rbQuarter.Size = new System.Drawing.Size(67, 17);
            this.rbQuarter.TabIndex = 10;
            this.rbQuarter.Text = "Квартал";
            this.rbQuarter.UseVisualStyleBackColor = true;
            this.rbQuarter.CheckedChanged += new System.EventHandler(this.rbDAT_CheckedChanged);
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(207, 33);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(58, 17);
            this.rbMonth.TabIndex = 9;
            this.rbMonth.Text = "Месяц";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbDAT_CheckedChanged);
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.Location = new System.Drawing.Point(103, 33);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(52, 17);
            this.rbDay.TabIndex = 8;
            this.rbDay.Text = "День";
            this.rbDay.UseVisualStyleBackColor = true;
            this.rbDay.CheckedChanged += new System.EventHandler(this.rbDAT_CheckedChanged);
            // 
            // rbWeek
            // 
            this.rbWeek.AutoSize = true;
            this.rbWeek.Checked = true;
            this.rbWeek.Location = new System.Drawing.Point(103, 54);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.Size = new System.Drawing.Size(63, 17);
            this.rbWeek.TabIndex = 7;
            this.rbWeek.TabStop = true;
            this.rbWeek.Text = "Неделя";
            this.rbWeek.UseVisualStyleBackColor = true;
            this.rbWeek.CheckedChanged += new System.EventHandler(this.rbDAT_CheckedChanged);
            // 
            // Technology_lUnit
            // 
            this.Technology_lUnit.AutoSize = true;
            this.Technology_lUnit.Location = new System.Drawing.Point(10, 6);
            this.Technology_lUnit.Name = "Technology_lUnit";
            this.Technology_lUnit.Size = new System.Drawing.Size(120, 13);
            this.Technology_lUnit.TabIndex = 5;
            this.Technology_lUnit.Text = "Фильтры по времени:";
            // 
            // Main_TabControl
            // 
            this.Main_TabControl.Controls.Add(this.tbOrders);
            this.Main_TabControl.Controls.Add(this.tbBatchs);
            this.Main_TabControl.Controls.Add(this.tbDosing);
            this.Main_TabControl.Controls.Add(this.tbMessages);
            this.Main_TabControl.Controls.Add(this.tbReport);
            this.Main_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TabControl.Location = new System.Drawing.Point(0, 0);
            this.Main_TabControl.Name = "Main_TabControl";
            this.Main_TabControl.SelectedIndex = 0;
            this.Main_TabControl.Size = new System.Drawing.Size(1272, 551);
            this.Main_TabControl.TabIndex = 12;
            this.Main_TabControl.SelectedIndexChanged += new System.EventHandler(this.Main_TabControl_SelectedIndexChanged);
            this.Main_TabControl.Click += new System.EventHandler(this.Main_TabControl_Click);
            // 
            // tbOrders
            // 
            this.tbOrders.Controls.Add(this.edgvOrders);
            this.tbOrders.Location = new System.Drawing.Point(4, 22);
            this.tbOrders.Name = "tbOrders";
            this.tbOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tbOrders.Size = new System.Drawing.Size(1264, 525);
            this.tbOrders.TabIndex = 0;
            this.tbOrders.Text = "Заказы";
            this.tbOrders.UseVisualStyleBackColor = true;
            // 
            // edgvOrders
            // 
            this.edgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edgvOrders.Location = new System.Drawing.Point(3, 3);
            this.edgvOrders.Margin = new System.Windows.Forms.Padding(4);
            this.edgvOrders.Name = "edgvOrders";
            this.edgvOrders.Size = new System.Drawing.Size(1258, 519);
            this.edgvOrders.TabIndex = 0;
            this.edgvOrders.ExportExcell += new System.EventHandler(this.edgvOrders_ExportExcell);
            this.edgvOrders.ExportHTML += new System.EventHandler(this.edgvOrders_ExportHTML);
            this.edgvOrders.MakeReport += new System.EventHandler(this.edgvOrders_MakeReport);
            // 
            // tbBatchs
            // 
            this.tbBatchs.Controls.Add(this.edgvBatchs);
            this.tbBatchs.Location = new System.Drawing.Point(4, 22);
            this.tbBatchs.Name = "tbBatchs";
            this.tbBatchs.Padding = new System.Windows.Forms.Padding(3);
            this.tbBatchs.Size = new System.Drawing.Size(1264, 525);
            this.tbBatchs.TabIndex = 1;
            this.tbBatchs.Text = "Замесы";
            this.tbBatchs.UseVisualStyleBackColor = true;
            // 
            // edgvBatchs
            // 
            this.edgvBatchs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edgvBatchs.Location = new System.Drawing.Point(3, 3);
            this.edgvBatchs.Name = "edgvBatchs";
            this.edgvBatchs.Size = new System.Drawing.Size(1258, 519);
            this.edgvBatchs.TabIndex = 0;
            this.edgvBatchs.ExportExcell += new System.EventHandler(this.edgvBatchs_ExportExcell);
            this.edgvBatchs.ExportHTML += new System.EventHandler(this.edgvBatchs_ExportHTML);
            this.edgvBatchs.MakeReport += new System.EventHandler(this.edgvBatchs_MakeReport);
            // 
            // tbDosing
            // 
            this.tbDosing.Controls.Add(this.edgvDosing);
            this.tbDosing.Location = new System.Drawing.Point(4, 22);
            this.tbDosing.Name = "tbDosing";
            this.tbDosing.Padding = new System.Windows.Forms.Padding(3);
            this.tbDosing.Size = new System.Drawing.Size(1264, 525);
            this.tbDosing.TabIndex = 3;
            this.tbDosing.Text = "Дозирования";
            this.tbDosing.UseVisualStyleBackColor = true;
            // 
            // edgvDosing
            // 
            this.edgvDosing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edgvDosing.Location = new System.Drawing.Point(3, 3);
            this.edgvDosing.Name = "edgvDosing";
            this.edgvDosing.Size = new System.Drawing.Size(1258, 519);
            this.edgvDosing.TabIndex = 1;
            this.edgvDosing.ExportExcell += new System.EventHandler(this.edgvDosing_ExportExcell);
            this.edgvDosing.ExportHTML += new System.EventHandler(this.edgvDosing_ExportHTML);
            // 
            // tbMessages
            // 
            this.tbMessages.Controls.Add(this.dgvWinCCAlarm);
            this.tbMessages.Location = new System.Drawing.Point(4, 22);
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.Padding = new System.Windows.Forms.Padding(3);
            this.tbMessages.Size = new System.Drawing.Size(1264, 525);
            this.tbMessages.TabIndex = 2;
            this.tbMessages.Text = "События";
            this.tbMessages.UseVisualStyleBackColor = true;
            // 
            // dgvWinCCAlarm
            // 
            this.dgvWinCCAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWinCCAlarm.Location = new System.Drawing.Point(3, 3);
            this.dgvWinCCAlarm.Name = "dgvWinCCAlarm";
            this.dgvWinCCAlarm.Size = new System.Drawing.Size(1258, 519);
            this.dgvWinCCAlarm.TabIndex = 1;
            this.dgvWinCCAlarm.ExportExcell += new System.EventHandler(this.dgvWinCCAlarm_ExportExcell);
            this.dgvWinCCAlarm.ExportHTML += new System.EventHandler(this.dgvWinCCAlarm_ExportHTML);
            // 
            // tbReport
            // 
            this.tbReport.Controls.Add(this.Report);
            this.tbReport.Location = new System.Drawing.Point(4, 22);
            this.tbReport.Name = "tbReport";
            this.tbReport.Padding = new System.Windows.Forms.Padding(3);
            this.tbReport.Size = new System.Drawing.Size(1264, 525);
            this.tbReport.TabIndex = 4;
            this.tbReport.Text = "Отчеты";
            this.tbReport.UseVisualStyleBackColor = true;
            // 
            // Report
            // 
            this.Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Report.Location = new System.Drawing.Point(3, 3);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(1258, 519);
            this.Report.TabIndex = 0;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            // 
            // DA
            // 
            this.DA.DeleteCommand = this.sqlDeleteCommand1;
            this.DA.InsertCommand = this.sqlInsertCommand1;
            this.DA.SelectCommand = this.sqlSelectCommand1;
            this.DA.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 384);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 693);
            this.Controls.Add(this.Main_tsc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMain";
            this.Text = "MBS. Система отчетности о состоянии технологического процесса";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMain_FormClosed);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.Shown += new System.EventHandler(this.formMain_Shown);
            this.Resize += new System.EventHandler(this.formMain_Resize);
            this.Main_StatusStrip.ResumeLayout(false);
            this.Main_StatusStrip.PerformLayout();
            this.Main_MenuStrip.ResumeLayout(false);
            this.Main_MenuStrip.PerformLayout();
            this.Main_tsc.BottomToolStripPanel.ResumeLayout(false);
            this.Main_tsc.BottomToolStripPanel.PerformLayout();
            this.Main_tsc.ContentPanel.ResumeLayout(false);
            this.Main_tsc.TopToolStripPanel.ResumeLayout(false);
            this.Main_tsc.TopToolStripPanel.PerformLayout();
            this.Main_tsc.ResumeLayout(false);
            this.Main_tsc.PerformLayout();
            this.scReports.Panel1.ResumeLayout(false);
            this.scReports.Panel1.PerformLayout();
            this.scReports.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scReports)).EndInit();
            this.scReports.ResumeLayout(false);
            this.Main_TabControl.ResumeLayout(false);
            this.tbOrders.ResumeLayout(false);
            this.tbBatchs.ResumeLayout(false);
            this.tbDosing.ResumeLayout(false);
            this.tbMessages.ResumeLayout(false);
            this.tbReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.StatusStrip Main_StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel slReportDB_ConnSts;
        private System.Windows.Forms.ToolStripStatusLabel User;
        private System.Windows.Forms.ToolStripStatusLabel Mode;
        private System.Windows.Forms.ToolStripMenuItem tsmi_1_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_2_OpenProject;
        private System.Windows.Forms.ToolStripMenuItem tsmi_2_CloseProject;
        private System.Windows.Forms.MenuStrip Main_MenuStrip;
        public System.Windows.Forms.ToolStripProgressBar Progress;
        private System.Windows.Forms.ToolStripStatusLabel tsslReportDB;
        private System.Windows.Forms.ToolStripStatusLabel tsslUser;
        private System.Windows.Forms.ToolStripStatusLabel tsslMode;
        private System.Windows.Forms.ToolStripStatusLabel DateAndTime;
        public System.Windows.Forms.ToolStripStatusLabel lOperation;
        private System.Windows.Forms.ToolStripStatusLabel Empty2;
        private ToolStripStatusLabel Empty1;
        private ToolStripMenuItem tsmi_1_Reports;
        private ToolStripMenuItem tsmi_2_Orders;
        private ToolStripMenuItem tsmi_2_Batchs;
        private ToolStripMenuItem tsmi_1_Service;
        private ToolStripMenuItem tsmi_2_BD;
        private ToolStripMenuItem tsmi_2_Users;
        private ToolStripMenuItem tsmi_3_AddUser;
        private ToolStripMenuItem tsmi_3_EditUser;
        private ToolStripMenuItem tsmi_3_Enter;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmi_2_Login;
        private ToolStripMenuItem tsmi_2_Logout;
        private ToolStripMenuItem tsmi_1_Help;
        private ToolStripMenuItem tsmi_2_About;
        private ToolStripMenuItem tsmi_1_Documentation;
        private ToolStripContainer Main_tsc;
        private System.Data.DataSet DS;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlDataAdapter DA;
        private ToolStripMenuItem tsmi_3_SetConnection;
        private ToolStripMenuItem tsmi_NewBD;
        private ToolStripMenuItem tsmi_3_CopyBD;
        private ToolStripMenuItem tsmi_2_UserManual;
        private ToolStripMenuItem tsmi_2_AdminManual;
        private SplitContainer scReports;
        private Label Technology_lUnit;
        private EDGV edgvOrders;
        private TabControl Main_TabControl;
        private TabPage tbOrders;
        private Splitter splitter1;
        private TabPage tbBatchs;
        private EDGV edgvBatchs;
        private TabPage tbMessages;
        private RadioButton rbMonth;
        private RadioButton rbDay;
        private RadioButton rbWeek;
        private RadioButton rbPeriod;
        private RadioButton rbYear;
        private RadioButton rbHalfYear;
        private RadioButton rbQuarter;
        private RadioButton rbHour;
        private RadioButton rbShift;
        private DateTimePicker dateTimePicker_Begin;
        private DateTimePicker dateTimePicker_End;
        private TabPage tbDosing;
        private EDGV edgvDosing;
        private Label lDAT_Filtr_End;
        private Label lDAT_Filtr_Start;
        private Label label1;
        private Button bDATFiltr_FWD;
        private Button bDATFiltr_BWD;
        private WinCCAlarmView dgvWinCCAlarm;
        private ToolStripStatusLabel tsslWinCCAlarm;
        private ToolStripStatusLabel slWinCCAlarm_ConnSts;
        private ToolStripStatusLabel Empty3;
        private ToolStripStatusLabel Empty;
        private TabPage tbReport;
        private ReportsControl Report;
        private ToolStripMenuItem tsmi_1_Setting;
    }
}

