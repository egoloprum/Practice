namespace MBS
{
    partial class formClearDB
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
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.radioBtn_Oneyear = new System.Windows.Forms.RadioButton();
            this.radioBtn_TillDate = new System.Windows.Forms.RadioButton();
            this.radioBtn_Twoyear = new System.Windows.Forms.RadioButton();
            this.dateTimePicker_TillDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Oneyear = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Twoyear = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(21, 265);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(265, 28);
            this.btn_Clear.TabIndex = 28;
            this.btn_Clear.Text = "Очистить";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(20, 301);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(265, 28);
            this.btn_Close.TabIndex = 27;
            this.btn_Close.Text = "Отмена";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // radioBtn_Oneyear
            // 
            this.radioBtn_Oneyear.AutoSize = true;
            this.radioBtn_Oneyear.Location = new System.Drawing.Point(22, 104);
            this.radioBtn_Oneyear.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtn_Oneyear.Name = "radioBtn_Oneyear";
            this.radioBtn_Oneyear.Size = new System.Drawing.Size(120, 20);
            this.radioBtn_Oneyear.TabIndex = 30;
            this.radioBtn_Oneyear.Text = "Старше 1 года";
            this.radioBtn_Oneyear.UseVisualStyleBackColor = true;
            this.radioBtn_Oneyear.CheckedChanged += new System.EventHandler(this.radioBtn_Oneyear_CheckedChanged);
            // 
            // radioBtn_TillDate
            // 
            this.radioBtn_TillDate.AutoSize = true;
            this.radioBtn_TillDate.Checked = true;
            this.radioBtn_TillDate.Location = new System.Drawing.Point(22, 36);
            this.radioBtn_TillDate.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtn_TillDate.Name = "radioBtn_TillDate";
            this.radioBtn_TillDate.Size = new System.Drawing.Size(154, 20);
            this.radioBtn_TillDate.TabIndex = 29;
            this.radioBtn_TillDate.TabStop = true;
            this.radioBtn_TillDate.Text = "До указанной даты";
            this.radioBtn_TillDate.UseVisualStyleBackColor = true;
            this.radioBtn_TillDate.CheckedChanged += new System.EventHandler(this.radioBtn_TillDate_CheckedChanged);
            // 
            // radioBtn_Twoyear
            // 
            this.radioBtn_Twoyear.AutoSize = true;
            this.radioBtn_Twoyear.Location = new System.Drawing.Point(20, 171);
            this.radioBtn_Twoyear.Margin = new System.Windows.Forms.Padding(4);
            this.radioBtn_Twoyear.Name = "radioBtn_Twoyear";
            this.radioBtn_Twoyear.Size = new System.Drawing.Size(113, 20);
            this.radioBtn_Twoyear.TabIndex = 31;
            this.radioBtn_Twoyear.Text = "Старше 2 лет";
            this.radioBtn_Twoyear.UseVisualStyleBackColor = true;
            this.radioBtn_Twoyear.CheckedChanged += new System.EventHandler(this.radioBtn_Twoyear_CheckedChanged);
            // 
            // dateTimePicker_TillDate
            // 
            this.dateTimePicker_TillDate.Location = new System.Drawing.Point(21, 63);
            this.dateTimePicker_TillDate.Name = "dateTimePicker_TillDate";
            this.dateTimePicker_TillDate.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker_TillDate.TabIndex = 32;
            // 
            // dateTimePicker_Oneyear
            // 
            this.dateTimePicker_Oneyear.Enabled = false;
            this.dateTimePicker_Oneyear.Location = new System.Drawing.Point(21, 131);
            this.dateTimePicker_Oneyear.Name = "dateTimePicker_Oneyear";
            this.dateTimePicker_Oneyear.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker_Oneyear.TabIndex = 33;
            // 
            // dateTimePicker_Twoyear
            // 
            this.dateTimePicker_Twoyear.Enabled = false;
            this.dateTimePicker_Twoyear.Location = new System.Drawing.Point(20, 198);
            this.dateTimePicker_Twoyear.Name = "dateTimePicker_Twoyear";
            this.dateTimePicker_Twoyear.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker_Twoyear.TabIndex = 34;
            // 
            // formClearDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 373);
            this.Controls.Add(this.dateTimePicker_Twoyear);
            this.Controls.Add(this.dateTimePicker_Oneyear);
            this.Controls.Add(this.dateTimePicker_TillDate);
            this.Controls.Add(this.radioBtn_Twoyear);
            this.Controls.Add(this.radioBtn_Oneyear);
            this.Controls.Add(this.radioBtn_TillDate);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Close);
            this.MaximumSize = new System.Drawing.Size(325, 420);
            this.MinimumSize = new System.Drawing.Size(325, 420);
            this.Name = "formClearDB";
            this.Text = "Очистка БД";
            this.Load += new System.EventHandler(this.formClearDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.RadioButton radioBtn_Oneyear;
        private System.Windows.Forms.RadioButton radioBtn_TillDate;
        private System.Windows.Forms.RadioButton radioBtn_Twoyear;
        private System.Windows.Forms.DateTimePicker dateTimePicker_TillDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Oneyear;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Twoyear;
    }
}
