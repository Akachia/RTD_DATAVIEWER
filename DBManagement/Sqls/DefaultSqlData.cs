using DBManagemnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlManagement;

namespace DBManagement
{
    public class DefaultSqlData : SqlResultData
    {
        public Dictionary<string, string> paramaterDic;
        public XmlOptionData sqldata;
        public DBConnectionString dBConnectionString;
        string errMsg;
        string sqlStr;

        public DefaultSqlData(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString) 
            : base(paramaterDic, sqldata, dBConnectionString)
        {
            this.paramaterDic = paramaterDic;
            this.sqldata = sqldata;
            this.dBConnectionString = dBConnectionString;
            this.errMsg = string.Empty;
            
        }

        public override object ExcuteSql()
        {
            object sqlObject = base.ExcuteSql();
            sqlStr = base.sqlStr;
            return sqlObject;

        }
    }
}
