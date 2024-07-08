namespace MBS
{
    partial class formCreateDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCreateDB));
            this.label_NameDB = new System.Windows.Forms.Label();
            this.label_User = new System.Windows.Forms.Label();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label_TypeDBMS = new System.Windows.Forms.Label();
            this.comboBox_TypeDBMS = new System.Windows.Forms.ComboBox();
            this.btn_CreateDB = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.comboBox_NameServer = new System.Windows.Forms.ComboBox();
            this.label_NameServer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton_Windows = new System.Windows.Forms.RadioButton();
            this.radioButton_SQLserver = new System.Windows.Forms.RadioButton();
            this.label_ConDB = new System.Windows.Forms.Label();
            this.btn_TestConn = new System.Windows.Forms.Button();
            this.comboBox_NameDB = new System.Windows.Forms.ComboBox();
            this.comboBox_TypeDB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_NameDB
            // 
            this.label_NameDB.AutoSize = true;
            this.label_NameDB.Enabled = false;
            this.label_NameDB.Location = new System.Drawing.Point(14, 290);
            this.label_NameDB.Name = "label_NameDB";
            this.label_NameDB.Size = new System.Drawing.Size(76, 13);
            this.label_NameDB.TabIndex = 0;
            this.label_NameDB.Text = "Название БД";
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Enabled = false;
            this.label_User.Location = new System.Drawing.Point(17, 202);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(80, 13);
            this.label_User.TabIndex = 1;
            this.label_User.Text = "Пользователь";
            // 
            // textBox_Username
            // 
            this.textBox_Username.Enabled = false;
            this.textBox_Username.Location = new System.Drawing.Point(117, 199);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(232, 20);
            this.textBox_Username.TabIndex = 3;
            this.textBox_Username.TextChanged += new System.EventHandler(this.textBox_Username_TextChanged);
            // 
            // label_TypeDBMS
            // 
            this.label_TypeDBMS.AutoSize = true;
            this.label_TypeDBMS.Location = new System.Drawing.Point(23, 12);
            this.label_TypeDBMS.Name = "label_TypeDBMS";
            this.label_TypeDBMS.Size = new System.Drawing.Size(60, 13);
            this.label_TypeDBMS.TabIndex = 4;
            this.label_TypeDBMS.Text = "Тип СУБД";
            // 
            // comboBox_TypeDBMS
            // 
            this.comboBox_TypeDBMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TypeDBMS.FormattingEnabled = true;
            this.comboBox_TypeDBMS.Items.AddRange(new object[] {
            "MS Server"});
            this.comboBox_TypeDBMS.Location = new System.Drawing.Point(17, 28);
            this.comboBox_TypeDBMS.Name = "comboBox_TypeDBMS";
            this.comboBox_TypeDBMS.Size = new System.Drawing.Size(332, 21);
            this.comboBox_TypeDBMS.TabIndex = 8;
            this.comboBox_TypeDBMS.DropDown += new System.EventHandler(this.comboBox_TypeDBMS_DropDown);
            this.comboBox_TypeDBMS.TextChanged += new System.EventHandler(this.comboBox_TypeDBMS_TextChanged);
            // 
            // btn_CreateDB
            // 
            this.btn_CreateDB.Enabled = false;
            this.btn_CreateDB.Location = new System.Drawing.Point(206, 322);
            this.btn_CreateDB.Name = "btn_CreateDB";
            this.btn_CreateDB.Size = new System.Drawing.Size(76, 23);
            this.btn_CreateDB.TabIndex = 12;
            this.btn_CreateDB.Text = "Создать";
            this.btn_CreateDB.UseVisualStyleBackColor = true;
            this.btn_CreateDB.Click += new System.EventHandler(this.btn_CreateDB_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(288, 322);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(61, 23);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "Отмена";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Enabled = false;
            this.textBox_Password.Location = new System.Drawing.Point(117, 225);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(232, 20);
            this.textBox_Password.TabIndex = 15;
            this.textBox_Password.UseSystemPasswordChar = true;
            this.textBox_Password.TextChanged += new System.EventHandler(this.textBox_Password_TextChanged);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Enabled = false;
            this.label_Password.Location = new System.Drawing.Point(17, 228);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(45, 13);
            this.label_Password.TabIndex = 14;
            this.label_Password.Text = "Пароль";
            // 
            // comboBox_NameServer
            // 
            this.comboBox_NameServer.FormattingEnabled = true;
            this.comboBox_NameServer.Location = new System.Drawing.Point(17, 69);
            this.comboBox_NameServer.Name = "comboBox_NameServer";
            this.comboBox_NameServer.Size = new System.Drawing.Size(332, 21);
            this.comboBox_NameServer.TabIndex = 17;
            this.comboBox_NameServer.DropDown += new System.EventHandler(this.comboBox_NameServer_DropDown);
            this.comboBox_NameServer.TextChanged += new System.EventHandler(this.comboBox_NameServer_TextChanged);
            // 
            // label_NameServer
            // 
            this.label_NameServer.AutoSize = true;
            this.label_NameServer.Location = new System.Drawing.Point(23, 53);
            this.label_NameServer.Name = "label_NameServer";
            this.label_NameServer.Size = new System.Drawing.Size(74, 13);
            this.label_NameServer.TabIndex = 16;
            this.label_NameServer.Text = "Имя сервера";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Логин в сервер";
            // 
            // radioButton_Windows
            // 
            this.radioButton_Windows.AutoSize = true;
            this.radioButton_Windows.Checked = true;
            this.radioButton_Windows.Location = new System.Drawing.Point(40, 153);
            this.radioButton_Windows.Name = "radioButton_Windows";
            this.radioButton_Windows.Size = new System.Drawing.Size(69, 17);
            this.radioButton_Windows.TabIndex = 19;
            this.radioButton_Windows.TabStop = true;
            this.radioButton_Windows.Text = "Windows";
            this.radioButton_Windows.UseVisualStyleBackColor = true;
            this.radioButton_Windows.CheckedChanged += new System.EventHandler(this.radioButton_Windows_CheckedChanged);
            // 
            // radioButton_SQLserver
            // 
            this.radioButton_SQLserver.AutoSize = true;
            this.radioButton_SQLserver.Location = new System.Drawing.Point(40, 173);
            this.radioButton_SQLserver.Name = "radioButton_SQLserver";
            this.radioButton_SQLserver.Size = new System.Drawing.Size(78, 17);
            this.radioButton_SQLserver.TabIndex = 20;
            this.radioButton_SQLserver.Text = "SQL server";
            this.radioButton_SQLserver.UseVisualStyleBackColor = true;
            this.radioButton_SQLserver.CheckedChanged += new System.EventHandler(this.radioButton_SQLserver_CheckedChanged);
            // 
            // label_ConDB
            // 
            this.label_ConDB.AutoSize = true;
            this.label_ConDB.Enabled = false;
            this.label_ConDB.Location = new System.Drawing.Point(23, 263);
            this.label_ConDB.Name = "label_ConDB";
            this.label_ConDB.Size = new System.Drawing.Size(104, 13);
            this.label_ConDB.TabIndex = 21;
            this.label_ConDB.Text = "Подключение к БД";
            // 
            // btn_TestConn
            // 
            this.btn_TestConn.Enabled = false;
            this.btn_TestConn.Location = new System.Drawing.Point(12, 322);
            this.btn_TestConn.Name = "btn_TestConn";
            this.btn_TestConn.Size = new System.Drawing.Size(142, 23);
            this.btn_TestConn.TabIndex = 22;
            this.btn_TestConn.Text = "Проверить подключение";
            this.btn_TestConn.UseVisualStyleBackColor = true;
            this.btn_TestConn.Click += new System.EventHandler(this.btn_TestConn_Click);
            // 
            // comboBox_NameDB
            // 
            this.comboBox_NameDB.Enabled = false;
            this.comboBox_NameDB.FormattingEnabled = true;
            this.comboBox_NameDB.Location = new System.Drawing.Point(117, 287);
            this.comboBox_NameDB.Name = "comboBox_NameDB";
            this.comboBox_NameDB.Size = new System.Drawing.Size(232, 21);
            this.comboBox_NameDB.TabIndex = 23;
            this.comboBox_NameDB.DropDown += new System.EventHandler(this.comboBox_NameDB_DropDown);
            this.comboBox_NameDB.TextChanged += new System.EventHandler(this.comboBox_NameDB_TextChanged);
            // 
            // comboBox_TypeDB
            // 
            this.comboBox_TypeDB.DisplayMember = "qweqw";
            this.comboBox_TypeDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TypeDB.FormattingEnabled = true;
            this.comboBox_TypeDB.Items.AddRange(new object[] {
            "События",
            "Отчеты"});
            this.comboBox_TypeDB.Location = new System.Drawing.Point(17, 109);
            this.comboBox_TypeDB.Name = "comboBox_TypeDB";
            this.comboBox_TypeDB.Size = new System.Drawing.Size(332, 21);
            this.comboBox_TypeDB.TabIndex = 25;
            this.comboBox_TypeDB.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Тип БД";
            // 
            // formCreateDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 361);
            this.Controls.Add(this.comboBox_TypeDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_NameDB);
            this.Controls.Add(this.btn_TestConn);
            this.Controls.Add(this.label_ConDB);
            this.Controls.Add(this.radioButton_SQLserver);
            this.Controls.Add(this.radioButton_Windows);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_NameServer);
            this.Controls.Add(this.label_NameServer);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_CreateDB);
            this.Controls.Add(this.comboBox_TypeDBMS);
            this.Controls.Add(this.label_TypeDBMS);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.label_NameDB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(380, 400);
            this.Name = "formCreateDB";
            this.Text = "Создание нового проекта";
            this.Load += new System.EventHandler(this.formCreateDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_NameDB;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Label label_TypeDBMS;
        private System.Windows.Forms.ComboBox comboBox_TypeDBMS;
        private System.Windows.Forms.Button btn_CreateDB;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.ComboBox comboBox_NameServer;
        private System.Windows.Forms.Label label_NameServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton_Windows;
        private System.Windows.Forms.RadioButton radioButton_SQLserver;
        private System.Windows.Forms.Label label_ConDB;
        private System.Windows.Forms.Button btn_TestConn;
        private System.Windows.Forms.ComboBox comboBox_NameDB;
        private System.Windows.Forms.ComboBox comboBox_TypeDB;
        private System.Windows.Forms.Label label1;
    }
}