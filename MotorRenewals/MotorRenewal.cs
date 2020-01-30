using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Telerik.WinControls.UI;

namespace MotorRenewals
{
    class MotorRenewal
    {
        public DataTable GetPolicyData(string policyString)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(Globals._conStringOra);
                string strSql =
                    "SELECT ia.ASSORTED_CODE,ia.ASSORTED_STRING,ia.CLIENT_CODE,ia.PERIOD_FROM,ia.PERIOD_TO_DATE" +
                    " from INS_ASSORTED ia INNER JOIN INS_POLICY_TYPES ipt ON ia.POLICY_TYPE_CODE = ipt.POLICY_TYPE_CODE " +
                    " WHERE ipt.CLASS_CODE  = '02' AND ia.DOCUMENT_CODE IN ('04','07') AND ia.ASSORTED_STRING LIKE '%"+ policyString +"%' ORDER BY ASSORTED_CODE";
                OracleDataAdapter adapter = new OracleDataAdapter(strSql, oracleConnection);
                DataTable tableOra = new DataTable();

                adapter.Fill(tableOra);
                return tableOra;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DataTable GetRenewalData(string policyString)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(Globals._conStringOra);
                string strSql =
                    "SELECT * FROM TMP_MTR_RENEWAL WHERE OLD_POLICY_NO LIKE '%" + policyString +"%' ORDER BY ASSORTED_CODE";
                OracleDataAdapter adapter = new OracleDataAdapter(strSql, oracleConnection);
                DataTable tableOra = new DataTable();

                adapter.Fill(tableOra);
                return tableOra;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void GenerateRenewalNotice(string assortedCode)
        {
            OracleConnection oracleConnection = new OracleConnection(Globals._conStringOra);
            OracleCommand oraCommand = new OracleCommand();
            oraCommand.Connection = oracleConnection;
            oraCommand.CommandType = CommandType.StoredProcedure;
            oraCommand.CommandText = "TMS.PKG_MOTOR_RENEWAL.GENERATE_RENEWAL_NOTICES";
            oraCommand.Parameters.Add("P_ASSORTED_CODE", OracleDbType.Varchar2).Value = assortedCode;

            oracleConnection.Open();
            oraCommand.ExecuteNonQuery();
            oracleConnection.Close();

        }

        public void RenewCertificate(string renewalAssortedCode)
        {
            OracleConnection oracleConnection = new OracleConnection(Globals._conStringOra);
            OracleCommand oraCommand = new OracleCommand();
            oraCommand.Connection = oracleConnection;
            oraCommand.CommandType = CommandType.StoredProcedure;
            oraCommand.CommandText = "TMS.PKG_MOTOR_RENEWAL.RENEW_CERTIFICATE";
            oraCommand.Parameters.Add("P_ASSORTED_CODE", OracleDbType.Varchar2).Value = renewalAssortedCode;

            oracleConnection.Open();
            oraCommand.ExecuteNonQuery();
            oracleConnection.Close();

        }

        public void AssociateWithMastherPolicy(string policyString)
        {
            string strSql =
                "SELECT IA.ASSORTED_CODE,IA.GENERATE_AGAINST,TO_NUMBER(SUBSTR(IA.ASSORTED_STRING,14,10)) NEW_POLICY_NO" +
                " FROM TMP_MTR_RENEWAL tmr  INNER JOIN INS_ASSORTED ia  ON tmr.RNEW_ASSORTED_CODE = ia.GENERATE_AGAINST" +
                " WHERE tmr.OLD_POLICY_NO = '"+ policyString +"'  AND ia.DOCUMENT_CODE  = '04'  AND SUBSTR(IA.ASSORTED_STRING,-4) >= '2019'";

            OracleConnection conOra = new OracleConnection(Globals._conStringOra);
            OracleDataAdapter adpOra = new OracleDataAdapter(strSql, conOra);
            DataTable tblOra = new DataTable();

            adpOra.Fill(tblOra);

            string polAssortedCode, newPolicyNo;

            if (tblOra.Rows.Count > 0)
            {
                polAssortedCode = tblOra.Rows[0]["ASSORTED_CODE"].ToString();
                newPolicyNo = tblOra.Rows[0]["NEW_POLICY_NO"].ToString();

                string strSql2 = "UPDATE TMP_MTR_RENEWAL SET NEW_POLICY_NO ='" + newPolicyNo + "', POL_ASSORTED_CODE ='" +
                                 polAssortedCode + "' WHERE OLD_POLICY_NO='" + policyString + "'";

                OracleCommand cmdOra = new OracleCommand(strSql2, conOra);

                conOra.Open();
                cmdOra.ExecuteNonQuery();
                conOra.Close();

            }







        }
    }
}
