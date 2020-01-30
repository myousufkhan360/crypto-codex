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
            dtpToDate.Value = DateTime.Now;
            grdMtrClaimPaid.ReadOnly = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataOps dataOps = new DataOps();
            DataTable tblTable= new DataTable();

            tblTable = dataOps.GetFireEnggContribution(dtpFromDate.Value, dtpToDate.Value);

            if (Directory.Exists(@"C:\OutputFiles\")==false)
            {
                Directory.CreateDirectory(@"C:\OutputFiles\");
            }


            if (tblTable != null)
            {
                string fileName = @"C:\OutputFiles\FirEngContrib_" + DateTime.Now.ToString("yyyyMMddTHHmmss") +".xlsx";
                ExcelFiles.WriteExcelFile(fileName,
                    tblTable);
                grdMtrClaimPaid.DataSource = tblTable;
                MessageBox.Show("File has been created in " + fileName);
            }

        }
    }
}
