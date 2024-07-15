using MBS.Properties;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBS
{
    public partial class formKeepConnection : Form
    {
        formCreateDB fCreateDB;
        formSetting fSetting;
        string _typeOfDb;

        public formKeepConnection(string typeOfDb)
        {
            InitializeComponent();
            _typeOfDb = typeOfDb;
        }

        private void btn_CloseConn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_KeepConn_Click(object sender, EventArgs e)
        {
            string connectionString = SQLControls.ConnectionString;
            fSetting = new formSetting();

            if (_typeOfDb == "Alarm")
            {
                fSetting.UpdateApp_AppConfig("MBS.Properties.Settings.AlarmConnectionString", connectionString);
                Console.WriteLine($"before = {fSetting.textBox_AlarmConnection_Value}");
                fSetting.textBox_AlarmConnection_Value = connectionString;
               
                Console.WriteLine($"after = {fSetting.textBox_AlarmConnection_Value}");
                Console.WriteLine($"connectionStr = {connectionString}");
            }
            else
            {
                fSetting.UpdateApp_AppConfig("MBS.Properties.Settings.ReportConnectionString", connectionString);
                Console.WriteLine($"before = {fSetting.textBox_ReportConnection_Value}");
                fSetting.textBox_ReportConnection_Value = connectionString;
                Console.WriteLine($"after = {fSetting.textBox_ReportConnection_Value}");
                Console.WriteLine($"connectionStr = {connectionString}");

            }

            this.Close();
            fSetting.Refresh();
        }
    }
}
