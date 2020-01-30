using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace TmsFix.myCode
{
    class TmsAccountVoucher
    {
        public void UnpostVoucher()
        {
            
        }

        public DataTable GetVoucherTypeList()
        {
            OracleConnection oracleConnection = new OracleConnection(myCode.Globals._conStringOra);
            string strSql = "SELECT V_TYPE,svt.VOUCHER_DESCRIPTION FROM TMS.SY_VOUCHER_TYPE svt";
            OracleDataAdapter adpOracleDataAdapter = new OracleDataAdapter(strSql, oracleConnection);
            DataTable tblOraTable = new DataTable();
            adpOracleDataAdapter.Fill(tblOraTable);
            return tblOraTable;  
        }

        public DataTable GetVoucherDetails(string voucherType, string voucherNo)
        {
            OracleConnection oracleConnection = new OracleConnection(myCode.Globals._conStringOra);
            string strSql = "SELECT GVM.SEQ_NO ID,gvm.V_TYPE TYPE,gvm.VOUCHNO V_NO,GVM.V_DATE V_dATE,GVM.POST_DT,GVM.POSTED_BY FROM GL_VOCH_MAST gvm "+
                "WHERE gvm.V_TYPE = '"+ voucherType +"' AND gvm.VOUCHNO LIKE '%"+ voucherNo+"%'";
            OracleDataAdapter adpOracleDataAdapter = new OracleDataAdapter(strSql, oracleConnection);
            DataTable tblOraTable = new DataTable();
            adpOracleDataAdapter.Fill(tblOraTable);
            return tblOraTable;
        }

        public void UnpostVoucher(string pVoucherNo)
        {
            OracleConnection oracleConnection = new OracleConnection(myCode.Globals._conStringOra);
            OracleCommand cmdOra;
            cmdOra = new OracleCommand();
            cmdOra.CommandType = CommandType.StoredProcedure;
            cmdOra.Connection = oracleConnection;
            cmdOra.CommandText = "TMS.PROC_UNPOST_VOUCHER";
            cmdOra.Parameters.Add("p_voucher_no", pVoucherNo);
            cmdOra.Parameters.Add("p_flag", "U");

            oracleConnection.Open();
            cmdOra.ExecuteNonQuery();
            oracleConnection.Close();
        }
    }    
}
