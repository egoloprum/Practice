namespace mySecurity
{
    partial class AddUserDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserDialog));
            this.bOK = new System.Windows.Forms.Button();
            this.nCancel = new System.Windows.Forms.Button();
            this.lUser = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lLogin = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.lRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.lConfirmPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bOK
            // 
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Location = new System.Drawing.Point(95, 208);
            this.bOK.Margin = new System.Windows.Forms.Padding(4);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(100, 28);
            this.bOK.TabIndex = 0;
            this.bOK.Text = "ОК";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // nCancel
            // 
            this.nCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.nCancel.Location = new System.Drawing.Point(222, 208);
            this.nCancel.Margin = new System.Windows.Forms.Padding(4);
            this.nCancel.Name = "nCancel";
            this.nCancel.Size = new System.Drawing.Size(100, 28);
            this.nCancel.TabIndex = 1;
            this.nCancel.Text = "Отмена";
            this.nCancel.UseVisualStyleBackColor = true;
            // 
            // lUser
            // 
            this.lUser.AutoSize = true;
            this.lUser.Location = new System.Drawing.Point(16, 23);
            this.lUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(39, 17);
            this.lUser.TabIndex = 2;
            this.lUser.Text = "Имя:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(97, 23);
            this.tbUser.Margin = new System.Windows.Forms.Padding(4);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(225, 22);
            this.tbUser.TabIndex = 3;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(97, 53);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(225, 22);
            this.tbLogin.TabIndex = 5;
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(16, 53);
            this.lLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(51, 17);
            this.lLogin.TabIndex = 4;
            this.lLogin.Text = "Логин:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(128, 127);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(194, 22);
            this.tbPassword.TabIndex = 7;
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(16, 127);
            this.lPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(61, 17);
            this.lPassword.TabIndex = 6;
            this.lPassword.Text = "Пароль:";
            // 
            // lRole
            // 
            this.lRole.AutoSize = true;
            this.lRole.Location = new System.Drawing.Point(16, 86);
            this.lRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lRole.Name = "lRole";
            this.lRole.Size = new System.Drawing.Size(44, 17);
            this.lRole.TabIndex = 8;
            this.lRole.Text = "Роль:";
            // 
            // cbRole
            // 
            this.cbRole.AutoCompleteCustomSource.AddRange(new string[] {
            "Гость",
            "Технолог",
            "Проектировщик",
            "Программист",
            "Администратор"});
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Гость",
            "Технолог",
            "Проектировщик",
            "Программист",
            "Администратор"});
            this.cbRole.Location = new System.Drawing.Point(97, 83);
            this.cbRole.Margin = new System.Windows.Forms.Padding(4);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(225, 24);
            this.cbRole.TabIndex = 9;
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(128, 157);
            this.tbConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(194, 22);
            this.tbConfirmPassword.TabIndex = 21;
            // 
            // lConfirmPassword
            // 
            this.lConfirmPassword.AutoSize = true;
            this.lConfirmPassword.Location = new System.Drawing.Point(18, 160);
            this.lConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lConfirmPassword.Name = "lConfirmPassword";
            this.lConfirmPassword.Size = new System.Drawing.Size(109, 17);
            this.lConfirmPassword.TabIndex = 20;
            this.lConfirmPassword.Text = "Подтвеждение:";
            // 
            // AddUserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 249);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.lConfirmPassword);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lLogin);
            this.Controls.Add(this.lUser);
            this.Controls.Add(this.lRole);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.nCancel);
            this.Controls.Add(this.bOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserDialog";
            this.ShowInTaskbar = false;
            this.Text = "Добавление пользователя";
            this.Load += new System.EventHandler(this.AddUserDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button nCancel;
        private System.Windows.Forms.Label lUser;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.Label lRole;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label lConfirmPassword;
    }
}