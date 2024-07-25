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
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MBS
{
    class SQLControls
    {
        // текущее подключение
        public static string CurrentConnectionString;
        public static string ConnectionString;
        public static SqlConnection CurrentConnection = new SqlConnection(CurrentConnectionString);

        //подключение к эталонной БД
        public static string ModelConnectionString = $"Data Source=(LocalDB)\\v11.0;AttachDbFilename={Application.StartupPath}\\Projects.mdf;Integrated " +
                                                       "Security=True;MultipleActiveResultSets=True";

        public static SqlConnection ModelConnection = new SqlConnection(ModelConnectionString);

        public static bool ObjExists(string ConnectionString, string strObjType, string strObjName) // проверка существования таблицы/запроса
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

        public static int AddNewDB(string DB_Name, string ShortName, string FullName, string Username, string Password, string Source, short Mode, string typeOfDB) // создание новой БД
        {
            int ErrorCode = 0;
            // создаем БД и возвращаем строку подклчюения к ней
            ErrorCode = CreateDB(DB_Name, Username, Password, Source, Mode);
            if (ErrorCode != 0) // если БД не создана 
            {
                MessageBox.Show("Failed at CreateDB", "AddNewDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ErrorCode;
            }

            // добавляем в нее таблицы
            ErrorCode = AddTablesToNewDB(typeOfDB, SQLControls.ConnectionString);
            if (ErrorCode != 0) // если таблицы не добавлены 
            {
                MessageBox.Show("Failed at AddTablesToNewDB", "AddNewDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ErrorCode;
            }

            // добавляем информацию о проекте в таблицу
/*            ErrorCode = AddInfoToNewProject(DB_Name, ShortName, FullName, SQLControls.ConnectionString);
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
            }*/

            return ErrorCode;
        }

        public static int CreateDB(string DB_Name, string Username, string Password, string Source, short Mode)
        {
            string DefaultConnectionString = "Data Source=172.23.1.84\\WINCC;Initial Catalog=master;User ID=a;Password=11111111";
            string newProjectConnectionString = "";
            string sqlQuery;

            switch (Mode)
            {
                case 0:
                    // Window DB
                    DefaultConnectionString     = $"Data Source={Environment.MachineName}{Source};Integrated Security=True;";
                    newProjectConnectionString  = $@"Data Source={Environment.MachineName}{Source};Initial Catalog={DB_Name};Integrated Security=True;";

                    string sourcePath = Application.StartupPath;

                    if (!sourcePath.EndsWith("\\"))
                    {
                        sourcePath += "\\";
                    }

                    sqlQuery = $@"CREATE DATABASE [{DB_Name}]";

                    break;

                case 1:
                    // SQLServer DB
                    newProjectConnectionString = $@"Data Source={Source};Initial Catalog={DB_Name};
                                                    User ID={Username};Password={Password};Persist Security Info=True;"; 
                        
                    sqlQuery = $"CREATE DATABASE {DB_Name}";
                    break;

                default:
                    // SQLServer DB
                    newProjectConnectionString = $@"Data Source={Source};Initial Catalog={DB_Name};
                                                    User ID={Username};Password={Password};Persist Security Info=True;";

                    sqlQuery = $"CREATE DATABASE {DB_Name}";
                    break;
            }

            using (SqlConnection connection = new SqlConnection(DefaultConnectionString))
            {
                try
                {
                    connection.Open();

                    string queryKill = "DECLARE @session_id INT; " +
                                       "SELECT @session_id = request_session_id " +
                                       "FROM sys.dm_tran_locks " +
                                       "WHERE resource_database_id = DB_ID('model'); " +
                                       "IF @session_id IS NOT NULL " +
                                       "BEGIN " +
                                           "DECLARE @sql NVARCHAR(100); " +
                                           "SET @sql = 'KILL ' + CAST(@session_id AS NVARCHAR(10)); " +
                                           "EXEC sp_executesql @sql; " +
                                       "END";

                    // deletes the lock
                    using (SqlCommand command = new SqlCommand(queryKill, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Create the database
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Create GetCurrentDatabaseSize stored procedure
                    Create_GetCurrentDBsize_func(connection);

                    // Set Cyrillic collation
                    using (SqlCommand command = new SqlCommand($"ALTER DATABASE [{DB_Name}] COLLATE Cyrillic_General_CI_AS", connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("База данных успешно создана", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static void Create_GetCurrentDBsize_func(SqlConnection connection)
        {
            string sqlQuery = "CREATE OR ALTER PROCEDURE GetCurrentDatabaseSize " +
                               "AS " +
                               "BEGIN " +
                                   "SET NOCOUNT ON " +
                                   "DECLARE @DatabaseSizeInBytes BIGINT; " +
                                   "SELECT @DatabaseSizeInBytes = SUM(size) * 8 * 1024 " +
                                   "FROM sys.master_files " +
                                   "WHERE type = 0 AND database_id = DB_ID(DB_NAME()); " +
                                   "SELECT @DatabaseSizeInBytes AS DatabaseSizeInBytes " +
                               "END";

            try
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
               
                General.ErrorMessage(ex);
                Console.WriteLine("Error on CreateGetCurrentDB");
            }
        }

        public static void Create_CleanTables_Report_func(SqlConnection connection)
        {
            string sqlQuery = "CREATE OR ALTER PROCEDURE dbo.CleanTables " +
                              "@CutoffDate char(20) " +
                              "AS " +
                              "BEGIN " +
                                   "DECLARE @tableName NVARCHAR(256) " +
                                   "DECLARE @sql NVARCHAR(MAX) " +
                                   "DECLARE @currentDate DATE = GETDATE() " +
                                   "DECLARE @oneYearAgo DATE = DATEADD(YEAR, -1, @currentDate) " +
                                   "SET @CutoffDate = CONVERT(datetime, @CutoffDate) " +

                                   "IF @CutoffDate > @oneYearAgo " +
                                   "BEGIN " +
                                       "RAISERROR('Cannot delete data within the last year.', 16, 1) " +
                                       "RETURN " +
                                   "END " +

                                   "DECLARE tableCursor CURSOR FOR " +
                                   "SELECT '[' + SCHEMA_NAME(schema_id) + '].[' + name + ']' AS TableName " +
                                   "FROM sys.tables " +
                                   "WHERE name NOT LIKE '%Label' " +

                                   "OPEN tableCursor " +
                                   "FETCH NEXT FROM tableCursor INTO @tableName " +

                                   "WHILE @@FETCH_STATUS = 0 " +
                                   "BEGIN " +
                                       "IF EXISTS ( " +
                                           "SELECT 1 " +
                                           "FROM sys.columns " +
                                           "WHERE [object_id] = OBJECT_ID(@tableName) AND [name] = 'DAT_Start_Dosing' " +
                                       ") " +
                                       "BEGIN " +
                                           "SET @sql = 'DELETE FROM ' + @tableName + ' WHERE DAT_Start_Dosing < @CutoffDate' " +
                                           "EXEC sp_executesql @sql, N'@CutoffDate DATE', @CutoffDate " +
                                           "PRINT 'Successfully deleted DAT_Start_Dosing from TBatchs' " +
                                       "END " +

                                       "IF EXISTS ( " +
                                           "SELECT 1 " +
                                           "FROM sys.columns " +
                                           "WHERE [object_id] = OBJECT_ID(@tableName) AND [name] = 'DAT_Start' " +
                                       ") " +
                                       "BEGIN " +
                                           "SET @sql = 'DELETE FROM ' + @tableName + ' WHERE DAT_Start < @CutoffDate' " +
                                           "EXEC sp_executesql @sql, N'@CutoffDate DATE', @CutoffDate " +
                                           "PRINT 'Successfully deleted DAT_Start from TDosing' " +
                                       "END " +

                                       "FETCH NEXT FROM tableCursor INTO @tableName " +
                                   "END " +
                                   "CLOSE tableCursor " +
                                   "DEALLOCATE tableCursor " +

                                   "DBCC SHRINKDATABASE (0) " +

                              "END";

            try
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex);
                Console.WriteLine("Error on Create_CleanTables_Report_func");
            }
        }

        public static void Create_CleanTables_Alarm_func(SqlConnection connection)
        {
            string sqlQuery = "CREATE OR ALTER PROCEDURE dbo.CleanTables_Alarm " +
                              "@CutoffDate char(20) " +
                              "AS " +
                              "BEGIN " +
                                   "DECLARE @tableName NVARCHAR(256) " +
                                   "DECLARE @sql NVARCHAR(MAX) " +
                                   "DECLARE @currentDate DATE = GETDATE() " +
                                   "DECLARE @oneYearAgo DATE = DATEADD(YEAR, -1, @currentDate) " +
                                   "SET @CutoffDate = CONVERT(datetime, @CutoffDate) " +

                                   "IF @CutoffDate > @oneYearAgo " +
                                   "BEGIN " +
                                       "RAISERROR('Cannot delete data within the last year.', 16, 1) " +
                                       "RETURN " +
                                   "END " +

                                   "DECLARE tableCursor CURSOR FOR " +
                                   "SELECT '[' + SCHEMA_NAME(schema_id) + '].[' + name + ']' AS TableName " +
                                   "FROM sys.tables " +
                                   "WHERE name NOT LIKE '%Label' " +

                                   "OPEN tableCursor " +
                                   "FETCH NEXT FROM tableCursor INTO @tableName " +

                                   "WHILE @@FETCH_STATUS = 0 " +
                                   "BEGIN " +
                                       "IF EXISTS ( " +
                                           "SELECT 1 " +
                                           "FROM sys.columns " +
                                           "WHERE [object_id] = OBJECT_ID(@tableName) AND [name] = 'plctime' " +
                                       ") " +
                                       "BEGIN " +
                                           "SET @sql = 'DELETE FROM ' + @tableName + ' WHERE plctime < @CutoffDate' " +
                                           "EXEC sp_executesql @sql, N'@CutoffDate DATE', @CutoffDate " +
                                           "PRINT 'Successfully deleted plctime from TBatchs' " +
                                       "END " +

                                       "IF EXISTS ( " +
                                           "SELECT 1 " +
                                           "FROM sys.columns " +
                                           "WHERE [object_id] = OBJECT_ID(@tableName) AND [name] = 'TimeString' " +
                                       ") " +
                                       "BEGIN " +
                                           "SET @sql = 'DELETE FROM ' + @tableName + ' WHERE TimeString < @CutoffDate' " +
                                           "EXEC sp_executesql @sql, N'@CutoffDate DATE', @CutoffDate " +
                                           "PRINT 'Successfully deleted TimeString from TDosing' " +
                                       "END " +

                                       "FETCH NEXT FROM tableCursor INTO @tableName " +
                                   "END " +
                                   "CLOSE tableCursor " +
                                   "DEALLOCATE tableCursor " +

                                   "DBCC SHRINKDATABASE (0) " +

                               "END";

            try
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex);
                Console.WriteLine("Error on Create_CleanTables_Alarm_func");
            }
        }

        public static int CleanTablesDB(string typeOfDB, string connectionString, DateTime date)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (typeOfDB == "Alarm")
                    {
                        using (SqlCommand command = new SqlCommand("CleanTables_Alarm", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@CutoffDate", SqlDbType.DateTime).Value = date;
                            object result = command.ExecuteScalar();

                            return 1;
                        }
                    }
                    else
                    {
                        using (SqlCommand command = new SqlCommand("CleanTables", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@CutoffDate", SqlDbType.DateTime).Value = date;
                            object result = command.ExecuteScalar();

                            return 1;
                        }
                    }
                }
            }

            catch (Exception ex) { General.ErrorMessage(ex); return ex.HResult; }
        }

        public static long GetSizeOfDB(string connectionString)
        {
            long databaseSize = 0;
            const long BYTES_IN_8GB = 8L * 1024 * 1024 * 1024;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Create_GetCurrentDBsize_func(connection);

                    using (SqlCommand command = new SqlCommand("GetCurrentDatabaseSize", connection)) // calling procedure by name
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            databaseSize = Convert.ToInt64(result);
                        }
                        if (databaseSize > BYTES_IN_8GB)
                        {
                            MessageBox.Show("Размер этой базы данных превышает 8 ГБ. Очистить эту базу данных?", 
                                $"Размер БД {GetInitialCatalog(connectionString)}",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error on GetSizeOfDB");
                General.ErrorMessage(ex);
                return -1;
            }

            return databaseSize;
        }

        static string GetInitialCatalog(string connectionString)
        {
            var match = Regex.Match(connectionString, @"Initial Catalog=(.*?);");
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

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

        public static int AddTablesToNewDB(string typeOfDB ,string NewProjectConnectionString) // добавление таблиц в БД
        {
            string sqlQuery = "";


            try
            {
                using (SqlConnection connection = new SqlConnection(NewProjectConnectionString))
                {
                    connection.Open();  

                    if (typeOfDB == "Alarm")
                    {
                        Create_CleanTables_Alarm_func(connection);

                        sqlQuery = "CREATE TABLE dbo.alams_connect_source (" +
                                       "id INT NOT NULL, " +
                                       "fname VARCHAR(50) NULL " +
                                   ")";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on alams_connect_source");
                            General.ErrorMessage(ex);
                        }

                        sqlQuery = "CREATE TABLE dbo.Alarm_log_10 (" +
                                       "Time_ms float NULL, " +
                                       "MsgProc smallint NULL, " +
                                       "StateAfter smallint NULL, " +
                                       "MsgClass smallint NULL, " +
                                       "MsgNumber int NULL, " +
                                       "Var1 varchar(255) NULL, " +
                                       "Var2 varchar(255) NULL, " +
                                       "Var3 varchar(255) NULL, " +
                                       "Var4 varchar(255) NULL, " +
                                       "Var5 varchar(255) NULL, " +
                                       "Var6 varchar(255) NULL, " +
                                       "Var7 varchar(255) NULL, " +
                                       "Var8 varchar(255) NULL, " +
                                       "TimeString char(26) NULL, " +
                                       "MsgText varchar(255) NULL, " +
                                       "PLC varchar(255) NULL " +
                                   ")";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on Alarm_log_10");
                            General.ErrorMessage(ex);
                        }

                        sqlQuery = "CREATE TABLE dbo.alarms (" +
                                       "plctime datetime2(3) NOT NULL, " +
                                       "rtime datetime2(3) NOT NULL, " +
                                       "mnumber int NULL, " +
                                       "mproc smallint NULL, " +
                                       "mclass smallint NULL, " +
                                       "mtext varchar(255) NULL, " +
                                       "stateafter smallint NULL, " +
                                       "v01 varchar(128) NULL, " +
                                       "v02 varchar(128) NULL, " +
                                       "v03 varchar(128) NULL " +
                                   ")";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on alarms");
                            General.ErrorMessage(ex);
                        }

                        sqlQuery = "CREATE TABLE dbo.alarms_tested (" +
                                       "plctime datetime2(3) NOT NULL, " +
                                       "rtime datetime2(3) NOT NULL, " +
                                       "mnumber int NULL, " +
                                       "mproc smallint NULL, " +
                                       "mclass smallint NULL, " +
                                       "mtext varchar(255) NULL, " +
                                       "stateafter smallint NULL, " +
                                       "v01 varchar(128) NULL, " +
                                       "v02 varchar(128) NULL, " +
                                       "v03 varchar(128) NULL " +
                                   ")";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on alarms_tested");
                            General.ErrorMessage(ex);
                        }

                        sqlQuery = "CREATE TABLE dbo.Data_log_10 (" +
                                       "VarName varchar(255) NULL, " +
                                       "TimeString char(26) NULL, " +
                                       "VarValue float NULL, " +
                                       "Validity smallint NULL, " +
                                       "Time_ms float NULL " +
                                   ")";
                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on Data_log_10");
                            General.ErrorMessage(ex);
                        }

                        sqlQuery = "CREATE TABLE dbo.Data_log_SQL0 (" +
                                       "VarName varchar(255) NULL, " +
                                       "TimeString char(26) NULL, " +
                                       "VarValue float NULL, " +
                                       "Validity smallint NULL, " +
                                       "Time_ms float NULL " +
                                   ")";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on Data_log_SQL0");
                            General.ErrorMessage(ex);
                        }

                    }
                    else
                    {
                        Create_CleanTables_Report_func(connection);

                        sqlQuery = "CREATE TABLE dbo.tBatchs (" +
                                       "ID int NOT NULL PRIMARY KEY, " +
                                       "OrderID int NULL, " +
                                       "BatchN int NULL, " +
                                       "Sts int NULL, " +
                                       "DAT_Start_Dosing datetime NULL, " +
                                       "DAT_Start_Mixing datetime NULL, " +
                                       "DAT_Start_Unload datetime NULL, " +
                                       "DAT_End datetime NULL, " +
                                       "VolumeSet real NULL, " +
                                       "VolumeDone real NULL, " +
                                       "MixingTime int NULL, " +
                                       "OperatorID int NULL " +
                                   ")";


                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on tBatchs");
                            General.ErrorMessage(ex);
                        }

                        sqlQuery = "CREATE TABLE dbo.tDosing (" +
                                       "SilosType int NULL, " +
                                       "Sts int NULL, " +
                                       "DAT_Start datetime NULL, " +
                                       "DAT_End datetime NULL, " +
                                       "SRC bit NULL, " +
                                       "BatchID int NULL, " +
                                       "BatchStep int NULL, " +
                                       "BatchRank int NULL, " +
                                       "SilosN int NULL, " +
                                       "SilosLabelID int NULL, " +
                                       "WeightSet real NULL, " +
                                       "WeightDose real NULL, " +
                                       "OperatorID int NULL " +
                                   ")";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on tDosing");
                            General.ErrorMessage(ex);
                        }

                        sqlQuery = "CREATE TABLE dbo.tOperator (" +
                                       "ID int NOT NULL PRIMARY KEY, " +
                                       "Operator nvarchar(50) NULL " +
                                   ")";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on tOperator");
                            General.ErrorMessage(ex);
                        }

                        sqlQuery = "CREATE TABLE dbo.tOrders (" +
                                       "ID int NOT NULL PRIMARY KEY, " +
                                       "Sts int NULL, " +
                                       "DAT_Create datetime NULL, " +
                                       "DAT_Start datetime NULL, " +
                                       "DAT_End datetime NULL, " +
                                       "Recipe int NULL, " +
                                       "RecipeLabelID int NULL, " +
                                       "BatchSet int NULL, " +
                                       "BatchDone int NULL, " +
                                       "VolumeSet real NULL, " +
                                       "VolumeDone real NULL, " +
                                       "Line int NULL, " +
                                       "UnloadPlace bit NULL, " +
                                       "OperatorID int NULL " +
                                   ")";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on tOrders");
                            General.ErrorMessage(ex);
                        }

                        sqlQuery = "CREATE TABLE dbo.tRecipe (" +
                                       "ID int NOT NULL PRIMARY KEY, " +
                                       "RecipeN int NULL, " +
                                       "RecipeLabel nvarchar(35) NULL, " +
                                       "DAT_Create datetime NULL, " +
                                       "UnloadPlace bit NULL, " +
                                       "TimeMixing1_s int NULL, " +
                                       "TimeMixing2_s int NULL, " +
                                       "TimeMixing3_s int NULL, " +
                                       "TimeMixing4_s int NULL, " +
                                       "TimeMixing5_s int NULL, " +
                                       "TimeMixing6_s int NULL, " +
                                       "TimeMixing7_s int NULL, " +
                                       "TimeMixing8_s int NULL, " +
                                       "TimeMixing9_s int NULL, " +
                                       "TimeMixingEnd_s int NULL, " +
                                       "UseActiator1 bit NULL, " +
                                       "UseActiator2 bit NULL, " +
                                       "UseActiator3 bit NULL, " +
                                       "TimeActatorWork_s int NULL, " +
                                       "OperatorID int NULL " +
                                   ")";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on tRecipe");
                            General.ErrorMessage(ex);
                        }

                        sqlQuery = "CREATE TABLE dbo.tSilosLabel (" +
                                       "ID int NOT NULL PRIMARY KEY, " +
                                       "SilosLabel nvarchar(35) NULL, " +
                                       "DAT_Create datetime NULL, " +
                                       "SilosN int NULL, " +
                                       "SilosType bit NULL " +
                                   ")";

                        try
                        {
                            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error on tSilosLabel");
                            General.ErrorMessage(ex);
                        }
                    }

                    connection.Close();
                }

                MessageBox.Show("Таблицы успешно добавлены в БД", "Таблицы добавлены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on AddTablesToNewDB");
                General.ErrorMessage(ex);
                return ex.HResult;
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
