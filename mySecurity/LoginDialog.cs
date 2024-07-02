using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace mySecurity
{
    public partial class LoginDialog : Form
    {
        public string User = String.Empty;
        public int Role = 0;

        public LoginDialog()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            myUser mUser = new myUser("", this.tbLogin.Text, this.tbPassword.Text, 0);

            if (mUser.Check() == 0)
            {
                User = mUser.User;
                Role = mUser.Role;
                MessageBox.Show("Пользователь успешно авторизован", "Авторизация пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cbUser_DropDown(object sender, EventArgs e)
        {
            cbUser.Items.Clear();
            DataSet UsersDataSet=new DataSet();
            UsersDataSet.ReadXml(myUser.UsersFilePath);
            DataTable dtUsers = UsersDataSet.Tables["User"];
            DataRow[] currentRows = dtUsers.Select(null, null, DataViewRowState.CurrentRows);
            foreach (DataRow row in currentRows)
                {
                    cbUser.Items.Add(row["Name"]);
                }             

        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sSelectedUser = this.cbUser.Text;
            DataSet UsersDataSet=new DataSet();
            UsersDataSet.ReadXml(myUser.UsersFilePath);
            DataTable dtUsers = UsersDataSet.Tables["User"];
            DataRow[] currentRows = dtUsers.Select(null, null, DataViewRowState.CurrentRows);
            foreach (DataRow row in currentRows)
                {
                    string sUser = row["Name"].ToString(); ;
                    string sLogin = row["Login"].ToString();
                    string sRole = row["Role"].ToString();
                    if (sUser == sSelectedUser)
                    {
                        this.tbLogin.Text = sLogin;
                    }
                } 
            
        }

        private void nCancel_Click(object sender, EventArgs e)
        {
            User = "";
            Role = 0;
            this.Close();
        }
    }
}
