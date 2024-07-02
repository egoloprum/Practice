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
using System.IO;

namespace mySecurity
{
    public partial class ViewUsersDialog : Form
    {
        public ViewUsersDialog()
        {
            InitializeComponent();
        }

        Point point = new Point();
        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs ee)
        {
            point.X = ee.ColumnIndex;
            point.Y = ee.RowIndex;
        } 


        public void UpdateUsers()
        {
            DS_Users.Clear();
            DS_Users.ReadXml(myUser.UsersFilePath);
            DGV_Users.DataSource = DS_Users;
            DGV_Users.DataMember = "User";
            DGV_Users.Columns["Key"].Visible = false;
            //DGV_Users.Columns["Login"].Visible = false;

            DGV_Users.Columns["Name"].DisplayIndex = 0; DGV_Users.Columns["Name"].HeaderText = "Имя пользователя"; 
            DGV_Users.Columns["Name"].Width = 160;

            DGV_Users.Columns["Login"].DisplayIndex = 1; DGV_Users.Columns["Login"].HeaderText = "Логин";
            DGV_Users.Columns["Login"].Width = 160; DGV_Users.Columns["Login"].ReadOnly = true;
            DataGridViewCellStyle dataGridViewCellStyle1= new DataGridViewCellStyle();
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            DGV_Users.Columns["Login"].DefaultCellStyle = dataGridViewCellStyle1;

            //Удаляем столбец, т.к. он не комбобокс
            DGV_Users.Columns.Remove("Role");

            //источник данных для ролей
            DS_Roles.Clear();
            DS_Roles.ReadXml(myUser.RolesFilePath);
            
            BS_Roles.DataSource = DS_Roles;
            BS_Roles.DataMember = "Role";

            //добавим столбец свыбором полей
            DataGridViewComboBoxColumn ComboBoxColumn = new DataGridViewComboBoxColumn();
            ComboBoxColumn.Name = "Role";
            ComboBoxColumn.HeaderText = "Роль";
            ComboBoxColumn.DataPropertyName = "Role";
            ComboBoxColumn.DataSource = BS_Roles;
            ComboBoxColumn.DisplayMember = "Name";
            ComboBoxColumn.ValueMember = "Privilege";
            ComboBoxColumn.Width = 160;
            ComboBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            DGV_Users.Columns.Add(ComboBoxColumn);

            //foreach (DataGridViewRow row in DGV_Users.Rows)
            //{
            //    int Role = Convert.ToInt32(row.Cells["Role"].Value.ToString());
            //    row.Cells["Role"].Value = myUser.Roles[Role];
            //} 
        }

        public void SaveUsers()
        {
             File.Delete(myUser.UsersFilePath);
            //XmlDocument document = new XmlDocument();
            //document.Load(myUser.UsersFilePath);
            //document.RemoveAll();
            //document.Save(myUser.UsersFilePath);
            //document = null;
            foreach (DataRow row in DS_Users.Tables["User"].Rows)
            {
                string sUser = row["Name"].ToString();
                string sLogin = row["Login"].ToString();
                string sKey = row["Key"].ToString();
                string sRole = row["Role"].ToString();
                //int iRole = Convert.ToInt32(sRole);
                //myUser mUser = new myUser(sUser, sLogin, sKey, iRole);
                myUser.Save(sUser, sLogin, sKey, sRole);

            }
            UpdateUsers(); 
        }

        private void ViewUsersDialog_Load(object sender, EventArgs e)
        {
            UpdateUsers();           
        }


        private void dAdd_Click(object sender, EventArgs e)
        {
            Form fAddUserDialog = new mySecurity.AddUserDialog();
            fAddUserDialog.Owner = this;
            if (fAddUserDialog.ShowDialog() == DialogResult.OK) { 
                UpdateUsers();
            }
            
        }

        private void bRoles_Click(object sender, EventArgs e)
        {
            Form fRolesDialog = new mySecurity.RolesDialog();
            fRolesDialog.Owner = this;
            if (fRolesDialog.ShowDialog() == DialogResult.OK)
            {
                UpdateUsers();
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            SaveUsers();
            //MessageBox.Show("Информация обновлена", "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SaveUsers();
            //MessageBox.Show("Информация обновлена", "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsmi_ChangePass_Click(object sender, EventArgs e)
        {
            string sUser = "";
            if (point.X >= 0 && point.Y >= 0)
            {
                sUser=this.DGV_Users.Rows[point.Y].Cells["Name"].Value.ToString();
                Form fChangePassword = new mySecurity.ChangePassword(sUser);
                fChangePassword.Owner = this;
                if (fChangePassword.ShowDialog() == DialogResult.OK)
                {
                    UpdateUsers();
                }
            }

        }




    }
}
