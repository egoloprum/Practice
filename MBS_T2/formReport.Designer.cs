using System.Security.Cryptography.X509Certificates;

namespace MBS
{
    partial class formReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formReport));
            this.dsReport = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rvViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BS = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.SuspendLayout();
            // 
            // dsReport
            // 
            this.dsReport.DataSetName = "NewDataSet";
            this.dsReport.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "View_Order";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rvViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1151, 684);
            this.panel1.TabIndex = 0;
            // 
            // rvViewer
            // 
            this.rvViewer.AutoSize = true;
            this.rvViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rvViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvViewer.LocalReport.DisplayName = "fsfdfsf";
            this.rvViewer.LocalReport.ReportEmbeddedResource = "MBS.Report2.rdlc";
            this.rvViewer.LocalReport.ReportPath = "Report2.rdlc";
            this.rvViewer.Location = new System.Drawing.Point(0, 0);
            this.rvViewer.Name = "rvViewer";
            this.rvViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.rvViewer.ServerReport.BearerToken = null;
            this.rvViewer.ShowBackButton = false;
            this.rvViewer.ShowExportButton = false;
            this.rvViewer.ShowRefreshButton = false;
            this.rvViewer.ShowStopButton = false;
            this.rvViewer.Size = new System.Drawing.Size(1151, 684);
            this.rvViewer.TabIndex = 0;
            this.rvViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // formReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 684);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formReport";
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.formReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Data.DataSet dsReport;
        private System.Data.DataTable dataTable1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource BS;
        public Microsoft.Reporting.WinForms.ReportViewer rvViewer;
    }
}