using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBS
{
    public partial class formCreateDB : Form
    {
        string _typeOfDb = "";
        public formCreateDB(String TypeOfDB)
        {
            InitializeComponent();

            _typeOfDb = TypeOfDB;
            Console.WriteLine(comboBox_TypeDB.Items[0]);
        }

        private void formCreateDB_Load(object sender, EventArgs e)
        {
            if (_typeOfDb == "Alarm")
            {
                comboBox_TypeDB.SelectedValue = comboBox_TypeDB.Items[0];
                comboBox_TypeDB.Text = comboBox_TypeDB.Items[0].ToString();
            }
            else
            {
                comboBox_TypeDB.SelectedValue = comboBox_TypeDB.Items[1];
                comboBox_TypeDB.Text = comboBox_TypeDB.Items[1].ToString();
            }

            comboBox_TypeDBMS.SelectedIndex = 0;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_TestConn_Click(object sender, EventArgs e)
        {
            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            //string connectString = connectionStringsSection.ConnectionStrings["MBS.Properties.Settings.ReportConnectionString"].ConnectionString; //.ReportConnectionString;

            //bool chDB = SQLControls.CheckDB(connectString);

            //if (chDB)
            //{
            //    DialogResult res = MessageBox.Show("Подключение подтверждано\n" + connectString, "БД доступна", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    DialogResult res = MessageBox.Show("Выбранная БД недоступна. Все равно сохранить подключение?", "БД недоступна", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //}
        }
        private void radioButton_Windows_CheckedChanged(object sender, EventArgs e)
        {
            label_User.Enabled = false;
            label_Password.Enabled = false;
            textBox_Username.Enabled = false;
            textBox_Password.Enabled = false;

            check_nameDB();
        }

        private void radioButton_SQLserver_CheckedChanged(object sender, EventArgs e)
        {
            label_User.Enabled = true;
            label_Password.Enabled = true;
            textBox_Username.Enabled = true;
            textBox_Password.Enabled = true;

            check_nameDB();
        }

        private void check_nameDB()
        {
            if (radioButton_SQLserver.Checked)
            {
                if (textBox_Username.Text.Length != 0 && textBox_Password.Text.Length != 0 && 
                    comboBox_NameServer.Text.Length != 0 && comboBox_NameDB.Text.Length != 0)
                {
                    comboBox_NameDB.Enabled = true;
                    label_NameDB.Enabled = true;
                    btn_CreateDB.Enabled = true;
                    btn_TestConn.Enabled = true;
                    Console.WriteLine("0");
                }
                else if (textBox_Username.Text.Length != 0 && textBox_Password.Text.Length != 0 && comboBox_NameServer.Text.Length != 0)
                {
                    comboBox_NameDB.Enabled = true;
                    label_NameDB.Enabled = true;
                    btn_CreateDB.Enabled = false;
                    btn_TestConn.Enabled = false;
                    Console.WriteLine("1");
                }
                else
                {
                    comboBox_NameDB.Enabled = false;
                    label_NameDB.Enabled = false;
                    btn_CreateDB.Enabled = false;
                    btn_TestConn.Enabled = false;
                    Console.WriteLine("2");
                }
            }
            else
            {                
                if (comboBox_NameServer.Text.Length != 0 && comboBox_NameDB.Text.Length != 0)
                {
                    comboBox_NameDB.Enabled = true;
                    label_NameDB.Enabled = true;
                    btn_CreateDB.Enabled = true;
                    btn_TestConn.Enabled = true;
                    Console.WriteLine("3");
                }
                else if (comboBox_NameServer.Text.Length != 0)
                {
                    comboBox_NameDB.Enabled = true;
                    label_NameDB.Enabled = true;
                    btn_CreateDB.Enabled = false;
                    btn_TestConn.Enabled = false;
                    Console.WriteLine("4");
                }
                else
                {
                    comboBox_NameDB.Enabled = false;
                    label_NameDB.Enabled = false;
                    btn_CreateDB.Enabled = false;
                    btn_TestConn.Enabled = false;
                    Console.WriteLine("5");
                }
            }
        }
        private void comboBox_NameServer_TextChanged(object sender, EventArgs e)
        {
            check_nameDB();
        }
        private void comboBox_NameDB_TextChanged(object sender, EventArgs e)
        {
            check_nameDB();
        }

        private void textBox_Username_TextChanged(object sender, EventArgs e)
        {
            check_nameDB();
        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {
            check_nameDB();
        }

        private void comboBox_NameServer_DropDown(object sender, EventArgs e)
        {
            string[] theAvailableSqlServers = SqlLocator.GetServers();
            if (theAvailableSqlServers != null)
            {
                comboBox_NameServer.DataSource = theAvailableSqlServers;
            }
            else
            {
                MessageBox.Show("SQL сервера не найдены!");
            }
        }

        private void comboBox_TypeDBMS_DropDown(object sender, EventArgs e)
        {

        }

        private void comboBox_TypeDBMS_TextChanged(object sender, EventArgs e)
        {
            short Mode = (short)this.comboBox_TypeDBMS.SelectedIndex;

            this.comboBox_TypeDBMS.ForeColor = System.Drawing.Color.Black;
            {
                switch (Mode)
                {
                    case 0:
                        //БД SQLServer
                        this.comboBox_NameServer.Text = ProjectSettings.DefaultSQLServer;
                        break;
                }
            }
        }
    }
}
