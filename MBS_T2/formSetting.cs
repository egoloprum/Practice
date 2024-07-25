using MBS.Properties;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using Microsoft.ReportingServices.Interfaces;
using System.Timers;
using System.Threading;

namespace MBS
{
    public partial class formSetting : Form
    {
        formSetting     fSetting;
        formCreateDB    fCreateDB;
        formClearDB     fClearDB;

        private const long BYTES_IN_8GB = 8L * 1024 * 1024 * 1024;

        public formSetting()
        {
            InitializeComponent();
        }

        private void formSetting_Load(object sender, EventArgs e)
        {
            textBox_ProjectName.Text        = Settings.Default.ProjectName;
            textBox_ReportPatch.Text        = Settings.Default.ReportPatch;
            textBox_ReportConnection.Text   = Settings.Default.ReportConnectionString;
            textBox_AlarmConnection.Text    = Settings.Default.AlarmConnectionString;

            long sizeDB = SQLControls.GetSizeOfDB(Settings.Default.ReportConnectionString);

            textBox_Size_Report.Text = (sizeDB / 1024 / 1024).ToString() + " MB";
            if (sizeDB > BYTES_IN_8GB)
            {
                textBox_Size_Report.BackColor = Color.FromArgb(255, 128, 128);
            }

            sizeDB = SQLControls.GetSizeOfDB(Settings.Default.AlarmConnectionString);
            textBox_Size_Alarm.Text = (sizeDB / 1024 / 1024).ToString() + " MB";
            if (sizeDB > BYTES_IN_8GB)
            {
                textBox_Size_Alarm.BackColor = Color.FromArgb(255, 128, 128);
            }
        }

        // ProjectName

        private void btn_ProjectName_Change_Click(object sender, EventArgs e)
        {
            textBox_ProjectName.ReadOnly = false;
            btn_ProjectName_Cancel.Visible = true;
            btn_ProjectName_Change.Visible = false;
            btn_ProjectName_Save.Enabled = true;
        }

        private void btn_ProjectName_Save_Click(object sender, EventArgs e)
        {
            Settings.Default["ProjectName"] = textBox_ProjectName.Text;
            Settings.Default.Save();
            textBox_ProjectName.ReadOnly = true;
            btn_ProjectName_Cancel.Visible = false;
            btn_ProjectName_Change.Visible = true;
            btn_ProjectName_Save.Enabled = false;

            UpdateUser_AppConfig("ProjectName", textBox_ProjectName.Text);
        }

        private void btn_ProjectName_Cancel_Click(object sender, EventArgs e)
        {
            textBox_ProjectName.Text = Settings.Default.ProjectName;
            textBox_ProjectName.ReadOnly = true;
            btn_ProjectName_Cancel.Visible = false;
            btn_ProjectName_Change.Visible = true;
        }

        // ReportPatch

        private void btn_ReportPatch_Change_Click(object sender, EventArgs e)
        {
            textBox_ReportPatch.ReadOnly = false;
            Settings.Default.ReportPatch = @"D:\Projects\MBS\Report\отчеты"; 

            string sFilePatch = General.GetFilePatch();

            if (sFilePatch != "")
            {
                textBox_ReportPatch.Text = sFilePatch;
                Settings.Default.ReportPatch = textBox_ReportPatch.Text;
                Settings.Default.Save();
                textBox_ReportPatch.ReadOnly = true;

                UpdateUser_AppConfig("ReportPatch", textBox_ReportPatch.Text);
            }
            else
            {
                textBox_ReportPatch.ReadOnly = true;
            }
        }

        // Report Connection

        private void btn_ReportConnection_Change_Click(object sender, EventArgs e)
        {
            int ErrCode = SQLControls.GetConnectionString("ReportConnectionString");

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            string connectString = connectionStringsSection.ConnectionStrings["MBS.Properties.Settings.ReportConnectionString"].ConnectionString; //.ReportConnectionString;
            if (ErrCode == 0)
            {
                textBox_ReportConnection.Text = connectString;
                UpdateApp_AppConfig("MBS.Properties.Settings.ReportConnectionString", connectString);
            }
            else
            {
                Console.WriteLine("failed report connection change.");
            }
        }

        private void btn_ReportConnection_CheckCon_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            string connectString = connectionStringsSection.ConnectionStrings["MBS.Properties.Settings.ReportConnectionString"].ConnectionString; //.ReportConnectionString;

