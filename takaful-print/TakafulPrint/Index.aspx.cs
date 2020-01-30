using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TakafulTelerik;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Telerik.Reporting.Processing;


namespace TakafulPrint
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int _PolicyNumber = Convert.ToInt32(Request["policyNumber"]);
            lblPolicyNumber.Text = "Policy Number: " + _PolicyNumber;

            TravelPolicyPrint _TravelPolicyPrint = new TravelPolicyPrint();
            SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            string _strSql = "SELECT * FROM vuTravelPolicyPrint WHERE PolicyNumber=" + _PolicyNumber;
            SqlDataAdapter _adpSql = new SqlDataAdapter(_strSql, _conSql);
            DataTable _tblSql = new DataTable();

            _adpSql.Fill(_tblSql);            
            _TravelPolicyPrint.DataSource = _tblSql;

            ReportProcessor reportProcessor = new ReportProcessor();
            Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource.ReportDocument = _TravelPolicyPrint;
            RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

            string fileName = result.DocumentName + "." + result.Extension;

            Response.Clear();
            Response.ContentType = result.MimeType;
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.Expires = -1;
            Response.Buffer = true;
            Response.BinaryWrite(result.DocumentBytes);
            Response.End();



        }
    }
}