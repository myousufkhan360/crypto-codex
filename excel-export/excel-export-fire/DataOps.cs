using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ExcelExportTms
{

class DataOps
    {
        public DataTable GetClaimPaidData(DateTime fromDate, DateTime toDate)
        {
            //Ora Connection
            OracleConnection _oracleConnection = new OracleConnection(Globals.conStringOra);
            string strSql = "SELECT * FROM VW_MIS_MTR_CLAIM_PAID WHERE PAID_DATE BETWEEN '" +
                            toDate.ToString("dd-MMM-yyyy") + "' AND '" + toDate.ToString("dd-MMM-yyyy") + "'";
            OracleDataAdapter _oracleDataAdapter = new OracleDataAdapter(strSql, _oracleConnection);
            DataTable _tblOracle = new DataTable();

            _oracleDataAdapter.Fill(_tblOracle);

            return _tblOracle;
        }

        public DataTable GetFireEnggContribution(DateTime fromDate, DateTime toDate)
        {
            //Ora Connection
            OracleConnection _oracleConnection = new OracleConnection(Globals.conStringOra);
            string strSql = "SELECT * FROM VW_MIS_GEN_CONTRIBUTION WHERE ISSUE_DATE BETWEEN '" +
                            fromDate.ToString("dd-MMM-yyyy") + "' AND '" + toDate.ToString("dd-MMM-yyyy") + "'";
            OracleDataAdapter _oracleDataAdapter = new OracleDataAdapter(strSql, _oracleConnection);
            DataTable _tblOracle = new DataTable();

            _oracleDataAdapter.Fill(_tblOracle);


            return _tblOracle;
        }
    }
}