            bool chDB = SQLControls.CheckDB(connectString);
            
            if (chDB)
            {
                DialogResult res = MessageBox.Show("Подключение подтверждано\n" + connectString, "БД доступна", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult res = MessageBox.Show("Выбранная БД недоступна. Все равно сохранить подключение?", "БД недоступна", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

        }

        // Alarm Connection

        private void btn_AlarmConnection_Change_Click(object sender, EventArgs e)
        {
            int ErrCode = SQLControls.GetConnectionString("AlarmConnectionString");

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            string connectString = connectionStringsSection.ConnectionStrings["MBS.Properties.Settings.AlarmConnectionString"].ConnectionString; //.AlarmConnectionString;
            if (ErrCode == 0)
            {
                textBox_AlarmConnection.Text = connectString;
                UpdateApp_AppConfig("MBS.Properties.Settings.AlarmConnectionString", connectString);
            }
            else
            {
                Console.WriteLine("failed report connection change.");
            }
        }

        private void btn_AlarmConnection_CheckCon_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            string connectString = connectionStringsSection.ConnectionStrings["MBS.Properties.Settings.AlarmConnectionString"].ConnectionString; //.AlarmConnectionString;

            bool chDB = SQLControls.CheckDB(connectString);

            if (chDB)
            {
                DialogResult res = MessageBox.Show("Подключение подтверждано\n" + connectString, "БД доступна", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult res = MessageBox.Show("Выбранная БД недоступна. Все равно сохранить подключение?", "БД недоступна", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }

        // update config file

        public void UpdateUser_AppConfig(string key, string value)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string configFilePath = Path.Combine(baseDirectory, @"..\..\App.config");
            configFilePath = Path.GetFullPath(configFilePath);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFilePath);

            XmlNode node = xmlDoc.SelectSingleNode($"//setting[@name='{key}']/value");
            if (node != null)
            {
                node.InnerText = value;
            }
            else
            {
                // if does not exist, create new one
                XmlNode settingsNode = xmlDoc.SelectSingleNode("//MBS.Properties.Settings");
                if (settingsNode != null)
                {
                    XmlElement settingElement = xmlDoc.CreateElement("setting");
                    settingElement.SetAttribute("name", key);
                    settingElement.SetAttribute("serializeAs", "String");

                    XmlElement valueElement = xmlDoc.CreateElement("value");
                    valueElement.InnerText = value;

                    settingElement.AppendChild(valueElement);
                    settingsNode.AppendChild(settingElement);
                }
            }

            xmlDoc.Save(configFilePath);
            // ConfigurationManager.RefreshSection(node.InnerXml);
        }
       
        public void UpdateApp_AppConfig(string name, string newConnectionString)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string configFilePath = Path.Combine(baseDirectory, @"..\..\App.config");
            configFilePath = Path.GetFullPath(configFilePath);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFilePath);

            XmlNode node = xmlDoc.SelectSingleNode($"//connectionStrings/add[@name='{name}']");
            if (node != null)
            {
                XmlAttribute connectionStringAttribute = node.Attributes["connectionString"];
                if (connectionStringAttribute != null)
                {
                    connectionStringAttribute.Value = newConnectionString;
                }
            }
            else
            {
                // if does not exist, create new one
                XmlNode connectionStringNode = xmlDoc.SelectSingleNode("//connectionStrings");
                if (connectionStringNode != null)
                {
                    XmlElement addElement = xmlDoc.CreateElement("add");
                    addElement.SetAttribute("name", name);
                    addElement.SetAttribute("connectionString", newConnectionString);
                    addElement.SetAttribute("providerName", "System.Data.SqlClient");

                    connectionStringNode.AppendChild(addElement);
                }
            }

            xmlDoc.Save(configFilePath);
            // ConfigurationManager.RefreshSection(node.InnerXml);
        }

        private void btn_ReportConnection_CreateDB_Click(object sender, EventArgs e)
        {
            fCreateDB = new formCreateDB("Report");
            fCreateDB.StartPosition = FormStartPosition.CenterScreen;
            fCreateDB.ShowDialog();
        }

        private void btn_AlarmConnection_CreateDB_Click(object sender, EventArgs e)
        {
            fCreateDB = new formCreateDB("Alarm");
            fCreateDB.StartPosition = FormStartPosition.CenterScreen;
            fCreateDB.ShowDialog();
        }

