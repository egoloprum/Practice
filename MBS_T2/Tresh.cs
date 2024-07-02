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

namespace WFA_СS
{
   class  Tresh
    {
        //public static int CopyInformationSchema()
        //{
        //    SqlConnection myConn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=E:\\Projects\\DB\\u2.mdf;Integrated Security=True;Connect Timeout=30");
        //    SqlConnection ProjectConn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Application.StartupPath + "\\Projects.mdf;Integrated Security=True");
        //    string[] TableNames=new string [3]{
        //    "TABLES",
        //    "COLUMNS",
        //    "KEY_COLUMN_USAGE"};
        //    try
        //    {
      //        ProjectConn.Open();
        //        for (int i = 0; i < 3; i++)
        //        {
        //            SqlCommand ReadCommand = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA." + TableNames[i], ProjectConn);
        //            SqlCommand WriteCommand = new SqlCommand("INSERT INTO INFORMATION_SCHEMA." + TableNames[i] + "*", myConn);
        //            SqlDataReader sqlreader = ReadCommand.ExecuteReader();
        //            while (sqlreader.Read())
        //            {
        //                if (!sqlreader.IsDBNull(0))
        //                {
        //                    MessageBox.Show(sqlreader.GetString(2) + "   " +sqlreader.GetString(3), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            sqlreader.Close();
                        
        //        }
        //        MessageBox.Show("DataBase is Copied Successfully", "Message2", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        ProjectConn.Close();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Message3", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    finally
        //    {
        //    }
        //    return 0;
        //}



//public string myConnectionString(string ID, string Password, string Path, short Mode)
// {
//     string ConnectionString = "Data Source=(LocalDB)\\v11.0; Integrated Security=True;";//по умолчанию локальная БД
//     switch (Mode)
//     {
//         case 0: //локальная база данных                  
//             ConnectionString = "Data Source=(LocalDB)\\v11.0; Integrated Security=True;";
//             break;
//         case 1://локальная база данных                   
//             ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=sa123456";
//             break;
//     }
//     return ConnectionString;
// }

      //public const int i_max=1;
//      public static string[] DBStripts_AddTable=new string [i_max]{
//            //0-создание таблицы [ProjectInfo][IF NOT EXISTS]
//               @"CREATE TABLE [dbo].[ProjectInfo]
//            (
//	        [ID] NCHAR(20) NOT NULL PRIMARY KEY,
//            [ShortName] NCHAR(55) NULL, 
//            [FullName] NCHAR(300) NULL, 
//	        [Type] NCHAR(100) NOT NULL, 
//            [Path] NCHAR(100) NOT NULL, 
//	        [Password] NCHAR(20) NOT NULL,
//            [Developer] NCHAR(50) NULL, 
//            [Customer] NCHAR(50) NULL    
//            )"
//      };
  //public static int DBCreator(string ConnectionString)
  //    {
  //        SqlConnection myConn = new SqlConnection(ConnectionString);
  //        try
  //        {
  //            myConn.Open();
  //            for (int i = 0; i < i_max; i++)
  //            {

  //                bool FindTable = ObjExists(ConnectionString, "Table", "ProjectInfo");
  //                if (FindTable == false)
  //                {
  //                    SqlCommand myCommand = new SqlCommand(DBStripts_AddTable[i], myConn);
  //                    myCommand.ExecuteNonQuery();
  //                    MessageBox.Show("DataBase is Connected Successfully", "Создание новой БД проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
  //                }
  //            }
  //            return 0;
  //        }
  //        catch (System.Exception ex)
  //        {
  //            MessageBox.Show(ex.Message, "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
  //            return ex.HResult;
  //        }
  //        finally
  //        {
  //        }

  //    }
public static string CreateDB(string ID, string Password, string Path, short Mode)
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
                  NewProjectConnectionString = "Data Source=" + Path + ";Initial Catalog=" + ID + ";User ID=sa;Password=sa123456";
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
                              "FILENAME = '" + Path + ID + ".ldf', " +
                              "SIZE = 1MB, " +
                              "MAXSIZE = 5MB, " +
                              "FILEGROWTH = 10%)";
                  break;
              case 2:
                  //БД MS Access *.accdb
                  try
                  {
                      NewProjectConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + "\\" + ID + ".accdb;Jet OLEDB:Engine Type=5;Jet OLEDB:Database Password=" + Password;
                      ADOX.Catalog BD = new ADOX.Catalog();
                      BD.Create(NewProjectConnectionString);
                      BD = null;
                      SQLControls.AddTablesToNewBD(NewProjectConnectionString);
                      MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);

                  }
                  catch (System.Exception ex)//catch (SqlException ex )          
                  {
                      MessageBox.Show(ex.Message, "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                  finally
                  {
                  }
                  break;
          }


          if (Mode == 0 || Mode == 1)
          {
       E:\Projects\WFA_СS\WFA_СS\Program.cs       SqlConnection myConn = new SqlConnection(myConnectionString);
              SqlCommand myCommand = new SqlCommand(str, myConn);
              try
              {
                  myConn.Open();
                  myCommand.ExecuteNonQuery();
                  SQLControls.AddTablesToNewBD(NewProjectConnectionString);
                  MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);

              }
              catch (System.Exception ex)//catch (SqlException ex )          
              {
                  MessageBox.Show(ex.Message, "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
              finally
              {
                  if (myConn.State == ConnectionState.Open)
                  {
                      myConn.Close();
                  }
              }
          }

          return NewProjectConnectionString;
      } //создание новой БД
               private int PointerTest(IntPtr Pointer)
        {
            string str = Pointer.ToString();

            MessageBox.Show(str, "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            str = str + " Hey";
            IntPtr ptr = ConvertStringToIntPtr(str); //получаем указатель
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Hello, Word!";
            //int val = Convert.ToInt32(str, 16);
            //IntPtr ptr = new IntPtr(val); //получаем указатель
            IntPtr ptr = ConvertStringToIntPtr(str);
            PointerTest(ptr);
            str = ptr.ToString();
            MessageBox.Show(str, "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        IntPtr ConvertStringToIntPtr(string hexString)
        {
            //IntPtr ptr;
            //удаляем 0х дял конвертации
            hexString = hexString.Replace("0x", "");
            //конвертируем в 10ую систему счисления, это необходимо дял вызова конструктора структуры
            long decAgain = long.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
            return new IntPtr(decAgain);
        }
    }
}