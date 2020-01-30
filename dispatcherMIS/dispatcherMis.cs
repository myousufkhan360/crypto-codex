using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dispatcherMIS
{
    class dispatcherMis
    {
        #region getting TM-FT-CR Data

        public void GetMisData()
        {
            try
            {
                OracleConnection conOra = new OracleConnection(Globals.conStringOra);
                string sqlStrOra = "SELECT * FROM VW_TM_FT_CR";
                OracleDataAdapter adpOra = new OracleDataAdapter(sqlStrOra, conOra);
                DataTable tblOra = new DataTable();
                adpOra.Fill(tblOra);

                using (SqlConnection sqlCon = new SqlConnection(Globals.conStringSql))
                {
                    sqlCon.Open();

                    string StrSql = "DELETE FROM tm_ft_cr";
                    SqlCommand cmdSql = new SqlCommand(StrSql, sqlCon);
                    cmdSql.ExecuteNonQuery();

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(Globals.conStringSql))
                    {
                        bulkCopy.DestinationTableName = "dbo.tm_ft_cr";
                        bulkCopy.WriteToServer(tblOra);
                    }

                    sqlCon.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion


    }

}
