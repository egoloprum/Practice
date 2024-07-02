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
            this.btn_ReportConnection_Cancel = new System.Windows.Forms.Button();
            this.btn_AlarmConnection_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ProjectName_Change
            // 
            this.btn_ProjectName_Change.Location = new System.Drawing.Point(22, 73);
            this.btn_ProjectName_Change.Name = "btn_ProjectName_Change";
            this.btn_ProjectName_Change.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectName_Change.TabIndex = 0;
            this.btn_ProjectName_Change.Text = "Изменить";
            this.btn_ProjectName_Change.UseVisualStyleBackColor = true;
            this.btn_ProjectName_Change.Click += new System.EventHandler(this.btn_ProjectName_Change_Click);
            // 
            // textBox_ProjectName
            // 
            this.textBox_ProjectName.Location = new System.Drawing.Point(22, 47);
            this.textBox_ProjectName.Name = "textBox_ProjectName";
            this.textBox_ProjectName.ReadOnly = true;
            this.textBox_ProjectName.Size = new System.Drawing.Size(183, 20);
            this.textBox_ProjectName.TabIndex = 1;
            // 
            // btn_ProjectName_Save
            // 
            this.btn_ProjectName_Save.Location = new System.Drawing.Point(103, 73);
            this.btn_ProjectName_Save.Name = "btn_ProjectName_Save";
            this.btn_ProjectName_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectName_Save.TabIndex = 2;
            this.btn_ProjectName_Save.Text = "Сохранить";
            this.btn_ProjectName_Save.UseVisualStyleBackColor = true;
            this.btn_ProjectName_Save.Click += new System.EventHandler(this.btn_ProjectName_Save_Click);
            // 
            // label_ProjectName
            // 
            this.label_ProjectName.AutoSize = true;
            this.label_ProjectName.Location = new System.Drawing.Point(19, 31);
            this.label_ProjectName.Name = "label_ProjectName";
            this.label_ProjectName.Size = new System.Drawing.Size(76, 13);
            this.label_ProjectName.TabIndex = 3;
            this.label_ProjectName.Text = "Имя проекта ";
            // 
            // label_ReportPatch
            // 
            this.label_ReportPatch.AutoSize = true;
            this.label_ReportPatch.Location = new System.Drawing.Point(19, 128);
            this.label_ReportPatch.Name = "label_ReportPatch";
            this.label_ReportPatch.Size = new System.Drawing.Size(124, 13);
            this.label_ReportPatch.TabIndex = 7;
            this.label_ReportPatch.Text = "Расположение отчетов";
            // 
            // textBox_ReportPatch
            // 
            this.textBox_ReportPatch.Location = new System.Drawing.Point(22, 144);
            this.textBox_ReportPatch.Name = "textBox_ReportPatch";
            this.textBox_ReportPatch.ReadOnly = true;
            this.textBox_ReportPatch.Size = new System.Drawing.Size(183, 20);
            this.textBox_ReportPatch.TabIndex = 5;
            // 
            // btn_ReportPatch_Change
            // 
            this.btn_ReportPatch_Change.Location = new System.Drawing.Point(22, 170);
            this.btn_ReportPatch_Change.Name = "btn_ReportPatch_Change";
            this.btn_ReportPatch_Change.Size = new System.Drawing.Size(75, 23);
            this.btn_ReportPatch_Change.TabIndex = 4;
            this.btn_ReportPatch_Change.Text = "Изменить";
            this.btn_ReportPatch_Change.UseVisualStyleBackColor = true;
            this.btn_ReportPatch_Change.Click += new System.EventHandler(this.btn_ReportPatch_Change_Click);
            // 
            // label_ReportConnection
            // 
            this.label_ReportConnection.AutoSize = true;
            this.label_ReportConnection.Location = new System.Drawing.Point(239, 31);
            this.label_ReportConnection.Name = "label_ReportConnection";
            this.label_ReportConnection.Size = new System.Drawing.Size(202, 13);
            this.label_ReportConnection.TabIndex = 10;
            this.label_ReportConnection.Text = "Настройки подключения в БД отчетов";
            // 
            // textBox_ReportConnection
            // 
            this.textBox_ReportConnection.Location = new System.Drawing.Point(242, 47);
            this.textBox_ReportConnection.Name = "textBox_ReportConnection";
            this.textBox_ReportConnection.ReadOnly = true;
            this.textBox_ReportConnection.Size = new System.Drawing.Size(320, 20);
            this.textBox_ReportConnection.TabIndex = 9;
            // 
            // btn_ReportConnection_Change
            // 
            this.btn_ReportConnection_Change.Location = new System.Drawing.Point(242, 73);
            this.btn_ReportConnection_Change.Name = "btn_ReportConnection_Change";
            this.btn_ReportConnection_Change.Size = new System.Drawing.Size(75, 23);
            this.btn_ReportConnection_Change.TabIndex = 8;
            this.btn_ReportConnection_Change.Text = "Изменить";
            this.btn_ReportConnection_Change.UseVisualStyleBackColor = true;
            this.btn_ReportConnection_Change.Click += new System.EventHandler(this.btn_ReportConnection_Change_Click);
            // 
            // btn_ReportConnection_CheckCon
            // 
            this.btn_ReportConnection_CheckCon.Location = new System.Drawing.Point(323, 73);
            this.btn_ReportConnection_CheckCon.Name = "btn_ReportConnection_CheckCon";
            this.btn_ReportConnection_CheckCon.Size = new System.Drawing.Size(145, 23);
            this.btn_ReportConnection_CheckCon.TabIndex = 11;
            this.btn_ReportConnection_CheckCon.Text = "Проверить подключение";
            this.btn_ReportConnection_CheckCon.UseVisualStyleBackColor = true;
            this.btn_ReportConnection_CheckCon.Click += new System.EventHandler(this.btn_ReportConnection_CheckCon_Click);
            // 
            // btn_ReportConnection_CreateDB
            // 
            this.btn_ReportConnection_CreateDB.Location = new System.Drawing.Point(474, 73);
            this.btn_ReportConnection_CreateDB.Name = "btn_ReportConnection_CreateDB";
            this.btn_ReportConnection_CreateDB.Size = new System.Drawing.Size(88, 23);
            this.btn_ReportConnection_CreateDB.TabIndex = 12;
            this.btn_ReportConnection_CreateDB.Text = "Создать БД";
            this.btn_ReportConnection_CreateDB.UseVisualStyleBackColor = true;
            // 
            // btn_AlarmConnection_CreateDB
            // 
            this.btn_AlarmConnection_CreateDB.Location = new System.Drawing.Point(474, 170);
            this.btn_AlarmConnection_CreateDB.Name = "btn_AlarmConnection_CreateDB";
            this.btn_AlarmConnection_CreateDB.Size = new System.Drawing.Size(88, 23);
            this.btn_AlarmConnection_CreateDB.TabIndex = 17;
            this.btn_AlarmConnection_CreateDB.Text = "Создать БД";
            this.btn_AlarmConnection_CreateDB.UseVisualStyleBackColor = true;
            // 
            // btn_AlarmConnection_CheckCon
            // 
            this.btn_AlarmConnection_CheckCon.Location = new System.Drawing.Point(323, 170);
            this.btn_AlarmConnection_CheckCon.Name = "btn_AlarmConnection_CheckCon";
            this.btn_AlarmConnection_CheckCon.Size = new System.Drawing.Size(145, 23);
            this.btn_AlarmConnection_CheckCon.TabIndex = 16;
            this.btn_AlarmConnection_CheckCon.Text = "Проверить подключение";
            this.btn_AlarmConnection_CheckCon.UseVisualStyleBackColor = true;
            this.btn_AlarmConnection_CheckCon.Click += new System.EventHandler(this.btn_AlarmConnection_CheckCon_Click);
            // 
            // label_AlarmConnection
            // 
            this.label_AlarmConnection.AutoSize = true;
            this.label_AlarmConnection.Location = new System.Drawing.Point(239, 128);
            this.label_AlarmConnection.Name = "label_AlarmConnection";
            this.label_AlarmConnection.Size = new System.Drawing.Size(206, 13);
            this.label_AlarmConnection.TabIndex = 15;
            this.label_AlarmConnection.Text = "Настройки подключения в БД событий";
            // 
            // textBox_AlarmConnection
            // 
            this.textBox_AlarmConnection.Location = new System.Drawing.Point(242, 144);
            this.textBox_AlarmConnection.Name = "textBox_AlarmConnection";
            this.textBox_AlarmConnection.ReadOnly = true;
            this.textBox_AlarmConnection.Size = new System.Drawing.Size(320, 20);
            this.textBox_AlarmConnection.TabIndex = 14;
            // 
            // btn_AlarmConnection_Change
            // 
            this.btn_AlarmConnection_Change.Location = new System.Drawing.Point(242, 170);
            this.btn_AlarmConnection_Change.Name = "btn_AlarmConnection_Change";
            this.btn_AlarmConnection_Change.Size = new System.Drawing.Size(75, 23);
            this.btn_AlarmConnection_Change.TabIndex = 13;
            this.btn_AlarmConnection_Change.Text = "Изменить";
            this.btn_AlarmConnection_Change.UseVisualStyleBackColor = true;
            this.btn_AlarmConnection_Change.Click += new System.EventHandler(this.btn_AlarmConnection_Change_Click);
            // 
            // btn_ProjectName_Cancel
            // 
            this.btn_ProjectName_Cancel.Location = new System.Drawing.Point(22, 73);
            this.btn_ProjectName_Cancel.Name = "btn_ProjectName_Cancel";
            this.btn_ProjectName_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_ProjectName_Cancel.TabIndex = 18;
            this.btn_ProjectName_Cancel.Text = "Отменить";
            this.btn_ProjectName_Cancel.UseVisualStyleBackColor = true;
            this.btn_ProjectName_Cancel.Visible = false;
            this.btn_ProjectName_Cancel.Click += new System.EventHandler(this.btn_ProjectName_Cancel_Click);
            // 
            // btn_ReportConnection_Cancel
            // 
            this.btn_ReportConnection_Cancel.Location = new System.Drawing.Point(242, 102);
            this.btn_ReportConnection_Cancel.Name = "btn_ReportConnection_Cancel";
            this.btn_ReportConnection_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_ReportConnection_Cancel.TabIndex = 20;
            this.btn_ReportConnection_Cancel.Text = "Отменить";
            this.btn_ReportConnection_Cancel.UseVisualStyleBackColor = true;
            this.btn_ReportConnection_Cancel.Visible = false;
            // 
            // btn_AlarmConnection_Cancel
            // 
            this.btn_AlarmConnection_Cancel.Location = new System.Drawing.Point(242, 199);
            this.btn_AlarmConnection_Cancel.Name = "btn_AlarmConnection_Cancel";
            this.btn_AlarmConnection_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_AlarmConnection_Cancel.TabIndex = 21;
            this.btn_AlarmConnection_Cancel.Text = "Отменить";
            this.btn_AlarmConnection_Cancel.UseVisualStyleBackColor = true;
            this.btn_AlarmConnection_Cancel.Visible = false;
            // 
            // formSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 293);
            this.Controls.Add(this.btn_AlarmConnection_Cancel);
            this.Controls.Add(this.btn_ReportConnection_Cancel);
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
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(642, 332);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(642, 332);
            this.Name = "formSetting";
            this.ShowInTaskbar = false;
            this.Text = "Настройка свойств";
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
        private System.Windows.Forms.Button btn_ReportConnection_Cancel;
        private System.Windows.Forms.Button btn_AlarmConnection_Cancel;
    }
}