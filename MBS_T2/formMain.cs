using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mySecurity;
using System.IO;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;
using System.Diagnostics.Eventing.Reader;
using System.Data.Common;
using Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Drawing.Printing;
using MBS.Properties;
using Microsoft.Reporting.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.CodeDom.Compiler;

namespace MBS
{
    public partial class formMain : Form
    {
        formSelectProject fCreateProject;
        formSetting fSetting;
        formAbout fAbout;
        
        private Timer timer = new Timer();

        DateTime DAT_filt_start = DateTime.Now.AddDays(-10);
        DateTime DAT_filt_end = DateTime.Now;
        public string sDAT_filt_start = "";
        public string sDAT_filt_end = "";
        bool bReportConnOK=false;
        bool bAlarmConnOK = false;


        public formMain()
        {
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);

            if (ProgressControl.bUpdate) { };
            //fCreateProject = new formSelectProject();
            //fCreateProject.Show();
            //this.Hide();
            InitializeComponent();

        }


        private void timer_Tick(object sender, EventArgs e)
        {
            //Статус БД отчетов
            if (bAlarmConnOK)
            {
                this.slReportDB_ConnSts.Text = "ОК";
                //this.slReportDB_ConnSts.BackColor = Color.LightGreen;
            }
            else
            {
                this.slReportDB_ConnSts.Text = "No";
                //this.slReportDB_ConnSts.BackColor = Color.LightCoral;
            }

            //Статус БД событий
            if (bAlarmConnOK)
            {
               this.slWinCCAlarm_ConnSts.Text = "ОК";
               //this.slWinCCAlarm_ConnSts.BackColor = Color.LightGreen;                    
            }
            else
            {
                this.slWinCCAlarm_ConnSts.Text = "Не подключена";
                //this.slWinCCAlarm_ConnSts.BackColor = Color.LightCoral;
            }
            //int red = int.Parse(rgbComponents[0]);


            //Прогресс
            //if (this.Progress.Value == this.Progress.Maximum)
            //{ this.Progress.Value = this.Progress.Minimum; }
            //    this.Progress.Value +=1;


            //Пользователь
            this.User.Text = ProgramSettings.User;
            //Режим
            this.Mode.Text = ProgramSettings.Roles[ProgramSettings.Role];


            //доступность кнопок
            ControlsEnableByRole();

           
            //дата и время
            DateTime DAT = DateTime.Now;
            string sDate = DAT.ToLongDateString() + "   " + DAT.ToLongTimeString();
            this.DateAndTime.Text = sDate;
            TimeFiltr.sDAT_start = sDAT_filt_start;
            TimeFiltr.sDAT_end = sDAT_filt_end;
            TimeFiltr.lDAT_start = this.lDAT_Filtr_Start.Text;
            TimeFiltr.lDAT_end = this.lDAT_Filtr_End.Text;

        }

        //public int ProgressBar()
        //{
        //    this.Operation.Text = ProgressControl.Operation;
        //    this.Progress.ProgressBar.Visible = true;
        //    this.Progress.ProgressBar.Maximum = ProgressControl.Count;
        //    this.Progress.ProgressBar.Value = ProgressControl.Progress;
        //    ProgressControl.bUpdate = false;
        //    return 0;
        //}

        private void toolStripMenuItem_NewProject_Click(object sender, EventArgs e)
        {
            fCreateProject = new formSelectProject();
            fCreateProject.tabControl_SelectProject.SelectedIndex = 1;
            fCreateProject.ShowDialog();
        }
        private void toolStripMenuItem_OpenProject_Click(object sender, EventArgs e)
        {
            fCreateProject = new formSelectProject();
            fCreateProject.tabControl_SelectProject.SelectedIndex = 0;
            fCreateProject.ShowDialog();
        }
        private void toolStripMenuItem_CloseProject_Click(object sender, EventArgs e)
        {
            SQLControls.CloseDB();
        }
        private void tsmi_1_Setting_Click(object sender, EventArgs e)
        {
            fSetting = new formSetting();
            fSetting.ShowDialog();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            #if DEBUG
                General.Login("Adm", "Adm");
#else
                mySecurity.LoginDialog fLoginDialog = new mySecurity.LoginDialog();
                fLoginDialog.Owner = this;

                if (fLoginDialog.ShowDialog() == DialogResult.OK)
                {
                    ProgramSettings.User = fLoginDialog.User;
                    if  (ProgramSettings.User=="" )  ProgramSettings.User="Не авторизован";
                    ProgramSettings.Role = fLoginDialog.Role;

                }
                else
                {
                    ProgramSettings.User = "Не авторизован";
                    ProgramSettings.Role = 0;
                }
#endif


            

            //fCreateProject = new formSelectProject();
            //fCreateProject.Owner = this;
            //fCreateProject.ShowDialog();

            //Проверка состояний подключения к БД отчетов
            bReportConnOK = SQLControls.CheckPropertyConnStr("Report");
            if (bReportConnOK)
            {
                DAT_filt_end = DateTime.Today;
                SetTimeFiltr();

                edgvOrders.SqlConnStr = Properties.Settings.Default.ReportConnectionString;
                edgvOrders.TableName = "Order";
                edgvOrders.Request =  FiltredRequest("Order");
                //Object_EDGV.EditButtonEnabled = false;
                edgvOrders.LoadTable();

                edgvBatchs.SqlConnStr = Properties.Settings.Default.ReportConnectionString;
                edgvBatchs.TableName = "Batch";
                edgvBatchs.Request = FiltredRequest("Batch");
                //Object_EDGV.EditButtonEnabled = false;
                edgvBatchs.LoadTable();

                edgvDosing.SqlConnStr = Properties.Settings.Default.ReportConnectionString;
                edgvDosing.TableName = "Dosing";
                edgvDosing.Request = FiltredRequest("Dosing");
                //Object_EDGV.EditButtonEnabled = false;
                edgvDosing.LoadTable();



                //Report.tblOrder = "View_Orders";
                //Report.RequestOrder = FiltredRequest("View_Orders");
                //Object_EDGV.EditButtonEnabled = false;
                //Report.SqlConn = new SqlConnection(Properties.Settings.Default.ReportConnectionString);
                Report.SqlConnStr = Properties.Settings.Default.ReportConnectionString;
                Report.RequestOrder = FiltredRequest("Order");
                Report.LoadTables();
            }

            //Проверка состояний подключения к БД событий
            bAlarmConnOK = SQLControls.CheckPropertyConnStr("Alarm");
            if (bAlarmConnOK)
            {
                //считываем данные и формируем таблицу
                dgvWinCCAlarm.SqlConn= new SqlConnection(Properties.Settings.Default.AlarmConnectionString);
                dgvWinCCAlarm.TableName = "View_Alarm";
                dgvWinCCAlarm.Request = FiltredRequest("View_Alarm");
                dgvWinCCAlarm.LoadTable();
            }

        }

