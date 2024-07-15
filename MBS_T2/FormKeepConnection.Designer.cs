namespace MBS
{
    partial class formKeepConnection
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
            this.btn_KeepConn = new System.Windows.Forms.Button();
            this.btn_CloseConn = new System.Windows.Forms.Button();
            this.label_keepConn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_KeepConn
            // 
            this.btn_KeepConn.Location = new System.Drawing.Point(24, 149);
            this.btn_KeepConn.Margin = new System.Windows.Forms.Padding(4);
            this.btn_KeepConn.Name = "btn_KeepConn";
            this.btn_KeepConn.Size = new System.Drawing.Size(235, 27);
            this.btn_KeepConn.TabIndex = 5;
            this.btn_KeepConn.Text = "Да - Сохраняем подключение";
            this.btn_KeepConn.UseVisualStyleBackColor = true;
            this.btn_KeepConn.Click += new System.EventHandler(this.btn_KeepConn_Click);
            // 
            // btn_CloseConn
            // 
            this.btn_CloseConn.Location = new System.Drawing.Point(24, 184);
            this.btn_CloseConn.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CloseConn.Name = "btn_CloseConn";
            this.btn_CloseConn.Size = new System.Drawing.Size(235, 27);
            this.btn_CloseConn.TabIndex = 6;
            this.btn_CloseConn.Text = "Нет - Выходим без подключение";
            this.btn_CloseConn.UseVisualStyleBackColor = true;
            this.btn_CloseConn.Click += new System.EventHandler(this.btn_CloseConn_Click);
            // 
            // label_keepConn
            // 
            this.label_keepConn.AutoSize = true;
            this.label_keepConn.Location = new System.Drawing.Point(21, 34);
            this.label_keepConn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_keepConn.Name = "label_keepConn";
            this.label_keepConn.Size = new System.Drawing.Size(244, 16);
            this.label_keepConn.TabIndex = 7;
            this.label_keepConn.Text = "Вы хотите сохранить подключение ?";
            // 
            // formKeepConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 230);
            this.Controls.Add(this.label_keepConn);
            this.Controls.Add(this.btn_CloseConn);
            this.Controls.Add(this.btn_KeepConn);
            this.MinimumSize = new System.Drawing.Size(305, 277);
            this.Name = "formKeepConnection";
            this.Text = "Сохранить подключение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_KeepConn;
        private System.Windows.Forms.Button btn_CloseConn;
        private System.Windows.Forms.Label label_keepConn;
    }
}
