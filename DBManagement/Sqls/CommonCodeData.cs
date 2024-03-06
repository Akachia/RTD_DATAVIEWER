using CustomUtils;
using Dapper;
using DBManagemnet;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XmlManagement;

namespace DBManagement
{
    public class CommonCodeData : SqlResultDataImpl
    {
        public CommonCodeData(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString)
            : base(paramaterDic, sqldata, dBConnectionString)
        {
        }

        public override object ExcuteSql()
        {
            CommonCodes getCommonCode = null;
            string cquery = base.MakeSql();
            base.sqlStr = cquery;
            try
            {
                using (var connection = new SqlConnection(dBConnectionString.MssqlConnectionString()))
                {
                     getCommonCode = new CommonCodes(connection.Query<CommonCode>(cquery).ToList());
                }
                return getCommonCode;
            }
            catch (Exception)
            {
                return getCommonCode;
            }
        }

        public override object ExcuteSql(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString)
        {
            base.paramaterDic = paramaterDic;
            base.sqldata = sqldata;
            base.dBConnectionString = dBConnectionString;

            return ExcuteSql();
        }
    }
}
