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
        public DefaultSqlData(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString) 
            : base(paramaterDic, sqldata, dBConnectionString)
        {
        }

        public override object ExcuteSql()
        {
            object sqlObject = base.ExcuteSql();
            return sqlObject;

        }
    }
}
