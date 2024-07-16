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
using System.Timers;
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
            Application.OpenForms["formCreateDB"].Close();
        }

        private void btn_KeepConn_Click(object sender, EventArgs e)
        {
            string connectionString = SQLControls.ConnectionString;
            fSetting = new formSetting();
            fCreateDB = new formCreateDB(_typeOfDb);

            if (_typeOfDb == "Alarm")
            {
                fSetting.UpdateApp_AppConfig("MBS.Properties.Settings.AlarmConnectionString", connectionString);
                Settings.Default.AlarmConnectionString = connectionString;

                Console.WriteLine($"sett def = {Settings.Default.AlarmConnectionString}");
            }
            else
            {
                fSetting.UpdateApp_AppConfig("MBS.Properties.Settings.ReportConnectionString", connectionString);
                Settings.Default.ReportConnectionString = connectionString;

                Console.WriteLine($"sett def = {Settings.Default.ReportConnectionString}");
            }

            this.Close();
            Application.OpenForms["formCreateDB"].Close();
            Application.OpenForms["formSetting"].Close();

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;
            timer.Enabled = true;


            void OnTimedEvent(object source, ElapsedEventArgs elaps)
            {
                timer.Stop();

                fSetting = new formSetting();
                fSetting.StartPosition = FormStartPosition.CenterScreen;
                fSetting.ShowDialog();
            }
        }
    }
}
