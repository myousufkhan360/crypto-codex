using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ddlAPI.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ddlAPI.DataLayers
{
    public class gridTravelDataLayer
    {
        //Get Coverage
        public List<TravelCoversSetup> getTravelCoversSetupByPlan(int _TravelPlanCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM vuTravelCoversSetup WHERE TravelPlanCode =" + _TravelPlanCode;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<TravelCoversSetup> _TravelCoversSetupList = new List<TravelCoversSetup>();
                TravelCoversSetup _TravelCoversSetup;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _TravelCoversSetup = new TravelCoversSetup();
                        _TravelCoversSetup.TravelPlanCode = Convert.ToInt32(_tbl.Rows[i]["TravelPlanCode"]);
                        _TravelCoversSetup.TravelPlanName = _tbl.Rows[i]["TravelPlanName"].ToString();
                        _TravelCoversSetup.TravelCoverCode = Convert.ToInt32(_tbl.Rows[i]["TravelCoverCode"]);
                        _TravelCoversSetup.TravelCoverName = _tbl.Rows[i]["TravelCoverName"].ToString();
                        _TravelCoversSetup.TravelCoverLimitText = _tbl.Rows[i]["TravelCoverLimitText"].ToString();
                        _TravelCoversSetupList.Add(_TravelCoversSetup);
                    }

                    return _TravelCoversSetupList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Get Travel Contribution Setup by Category/Plan Code
        public List<TravelContributionSetup> getTravelContributionSetup(int _TravelCategoryCode, int _TravelPlanCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM vuTravelContributionSetup tcs WHERE tcs.TravelCategoryCode = " + _TravelCategoryCode + " AND tcs.TravelPlanCode =" + _TravelPlanCode + " ORDER BY TravelContributionStpCode";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<TravelContributionSetup> _TravelContributionSetupList = new List<TravelContributionSetup>();
                TravelContributionSetup _TravelContributionSetup;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _TravelContributionSetup = new TravelContributionSetup();
                        _TravelContributionSetup.TravelCategoryCode = Convert.ToInt32(_tbl.Rows[i]["TravelCategoryCode"]);
                        _TravelContributionSetup.TravelCategoryName = _tbl.Rows[i]["TravelCategoryName"].ToString();
                        _TravelContributionSetup.TravelPlanCode = Convert.ToInt32(_tbl.Rows[i]["TravelPlanCode"]);
                        _TravelContributionSetup.TravelPlanName = _tbl.Rows[i]["TravelPlanName"].ToString();
                        _TravelContributionSetup.TravelTanureCode = Convert.ToInt32(_tbl.Rows[i]["TravelTenureCode"]);
                        _TravelContributionSetup.TravelTanureText = _tbl.Rows[i]["TravelTenureText"].ToString();
                        _TravelContributionSetup.TravelCoverageTypeCode = Convert.ToInt32(_tbl.Rows[i]["TravelCoverageTypeCode"]);
                        _TravelContributionSetup.TravelCoverageTypeName = _tbl.Rows[i]["TravelCoverageTypeName"].ToString();
                        _TravelContributionSetup.TravelContribution = Convert.ToDecimal(_tbl.Rows[i]["TravelContribution"]); ;
                        _TravelContributionSetupList.Add(_TravelContributionSetup);
                    }

                    return _TravelContributionSetupList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}