namespace mySecurity
{
    partial class LoginDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDialog));
            this.bOK = new System.Windows.Forms.Button();
            this.nCancel = new System.Windows.Forms.Button();
            this.lUser = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lLogin = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(97, 137);
            this.bOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.nCancel.Location = new System.Drawing.Point(224, 137);
            this.nCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nCancel.Name = "nCancel";
            this.nCancel.Size = new System.Drawing.Size(100, 28);
            this.nCancel.TabIndex = 1;
            this.nCancel.Text = "Отмена";
            this.nCancel.UseVisualStyleBackColor = true;
            this.nCancel.Click += new System.EventHandler(this.nCancel_Click);
            // 
            // lUser
            // 
            this.lUser.AutoSize = true;
            this.lUser.Location = new System.Drawing.Point(16, 26);
            this.lUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(39, 17);
            this.lUser.TabIndex = 2;
            this.lUser.Text = "Имя:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(97, 54);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(225, 22);
            this.tbLogin.TabIndex = 5;
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Location = new System.Drawing.Point(16, 58);
            this.lLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(51, 17);
            this.lLogin.TabIndex = 4;
            this.lLogin.Text = "Логин:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(97, 91);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(225, 22);
            this.tbPassword.TabIndex = 7;
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(16, 95);
            this.lPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(61, 17);
            this.lPassword.TabIndex = 6;
            this.lPassword.Text = "Пароль:";
            // 
            // cbUser
            // 
            this.cbUser.AutoCompleteCustomSource.AddRange(new string[] {
            "Администратор",
            "Технолог",
            "Проектировщик",
            "Программист"});
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(97, 22);
            this.cbUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(225, 24);
            this.cbUser.TabIndex = 9;
            this.cbUser.DropDown += new System.EventHandler(this.cbUser_DropDown);
            this.cbUser.SelectedIndexChanged += new System.EventHandler(this.cbUser_SelectedIndexChanged);
            // 
            // LoginDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 178);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.lLogin);
            this.Controls.Add(this.lUser);
            this.Controls.Add(this.nCancel);
            this.Controls.Add(this.bOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginDialog";
            this.ShowInTaskbar = false;
            this.Text = "Авторизация пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button nCancel;
        private System.Windows.Forms.Label lUser;
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.TextBox tbPassword;




    }
}