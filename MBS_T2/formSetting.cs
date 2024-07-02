using Microsoft.Vbe.Interop;
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
    public partial class formSetting : Form
    {
        public formSetting()
        {
            InitializeComponent();
            Load += new EventHandler(formSetting_Load);
        }

        private void formSetting_Load(object sender, System.EventArgs e)
        {
            textBox_ProjectName.Text = Properties.Settings.Default.ProjectName;
            textBox_ReportPatch.Text = Properties.Settings.Default.ReportPatch;
            textBox_ReportConnection.Text = Properties.Settings.Default.ReportConnectionString;
            textBox_AlarmConnection.Text = Properties.Settings.Default.AlarmConnectionString;
        }

        // ProjectName

        private void btn_ProjectName_Change_Click(object sender, EventArgs e)
        {
            textBox_ProjectName.ReadOnly = false;
            btn_ProjectName_Cancel.Visible = true;
            btn_ProjectName_Change.Visible = false;
        }

        private void btn_ProjectName_Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ProjectName = textBox_ProjectName.Text;
            Properties.Settings.Default.Save();
            textBox_ProjectName.ReadOnly = true;
            btn_ProjectName_Cancel.Visible = false;
            btn_ProjectName_Change.Visible = true;
        }

        private void btn_ProjectName_Cancel_Click(object sender, EventArgs e)
        {
            textBox_ProjectName.Text = Properties.Settings.Default.ProjectName;
            textBox_ProjectName.ReadOnly = true;
            btn_ProjectName_Cancel.Visible = false;
            btn_ProjectName_Change.Visible = true;
        }

        // ReportPatch

        private void btn_ReportPatch_Change_Click(object sender, EventArgs e)
        {
            textBox_ReportPatch.ReadOnly = false;
            Properties.Settings.Default.ReportPatch = @"D:\Projects\MBS\Report\отчеты"; 

            string sFilePatch = General.GetFilePatch();

            if (sFilePatch != "")
            {
                textBox_ReportPatch.Text = sFilePatch;
                Properties.Settings.Default.ReportPatch = textBox_ReportPatch.Text;
                Properties.Settings.Default.Save();
                textBox_ReportPatch.ReadOnly = true;
            }
            else
            {
                textBox_ReportPatch.ReadOnly = true;
            }
        }

        // Report Connection

        private void btn_ReportConnection_Change_Click(object sender, EventArgs e)
        {
            int ErrCode = SQLControls.GetConnectionString("ReportConnectionString");

        }



        private void btn_ReportConnection_CheckCon_Click(object sender, EventArgs e)
        {
            bool chDB = SQLControls.CheckDB("");
        }

        // Alarm Connection

        private void btn_AlarmConnection_Change_Click(object sender, EventArgs e)
        {
            int gConString = SQLControls.GetConnectionString("");
        }

        private void btn_AlarmConnection_CheckCon_Click(object sender, EventArgs e)
        {
            bool chDB = SQLControls.CheckDB("");
        }

    }
}
