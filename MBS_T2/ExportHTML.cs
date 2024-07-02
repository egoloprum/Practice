using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace MBS
{
    public static class ExportHTML
    {
        public static void DGVToHtml(DataGridView dgv, String sFileName, ProgressBar PB, bool AlarmMode=false)
        {
            XmlWriter writer = null;

            try
            {
                //Прогресс
                //this.lOperation.Text = "Выполняется экспорт данных в HTML...";
                //this.Main_StatusStrip.Update();

                string sFilePatch = Properties.Settings.Default.ReportPatch;
                
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("\t");
                settings.OmitXmlDeclaration = true;
                settings.Encoding = Encoding.UTF8;
                string fn = sFilePatch + "\\" + sFileName + ".html";

                if (File.Exists(fn))
                {
                    //File.Delete(xls);
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.DefaultExt = ".html";
                    sf.InitialDirectory = sFilePatch;
                    sf.FileName = sFileName;
                    if (sf.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    fn = sf.FileName;
                }
                writer = XmlWriter.Create(fn, settings);

                writer.WriteStartElement("table");
                writer.WriteAttributeString("border", "0");
                writer.WriteAttributeString("cellspacing", "1");
                writer.WriteAttributeString("cellpadding", "3");
                writer.WriteAttributeString("bgcolor", "#000000");
                writer.WriteStartElement("tbody");

                // Запись заголовка таблицы HTML:
                writer.WriteStartElement("tr");
                writer.WriteAttributeString("style", "background-color: #e0effe;");
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    writer.WriteElementString("th", column.HeaderText);
                }
                writer.WriteEndElement();  // закрытие тега tr
                                           // Запись всех строк:
                int rowstart = 0;
                int rowidx = rowstart;
                int rowend = dgv.Rows.Count - 1;
                //Прогресс
                PB.Maximum = dgv.Rows.Count;
                //this.lOperation.Visible = true;
                foreach (DataGridViewRow row in dgv.Rows)
                {

                    //Прогресс (прирост значения)
                    if (PB.Value == PB.Maximum)
                    { PB.Value = PB.Minimum; }
                    PB.Value += 1;

                    writer.WriteStartElement("tr");
                    //цвета фона и текста я чейки
                    string sBackColor = "#ffffff";
                    string sForeColor = "#000000";
                    if (row.DefaultCellStyle.BackColor != null & row.DefaultCellStyle.BackColor != Color.Empty)
                        sBackColor = $"#{row.DefaultCellStyle.BackColor.R:X2}{row.DefaultCellStyle.BackColor.G:X2}{row.DefaultCellStyle.BackColor.B:X2}";
                    if (row.DefaultCellStyle.ForeColor != null & row.DefaultCellStyle.ForeColor != Color.Empty)
                        sForeColor = $"#{row.DefaultCellStyle.ForeColor.R:X2}{row.DefaultCellStyle.ForeColor.G:X2}{row.DefaultCellStyle.ForeColor.B:X2}";
                    writer.WriteAttributeString("style", "background-color: " + sBackColor + "; color:" + sForeColor + ";");

                    foreach (DataGridViewCell column in row.Cells)
                    {
                        if (null != column.FormattedValue)
                        {
                            writer.WriteStartElement("td");
                            writer.WriteString(column.FormattedValue.ToString());
                            writer.WriteEndElement();  // закрытие тега td
                        }
                        else
                            writer.WriteElementString("td", " ");
                    }
                    writer.WriteEndElement();  // закрытие тега tr
                    rowidx++;
                }
                writer.WriteEndElement();  // закрытие тега tbody
                writer.WriteEndElement();  // закрытие тега table
                writer.Flush();
                writer.Close();

                //ProgressControl.Clear();
                DialogResult res = MessageBox.Show("Экспорт завершен. Открыть файл?", "Экспорт выполнен", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(fn);
                    //Прогресс сбрасываем
                    //this.lOperation.Text = "";
                    PB.Value = 0;
                }

                if (res == DialogResult.No)
                    //Прогресс сбрасываем
                    //this.lOperation.Text = "";
                    PB.Value = 0;
                {
                }
            }
            finally
            {
                if (writer != null)
                    writer.Close();
                //GC.GetTotalMemory(true);
            }
        }
    }
}
