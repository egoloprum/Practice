﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBS
{
    public partial class formCreateDB : Form
    {
        // alarm or report
        string _typeOfDb = "";

        // name of DBs to check if it exists
        List<string> _name_Databases = new List<string>();
        List<string> _theAvailableSqlServers = new List<string>();

        // window = 0; sql server = 1
        short _modeOfDb = 0;
        public formCreateDB(String TypeOfDB)
        {
            InitializeComponent();

            _typeOfDb = TypeOfDB;
        }

        private async void formCreateDB_Load(object sender, EventArgs e)
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
            string connectionString = $"Data Source={comboBox_NameServer.Text};Initial Catalog={comboBox_NameDB.Text};User ID={textBox_Username.Text};Password={textBox_Password.Text}";
            bool chDB = SQLControls.CheckDB(connectionString);

            if (chDB)
            {
                DialogResult res = MessageBox.Show("Подключение подтверждано\n" + connectionString, "БД доступна", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult res = MessageBox.Show("Выбранная БД недоступна. Все равно сохранить подключение?", "БД недоступна", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }
        private void radioButton_Windows_CheckedChanged(object sender, EventArgs e)
        {
            label_User.Enabled = false;
            label_Password.Enabled = false;
            textBox_Username.Enabled = false;
            textBox_Password.Enabled = false;

            _modeOfDb = 0;
            check_nameDB();
        }

        private void radioButton_SQLserver_CheckedChanged(object sender, EventArgs e)
        {
            label_User.Enabled = true;
            label_Password.Enabled = true;
            textBox_Username.Enabled = true;
            textBox_Password.Enabled = true;

            _modeOfDb = 1;
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
                }
                else if (textBox_Username.Text.Length != 0 && textBox_Password.Text.Length != 0 && comboBox_NameServer.Text.Length != 0)
                {
                    comboBox_NameDB.Enabled = true;
                    label_NameDB.Enabled = true;
                    btn_CreateDB.Enabled = false;
                    btn_TestConn.Enabled = false;
                }
                else
                {
                    comboBox_NameDB.Enabled = false;
                    label_NameDB.Enabled = false;
                    btn_CreateDB.Enabled = false;
                    btn_TestConn.Enabled = false;
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
                }
                else if (comboBox_NameServer.Text.Length != 0)
                {
                    comboBox_NameDB.Enabled = true;
                    label_NameDB.Enabled = true;
                    btn_CreateDB.Enabled = false;
                    btn_TestConn.Enabled = false;
                }
                else
                {
                    comboBox_NameDB.Enabled = false;
                    label_NameDB.Enabled = false;
                    btn_CreateDB.Enabled = false;
                    btn_TestConn.Enabled = false;
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

            if (_name_Databases.Contains(comboBox_NameDB.Text))
            {
                btn_TestConn.Enabled = true;
            }
            else
            {
                btn_TestConn.Enabled = false;
            }
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
            List<string> theAvailableSqlServers = new List<string>();
            
            if (!_theAvailableSqlServers.Any())
            {
                string[] Servers = SqlLocator.GetServers();

                foreach (string Server in Servers)
                {
                    _theAvailableSqlServers.Add(Server);
                }
            }

            theAvailableSqlServers = _theAvailableSqlServers;

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

        private void btn_CreateDB_Click(object sender, EventArgs e)
        {
            string DB_Name  = comboBox_NameDB.Text;
            string Username = textBox_Username.Text;
            string Password = textBox_Password.Text;
            string Source   = comboBox_NameServer.Text;
            // window = 0; sql server = 1;
            short Mode      = _modeOfDb;
            // int createdDB = SQLControls.CreateDB(DB_Name, Username, Password, Source, Mode);
            int AddDB = SQLControls.AddNewDB(DB_Name, "", "", Username, Password, Source, Mode);

            if (AddDB == 0)
            {
                MessageBox.Show("Проект успешно создан", "Создание нового проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProjectInfo Project = new ProjectInfo(SQLControls.CurrentConnection.Database, SQLControls.CurrentConnection.ConnectionString);
                Project.Name = "";
                Project.Description = "";
                Project.Save();
                // UpdateProjects();
                this.Close();
            }
            else
            {
                MessageBox.Show("Проект не создан", "Создание нового проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox_NameDB_DropDown(object sender, EventArgs e)
        {
            // Data Source=172.23.1.84\\WINCC;
            string connectionString = $"Data Source={comboBox_NameServer.Text};Initial Catalog=master;" +
                $"User ID={textBox_Username.Text};Password={textBox_Password.Text}";
            string strQuery = "SELECT name FROM sys.databases";

            List<string> name_Databases = new List<string>();
            try
            {
                // get all initial catalog names
                SqlConnection myConnecton = new SqlConnection(connectionString);
                myConnecton.Open();
                SqlCommand myCommand = new SqlCommand(strQuery, myConnecton);
                SqlDataReader myDataReader = myCommand.ExecuteReader();

                while (myDataReader.Read())
                {
                    name_Databases.Add(myDataReader["name"].ToString());
                }

                comboBox_NameDB.DataSource = name_Databases;
                _name_Databases = name_Databases;
                myConnecton.Close();
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // ex.HResult;
            }
        }
    }
}