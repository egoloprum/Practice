namespace mySecurity
{
    partial class RolesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolesDialog));
            this.DGV_Roles = new System.Windows.Forms.DataGridView();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.DS_Roles = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Roles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Roles)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Roles
            // 
            this.DGV_Roles.AllowUserToOrderColumns = true;
            this.DGV_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Roles.Location = new System.Drawing.Point(13, 13);
            this.DGV_Roles.Margin = new System.Windows.Forms.Padding(4);
            this.DGV_Roles.Name = "DGV_Roles";
            this.DGV_Roles.Size = new System.Drawing.Size(415, 259);
            this.DGV_Roles.TabIndex = 1;
            this.DGV_Roles.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DGV_Roles_UserAddedRow);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(332, 280);
            this.bSave.Margin = new System.Windows.Forms.Padding(4);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(96, 27);
            this.bSave.TabIndex = 7;
            this.bSave.Text = "Применить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(243, 280);
            this.bCancel.Margin = new System.Windows.Forms.Padding(4);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(81, 27);
            this.bCancel.TabIndex = 8;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(137, 280);
            this.bOK.Margin = new System.Windows.Forms.Padding(4);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(98, 27);
            this.bOK.TabIndex = 9;
            this.bOK.Text = "ОК";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // DS_Roles
            // 
            this.DS_Roles.DataSetName = "NewDataSet";
            // 
            // RolesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 312);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.DGV_Roles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RolesDialog";
            this.Text = "Роли";
            this.Load += new System.EventHandler(this.RolesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Roles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Roles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Roles;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
        private System.Data.DataSet DS_Roles;
    }
}