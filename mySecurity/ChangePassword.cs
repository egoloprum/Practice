using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mySecurity
{
    public partial class ChangePassword : Form
    {
        public string User = String.Empty;

        public ChangePassword(string user)
        {            
            InitializeComponent();
            User = user;
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbLogin.Text = myUser.GetUserInfo(this.cbUser.Text, "Login");
        }

        private void cbUser_DropDown(object sender, EventArgs e)
        {
            cbUser.Items.Clear();
            DataSet UsersDataSet = new DataSet();
            UsersDataSet.ReadXml(myUser.UsersFilePath);
            DataTable dtUsers = UsersDataSet.Tables["User"];
            DataRow[] currentRows = dtUsers.Select(null, null, DataViewRowState.CurrentRows);
            foreach (DataRow row in currentRows)
            {
                cbUser.Items.Add(row["Name"]);
            }  
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            cbUser.Text = User;
            this.tbLogin.Text = myUser.GetUserInfo(User, "Login");
            this.tbNewLogin.Text = myUser.GetUserInfo(User, "Login");
            tbOldPassword.Focus();
            //tbNewPassword.Enabled = false;
            //tbConfirmPassword.Enabled = false;

        }


        private void bOK_Click(object sender, EventArgs e)
        {
            myUser mUser = new myUser(cbUser.Text, this.tbLogin.Text, this.tbOldPassword.Text, 0);
            if (mUser.Check() == 0)
            {
                if (tbNewLogin.Text!=""&&tbNewPassword.Text!="")
                {
                    if (string.Compare(tbNewPassword.Text,tbConfirmPassword.Text,0)==0)
                    {
                        int Role =Convert.ToInt32(myUser.GetUserInfo(User, "Role"));
                        myUser mnUser = new myUser(cbUser.Text, this.tbNewLogin.Text, tbNewPassword.Text, Role);
                        mnUser.Update();
                        MessageBox.Show("Параметры входа изменены", "Изменение параметров входа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else 
                    {
                        MessageBox.Show("Значение нового пароля и подтверждения пароля не совпадают", "Изменение параметров входа",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else 
                {
                    MessageBox.Show("Новые логин или пароль не указаны", "Изменение параметров входа",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
