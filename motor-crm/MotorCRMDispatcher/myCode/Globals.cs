using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorCRMDispatcher
{
    public static class Globals
    {
        //public static string _oraConStr = "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.10)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=TPL));uid=tms;pwd=tmsinstance_786;";
        public static string _oraConStr = "Data Source=192.168.1.10:1521/TPL;Persist Security Info=True;User ID=tms;Password=tmsinstance_786;";
        public static string _sqlConStr = "Data Source=d:\\MotorCRMDispatcher\\MotorCrmDb.db;Version=3;";

    }
}
