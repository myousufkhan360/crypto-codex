using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace TmsFix.myCode
{
    class TmsContribution
    {
        public string AssortedCode { get; set; }
        public string OrderNo { get; set; }
        public string ChargeCode { get; set; }
        public string ChargeName { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal PreviousAmount { get; set; }
        public decimal DifferAmount { get; set; }
        public string TxnSysId { get; set; }

        public List<TmsContribution> GeTmsContributionData(string assortedCode)
        {
            OracleConnection oracleConnection = new OracleConnection(myCode.Globals._conStringOra);
            string strSql = "SELECT * FROM TMS.VW_TMS_FIX_CONTRIBUTION WHERE ASSORTED_CODE = '" + assortedCode + "'";
            OracleDataAdapter adpOracleDataAdapter = new OracleDataAdapter(strSql, oracleConnection);
            DataTable tblOraTable = new DataTable();
            List<TmsContribution> TmsContributions = new List<TmsContribution>();
            TmsContribution TmsContribution;

            adpOracleDataAdapter.Fill(tblOraTable);

            for (int i = 0; i < tblOraTable.Rows.Count; i++)
            {
                TmsContribution = new TmsContribution();
                TmsContribution.AssortedCode = tblOraTable.Rows[i]["ASSORTED_CODE"].ToString();
                TmsContribution.OrderNo = tblOraTable.Rows[i]["ORDER_NO"].ToString();
                TmsContribution.ChargeCode = tblOraTable.Rows[i]["CHARGE_CODE"].ToString();
                TmsContribution.ChargeName = tblOraTable.Rows[i]["CHARGE_CATEGORY_NAME"].ToString();
                TmsContribution.Rate = Convert.ToDecimal(tblOraTable.Rows[i]["RATE"]);
                TmsContribution.Amount = Convert.ToDecimal(tblOraTable.Rows[i]["AMOUNT"]);
                TmsContribution.PreviousAmount = Convert.ToDecimal(tblOraTable.Rows[i]["PREV_AMOUNT"]);
                TmsContribution.DifferAmount = TmsContribution.Amount - TmsContribution.PreviousAmount;
                TmsContribution.TxnSysId = tblOraTable.Rows[i]["PREMIUM_SEQNO"].ToString();

                TmsContributions.Add(TmsContribution);
            }

            return TmsContributions;
        }

        public void CommitContributionData(string txnSysId, decimal amount)
        {
            OracleConnection oracleConnection = new OracleConnection(myCode.Globals._conStringOra);
            string strSql = "UPDATE INS_PREMIUM SET AMOUNT = " + amount + " WHERE PREMIUM_SEQNO ='" + txnSysId + "'";
            OracleCommand cmdOracleCommand = new OracleCommand(strSql, oracleConnection);

            oracleConnection.Open();
            cmdOracleCommand.ExecuteNonQuery();
            oracleConnection.Close();
        }
    }
}
