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

namespace MBS
{
    public partial class formSetting : Form
    {
        public formSetting()
        {
            InitializeComponent();
            Load += new EventHandler(formSetting_Load);
        }

        private void formSetting_Load(object sender, System.EventArgs e)
        {
            textBox_ProjectName.Text = Properties.Settings.Default.ProjectName;
            textBox_ReportPatch.Text = Properties.Settings.Default.ReportPatch;
            textBox_ReportConnection.Text = Properties.Settings.Default.ReportConnectionString;
            textBox_AlarmConnection.Text = Properties.Settings.Default.AlarmConnectionString;
            
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
            Properties.Settings.Default["ProjectName"] = textBox_ProjectName.Text;
            Properties.Settings.Default.Save();
            textBox_ProjectName.ReadOnly = true;
            btn_ProjectName_Cancel.Visible = false;
            btn_ProjectName_Change.Visible = true;
            btn_ProjectName_Save.Enabled = false;

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.GetSectionGroup("userSettings").Sections["MBS.Properties.Settings"] as ClientSettingsSection;

            if (settings != null)
            {
                var setting = settings.Settings.Get("ProjectName");
                if (setting != null)
                {
                    Console.WriteLine(setting.Value.ValueXml.InnerXml);
                    setting.Value.ValueXml.InnerXml = textBox_ProjectName.Text;
                    Console.WriteLine("changed");
                    Console.WriteLine(setting.Value.ValueXml.InnerXml);
                }
                else
                    Console.WriteLine("failed");

                config.Save(ConfigurationSaveMode.Full);
                config.Save(ConfigurationSaveMode.Minimal);
                config.Save(ConfigurationSaveMode.Modified);
                Console.WriteLine(setting.Value.ValueXml.InnerXml);
                ConfigurationManager.RefreshSection(settings.SectionInformation.Name);
            }

        }

        private void btn_ProjectName_Cancel_Click(object sender, EventArgs e)
        {
            textBox_ProjectName.Text = Properties.Settings.Default.ProjectName;
            textBox_ProjectName.ReadOnly = true;
            btn_ProjectName_Cancel.Visible = false;
            btn_ProjectName_Change.Visible = true;
        }

        // ReportPatch

        private void btn_ReportPatch_Change_Click(object sender, EventArgs e)
        {
            textBox_ReportPatch.ReadOnly = false;
            Properties.Settings.Default.ReportPatch = @"D:\Projects\MBS\Report\отчеты"; 

            string sFilePatch = General.GetFilePatch();

            if (sFilePatch != "")
            {
                textBox_ReportPatch.Text = sFilePatch;
                Properties.Settings.Default.ReportPatch = textBox_ReportPatch.Text;
                Properties.Settings.Default.Save();
                textBox_ReportPatch.ReadOnly = true;
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
    }
}
