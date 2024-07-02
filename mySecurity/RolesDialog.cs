using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace mySecurity
{
    public partial class RolesDialog : Form
    {
        public RolesDialog()
        {
            InitializeComponent();
        }
        public void SaveRoles()
        {
            File.Delete(myUser.RolesFilePath);

            if (!File.Exists(myUser.RolesFilePath))
            {
                XmlTextWriter textWritter = new XmlTextWriter(myUser.RolesFilePath, Encoding.UTF8);
                textWritter.WriteStartDocument();
                textWritter.WriteStartElement("Roles");
                textWritter.WriteEndElement();
                textWritter.Close();
            }

            foreach (DataRow row in DS_Roles.Tables["Role"].Rows)
            {
                string sID = row["ID"].ToString();
                string sName = row["Name"].ToString();
                string sPrivilege = row["Privilege"].ToString();

                XmlDocument document = new XmlDocument();
                document.Load(myUser.RolesFilePath);

                XmlNode element = document.CreateElement("Role");
                document.DocumentElement.AppendChild(element); // указываем родителя
                XmlAttribute attribute = document.CreateAttribute("ID"); // создаём атрибут
                attribute.Value = sID; // устанавливаем значение атрибута

                element.Attributes.Append(attribute); // добавляем атрибут
                XmlNode subElement1 = document.CreateElement("Name"); // даём имя
                subElement1.InnerText = sName; // и значение
                element.AppendChild(subElement1); // и указываем кому принадлежит

                XmlNode subElement2 = document.CreateElement("Privilege");
                subElement2.InnerText = sPrivilege.ToString();
                element.AppendChild(subElement2);

                document.Save(myUser.RolesFilePath);
            }
            UpdateRoles();
            //((DataSet)Owner.Controls["DS_Roles"]).Clear();             
            // DS_Roles.Clear();
            //DS_Roles.ReadXml(myUser.RolesFilePath);
            //BS_Roles.DataSource = DS_Roles;
            //BS_Roles.DataMember = "Role";
        }
        private void bOK_Click(object sender, EventArgs e)
        {
            SaveRoles();
            //MessageBox.Show("Информация обновлена", "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SaveRoles();
            //MessageBox.Show("Информация обновлена", "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RolesDialog_Load(object sender, EventArgs e)
        {
            UpdateRoles();
        }

        public void UpdateRoles()
        {
            this.DS_Roles.Clear();
            this.DS_Roles.ReadXml(myUser.RolesFilePath);
            DGV_Roles.DataSource = this.DS_Roles;
            DGV_Roles.DataMember = "Role";

            DGV_Roles.Columns["ID"].DisplayIndex = 0; DGV_Roles.Columns["ID"].HeaderText = "ID";
            DGV_Roles.Columns["ID"].Width = 30; DGV_Roles.Columns["ID"].ReadOnly = true;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            DGV_Roles.Columns["ID"].DefaultCellStyle = dataGridViewCellStyle1;
            
            DGV_Roles.Columns["Name"].DisplayIndex = 1; DGV_Roles.Columns["Name"].HeaderText = "Роль";
            DGV_Roles.Columns["Name"].Width = 160;

            DGV_Roles.Columns["Privilege"].DisplayIndex = 2; DGV_Roles.Columns["Privilege"].HeaderText = "Привелигии";
            DGV_Roles.Columns["Privilege"].Width = 78;
        }


        private void DGV_Roles_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //DGV_Roles.Rows[e.RowIndex].Cells["ID"].Value = DGV_Roles.RowCount;
            DGV_Roles.Rows[e.Row.Index-1].Cells["ID"].Value = DGV_Roles.RowCount-2;
            //e.Row.Cells["ID"].Value = DGV_Roles.RowCount-1;
        }
    }
}
