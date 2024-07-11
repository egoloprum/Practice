using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.Data.ConnectionUI;
using System.Configuration;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using MBS.Properties;
using System.Xml;
using System.IO;

namespace MBS
{
    class SQLControls
    {
        // текущее подключение
        public static string CurrentConnectionString;
        public static string ConnectionString;
        public static SqlConnection CurrentConnection = new SqlConnection(CurrentConnectionString);

        //подключение к эталонной БД
        public static string ModelConnectionString = $"Data Source=(LocalDB)\\v11.0;AttachDbFilename={Application.StartupPath }\\Projects.mdf;Integrated " +
                                                       "Security=True;MultipleActiveResultSets=True";

        //public static string ModelConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Application.StartupPath.Replace("\\bin\\Debug","") + "\\Projects.mdf;Integrated Security=True;MultipleActiveResultSets=True";
        public static SqlConnection ModelConnection = new SqlConnection(ModelConnectionString);

        public static bool ObjExists(string ConnectionString, string strObjType, string strObjName)//проверка существования таблицы/запроса
        {
            string str = null;
            switch (strObjType)
            {
            case "Table":
                    str = $"SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_NAME='{strObjName}'";
                break;
            case "Query":             
                break;  
            default:      
                break;
            }
            try {
                SqlConnection myConn = new SqlConnection(ConnectionString);
                myConn.Open();
                SqlCommand myCommand = new SqlCommand(str, myConn);
                if (myCommand.ExecuteScalar().ToString() == strObjName) { return true; }
                else { return false; }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            finally
            {
            } 
        }

        public static int AddNewDB(string DB_Name, string ShortName, string FullName, string Username, string Password, string Source, short Mode) //создание новой БД
        {
            int ErrorCode = 0;
            //создаем БД и возвращаем строку подклчюения к ней
            ErrorCode = CreateDB(DB_Name, Username, Password, Source, Mode);
            if (ErrorCode != 0)// если БД не создана 
            {
                MessageBox.Show("Failed at CreateDB", "AddNewDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ErrorCode;
            }

            // добавляем в нее таблицы
            ErrorCode = AddTablesToNewDB(SQLControls.ConnectionString);
            if (ErrorCode != 0) //если таблицы не добавлены 
            {
                MessageBox.Show("Failed at AddTablesToNewDB", "AddNewDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ErrorCode;
            }

            // добавляем информацию о проекте в таблицу
            ErrorCode = AddInfoToNewProject(DB_Name, ShortName, FullName, SQLControls.ConnectionString);
            if (ErrorCode != 0) // информация не добавлена
            {
                MessageBox.Show("Failed at AddInfoToNewProject", "AddNewDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ErrorCode;
            }

            // копируем инфомарци. о проекте в эталонную таблицу (она жде перечень запомненных проектов)
            ErrorCode = AddInfoToModelProject(SQLControls.ConnectionString);
            if (ErrorCode != 0) // информация не добавлена
            {
                MessageBox.Show("Failed at AddInfoToModelProject", "AddNewDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ErrorCode;
            }

            MessageBox.Show("Проект успешно создан", "Создание нового проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ErrorCode = ConnectDB(SQLControls.ConnectionString);
            if (ErrorCode != 0) // информация добавлена успешно
            {
                MessageBox.Show("Failed at ConnectDB", "AddNewDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ErrorCode;
            }
            
            return ErrorCode;
        }

        /*      public static int  AddNewDB(string DB_Name, string ShortName, string FullName, string Username, string Password, string Source, short Mode) //создание новой БД
              {
                  int ErrorCode=0;
                  //создаем БД и возвращаем строку подклчюения к ней
                  ErrorCode = CreateDB(DB_Name, Username, Password, Source, Mode);
                  if (ErrorCode == 0)// если БД создана успешно 
                  {                            
                      //добавляем в нее таблицы
                      ErrorCode = AddTablesToNewBD(SQLControls.ConnectionString);
                      if (ErrorCode == 0) //если таблицы добавлены успешно
                      {
                          //добавляем информацию о проекте в таблицу
                          ErrorCode = AddInfoToNewProject(DB_Name, ShortName, FullName, SQLControls.ConnectionString);
                          if (ErrorCode == 0)//информация добавлена успешно
                          {
                              //копируем инфомарци. о проекте в эталонную таблицу (она жде перечень запомненных проектов)
                              ErrorCode = AddInfoToModelProject(SQLControls.ConnectionString);
                              if (ErrorCode == 0)//информация добавлена успешно
                              {
                                  MessageBox.Show("Проект успешно создан", "Создание нового проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                  ErrorCode = ConnectDB(SQLControls.ConnectionString);
                                  if (ErrorCode == 0)//информация добавлена успешно
                                  { 
                                  }
                              }

                          }

                      }
                  }
                  else { ErrorCode = 1; }
                  return ErrorCode;
              }*/

        public static int CreateDB(string DB_Name, string Username, string Password, string Source, short Mode)
        {
            string DefaultConnectionString = "Data Source=172.23.1.84\\WINCC;Initial Catalog=master;User ID=a;Password=11111111;MultipleActiveResultSets=True";
            string newProjectConnectionString;
            string sqlQuery;

            switch (Mode)
            {
                case 0:
                    // Local DB *.mdf
                    DefaultConnectionString     = $"Data Source=DESKTOP-NGC89DL{Source};Integrated Security=True;MultipleActiveResultSets=True";
                    // newProjectConnectionString  = $@"Data Source=DESKTOP-NGC89DL{Source};AttachDbFilename={Source}\{DB_Name}.mdf;Integrated Security=True";
                    newProjectConnectionString  = $@"Data Source=DESKTOP-NGC89DL{Source};Integrated Security=True;MultipleActiveResultSets=True";
                    /*sqlQuery =  $"CREATE DATABASE {DB_Name} ON PRIMARY " +
                                $"(NAME = {DB_Name}_Data, " +
                                $@"FILENAME = '{Source}\{DB_Name}.mdf', " +
                                $"SIZE = 4MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                                $"LOG ON (NAME = {DB_Name}_Log, " +
                                $@"FILENAME = '{Source}\{DB_Name}_log.ldf', " +
                                $"SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";*/

                    string sourcePath = Application.StartupPath;

                    if (!sourcePath.EndsWith("\\"))
                    {
                        sourcePath += "\\";
                    }

                    sqlQuery = $@"CREATE DATABASE [{DB_Name}]";

/*                    sqlQuery = $@"CREATE DATABASE [{DB_Name}]
                                        ON PRIMARY (
                                            NAME={DB_Name}_Data,
                                            FILENAME='{sourcePath}{Source}\{DB_Name}_Data.mdf'
                                        )
                                        LOG ON (
                                            NAME={DB_Name}_Log,
                                            FILENAME='{sourcePath}{Source}\{DB_Name}_Log.mdf',
                                            SIZE=1MB, MAXSIZE=5MB, FILEGROWTH=10%
                                        )
                    ";*/

                    break;

                case 1:
                    // SQLServer DB
                    newProjectConnectionString = $@"Data Source={Source};Initial Catalog={DB_Name};
                                                    User ID={Username};Password={Password};Persist Security Info=True;
                                                    MultipleActiveResultSets=True"; 
                        
                    sqlQuery = $"CREATE DATABASE {DB_Name}";
                    break;

                default:
                    // SQLServer DB
                    newProjectConnectionString = $@"Data Source={Source};Initial Catalog={DB_Name};
                                                    User ID={Username};Password={Password};Persist Security Info=True;
                                                    MultipleActiveResultSets=True";

                    sqlQuery = $"CREATE DATABASE {DB_Name}";
                    break;
            }

            using (SqlConnection connection = new SqlConnection(DefaultConnectionString))
            {
                try
                {
                    connection.Open();

                    // Create the database
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Set Cyrillic collation
                    using (SqlCommand command = new SqlCommand($"ALTER DATABASE [{DB_Name}] COLLATE Cyrillic_General_CI_AS", connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Database is created successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    General.ErrorMessage(ex);
                    return ex.HResult;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            SQLControls.ConnectionString = newProjectConnectionString;
            return 0;
        }

      /*     public static int CreateDB(string ID, string Password, string Path, short Mode) //создание новой БД
           {
              string myConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=sa123456";
              string NewProjectConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=sa123456";
              string str = "";
              if (String.IsNullOrWhiteSpace(Path))
              {
                 if (Mode == 0) { Path = ".\\SQLEXPRESS"; }
                 else { Path = Application.StartupPath; }
              };
              switch (Mode)
              {
                 case 0:
                    //БД SQLServer
                    myConnectionString = "Data Source=" + Path + ";Initial Catalog=master;User ID=sa;Password=sa123456";
                    NewProjectConnectionString = "Data Source=" + Path + ";Initial Catalog=" + ID + ";User ID=sa;Password=sa123456; Persist Security Info=True";
                    str = "CREATE DATABASE " + ID;
                    break;
                 case 1:
                    //локальная БД *.mdf
                    myConnectionString = "Data Source=(LocalDB)\\v11.0; Integrated Security=True;";
                    NewProjectConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Path + ID + ".mdf;Integrated Security=True";
                    str = "CREATE DATABASE " + ID + " ON PRIMARY " +
                                "(NAME = " + ID + "_Data, " +
                                "FILENAME = '" + Path + ID + ".mdf', " +
                                "SIZE = 4MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                                "LOG ON (NAME = " + ID + "_Log, " +
                                "FILENAME = '" + Path + ID + "_log.ldf', " +
                                "SIZE = 1MB, " +
                                "MAXSIZE = 5MB, " +
                                "FILEGROWTH = 10%)";
                    break;
                 default:
                    //БД SQLServer
                    myConnectionString = "Data Source=" + Path + ";Initial Catalog=master;User ID=sa;Password=sa123456";
                    NewProjectConnectionString = "Data Source=" + Path + ";Initial Catalog=" + ID + ";User ID=sa;Password=sa123456;Persist Security Info=True";
                    str = "CREATE DATABASE " + ID;
                    break;
              }

              SqlConnection myConn = new SqlConnection(myConnectionString);
              SqlCommand myCommand = new SqlCommand(str, myConn);
              try
              {
                    myConn.Open();
                    //Создаем новую БД запросом
                    myCommand.ExecuteNonQuery();
                    //Указываем для нее русскую кодировку (чтобы была поддержка русских букв)
                    str = "ALTER DATABASE [" + ID + "] COLLATE Cyrillic_General_CI_AS";
                    myCommand = new SqlCommand(str, myConn);
                    myCommand.ExecuteNonQuery();       
                    MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
              catch (System.Exception ex)//catch (SqlException ex )          
              {
                    General.ErrorMessage(ex);                
                    return ex.HResult;
              }
              finally
              {
                    if (myConn.State == ConnectionState.Open)
                    {
                       myConn.Close();
                    }
              }

              SQLControls.ConnectionString = NewProjectConnectionString;
              return 0;
           }*/

        public static int CyrillicDB() // Изменение кодировки таблиц (скрипт не отлажен)
            { //http://www.sql.ru/forum/147286/izmenit-collation-u-sushhestvuushhey-bd
                // пока все зафиксируем
                string DB = "E:\\VSPROJECTS\\ASUPR\\WFA_СS\\WFA_СS\\PROJECTS.MDF";
                string MasterConnectionString = "Data Source=(LocalDB)\\v11.0; Integrated Security=True;";
                string DBConnectionString = $"Data Source=(LocalDB)\\v11.0;AttachDbFilename={ DB }.mdf;Integrated Security=True"; ;
                SqlConnection MyConnection = new SqlConnection(MasterConnectionString);
                try
                {                  
                    // Сначала меняем collation у самой базы
                    MyConnection.Open();
                    string str = $"ALTER DATABASE [{ DB }] COLLATE Cyrillic_General_CI_AS";
                    SqlCommand myCommand = new SqlCommand(str, MyConnection);
                    myCommand.ExecuteNonQuery();
                    MyConnection.Close();
                    // подклюбчаемся к базе
                    MyConnection.ConnectionString = DBConnectionString;
                    MyConnection.Open();
                                  
                    string[] arrstr = new string[5];
                    // строим в EM скрипт создания индексов и сохраняем его на долгую память до п.6 ???
                    arrstr[0] = @"";
                    // убиваем PK и FK скриптом полученным после   
                    arrstr[1] = @"select 'ALTER TABLE ' + TABLE_NAME + ' DROP CONSTRAINT ' + CONSTRAINT_NAME 
                                from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
                                where constraint_type='PRIMARY KEY' or constraint_type='FOREIGN KEY'
                                ORDER BY constraint_type ";
                    // убиваем остатки индексов
                    arrstr[2] = @"SELECT 'drop index ' + o.name + '.' + i.name AS Индекс
                                FROM sysobjects o INNER JOIN sysindexes i ON o.id = i.id
                                WHERE (o.xtype = 'U') AND 
	                                (i.indid > 0) AND 
	                                (i.indid < 255) AND 
	                                (INDEXPROPERTY(i.id, i.name, 'isStatistics') = 0)
                                and o.name <> 'dtproperties'
                                ORDER BY o.name, i.indid";
                    // Меняем collation
                    arrstr[3] = @"SELECT 'ALTER TABLE ['+ 
		                        rtrim(TABLE_NAME)+
		                        '] ALTER COLUMN ['+
		                        rtrim(COLUMN_NAME)+
		                        '] '+
		                        rtrim(DATA_TYPE)+
	                        CASE WHEN NOT(CHARACTER_MAXIMUM_LENGTH IS NULL) OR (CHARACTER_MAXIMUM_LENGTH=0)
		                        THEN '('+convert(varchar(10),CHARACTER_MAXIMUM_LENGTH)+')'
	                        END+
	                        ' COLLATE Latin1_General_CI_AS' COLLATE Latin1_General_CI_AS 
	                        FROM INFORMATION_SCHEMA.COLUMNS 
	                        WHERE	(TABLE_CATALOG=DB_NAME() COLLATE Latin1_General_CI_AS) AND 
		                        ((DATA_TYPE LIKE '%char%' COLLATE Latin1_General_CI_AS) OR (DATA_TYPE LIKE '%text%' COLLATE Latin1_General_CI_AS)) AND
		                        (COLLATION_NAME IS NOT NULL) AND
		                        (COLLATION_NAME <> 'Latin1_General_CI_AS' COLLATE Latin1_General_CI_AS) AND 
		                        TABLE_NAME in (SELECT o.name 
					                        FROM sysobjects o 
					                        WHERE (o.xtype = 'U'))";
                    // пересоздаем индексы скриптом из п.1
                    arrstr[4] = @"";
                    for (int i = 0; i < 4; i++) {
                        myCommand = new SqlCommand(str, MyConnection);
                        SqlDataReader SqlReader = myCommand.ExecuteReader();
                        while (SqlReader.Read())
                        {
                            if (!SqlReader.IsDBNull(0))
                            {
                                // запрашиваем текст скрипта создания таблицы по образцу
                                string SQLCommandText = SqlReader.GetString(0);
                                // передаем текст в команду и выполняем ее
                                SqlCommand mySQLCommand = new SqlCommand(SQLCommandText, MyConnection);
                                mySQLCommand.ExecuteNonQuery();

                            }
                        }
                        SqlReader.Close();
                    }                
                    MyConnection.Close();
                    MessageBox.Show("DataBase isCyrillic", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception ex)
                {
                    General.ErrorMessage(ex);
                    return ex.HResult;
                }
                finally
                {
                }
                return 0;
            }

        public static int DeleteDateBase(string ConnectionString) // создание новой БД
        {                      
            //CloseDB();            
            SqlConnection myConn = new SqlConnection(ConnectionString);
            myConn.Open();
            string sDataBase = myConn.Database;
            myConn.Close();
            string sDataSource = myConn.DataSource;
            string ControlConnectionString = ModelConnectionString;
            string str;
            SqlCommand myCommand;

            if (sDataSource != "(LocalDB)\\v11.0")
            {
                ControlConnectionString = "Data Source=" + sDataSource + ";Initial Catalog=master;User ID=a;Password=11111111";

            }
            try
            {
                // закрываем текущее подключение, если удаляем его
                if (sDataSource == CurrentConnection.DataSource && sDataBase == CurrentConnection.Database)
                {
                    CloseDB();

                }   
                myConn = new SqlConnection(ControlConnectionString);
                myConn.Open();
                  
                //if (sDataSource != "(LocalDB)\\v11.0")
                //{
                    str = $@"ALTER DATABASE [{sDataBase}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    myCommand = new SqlCommand(str, myConn);
                    myCommand.ExecuteNonQuery();
                //}
                str = $@"DROP DATABASE [{sDataBase}'";
                myCommand = new SqlCommand(str, myConn);
                myCommand.ExecuteNonQuery();
                myConn.Close();
                MessageBox.Show("БД проекта успешно удалена", "Удаление проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)//catch (SqlException ex )          
            {
                myConn.Close();
                General.ErrorMessage(ex);
                return ex.HResult;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return 0;
        }

        public static int AddTablesToNewDB(string NewProjectConnectionString) // добавление таблиц в БД
        {
            SqlConnection NewProjectConnection = new SqlConnection(NewProjectConnectionString); // подключение к создаваемой БД

            // SqlConnection ModelConnection = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=" 
            //                                                    + Application.StartupPath 
            //                                                    + "\\Projects.mdf;Integrated Security=True"); // подключение к эталонной БД

            try
            {
                // открываем подключения
                NewProjectConnection.Open();
                // ModelConnection.Open();

                // запрашиваем названия таблиц из эталонной БД

                SqlCommand ReadTablesCommand = new SqlCommand("SELECT TABLE_NAME FROM information_schema.TABLES", NewProjectConnection);
                // SqlCommand ReadTablesCommand = new SqlCommand("SELECT * FROM sysobjects WHERE xtype = 'U';", NewProjectConnection);
                SqlDataReader SqlReader = ReadTablesCommand.ExecuteReader();
                ProgressControl.Progress = 0;
                ProgressControl.Operation = "Добавление таблиц в проект";

                while (SqlReader.Read())
                {
                    // get rows
                    ProgressControl.Count++;
                }

                List<string> readerStrings = new List<string>();

                SqlReader.Close();
                SqlReader = ReadTablesCommand.ExecuteReader();

                while (SqlReader.Read())
                {
                    if (!SqlReader.IsDBNull(0))
                    {
                        // запрашиваем текст скрипта создания таблицы по образцу
                        readerStrings.Add(SqlReader.GetString(0));

                        //string SQLCommandText = SQLScript_CreateTable(SqlReader.GetString(0));
                        // передаем текст в команду и выполняем ее
                        //SqlCommand mySQLCommand = new SqlCommand(SQLCommandText, NewProjectConnection);
                        //mySQLCommand.ExecuteNonQuery();
                      
                        // fMain.ProgressBar("Добавление таблиц в проект", count, i);
                    }
                }
                // закрываем все после использования
                ProgressControl.Clear();
                SqlReader.Close();

                foreach (string str in readerStrings)
                {
                    string SQLCommandText = SQLScript_CreateTable(str, NewProjectConnection);
                    Console.WriteLine($"Those strs: {SQLCommandText}");
                    SqlCommand mySQLCommand = new SqlCommand(SQLCommandText, NewProjectConnection);
                    mySQLCommand.ExecuteNonQuery();
                }


                // ModelConnection.Close();
                NewProjectConnection.Close();
                MessageBox.Show("Successfully finished the function", "AddTablesToNewDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex);     
                return ex.HResult;
            }
            finally
            {
                /*if (ModelConnection.State == ConnectionState.Open)
                {
                    ModelConnection.Close();
                }*/
                if (NewProjectConnection.State == ConnectionState.Open)
                {
                    NewProjectConnection.Close();
                }
            }
        } 

        public static string SQLScript_CreateTable(string TableName, SqlConnection connectionString) // создание скриптов для добавления таблиц в БД на основе эталанной БД Projects (сделано для облегчения разработки)
        {
            string SQLScript= $"CREATE TABLE [{ TableName }]";
            string str = $@"SELECT COLUMN_NAME, DATA_TYPE,
                        iif(CHARACTER_MAXIMUM_LENGTH<>0,CHARACTER_MAXIMUM_LENGTH,0) AS [LENGTH],
                        iif(IS_NULLABLE='NO','NOT NULL', 'NULL') AS NULLABLE, 
                        iif(COLUMN_NAME=(SELECT COLUMN_NAME  FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='{ TableName }'),' PRIMARY KEY','') AS [PRIMARY_KEY],
                        iif  (COLUMN_DEFAULT<>NULL,' DEFAULT ' + COLUMN_DEFAULT,'') AS [DEFAULT] 
                        FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE table_name = '{ TableName }'";

            try
            {
                SqlCommand myCommand = new SqlCommand(str, connectionString);
                SqlDataReader sqlreader = myCommand.ExecuteReader();
                while (sqlreader.Read())
                {
                    if (!sqlreader.IsDBNull(0))
                    {
                        string COLUMN_NAME = $"[{sqlreader.GetString(0)}] ";
                        string DATA_TYPE=sqlreader.GetString(1);
                        string CHARACTER_MAXIMUM_LENGTH = " ";

                        if (sqlreader.GetInt32(2) != 0 & !(DATA_TYPE == "TEXT" || DATA_TYPE == "text"))
                        {
                            CHARACTER_MAXIMUM_LENGTH = $"({sqlreader.GetInt32(2).ToString()}) ";
                        }
                        string NULLABLE = sqlreader.GetString(3);
                        string PRIMARY_KEY=sqlreader.GetString(4);
                        string DEFAULT = sqlreader.GetString(5);

                        if (SQLScript == $"CREATE TABLE [{TableName}] (\n")
                        {
                            SQLScript = SQLScript +  COLUMN_NAME  + DATA_TYPE +  CHARACTER_MAXIMUM_LENGTH +  NULLABLE + PRIMARY_KEY + DEFAULT;
                        }
                        else
                        {
                            SQLScript = SQLScript + ",\n" +  COLUMN_NAME  + DATA_TYPE +  CHARACTER_MAXIMUM_LENGTH + NULLABLE + PRIMARY_KEY + DEFAULT;
                        }
                        SQLScript += "\n)";
                    }
                }
               
                // MessageBox.Show(SQLScript, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sqlreader.Close();
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);    
            }
            finally
            {
            } 
            return SQLScript;
        } 

        public static int GetConnectionString(string sPropertyConnStr) // получение строки подключения  с помощью диалога от VS
        {
            try
            {
                DataConnectionDialog dcd = new DataConnectionDialog();
                DataSource.AddStandardDataSources(dcd);
                //dcd.DataSources.Add(DataSource.SqlDataSource);
                //dcd.DataSources.Add(DataSource.SqlFileDataSource);
                if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
                {
                    // проверка добавленного подключения
                    bool bCheckDB = CheckDB(dcd.ConnectionString);
                    if (bCheckDB)
                    {
                        // сохраняем
                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                        connectionStringsSection.ConnectionStrings["MBS.Properties.Settings." + sPropertyConnStr].ConnectionString = dcd.ConnectionString;
                        config.Save();
                        ConfigurationManager.RefreshSection("connectionStrings");
                        DialogResult res = MessageBox.Show("Подключение добавлено", "БД доступна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return 0;
                    }
                    else
                    {
                        // выводим окно подключения
                        DialogResult res = MessageBox.Show("Выбранная БД недоступна. Все равно сохранить подключение?", "БД недоступна", 
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (res == DialogResult.Yes)
                        {
                            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                            connectionStringsSection.ConnectionStrings["MBS.Properties.Settings." + sPropertyConnStr].ConnectionString = dcd.ConnectionString;
                            config.Save();
                            ConfigurationManager.RefreshSection("connectionStrings");
                            Settings.Default.Reload();
                        }
                        return 1;
                    }

                }
                else return 1;
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex);
                return ex.HResult;
            }
            finally
            {
            }
        } 

        public static string myConnectionString(string ID, string Password, string Path, short Mode) // формирование строки подключения (мусор?)
        {
            string ConnectionString = $"Data Source=.\\SQLEXPRESS;Initial Catalog={ID};User ID=sa;Password=sa123456"; // по умолчанию локальная БД

            switch (Mode)
            {
                case 0:
                    // БД SQLServer
                    ConnectionString = $"Data Source={Path};Initial Catalog={ID};User ID=sa;Password=sa123456";
                    break;
                case 1:
                    // локальная БД *.mdf
                    ConnectionString = "Data Source=(LocalDB)\\v11.0; AttachDbFilename{Path}\\{ID}.mdf;Integrated Security=True;";
                    break;
                case 2:
                    // БД MS Access *.accdb
                    ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path}\\{ID}.accdb ";
                    break;
                case 3:
                    ;
                    break;
                case 4:
                    ;
                    break;
                case 5:
                    ;
                    break;
            }


            return ConnectionString;
        } 

        public static int ConnectDB(string ConnectionString) // подключение к БД
        {
            try
            {
                if (SQLControls.CurrentConnection.State != ConnectionState.Closed)
                {
                    CloseDB();
                }
                SQLControls.CurrentConnectionString = ConnectionString;
                SQLControls.CurrentConnection.ConnectionString = SQLControls.CurrentConnectionString;
                SQLControls.CurrentConnection.Open();
                return 0;
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return ex.HResult;
            }
         
        }

        public static int CloseDB() // отключение от БД
        {
            try
            {
                SQLControls.CurrentConnection.Close();
                SQLControls.CurrentConnection.ConnectionString = "";
                SQLControls.CurrentConnectionString = "";              
                return 0;
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return ex.HResult;
            }

        }

        public static int AddInfoToNewProject(string ID, string ShortName, string FullName, string ConnectionString) // добавление информации о проекте в эталанноу БД Projects
        {
            string str = $"INSERT INTO [ProjectInfo] ([Id], [ShortName], [FullName], [Path]) VALUES (N'{ID}', N'{ShortName}', N'{FullName}', N'{ConnectionString}')";
            try
            {
                // Информация в таблице проекта
                SqlConnection myConnecton = new SqlConnection(ConnectionString);
                myConnecton.Open();
                SqlCommand myCommand = new SqlCommand(str, myConnecton);
                myCommand.ExecuteNonQuery();
                myConnecton.Close(); 
            }
            catch (Exception ex)
            {
                General.ErrorMessage(ex);    
                return ex.HResult;
            }
            return 0;
        }

        public static int AddInfoToModelProject(string ConnectionString) // добавление информации о проекте в эталанноу БД Projects
        {
            const int i_max = 4;
            string[] ColumnName = new string[i_max]{
            "ID",
            "ShortName",
            "FullName",
            "Path"
            };
            string[] ColumnValue = new string[i_max];
            string ConnectionStringColumnName = "Path",
                TableName   = "ProjectInfo",
                str_Insert  = "",
                str_Insert1 = $"INSERT INTO [{ TableName }] (",
                str_Insert2 = ") VALUES (",
                str_Update  = $"UPDATE [{ TableName }] SET  ";
            SqlConnection SourceConnecton   = new SqlConnection(ConnectionString);
            SqlConnection DestConnecton     = new SqlConnection(ModelConnectionString);
            try
            {
                // Запрашиваем информацию о проекте из БД проекта
                SourceConnecton.Open();
                DestConnecton.Open();
                try
                {
                SqlCommand ReadDataCommand = new SqlCommand("select * from [ProjectInfo]", SourceConnecton);
                SqlDataReader SqlReader = ReadDataCommand.ExecuteReader();
                while (SqlReader.Read())
                {
                    if (!SqlReader.IsDBNull(0))
                    {
                        // формируем тексты запросов на добалвение/обновление данных
                        for (int i = 0; i < i_max; i++)
                        {
                          
                            ColumnValue[i] = (string)SqlReader[ColumnName[i]];
                            ColumnValue[i] = General.Convertall(ColumnValue[i], Encoding.GetEncoding(1251), Encoding.Default);
                            if (i > 0)
                            {
                                str_Insert1 = str_Insert1 + ", ";
                                str_Insert2 = str_Insert2 + ", ";
                                str_Update  = str_Update + ", ";

                            }
                            str_Insert1 = str_Insert1 + $"[{ ColumnName[i] }]";
                            str_Insert2 = str_Insert2 + $"N'{ ColumnValue[i] }'";

                            str_Update = str_Update + $"[{ ColumnName[i] }] = N'{ ColumnValue[i] }'";
                        }
                        str_Insert = str_Insert1 + str_Insert2 + ")";
                        //Запрашиваем значение строки подключения
                        // ConnectionString = (string)SqlReader[ConnectionStringColumnName];
                    }
                }
                SqlReader.Close();
                SourceConnecton.Close();

                }
                catch
                {
                    str_Insert = $"INSERT INTO [{ TableName }] (ID, ShortName, FullName,Path) VALUES " +
                                 $"('{ SourceConnecton.Database }', '', '','{ SourceConnecton.ConnectionString }')";
                    str_Update = $"UPDATE [{TableName }] SET  [ID]= N'{ SourceConnecton.Database }', [ShortName]= N'', " +
                                 $"[FullName]= N'', [Path] = N'{ SourceConnecton.ConnectionString }'" ;
                }

                // Проверяем, есть ли такая запись в эталонной таблице
                SqlCommand DataCommand = new SqlCommand($"select count(*) from [ProjectInfo] where [{ ConnectionStringColumnName }] like '{ ConnectionString }'", DestConnecton);
                if (DataCommand.ExecuteScalar().ToString() != "0")
                {
                    // Обновляем запись
                    DataCommand = new SqlCommand(str_Update, DestConnecton);
                }
                else
                {
                    // Добавляем запись
                    DataCommand = new SqlCommand(str_Insert, DestConnecton);
                }
                DataCommand.ExecuteNonQuery();
                DestConnecton.Close();
                return 0;
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return ex.HResult;
            }

        }
        public static string GetProjectInfo(string ConnectionString, string InfoColumn) // Запрашиваем информацию о проекте из БД проекта
        {
            string InfoValue = "";
            SqlConnection SourceConnecton = new SqlConnection(ConnectionString);
            try
            {              
            SourceConnecton.Open();
            SqlCommand ReadDataCommand = new SqlCommand($"select [{ InfoColumn }] from [ProjectInfo]", SourceConnecton);
            SqlDataReader SqlReader = ReadDataCommand.ExecuteReader();
            while (SqlReader.Read())
            {
                if (!SqlReader.IsDBNull(0))
                {
                    InfoValue = (string)SqlReader[InfoColumn];
                    InfoValue = General.Convertall(InfoValue, Encoding.GetEncoding(1251), Encoding.Default);
                }
            }
            SqlReader.Close();
            SourceConnecton.Close();
            return InfoValue;
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return InfoValue;
            }
        }

        public static bool CheckDB(string connectString)
        {
            SqlConnection CurrentConnection = new SqlConnection(connectString);

            try
            {
                CurrentConnection.Open();
                CurrentConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckPropertyConnStr(string sPropertyConnStr)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            string connectString = connectionStringsSection.ConnectionStrings["MBS.Properties.Settings." + sPropertyConnStr + "ConnectionString"].ConnectionString; //.ReportConnectionString;

            try
            {
                // проверка добавленного подключения
                bool bCheckDB = CheckDB(connectString);
                if (bCheckDB)
                {
                    return true;
                }
                else
                {
                    // выводим окно подключения
                    DialogResult res = MessageBox.Show($"БД { sPropertyConnStr} недоступна. Указать новое подключение?", "БД недоступна", 
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        int ErrCode = SQLControls.GetConnectionString(sPropertyConnStr + "ConnectionString");
                        if (ErrCode == 0)
                        {
                            Settings.Default.Reload();
                            return true;
                        }
                        else return false;
                    }
                    else
                    {
                        MessageBox.Show($"БД { sPropertyConnStr } отключена. Для воостановления доступа настройте подключение", "БД недоступна", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            catch
            {

                return false;
            }
        }

        public static string GetRequest(string sRequestName)
        {
            XmlNode RequestNode = null;
            XmlDocument SQLRequestXML = new XmlDocument();
            SQLRequestXML.Load("SettingsXML/SQLRequest.xml");
            string sRequest = "";
            try
            {
                RequestNode = SQLRequestXML.DocumentElement.SelectSingleNode($"//Request[@ID='{ sRequestName }']");
                if (RequestNode != null)
                {
                    //if (RequestNode.ChildNodes[0].InnerText != null)                      
                    //    sRequest = RequestNode.ChildNodes[0].InnerText.ToString().Replace("\r\n", "").Replace("\t", "");
                    if (RequestNode.Attributes["RequestString"].Value != null)
                        sRequest = RequestNode.Attributes["RequestString"].Value.ToString().Replace("\r\n", "").Replace("\t", "");
                }
                return sRequest;
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
    }


}