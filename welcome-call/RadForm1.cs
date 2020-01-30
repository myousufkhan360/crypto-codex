using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelExportTms
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now;
            grdMtrClaimPaid.ReadOnly = true;
            lblReportName.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdoClaimPaid.Checked)
            {
                ExecuteWelcomeCallReport();
            }
            else 
            {
                MessageBox.Show("Please Select Welcome Calls");
            }

        }

        private void ExecuteWelcomeCallReport()
        {
            DataOps dataOps = new DataOps();
            DataTable tblTable = new DataTable();

            lblReportName.Text = "Motor Welcome Calls";
            tblTable = dataOps.GetWelcomeCall(dtpFromDate.Value);

            if (Directory.Exists(@"C:\OutputFiles\") == false)
            {
                Directory.CreateDirectory(@"C:\OutputFiles\");
            }


            if (tblTable != null)
            {
                string fileName = @"C:\OutputFiles\TmsWelcome_Call_" + DateTime.Now.ToString("yyyy-MM-dd-THHmmss") + ".xlsx";
                ExcelFiles.WriteExcelFile(fileName,
                    tblTable);
                grdMtrClaimPaid.DataSource = tblTable;
                MessageBox.Show("File has been created in " + fileName);
            }

        }

        

        }
    
    }


