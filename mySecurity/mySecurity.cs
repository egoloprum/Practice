using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Data;

namespace mySecurity
{
    [Serializable()]

    class General
    {
        public static int ErrorMessage(System.Exception ex)
        {
            #if DEBUG
                        MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #else
                       MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endif
            return 0;
        }
    }


           

    public class myUser
    {
        //Пользователь
        private string _user = "";
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        //Логин
        private string _login = "";
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        //Пароль (не храним, только запись)
        private double _key = 0;
        public string Password
        {
            set { _key = _encryption(_login, value); }
        }
        //Ключ (только чтение)
        public double Key
        {
            get { return _key; }
        }
        //Роль
        private int _role = 0;
        public int Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public static string UsersFilePath {
            get
            {
                return "SettingsXML\\UserInfo.xml";
            }
        }

        public static string RolesFilePath
        {
            get
            {
                return "SettingsXML\\RolesInfo.xml";
            }
        }

        public static string[] Roles = new string[5] {
            "Гость",
            "Технолог",
            "Проектировщик",
            "Программист",
            "Администратор"};

        public myUser(string user, string login, string password, int role)
        {
            User = user;
            Login = login;
            Password = password;
            Role = role;
        }

         public myUser()
        {
        }

         public static int LogIn(string sLogin, string sPassword)
         {
             try
             {
                 double Key = myUser._encryption(sLogin, sPassword); //формируем ключь из логина и пароля
                 string sUser = "Не авторизован";
                 int iRole = 0;

                 //проверяем соответсвует ли ключ сохраненному
                 DataSet UsersDataSet = new DataSet();
                 UsersDataSet.ReadXml(myUser.UsersFilePath);
                 DataTable dtUsers = UsersDataSet.Tables["User"];
                 DataRow[] currentRows = dtUsers.Select(null, null, DataViewRowState.CurrentRows);                                  
                 foreach (DataRow row in currentRows)
                 {
                     if (Convert.ToDouble(row["Key"].ToString()) == Key)
                     {
                         sUser = row["Name"].ToString();
                         iRole = Convert.ToInt32(row["Role"].ToString());
                         return 0;
                     }
                 }
                 MessageBox.Show("Неправильный логин или пароль", "Авторизация пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return 1;
             }
             catch (System.Exception ex)
             {
                 MessageBox.Show(ex.Message, "Авторизация пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return ex.HResult;
             }

         }

        //public static string pathToXml{
        //#if DEBUG 
        //    get
        //    {
        //        return Application.StartupPath.Replace("\\bin\\Debug","");
        //    }
        //#else
        //    get
        //    {
        //        return Application.StartupPath;
        //    }
        //#endif   
        //}
        //private XmlTextWriter textWritter = new XmlTextWriter(pathToXml, Encoding.UTF8);

        private static double _encryption(string login, string password)
        {
            // конвертируем string в байт массив
            byte[] bLogin = Encoding.UTF8.GetBytes(login);
            string mLogin = Convert.ToBase64String(bLogin);
            byte[] mas0 = Convert.FromBase64String(mLogin);

            byte[] bPassword = Encoding.UTF8.GetBytes(password);
            string mPassword = Convert.ToBase64String(bPassword);
            byte[] mas1 = Convert.FromBase64String(mPassword);

            // суммируем компоненты байт массива 
            int mas0Sum = 0;
            foreach (byte i in mas0)
            {
                mas0Sum += Convert.ToInt32(i);
            }
            int mas1Sum = 0;
            foreach (byte i in mas1)
            {
                mas1Sum += Convert.ToInt32(i);
            }
            // полученные суммы байт массивов обрабатываем односторонней функцией 
            //(возводим в 2 степень, и перемножаем) 
            double totalSum = Math.Pow(Convert.ToDouble(mas0Sum), 2.0) * Math.Pow(Convert.ToDouble(mas1Sum), 2.0);
            return totalSum;
            //}
        }

        public static string GetClassDescription
        {
            get
            {
                return "Класс myUser. Используется для управления пользователями и ролями";
            }

        }

        public void Print() 
        {
            string sPrint = "User: " + _user + "\r\n Login: " + _login + "\r\n Key :" + Key + "\r\n Role :" + _role;
            MessageBox.Show(sPrint, "MyUser", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public int Add() 
        {
            // https://msdn.microsoft.com/ru-ru/library/ekw4dh3f.aspx
            ////Серелизация объекта, вариант 1
            //Stream stream = File.Open(XMLPath, FileMode.Create);
            //SoapFormatter formatter = new SoapFormatter();
            //formatter.Serialize(stream, this);
            //stream.Close();

            ////Серелизация объекта, вариант 2
            //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(myUser));
            //System.IO.FileStream file = System.IO.File.Create(XMLPath);
            //writer.Serialize(file, this);
            //file.Close();
            try {
                if (!File.Exists(myUser.UsersFilePath))
                {
                    XmlTextWriter textWritter = new XmlTextWriter(myUser.UsersFilePath, Encoding.UTF8);
                    textWritter.WriteStartDocument();
                    textWritter.WriteStartElement("Users");
                    textWritter.WriteEndElement();
                    textWritter.Close();
                }

                XmlDocument document = new XmlDocument();
                document.Load(myUser.UsersFilePath);

                //проверяем, есть ли уже такой пользователь
                bool UserExist = false;
                XmlNodeList cl = document.DocumentElement.ChildNodes;
                foreach (XmlNode n in cl)
                {
                    if (string.Compare(n.Attributes["Name"].Value, _user, true) == 0)
                    {
                            UserExist = true;
                            if (MessageBox.Show("Пользователь " + _user + " уже существует . Вы хотите обновить информацию?", "Пользователь",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                            {
                                n.ChildNodes[0].InnerText = _login;
                                n.ChildNodes[1].InnerText = _key.ToString();
                                n.ChildNodes[2].InnerText = _role.ToString();
                                //MessageBox.Show("Информация обновлена", "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                    }
                }
                document.Save(myUser.UsersFilePath);
                document = null;
                //пользователь не найден - добавляем информацию
                if (!UserExist)
                {
                    Save(_user, _login, _key.ToString(), _role.ToString());
                    //XmlNode element = document.CreateElement("User");
                    //document.DocumentElement.AppendChild(element); // указываем родителя
                    //XmlAttribute attribute = document.CreateAttribute("Name"); // создаём атрибут
                    //attribute.Value = _user; // устанавливаем значение атрибута

                    //element.Attributes.Append(attribute); // добавляем атрибут
                    //XmlNode subElement1 = document.CreateElement("Login"); // даём имя
                    //subElement1.InnerText = _login; // и значение
                    //element.AppendChild(subElement1); // и указываем кому принадлежит

                    //XmlNode subElement2 = document.CreateElement("Key");
                    //subElement2.InnerText = _key.ToString();
                    //element.AppendChild(subElement2);

                    //XmlNode subElement3 = document.CreateElement("Role");
                    //subElement3.InnerText = _role.ToString();
                    //element.AppendChild(subElement3);

                    //MessageBox.Show("Пользователь успешно добавлен", "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



                //document.Save(myUser.UsersFilePath);                        
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Добавление пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.HResult;
            }
            
            return 0;        
        }
        public static int Save(string sUser, string sLogin, string sKey, string sRole)
        {
            try
            {
                if (!File.Exists(myUser.UsersFilePath))
                {
                    XmlTextWriter textWritter = new XmlTextWriter(myUser.UsersFilePath, Encoding.UTF8);
                    textWritter.WriteStartDocument();
                    textWritter.WriteStartElement("Users");
                    textWritter.WriteEndElement();
                    textWritter.Close();
                }

                XmlDocument document = new XmlDocument();
                document.Load(myUser.UsersFilePath);

                XmlNode element = document.CreateElement("User");
                document.DocumentElement.AppendChild(element); // указываем родителя
                XmlAttribute attribute = document.CreateAttribute("Name"); // создаём атрибут
                attribute.Value = sUser; // устанавливаем значение атрибута

                element.Attributes.Append(attribute); // добавляем атрибут
                XmlNode subElement1 = document.CreateElement("Login"); // даём имя
                subElement1.InnerText = sLogin; // и значение
                element.AppendChild(subElement1); // и указываем кому принадлежит

                XmlNode subElement2 = document.CreateElement("Key");
                subElement2.InnerText = sKey.ToString();
                element.AppendChild(subElement2);

                XmlNode subElement3 = document.CreateElement("Role");
                subElement3.InnerText = sRole.ToString();
                element.AppendChild(subElement3);

                document.Save(myUser.UsersFilePath);
                return 0;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.HResult;
            }

        }
        public int Update()
        {
            try
            {
                if (!File.Exists(myUser.UsersFilePath))
                {
                    XmlTextWriter textWritter = new XmlTextWriter(myUser.UsersFilePath, Encoding.UTF8);
                    textWritter.WriteStartDocument();
                    textWritter.WriteStartElement("Users");
                    textWritter.WriteEndElement();
                    textWritter.Close();
                }

                XmlDocument document = new XmlDocument();
                document.Load(myUser.UsersFilePath);

                //проверяем, есть ли уже такой пользователь
                bool UserExist = false;
                XmlNodeList cl = document.DocumentElement.ChildNodes;
                foreach (XmlNode n in cl)
                {
                    if (string.Compare(n.Attributes["Name"].Value, _user, true) == 0)
                    {
                        UserExist = true;
                        n.ChildNodes[0].InnerText = _login;
                        n.ChildNodes[1].InnerText = _key.ToString();
                        n.ChildNodes[2].InnerText = _role.ToString();                       
                    }
                }
                document.Save(myUser.UsersFilePath);
                document = null;
                //пользователь не найден - добавляем информацию
                if (!UserExist)
                {
                    if (MessageBox.Show("Пользователь " + _user + " не найден. Вы хотите добавить нового пользователя?", "Пользователь",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        Save(_user, _login, _key.ToString(), _role.ToString());

                        //XmlNode element = document.CreateElement("User");
                        //document.DocumentElement.AppendChild(element); // указываем родителя
                        //XmlAttribute attribute = document.CreateAttribute("Name"); // создаём атрибут
                        //attribute.Value = _user; // устанавливаем значение атрибута

                        //element.Attributes.Append(attribute); // добавляем атрибут
                        //XmlNode subElement1 = document.CreateElement("Login"); // даём имя
                        //subElement1.InnerText = _login; // и значение
                        //element.AppendChild(subElement1); // и указываем кому принадлежит

                        //XmlNode subElement2 = document.CreateElement("Key");
                        //subElement2.InnerText = _key.ToString();
                        //element.AppendChild(subElement2);

                        //XmlNode subElement3 = document.CreateElement("Role");
                        //subElement3.InnerText = _role.ToString();
                        //element.AppendChild(subElement3);
                        //MessageBox.Show("Пользователь успешно добавлен", "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } 
                }
                //document.Save(myUser.UsersFilePath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.HResult;
            }
            
            return 0;
        }
        public int Check() 
        {
            try
            {
                //проеряем соответсвует ли ключ сохраненному
                DataSet UsersDataSet=new DataSet();
                UsersDataSet.ReadXml(myUser.UsersFilePath);
                DataTable dtUsers = UsersDataSet.Tables["User"];
                DataRow[] currentRows = dtUsers.Select(null, null, DataViewRowState.CurrentRows);
                foreach (DataRow row in currentRows)
                {
                    if (Convert.ToDouble(row["Key"].ToString()) == Key)
                    {
                        User = row["Name"].ToString();
                        Role = Convert.ToInt32(row["Role"].ToString());
                        return 0; 
                    }                        
                }
                MessageBox.Show("Неправильный логин или пароль", "Авторизация пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 1; 
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Авторизация пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.HResult;
            }
 
        }           
        public int Delete()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(UsersFilePath);

                //XmlNode node = null;
                XmlNodeList cl = document.DocumentElement.ChildNodes;

                foreach (XmlNode n in cl)
                {
                    if (string.Compare(n.Attributes["Name"].Value, _user, true)==0 )
                    {
                        {
                            document.DocumentElement.RemoveChild(n);
                            MessageBox.Show("Пользователь удален", "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }                                     
                }
                document.Save(UsersFilePath);
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return ex.HResult;
            }            
            return 0;
        }

        public static string GetUserInfo(string User, string InfoColumn)//Запрашиваем информацию о пользователе из файла
        {
            string InfoValue = "";
            try
            {
                DataSet UsersDataSet = new DataSet();
                UsersDataSet.ReadXml(myUser.UsersFilePath);
                DataTable dtUsers = UsersDataSet.Tables["User"];
                DataRow[] currentRows = dtUsers.Select(null, null, DataViewRowState.CurrentRows);
                foreach (DataRow row in currentRows)
                {
                    if (row["Name"].ToString() == User)
                    {
                        InfoValue = row[InfoColumn].ToString();
                    }
                }
                return InfoValue;
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return InfoValue;
            }

        }
 
    }
}
