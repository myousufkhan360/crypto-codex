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
        public DataTable GetWelcomeCall(DateTime mtrDate)
        {
            //Ora Connection
            OracleConnection _oracleConnection = new OracleConnection(Globals.conStringOra);
            string strSql = "SELECT * FROM VW_MTR_WELCOME_CALLS vmwc WHERE TRUNC(vmwc.ISSUE_DATE) = '" + mtrDate.ToString("dd-MMM-yyyy") +"'";
            OracleDataAdapter _oracleDataAdapter = new OracleDataAdapter(strSql, _oracleConnection);
            DataTable _tblOracle = new DataTable();

            _oracleDataAdapter.Fill(_tblOracle);

            return _tblOracle;
        }

        

    }
}
