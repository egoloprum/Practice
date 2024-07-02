using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using mySecurity;
using System.IO;
using Microsoft.Win32;
using MBS.Properties;
using System.Configuration;

namespace MBS
{
   class  General
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

       public static void Login(string sLogin, string sPassword)
       {
                myUser mUser = new myUser("Не авторизован", sLogin, sPassword, 0);
                if (mUser.Check() == 0)
                {
                    ProgramSettings.User= mUser.User;
                    if  (ProgramSettings.User=="" )  ProgramSettings.User="Не авторизован";
                    ProgramSettings.Role = mUser.Role;
                }
                else
                {
                    ProgramSettings.User = "Не авторизован";
                    ProgramSettings.Role = 0;
                }    
      
       }



       public static string Convertall(string value, Encoding src, Encoding trg)
       {
           Decoder dec = src.GetDecoder();
           byte[] ba = trg.GetBytes(value);
           int len = dec.GetCharCount(ba, 0, ba.Length);
           char[] ca = new char[len];
           dec.GetChars(ba, 0, ba.Length, ca, 0);
           return new string(ca);
       }

        public static string GetFilePatch()
        {          
            try 
	        {
                string sFilePatch = Properties.Settings.Default.ReportPatch;
                if (sFilePatch == null | !Directory.Exists(sFilePatch))
                {
                    FolderBrowserDialog Dir = new FolderBrowserDialog();
                    if (Dir.ShowDialog() == DialogResult.OK)
                    {
                        sFilePatch = Dir.SelectedPath;
                        Properties.Settings.Default.ReportPatch = sFilePatch;
                        Properties.Settings.Default.Save();
                        
                        //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        ////var userSection = (userSettings)config.GetSection("userSettings");
                        ////usersSection
                        ////    .ConnectionStrings["MBS.Properties.Settings." + sPropertyConnStr].ConnectionString = dcd.ConnectionString;
                        //config.Save();
                        //ConfigurationManager.RefreshSection("userSettings");
                        Properties.Settings.Default.Reload();
                    }
                    else sFilePatch = "";
                }
                if(sFilePatch=="")
                    MessageBox.Show("Сохранение не может быть выполнено. Для экспорта данных укажите директорию", "Сохранение не может быть выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return sFilePatch;
            }
            catch (System.Exception ex)
            {
                General.ErrorMessage(ex);
                return "";
	        }

        }

        

        //public struct OP
        //{
        //    public string sOperation = "";
        //    public int Count = 100;
        //    public int i = 0;
        //}


        //public static DateTime DAT = DateTime.Now;
        //public static string sDate = DAT.ToLongDateString() + "   " + DAT.DayOfWeek.ToString() + "      " + DAT.ToLongTimeString();

        //public unsafe struct StrPtr {
        //    public char* CharArray;
        //    public int Len;
        //}

        //public unsafe static int StringToPointer(string str)
        //{
        //  StrPtr prt;
        //    prt.Len=str.Length;

        //    char[] CharArray = new char[prt.Len];
        //    CharArray=str.ToCharArray();
        //    char*[] pCharArray = new char*[prt.Len];
        //    for (int i= 0; i < prt.Len; i++)
        //    {
        //        MessageBox.Show(CharArray[i].ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //fixed(pCharArray[i] =  &CharArray[i]);
        //    }

        //        return 0;
        //}
        //public unsafe static int PointerToString(char* pChar)
        //{
        //    //string str = new String(pChar);
        //    return 0;
        //}


    }
   class ProgramSettings {
       public static string User="";
       public static int Role=0;
       public static string[] Roles = new string[5] {
            "Гость",
            "Оператор",
            "Проектировщик",
            "Программист",
            "Администратор"};
       //public string Database;
       //public string Datasource;
       //public string State;
   }
}
