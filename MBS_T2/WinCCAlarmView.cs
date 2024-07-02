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
using System.Xml;
using System.Xml.XPath;
using static System.Windows.Forms.AxHost;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing.Printing;

namespace MBS
{
    public partial class WinCCAlarmView : System.Windows.Forms.UserControl
    {
        public string TableName;
        public string Request;

        public SqlConnection SqlConn =new SqlConnection();
        DataSet DS = new DataSet();
        SqlCommandBuilder cmdBuilder;
        BindingSource BS = new BindingSource();
        SqlDataAdapter DA;
        System.Data.DataTable DTBuffer = new System.Data.DataTable();
        //Point point = new Point();
        public event EventHandler ExportExcell;
        public event EventHandler ExportHTML;
        public event EventHandler PrintDGV;

        public WinCCAlarmView()
        {
            InitializeComponent();
        }
        public void LoadTable()
        {
            try
            {
                UpdateTable();
                //DS.Tables.Add(TableName);
                //BS.DataSource = DS;
                //BS.DataMember = TableName;

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
                    this.DGV.Columns["Дата и время"].Width= 130;
                    this.DGV.Columns["Категория"].Width = 120;
                    this.DGV.Columns["Состояние"].Width = 190;
                    this.DGV.Columns["Событие"].Width= 500;
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

        public int UpdateTable()
        {
            string SelectCommand = Request;

            //MessageBox.Show(Properties.Settings.Default.AlarmConnectionString.ToString());

            try
            {
                if (DS.Tables.Contains(TableName)) { DS.Tables[TableName].Clear(); }
                this.DA = new SqlDataAdapter(SelectCommand, SqlConn);
                cmdBuilder = new SqlCommandBuilder(DA);
                this.DA.Fill(DS, TableName);
                BS.DataSource = DS;
                BS.DataMember = TableName;

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
            }
        }
        //private int WinCCAlarmStyle()
        //{
        //    //try
        //    //{

        //    //    this.UpdatingCount = this.DGV.Rows.Count;
        //    //    ;

        //    //    foreach (DataGridViewRow dgvRow in this.DGV.Rows)
        //    //    {


        //    //        //if (dgvRow.Cells["Состояние"].Value.ToString() == "1") dgvRow.Cells["Состояние"].Value = "ПРИШЛО";
        //    //        //else dgvRow.Cells["Состояние"].Value = "УШЛО";



        //    //        if (dgvRow.Cells["Категория"].Value != null)
        //    //        {
        //    //            XmlNode AlarmStyle = null;
        //    //            XmlDocument AlarmClassXML = new XmlDocument();
        //    //            AlarmClassXML.Load("WinCCAlarmClassInfo.xml");

        //    //            XmlNode AlarmClass = AlarmClassXML.DocumentElement.SelectSingleNode("//AlarmClass[@ID='" + dgvRow.Cells["Категория"].Value.ToString() + "']");
        //    //            if (AlarmClass != null)
        //    //            {

        //    //                //if (AlarmClass.SelectSingleNode("./InfoRu").InnerText != null)
        //    //                if (AlarmClass.Attributes["Info"].Value != null)

        //    //                    //{ e.Value = AlarmClass.Attributes["Info"].Value.ToString(); }// AlarmClass.ChildNodes[0].InnerText

        //    //                    if (dgvRow.Cells["Состояние"].Value.ToString() == "1") { AlarmStyle = AlarmClass.SelectSingleNode("./IncomingAlarmStyle"); }
        //    //                    else { AlarmStyle = AlarmClass.SelectSingleNode("./OutgoingAlarmStyle"); }

        //    //                if (AlarmStyle != null)
        //    //                {
        //    //                    //Цвет фона
        //    //                    string rgbString = AlarmStyle.Attributes["BackgroundColor"].Value;// AlarmClass.ChildNodes[0].InnerText;//"BackgroundColor".Value
        //    //                    if (rgbString != null)
        //    //                    {
        //    //                        string[] rgbComponents = rgbString.Split(',');
        //    //                        int red = int.Parse(rgbComponents[0]);
        //    //                        int green = int.Parse(rgbComponents[1]);
        //    //                        int blue = int.Parse(rgbComponents[2]);
        //    //                        dgvRow.DefaultCellStyle.BackColor = Color.FromArgb(red, green, blue);
        //    //                    }
        //    //                    //Цвет шрифта
        //    //                    rgbString = AlarmStyle.Attributes["FontColor"].Value;//AlarmClass.SelectSingleNode("./FontColor").InnerText;
        //    //                    if (rgbString != null)
        //    //                    {
        //    //                        string[] rgbComponents = rgbString.Split(',');
        //    //                        int red = int.Parse(rgbComponents[0]);
        //    //                        int green = int.Parse(rgbComponents[1]);
        //    //                        int blue = int.Parse(rgbComponents[2]);
        //    //                        dgvRow.DefaultCellStyle.ForeColor = Color.FromArgb(red, green, blue);
        //    //                    }
        //    //                }
        //    //                EventArgs e = null;
        //    //                this.UpdatingRun(this, e);
        //    //                UpdatingProgress += 1;
        //    //            }
        //    //        }
        //    //    }
        //    //    //ProgressControl.Clear();
        //    return 0;
        //    //}

        //    //catch (System.Exception ex)
        //    //{
        //    //    //ProgressControl.Clear();
        //    //    General.ErrorMessage(ex);
        //    //    return ex.HResult;
        //    //}
        //    //finally
        //    //{
        //    //}
        //}



        private void dataGridView1_CellFormatting(object sender,
                                          DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex==0)
                //{
                //    if (this.DGV.Rows[e.RowIndex].Cells["Состояние"].Value != null)
                //    {
                //        string sState = this.DGV.Rows[e.RowIndex].Cells["Состояние"].Value.ToString();
                //        //this.DGV.Columns["Состояние"].DefaultCellStyle.Format.S
                //         this.DGV.Columns["Состояние"].ValueType = typeof(String);
                //        if (sState == "1") this.DGV.Rows[e.RowIndex].Cells["Состояние"].Value = "ПРИШЛО";
                //        else this.DGV.Rows[e.RowIndex].Cells["Состояние"].Value = "УШЛО";
                //    }



                //    //XmlNode node = null;
                //    if (this.DGV.Rows[e.RowIndex].Cells["Категория"].Value != null)
                //    {
                //        XmlNode AlarmStyle = null;
                //        XmlDocument AlarmClassXML = new XmlDocument();
                //        AlarmClassXML.Load("WinCCAlarmClassInfo.xml");

                //        XmlNode AlarmClass = AlarmClassXML.DocumentElement.SelectSingleNode("//AlarmClass[@ID='" + this.DGV.Rows[e.RowIndex].Cells["Категория"].Value.ToString() + "']");
                //        if (AlarmClass != null)
                //        {

                //            //if (AlarmClass.SelectSingleNode("./InfoRu").InnerText != null)
                //            if (AlarmClass.Attributes["Info"].Value != null)

                //            { this.DGV.Rows[e.RowIndex].Cells["Категория"].Value = AlarmClass.Attributes["Info"].Value.ToString(); }// AlarmClass.ChildNodes[0].InnerText

                //            if (this.DGV.Rows[e.RowIndex].Cells["Состояние"].Value.ToString() == "1") { AlarmStyle = AlarmClass.SelectSingleNode("./IncomingAlarmStyle"); }
                //            else { AlarmStyle = AlarmClass.SelectSingleNode("./OutgoingAlarmStyle"); }

                //            if (AlarmStyle != null)
                //            {
                //                //Цвет фона
                //                string rgbString = AlarmStyle.Attributes["BackgroundColor"].Value;// AlarmClass.ChildNodes[0].InnerText;//"BackgroundColor".Value
                //                if (rgbString != null)
                //                {
                //                    string[] rgbComponents = rgbString.Split(',');
                //                    int red = int.Parse(rgbComponents[0]);
                //                    int green = int.Parse(rgbComponents[1]);
                //                    int blue = int.Parse(rgbComponents[2]);
                //                    this.DGV.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(red, green, blue);
                //                }
                //                //Цвет шрифта
                //                rgbString = AlarmStyle.Attributes["FontColor"].Value;//AlarmClass.SelectSingleNode("./FontColor").InnerText;
                //                if (rgbString != null)
                //                {
                //                    string[] rgbComponents = rgbString.Split(',');
                //                    int red = int.Parse(rgbComponents[0]);
                //                    int green = int.Parse(rgbComponents[1]);
                //                    int blue = int.Parse(rgbComponents[2]);
                //                    this.DGV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(red, green, blue);
                //                }
                //            }

                //        }
                //    }

                //}

                if (this.DGV.Columns[e.ColumnIndex].Name.Equals("Состояние"))
                {
                    if (e.Value != null)
                    {
                        //http://ste.nichost.ru/siemens/pdf/rus/WinCC_flexible_2005_p2_r.pdf WinCC flexible 2005 Компактная\ Стандартная\ Расширенная
                        //Руководство пользователя, редакция 06\2005, 6AV6691 - 1AB01 - 0AB0
                        //0 = Поступило / Ушло
                        //1 = Поступило
                        //2 = Поступило / Квитировано / Ушло
                        //3 = Поступило / Квитировано
                        //6 = Поступило / Ушло / Квитировано
                        switch (e.Value.ToString())
                        {
                            case "0":
                                e.Value = "ПРИШЛО/УШЛО";
                                break;

                            case "1":
                                e.Value = "ПРИШЛО";
                                break;

                            case "2":
                                e.Value = "ПРИШЛО/КВИТИРОВАНО/УШЛО";
                                break;

                            case "3":
                                e.Value = "ПРИШЛО/КВИТИРОВАНО";
                                break;

                            case "6":
                                e.Value = "ПРИШЛО/УШЛО/КВИТИРОВАНО";
                                break;

                            default:
                                e.Value = "";
                                break;
                        }

                    }
                }

                if (this.DGV.Columns[e.ColumnIndex].Name.Equals("Категория"))//ValueType == DateTime)
                {
                    XmlNode AlarmStyle = null;
                    XmlDocument AlarmClassXML = new XmlDocument();
                    AlarmClassXML.Load("SettingsXML/WinCCAlarmClassInfo.xml");

                    //XmlNode node = null;
                    if (e.Value != null)
                    {
                        
                        XmlNode AlarmClass = AlarmClassXML.DocumentElement.SelectSingleNode("//AlarmClass[@ID='" + e.Value.ToString() + "']");
                        if (AlarmClass != null)
                        {

                            //if (AlarmClass.SelectSingleNode("./InfoRu").InnerText != null)
                            if (AlarmClass.Attributes["Info"].Value != null)

                            { e.Value = AlarmClass.Attributes["Info"].Value.ToString(); }// AlarmClass.ChildNodes[0].InnerText
                            string sSts = this.DGV.Rows[e.RowIndex].Cells["Состояние"].Value.ToString();
                            if (sSts == "1"| sSts == "3") { AlarmStyle = AlarmClass.SelectSingleNode("./IncomingAlarmStyle"); }
                            else { AlarmStyle = AlarmClass.SelectSingleNode("./OutgoingAlarmStyle"); }

                            if (AlarmStyle != null)
                            {
                                //Цвет фона
                                string rgbString = AlarmStyle.Attributes["BackgroundColor"].Value;// AlarmClass.ChildNodes[0].InnerText;//"BackgroundColor".Value
                                if (rgbString != null)
                                {
                                    string[] rgbComponents = rgbString.Split(',');
                                    int red = int.Parse(rgbComponents[0]);
                                    int green = int.Parse(rgbComponents[1]);
                                    int blue = int.Parse(rgbComponents[2]);
                                    this.DGV.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(red, green, blue);
                                }
                                //Цвет шрифта
                                rgbString = AlarmStyle.Attributes["FontColor"].Value;//AlarmClass.SelectSingleNode("./FontColor").InnerText;
                                if (rgbString != null)
                                {
                                    string[] rgbComponents = rgbString.Split(',');
                                    int red = int.Parse(rgbComponents[0]);
                                    int green = int.Parse(rgbComponents[1]);
                                    int blue = int.Parse(rgbComponents[2]);
                                    this.DGV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(red, green, blue);
                                }

                            }
                            else
                            {
                                this.DGV.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                this.DGV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                            }

                        }
                        else
                        {
                            this.DGV.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                            this.DGV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }

            catch (System.Exception ex)
            {

                General.ErrorMessage(ex);
            }
            finally
            {
            }
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
            //WinCCAlarmStyle();
        }

        private void SortStringChanged(object sender, EventArgs e)
        {
            this.BS.Sort = ((ADGV.AdvancedDataGridView)sender).SortString;
            //WinCCAlarmStyle();
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            this.DGV.ClearFilter(true);
            //WinCCAlarmStyle();
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

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.PrintDGV != null)
                this.PrintDGV(this, e);
        }

        private void tsbExportHTML_Click(object sender, EventArgs e)
        {
            if (this.ExportHTML != null)
                this.ExportHTML(this, e);
        }
    }
}
