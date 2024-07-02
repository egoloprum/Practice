namespace mySecurity
{
    partial class ChangePassword
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
            this.tbOldPassword = new System.Windows.Forms.TextBox();
            this.lOldPassword = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lLogin = new System.Windows.Forms.Label();
            this.lUser = new System.Windows.Forms.Label();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.lNewPassword = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.lConfirmPassword = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.tbNewLogin = new System.Windows.Forms.TextBox();
            this.lNewLogin = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbOldPassword
            // 
            this.tbOldPassword.Location = new System.Drawing.Point(138, 80);
            this.tbOldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbOldPassword.Name = "tbOldPassword";
            this.tbOldPassword.Size = new System.Drawing.Size(225, 22);
            this.tbOldPassword.TabIndex = 14;
            // 
            // lOldPassword
            // 
            this.lOldPassword.AutoSize = true;
            this.lOldPassword.Location = new System.Drawing.Point(13, 83);
            this.lOldPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lOldPassword.Name = "lOldPassword";
            this.lOldPassword.Size = new System.Drawing.Size(113, 17);
            this.lOldPassword.TabIndex = 13;
            this.lOldPassword.Text = "Старый пароль:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(138, 48);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(225, 22);
            this.tbLogin.TabIndex = 12;
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(13, 51);
            this.lLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(51, 17);
            this.lLogin.TabIndex = 11;
            this.lLogin.Text = "Логин:";
            // 
            // lUser
            // 
            this.lUser.AutoSize = true;
            this.lUser.Location = new System.Drawing.Point(14, 17);
            this.lUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(105, 17);
            this.lUser.TabIndex = 10;
            this.lUser.Text = "Пользователь:";
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Location = new System.Drawing.Point(138, 159);
            this.tbNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(225, 22);
            this.tbNewPassword.TabIndex = 17;
            // 
            // lNewPassword
            // 
            this.lNewPassword.AutoSize = true;
            this.lNewPassword.Location = new System.Drawing.Point(13, 162);
            this.lNewPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lNewPassword.Name = "lNewPassword";
            this.lNewPassword.Size = new System.Drawing.Size(106, 17);
            this.lNewPassword.TabIndex = 16;
            this.lNewPassword.Text = "Новый пароль:";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(138, 192);
            this.tbConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(225, 22);
            this.tbConfirmPassword.TabIndex = 19;
            // 
            // lConfirmPassword
            // 
            this.lConfirmPassword.AutoSize = true;
            this.lConfirmPassword.Location = new System.Drawing.Point(13, 195);
            this.lConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lConfirmPassword.Name = "lConfirmPassword";
            this.lConfirmPassword.Size = new System.Drawing.Size(109, 17);
            this.lConfirmPassword.TabIndex = 18;
            this.lConfirmPassword.Text = "Подтвеждение:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.Controls.Add(this.bCancel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.bOK, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 234);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 39);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(266, 6);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(86, 27);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(144, 6);
            this.bOK.Margin = new System.Windows.Forms.Padding(4);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(98, 27);
            this.bOK.TabIndex = 6;
            this.bOK.Text = "ОК";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // cbUser
            // 
            this.cbUser.AutoCompleteCustomSource.AddRange(new string[] {
            "Администратор",
            "Технолог",
            "Проектировщик",
            "Программист"});
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(138, 14);
            this.cbUser.Margin = new System.Windows.Forms.Padding(4);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(225, 24);
            this.cbUser.TabIndex = 10;
            this.cbUser.DropDown += new System.EventHandler(this.cbUser_DropDown);
            this.cbUser.SelectedIndexChanged += new System.EventHandler(this.cbUser_SelectedIndexChanged);
            // 
            // tbNewLogin
            // 
            this.tbNewLogin.Location = new System.Drawing.Point(139, 125);
            this.tbNewLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbNewLogin.Name = "tbNewLogin";
            this.tbNewLogin.Size = new System.Drawing.Size(225, 22);
            this.tbNewLogin.TabIndex = 22;
            // 
            // lNewLogin
            // 
            this.lNewLogin.AutoSize = true;
            this.lNewLogin.Location = new System.Drawing.Point(13, 128);
            this.lNewLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lNewLogin.Name = "lNewLogin";
            this.lNewLogin.Size = new System.Drawing.Size(96, 17);
            this.lNewLogin.TabIndex = 21;
            this.lNewLogin.Text = "Новый логин:";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 273);
            this.Controls.Add(this.tbNewLogin);
            this.Controls.Add(this.lNewLogin);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.lConfirmPassword);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.lNewPassword);
            this.Controls.Add(this.tbOldPassword);
            this.Controls.Add(this.lOldPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lLogin);
            this.Controls.Add(this.lUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.Text = "Изменение параметров входа";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOldPassword;
        private System.Windows.Forms.Label lOldPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.Label lUser;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Label lNewPassword;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label lConfirmPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.TextBox tbNewLogin;
        private System.Windows.Forms.Label lNewLogin;
    }
}