using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Xml;
using System.Windows.Forms;

namespace MBS
{
    class ProjectInfo
    {
        //Проект
        private string _project = "";
        public string Project
        {
            get { return _project; }
            set { _project = value; }
        }
        //Строка подключения
        private string _connectionString = "";
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        //Имя
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //Описание
        private string _description = "";
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        //Описание
        private string _default = "";
        public string Default
        {
            get { return _default; }
            set { _default = value; }
        }
        //Файл где храниться информация
        public static string FilePath
        {
            get
            {
                return "SettingsXML/ProjectInfo.xml";
            }
        }

        public ProjectInfo(string project, string connectionString)
        {
            Project = project;
            ConnectionString = connectionString;

        }

        public int Save()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    XmlTextWriter textWritter = new XmlTextWriter(FilePath, Encoding.UTF8);
                    textWritter.WriteStartDocument();
                    textWritter.WriteStartElement("Projects");
                    textWritter.WriteEndElement();
                    textWritter.Close();
                }

                XmlDocument document = new XmlDocument();
                document.Load(FilePath);
                //XmlNode node = null;

                bool InfoExist = false;
                XmlNodeList cl = document.DocumentElement.ChildNodes;
                foreach (XmlNode n in cl)
                {
                    if (string.Compare(n.Attributes["ID"].Value, _project, true) == 0)
                    {
                        if (string.Compare(n.ChildNodes[0].InnerText, _connectionString, true)==0)
                        {
                           //элемент найден, обновляем
                            InfoExist = true;
                            if (MessageBox.Show("Такое подключение уже существует. Вы хотите обновить информацию?", "Добавление нового подключения",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                            {
                                n.ChildNodes[1].InnerText = _name;
                                n.ChildNodes[2].InnerText = _description;
                            }
                        }
                    }
                }
                //если элемент не был найден, то добавляем
                if (!InfoExist)
                {
                    XmlNode element = document.CreateElement("Project");
                    document.DocumentElement.AppendChild(element); // указываем родителя
                    XmlAttribute attribute = document.CreateAttribute("ID"); // создаём атрибут
                    attribute.Value = _project; // устанавливаем значение атрибута
                    element.Attributes.Append(attribute); // добавляем атрибут

                    XmlNode subElement0 = document.CreateElement("ConnectionString"); // даём имя
                    subElement0.InnerText = _connectionString; // и значение
                    element.AppendChild(subElement0); // и указываем кому принадлежит

                    element.Attributes.Append(attribute); // добавляем атрибут
                    XmlNode subElement1 = document.CreateElement("Name"); // даём имя
                    subElement1.InnerText = _name; // и значение
                    element.AppendChild(subElement1); // и указываем кому принадлежит

                    element.Attributes.Append(attribute); // добавляем атрибут
                    XmlNode subElement2 = document.CreateElement("Description"); // даём имя
                    subElement2.InnerText = _description; // и значение
                    element.AppendChild(subElement2); // и указываем кому принадлежит

                    element.Attributes.Append(attribute); // добавляем атрибут
                    XmlNode subElement3 = document.CreateElement("Default"); // даём имя
                    subElement3.InnerText = _default; // и значение
                    element.AppendChild(subElement3); // и указываем кому принадлежит

                    MessageBox.Show("Подключение к проекту добавлено", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



                document.Save(FilePath);
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return ex.HResult;
            }
            return 0;
        }
        public int Delete()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(FilePath);

                //XmlNode node = null;
                XmlNodeList cl = document.DocumentElement.ChildNodes;

                foreach (XmlNode n in cl)
                {
                    if (string.Compare(n.Attributes["ID"].Value, _project, true)==0 )
                    {
                        if (string.Compare(n.ChildNodes[0].InnerText, _connectionString, true) == 0)
                        {
                            document.DocumentElement.RemoveChild(n);   
                        }

                    }
                                     
                }

                document.Save(FilePath);


                //XmlElement root = document.DocumentElement;
                //XmlElement element = document.GetElementById(_project);// Только что нужно подставить здесь?
                //root.RemoveChild(element);
                //document.Save(FilePath);
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return ex.HResult;
            }            
            return 0;
        }

        public int SetDefault()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(FilePath);

                //XmlNode node = null;
                XmlNodeList cl = document.DocumentElement.ChildNodes;

                foreach (XmlNode n in cl)
                {
                    if (string.Compare(n.Attributes["ID"].Value, _project, true) == 0)
                    {
                        if (string.Compare(n.ChildNodes[0].InnerText, _connectionString, true) == 0)
                        {
                            n.ChildNodes[3].InnerText = "1";
        
                            //document.DocumentElement.RemoveChild(n);
                        }

                    }
                    else
                    {
                        n.ChildNodes[3].InnerText = "0";
                    }

                }

                document.Save(FilePath);


                //XmlElement root = document.DocumentElement;
                //XmlElement element = document.GetElementById(_project);// Только что нужно подставить здесь?
                //root.RemoveChild(element);
                //document.Save(FilePath);
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return ex.HResult;
            }
            return 0;
        }
    }

    //class ProjectInfoDGV
    //{
    //    public DataGridView DGV_ProjectInfo;
    //    public DataSet DS_ProjectInfo;
    //    public void UpdateProjects()
    //    {
    //        DS_ProjectInfo.Clear();
    //        DS_ProjectInfo.ReadXml(ProjectInfo.FilePath);
    //        DGV_ProjectInfo.DataSource = DS_ProjectInfo;
    //        DGV_ProjectInfo.DataMember = "Project";
    //        DGV_ProjectInfo.Columns["ID"].HeaderText = "Проект"; DGV_ProjectInfo.Columns["ID"].Width = 60;
    //        DGV_ProjectInfo.Columns["ConnectionString"].HeaderText = "Строка подключения"; DGV_ProjectInfo.Columns["ConnectionString"].Width = 160;
    //        DGV_ProjectInfo.Columns["Name"].HeaderText = "Наименование"; DGV_ProjectInfo.Columns["Name"].Width = 60;
    //        DGV_ProjectInfo.Columns["Description"].HeaderText = "Описание"; DGV_ProjectInfo.Columns["Description"].Width = 160;
    //    }
    //}
}
