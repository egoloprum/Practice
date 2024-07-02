using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Reporting.WinForms;
using System.Xml;
using Microsoft.Office.Interop.Word;
using Microsoft.ReportingServices.Interfaces;
using System.Drawing.Printing;
using System.Net.NetworkInformation;

namespace MBS
{
    public partial class EDGV : UserControl
    {
        public string TableName;
        public string Request;
        public Boolean EnableEdit =false;
        //public Boolean EditButtonEnabled = false;
        int k = 0;
        DataSet DS = new DataSet();
        SqlCommandBuilder cmdBuilder;
        public BindingSource BS = new BindingSource();
        SqlDataAdapter DA;
        System.Data.DataTable DTBuffer = new System.Data.DataTable();
        //Point point = new Point();
        public event EventHandler ExportExcell;
        public event EventHandler ExportHTML;
        public event EventHandler MakeReport;
        //public SqlConnection SqlConn = new SqlConnection();
        public string SqlConnStr;
        formReport fReport;
        public EDGV()
        {
            InitializeComponent();
        }
        public void LoadTable()
        {
            try
            {
                UpdateTable();
                this.DGV.DataSource = this.BS;
                this.BN.BindingSource = this.BS;

                //устанавливаем ширину бокового элемента
                this.DGV.RowHeadersWidth = 30;
                //разрешаем копирование
                this.DGV.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                //формат даты и времени
                foreach (DataGridViewColumn dgvColumn in this.DGV.Columns)
                {
                    if (dgvColumn.ValueType == typeof(DateTime)) dgvColumn.DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss.fff";
                    dgvColumn.HeaderText = GetDescription(TableName, dgvColumn.HeaderText, 1);
                }
                //автоподбор ширины столбцов
                ResizeTable();
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }
        }

        private void ResizeTable()
        {
            int runningWidthUsed = 0;
            try
            {
                if (this.DGV.ColumnCount > 0)
                {
                    //автоподбор ширины столбцов
                    this.DGV.AutoResizeColumns();

                    //подбор ширины последнего стоблца по ширину окна
                    runningWidthUsed += this.DGV.RowHeadersWidth + this.DGV.Margin.Left + this.DGV.VerticalScrollingOffset;
                    for (int i = 0; i < this.DGV.ColumnCount; i++)
                        runningWidthUsed += this.DGV.Columns[i].Width;


                    if (this.Width > runningWidthUsed)
                    {
                        int Delta = this.Width - runningWidthUsed-20;
                        this.DGV.Columns[this.DGV.ColumnCount - 1].Width += Delta;
                    }
                }
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }
        }

        private string GetDescription(string TableName, string ColumnName, int DescriptionMode)
        {

            string sColumnTitle = ColumnName;
            try
            {
                if (DescriptionMode == 1)
                {

                    XmlNode RequestNode = null;
                    XmlDocument SQLRequestXML = new XmlDocument();
                    SQLRequestXML.Load("SettingsXML/SQLRequest.xml");

                    RequestNode = SQLRequestXML.DocumentElement.SelectSingleNode("//Request[@ID='" + TableName + "']");
                    if (RequestNode != null)
                    {
                        XmlNode ColumnNameNode = RequestNode.SelectSingleNode("//column[@name='" + ColumnName + "']");
                        if (ColumnNameNode != null)
                        {
                            if (ColumnNameNode.Attributes["title"].Value != null)
                                sColumnTitle = ColumnNameNode.Attributes["title"].Value.ToString();
                        }
                    }
                }
                return sColumnTitle;
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return "null";
            }
            finally
            {

            }
        }

        public int UpdateTable()
        {
            string SelectCommand = Request;
            SqlConnection SqlConn = new SqlConnection(SqlConnStr);
            try
            {
                if (DS.Tables.Contains(TableName)) { DS.Tables[TableName].Clear(); }
                this.DA = new SqlDataAdapter(SelectCommand, SqlConn);
                cmdBuilder = new SqlCommandBuilder(DA);
                this.DA.Fill(DS, TableName);
                BS.DataSource = DS;
                BS.DataMember = TableName;
                GetSumm();
                return 0;
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return ex.HResult;
            }
            finally
            {
                DA = null;
                SqlConn.Close();
            }
        }
         private void GetSumm()
        {

            double dDiff_prc = 0.0;
            double dSetWeight = 0.0;
            double dDoneWeight = 0.0;

            dSetWeight = DGV.Rows.Cast<DataGridViewRow>()
                       .AsEnumerable()
                       .Sum(x => double.Parse(x.Cells["WeightSet_kg"].Value.ToString()));
            dDoneWeight = DGV.Rows.Cast<DataGridViewRow>()
                                           .AsEnumerable()
                                           .Sum(x => double.Parse(x.Cells["WeightDone_kg"].Value.ToString()));
            if (dSetWeight != 0)
            {
                dDiff_prc = Math.Round(((dSetWeight- dDoneWeight) * 100 / dSetWeight), 2, MidpointRounding.AwayFromZero);
            }

            SetWeight.Text = dSetWeight.ToString();
            DoneWeight.Text = dDoneWeight.ToString();
            Diff_kg.Text = (dSetWeight- dDoneWeight).ToString();
            Diff_prc.Text = dDiff_prc.ToString();            
        }







        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            UpdateTable();
            ResizeTable();
        }

