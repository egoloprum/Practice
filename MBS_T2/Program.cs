using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using MBS.Properties;


namespace MBS
{
    public class ProjectSettings
    {
        public static string DefaultSQLServer           = "(local)\\SQLEXPRESS",
                             DefaultPath                = "E:\\Projects\\",
                             DefaultProjectID           = "ASUTP_U1",
                             DefaultProjectShortName    = "АСУТП У1",
                             DefaultProjectFullName     = "Разработка автоматизированной системы управления технологическим процессом участка 1",
                             DefaultProjectDeveloper    = "ООО \"Исполнитель\"",
                             DefaultProjectCustomer     = "ООО \"Заказчик\"",
                             DefaultProjectPassword     = "sa123456";

        public static string Desinger   = "Каменева Е.Ю.",
                            Verifying   = "Квасников А.В.",
                            Auditor     = "Квасникова О.И.",
                            Approver    = "Сабельфельд К.К.",
                            ProjectCod  = "ЛКЖТ.123456.789";
    }

    public static class TimeFiltr
    {
        public static string sDAT_start;
        public static string sDAT_end;
        public static string lDAT_start;
        public static string lDAT_end;
    }

    public class ProgressControl
    {
        public static bool bUpdate = false;
        public static string Operation = "";
        public static int Count = 100;
        public static int Progress = 0;
        public static void Clear() {
            Progress = 0; Count = 0; Operation = "";
        }
        public static void Update()
        {



            if (Progress == Count)
            { Progress = 0; }
            Progress++;
            ToolStripLabel lblOperation = new formMain().lOperation;
            ToolStripProgressBar pbProgress = new formMain().Progress;
            //formMain().Invoke(new ThreadStart(delegate
            //{
                lblOperation.Text = Operation;
                pbProgress.ProgressBar.Maximum = Count;
                pbProgress.ProgressBar.Value = Progress;
            //}));
        }

    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formMain());

