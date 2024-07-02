using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace MBS
{
    public class ExportDocs
    {
        
        public static int ExportToWord(string FileName){
            //http://101teist.blogspot.ru/2011/09/c-word.html
            //http://alexanderkobelev.blogspot.co.uk/2011/02/word-c-40.html
            //http://www.csharpcoderr.com/2014/02/microsoft-word-1.html
            //http://hiprog.com/index.php?option=com_content&task=view&id=375&Itemid=35

            System.Type officeType = System.Type.GetTypeFromProgID("Word.Application");

            if (officeType == null)
            {
                // Word is not installed.
                MessageBox.Show("Приложение Microsoft Word не установленно на компьютере. Формирование документа не может быть выполнено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else
            {
                // Word is installed.
                //создаем обьект приложения word
                Word._Application application = null;
                Word._Document document = null;
                // если вылетим не этом этапе, приложение останется открытым
                try
                {
                    application = new Word.Application();
                    document = application.Documents.Add(FileName);
                    //меняем свойства документа
                    foreach (dynamic prop in document.CustomDocumentProperties)
                    {
                        //MessageBox.Show(prop.Name+ "=" +prop.Value);
                        string str = "select  top 1 [Value] from [tProjectInfo] where [Use] +  [Setting]= '" + prop.Name + "'";
                        SqlCommand myCommand = new SqlCommand(str, SQLControls.CurrentConnection);
                        SqlDataReader SqlReader = myCommand.ExecuteReader();
                        string sText = "?Значение не найдено?";
                        while (SqlReader.Read())
                        {
                            if (!SqlReader.IsDBNull(0))
                                sText = SqlReader.GetString(0);
                        }
                        SqlReader.Close();
                        prop.Value = sText;
                        //MessageBox.Show(prop.Name + "=" + prop.Value);
                    }
                    //обновляем поля в теле документа
                    document.Fields.Update();
                    //обновляем поля в колонтитулах документа
                    application.ScreenUpdating = false; //Отключение обновления экрана
                    document.PrintPreview(); //Предварительный просмотр
                    document.ClosePrintPreview(); //Закрыть предварительный просмотр
                    application.ScreenUpdating = true; //Обновить экран


                    //вставляем таблицы

                    foreach (Word.Bookmark bookmark in document.Bookmarks)
                    {
                        //получаем текст запроса в зависимости от метки
                        //MessageBox.Show(bookmark.Name);

                        //заполняем таблизу запросом
                        string str = @"Select ROW_NUMBER() OVER(ORDER BY [tObject].[Object]) as [№], [tObject].[Object] as [Позиция],
                                [tObject].[Description] as [Наименование], 0 as [Мин.шкалы], 100 as [Макс.шкалы],'%' as [Ед.изм.], 
                                10 as [НАГ], 20 as [НРГ], 80 as [ВРГ], 90 as [ВАГ], [tSignal].[Type] as [Тип сигнала], 'погр. 0,025%' as [Характеристика сигнала],
                                'SU1' as [Шкаф], 'A1' as [Модуль], '1' as [Канал],[tObject].[Class] as [Тип оборудования], '' as [Примечание] 
                                from tObject INNER JOIN tSignal ON tObject.Class =tSignal.Class
                                where [tSignal].[T]='AI'";
                        SqlDataAdapter DA = new SqlDataAdapter(str, SQLControls.CurrentConnection);
                        SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(DA);
                        DataTable DT = new DataTable();
                        DA.Fill(DT);

                        //заполняем таблицу документа данными
                        Word.Table tbl = bookmark.Range.Tables[1];
                        //Word.Rows mrows = bookmark.Range.Rows;

                        //определяем строки заголовков
                        int hRow = 1;
                        bool head = true;
                        while (head)
                        {
                            hRow++; //связано с тем, что если в таблице есть объединение, то индексы ячеек пропускаются
                            try { head = (tbl.Cell(hRow, 1).Range.Rows.HeadingFormat != 0); }
                            catch { }
                        }
                        //определяем число столбцов
                        int nColumns = DT.Columns.Count;
                        if (tbl.Columns.Count != nColumns)
                        {
                            // MessageBox.Show();
                            if (tbl.Columns.Count < nColumns) nColumns = tbl.Columns.Count;
                        }
                        //вносим данные
                        for (int r = 0; r < DT.Rows.Count; r++)
                        {
                            for (int c = 0; c < nColumns; c++)
                            {
                                var cell = tbl.Cell(r + hRow, c + 1);
                                cell.Range.Text = DT.Rows[r][c].ToString();
                                //если эта строка последняя, а данные еще не кончились - то добавляем еще строку
                                if (DT.Rows.Count > (tbl.Rows.Count - hRow + 1)) tbl.Rows.Add();
                            }
                        }
                    }

                    //document.TablesOfContents[1].Update(); //обновляем содержание
                    application.Visible = true;
                    //document.SaveAs(ProjectSettings.DefaultPath +ProjectSettings.ProjectCod + "В1.doc");
                    //document.Close();
                    //application.Quit();
                    // document = null;
                    // application = null;
                    return 0;
                }
                catch (System.Exception ex)
                {
                    try
                    {
                        document.Close();
                    }
                    catch { }
                    application.Quit();
                    document = null;
                    application = null;
                    General.ErrorMessage(ex); ;
                    //throw ex;
                    return ex.HResult;
                }
            }              
        } 
    }
}