        private void formMain_Load(object sender, EventArgs e)
        {
           // this.zerolbl.Padding = new Padding((int)(this.Size.Width - 1210), 0, 0, 0);
           this.Progress.Maximum=10;
           this.Progress.Minimum = 0;
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            //MessageBox.Show("this.MAIN.Width=" + this.Width);
            // this.zerolbl.Padding = new Padding((int)(this.Size.Width - 1210), 0, 0, 0);
            //this.zerolbl.Padding = new Padding((int)(this.Size.Width
            //    - this.tsslDataSource.Width - this.DataSource.Width - this.tsslDataBase.Width - this.DataBase.Width
            //    - this.tsslState.Width - this.State.Width - -this.Operation.Width - this.Progress.Width
            //    - this.tsslMode.Width - this.Mode.Width - this.tsslUser.Width - this.User.Width - this.DateAndTime.Width -30), 0, 0, 0);
                
                
        }      

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SQLControls.CloseDB();
        }

        private void tsmi_3_AddUser_Click(object sender, EventArgs e)
        {
            Form fAddUserDialog = new mySecurity.AddUserDialog();
            fAddUserDialog.Owner = this;
            if (fAddUserDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("DialogResult.ОК");
            }


        }

        private void tsmi_3_EditUser_Click(object sender, EventArgs e)
        {
            Form fViewUsersDialog = new mySecurity.ViewUsersDialog();
            fViewUsersDialog.Owner = this;
            fViewUsersDialog.ShowDialog();
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mySecurity.LoginDialog fLoginDialog = new mySecurity.LoginDialog();
            fLoginDialog.Owner = this;
            if (fLoginDialog.ShowDialog() == DialogResult.OK)
            {
                ProgramSettings.User = fLoginDialog.User;
                ProgramSettings.Role = fLoginDialog.Role;
            }
            ControlsEnableByRole();
        }


        private void Main_TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            edgvOrders.TableName = "Order";
            edgvBatchs.TableName = "Batch";
            edgvDosing.TableName = "Dosing";


            if (this.Main_TabControl.SelectedIndex <= 3)
                UpdateTechnologyTabControl();
        }

        private void UpdateTechnologyTabControl() 
        {

            try
            {
                //string[] sTables = { "View_Orders", "View_Batch", "View_Dosing" };
                List<EDGV> lEDGV = new List<EDGV> { edgvOrders, edgvBatchs, edgvDosing};
                if (this.Main_TabControl.SelectedIndex <= 2)            //    if (this.Main_TabControl.SelectedIndex <= sTables.Length-1)
                {

                    //EDGV TestEDGV = lEDGV.Where(i => i.TableName == sTables[this.Main_TabControl.SelectedIndex]).First();
                    EDGV EDGV = lEDGV.ElementAt(this.Main_TabControl.SelectedIndex);
                    EDGV.Request = FiltredRequest(EDGV.TableName);
                    EDGV.UpdateTable();
                }
                if (this.Main_TabControl.SelectedIndex == 3)
                   { dgvWinCCAlarm.Request = FiltredRequest(dgvWinCCAlarm.TableName);
                    dgvWinCCAlarm.UpdateTable();
                }
                if (this.Main_TabControl.SelectedIndex == 4)
                {
                    Report.RequestOrder = FiltredRequest("Order");
                    Report.UpdateTable("Order");
                }

                
                //MessageBox.Show("UpdateTechnologyTabControl");
            }

            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }
        }

        private string FiltredRequest(string TableName)
        {
            string Request="", Condition = "";
            try
            {
                if ((this.lDAT_Filtr_Start.Text != "" & this.lDAT_Filtr_End.Text != "") )
                {
                    switch (TableName)
                    {
                        case "Order":
                            if (sDAT_filt_start == sDAT_filt_end)
                                Condition = " WHERE ((CONVERT(date,[DAT_Create]) = '" + sDAT_filt_start + "') OR (CONVERT(date,[DAT_End]) = '" + sDAT_filt_start + "'))";
                            else
                                Condition = " WHERE (([DAT_Create] >= '" + sDAT_filt_start + "' AND [DAT_Create] <= '" + sDAT_filt_end + "') OR " +
                                        " ([DAT_End] >= '" + sDAT_filt_start + "' AND [DAT_End] <= '" + sDAT_filt_end + "'))";
                            break;
                        case "Batch":
                            if (sDAT_filt_start == sDAT_filt_end)
                                Condition = " WHERE ((CONVERT(date,[DAT_Start_Dosing]) = '" + sDAT_filt_start + "') OR (CONVERT(date,[DAT_End]) = '" + sDAT_filt_start + "'))";
                            else
                                Condition = " WHERE (([DAT_Start_Dosing] >= '" + sDAT_filt_start + "' AND [DAT_Start_Dosing] <= '" + sDAT_filt_end + "') OR " +
                                        " ([DAT_End] >= '" + sDAT_filt_start + "' AND [DAT_End] <= '" + sDAT_filt_end + "'))";
                            break;
                        case "Dosing":
                            if (sDAT_filt_start == sDAT_filt_end)
                                Condition = " WHERE ((CONVERT(date,[DAT_Start] )= '" + sDAT_filt_start + "') OR (CONVERT(date,[DAT_End] = '" + sDAT_filt_start + "'))";
                            else
                                Condition = " WHERE ([DAT_End] >= '" + sDAT_filt_start + "' AND [DAT_End] <= '" + sDAT_filt_end + "')";
                            break;
                        case "View_Alarm":
                            if (sDAT_filt_start == sDAT_filt_end)
                                Condition = " WHERE (CONVERT(date,([Time_ms]/1000000))= '" + sDAT_filt_start + "')";
                            else
                                Condition = " WHERE (CONVERT(datetime,([Time_ms]/1000000)) >= '" + sDAT_filt_start + "' AND CONVERT(datetime,([Time_ms]/1000000)) <= '" + sDAT_filt_end + "')";
                            break;

                        default:
                            Condition = "";
                            break;
                    }
                }
                else Condition = "";

                switch (TableName)
                {
                    case "Order":
                        //Request = "EXECUTE [MBS2].[dbo].[Order_Select] '" + sDAT_filt_start + "', '" + sDAT_filt_end + "'";
                        Request = SQLControls.GetReguest("Order").Replace("@BD","MBS2").Replace("@DAT_Start", sDAT_filt_start).Replace("@DAT_End", sDAT_filt_end);//
                        //  Request = "SELECT[ID]" +
                        //",[Sts] As  'Состояние'" +
                        //",[DAT_Create] As  'Заказ создан'" +
                        //",[DAT_Start] As  'Заказ запущен'" +
                        //",[DAT_End] As  'Заказ завершен'" +
                        //",[Recipe] As  'Рецепт'" +
                        //",[RecipeLabel] As  'Наименование'" +
                        //",[BacthSet] As  'Задано замесов'" +
                        //",[BacthDone] As  'Выполнено замесов'" +
                        //",[VolumeSet] As  'Заданный вес (кг)'" +
                        //",[VolumeDone] As  'Полученный вес (кг)'" +
                        //",[Line] As  'Линия'" +
                        //",[UnloadPlace] As  'Место выгрузки'" +
                        //",[FullTime_h] As  'Длительность выполнения (час)'" +
                        //",[Operator] As  'Оператор'" +
                        //" FROM [MBS2].[dbo].[View_Orders]" +
                        // Condition;
                        break;
                    case "Batch":
                        //Request = "SELECT  [ID]" +
                        //  ",[OrderID] As  'Заказ'" +
                        //  ",[BacthN] As  'Номер замеса в заказе'" +
                        //  ",[Sts] As  'Состояние'" +
                        //  ",[DAT_Start_Dosing] As  'Начало дозирования'" +
                        //  ",[DAT_Start_Mixing] As  'Начало домешивания'" +
                        //  ",[DAT_Start_Unload] As  'Начало выгрузки'" +
                        //  ",[DAT_End] As  'Завершение замеса'" +
                        //  ",[WeightSet_kg] As  'Заданный вес (кг)'" +
                        //  ",[WeightDone_kg] As  'Полученный вес (кг)'" +
                        //  ",[WeightDiff_kg] As 'Разница (кг)'" +
                        //  ",[WeightDiff_prc] As 'Разница (%)'" +
                        //  ",[PLCMixingTime_s] As  'Длительность смешивание (сек)'" +
                        //  ",[DosingTime_s] As  'Длительность дозирования (сек)'" +
                        //  ",[MixingTime_s] As  'Длительность смешивания (сек)'" +
                        //  ",[UnloadTime_s] As  'Длительность выгрузки (сек)'" +
                        //  ",[Operator] As  'Оператор'" +
                        //  " FROM [MBS2].[dbo].[View_Batch]" +
                        //  Condition;
                            Request = SQLControls.GetReguest("Batch").Replace("@BD", "MBS2").Replace("@DAT_Start", sDAT_filt_start).Replace("@DAT_End", sDAT_filt_end);
                        break;
                    case "Dosing":
                        //Request = "SELECT[ID]" +
                        //    ",[SilosType] AS 'Тип силоса'" +
                        //    ",[SRC] As 'Управление'" +
                        //    ",[Sts] AS 'Состояние'" +
                        //    ",[DAT_Start] As 'Начало дозирования'" +
                        //    ",[DAT_End]  As 'Завершение дозирования'" +
                        //    ",[BatchID] As 'Замес'" +
                        //    ",[BacthStep]  As 'Шаг замеса'" +
                        //    ",[BacthRank] As 'Ранг замеса'" +
                        //    ",[SilosN] As 'Номер силоса'" +
                        //    ",[SilosLabel] As 'Наименование'" +
                        //    ",[WeightSet] As 'Заданный вес (кг)'" +
                        //    ",[WeightDose]  As 'Полученный вес (кг)'" +
                        //    ",[WeightDiff_kg] As 'Разница (кг)'" +
                        //    ",[WeightDiff_prc] As 'Разница (%)'" +
                        //    ",[DOSING_TIME_s] As 'Длительность дозирования (сек)'" +
                        //    ",[Operator] As 'Оператор'" +
                        //    "FROM [MBS2].[dbo].[View_Dosing] " +
                        //    Condition;
                            Request = SQLControls.GetReguest("Dosing").Replace("@BD", "MBS2").Replace("@DAT_Start", sDAT_filt_start).Replace("@DAT_End", sDAT_filt_end);
                        break;
                    case "View_Alarm":
                        Request = "SELECT  " +//[MsgNumber] AS ID,
                                    "CONVERT(datetime,([Time_ms]/1000000)) AS 'Дата и время'" +
                                  ",CONVERT(varchar(30),[MsgClass]) as Категория " +
                                  ",CONVERT(varchar(50),[StateAfter]) as Состояние" +
                                  ",[Var1] as Узел" +
                                  ",[Var2] as Объект" +
                                  ",[Var3]" +
                                  ",[Var4]" +
                                  ",[Var5]" +
                                  ",[MsgText] as Событие" +
                                  ",[Var6] as Пользователь" +
                                  ",[TimeString]" +
                              "FROM [MBS2_Alarm].[dbo].[Alarm_log_10]" +
                            Condition
                            + "ORDER BY CONVERT(datetime,([Time_ms]/1000000)) DESC";
                        break;
                    default:
                        Request = "select  *  View_Orders";
                        break;
                }
                //MessageBox.Show(Condition);
                return Request;
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return "select * from View_Orders";
            }
        }

        private void tsmi_2_About_Click(object sender, EventArgs e)
        {
            fAbout = new formAbout();
            fAbout.ShowDialog();
        }

        private void tsmi_3_CopyBD_Click(object sender, EventArgs e)
        {

        }

        private void ControlsEnableByRole()
        {
            this.edgvBatchs.EnableEdit = (ProgramSettings.Role >= 4);
            this.edgvOrders.EnableEdit = (ProgramSettings.Role >= 4);
            this.edgvDosing.EnableEdit = (ProgramSettings.Role >= 4);
            if (ProgramSettings.Role >= 4)
            {
                //this.tsmi_3_SetConnection.Enabled = true;
                this.tsmi_NewBD.Enabled = true;
                this.tsmi_3_CopyBD.Enabled = true;
                this.tsmi_2_Users.Enabled = true;
                this.tsmi_3_AddUser.Enabled = true;
                this.tsmi_3_EditUser.Enabled = true;
            }
            else
            {
                // this.tsmi_3_SetConnection.Enabled = false;
                this.tsmi_NewBD.Enabled = false;
                this.tsmi_3_CopyBD.Enabled = false;
                this.tsmi_2_Users.Enabled = false;
                this.tsmi_3_AddUser.Enabled = false;
                this.tsmi_3_EditUser.Enabled = false;
            }
        }
        private void SetTimeFiltr()
        {

            RadioButton rbTimeFiltr = this.scReports.Panel1.Controls.OfType<RadioButton>()
                       .Where(x => x.Checked).FirstOrDefault();

            System.TimeSpan diffTime= TimeSpan.FromDays(10);
                if (rbTimeFiltr != null)
                {
                    switch (rbTimeFiltr.Name)
                    {
                    case "rbHour":
                        diffTime = TimeSpan.FromHours(1);
                        break;
                    case "rbShift":
                        diffTime = TimeSpan.FromHours(8);
                        break;
                    case "rbDay":
                        diffTime = new System.TimeSpan(23, 59, 59);
                        break;
                    case "rbWeek":
                        diffTime = TimeSpan.FromDays(7);
                        break;
                    case "rbMonth":
                        diffTime = TimeSpan.FromDays(30);
                        break;
                    case "rbQuarter":
                        diffTime = TimeSpan.FromDays(90);
                        break;
                    case "rbHalfYear":
                        diffTime = TimeSpan.FromDays(183);
                        break;
                    case "rbYear":
                        diffTime = TimeSpan.FromDays(365);
                        break;
                    default:
                        diffTime = TimeSpan.FromDays(10);
                        break;
                    }

                switch (rbTimeFiltr.Name)
                {
                    case "rbHour":
                    case "rbShift":
                        DAT_filt_start = DAT_filt_end.Subtract(diffTime);
                        this.lDAT_Filtr_Start.Text = DAT_filt_start.ToLongDateString() + " " + DAT_filt_start.ToLongTimeString();
                        this.lDAT_Filtr_End.Text = DAT_filt_end.ToLongDateString() + " " + DAT_filt_end.ToLongTimeString();
                        this.sDAT_filt_start = DAT_filt_start.ToString("yyyy-MM-dd HH:mm:ss");
                        this.sDAT_filt_end = DAT_filt_end.ToString("yyyy-MM-dd HH:mm:ss");
                        dateTimePicker_Begin.Visible = false;
                        dateTimePicker_End.Visible = false;
                        this.lDAT_Filtr_Start.Visible = true;
                        this.lDAT_Filtr_End.Visible = true;
                        bDATFiltr_FWD.Visible = true;
                        bDATFiltr_BWD.Visible = true;
                        break;
                    case "rbDay":
                        DAT_filt_end = DAT_filt_end + diffTime;
                        DAT_filt_start = DAT_filt_end - diffTime;
                        this.lDAT_Filtr_Start.Text = DAT_filt_start.ToLongDateString() + " " + DAT_filt_start.ToLongTimeString();
                        this.lDAT_Filtr_End.Text = DAT_filt_end.ToLongDateString() + " " + DAT_filt_end.ToLongTimeString();
                        this.sDAT_filt_start = DAT_filt_start.ToString("yyyy-MM-dd HH:mm:ss");
                        this.sDAT_filt_end = DAT_filt_end.ToString("yyyy-MM-dd HH:mm:ss");
                        dateTimePicker_Begin.Visible = false;
                        dateTimePicker_End.Visible = false;
                        this.lDAT_Filtr_Start.Visible = true;
                        this.lDAT_Filtr_End.Visible = true;
                        bDATFiltr_FWD.Visible = true;
                        bDATFiltr_BWD.Visible = true;
                        break;
                    case "rbWeek":
                    case "rbMonth":
                    case "rbQuarter":
                    case "rbHalfYear":
                    case "rbYear":
                        DAT_filt_start = DAT_filt_end.Subtract(diffTime);
                        this.lDAT_Filtr_Start.Text = DAT_filt_start.ToLongDateString();
                        this.lDAT_Filtr_End.Text = DAT_filt_end.ToLongDateString();
                        this.sDAT_filt_start = DAT_filt_start.ToString("yyyy-MM-dd");
                        this.sDAT_filt_end = DAT_filt_end.ToString("yyyy-MM-dd");
                        dateTimePicker_Begin.Visible = false;
                        dateTimePicker_End.Visible = false;
                        this.lDAT_Filtr_Start.Visible = true;
                        this.lDAT_Filtr_End.Visible = true;
                        bDATFiltr_FWD.Visible = true;
                        bDATFiltr_BWD.Visible = true;
                        break;
                    case "rbPeriod":
                        DAT_filt_start = dateTimePicker_Begin.Value;
                        DAT_filt_end = dateTimePicker_End.Value;
                        this.sDAT_filt_start = dateTimePicker_Begin.Value.ToString("yyyy-MM-dd");
                        this.sDAT_filt_end = dateTimePicker_End.Value.ToString("yyyy-MM-dd");
                        this.lDAT_Filtr_Start.Text = DAT_filt_start.ToLongDateString();
                        this.lDAT_Filtr_End.Text = DAT_filt_end.ToLongDateString();
                        dateTimePicker_Begin.Visible = true;
                        dateTimePicker_End.Visible = true;
                        bDATFiltr_FWD.Visible = false;
                        bDATFiltr_BWD.Visible = false;
                        this.lDAT_Filtr_Start.Visible = false;
                        this.lDAT_Filtr_End.Visible = false;
                        break;
                    case "rbAll":
                        this.sDAT_filt_start = "";
                        this.sDAT_filt_end = "";
                        this.lDAT_Filtr_Start.Text = "";
                        this.lDAT_Filtr_End.Text = "";
                        dateTimePicker_Begin.Visible = false;
                        dateTimePicker_End.Visible = false;
                        bDATFiltr_FWD.Visible = false;
                        bDATFiltr_BWD.Visible = false;
                        this.lDAT_Filtr_Start.Visible = true;
                        this.lDAT_Filtr_End.Visible = true;
                        break;
                    default:
                        DAT_filt_start = DateTime.Now.AddDays(-10);
                        DAT_filt_end = DateTime.Now;
                        this.lDAT_Filtr_Start.Text = DAT_filt_start.ToLongDateString();
                        this.lDAT_Filtr_End.Text = DAT_filt_end.ToLongDateString();
                        this.sDAT_filt_start = DAT_filt_start.ToString("yyyy-MM-dd");
                        this.sDAT_filt_end = DAT_filt_end.ToString("yyyy-MM-dd");
                        dateTimePicker_Begin.Visible = false;
                        dateTimePicker_End.Visible = false;
                        this.lDAT_Filtr_Start.Visible = true;
                        this.lDAT_Filtr_End.Visible = true;
                        bDATFiltr_FWD.Visible = true;
                        bDATFiltr_BWD.Visible = true;
                        break;
                }
                //MessageBox.Show("SetTimeFiltr");

            }
            
        }
        private void rbDAT_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbDAT = (sender as RadioButton);
            if (rbDAT.Checked)
            {
                if (sender.Equals(this.rbHour) | sender.Equals(this.rbShift))
                { DAT_filt_end = DateTime.Now;
                    SetTimeFiltr();
                    UpdateTechnologyTabControl(); }
                else if (sender.Equals(this.rbDay) | sender.Equals(this.rbWeek) | sender.Equals(this.rbMonth) | sender.Equals(this.rbQuarter) |
                    sender.Equals(this.rbHalfYear) | sender.Equals(this.rbYear))
      {              DAT_filt_end = DateTime.Today;
                SetTimeFiltr();
                    UpdateTechnologyTabControl();
                }
                else if (sender.Equals(this.rbPeriod))
                {
                    dateTimePicker_Begin.Value = DAT_filt_start;
                    dateTimePicker_End.Value = DAT_filt_end;
                }
                else
                {
                }
                //SetTimeFiltr();
                //UpdateTechnologyTabControl();
            }

        }


        private void dateTimePicker_Begin_ValueChanged(object sender, EventArgs e)
        {
            //DAT_filt_start = dateTimePicker_Begin.Value;
            //this.sDAT_filt_start = dateTimePicker_Begin.Value.ToString("yyyy-MM-dd");
            //this.sDAT_filt_end = dateTimePicker_End.Value.ToString("yyyy-MM-dd");
            //this.lDAT_Filtr_Start.Text = DAT_filt_start.ToLongDateString();
            //this.lDAT_Filtr_End.Text = DAT_filt_end.ToLongDateString();
            //UpdateTechnologyTabControl();
            SetTimeFiltr();
            UpdateTechnologyTabControl();
        }

        private void dateTimePicker_End_ValueChanged(object sender, EventArgs e)
        {
            //DAT_filt_end = dateTimePicker_End.Value;
            //this.sDAT_filt_start = dateTimePicker_Begin.Value.ToString("yyyy-MM-dd");
            //this.sDAT_filt_end = dateTimePicker_End.Value.ToString("yyyy-MM-dd");
            //this.lDAT_Filtr_Start.Text = DAT_filt_start.ToLongDateString();
            //this.lDAT_Filtr_End.Text = DAT_filt_end.ToLongDateString();
            //UpdateTechnologyTabControl();
            SetTimeFiltr();
            UpdateTechnologyTabControl();
        }

        private void bDATFiltr_FWD_Click(object sender, EventArgs e)
        {
            System.TimeSpan diffTime = DAT_filt_end.Subtract(DAT_filt_start);
            DateTime tempDATEnd;
            if (this.rbDay.Checked) tempDATEnd = DAT_filt_end.Date.AddDays(1);
            else tempDATEnd = DAT_filt_end.Subtract(-diffTime);

            if (tempDATEnd > DateTime.Now)
            {
                if (this.rbHour.Checked | this.rbShift.Checked) DAT_filt_end = DateTime.Now;
                else DAT_filt_end = DateTime.Today;
            } 
            else DAT_filt_end = tempDATEnd;
            SetTimeFiltr();
            UpdateTechnologyTabControl();
        }

        private void bDATFiltr_BWD_Click(object sender, EventArgs e)
        {
            System.TimeSpan diffTime = DAT_filt_end.Subtract(DAT_filt_start);
            if (this.rbDay.Checked) { DAT_filt_end = DAT_filt_end.Date.AddDays(-1); }
            else { DAT_filt_end = DAT_filt_end.Subtract(diffTime); }

            SetTimeFiltr();
            UpdateTechnologyTabControl();
        }

        private void dgvWinCCAlarm_ExportExcell(object sender, EventArgs e)
        {
            string sFileName = "События " + this.sDAT_filt_start + "-" + this.sDAT_filt_end;
            DGV_to_CSV(sFileName, this.dgvWinCCAlarm.DGV);
            CSV_to_Excel(sFileName);
        }

        private void edgvDosing_ExportExcell(object sender, EventArgs e)
        {
            string sFileName = "Дозирования " + this.sDAT_filt_start + "-" + this.sDAT_filt_end;
            //if(this.edgvDosing.DGV.f)
            DGV_to_CSV(sFileName, this.edgvDosing.DGV);
            CSV_to_Excel(sFileName);
        }

        private void edgvBatchs_ExportExcell(object sender, EventArgs e)
        {
            string sFileName = "Замесы " + this.sDAT_filt_start + "-" + this.sDAT_filt_end;
            DGV_to_CSV(sFileName, this.edgvBatchs.DGV);
            CSV_to_Excel(sFileName);
        }

        private void edgvOrders_ExportExcell(object sender, EventArgs e)
        {
            string sFileName = "Заказы " + this.sDAT_filt_start + "-" + this.sDAT_filt_end;
            DGV_to_CSV(sFileName, this.edgvOrders.DGV);
            CSV_to_Excel(sFileName);
        }

        private void dgvWinCCAlarm_ExportHTML(object sender, EventArgs e)
        {
            string sFilePatch = General.GetFilePatch();
            if (sFilePatch != "")
            {
                this.lOperation.Text = "Выполняется экспорт данных в HTML...";
                string sFileName = sFilePatch + "\\События ";// + this.sDAT_filt_start + " - " + this.sDAT_filt_end + ".html";
                SaveToHtml(this.dgvWinCCAlarm.DGV, sFileName);
            }                      
        }

        private void edgvOrders_ExportHTML(object sender, EventArgs e)
        {
            string sFileName = Properties.Settings.Default.ReportPatch + "Заказы " + this.sDAT_filt_start + "-" + this.sDAT_filt_end + ".html";
            SaveToHtml(this.edgvOrders.DGV, sFileName);
        }

        private void edgvBatchs_ExportHTML(object sender, EventArgs e)
        {
            string sFileName = Properties.Settings.Default.ReportPatch + "Замесы " + this.sDAT_filt_start + "-" + this.sDAT_filt_end + ".html";
            SaveToHtml(this.edgvBatchs.DGV, sFileName);
        }

        private void edgvDosing_ExportHTML(object sender, EventArgs e)
        {
            string sFileName = Properties.Settings.Default.ReportPatch + "Дозирования " + this.sDAT_filt_start + " - " + this.sDAT_filt_end + ".html";
            SaveToHtml(this.edgvDosing.DGV, sFileName);
        }
        private void DGV_to_CSV(string sFileName, ADGV.AdvancedDataGridView DGV)
        {
            #region Потоком (быстро, но файл CSV)
            int cols;
            StreamWriter wr = null;
            try
            {            //Прогресс
                this.lOperation.Text = "Выполняется экспорт данных в Excel...";
                this.Main_StatusStrip.Update();

                //open file 
                string csv = Properties.Settings.Default.ReportPatch + sFileName + ".csv";
                wr = new StreamWriter(csv, false, Encoding.UTF8);  //"Messages.csv"

                //wr.Write("МБС. Линия 2.    " + sTitle+" за период с " + this.lDAT_Filtr_Start.Text + " по " + this.lDAT_Filtr_End.Text);
                //wr.WriteLine();

                //determine the number of columns and write columns to file 
                cols = DGV.Columns.Count;
                for (int i = 0; i < cols; i++)
                {
                    wr.Write(DGV.Columns[i].HeaderText.ToString().Replace(",", ".") + ","); //.ToUpper()
                }
                wr.WriteLine();

                //write rows to excel file
                //Прогресс (максимум значения)
                this.Progress.Maximum = DGV.Rows.Count;

                for (int i = 0; i < DGV.Rows.Count; i++)
                {
                    //Прогресс (прирост значения)
                    if (this.Progress.Value == this.Progress.Maximum)
                    { this.Progress.Value = this.Progress.Minimum; }
                    this.Progress.Value += 1;

                    for (int j = 0; j < cols; j++)
                    {
                        if (DGV.Rows[i].Cells[j].Value != null)
                        {
                            //if (DGV.Columns[j].ValueType == typeof(DateTime))
                            //{
                            //    string sDate = DateTime.ParseExact(DGV.Rows[i].Cells[j].FormattedValue.ToString(), "dd/MM/yyyy hh:mm:ss.fff", null).ToString("dd/MM/yyyy hh:mm:ss.fff");
                            //    wr.Write(sDate + ","); 
                            //}
                            //else{ wr.Write(DGV.Rows[i].Cells[j].FormattedValue.ToString().Replace(",", ".") + ","); }//.Replace(@"\r\n?|\n"," ")
                            wr.Write(DGV.Rows[i].Cells[j].FormattedValue.ToString().Replace(",", ".") + ",");
                        }
                        else
                        {
                            wr.Write(",");
                        }

                    }

                    wr.WriteLine();
                }
                wr.Close();
                //Прогресс сбрасываем
                this.lOperation.Text = "";
                this.Progress.Value = 0;


            }
            catch (System.Exception ex)
            {
                if(wr!=null)wr.Close();
                //Прогресс сбрасываем
                this.lOperation.Text = "";
                this.Progress.Value = 0;
                General.ErrorMessage(ex);
            }
            finally { if (wr != null) wr.Close(); }


            #endregion


            #region Экспорт через OleDB (не заработал)
            //string filename = "c:\\tmp\\test.xls";
            //Stopwatch sw1 = Stopwatch.StartNew();
            //var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; " +
            //                                      "Extended Properties=Excel 12.0", filename);
            //using (OleDbConnection cn = new OleDbConnection(connectionString))
            //{
            //    cn.Open();
            //    using (var adapter = new OleDbDataAdapter("SELECT * FROM [roots$]", cn))
            //    {
            //        var ds = new DataSet();
            //        ds.Tables.Add((System.Data.DataTable)DS.Tables[TableName]);   
            //        adapter.Fill(ds, TableName);
            //        sw1.Stop();
            //        Console.WriteLine("Time taken for excel roots: {0} ms", sw1.Elapsed.TotalMilliseconds);
            //    }
            //}
            #endregion

            #region Экспорт из буфера обмена (более менее быстро, но не красиво)
            //DGV.SelectAll();
            //DataObject dataObj = DGV.GetClipboardContent();
            //if (dataObj != null)
            //    Clipboard.SetDataObject(dataObj);

            //Microsoft.Office.Interop.Excel.Application xlexcel;
            //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            //object misValue = System.Reflection.Missing.Value;
            //xlexcel = new Microsoft.Office.Interop.Excel.Application();
            //xlexcel.Visible = true;
            //xlWorkBook = xlexcel.Workbooks.Add(misValue);
            //xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.ActiveSheet;
            //Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            //CR.Select();
            //xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            #endregion

            #region Экспорт построчно (медленно)
            //Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            //Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ////Книга.
            //ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ////Таблица.
            //ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            //ExcelApp.Cells[1, 1] = "МБС. Линия 2. События за период с " + "по";

            //for (int i = 0; i < DGV.Rows.Count; i++)
            //{
            //    for (int j = 0; j < DGV.ColumnCount; j++)
            //    {
            //        ExcelWorkSheet.Cells[i + 2, j + 1] = DGV.Rows[i].Cells[j].Value; //Тут ошибку выдает
            //    }
            //}
            //ExcelApp.Visible = true;
            //ExcelApp.UserControl = true;
            // Уничтожение объекта Excel.
            //Marshal.ReleaseComObject(ExcelApp);
            //// Вызываем сборщик мусора для немедленной очистки памяти
            //GC.GetTotalMemory(true);
            #endregion
        }
        private void CSV_to_Excel(string sFileName)
        {   // не будет работать нк компе без EXCEL, либо разобраться как зарегистрировать DLL для использования без установки, либо переделать на другую библиотеку (EEPUB)
            //https/stackoverflow.com/questions/2654932/create-excel-files-from-c-sharp-without-office
            Microsoft.Office.Interop.Excel.Application xl = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
                //Прогресс
                this.lOperation.Text = "Выполняется форматирование таблицы Excel...";
                this.Progress.Maximum = 3;
                this.Progress.Value = 1;
                this.Main_StatusStrip.Update();            
            try
            {


                string sFilePatch = Properties.Settings.Default.ReportPatch;
                string csv = sFilePatch + sFileName + ".csv"; // @"D:\Report\Messages.csv";
                string xls = sFilePatch + sFileName + ".xlsx"; //@"D:\Report\Messages.xlsx";



                xl = new Microsoft.Office.Interop.Excel.Application();
                //Open Excel Workbook for conversion.
                wb = xl.Workbooks.Open(csv);
                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.get_Item(1);                

                //Select The UsedRange
                Microsoft.Office.Interop.Excel.Range used = ws.UsedRange;
                //ws.Cells[1, 1].Font.Bold = true;
                ws.Range[ws.Cells[1, 1], ws.Cells[1, used.Columns.Count]].Font.Bold = true;
                ws.Range[ws.Cells[1, 1], ws.Cells[1, used.Columns.Count]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.PowderBlue);//.LightCyan
                ws.Range[ws.Cells[1, 1], ws.Cells[1, used.Columns.Count]].AutoFilter();
                //ws.Range[ws.Cells[1, 1], ws.Cells[1, used.Columns.Count]].WrapText = true; // перенос текста

                used.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                used.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                //Прогресс (прирост значения)
                if (this.Progress.Value == this.Progress.Maximum)
                { this.Progress.Value = this.Progress.Minimum; }
                this.Progress.Value += 1;

                //Autofit The Columns
                used.EntireColumn.AutoFit();

                //Close the Workbook.
                ws.Activate();
                ws.Application.ActiveWindow.SplitRow = 1;
                ws.Application.ActiveWindow.FreezePanes = true;

                //Прогресс (прирост значения)
                if (this.Progress.Value == this.Progress.Maximum)
                { this.Progress.Value = this.Progress.Minimum; }
                this.Progress.Value += 1;

                //Save file as xls file
                if (File.Exists(xls)) 
                {  
                    //File.Delete(xls);
                    SaveFileDialog sf= new SaveFileDialog();
                    sf.DefaultExt=".xlsx";
                    sf.InitialDirectory = sFilePatch;
                    sf.FileName = sFileName;
                    //sf.ShowDialog();
                    if (sf.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    if (xls == sf.FileName)
                    {
                        File.Delete(xls);
                        wb.SaveAs(xls, 51);
                    }
                    else 
                    { 
                        xls = sf.FileName;
                        wb.SaveAs(xls, 51);
                    }

                    //wb.SaveAs(xls, 51);
                }
                else { wb.SaveAs(xls, 51); }

                wb.Close();
                wb= null;
                //Quit Excel Application.
                xl.Quit();
                Marshal.ReleaseComObject(xl);
                File.Delete(csv);
                Type officeType = Type.GetTypeFromProgID("Excel.Application");
                if (officeType == null)
                {
                    DialogResult res = MessageBox.Show("Экспорт завершен. Открыть папку?", "Экспорт выполнен", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)  {Process.Start("explorer.exe", xls);}
                }
                else
                {
                    DialogResult res = MessageBox.Show("Экспорт завершен. Открыть файл?", "Экспорт выполнен", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(xls);
                    }
                }
                //Прогресс сбрасываем
                this.lOperation.Text = "";
                this.Progress.Value = 0;

            }
            catch (System.Exception ex)
            {
                //Прогресс сбрасываем
                this.lOperation.Text = "";
                this.Progress.Value = 0;
                if(wb!=null)
                {   wb.Close();
                    wb = null;
                }
                //Quit Excel Application.
                if (xl != null)
                {
                    Marshal.ReleaseComObject(xl);
                    xl = null; 
                }
                    General.ErrorMessage(ex);
            }
            finally
            {                 
                // Уничтожение объекта Excel.
                //Marshal.ReleaseComObject(xl);
                // Вызываем сборщик мусора для немедленной очистки памяти
                GC.GetTotalMemory(true);
            }




        }

        void SaveToHtml(DataGridView dgv, String fn)
        {
            XmlWriter writer = null;

            try
            {
                //Прогресс
                this.lOperation.Text = "Выполняется экспорт данных в HTML...";
                this.Main_StatusStrip.Update();

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("\t");
                settings.OmitXmlDeclaration = true;
                settings.Encoding = Encoding.UTF8;

                if (File.Exists(fn))
                {
                    //File.Delete(xls);
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.DefaultExt = ".html";
                    sf.InitialDirectory = Properties.Settings.Default.ReportPatch;
                    sf.FileName = fn.Replace(Properties.Settings.Default.ReportPatch, "");
                    //sf.ShowDialog();
                    if (sf.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    fn = sf.FileName;
                }
                writer = XmlWriter.Create(fn, settings);

                writer.WriteStartElement("table");
                writer.WriteAttributeString("border", "0");
                writer.WriteAttributeString("cellspacing", "1");
                writer.WriteAttributeString("cellpadding", "3");
                writer.WriteAttributeString("bgcolor", "#000000");
                writer.WriteStartElement("tbody");

                // Запись заголовка таблицы HTML:
                writer.WriteStartElement("tr");
                writer.WriteAttributeString("style", "background-color: #e0effe;");
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    writer.WriteElementString("th", column.HeaderText);
                }
                writer.WriteEndElement();  // закрытие тега tr
               // Запись всех строк:
                int rowstart = 0;
                int rowidx = rowstart;
                int rowend = dgv.Rows.Count - 1;
                //Прогресс
                this.Progress.Maximum = dgv.Rows.Count;
                this.lOperation.Visible = true;
                foreach (DataGridViewRow row in dgv.Rows)
                {

                    //Прогресс (прирост значения)
                    if (this.Progress.Value == this.Progress.Maximum)
                    { this.Progress.Value = this.Progress.Minimum; }
                    this.Progress.Value += 1;

                    writer.WriteStartElement("tr");
                    //цвета фона и текста я чейки
                    string sBackColor = "#ffffff";
                    string sForeColor = "#000000";
                    if (row.DefaultCellStyle.BackColor != null & row.DefaultCellStyle.BackColor!= Color.Empty) 
                        sBackColor = $"#{row.DefaultCellStyle.BackColor.R:X2}{row.DefaultCellStyle.BackColor.G:X2}{row.DefaultCellStyle.BackColor.B:X2}";                       
                    if (row.DefaultCellStyle.ForeColor != null & row.DefaultCellStyle.ForeColor != Color.Empty) 
                        sForeColor = $"#{row.DefaultCellStyle.ForeColor.R:X2}{row.DefaultCellStyle.ForeColor.G:X2}{row.DefaultCellStyle.ForeColor.B:X2}";
                    writer.WriteAttributeString("style", "background-color: " + sBackColor + "; color:" + sForeColor + ";");

                    foreach (DataGridViewCell column in row.Cells)
                    {
                        if (null != column.FormattedValue)
                        {
                            writer.WriteStartElement("td");
                            writer.WriteString(column.FormattedValue.ToString());
                            writer.WriteEndElement();  // закрытие тега td
                        }
                        else
                            writer.WriteElementString("td", " ");
                    }
                    writer.WriteEndElement();  // закрытие тега tr
                    rowidx++;
                }
                writer.WriteEndElement();  // закрытие тега tbody
                writer.WriteEndElement();  // закрытие тега table
                writer.Flush();
                writer.Close();

                //ProgressControl.Clear();
                DialogResult res = MessageBox.Show("Экспорт завершен. Открыть файл?", "Экспорт выполнен", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(fn);
                    //Прогресс сбрасываем
                    this.lOperation.Text = "";
                    this.Progress.Value = 0;
                }

                if (res == DialogResult.No)
                    //Прогресс сбрасываем
                    this.lOperation.Text = "";
                    this.Progress.Value = 0;
                {
                }
            }
            finally
            {
                if (writer != null)
                    writer.Close();
                //GC.GetTotalMemory(true);
            }
        }


        private void slReportDB_ConnSts_Click(object sender, EventArgs e)
        {
            //Проверка состояний подключения к БД событий
            bReportConnOK = SQLControls.CheckPropertyConnStr("Report");
        }

        private void slWinCCAlarm_ConnSts_Click(object sender, EventArgs e)
        {
            //Проверка состояний подключения к БД событий
            bAlarmConnOK = SQLControls.CheckPropertyConnStr("Alarm");
        }

        private void Main_TabControl_Click(object sender, EventArgs e)
        {
            if (this.Main_TabControl.SelectedTab == this.Main_TabControl.TabPages["tbReport"])
            {
                Report.UpdateTables();
            }
            
        }

        private void edgvOrders_MakeReport(object sender, EventArgs e)
        {
            string sID = this.edgvOrders.DGV.Rows[(e as DataGridViewCellEventArgs).RowIndex].Cells["ID"].Value.ToString();

            Report.GoToRowByID("Order", sID);
            //this.Main_TabControl.SelectedIndex = this.Main_TabControl.TabPages["tbReport"].ind;
            this.Main_TabControl.SelectedTab = this.Main_TabControl.TabPages["tbReport"];


            //Report.UpdateTables();
        }

        private void edgvBatchs_MakeReport(object sender, EventArgs e)
        {
            string sOrderID = this.edgvBatchs.DGV.Rows[(e as DataGridViewCellEventArgs).RowIndex].Cells["Заказ"].Value.ToString();
            if (sOrderID == "" | sOrderID == null)
                sOrderID = "0";
            Report.GoToRowByID("Order", sOrderID);

            //this.Main_TabControl.SelectedIndex = this.Main_TabControl.TabPages["tbReport"].ind;
            this.Main_TabControl.SelectedTab = this.Main_TabControl.TabPages["tbReport"];

            string sID = this.edgvBatchs.DGV.Rows[(e as DataGridViewCellEventArgs).RowIndex].Cells["ID"].Value.ToString();
            Report.GoToRowByID("Batch", sID);
        }
    }
}