            //Application.Run(new formSelectProject());
            //Form fMain = new formMain();
            //fMain.Show();
        }

    }

    public class PrintPreviewDialogSelectPrinter : PrintPreviewDialog
    {
        public List<string> lstColumns = new List<string>();

        public PrintPreviewDialogSelectPrinter()
        {
            Shown += myPrintPreview_Shown;
        }

        public void myPrintPreview_Shown(object sender, EventArgs e)
        {
            //Get the toolstrip from the base control
            ToolStrip ts = (ToolStrip)this.Controls[1];
            //Get the print button from the toolstrip
            ToolStripItem printItem = ts.Items[0];//"printToolStripButton"
            ToolStripItem bClose = ts.Items[9];//"printToolStripButton"

            ToolStripItem myPrintItem;
            myPrintItem = ts.Items.Add(printItem.Text, printItem.Image, new EventHandler(MybtnPrint_Click));
            myPrintItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            //Relocate the item to the beginning of the toolstrip
            ts.Items.Insert(0, myPrintItem);
            //Remove the orginal button
            ts.Items.Remove(printItem);

            //добавим кнопку "Выбрать столбцы"
            ToolStripItem SelectColumnsItem;
            SelectColumnsItem = ts.Items.Add("Выбор столбцов", null, new EventHandler(btnSelectColumns_Click));
            SelectColumnsItem.DisplayStyle = bClose.DisplayStyle;
            //SelectColumnsItem.
            ts.Items.Insert(9, SelectColumnsItem);

            //добавим чек-бокс "Автоподбор ширины"
            CheckBox FitPageWidthItem = new CheckBox();
            FitPageWidthItem.Text = "Автоподрор ширины страницы";
            ToolStripControlHost host = new ToolStripControlHost(FitPageWidthItem);
            ts.Items.Insert(10,host);

            //добавим кнопку "Применить"
            System.Windows.Forms.Button btnUpdate = new System.Windows.Forms.Button();
            btnUpdate.Text = "Применить";
            btnUpdate.FlatStyle = FlatStyle.System;
            btnUpdate.BackColor = System.Drawing.SystemColors.AppWorkspace;
            btnUpdate.Padding = new Padding(0);
            btnUpdate.Click += new System.EventHandler(btnUpdate_Click);
            host = new ToolStripControlHost(btnUpdate);
            ts.Items.Insert(11, host);

            //добавим кнопку "Разделитель"
            ToolStripSeparator Sep1 = new ToolStripSeparator();
            ts.Items.Insert(12, Sep1);

 
        }

        public void MybtnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog dlgPrint = new PrintDialog();
            
            try
            {
                dlgPrint.AllowSelection = true;
                dlgPrint.ShowNetwork = true;
                dlgPrint.Document = this.Document;
                if (dlgPrint.ShowDialog() == DialogResult.OK)
                {
                    this.Document.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print Error: " + ex.Message);
            }
        }

        public void btnSelectColumns_Click(object sender, EventArgs e)
        {
            try
            {
                var fSelecColums = new Form();
                fSelecColums.Text = "Выбор столбцов";
                fSelecColums.ShowIcon = false;

                //добавим кнопку Выбрать
                System.Windows.Forms.Button bOK = new System.Windows.Forms.Button();
                bOK.Text = "Выбрать";
                fSelecColums.Controls.Add(bOK);

                //добавим кнопку Выбрать
                System.Windows.Forms.Button bCancel = new System.Windows.Forms.Button();
                bCancel.Text = "Отмена";
                //bCancel.Location=
                fSelecColums.Controls.Add(bCancel);
                //foreach()
                //    chklst.Items.Add(field, true)
                fSelecColums.Show();
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {

            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }
        }
        //public List<string> GetSelectedColumns()
        //{
        //    List<string> lst = new List<string>();
        //    foreach (object item in chklst.CheckedItems)
        //        lst.Add(item.ToString());
        //    return lst;
        //}
    }

    public static class ReportFunc
    {
        public static void CallOrderReport(string nameReport /*наименование отчета*/ , BindingSource bsReport /*DataTable, который будет передат в отчет*/)

        {
            formReport fReport = new formReport();
            string sDAT_filt_start = new formMain().sDAT_filt_start;
            string  sDAT_filt_end = new formMain().sDAT_filt_end;
           
            ReportDataSource rds = new ReportDataSource("DS", bsReport); // ReportViewerDataSource : ReportViewer is to be bind to this DataSource


            fReport.rvViewer.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer

            fReport.rvViewer.LocalReport.ReportEmbeddedResource = "r"+nameReport + ".rdlc"; // bind reportviewer with .rdlc
            fReport.rvViewer.LocalReport.ReportPath = "r" + nameReport + ".rdlc";

            fReport.rvViewer.LocalReport.DataSources.Add(rds); //bind ReportViewer1 to the new datasource(Which you wish)
            fReport.rvViewer.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case

            System.Drawing.Printing.PageSettings rPageSettings = new System.Drawing.Printing.PageSettings();
            rPageSettings.Landscape = true;
            //rPageSettings.Margins.Top = PrinterUnitConvert.Convert(200, PrinterUnit.HundredthsOfAMillimeter, PrinterUnit.ThousandthsOfAnInch);
            //int s = rPageSettings.Margins.Right;
            //rPageSettings.Margins.Right = PrinterUnitConvert.Convert(s, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.ThousandthsOfAnInch); ;
            //rPageSettings.Margins.Bottom = PrinterUnitConvert.Convert(393701, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.ThousandthsOfAnInch);
            //rPageSettings.Margins.Left = PrinterUnitConvert.Convert(10, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.ThousandthsOfAnInch);
            //rPageSettings.Margins.Top = (200 as PrinterUnit.TenthsOfAMillimeter);
            //rPageSettings.Margins
            fReport.rvViewer.SetPageSettings(rPageSettings);


            // Создаем параметры. "ch_num" и "product_name" - имена параметров в отчете
            ReportParameter param1 = new ReportParameter("ReportTitle", "Отчет по заказу");
            ReportParameter param2 = new ReportParameter("DAT_Start", "sDAT_filt_start");
            ReportParameter param3 = new ReportParameter("DAT_End", "sDAT_filt_end");

            ReportParameter[] param = { param1, param2, param3 };

            //ReportParameter param2 = new ReportParameter("product_name", "Bbbbbbb");
            fReport.rvViewer.LocalReport.SetParameters(param);

            //fReport.rvViewer.
            //    .AsyncRendering = false;
            //fReport.rvViewer.AutoSizeMode
            //    .SizeToReportContent = true;
            //fReport.rvViewer.ZoomMode = ZoomMode.FullPage;

            fReport.ShowDialog();
        }

    }



    }
