using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using System.Configuration;


namespace MBS
{
    public partial class formSelectProject : Form
    {
        public formSelectProject()
        {
            InitializeComponent();
        }

        Point point = new Point();
        private void dataGridView_CellMouseEnter(
            object sender, DataGridViewCellEventArgs ee)
        {

            point.X = ee.ColumnIndex;
            point.Y = ee.RowIndex;
        }  

        private void TextBox_Click(object sender, EventArgs e)
        {
            if (((TextBox)sender).ForeColor!=System.Drawing.Color.Black){
                ((TextBox)sender).ForeColor = System.Drawing.Color.Black;
                ((TextBox)sender).Text = "";
            }
        }

        private void buttonChancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
        private void buttonCreateProject_Click(object sender, EventArgs e)
        {
            string
                ID = this.textBoxProjectID.Text,            
                Password = this.textBoxProjectPassword.Text,
                Path,
                ShortName = this.textBoxProjectShortName.Text,
                FullName = this.textBoxProjectFullName.Text;
                short Mode = (short)this.comboBoxProjectBDMode.SelectedIndex;
                switch (Mode)
                {
                    case 0:
                        //БД SQLServer
                        Path = this.comboBoxSQLServers.Text;

                        break;
                    case 1:
                        //локальная БД *.mdf
                        Path = this.textBoxProjectPath.Text;
                        break;
                    default:
                        Path = this.comboBoxSQLServers.Text;
                        break;
                }
            int ErrorCode=SQLControls.AddNewDB(ID, ShortName, FullName, Password, Path, Mode);
            if (ErrorCode == 0) {
                //сохраняем информацию в файл
                ProjectInfo Project = new ProjectInfo(SQLControls.CurrentConnection.Database, SQLControls.CurrentConnection.ConnectionString);
                Project.Name = ShortName;
                Project.Description = FullName;
                Project.Save();
                UpdateProjects();
                this.Close();
            }
        }

        private void comboBoxProjectBDMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            short Mode = (short)this.comboBoxProjectBDMode.SelectedIndex;

