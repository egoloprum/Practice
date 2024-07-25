using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBS
{
    public partial class formClearDB : Form
    {
        string _connectionString = "";
        string _typeOfDB = "";

        public formClearDB(string typeOfDB, string connectionString)
        {
            _connectionString = connectionString;
            _typeOfDB = typeOfDB;

            InitializeComponent();
        }

        private void formClearDB_Load(object sender, EventArgs e)
        {
            dateTimePicker_TillDate.MaxDate = DateTime.Today.AddYears(-1);

            dateTimePicker_Oneyear.Value = DateTime.Today.AddYears(-1);
            dateTimePicker_Oneyear.MaxDate = DateTime.Today.AddYears(-1);
            dateTimePicker_Oneyear.MinDate = DateTime.Today.AddYears(-1);

            dateTimePicker_Twoyear.Value = DateTime.Today.AddYears(-2);
            dateTimePicker_Twoyear.MaxDate = DateTime.Today.AddYears(-2);
            dateTimePicker_Twoyear.MinDate = DateTime.Today.AddYears(-2);

            dateTimePicker_Oneyear.Enabled = false;
            dateTimePicker_Twoyear.Enabled = false;
        }

        private void radioBtn_TillDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_TillDate.Enabled = true;
            dateTimePicker_Oneyear.Enabled = false;
            dateTimePicker_Twoyear.Enabled = false;
        }

        private void radioBtn_Oneyear_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_TillDate.Enabled = false;
            dateTimePicker_Oneyear.Enabled = true;
            dateTimePicker_Twoyear.Enabled = false;
        }

        private void radioBtn_Twoyear_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_TillDate.Enabled = false;
            dateTimePicker_Oneyear.Enabled = false;
            dateTimePicker_Twoyear.Enabled = true;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены, что хотите очистить БД? Восстановление данных после очистки не возможно.",
                                               "Очистка БД", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            int result = 0;

            if (res == DialogResult.Yes)
            {
                // clear db

                if (dateTimePicker_TillDate.Enabled)
                {
                    result = SQLControls.CleanTablesDB(_typeOfDB, _connectionString, dateTimePicker_TillDate.Value);
                }

                if ( dateTimePicker_Oneyear.Enabled)
                {
                    result = SQLControls.CleanTablesDB(_typeOfDB, _connectionString, dateTimePicker_Oneyear.Value);
                }

                if (dateTimePicker_Twoyear.Enabled)
                {
                    result = SQLControls.CleanTablesDB(_typeOfDB, _connectionString, dateTimePicker_Twoyear.Value);
                }

                if (result == 1)
                {
                    MessageBox.Show("База данных успешно очищена..", "Очистка БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                // close 
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
