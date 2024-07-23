namespace MBS
{
    partial class formSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSetting));
            this.btn_ProjectName_Change = new System.Windows.Forms.Button();
            this.textBox_ProjectName = new System.Windows.Forms.TextBox();
            this.btn_ProjectName_Save = new System.Windows.Forms.Button();
            this.label_ProjectName = new System.Windows.Forms.Label();
            this.label_ReportPatch = new System.Windows.Forms.Label();
            this.textBox_ReportPatch = new System.Windows.Forms.TextBox();
            this.btn_ReportPatch_Change = new System.Windows.Forms.Button();
            this.label_ReportConnection = new System.Windows.Forms.Label();
            this.textBox_ReportConnection = new System.Windows.Forms.TextBox();
            this.btn_ReportConnection_Change = new System.Windows.Forms.Button();
            this.btn_ReportConnection_CheckCon = new System.Windows.Forms.Button();
            this.btn_ReportConnection_CreateDB = new System.Windows.Forms.Button();
            this.btn_AlarmConnection_CreateDB = new System.Windows.Forms.Button();
            this.btn_AlarmConnection_CheckCon = new System.Windows.Forms.Button();
            this.label_AlarmConnection = new System.Windows.Forms.Label();
            this.textBox_AlarmConnection = new System.Windows.Forms.TextBox();
            this.btn_AlarmConnection_Change = new System.Windows.Forms.Button();
            this.btn_ProjectName_Cancel = new System.Windows.Forms.Button();
            this.label_Size_Report = new System.Windows.Forms.Label();
            this.textBox_Size_Report = new System.Windows.Forms.TextBox();
            this.btn_UpdateSize_Report = new System.Windows.Forms.Button();
            this.btn_UpdateSize_Alarm = new System.Windows.Forms.Button();
            this.textBox_Size_Alarm = new System.Windows.Forms.TextBox();
            this.label_Size_Alarm = new System.Windows.Forms.Label();
            this.btn_Clear_Report = new System.Windows.Forms.Button();
            this.btn_Clear_Alarm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ProjectName_Change
            // 
            this.btn_ProjectName_Change.Location = new System.Drawing.Point(16, 69);
            this.btn_ProjectName_Change.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ProjectName_Change.Name = "btn_ProjectName_Change";
            this.btn_ProjectName_Change.Size = new System.Drawing.Size(140, 28);
            this.btn_ProjectName_Change.TabIndex = 0;
            this.btn_ProjectName_Change.Text = "Изменить";
            this.btn_ProjectName_Change.UseVisualStyleBackColor = true;
            this.btn_ProjectName_Change.Click += new System.EventHandler(this.btn_ProjectName_Change_Click);
            // 
            // textBox_ProjectName
            // 
            this.textBox_ProjectName.Location = new System.Drawing.Point(16, 37);
            this.textBox_ProjectName.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ProjectName.Name = "textBox_ProjectName";
            this.textBox_ProjectName.ReadOnly = true;
            this.textBox_ProjectName.Size = new System.Drawing.Size(261, 22);
            this.textBox_ProjectName.TabIndex = 1;
            // 
            // btn_ProjectName_Save
            // 
            this.btn_ProjectName_Save.Enabled = false;
            this.btn_ProjectName_Save.Location = new System.Drawing.Point(163, 69);
            this.btn_ProjectName_Save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ProjectName_Save.Name = "btn_ProjectName_Save";
            this.btn_ProjectName_Save.Size = new System.Drawing.Size(116, 28);
            this.btn_ProjectName_Save.TabIndex = 2;
            this.btn_ProjectName_Save.Text = "Сохранить";
            this.btn_ProjectName_Save.UseVisualStyleBackColor = true;
            this.btn_ProjectName_Save.Click += new System.EventHandler(this.btn_ProjectName_Save_Click);
            // 
            // label_ProjectName
            // 
            this.label_ProjectName.AutoSize = true;
            this.label_ProjectName.Location = new System.Drawing.Point(16, 17);
            this.label_ProjectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ProjectName.Name = "label_ProjectName";
            this.label_ProjectName.Size = new System.Drawing.Size(93, 16);
            this.label_ProjectName.TabIndex = 3;
            this.label_ProjectName.Text = "Имя проекта ";
            // 
            // label_ReportPatch
            // 
            this.label_ReportPatch.AutoSize = true;
            this.label_ReportPatch.Location = new System.Drawing.Point(16, 182);
            this.label_ReportPatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ReportPatch.Name = "label_ReportPatch";
            this.label_ReportPatch.Size = new System.Drawing.Size(161, 16);
            this.label_ReportPatch.TabIndex = 7;
            this.label_ReportPatch.Text = "Расположение отчетов";
            // 
            // textBox_ReportPatch
            // 
            this.textBox_ReportPatch.Location = new System.Drawing.Point(16, 202);
            this.textBox_ReportPatch.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ReportPatch.Name = "textBox_ReportPatch";
            this.textBox_ReportPatch.ReadOnly = true;
            this.textBox_ReportPatch.Size = new System.Drawing.Size(261, 22);
            this.textBox_ReportPatch.TabIndex = 5;
            // 
            // btn_ReportPatch_Change
            // 
            this.btn_ReportPatch_Change.Location = new System.Drawing.Point(16, 234);
            this.btn_ReportPatch_Change.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ReportPatch_Change.Name = "btn_ReportPatch_Change";
            this.btn_ReportPatch_Change.Size = new System.Drawing.Size(140, 28);
            this.btn_ReportPatch_Change.TabIndex = 4;
            this.btn_ReportPatch_Change.Text = "Изменить";
            this.btn_ReportPatch_Change.UseVisualStyleBackColor = true;
            this.btn_ReportPatch_Change.Click += new System.EventHandler(this.btn_ReportPatch_Change_Click);
            // 
            // label_ReportConnection
            // 
            this.label_ReportConnection.AutoSize = true;
            this.label_ReportConnection.Location = new System.Drawing.Point(311, 17);
            this.label_ReportConnection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ReportConnection.Name = "label_ReportConnection";
            this.label_ReportConnection.Size = new System.Drawing.Size(258, 16);
            this.label_ReportConnection.TabIndex = 10;
            this.label_ReportConnection.Text = "Настройки подключения в БД отчетов";
            // 
            // textBox_ReportConnection
            // 
            this.textBox_ReportConnection.Location = new System.Drawing.Point(309, 37);
            this.textBox_ReportConnection.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ReportConnection.Name = "textBox_ReportConnection";
            this.textBox_ReportConnection.ReadOnly = true;
            this.textBox_ReportConnection.Size = new System.Drawing.Size(479, 22);
            this.textBox_ReportConnection.TabIndex = 9;
            // 
            // btn_ReportConnection_Change
            // 
            this.btn_ReportConnection_Change.Location = new System.Drawing.Point(309, 103);
            this.btn_ReportConnection_Change.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ReportConnection_Change.Name = "btn_ReportConnection_Change";
            this.btn_ReportConnection_Change.Size = new System.Drawing.Size(230, 28);
            this.btn_ReportConnection_Change.TabIndex = 8;
            this.btn_ReportConnection_Change.Text = "Изменить подключение";
            this.btn_ReportConnection_Change.UseVisualStyleBackColor = true;
            this.btn_ReportConnection_Change.Click += new System.EventHandler(this.btn_ReportConnection_Change_Click);
            // 
            // btn_ReportConnection_CheckCon
            // 
            this.btn_ReportConnection_CheckCon.Location = new System.Drawing.Point(558, 103);
            this.btn_ReportConnection_CheckCon.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ReportConnection_CheckCon.Name = "btn_ReportConnection_CheckCon";
            this.btn_ReportConnection_CheckCon.Size = new System.Drawing.Size(230, 28);
            this.btn_ReportConnection_CheckCon.TabIndex = 11;
            this.btn_ReportConnection_CheckCon.Text = "Проверить подключение";
            this.btn_ReportConnection_CheckCon.UseVisualStyleBackColor = true;
            this.btn_ReportConnection_CheckCon.Click += new System.EventHandler(this.btn_ReportConnection_CheckCon_Click);
            // 
            // btn_ReportConnection_CreateDB
            // 
            this.btn_ReportConnection_CreateDB.Location = new System.Drawing.Point(309, 139);
            this.btn_ReportConnection_CreateDB.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ReportConnection_CreateDB.Name = "btn_ReportConnection_CreateDB";
            this.btn_ReportConnection_CreateDB.Size = new System.Drawing.Size(140, 28);
            this.btn_ReportConnection_CreateDB.TabIndex = 12;
            this.btn_ReportConnection_CreateDB.Text = "Создать БД";
            this.btn_ReportConnection_CreateDB.UseVisualStyleBackColor = true;
            this.btn_ReportConnection_CreateDB.Click += new System.EventHandler(this.btn_ReportConnection_CreateDB_Click);
            // 
            // btn_AlarmConnection_CreateDB
            // 
            this.btn_AlarmConnection_CreateDB.Location = new System.Drawing.Point(309, 358);
            this.btn_AlarmConnection_CreateDB.Margin = new System.Windows.Forms.Padding(4);
            this.btn_AlarmConnection_CreateDB.Name = "btn_AlarmConnection_CreateDB";
            this.btn_AlarmConnection_CreateDB.Size = new System.Drawing.Size(140, 28);
            this.btn_AlarmConnection_CreateDB.TabIndex = 17;
            this.btn_AlarmConnection_CreateDB.Text = "Создать БД";
            this.btn_AlarmConnection_CreateDB.UseVisualStyleBackColor = true;
            this.btn_AlarmConnection_CreateDB.Click += new System.EventHandler(this.btn_AlarmConnection_CreateDB_Click);
            // 
            // btn_AlarmConnection_CheckCon
            // 
            this.btn_AlarmConnection_CheckCon.Location = new System.Drawing.Point(558, 322);
            this.btn_AlarmConnection_CheckCon.Margin = new System.Windows.Forms.Padding(4);
            this.btn_AlarmConnection_CheckCon.Name = "btn_AlarmConnection_CheckCon";
            this.btn_AlarmConnection_CheckCon.Size = new System.Drawing.Size(230, 28);
            this.btn_AlarmConnection_CheckCon.TabIndex = 16;
            this.btn_AlarmConnection_CheckCon.Text = "Проверить подключение";
            this.btn_AlarmConnection_CheckCon.UseVisualStyleBackColor = true;
            this.btn_AlarmConnection_CheckCon.Click += new System.EventHandler(this.btn_AlarmConnection_CheckCon_Click);
            // 
            // label_AlarmConnection
            // 
            this.label_AlarmConnection.AutoSize = true;
            this.label_AlarmConnection.Location = new System.Drawing.Point(311, 234);
            this.label_AlarmConnection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_AlarmConnection.Name = "label_AlarmConnection";
            this.label_AlarmConnection.Size = new System.Drawing.Size(259, 16);
            this.label_AlarmConnection.TabIndex = 15;
            this.label_AlarmConnection.Text = "Настройки подключения в БД событий";
            // 
            // textBox_AlarmConnection
            // 
            this.textBox_AlarmConnection.Location = new System.Drawing.Point(309, 254);
            this.textBox_AlarmConnection.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_AlarmConnection.Name = "textBox_AlarmConnection";
            this.textBox_AlarmConnection.ReadOnly = true;
            this.textBox_AlarmConnection.Size = new System.Drawing.Size(479, 22);
            this.textBox_AlarmConnection.TabIndex = 14;
            // 
            // btn_AlarmConnection_Change
            // 
            this.btn_AlarmConnection_Change.Location = new System.Drawing.Point(308, 322);
            this.btn_AlarmConnection_Change.Margin = new System.Windows.Forms.Padding(4);
            this.btn_AlarmConnection_Change.Name = "btn_AlarmConnection_Change";
            this.btn_AlarmConnection_Change.Size = new System.Drawing.Size(230, 28);
            this.btn_AlarmConnection_Change.TabIndex = 13;
            this.btn_AlarmConnection_Change.Text = "Изменить подключение";
            this.btn_AlarmConnection_Change.UseVisualStyleBackColor = true;
            this.btn_AlarmConnection_Change.Click += new System.EventHandler(this.btn_AlarmConnection_Change_Click);
            // 
            // btn_ProjectName_Cancel
            // 
            this.btn_ProjectName_Cancel.Location = new System.Drawing.Point(16, 69);
            this.btn_ProjectName_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ProjectName_Cancel.Name = "btn_ProjectName_Cancel";
            this.btn_ProjectName_Cancel.Size = new System.Drawing.Size(140, 28);
            this.btn_ProjectName_Cancel.TabIndex = 18;
            this.btn_ProjectName_Cancel.Text = "Отменить";
            this.btn_ProjectName_Cancel.UseVisualStyleBackColor = true;
            this.btn_ProjectName_Cancel.Visible = false;
            this.btn_ProjectName_Cancel.Click += new System.EventHandler(this.btn_ProjectName_Cancel_Click);
            // 
            // label_Size_Report
            // 
            this.label_Size_Report.AutoSize = true;
            this.label_Size_Report.Location = new System.Drawing.Point(305, 73);
            this.label_Size_Report.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Size_Report.Name = "label_Size_Report";
            this.label_Size_Report.Size = new System.Drawing.Size(135, 16);
            this.label_Size_Report.TabIndex = 19;
            this.label_Size_Report.Text = "Размер БД отчетов";
            // 
            // textBox_Size_Report
            // 
            this.textBox_Size_Report.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_Size_Report.Location = new System.Drawing.Point(456, 70);
            this.textBox_Size_Report.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Size_Report.Name = "textBox_Size_Report";
            this.textBox_Size_Report.ReadOnly = true;
            this.textBox_Size_Report.Size = new System.Drawing.Size(185, 22);
            this.textBox_Size_Report.TabIndex = 20;
            // 
            // btn_UpdateSize_Report
            // 
            this.btn_UpdateSize_Report.Location = new System.Drawing.Point(648, 67);
            this.btn_UpdateSize_Report.Margin = new System.Windows.Forms.Padding(4);
            this.btn_UpdateSize_Report.Name = "btn_UpdateSize_Report";
            this.btn_UpdateSize_Report.Size = new System.Drawing.Size(140, 28);
            this.btn_UpdateSize_Report.TabIndex = 21;
            this.btn_UpdateSize_Report.Text = "Обновить";
            this.btn_UpdateSize_Report.UseVisualStyleBackColor = true;
            this.btn_UpdateSize_Report.Click += new System.EventHandler(this.btn_UpdateSize_Report_Click);
            // 
            // btn_UpdateSize_Alarm
            // 
            this.btn_UpdateSize_Alarm.Location = new System.Drawing.Point(649, 286);
            this.btn_UpdateSize_Alarm.Margin = new System.Windows.Forms.Padding(4);
            this.btn_UpdateSize_Alarm.Name = "btn_UpdateSize_Alarm";
            this.btn_UpdateSize_Alarm.Size = new System.Drawing.Size(139, 28);
            this.btn_UpdateSize_Alarm.TabIndex = 24;
            this.btn_UpdateSize_Alarm.Text = "Обновить";
            this.btn_UpdateSize_Alarm.UseVisualStyleBackColor = true;
            this.btn_UpdateSize_Alarm.Click += new System.EventHandler(this.btn_UpdateSize_Alarm_Click);
            // 
            // textBox_Size_Alarm
            // 
            this.textBox_Size_Alarm.Location = new System.Drawing.Point(456, 289);
            this.textBox_Size_Alarm.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Size_Alarm.Name = "textBox_Size_Alarm";
            this.textBox_Size_Alarm.ReadOnly = true;
            this.textBox_Size_Alarm.Size = new System.Drawing.Size(185, 22);
            this.textBox_Size_Alarm.TabIndex = 23;
            // 
            // label_Size_Alarm
            // 
            this.label_Size_Alarm.AutoSize = true;
            this.label_Size_Alarm.Location = new System.Drawing.Point(304, 292);
            this.label_Size_Alarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Size_Alarm.Name = "label_Size_Alarm";
            this.label_Size_Alarm.Size = new System.Drawing.Size(136, 16);
            this.label_Size_Alarm.TabIndex = 22;
            this.label_Size_Alarm.Text = "Размер БД событий";
            // 
            // btn_Clear_Report
            // 
            this.btn_Clear_Report.Location = new System.Drawing.Point(648, 139);
            this.btn_Clear_Report.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Clear_Report.Name = "btn_Clear_Report";
            this.btn_Clear_Report.Size = new System.Drawing.Size(140, 28);
            this.btn_Clear_Report.TabIndex = 25;
            this.btn_Clear_Report.Text = "Очистить БД";
            this.btn_Clear_Report.UseVisualStyleBackColor = true;
            this.btn_Clear_Report.Click += new System.EventHandler(this.btn_Clear_Report_Click);
            // 
            // btn_Clear_Alarm
            // 
            this.btn_Clear_Alarm.Location = new System.Drawing.Point(648, 358);
            this.btn_Clear_Alarm.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Clear_Alarm.Name = "btn_Clear_Alarm";
            this.btn_Clear_Alarm.Size = new System.Drawing.Size(140, 28);
            this.btn_Clear_Alarm.TabIndex = 26;
            this.btn_Clear_Alarm.Text = "Очистить БД";
            this.btn_Clear_Alarm.UseVisualStyleBackColor = true;
            this.btn_Clear_Alarm.Click += new System.EventHandler(this.btn_Clear_Alarm_Click);
            // 
            // formSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(805, 423);
            this.Controls.Add(this.btn_Clear_Alarm);
            this.Controls.Add(this.btn_Clear_Report);
            this.Controls.Add(this.btn_UpdateSize_Alarm);
            this.Controls.Add(this.textBox_Size_Alarm);
            this.Controls.Add(this.label_Size_Alarm);
            this.Controls.Add(this.btn_UpdateSize_Report);
            this.Controls.Add(this.textBox_Size_Report);
            this.Controls.Add(this.label_Size_Report);
            this.Controls.Add(this.btn_ProjectName_Cancel);
            this.Controls.Add(this.btn_AlarmConnection_CreateDB);
            this.Controls.Add(this.btn_AlarmConnection_CheckCon);
            this.Controls.Add(this.label_AlarmConnection);
            this.Controls.Add(this.textBox_AlarmConnection);
            this.Controls.Add(this.btn_AlarmConnection_Change);
            this.Controls.Add(this.btn_ReportConnection_CreateDB);
            this.Controls.Add(this.btn_ReportConnection_CheckCon);
            this.Controls.Add(this.label_ReportConnection);
            this.Controls.Add(this.textBox_ReportConnection);
            this.Controls.Add(this.btn_ReportConnection_Change);
            this.Controls.Add(this.label_ReportPatch);
            this.Controls.Add(this.textBox_ReportPatch);
            this.Controls.Add(this.btn_ReportPatch_Change);
            this.Controls.Add(this.label_ProjectName);
            this.Controls.Add(this.btn_ProjectName_Save);
            this.Controls.Add(this.textBox_ProjectName);
            this.Controls.Add(this.btn_ProjectName_Change);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(823, 470);
            this.Name = "formSetting";
            this.ShowInTaskbar = false;
            this.Text = "Настройка свойств";
            this.Load += new System.EventHandler(this.formSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ProjectName_Change;
        private System.Windows.Forms.TextBox textBox_ProjectName;
        private System.Windows.Forms.Button btn_ProjectName_Save;
        private System.Windows.Forms.Label label_ProjectName;
        private System.Windows.Forms.Label label_ReportPatch;
        private System.Windows.Forms.TextBox textBox_ReportPatch;
        private System.Windows.Forms.Button btn_ReportPatch_Change;
        private System.Windows.Forms.Label label_ReportConnection;
        private System.Windows.Forms.TextBox textBox_ReportConnection;
        private System.Windows.Forms.Button btn_ReportConnection_Change;
        private System.Windows.Forms.Button btn_ReportConnection_CheckCon;
        private System.Windows.Forms.Button btn_ReportConnection_CreateDB;
        private System.Windows.Forms.Button btn_AlarmConnection_CreateDB;
        private System.Windows.Forms.Button btn_AlarmConnection_CheckCon;
        private System.Windows.Forms.Label label_AlarmConnection;
        private System.Windows.Forms.TextBox textBox_AlarmConnection;
        private System.Windows.Forms.Button btn_AlarmConnection_Change;
        private System.Windows.Forms.Button btn_ProjectName_Cancel;
        private System.Windows.Forms.Label label_Size_Report;
        private System.Windows.Forms.TextBox textBox_Size_Report;
        private System.Windows.Forms.Button btn_UpdateSize_Report;
        private System.Windows.Forms.Button btn_UpdateSize_Alarm;
        private System.Windows.Forms.TextBox textBox_Size_Alarm;
        private System.Windows.Forms.Label label_Size_Alarm;
        private System.Windows.Forms.Button btn_Clear_Report;
        private System.Windows.Forms.Button btn_Clear_Alarm;
    }
}