            this.comboBoxProjectBDMode.ForeColor = System.Drawing.Color.Black;
            {
                switch (Mode)
                {
                    case 0:
                        //БД SQLServer
                        this.textBoxProjectPath.Visible = false;
                        this.buttonSelectFolder.Visible = false;
                        this.labelProjectPath.Text = "Источник данных:";
                        this.comboBoxSQLServers.Visible = true;
                        if (this.comboBoxSQLServers.ForeColor == System.Drawing.Color.Gray)
                        {
                            this.comboBoxSQLServers.Text = ProjectSettings.DefaultSQLServer;
                        }
                        
                        break;
                    case 1:
                        //локальная БД *.mdf
                        this.textBoxProjectPath.Visible = true;
                        this.buttonSelectFolder.Visible = true;
                        this.labelProjectPath.Text = "Папка проекта:";
                        this.comboBoxSQLServers.Visible = false;                    
                        if (this.textBoxProjectPath.ForeColor == System.Drawing.Color.Gray)
                        {
                            this.textBoxProjectPath.Text = ProjectSettings.DefaultPath;
                        }
                        break;
                    default:
                        this.textBoxProjectPath.Visible = false;
                        this.buttonSelectFolder.Visible = false;
                        this.labelProjectPath.Text = "Источник данных:";
                        this.comboBoxSQLServers.Visible = true;
                        if (this.comboBoxSQLServers.ForeColor == System.Drawing.Color.Gray)
                        {
                            this.comboBoxSQLServers.Text = ProjectSettings.DefaultSQLServer;
                        }
                    break;
                }
            }        
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            string sName=((TextBox)sender).Name;
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).ForeColor = System.Drawing.Color.Gray;
                ((TextBox)sender).Text = ((TextBox)sender).AccessibleDescription;//("Inital" + sName.Replace("textBox",""));
            }
        }

        private void btnNewConnect_Click(object sender, EventArgs e)
        {
            int ErrCode=0;
            try {
                ErrCode = SQLControls.GetConnectionString("ReportConnectionString");
                if (ErrCode == 0) {
                    ErrCode = SQLControls.ConnectDB(SQLControls.ConnectionString);
                    if (ErrCode == 0) {
                        ProjectInfo Project = new ProjectInfo(SQLControls.CurrentConnection.Database, SQLControls.CurrentConnection.ConnectionString);
                        Project.Name = SQLControls.GetProjectInfo(SQLControls.CurrentConnection.ConnectionString, "ShortName");
                        Project.Description = SQLControls.GetProjectInfo(SQLControls.CurrentConnection.ConnectionString, "FullName");
                        Project.Save();
                        UpdateProjects();
                        //ErrCode = SQLControls.AddInfoToModelProject(SQLControls.ConnectionString);
                        //if (ErrCode == 0) {
                        //this.projectInfoTableAdapter.Fill(this.projectsDataSet.ProjectInfo);
                        //MessageBox.Show("Проект подключен", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //}
                    }

                }                            
            }
            catch (System.Exception ex)//catch (SqlException ex )          
            {
               MessageBox.Show(ex.Message, "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
            }

        }

        private void tabControl_SelectProject_Selected(object sender, TabControlEventArgs e)
        {
            this.Text = tabControl_SelectProject.SelectedTab.Text;
        }

        private void formSelectProject_Shown(object sender, EventArgs e)
        {
            this.Text = tabControl_SelectProject.SelectedTab.Text;
        }

        private void formSelectProject_Load(object sender, EventArgs e)
        {
            UpdateProjects();
            this.textBoxProjectPath.Visible = false;
            this.buttonSelectFolder.Visible = false;
            this.comboBoxSQLServers.Visible = true;
            this.btnNewConnect.Enabled = (ProgramSettings.Role >= 4);
            this.tabControl_SelectProject.Enabled = (ProgramSettings.Role >= 4);
            lConnStr_Alarm.Text = Properties.Settings.Default.AlarmConnectionString;


        }

        private void toolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            if (point.X >= 0 && point.Y >= 0)
            {
                SQLControls.ConnectionString = this.DGV_ProjectInfo["ConnectionString", point.Y].Value.ToString();
                SQLControls.ConnectDB(SQLControls.ConnectionString);
            }
        }

        private void toolStripMenuItem_DelConnection_Click(object sender, EventArgs e)
        {
            if (point.X >= 0 && point.Y >= 0)
            {
                string sDB = this.DGV_ProjectInfo.Rows[point.Y].Cells["ID"].Value.ToString();
                string sN = this.DGV_ProjectInfo.Rows[point.Y].Cells["Name"].Value.ToString();
                string sD = this.DGV_ProjectInfo.Rows[point.Y].Cells["Description"].Value.ToString();
                string sCS = this.DGV_ProjectInfo.Rows[point.Y].Cells["ConnectionString"].Value.ToString();
                ProjectInfo Project = new ProjectInfo(sDB, sCS);
                Project.Delete();
                UpdateProjects();
                //this.projectInfoDataGridView.Rows.RemoveAt(point.Y);
                //this.projectInfoTableAdapter.Update(projectsDataSet);
            }
        }

        private void toolStripMenuItem_DelProject_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Вы уверены, что хотите удалить проект? Востановление удаленного проекта не возможно!", "Удаление проекта", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (SQLControls.DeleteDateBase(this.DGV_ProjectInfo["ConnectionString", point.Y].Value.ToString()) == 0)
                {
                    string sDB = this.DGV_ProjectInfo.Rows[point.Y].Cells["ID"].Value.ToString();
                    string sN = this.DGV_ProjectInfo.Rows[point.Y].Cells["Name"].Value.ToString();
                    string sD = this.DGV_ProjectInfo.Rows[point.Y].Cells["Description"].Value.ToString();
                    string sCS = this.DGV_ProjectInfo.Rows[point.Y].Cells["ConnectionString"].Value.ToString();
                    ProjectInfo Project = new ProjectInfo(sDB, sCS);
                    Project.Delete();
                    UpdateProjects();
                }
            }
            
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK) {
                this.textBoxProjectPath.Text = FBD.SelectedPath + "\\";  
                this.textBoxProjectPath.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void comboBoxSQLServers_DropDown(object sender, EventArgs e)
        {//See more at: http://www.csharpcoderr.com/2015/03/Finding-SQL-Servers-on-the-Network.html#sthash.zQsrUdPT.dpuf
            //Предварительно очищаем все элементы управления в которые будут выводиться данные
            //comboBoxSQLServers.Items.Clear();
            //Получение доступных SQL серверов.
            string[] theAvailableSqlServers = SqlLocator.GetServers();
            if (theAvailableSqlServers != null)
            {
                comboBoxSQLServers.DataSource = theAvailableSqlServers;
            }
            else
            {
                MessageBox.Show("SQL сервера не найдены!");
            }
        }

        private void comboBoxSQLServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxProjectPath.Text = this.comboBoxSQLServers.SelectedText;
            this.comboBoxSQLServers.ForeColor = System.Drawing.Color.Black;
        }

        public void UpdateProjects()
        {
            int i;
            DS_ProjectInfo.Clear();
            DS_ProjectInfo.ReadXml(ProjectInfo.FilePath);
            DGV_ProjectInfo.DataSource = DS_ProjectInfo;

            DGV_ProjectInfo.DataMember = "Project";
            DGV_ProjectInfo.Columns["ID"].HeaderText = "Проект";
            DGV_ProjectInfo.Columns["ID"].DisplayIndex = 0;
            DGV_ProjectInfo.Columns["ID"].Width = 95;
            DGV_ProjectInfo.Columns["ConnectionString"].HeaderText = "Строка подключения";
            DGV_ProjectInfo.Columns["ConnectionString"].DisplayIndex = 1;
            DGV_ProjectInfo.Columns["ConnectionString"].Width = 300;
            DGV_ProjectInfo.Columns["Name"].HeaderText = "Наименование";
            DGV_ProjectInfo.Columns["Name"].DisplayIndex = 2;
            DGV_ProjectInfo.Columns["Name"].Width = 100;
            DGV_ProjectInfo.Columns["Description"].HeaderText = "Описание";
            DGV_ProjectInfo.Columns["Description"].DisplayIndex = 3;
            DGV_ProjectInfo.Columns["Description"].Width = 150;
            DGV_ProjectInfo.Columns["Default"].HeaderText = "Автозапуск";
            DGV_ProjectInfo.Columns["Default"].DisplayIndex = 4;
            DGV_ProjectInfo.Columns["Default"].Width = 120;
            for (i = 0; i < DGV_ProjectInfo.Rows.Count; i++)
            {
                if (DGV_ProjectInfo[3, i].Value.ToString()=="1")
                    DGV_ProjectInfo[3, i].Value = "Да";
                else  DGV_ProjectInfo[3, i].Value = "";
            }
        }


        private void DGV_ProjectInfo_CellMouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                SQLControls.ConnectionString = ((DataGridView)sender)["ConnectionString", e.RowIndex].Value.ToString();
                SQLControls.ConnectDB(SQLControls.ConnectionString);
                this.Close();
            }
        }

        private void toolStripMenuItem_SetDefault_Click(object sender, EventArgs e)
        {
                    string sDB = this.DGV_ProjectInfo.Rows[point.Y].Cells["ID"].Value.ToString();
                    string sCS = this.DGV_ProjectInfo.Rows[point.Y].Cells["ConnectionString"].Value.ToString();
                    ProjectInfo Project = new ProjectInfo(sDB, sCS);
                    Project.SetDefault();
                    UpdateProjects();

        }

        private void bConnStr_Alarm_Click(object sender, EventArgs e)
        {
            int ErrCode = 0;
            try
            {
                ErrCode = SQLControls.GetConnectionString("AlarmConnectionString");
                if (ErrCode == 0)
                {
                    ErrCode = SQLControls.ConnectDB(SQLControls.ConnectionString);
                    if (ErrCode == 0)
                    {
                        //Properties.Settings.Default.AlarmConnectionString = SQLControls.CurrentConnection.ConnectionString;
                        //Properties.Settings.Default.Save(); // Сохраняем переменные.

                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                        connectionStringsSection.ConnectionStrings["MBS.Properties.Settings.AlarmConnectionString"].ConnectionString = SQLControls.CurrentConnection.ConnectionString;
                        config.Save();
                        ConfigurationManager.RefreshSection("connectionStrings");
                        lConnStr_Alarm.Text = Properties.Settings.Default.AlarmConnectionString;
                    }


                }
            }
            catch (System.Exception ex)//catch (SqlException ex )          
            {
                MessageBox.Show(ex.Message, "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
            }

        }

    }
}