        private void btn_UpdateSize_Report_Click(object sender, EventArgs e)
        {
            textBox_Size_Report.Text = "calculating";

            System.Timers.Timer timer = new System.Timers.Timer(500);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;
            timer.Enabled = true;

            // Run the database query on a separate thread to avoid blocking the UI thread
            Task.Run(() =>
            {
                long sizeDB = SQLControls.GetSizeOfDB(textBox_ReportConnection.Text);

                // Wait for the timer to elapse
                timer.WaitForElapsed();

                // Update the UI on the main thread
                this.Invoke(new Action(() =>
                {
                    textBox_Size_Report.Text = (sizeDB / 1024 / 1024).ToString() + " MB";
                    if (sizeDB > BYTES_IN_8GB)
                    {
                        textBox_Size_Report.BackColor = Color.FromArgb(255, 128, 128);
                    }
                }));
            });

            void OnTimedEvent(object source, ElapsedEventArgs elaps)
            {
                timer.Stop();
            }
        }

        private void btn_UpdateSize_Alarm_Click(object sender, EventArgs e)
        {
            textBox_Size_Alarm.Text = "calculating";

            System.Timers.Timer timer = new System.Timers.Timer(500);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;
            timer.Enabled = true;

            // Run the database query on a separate thread to avoid blocking the UI thread
            Task.Run(() =>
            {
                long sizeDB = SQLControls.GetSizeOfDB(textBox_AlarmConnection.Text);

                if (sizeDB == -1)
                {
                    textBox_Size_Alarm.Text = "error";
                }

                // Wait for the timer to elapse
                timer.WaitForElapsed();

                // Update the UI on the main thread
                this.Invoke(new Action(() =>
                {
                    textBox_Size_Alarm.Text = (sizeDB / 1024 / 1024).ToString() + " MB";

                    if (sizeDB > BYTES_IN_8GB)
                    {
                        textBox_Size_Alarm.BackColor = Color.FromArgb(255, 128, 128);
                    }
                }));
            });

            void OnTimedEvent(object source, ElapsedEventArgs elaps)
            {
                timer.Stop();
            }
        }

        private void btn_Clear_Report_Click(object sender, EventArgs e)
        {
            fClearDB = new formClearDB("Report", Settings.Default.ReportConnectionString);
            fClearDB.StartPosition = FormStartPosition.CenterScreen;
            fClearDB.ShowDialog();
        }

        private void btn_Clear_Alarm_Click(object sender, EventArgs e)
        {
            fClearDB = new formClearDB("Alarm", Settings.Default.AlarmConnectionString);
            fClearDB.StartPosition = FormStartPosition.CenterScreen;
            fClearDB.ShowDialog();
        }

        private void textBox_ReportConnection_TextChanged(object sender, EventArgs e)
        {
            long sizeDB = SQLControls.GetSizeOfDB(textBox_ReportConnection.Text);

            if (sizeDB == -1)
            {
                textBox_Size_Report.Text = "error";
            }

            textBox_Size_Report.Text = (sizeDB / 1024 / 1024).ToString() + " MB";

            if (sizeDB > BYTES_IN_8GB)
            {
                textBox_Size_Report.BackColor = Color.FromArgb(255, 128, 128);
            }
        }

        private void textBox_AlarmConnection_TextChanged(object sender, EventArgs e)
        {
            long sizeDB = SQLControls.GetSizeOfDB(textBox_AlarmConnection.Text);

            if (sizeDB == -1)
            {
                textBox_Size_Alarm.Text = "error";
            }

            textBox_Size_Alarm.Text = (sizeDB / 1024 / 1024).ToString() + " MB";

            if (sizeDB > BYTES_IN_8GB)
            {
                textBox_Size_Alarm.BackColor = Color.FromArgb(255, 128, 128);
            }
        }
    }
}

public static class TimerExtensions
{
    public static void WaitForElapsed(this System.Timers.Timer timer)
    {
        ManualResetEventSlim mre = new ManualResetEventSlim(false);
        ElapsedEventHandler handler = null;
        handler = (s, e) =>
        {
            timer.Elapsed -= handler;
            mre.Set();
        };
        timer.Elapsed += handler;
        mre.Wait();
    }
}