        private void DGV_SizeChanged(object sender, EventArgs e)
        {
            ResizeTable();
        }

        private void FilterStringChanged(object sender, EventArgs e)
        {
            this.BS.Filter = ((ADGV.AdvancedDataGridView)sender).FilterString;
            GetSumm();
        }

        private void SortStringChanged(object sender, EventArgs e)
        {
            this.BS.Sort = ((ADGV.AdvancedDataGridView)sender).SortString;
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            this.DGV.ClearFilter(true);
        }

        private void clearSortButton_Click(object sender, EventArgs e)
        {
            this.DGV.ClearSort(true);
        }

        private void tsbExportExcell_Click(object sender, EventArgs e)
        {
            if (this.ExportExcell != null)
                this.ExportExcell(this, e);
        }

        private void tsbExportHTML_Click(object sender, EventArgs e)
        {
            //if (this.ExportHTML != null)
            //    this.ExportHTML(this, e);
            ProgressControl.Operation= "Выполняется экспорт данных в HTML...";
            ProgressControl.Count = 10;
            ProgressControl.Update();
            if(ProgressControl.Progress== ProgressControl.Count)
            {
                ProgressControl.Clear();
            }


        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            fReport = new formReport(); 
            ReportDataSource rds = new ReportDataSource("DS", this.BS); // ReportViewerDataSource : ReportViewer is to be bind to this DataSource

            fReport.rvViewer.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
                                                              //fReport.rvViewer.LocalReport.ReportEmbeddedResource = "Report2.rdlc"; // bind reportviewer with .rdlc
            fReport.rvViewer.LocalReport.ReportEmbeddedResource = "Reports\\r" + TableName + ".rdlc"; // bind reportviewer with .rdlc
            fReport.rvViewer.LocalReport.ReportPath = "Reports\\r" + TableName + ".rdlc";
            fReport.rvViewer.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            fReport.rvViewer.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case
            //свойства для вывода на печать, не задействованы
            //System.Drawing.Printing.PageSettings rPageSettings = new System.Drawing.Printing.PageSettings();
            //rPageSettings.Landscape= true;
            //rPageSettings.Margins.Top = PrinterUnitConvert.Convert(200, PrinterUnit.HundredthsOfAMillimeter, PrinterUnit.ThousandthsOfAnInch);
            //fReport.rvViewer.SetPageSettings(rPageSettings);

            // Создаем параметры. "ch_num" и "product_name" - имена параметров в отчете
            string sReportTitle = "";
            if (TableName == "Order") sReportTitle = "заказам";
            if (TableName == "Batch") sReportTitle = "замесам";
            if (TableName == "Dosing") sReportTitle = "дозированиям";

            ReportParameter param1 = new ReportParameter("ReportTitle", "Отчет по " + sReportTitle);
            ReportParameter param2 = new ReportParameter("DAT_Start", TimeFiltr.lDAT_start);
            ReportParameter param3 = new ReportParameter("DAT_End", TimeFiltr.lDAT_end);
            string sFiltrString = " ";
            if (DGV.FilterString != null & DGV.FilterString.ToString() != "")
                sFiltrString = "Фильтр:" + DGV.FilterString.ToString();
            ReportParameter param4 = new ReportParameter("FiltrString", sFiltrString);
            ReportParameter param5 = new ReportParameter("ProjectName", Properties.Settings.Default.ProjectName.ToString());

            ReportParameter[] param = { param1, param2, param3, param4, param5 };

            fReport.rvViewer.LocalReport.SetParameters(param);
            fReport.rvViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            fReport.ShowDialog();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.MakeReport != null)
                this.MakeReport(this, e);
        }

    }
}
