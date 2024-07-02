namespace mySecurity
{
    partial class ViewUsersDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewUsersDialog));
            this.DGV_Users = new System.Windows.Forms.DataGridView();
            this.cms_Users = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_ChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.DS_Users = new System.Data.DataSet();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.bRoles = new System.Windows.Forms.Button();
            this.dAdd = new System.Windows.Forms.Button();
            this.BS_Roles = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Roles = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Users)).BeginInit();
            this.cms_Users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Users)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Roles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Roles)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Users
            // 
            this.DGV_Users.AllowUserToAddRows = false;
            this.DGV_Users.AllowUserToDeleteRows = false;
            this.DGV_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Users.ContextMenuStrip = this.cms_Users;
            this.DGV_Users.Location = new System.Drawing.Point(0, 0);
            this.DGV_Users.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_Users.Name = "DGV_Users";
            this.DGV_Users.Size = new System.Drawing.Size(700, 295);
            this.DGV_Users.TabIndex = 0;
            this.DGV_Users.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
            // 
            // cms_Users
            // 
            this.cms_Users.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_Users.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ChangePass,
            this.tsmi_Delete});
            this.cms_Users.Name = "cms_Users";
            this.cms_Users.ShowImageMargin = false;
            this.cms_Users.Size = new System.Drawing.Size(315, 68);
            // 
            // tsmi_ChangePass
            // 
            this.tsmi_ChangePass.Name = "tsmi_ChangePass";
            this.tsmi_ChangePass.Size = new System.Drawing.Size(314, 32);
            this.tsmi_ChangePass.Text = "Изменить параметры входа";
            this.tsmi_ChangePass.Click += new System.EventHandler(this.tsmi_ChangePass_Click);
            // 
            // tsmi_Delete
            // 
            this.tsmi_Delete.Name = "tsmi_Delete";
            this.tsmi_Delete.Size = new System.Drawing.Size(314, 32);
            this.tsmi_Delete.Text = "Удалить";
            // 
            // DS_Users
            // 
            this.DS_Users.DataSetName = "NewDataSet";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.Controls.Add(this.bSave, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.bCancel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.bOK, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.bRoles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dAdd, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 297);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 39);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(597, 6);
            this.bSave.Margin = new System.Windows.Forms.Padding(4);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(96, 27);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Применить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(508, 6);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(81, 27);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(402, 6);
            this.bOK.Margin = new System.Windows.Forms.Padding(4);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(98, 27);
            this.bOK.TabIndex = 6;
            this.bOK.Text = "ОК";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bRoles
            // 
            this.bRoles.Location = new System.Drawing.Point(7, 6);
            this.bRoles.Margin = new System.Windows.Forms.Padding(4);
            this.bRoles.Name = "bRoles";
            this.bRoles.Size = new System.Drawing.Size(54, 27);
            this.bRoles.TabIndex = 8;
            this.bRoles.Text = "Роли";
            this.bRoles.UseVisualStyleBackColor = true;
            this.bRoles.Click += new System.EventHandler(this.bRoles_Click);
            // 
            // dAdd
            // 
            this.dAdd.Location = new System.Drawing.Point(132, 6);
            this.dAdd.Margin = new System.Windows.Forms.Padding(4);
            this.dAdd.Name = "dAdd";
            this.dAdd.Size = new System.Drawing.Size(192, 27);
            this.dAdd.TabIndex = 7;
            this.dAdd.Text = "Добавить пользователя";
            this.dAdd.UseVisualStyleBackColor = true;
            this.dAdd.Click += new System.EventHandler(this.dAdd_Click);
            // 
            // BS_Roles
            // 
            this.BS_Roles.DataSource = this.DS_Roles;
            this.BS_Roles.Position = 0;
            // 
            // DS_Roles
            // 
            this.DS_Roles.DataSetName = "NewDataSet";
            // 
            // ViewUsersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 336);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.DGV_Users);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewUsersDialog";
            this.ShowInTaskbar = false;
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.ViewUsersDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Users)).EndInit();
            this.cms_Users.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS_Users)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BS_Roles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Roles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Users;
        private System.Data.DataSet DS_Users;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button dAdd;
        private System.Windows.Forms.Button bRoles;
        private System.Windows.Forms.ContextMenuStrip cms_Users;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ChangePass;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Delete;
        private System.Windows.Forms.BindingSource BS_Roles;
        private System.Data.DataSet DS_Roles;

    }
}