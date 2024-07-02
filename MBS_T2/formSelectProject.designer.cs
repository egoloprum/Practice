namespace MBS
{


    partial class formSelectProject
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>


        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSelectProject));
            this.textBoxProjectID = new System.Windows.Forms.TextBox();
            this.textBoxProjectShortName = new System.Windows.Forms.TextBox();
            this.textBoxProjectFullName = new System.Windows.Forms.TextBox();
            this.labelProjectID = new System.Windows.Forms.Label();
            this.labelProjectShortName = new System.Windows.Forms.Label();
            this.labelProjectFullName = new System.Windows.Forms.Label();
            this.buttonCreateProject = new System.Windows.Forms.Button();
            this.buttonChancel = new System.Windows.Forms.Button();
            this.labelProjectPassword = new System.Windows.Forms.Label();
            this.textBoxProjectPassword = new System.Windows.Forms.TextBox();
            this.labelProjectPath = new System.Windows.Forms.Label();
            this.textBoxProjectPath = new System.Windows.Forms.TextBox();
            this.labelDBType = new System.Windows.Forms.Label();
            this.comboBoxProjectBDMode = new System.Windows.Forms.ComboBox();
            this.tabControl_SelectProject = new System.Windows.Forms.TabControl();
            this.contextMenuStripConnections = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DelConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DelProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SetDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageExistingProject = new System.Windows.Forms.TabPage();
            this.DGV_ProjectInfo = new System.Windows.Forms.DataGridView();
            this.lblNewConnection = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewConnect = new System.Windows.Forms.Button();
            this.tabPageNewProject = new System.Windows.Forms.TabPage();
            this.comboBoxSQLServers = new System.Windows.Forms.ComboBox();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.DS_ProjectInfo = new System.Data.DataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.lConnStr_Alarm = new System.Windows.Forms.Label();
            this.bConnStr_Alarm = new System.Windows.Forms.Button();
            this.tabControl_SelectProject.SuspendLayout();
            this.contextMenuStripConnections.SuspendLayout();
            this.tabPageExistingProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProjectInfo)).BeginInit();
            this.tabPageNewProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_ProjectInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxProjectID
            // 
            this.textBoxProjectID.AccessibleDescription = "Введите название БД (обязательно, только аглийские буквы)";
            this.textBoxProjectID.ForeColor = System.Drawing.Color.Gray;
            this.textBoxProjectID.Location = new System.Drawing.Point(169, 7);
            this.textBoxProjectID.Name = "textBoxProjectID";
            this.textBoxProjectID.Size = new System.Drawing.Size(151, 20);
            this.textBoxProjectID.TabIndex = 0;
            this.textBoxProjectID.Tag = "";
            this.textBoxProjectID.Text = "MBS_T2";
            this.textBoxProjectID.Click += new System.EventHandler(this.TextBox_Click);
            this.textBoxProjectID.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // textBoxProjectShortName
            // 
            this.textBoxProjectShortName.AccessibleDescription = "Введите наименование проекта (технологической линии)";
            this.textBoxProjectShortName.ForeColor = System.Drawing.Color.Gray;
            this.textBoxProjectShortName.Location = new System.Drawing.Point(144, 82);
            this.textBoxProjectShortName.Name = "textBoxProjectShortName";
            this.textBoxProjectShortName.Size = new System.Drawing.Size(465, 20);
            this.textBoxProjectShortName.TabIndex = 1;
            this.textBoxProjectShortName.Text = "МБС Л2";
            this.textBoxProjectShortName.Click += new System.EventHandler(this.TextBox_Click);
            this.textBoxProjectShortName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // textBoxProjectFullName
            // 
            this.textBoxProjectFullName.AccessibleDescription = "Введите подробное описание (не обязательно)";
            this.textBoxProjectFullName.ForeColor = System.Drawing.Color.Gray;
            this.textBoxProjectFullName.Location = new System.Drawing.Point(144, 108);
            this.textBoxProjectFullName.MaximumSize = new System.Drawing.Size(451, 60);
            this.textBoxProjectFullName.MinimumSize = new System.Drawing.Size(465, 60);
            this.textBoxProjectFullName.Multiline = true;
            this.textBoxProjectFullName.Name = "textBoxProjectFullName";
            this.textBoxProjectFullName.Size = new System.Drawing.Size(465, 60);
            this.textBoxProjectFullName.TabIndex = 2;
            this.textBoxProjectFullName.Text = "МБС. Линия 2";
            this.textBoxProjectFullName.Click += new System.EventHandler(this.TextBox_Click);
            this.textBoxProjectFullName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // labelProjectID
            // 
            this.labelProjectID.AutoSize = true;
            this.labelProjectID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelProjectID.Location = new System.Drawing.Point(6, 9);
            this.labelProjectID.Name = "labelProjectID";
            this.labelProjectID.Size = new System.Drawing.Size(166, 13);
            this.labelProjectID.TabIndex = 5;
            this.labelProjectID.Text = "Идентификатор (название БД):";
            // 
            // labelProjectShortName
            // 
            this.labelProjectShortName.AutoSize = true;
            this.labelProjectShortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelProjectShortName.Location = new System.Drawing.Point(6, 85);
            this.labelProjectShortName.Name = "labelProjectShortName";
            this.labelProjectShortName.Size = new System.Drawing.Size(129, 13);
            this.labelProjectShortName.TabIndex = 6;
            this.labelProjectShortName.Text = "Краткое наименование:";
            // 
            // labelProjectFullName
            // 
            this.labelProjectFullName.AutoSize = true;
            this.labelProjectFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelProjectFullName.Location = new System.Drawing.Point(6, 111);
            this.labelProjectFullName.Name = "labelProjectFullName";
            this.labelProjectFullName.Size = new System.Drawing.Size(125, 13);
            this.labelProjectFullName.TabIndex = 7;
            this.labelProjectFullName.Text = "Полное наименование:";
            // 
            // buttonCreateProject
            // 
            this.buttonCreateProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateProject.Location = new System.Drawing.Point(462, 236);
            this.buttonCreateProject.Name = "buttonCreateProject";
            this.buttonCreateProject.Size = new System.Drawing.Size(89, 23);
            this.buttonCreateProject.TabIndex = 11;
            this.buttonCreateProject.Text = "Создать";
            this.buttonCreateProject.UseVisualStyleBackColor = true;
            this.buttonCreateProject.Click += new System.EventHandler(this.buttonCreateProject_Click);
            // 
            // buttonChancel
            // 
            this.buttonChancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChancel.Location = new System.Drawing.Point(557, 236);
            this.buttonChancel.Name = "buttonChancel";
            this.buttonChancel.Size = new System.Drawing.Size(55, 23);
            this.buttonChancel.TabIndex = 12;
            this.buttonChancel.Text = "Отмена";
            this.buttonChancel.UseVisualStyleBackColor = true;
            this.buttonChancel.Click += new System.EventHandler(this.buttonChancel_Click);
            // 
            // labelProjectPassword
            // 
            this.labelProjectPassword.AutoSize = true;
            this.labelProjectPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelProjectPassword.Location = new System.Drawing.Point(347, 9);
            this.labelProjectPassword.Name = "labelProjectPassword";
            this.labelProjectPassword.Size = new System.Drawing.Size(48, 13);
            this.labelProjectPassword.TabIndex = 14;
            this.labelProjectPassword.Text = "Пароль:";
            // 
            // textBoxProjectPassword
            // 
            this.textBoxProjectPassword.AccessibleDescription = "Введите пароль пользователя";
            this.textBoxProjectPassword.ForeColor = System.Drawing.Color.Gray;
            this.textBoxProjectPassword.Location = new System.Drawing.Point(401, 7);
            this.textBoxProjectPassword.Name = "textBoxProjectPassword";
            this.textBoxProjectPassword.Size = new System.Drawing.Size(211, 20);
            this.textBoxProjectPassword.TabIndex = 13;
            this.textBoxProjectPassword.Text = "sa123456";
            this.textBoxProjectPassword.Click += new System.EventHandler(this.TextBox_Click);
            this.textBoxProjectPassword.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // labelProjectPath
            // 
            this.labelProjectPath.AutoSize = true;
            this.labelProjectPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelProjectPath.Location = new System.Drawing.Point(226, 35);
            this.labelProjectPath.Name = "labelProjectPath";
            this.labelProjectPath.Size = new System.Drawing.Size(98, 13);
            this.labelProjectPath.TabIndex = 16;
            this.labelProjectPath.Text = "Источник данных:";
            // 
            // textBoxProjectPath
            // 
            this.textBoxProjectPath.AccessibleDescription = "";
            this.textBoxProjectPath.ForeColor = System.Drawing.Color.Gray;
            this.textBoxProjectPath.Location = new System.Drawing.Point(327, 33);
            this.textBoxProjectPath.Name = "textBoxProjectPath";
            this.textBoxProjectPath.Size = new System.Drawing.Size(259, 20);
            this.textBoxProjectPath.TabIndex = 15;
            this.textBoxProjectPath.Text = "E:\\Projects\\";
            this.textBoxProjectPath.Click += new System.EventHandler(this.TextBox_Click);
            this.textBoxProjectPath.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // labelDBType
            // 
            this.labelDBType.AutoSize = true;
            this.labelDBType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelDBType.Location = new System.Drawing.Point(6, 36);
            this.labelDBType.Name = "labelDBType";
            this.labelDBType.Size = new System.Drawing.Size(48, 13);
            this.labelDBType.TabIndex = 19;
            this.labelDBType.Text = "Тип БД:";
            // 
            // comboBoxProjectBDMode
            // 
            this.comboBoxProjectBDMode.ForeColor = System.Drawing.Color.Gray;
            this.comboBoxProjectBDMode.FormattingEnabled = true;
            this.comboBoxProjectBDMode.Items.AddRange(new object[] {
            "БД SQL Server",
            "Локальная БД (*.mdb)"});
            this.comboBoxProjectBDMode.Location = new System.Drawing.Point(66, 33);
            this.comboBoxProjectBDMode.Name = "comboBoxProjectBDMode";
            this.comboBoxProjectBDMode.Size = new System.Drawing.Size(145, 21);
            this.comboBoxProjectBDMode.TabIndex = 20;
            this.comboBoxProjectBDMode.Text = "БД SQL Server";
            this.comboBoxProjectBDMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjectBDMode_SelectedIndexChanged);
            // 
            // tabControl_SelectProject
            // 
            this.tabControl_SelectProject.ContextMenuStrip = this.contextMenuStripConnections;
            this.tabControl_SelectProject.Controls.Add(this.tabPageExistingProject);
            this.tabControl_SelectProject.Controls.Add(this.tabPageNewProject);
            this.tabControl_SelectProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_SelectProject.Location = new System.Drawing.Point(0, 0);
            this.tabControl_SelectProject.Name = "tabControl_SelectProject";
            this.tabControl_SelectProject.SelectedIndex = 0;
            this.tabControl_SelectProject.Size = new System.Drawing.Size(626, 293);
            this.tabControl_SelectProject.TabIndex = 22;
            this.tabControl_SelectProject.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_SelectProject_Selected);
            // 
            // contextMenuStripConnections
            // 
            this.contextMenuStripConnections.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripConnections.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Open,
            this.toolStripMenuItem_SaveAs,
            this.toolStripMenuItem_DelConnection,
            this.toolStripMenuItem_DelProject,
            this.toolStripMenuItem_SetDefault});
            this.contextMenuStripConnections.Name = "contextMenuStripConnections";
            this.contextMenuStripConnections.Size = new System.Drawing.Size(240, 114);
            // 
            // toolStripMenuItem_Open
            // 
            this.toolStripMenuItem_Open.Name = "toolStripMenuItem_Open";
            this.toolStripMenuItem_Open.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_Open.Text = "Открыть";
            this.toolStripMenuItem_Open.Click += new System.EventHandler(this.toolStripMenuItem_Open_Click);
            // 
            // toolStripMenuItem_SaveAs
            // 
            this.toolStripMenuItem_SaveAs.Name = "toolStripMenuItem_SaveAs";
            this.toolStripMenuItem_SaveAs.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_SaveAs.Text = "Сохранить как...";
            // 
            // toolStripMenuItem_DelConnection
            // 
            this.toolStripMenuItem_DelConnection.Name = "toolStripMenuItem_DelConnection";
            this.toolStripMenuItem_DelConnection.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_DelConnection.Text = "Удалить подключение";
            this.toolStripMenuItem_DelConnection.Click += new System.EventHandler(this.toolStripMenuItem_DelConnection_Click);
            // 
            // toolStripMenuItem_DelProject
            // 
            this.toolStripMenuItem_DelProject.Name = "toolStripMenuItem_DelProject";
            this.toolStripMenuItem_DelProject.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_DelProject.Text = "Удалить проект";
            this.toolStripMenuItem_DelProject.Click += new System.EventHandler(this.toolStripMenuItem_DelProject_Click);
            // 
            // toolStripMenuItem_SetDefault
            // 
            this.toolStripMenuItem_SetDefault.Name = "toolStripMenuItem_SetDefault";
            this.toolStripMenuItem_SetDefault.Size = new System.Drawing.Size(239, 22);
            this.toolStripMenuItem_SetDefault.Text = "Использовать по-умолчанию";
            this.toolStripMenuItem_SetDefault.Click += new System.EventHandler(this.toolStripMenuItem_SetDefault_Click);
            // 
            // tabPageExistingProject
            // 
            this.tabPageExistingProject.AutoScroll = true;
            this.tabPageExistingProject.Controls.Add(this.bConnStr_Alarm);
            this.tabPageExistingProject.Controls.Add(this.lConnStr_Alarm);
            this.tabPageExistingProject.Controls.Add(this.label2);
            this.tabPageExistingProject.Controls.Add(this.DGV_ProjectInfo);
            this.tabPageExistingProject.Controls.Add(this.lblNewConnection);
            this.tabPageExistingProject.Controls.Add(this.label1);
            this.tabPageExistingProject.Controls.Add(this.btnNewConnect);
            this.tabPageExistingProject.Location = new System.Drawing.Point(4, 22);
            this.tabPageExistingProject.Name = "tabPageExistingProject";
            this.tabPageExistingProject.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageExistingProject.Size = new System.Drawing.Size(618, 267);
            this.tabPageExistingProject.TabIndex = 0;
            this.tabPageExistingProject.Text = "Подключение к существующему проекту";
            this.tabPageExistingProject.UseVisualStyleBackColor = true;
            // 
            // DGV_ProjectInfo
            // 
            this.DGV_ProjectInfo.AllowUserToAddRows = false;
            this.DGV_ProjectInfo.AllowUserToDeleteRows = false;
            this.DGV_ProjectInfo.AllowUserToOrderColumns = true;
            this.DGV_ProjectInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ProjectInfo.Location = new System.Drawing.Point(6, 29);
            this.DGV_ProjectInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DGV_ProjectInfo.Name = "DGV_ProjectInfo";
            this.DGV_ProjectInfo.ReadOnly = true;
            this.DGV_ProjectInfo.RowTemplate.Height = 24;
            this.DGV_ProjectInfo.Size = new System.Drawing.Size(606, 120);
            this.DGV_ProjectInfo.TabIndex = 7;
            this.DGV_ProjectInfo.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_ProjectInfo_CellMouseDoubleClick);
            this.DGV_ProjectInfo.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
            // 
            // lblNewConnection
            // 
            this.lblNewConnection.AutoSize = true;
            this.lblNewConnection.Location = new System.Drawing.Point(7, 163);
            this.lblNewConnection.Name = "lblNewConnection";
            this.lblNewConnection.Size = new System.Drawing.Size(291, 13);
            this.lblNewConnection.TabIndex = 4;
            this.lblNewConnection.Text = "Или добавьте новое подключение к существующей БД:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите из существующих подключений:";
            // 
            // btnNewConnect
            // 
            this.btnNewConnect.Location = new System.Drawing.Point(329, 158);
            this.btnNewConnect.Name = "btnNewConnect";
            this.btnNewConnect.Size = new System.Drawing.Size(284, 23);
            this.btnNewConnect.TabIndex = 1;
            this.btnNewConnect.Text = "Добавить новое подключение к существующей БД";
            this.btnNewConnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewConnect.UseVisualStyleBackColor = true;
            this.btnNewConnect.Click += new System.EventHandler(this.btnNewConnect_Click);
            // 
            // tabPageNewProject
            // 
            this.tabPageNewProject.Controls.Add(this.comboBoxSQLServers);
            this.tabPageNewProject.Controls.Add(this.buttonSelectFolder);
            this.tabPageNewProject.Controls.Add(this.textBoxProjectID);
            this.tabPageNewProject.Controls.Add(this.labelProjectPassword);
            this.tabPageNewProject.Controls.Add(this.labelProjectID);
            this.tabPageNewProject.Controls.Add(this.textBoxProjectShortName);
            this.tabPageNewProject.Controls.Add(this.labelProjectShortName);
            this.tabPageNewProject.Controls.Add(this.textBoxProjectPath);
            this.tabPageNewProject.Controls.Add(this.comboBoxProjectBDMode);
            this.tabPageNewProject.Controls.Add(this.textBoxProjectPassword);
            this.tabPageNewProject.Controls.Add(this.textBoxProjectFullName);
            this.tabPageNewProject.Controls.Add(this.labelProjectFullName);
            this.tabPageNewProject.Controls.Add(this.buttonCreateProject);
            this.tabPageNewProject.Controls.Add(this.labelProjectPath);
            this.tabPageNewProject.Controls.Add(this.labelDBType);
            this.tabPageNewProject.Controls.Add(this.buttonChancel);
            this.tabPageNewProject.Location = new System.Drawing.Point(4, 22);
            this.tabPageNewProject.Name = "tabPageNewProject";
            this.tabPageNewProject.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageNewProject.Size = new System.Drawing.Size(616, 262);
            this.tabPageNewProject.TabIndex = 1;
            this.tabPageNewProject.Text = "Создание нового проекта";
            this.tabPageNewProject.UseVisualStyleBackColor = true;
            // 
            // comboBoxSQLServers
            // 
            this.comboBoxSQLServers.ForeColor = System.Drawing.Color.Gray;
            this.comboBoxSQLServers.FormattingEnabled = true;
            this.comboBoxSQLServers.Location = new System.Drawing.Point(327, 32);
            this.comboBoxSQLServers.Name = "comboBoxSQLServers";
            this.comboBoxSQLServers.Size = new System.Drawing.Size(259, 21);
            this.comboBoxSQLServers.TabIndex = 23;
            this.comboBoxSQLServers.Text = "(local)\\SQLEXPRESS";
            this.comboBoxSQLServers.DropDown += new System.EventHandler(this.comboBoxSQLServers_DropDown);
            this.comboBoxSQLServers.SelectedIndexChanged += new System.EventHandler(this.comboBoxSQLServers_SelectedIndexChanged);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(586, 31);
            this.buttonSelectFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(26, 20);
            this.buttonSelectFolder.TabIndex = 21;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // DS_ProjectInfo
            // 
            this.DS_ProjectInfo.DataSetName = "NewDataSet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Подключение к БД событий (WinCC Alarm):";
            // 
            // lConnStr_Alarm
            // 
            this.lConnStr_Alarm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lConnStr_Alarm.Location = new System.Drawing.Point(11, 205);
            this.lConnStr_Alarm.Name = "lConnStr_Alarm";
            this.lConnStr_Alarm.Size = new System.Drawing.Size(561, 23);
            this.lConnStr_Alarm.TabIndex = 9;
            // 
            // bConnStr_Alarm
            // 
            this.bConnStr_Alarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bConnStr_Alarm.Location = new System.Drawing.Point(574, 205);
            this.bConnStr_Alarm.Name = "bConnStr_Alarm";
            this.bConnStr_Alarm.Size = new System.Drawing.Size(36, 23);
            this.bConnStr_Alarm.TabIndex = 10;
            this.bConnStr_Alarm.Text = "...";
            this.bConnStr_Alarm.UseVisualStyleBackColor = true;
            this.bConnStr_Alarm.Click += new System.EventHandler(this.bConnStr_Alarm_Click);
            // 
            // formSelectProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 293);
            this.Controls.Add(this.tabControl_SelectProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(642, 332);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(642, 332);
            this.Name = "formSelectProject";
            this.ShowInTaskbar = false;
            this.Text = "Добавление нового проекта";
            this.Load += new System.EventHandler(this.formSelectProject_Load);
            this.Shown += new System.EventHandler(this.formSelectProject_Shown);
            this.tabControl_SelectProject.ResumeLayout(false);
            this.contextMenuStripConnections.ResumeLayout(false);
            this.tabPageExistingProject.ResumeLayout(false);
            this.tabPageExistingProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProjectInfo)).EndInit();
            this.tabPageNewProject.ResumeLayout(false);
            this.tabPageNewProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_ProjectInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProjectID;
        private System.Windows.Forms.TextBox textBoxProjectShortName;
        private System.Windows.Forms.TextBox textBoxProjectFullName;
        private System.Windows.Forms.Label labelProjectID;
        private System.Windows.Forms.Label labelProjectShortName;
        private System.Windows.Forms.Label labelProjectFullName;
        private System.Windows.Forms.Button buttonCreateProject;
        private System.Windows.Forms.Button buttonChancel;
        private System.Windows.Forms.Label labelProjectPassword;
        private System.Windows.Forms.TextBox textBoxProjectPassword;
        private System.Windows.Forms.Label labelProjectPath;
        private System.Windows.Forms.TextBox textBoxProjectPath;
        private System.Windows.Forms.Label labelDBType;
        private System.Windows.Forms.ComboBox comboBoxProjectBDMode;
        public System.Windows.Forms.TabControl tabControl_SelectProject;
        private System.Windows.Forms.TabPage tabPageExistingProject;
        private System.Windows.Forms.TabPage tabPageNewProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewConnect;
        private System.Windows.Forms.Label lblNewConnection;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripConnections;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Open;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DelConnection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DelProject;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.ComboBox comboBoxSQLServers;
        private System.Data.DataSet DS_ProjectInfo;
        private System.Windows.Forms.DataGridView DGV_ProjectInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SetDefault;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lConnStr_Alarm;
        private System.Windows.Forms.Button bConnStr_Alarm;
    }
}

