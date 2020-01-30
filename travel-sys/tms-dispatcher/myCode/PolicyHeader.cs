using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace TmsDispatcher
{
    class PolicyHeader
    {
        public string InsertPolicyHeader()
        {
            string _result="";

            SqlConnection _conSql = new SqlConnection(Globals._conStringSql);
            string _strSql = "SELECT * FROM vuTmsPolicyHeader";
            SqlDataAdapter _adpSql = new SqlDataAdapter(_strSql,_conSql);
            DataTable _tblSql = new DataTable();

            PolicyHeaderMDL _policyHeaderMdl = new PolicyHeaderMDL();

            for(int i=0;i<_tblSql.Rows.Count;i++)
            {
                _policyHeaderMdl.AgencyCode = _tblSql.Rows[i]["AgencyCode"].ToString();
                _policyHeaderMdl.AssortedString = _tblSql.Rows[i]["AssortedString"].ToString();
                _policyHeaderMdl.BranchCode = _tblSql.Rows[i]["BranchCode"].ToString();
                _policyHeaderMdl.CalculationType = _tblSql.Rows[i]["CalculationType"].ToString();
                _policyHeaderMdl.ClientCode = _tblSql.Rows[i]["ClientCode"].ToString();
                _policyHeaderMdl.DocumentCode = _tblSql.Rows[i]["DocumentCode"].ToString();
                _policyHeaderMdl.UserCode = _tblSql.Rows[i]["UserCode"].ToString();
                _policyHeaderMdl.UserIP = _tblSql.Rows[i]["UserIP"].ToString();
                _policyHeaderMdl.SystemDate = _tblSql.Rows[i]["SystemDate"].ToString();
                _policyHeaderMdl.FRR = _tblSql.Rows[i]["FRR"].ToString();
                _policyHeaderMdl.InsuredName = _tblSql.Rows[i]["InsuredName"].ToString();
                _policyHeaderMdl.IsValid = _tblSql.Rows[i]["IsValid"].ToString();
                _policyHeaderMdl.IssueDate = _tblSql.Rows[i]["IssueDate"].ToString();
                _policyHeaderMdl.PolicyFromDate = _tblSql.Rows[i]["PolicyFromDate"].ToString();
                _policyHeaderMdl.PolicyToDate = _tblSql.Rows[i]["PolicyToDate"].ToString();
                _policyHeaderMdl.PolicyDate = _tblSql.Rows[i]["PolicyDate"].ToString();
                _policyHeaderMdl.PolicyTypeCode = _tblSql.Rows[i]["PolicyTypeCode"].ToString();
                _policyHeaderMdl.PostingStatus = _tblSql.Rows[i]["PostingStatus"].ToString();
                _policyHeaderMdl.RsdFlag = _tblSql.Rows[i]["RsdFlag"].ToString();
                _policyHeaderMdl.PostedBy = _tblSql.Rows[i]["PostedBy"].ToString();
                _policyHeaderMdl.PostedIP = _tblSql.Rows[i]["PostedIP"].ToString();
                _policyHeaderMdl.PostedDate = _tblSql.Rows[i]["PostedDate"].ToString();
                _policyHeaderMdl.TakafulType = _tblSql.Rows[i]["TakafulType"].ToString();

            }

            _adpSql.Fill(_tblSql);

            StringBuilder _sb = new StringBuilder();
            string _assortedCode = getNewAssortedCode();
            for(int i=0;i<_tblSql.Rows.Count;i++)
            {
                _sb.AppendLine("INSERT INTO INS_ASSORTED(");
                _sb.AppendLine("ASSORTED_CODE,");
                _sb.AppendLine("AGENCY_CODE,");
                _sb.AppendLine("ASSORTED_STRING,");
                _sb.AppendLine("BRANCH_CODE,");
                _sb.AppendLine("CALC_TYPE_RE_FOR,");
                _sb.AppendLine("CLIENT_CODE,");
                _sb.AppendLine("DOCUMENT_CODE,");
                _sb.AppendLine("ENT_BY,");
                _sb.AppendLine("ENT_BY_IP,");
                _sb.AppendLine("ENT_DATE,");
                _sb.AppendLine("FRR,");
                _sb.AppendLine("INSURED_NAME,");
                _sb.AppendLine("IS_VALID,");
                _sb.AppendLine("ISSUE_DATE,");
                _sb.AppendLine("PERIOD_FROM,");
                _sb.AppendLine("PERIOD_TO_DATE,");
                _sb.AppendLine("POLICY_DATE,");
                _sb.AppendLine("POLICY_TYPE_CODE,");
                _sb.AppendLine("POSTING_STATUS,");
                _sb.AppendLine("RSD_FLAG,");
                _sb.AppendLine("SUP_BY,");
                _sb.AppendLine("SUP_BY_IP,");
                _sb.AppendLine("SUP_DATE,");
                _sb.AppendLine("TAKAFUL_TYPE)");
                _sb.AppendLine("VALUES(");
                _sb.AppendLine("'" + _assortedCode + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["AgencyCode"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["AssortedString"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["BranchCode"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["CalculationType"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["ClientCode"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["DocumentCode"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["UserCode"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["UserIP"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["SystemDate"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["FRR"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["InsuredName"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["IsValid"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["IssueDate"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["PolicyFromDate"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["PolicyToDate"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["PolicyDate"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["PolicyTypeCode"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["PostingStatus"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["RsdFlag"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["PostedBy"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["PostedIP"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["PostedDate"].ToString() + "',");
                _sb.AppendLine("'" + _tblSql.Rows[i]["TakafulType"].ToString() + "')");

                OracleConnection _conOra = new OracleConnection(Globals._conStringOra);
                OracleCommand _cmdOra = new OracleCommand(_sb.ToString(), _conOra);

                _conOra.Open();
                _cmdOra.ExecuteNonQuery();
                _conOra.Close();



            }




            return _result;
        }
        
        public string getNewAssortedCode()
        {
            string _result = "";
            string _strOra = "Select '04' || lpad(nvl(max(to_number(substr(ASSORTED_CODE, 3, 10))), 0) + 1,10,'0') ASSORTED_CODE from INS_ASSORTED Where DOCUMENT_CODE = '04'";
            OracleConnection _conOra = new OracleConnection(Globals._conStringOra);
            OracleDataAdapter _adpOra = new OracleDataAdapter(_strOra, _conOra);
            DataTable _tblOra = new DataTable();

            _adpOra.Fill(_tblOra);

            if(_tblOra.Rows.Count > 0)
            {
                _result = _tblOra.Rows[0][0].ToString();
            }
            else
            {
                _result = "-1";
            }


            return _result;
        }

        

    }
}
