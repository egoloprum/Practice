using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace mySecurity
{
    public partial class AddUserDialog : Form
    {
        public AddUserDialog()
        {
            InitializeComponent();
        }
        private void bOK_Click(object sender, EventArgs e)
        {
            if (tbUser.Text != "" && this.tbLogin.Text != "" && tbPassword.Text != "" && this.cbRole.Text!= "")
            {
                if (string.Compare(tbPassword.Text, tbConfirmPassword.Text, 0) == 0)
                {
                    myUser mUser = new myUser(tbUser.Text, this.tbLogin.Text, tbPassword.Text, Convert.ToInt32(this.cbRole.SelectedValue.ToString()));
                    mUser.Add();
                    //MessageBox.Show("Данные пользователя обновлены", "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Значение пароля и подтверждения пароля не совпадают", "Пользователь",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Не все данные пользователя не указаны", "Пользователь",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddUserDialog_Load(object sender, EventArgs e)
        {
            //источник данных для ролей
            DataSet DS_Roles = new DataSet();
            DS_Roles.Clear();
            DS_Roles.ReadXml(myUser.RolesFilePath);
            BindingSource BS1 = new BindingSource();
            BS1.DataSource = DS_Roles;
            BS1.DataMember = "Role";

            //добавим столбец свыбором полей
            this.cbRole.DataSource = BS1;
            this.cbRole.DisplayMember = "Name";
            this.cbRole.ValueMember = "Privilege";
        }

    }
}
