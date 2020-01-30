using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TmsFix.myCode
{
    class TmsHeader
    {
        public string AssortedCode { get; set; }
        public string AssortedString { get; set; }
        public string AssortedFortmattedString { get; set; }
        public string DocumentType { get; set; }
        public string IssueDate { get; set; }
        public string PostingStatus { get; set; }

        public List<TmsHeader> GeTmsHeaderData(string assortedString)
        {
            OracleConnection oracleConnection = new OracleConnection(myCode.Globals._conStringOra);
            string strSql = "SELECT * FROM TMS.VW_TMS_FIX_HEADER WHERE ASSORTED_STRING LIKE '%" + assortedString + "%' OR end_string LIKE '%" + assortedString + "%'";
            OracleDataAdapter adpOracleDataAdapter = new OracleDataAdapter(strSql, oracleConnection);
            DataTable tblOraTable = new DataTable();
            List<TmsHeader> tmsHeaders = new List<TmsHeader>();
            TmsHeader tmsHeader;

            adpOracleDataAdapter.Fill(tblOraTable);

            for (int i = 0; i < tblOraTable.Rows.Count; i++)
            {
                tmsHeader = new TmsHeader();
                tmsHeader.AssortedCode = tblOraTable.Rows[i]["ASSORTED_CODE"].ToString();
                tmsHeader.AssortedFortmattedString = tblOraTable.Rows[i]["ASSORTED_STRING_FMT"].ToString();
                tmsHeader.AssortedString = tblOraTable.Rows[i]["ASSORTED_STRING"].ToString();
                tmsHeader.DocumentType = tblOraTable.Rows[i]["DOCUMENT_NAME"].ToString();
                tmsHeader.IssueDate = tblOraTable.Rows[i]["ISSUE_DATE"].ToString();
                tmsHeader.PostingStatus = tblOraTable.Rows[i]["POSTING_STATUS"].ToString();

                tmsHeaders.Add(tmsHeader);
            }

            return tmsHeaders;
        }
    }
}
