using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.CodeDom.Compiler;
using System.Data.Common;
//using Microsoft.Office.Core;
using Microsoft.Reporting.WinForms;
using System.Runtime.InteropServices.WindowsRuntime;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace MBS
{
    public partial class ReportsControl : UserControl
    {
        public string TableName;
        public string RequestOrder;
        public string tblOrder;
        public string ProgressLabel = "";
        public int ProgressCount=0;
        public int ProgressValue = 0;
        //public string RequestOrder;

        DataSet DS = new DataSet();
        SqlCommandBuilder cmdBuilder;
        BindingSource bsOrder = new BindingSource();
        BindingSource bsBatch = new BindingSource();
        BindingSource bsDosing = new BindingSource();
        SqlDataAdapter DA;
        System.Data.DataTable DTBuffer = new System.Data.DataTable();
        //Point point = new Point();
        //public event EventHandler ExportExcell;
        //public event EventHandler ExportHTML;
        //public event EventHandler PrintDGV;
        public string sOrderID;
        public string sBatchID;
        public string SqlConnStr;
        formReport fReport;
        ReportDataSource rdsDosing;

        //public SqlConnection SqlConn = new SqlConnection();

        public ReportsControl()
        {
            InitializeComponent();
        }

        public void LoadTables()
        {
            try
            {
                LoadTable("Order");
                LoadTable("Batch");
                LoadTable("Dosing");
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }
        }

        public void UpdateTables()
        {
            try
            {
                UpdateTable("Order");
                ResizeTable(dgvOrder);
                //UpdateTable("Batch");
                //ResizeTable(dgvBatch);
                //UpdateTable("Dosing");
                //ResizeTable(dgvDosing);

            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }
        }
        public void LoadTable(string TableName)
        {


            List<DataGridView> lDGV = new List<DataGridView> { dgvOrder, dgvBatch, dgvDosing };
            List<BindingNavigator> lBN = new List<BindingNavigator> { bnOrder, bnBatch };
            List<BindingSource> lBS = new List<BindingSource> { bsOrder, bsBatch, bsDosing };
            try
            {

                UpdateTable(TableName);

                DataGridView DGV = lDGV.Where(i => i.Name == "dgv" + TableName).First();
                BindingSource BS = lBS.Where(i => i.DataMember == "Report" + TableName).First();

                if (TableName != "Dosing")
                {
                    BindingNavigator BN = lBN.Where(i => i.Name == "bn" + TableName).First();
                    if (BN != null)
                        BN.BindingSource = BS;
                }
                if (DGV != null)
                    DGV.DataSource = BS;


                //устанавливаем ширину бокового элемента
                DGV.RowHeadersWidth = 20;
                //НЕ разрешаем копирование
                DGV.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;//.EnableWithoutHeaderText;
                //формат даты и времени
                foreach (DataGridViewColumn dgvColumn in DGV.Columns)
                {
                    if (dgvColumn.ValueType == typeof(DateTime)) dgvColumn.DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss.fff";
                    dgvColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvColumn.HeaderText = GetDescription(TableName, dgvColumn.HeaderText, 1);
                }
                //автоподбор ширины столбцов
                //ResizeTable(DGV);

                //выставить высоту DGV
                //if (TableName != "Dosing")
                //{
                //    var totalHeight = DGV.Rows.GetRowsHeight(3) + DGV.ColumnHeadersHeight;
                //}
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

        private void ResizeTable(DataGridView DGV)
        {
            try
            {
                if (DGV.ColumnCount > 0)
                {


                    //автоподбор ширины столбцов
                    DGV.AutoResizeColumns();

                    //формат даты и времени
                    //foreach (DataGridViewColumn dgvColumn in DGV.Columns)
                    //{
                    //    if (dgvColumn.ValueType == typeof(DateTime)) dgvColumn.Width = 250;
                    //}

                    //подбор ширины последнего стоблца по ширину окна
                    //    runningWidthUsed += DGV.RowHeadersWidth + DGV.Margin.Left + DGV.VerticalScrollingOffset;
                    //for (int i = 0; i < DGV.ColumnCount; i++)
                    //    runningWidthUsed += DGV.Columns[i].Width;

                    //if (this.Width > runningWidthUsed)
                    //{
                    //    int Delta = this.Width - runningWidthUsed - 20;
                    //    DGV.Columns[DGV.ColumnCount - 1].Width += Delta;
                    //}

                }
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }
        }

        public int UpdateTable(string TableName)
        {
            string SelectCommand ="";//.Replace("@DAT_Start", fMain.sDAT_filt_start).Replace("@DAT_End", sDAT_filt_end);
            SqlConnection SqlConn = new SqlConnection(SqlConnStr);//new SqlConnection(Properties.Settings.Default.ReportConnectionString);
                                                                  //List<BindingSource> lBS = new List<BindingSource> { bsOrder, bsBatch };
            BindingSource BS = new BindingSource(); // lBS.Where(i => i.Name == "bs" + TableName).First();

            if (sOrderID == "" | sOrderID == null) sOrderID = "0";
            if (sBatchID == "" | sBatchID == null) sBatchID = "0";


            if (TableName == "Order")
            {
                SelectCommand = RequestOrder;
                BS = this.bsOrder;
            }              
            if (TableName == "Batch")
            {
                
                SelectCommand = SQLControls.GetRequest("ReportBatchByOrderID").Replace("@BD", "MBS2").Replace("@OrderID", sOrderID);
                BS = this.bsBatch;
            }
            if (TableName == "Dosing")
            {
                SelectCommand = SQLControls.GetRequest("ReportDosingByBatchID").Replace("@BD", "MBS2").Replace("@BatchID", sBatchID);
                BS = this.bsDosing;
            }
            if (TableName == "DosingByOrder")
            {
                SelectCommand = SQLControls.GetRequest("ReportDosingByOrderID").Replace("@BD", "MBS2").Replace("@OrderID", sOrderID);
            }
            //MessageBox.Show(Properties.Settings.Default.AlarmConnectionString.ToString());

            try
            {
                if (DS.Tables.Contains("Report" + TableName)) { DS.Tables["Report" + TableName].Clear(); }
                this.DA = new SqlDataAdapter(SelectCommand, SqlConn);
                cmdBuilder = new SqlCommandBuilder(DA);
                this.DA.Fill(DS, "Report" + TableName);
                BS.DataSource = DS;
                BS.DataMember = "Report" + TableName;


                if (TableName == "Dosing")
                {                                
                    //dgvDosing.DataSource = BS;
                    //dgvDosing.Update();
                    //dgvDosing.Refresh();
                    DosingStyle();
                }
                return 0;
            }
            catch (System.Exception ex)
            {

                General.ErrorMessage(ex);
                return ex.HResult;
            }
            finally
            {
                this.DA = null;
                SqlConn.Close();
            }
        }


        public int FillDTfromBD(string TableName)
        {
            string SelectCommand = SQLControls.GetRequest(TableName);
            SqlConnection SqlConn = new SqlConnection(SqlConnStr);//new SqlConnection(Properties.Settings.Default.ReportConnectionString);
                                                                  //List<BindingSource> lBS = new List<BindingSource> { bsOrder, bsBatch };
            if (TableName.Contains("Batch") == true)
            {
                if (sOrderID != "0" & sOrderID != "" & sOrderID != null)
                    SelectCommand = SelectCommand + " WHERE ([OrderID]=" + sOrderID + ")";
            }
            //MessageBox.Show(Properties.Settings.Default.AlarmConnectionString.ToString());

            try
            {
                if (TableName.Contains("Dosing")==true)
                {
                    if (sBatchID == "" | sBatchID == null) sBatchID = "0";

                    if (DS.Tables.Contains("Report" + TableName)) { DS.Tables["Report" + TableName].Clear(); }

                    string[] sSilisType = { "ИНЕРТНЫЕ", "ДОБАВКИ" };

                    foreach (string s in sSilisType)
                    {

                        if (s == "ДОБАВКИ")
                        {
                            //Добавляем заголовок ДОБАВКИ
                            DataRow newRow3 = DS.Tables["Report" + TableName].NewRow();
                            newRow3[0] = "ДОБАВКИ";
                            DS.Tables["Report" + TableName].Rows.Add(newRow3);
                        }

                        SelectCommand = SQLControls.GetRequest(TableName) +
                         " WHERE ([BatchID]=" + sBatchID + " AND [SilosType]='" + s + "')";

                        //SelectCommand = GetRequest(TableName);// +
                        //" WHERE ([BatchID]=" + sBatchID + " AND [SilosType]='" + s + "')";// +
                        //" ORDER BY [BacthRank]";
                        //"SELECT " +
                        //"[SilosLabel] As 'Наименование'" +
                        //",[SilosN] As 'Номер силоса'" +
                        //",[BacthRank] As 'Ранг замеса'" +
                        //",[BacthStep]  As 'Шаг замеса'" +
                        //",[WeightSet] As 'Заданный вес (кг)'" +
                        //",[WeightDose]  As 'Полученный вес (кг)'" +
                        //",[WeightDiff_kg] As 'Разница (кг)'" +
                        //",[WeightDiff_prc] As 'Разница (%)'" +
                        //",[Sts] AS 'Состояние'" +
                        //",[DAT_Start] As 'Начало дозирования'" +
                        //",[DAT_End]  As 'Завершение дозирования'" +
                        //",[dbo].sec_to_ddhhmmss([DOSING_TIME_s]) As 'Длительность дозирования'" +
                        //",[Operator] As 'Оператор'" +
                        //" FROM[MBS2].[dbo].[View_Dosing] " +



                        //Заполняем таблицу данными (сначала заполняем, чтобы не создавать структуру таблицы)
                        this.DA = new SqlDataAdapter(SelectCommand, SqlConn);
                        cmdBuilder = new SqlCommandBuilder(DA);
                        this.DA.Fill(DS, "Report" + TableName);

                        if (s == "ИНЕРТНЫЕ")
                        {
                            //Добавляем заголовок ИНЕРТНЫЕ
                            DataRow newRow = DS.Tables["Report" + TableName].NewRow();
                            newRow[0] = "ИНЕРТНЫЕ";
                            DS.Tables["Report" + TableName].Rows.InsertAt(newRow, 0);
                        }


                        //Добавляем строку Всего
                        //SelectCommand = GetRequest(TableName) +
                        //" WHERE ([BatchID]=" + sBatchID + " AND [SilosType]='" + s + "')";

                        SelectCommand = "SELECT " +
                                        "'Всего' As 'Наименование'" + //"'" + s + "' As 'Наименование'" +
                                        ",null As 'Номер силоса'" +
                                        ",null  As 'Ранг замеса'" +
                                        ",null   As 'Шаг замеса'" +
                                        ",sum([WeightSet])  As 'Заданный вес (кг)'" +
                                        ",sum([WeightDose])   As 'Полученный вес (кг)'" +
                                        ",(sum([WeightSet])-sum([WeightDose]))  As 'Разница (кг)'" +
                                        ",IIF(sum([WeightSet]) IS NULL,null, ROUND((sum([WeightSet])-sum([WeightDose]))*100/sum([WeightSet]),2)) As 'Разница (%)'" +
                                        ",null  AS 'Состояние'" +
                                        ",null  As 'Начало дозирования'" +
                                        ",null   As 'Завершение дозирования'" +
                                        ",sum([DOSING_TIME_s]) As 'Длительность дозирования'" + //",[dbo].sec_to_ddhhmmss(sum([DOSING_TIME_s])) As 'Длительность дозирования'" +
                                        ",null  As 'Оператор'" +
                                        " FROM[MBS2].[dbo].[View_Dosing] " +
                                        " WHERE ([BatchID]=" + sBatchID + " AND [SilosType]='" + s + "')";


                        //Заполняем таблицу данными (сначала заполняем, чтобы не создавать структуру таблицы)
                        this.DA = new SqlDataAdapter(SelectCommand, SqlConn);
                        cmdBuilder = new SqlCommandBuilder(DA);
                        this.DA.Fill(DS, "Report" + TableName);

                        //Добавляем пустую строку
                        DataRow newRow2 = DS.Tables["Report" + TableName].NewRow();
                        newRow2[0] = "";
                        DS.Tables["Report" + TableName].Rows.Add(newRow2);

                    }

                    //Добавляем строку ИТОГО
                    SelectCommand = "SELECT " +
                                    "'ИТОГО' As 'Наименование'" + //"'" + s + "' As 'Наименование'" +
                                    ",null As 'Номер силоса'" +
                                    ",null  As 'Ранг замеса'" +
                                    ",null   As 'Шаг замеса'" +
                                    ",sum([WeightSet])  As 'Заданный вес (кг)'" +
                                    ",sum([WeightDose])   As 'Полученный вес (кг)'" +
                                    ",(sum([WeightSet])-sum([WeightDose]))  As 'Разница (кг)'" +
                                    ",IIF(sum([WeightSet]) IS NULL,null, ROUND((sum([WeightSet])-sum([WeightDose]))*100/sum([WeightSet]),2)) As 'Разница (%)'" +
                                    ",null  AS 'Состояние'" +
                                    ",null  As 'Начало дозирования'" +
                                    ",null   As 'Завершение дозирования'" +
                                    ",sum([DOSING_TIME_s]) As 'Длительность дозирования'" +//",[dbo].sec_to_ddhhmmss(sum([DOSING_TIME_s])) As 'Длительность дозирования'" +
                                    ",null  As 'Оператор'" +
                                    " FROM[MBS2].[dbo].[View_Dosing] " +
                                    " WHERE ([BatchID]=" + sBatchID + ")";


                    //Заполняем таблицу данными (сначала заполняем, чтобы не создавать структуру таблицы)
                    this.DA = new SqlDataAdapter(SelectCommand, SqlConn);
                    cmdBuilder = new SqlCommandBuilder(DA);
                    this.DA.Fill(DS, "Report" + TableName);
                    //System.Data.DataTable DosingTable = DS.Tables.Add("Report" + TableName);

                }
                else
                {

                    if (DS.Tables.Contains("Report" + TableName)) { DS.Tables["Report" + TableName].Clear(); }
                    this.DA = new SqlDataAdapter(SelectCommand, SqlConn);
                    cmdBuilder = new SqlCommandBuilder(DA);
                    this.DA.Fill(DS, "Report" + TableName);
                }
                //WinCCAlarmStyle();
                return 0;
            }
            catch (System.Exception ex)
            {

                General.ErrorMessage(ex);
                return ex.HResult;
            }
            finally
            {
                this.DA = null;
                SqlConn.Close();
            }
        }



        private Int64 SumValueInDateSet(System.Data.DataTable DT, String sColumnName)
        {
            string Counter = ""; // Счетчик строк
            Int64 iSum = 0; // Накопитель суммы
            // Цик по строкам iDataSet если он не пустой
            if (DT.Rows.Count != 0)
            {
                foreach (DataRow iRow in DT.Rows)
                    Counter = iRow[sColumnName].ToString();
                iSum = Convert.ToInt64(Counter) + iSum;
            }
            return iSum;
        }

        private int DosingStyle()
        {
            try
            {
                ////устанавливаем ширину бокового элемента
                //dgvDosing.RowHeadersWidth = 20;

                //this.UpdatingCount = this.dgv.Rows.Count;
                Color rowColor = Color.White;
                Color sumColor = Color.White;

                foreach (DataGridViewRow dgvRow in this.dgvDosing.Rows)
                {
                    dgvRow.DefaultCellStyle.ForeColor = Color.Black;

                    if (dgvRow.Cells["SilosLabel"].Value != null)
                    {

                        if (dgvRow.Cells["SilosLabel"].Value.ToString() == "ИНЕРТНЫЕ")
                        {
                            dgvRow.DefaultCellStyle.BackColor = Color.FromArgb(198, 214, 223);//Color.Bisque;
                            rowColor = Color.FromArgb(227, 235, 239);//Color.BlanchedAlmond;
                            sumColor = Color.FromArgb(227, 235, 239);//Color.BlanchedAlmond;
                            dgvRow.DefaultCellStyle.Font = new System.Drawing.Font(this.dgvDosing.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                        }
                        else
                        {
                            if (dgvRow.Cells["SilosLabel"].Value.ToString() == "ДОБАВКИ")
                            {
                                dgvRow.DefaultCellStyle.BackColor = Color.FromArgb(205, 225, 215);// Color.FromArgb(231, 214, 212);
                                dgvRow.DefaultCellStyle.Font = new System.Drawing.Font(this.dgvDosing.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                                rowColor = Color.FromArgb(226, 237, 232);// Color.FromArgb(216, 231, 224);//Color.MistyRose;
                                sumColor = Color.FromArgb(226, 237, 232);//Color.FromArgb(216, 231, 224);//Color.MistyRose;
                            }
                            else
                            {
                                if (dgvRow.Cells["SilosLabel"].Value.ToString() == "ИТОГО")
                                {
                                    dgvRow.DefaultCellStyle.BackColor = Color.LightSteelBlue;// Color.FromArgb(185, 208, 224);// Color.Pink;
                                    dgvRow.DefaultCellStyle.Font = new System.Drawing.Font(this.dgvDosing.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

                                }

                                else
                                {

                                    if (dgvRow.Cells["SilosLabel"].Value.ToString() == "Всего")
                                    //dgvRow.DefaultCellStyle.Font.Bold = true;
                                    //.Style= FontStyle.Bold;
                                    {
                                        dgvRow.DefaultCellStyle.BackColor = sumColor;
                                        dgvRow.DefaultCellStyle.Font = new System.Drawing.Font(this.dgvDosing.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                                    }
                                    else dgvRow.DefaultCellStyle.BackColor = rowColor;
                                }


                            }
                        }

                    }
                    //this.dgvDosing.ColumnHeadersDefaultCellStyle.BackColor =Color.FromArgb(185, 208, 224);

                    //убираем выделение
                    dgvRow.DefaultCellStyle.SelectionBackColor = dgvRow.DefaultCellStyle.BackColor;
                    dgvRow.DefaultCellStyle.SelectionForeColor = dgvRow.DefaultCellStyle.ForeColor;

                }
                //ProgressControl.Clear();
                return 0;
            }

            catch (System.Exception ex)
            {
                //ProgressControl.Clear();
                General.ErrorMessage(ex);
                return ex.HResult;
            }
            finally
            {
            }
        }

        private void ExportExcell(bool Colored)
        {

            try
            {
                #region Экспорт построчно (медленно)
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                int j, i = 0;

                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                int iRow = 1;
                //Строка 1
                ExcelApp.Cells[1, 1] = "МБС. Линия 2. Отчет по замесу";

                //Строка 2,3
                //вносим данные замеса
                for (j = 0; j < dgvBatch.ColumnCount; j++)
                {
                    ExcelWorkSheet.Cells[2, j + 1] = dgvBatch.Columns[j].Name.ToString().Replace(",", ".");
                    ExcelWorkSheet.Cells[2, j + 1].Font.Bold = true;
                    ExcelWorkSheet.Cells[3, j + 1] = dgvBatch.Rows[dgvBatch.SelectedCells[0].RowIndex].Cells[j].FormattedValue.ToString().Replace(",", ".");

                }

                //вносим данные дозирований

                for (j = 0; j < dgvDosing.ColumnCount; j++)
                {
                    ExcelWorkSheet.Cells[4, j + 1] = dgvDosing.Columns[j].Name.ToString().Replace(",", ".");
                    ExcelWorkSheet.Cells[4, j + 1].Font.Bold = true;
                    if (Colored) ExcelWorkSheet.Cells[4, j + 1].Interior.Color = dgvDosing.RowHeadersDefaultCellStyle.BackColor;

                    //ExcelWorkSheet.Cells[4, j + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.PowderBlue);//.LightCyan

                    for (i = 0; i < dgvDosing.Rows.Count; i++)
                    {

                        ExcelWorkSheet.Cells[i + 5, j + 1] = dgvDosing.Rows[i].Cells[j].FormattedValue.ToString().Replace(",", ".");
                        //ExcelWorkSheet.Cells[i + 5, j + 1].Font.Bold = dgvDosing.Rows[i].DefaultCellStyle.Font.Bold;                         
                        if (Colored) ExcelWorkSheet.Cells[i + 5, j + 1].Interior.Color = dgvDosing.Rows[i].DefaultCellStyle.BackColor;

                        iRow = i + 5;//запомнили номер последней добавленной строки
                    }
                }
                ExcelWorkSheet.Range[ExcelWorkSheet.Cells[4, 1], ExcelWorkSheet.Cells[i + 5, j]].Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                Microsoft.Office.Interop.Excel.Range used = ExcelWorkSheet.UsedRange;
                //Autofit The Columns
                used.EntireColumn.AutoFit();
                //ws.Range[ws.Cells[1, 1], ws.Cells[1, used.Columns.Count]].WrapText = true; // перенос текста

                //used.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                used.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;


                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
                //Уничтожение объекта Excel.
                Marshal.ReleaseComObject(ExcelApp);
                // Вызываем сборщик мусора для немедленной очистки памяти
                GC.GetTotalMemory(true);
                #endregion
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }



        }

        void SaveBatchToHtml(XmlWriter writer, string sWidth, string sIDBatch)
        {
            System.Data.DataTable dtDosing = DS.Tables["ReportDosing"];
            System.Data.DataTable dtBatch = DS.Tables["ReportBatch"];
            System.Data.DataTable dOrder = DS.Tables["ReportOrder"];

            try
            {
                #region Batch
                if (dtBatch != null)
                {
//-------------------------------------------------------------------------------------------------------------------------                   
                    writer.WriteStartElement("table");
                    writer.WriteAttributeString("border", "0");
                    writer.WriteAttributeString("cellspacing", "3");
                    writer.WriteAttributeString("cellpadding", "3");
                    //writer.WriteAttributeString("bgcolor", "#8cacbb");
                    writer.WriteAttributeString("width", sWidth);
                    writer.WriteAttributeString("style", "border-collapse: collapse;border-left:.5pt solid black;border-right:.5pt solid black;border-top:.5pt solid black");
                    writer.WriteStartElement("tbody");
                    // Use the Select method to find all rows matching the filter.
                    DataRow[] rowsOrder = dOrder.Select("ID = " + sOrderID);
                    DataRow rowOrder = rowsOrder[0]; //берем только первую строку

                    //находим все строки в нужным ID
                    // Use the Select method to find all rows matching the filter.
                    DataRow[] rowsBatch = dtBatch.Select("ID = " + sIDBatch);
                    DataRow rowBatch = rowsBatch[0]; //берем только первую строку


                    // Запись заголовка таблицы HTML:

                    string[] sTitleColumnHeaders = { "Замес", "Заказ ID", "Рецепт", "Наименование", "Место выгрузки"};
                    string[] sValueColumnHeaders = { "BacthSet", "ID", "Recipe", "RecipeLabel", "UnloadPlace" };
                    //string sOrderRecipe="", sOrderRecipeLabel = "";


                    //if (rowOrder.Table.Columns.Contains(sTitleColumnHeaders[3]))
                    //    sOrderRecipeLabel = rowOrder[sTitleColumnHeaders[3]].ToString();


                    writer.WriteStartElement("tr");
                    writer.WriteAttributeString("style", "background-color: #a0cefc;text-align: left;font-size:18;");
                    for (int c = 0; c <= (sTitleColumnHeaders.Length-1); c++) //цикл по столбцам
                    {

                        string sValue = "";
                        if (rowOrder.Table.Columns.Contains(sValueColumnHeaders[c]))
                            sValue = rowOrder[sValueColumnHeaders[c]].ToString();
                        if (c == 0)
                        {
                            string sValue1 = "?";
                            if (rowBatch.Table.Columns.Contains("BacthN"))
                                sValue1 = rowBatch["BacthN"].ToString();
                            sValue = sValue1 + " из " + sValue;
                        }

                        writer.WriteStartElement("td");
                        writer.WriteAttributeString("style", "font-weight:bold;border-bottom:.5pt solid black");
                        writer.WriteString(sTitleColumnHeaders[c]);
                        writer.WriteEndElement();  // закрытие тега td

                        writer.WriteStartElement("td");
                        writer.WriteAttributeString("style", "font-weight:regular;border-bottom:.5pt solid black");
                        writer.WriteString(sValue);
                        writer.WriteEndElement();  // закрытие тега td

                        writer.WriteStartElement("td");
                        if (c != (sTitleColumnHeaders.Length-1)) writer.WriteAttributeString("width", "100");
                        writer.WriteAttributeString("style", "border-bottom:.5pt solid black");
                        writer.WriteString(" ");
                        writer.WriteEndElement();  // закрытие тега td

                    }
                    writer.WriteEndElement();  // закрытие тега tr
                    writer.WriteEndElement();  // закрытие тега tbody
                    writer.WriteEndElement();  // закрытие тега table
//-------------------------------------------------------------------------------------------------------------------------
                    //формируем структуру будущей таблицы
                    writer.WriteStartElement("table");
                    writer.WriteAttributeString("border", "0");
                    writer.WriteAttributeString("cellspacing", "3");
                    writer.WriteAttributeString("cellpadding", "3");
                    //writer.WriteAttributeString("bgcolor", "#8cacbb");
                    writer.WriteAttributeString("width", sWidth);
                    writer.WriteAttributeString("style", "border-collapse: collapse;border-left:.5pt solid black;border-right:.5pt solid black;");
                    writer.WriteStartElement("tbody");

                    //string[,] sColumnHeaders =
                    //{
                    //    {"Заданный вес (кг)", "Длительность дозирования", "Начало дозирования", "Состояние"},
                    //    {"Полученный вес (кг)", "Длительность смешивания", "Начало домешивания", "ID"},
                    //    {"Разница (кг)", "Длительность домешивания", "Начало выгрузки", "Оператор"},
                    //    {"Разница (%)", "Длительность выгрузки", "Завершение замеса", ""}
                    //};

                    string[,] sColumnHeaders =
                    {
                        {"WeightSet_kg", "DosingTime", "DAT_Start_Dosing", "Sts"},
                        {"WeightDone_kg", "FullMixingTime", "DAT_Start_Mixing", "ID"},
                        {"WeightDiff_kg", "MixingTime", "DAT_Start_Unload", "Operator"},
                        {"WeightDiff_prc", "UnloadTime", "DAT_End", ""}
                    };

                    for (int r = 0; r <= sColumnHeaders.GetUpperBound(0); r++)//цикл по строкам
                    {
                        writer.WriteStartElement("tr");
                        writer.WriteAttributeString("style", "background-color: #ffffff; color:#000000; font-weight:regular;");

                        for (int c = 0; c <= sColumnHeaders.GetUpperBound(1); c++) //цикл по столбцам
                        {                            
                            writer.WriteStartElement("td");
                            writer.WriteAttributeString("style", "font-weight:bold;");
                            string sTitle = GetDescription("ReportBatchByOrderID", sColumnHeaders[r, c], 1);
                            writer.WriteString(sTitle);
                            writer.WriteEndElement();  // закрытие тега td

                            writer.WriteStartElement("td");
                            writer.WriteAttributeString("style", "font-weight:regular;");
                            
                            if (rowBatch.Table.Columns.Contains(sColumnHeaders[r, c]))
                                writer.WriteString(rowBatch[sColumnHeaders[r, c]].ToString());
                            else
                                writer.WriteString(" ");

                            writer.WriteEndElement();  // закрытие тега td

                            writer.WriteStartElement("td");
                            if (c != (sTitleColumnHeaders.Length - 1)) writer.WriteAttributeString("width", "50");     
                            writer.WriteString(" ");
                            writer.WriteEndElement();  // закрытие тега td

                        }
                        writer.WriteEndElement();  // закрытие тега tr
                    }


                    writer.WriteEndElement();  // закрытие тега tbody
                    writer.WriteEndElement();  // закрытие тега table
                }
                else
                {

                }
                #endregion

//-------------------------------------------------------------------------------------------------------------------------
                #region Dosing

                if (dtDosing != null)
                {
                    writer.WriteStartElement("table");
                    writer.WriteAttributeString("border", "0");
                    writer.WriteAttributeString("cellspacing", "1");
                    writer.WriteAttributeString("cellpadding", "3");
                    writer.WriteAttributeString("bgcolor", "#8cacbb");
                    writer.WriteAttributeString("width", sWidth);
                    writer.WriteAttributeString("style", "border-collapse: collapse; border:.5pt solid black");
                    writer.WriteStartElement("tbody");


                    // Запись заголовка таблицы HTML:
                    writer.WriteStartElement("tr");
                    writer.WriteAttributeString("style", "background-color: #e0effe;");

                    foreach (DataColumn column in dtDosing.Columns)
                    {                        
                        writer.WriteStartElement("th");
                        writer.WriteAttributeString("style", "border:.5pt solid black;");
                        if (column.Ordinal == 0)
                            writer.WriteAttributeString("width", "170");
                        string sHeader = GetDescription(dtDosing.TableName+ "ByBatchID", column.ColumnName.ToString(), 1);
                        writer.WriteString(sHeader);
                        writer.WriteEndElement();  // закрытие тега th
                    }
                    writer.WriteEndElement();  // закрытие тега tr

                    // Запись всех строк:
                    int rowstart = 0;
                    int rowidx = rowstart;
                    int rowend = dtDosing.Rows.Count - 1;
                    //Прогресс
                    this.ProgressCount = dtDosing.Rows.Count;
                    foreach (DataRow row in dtDosing.Rows)
                    {

                        //Прогресс (прирост значения)
                        if (this.ProgressValue == this.ProgressCount)
                        { this.ProgressValue = 0; }
                        this.ProgressValue += 1;

                        writer.WriteStartElement("tr");
                        //цвета фона и текста я чейки
                        string sBackColor = "#ffffff";
                        string sForeColor = "#000000";
                        string sFontStyle = "regular";
                        if (rowidx == rowend)
                        {
                            sFontStyle = "bold";
                            sBackColor = "#ecf5fe";
                        }
                        string sBorder = "border:.5pt solid black;";
                        if (row[0].ToString() == "ИНЕРТНЫЕ" | row[0].ToString() == "ДОБАВКИ")
                        {
                            sBorder = "border-bottom:.5pt solid black;border-top:.5pt solid black';";
                            sBackColor = "#ecf5fe";
                        }    
                            

                        writer.WriteAttributeString("style", "background-color: " + sBackColor + "; color:" + sForeColor + "; font-weight:" + sFontStyle + ";");

                        foreach (DataColumn column in dtDosing.Columns)
                        {
                            if (null != row[column.ColumnName])
                            {
                                writer.WriteStartElement("td");
                                writer.WriteAttributeString("style", sBorder);
                                writer.WriteString(row[column.ColumnName].ToString());
                                writer.WriteEndElement();  // закрытие тега td
                            }
                            else
                                writer.WriteElementString("td", " ");
                        }
                        writer.WriteEndElement();  // закрытие тега tr
                        rowidx++;
                    }

                    ////печатаем пустую строку для разделения страниц

                    //writer.WriteStartElement("tr");
                    //writer.WriteAttributeString("style", "background-color: #ffffff; color:#000000; font-weight:regular;");
                    //writer.WriteElementString("td", " ");
                    //writer.WriteEndElement();  // закрытие тега tr

                    writer.WriteEndElement();  // закрытие тега tbody
                    writer.WriteEndElement();  // закрытие тега table
                }
                else
                {

                }
                #endregion
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }
            finally
            {
            }
        }

        void SaveToHtml(String sFileName, bool OrderMode)
        {
            XmlWriter writer = null;

            System.Data.DataTable dtDosing = DS.Tables["ReportDosing"];
            System.Data.DataTable dtBatch = DS.Tables["ReportBatch"];
            string sWidth = "1400"; //заданная ширина таблиц (чтобы были одной ширины), возможно потом вынести в настройку

            try
            {
                string sFilePatch = General.GetFilePatch();
                if (sFilePatch != "")
                {
                    string fn = sFilePatch + "\\" + sFileName + ".html";
                    //Прогресс
                    this.ProgressLabel = "Выполняется экспорт данных в HTML...";

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = ("\t");
                    settings.OmitXmlDeclaration = true;
                    settings.Encoding = Encoding.UTF8;
                    if (File.Exists(fn))
                    {
                        //File.Delete(xls);
                        SaveFileDialog sf = new SaveFileDialog();
                        sf.DefaultExt = ".html";
                        sf.InitialDirectory = sFilePatch;
                        sf.FileName = sFileName;
                        //sf.ShowDialog();
                        if (sf.ShowDialog() == DialogResult.Cancel)
                            return;
                        // получаем выбранный файл
                        fn = sf.FileName;
                    }

                    //начинаем экспорт
                    writer = XmlWriter.Create(fn, settings);
                    //writer.WriteStartDocument();
                    // Запись комментария:
                    //writer.WriteComment(fn);
                    // open root node
                    writer.WriteStartElement("Report");

//----------------------Заголовок файла-------------------------------------------
                    writer.WriteStartElement("head");
                    writer.WriteStartElement("title");
                    writer.WriteString(sFileName);
                    writer.WriteEndElement();//<title>
                    writer.WriteEndElement();//<head>

 //----------------------Шапка файла (в виде отдельной таблицы)-------------------------------------------
                    writer.WriteStartElement("table");  // открытие тега table
                    writer.WriteAttributeString("border", "0");
                    writer.WriteAttributeString("cellspacing", "3");
                    writer.WriteAttributeString("cellpadding", "3");
                    writer.WriteAttributeString("width", sWidth);
                    writer.WriteStartElement("tbody"); // открытие тега tbody
                    writer.WriteStartElement("tr");// Добавляем строку
                    //Поле - Названия проекта (производства)
                    writer.WriteStartElement("th");
                    writer.WriteAttributeString("style", "text-align: left;");
                    string sProject = Properties.Settings.Default.ProjectName.ToString();
                    writer.WriteString(sProject);
                    writer.WriteEndElement();  // закрытие тега th
                    //Поле - Названия отчета
                    writer.WriteStartElement("th");
                    writer.WriteAttributeString("style", "font-size:20; text-align: center;");
                    writer.WriteString(sFileName);
                    writer.WriteEndElement();  // закрытие тега th
                    //Поле - Дата формирования отчета
                    writer.WriteStartElement("th");
                    writer.WriteAttributeString("style", "text-align: right;");
                    string sDate = DateTime.Now.ToString();
                    writer.WriteString(sDate);
                    writer.WriteEndElement();  // закрытие тега th

                    writer.WriteEndElement();  // закрытие тега tr
                    writer.WriteEndElement();  // закрытие тега tbody
                    writer.WriteEndElement();  // закрытие тега table


                    //----------------------Таблица дозирований (в виде отдельной таблицы)-------------------------------------------
                    if (OrderMode)
                    {
                            foreach (DataRow rowBatch in DS.Tables["ReportBatch"].Rows)
                            {
                                if (rowBatch.Table.Columns.Contains("ID"))
                                {
                                    string sIDBatch = rowBatch["ID"].ToString();
                                    if (sIDBatch != null)
                                    {
                                        writer.WriteStartElement("BatchID" + sIDBatch);
                                        SaveBatchToHtml(writer, sWidth, sIDBatch);
                                        writer.WriteEndElement();  // закрытие тега ("Batch")
                                    }
                                }
                            }
                    }
                    else                    
                    {
                        writer.WriteStartElement("BatchID" + sBatchID);
                        SaveBatchToHtml(writer, sWidth, sBatchID);
                        writer.WriteEndElement();  // закрытие тега ("Batch")
                        //< div class="page-break"></div>
                    }





                    // close root node
                    writer.WriteEndDocument();// ("report");
                                              //writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();

                    //ProgressControl.Clear();
                    DialogResult res = MessageBox.Show("Экспорт завершен. Открыть файл?", "Экспорт выполнен", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(fn);
                    }

                    if (res == DialogResult.No)

                    {
                    }

                }
            }
            finally
            {
                //Прогресс сбрасываем
                this.ProgressLabel = "";
                this.ProgressValue = 0;
                if (writer != null)
                    writer.Close();
                //GC.GetTotalMemory(true);
            }
        }

        private void tsbExportExcellBatch_Click(object sender, EventArgs e)
        {
            ExportExcell(true);
        }

        private void dgvOrder_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //dgvOrder.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(dgvOrder.DefaultCellStyle.Font, FontStyle.Bold);
            //sOrderID = SelectRow("Order", e.RowIndex);
            //if (sOrderID != "0")
            //{
            //    UpdateTable("Batch");
            //    ResizeTable(dgvBatch);
            //}
            //try
            //{
            //    sOrderID = "";
            //    this.dgvOrder.Rows[e.RowIndex].Selected = true;
            //    //this.dgvOrder.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(this.dgvOrder.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            //    //if (dgvOrder.DataSource != null)
            //    //{
            //    //    if (this.bsOrder.Current != null)
            //    //        sOrderID = (this.bsOrder.Current as DataRowView).Row["ID"].ToString();
            //    //}
            //    sOrderID = this.dgvOrder.Rows[e.RowIndex].Cells["ID"].Value.ToString();



            //    if (sOrderID != "")
            //    {
            //        lOrderSelect.Text = "Выбран заказ ID=" + sOrderID; //временно чтобы отслеживтаь
            //        UpdateTable("Batch");
            //        ResizeTable(dgvBatch);
            //    }
            //    else lOrderSelect.Text = "";

            //}
            //catch (System.Exception ex)
            //{
            //    General.ErrorMessage(ex);
            //}
            //finally
            //{
            //}
        }


        private void dgvBatch_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //sBatchID = SelectRow("Batch", e.RowIndex);
            //UpdateTable("Dosing");
        }

        public void GoToRowByID(string TableName, string id)
        {
            List<DataGridView> lDGV = new List<DataGridView> { dgvOrder, dgvBatch, dgvDosing };
            //List<BindingNavigator> lBN = new List<BindingNavigator> { bnOrder, bnBatch };
            List<BindingSource> lBS = new List<BindingSource> { bsOrder, bsBatch, bsDosing };
            try
            {
                UpdateTable(TableName);
                //if(id!="0")
                //{
                BindingSource BS = lBS.Where(i => i.DataMember == "Report" + TableName).First();
                if (BS != null)
                {
                    BS.Position = BS.Find("ID", id);
                }
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
            }
        }

        public string SelectRow(string TableName, int RowIndex)
        {
            List<DataGridView> lDGV = new List<DataGridView> { dgvOrder, dgvBatch, dgvDosing };
            string sText=""; //предустанавливаем текст для надписи
            if (TableName == "Order")
                sText = "Заказ не выбран";
            if (TableName == "Batch")
                sText = "Замес не выбран";

            string sID = "0"; //предустанавливаем возвращаемой значение
            try
            {               
                if (RowIndex >= 0) //если индекс положительный
                {
                    DataGridView DGV = lDGV.Where(i => i.Name == "dgv" + TableName).First();
                    if (DGV != null)
                    {
                        //DGV.Rows[RowIndex].Selected = true;
                        //DGV.DefaultCellStyle.Font = new System.Drawing.Font(DGV.DefaultCellStyle.Font, FontStyle.Regular);//не работает
                        //DGV.Rows[RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(DGV.DefaultCellStyle.Font, FontStyle.Bold);

                        sID = DGV.Rows[RowIndex].Cells["ID"].Value.ToString();
                        if (sID != "" & sID != null)
                        {
                            if (TableName == "Order")
                                sText = "Выбран заказ ID=" + sID; //временно чтобы отслеживтаь
                            if (TableName == "Batch")
                                sText = "Выбран замес ID=" + sID; //временно чтобы отслеживтаь}

                        }
                    }
                }
                return sID;
            }
            catch (Exception)
            {

                return sID;
            }
            finally { 
                if (TableName == "Order")
                    lOrderSelect.Text = sText; //временно чтобы отслеживтаь
                if (TableName == "Batch")
                    lBatchSelect.Text = sText; //временно чтобы отслеживтаь}

            }           
        }
        //private void dgvOrder_RowLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    dgvOrder.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(dgvOrder.DefaultCellStyle.Font, FontStyle.Regular);
        //}

        private void dgvOrder_SelectionChanged(object sender, EventArgs e)
        {
            if ((sender as DataGridView).Focused)
            {
                if ((sender as DataGridView).RowCount > 0)
                {

                    sOrderID = SelectRow("Order", (sender as DataGridView).CurrentRow.Index);
                    //if (sOrderID != "0")
                    //{
                    UpdateTable("Batch");
                    ResizeTable(dgvBatch);
                    //}
                }
            }



        }

        private void dgvBatch_SelectionChanged(object sender, EventArgs e)
        {
            if ((sender as DataGridView).RowCount > 0)
            {
                sBatchID = SelectRow("Batch", (sender as DataGridView).CurrentRow.Index);
                UpdateTable("Dosing");
            }
            else            
            { 
                lBatchSelect.Text = "Замес не найден";
                sBatchID = "0";
                UpdateTable("Dosing");
            } 
               
                
            //ResizeTable(dgvDosing);
        }

        private void tsbExportHTMLBatch_Click(object sender, EventArgs e)
        {
            string sFileName = "Отчет по замесу ID" + sBatchID;
            SaveToHtml(sFileName,false);

        }

        private void tsbPrintBatch_Click(object sender, EventArgs e)
        {
            //if (this.PrintDGV != null)
            //    this.PrintDGV(this, e);
            fReport = new formReport();

            //System.Data.DataTable Batch= this.DS.Tables["ReportBatch"].AsEnumerable().Where(row => row.Field<String>("ID").ToString() == sBatchID).AsDataView().ToTable();

            System.Data.DataTable Batch = this.DS.Tables["ReportBatch"].Select("ID = " + sBatchID).CopyToDataTable();
            ReportDataSource rdsBatch = new ReportDataSource("dsBatch", Batch); // ReportViewerDataSource : ReportViewer is to be bind to this DataSource

            UpdateTable("DosingByOrder");

            rdsDosing = new ReportDataSource("DS", this.DS.Tables["ReportDosingByOrder"]); // ReportViewerDataSource : ReportViewer is to be bind to this DataSource


            fReport.rvViewer.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
                                                              //fReport.rvViewer.LocalReport.ReportEmbeddedResource = "Report2.rdlc"; // bind reportviewer with .rdlc
            fReport.rvViewer.LocalReport.ReportEmbeddedResource = "Reports\\rReportByBatchID"; // bind reportviewer with .rdlc
            fReport.rvViewer.LocalReport.ReportPath = "Reports\\rReportByBatchID.rdlc";
            fReport.rvViewer.LocalReport.DataSources.Add(rdsBatch); //bind ReportViewer1 to the new datasource(Which you wish)
            fReport.rvViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);


            fReport.rvViewer.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case

            // Создаем параметры
            string sReportTitle = "замесу ID="+ sBatchID;
            ReportParameter param1 = new ReportParameter("ReportTitle", sReportTitle);
            ReportParameter param2 = new ReportParameter("ProjectName", Properties.Settings.Default.ProjectName.ToString());
            ReportParameter[] param = { param1, param2};

            fReport.rvViewer.LocalReport.SetParameters(param);
            fReport.rvViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            fReport.ShowDialog();
        }

        private void SubreportProcessingEventHandler(object sender,SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(rdsDosing);
        }

        private void tsbPrintOrder_Click(object sender, EventArgs e)
        {
            fReport = new formReport();
            ReportDataSource rdsBatch = new ReportDataSource("dsBatch", this.bsBatch); // ReportViewerDataSource : ReportViewer is to be bind to this DataSource

            UpdateTable("DosingByOrder");

            rdsDosing = new ReportDataSource("DS", this.DS.Tables["ReportDosingByOrder"]); // ReportViewerDataSource : ReportViewer is to be bind to this DataSource


            fReport.rvViewer.LocalReport.DataSources.Clear(); // Clear the Previous DataSource of ReportViewer
                                                              //fReport.rvViewer.LocalReport.ReportEmbeddedResource = "Report2.rdlc"; // bind reportviewer with .rdlc
            fReport.rvViewer.LocalReport.ReportEmbeddedResource = "Reports\\rReportByBatchID"; // bind reportviewer with .rdlc
            fReport.rvViewer.LocalReport.ReportPath = "Reports\\rReportByBatchID.rdlc";
            fReport.rvViewer.LocalReport.DataSources.Add(rdsBatch); //bind ReportViewer1 to the new datasource(Which you wish)
            fReport.rvViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);


            fReport.rvViewer.LocalReport.Refresh(); // Refresh the ReportViewer Control, ReportViewer1 in this case

            // Создаем параметры
            string sReportTitle = "заказу ID=" + sOrderID;
            ReportParameter param1 = new ReportParameter("ReportTitle", sReportTitle);
            ReportParameter param2 = new ReportParameter("ProjectName", Properties.Settings.Default.ProjectName.ToString());
            ReportParameter[] param = { param1, param2 };

            fReport.rvViewer.LocalReport.SetParameters(param);
            fReport.rvViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            fReport.ShowDialog();
        }

        private void tsbExportHTMLOrder_Click(object sender, EventArgs e)
        {
            string sFileName = "Отчет по заказу ID" + sOrderID;
            SaveToHtml(sFileName,true);
        }
    }
}

