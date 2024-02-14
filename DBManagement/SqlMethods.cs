using DBManagemnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlManagement;

namespace DBManagement
{
    public interface SqlMethods 
    {
        object GetSqlData(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString, ref string errMsg);
    }
}
