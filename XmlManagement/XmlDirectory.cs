using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlManagement
{
    internal class XmlDirectory
    {
        internal XmlDirectory()
        {
            XmlDocument appXmlData = new XmlDocument();
            appXmlData.Load(AppConfigDirectory);
            XmlNode xml = appXmlData.ChildNodes[1];
            string mssqlPath = $@"{System.IO.Directory.GetCurrentDirectory()}\MssqlXmls";
            string oraclePath = $@"{System.IO.Directory.GetCurrentDirectory()}\OracleXmls";
            string dbConfigPath = $@"{System.IO.Directory.GetCurrentDirectory()}\DBConnectionString.xml";

            if (System.IO.Directory.Exists(mssqlPath))
            {
                MssqlSqlDirectory = mssqlPath;
            }
            else
            {
                MssqlSqlDirectory = xml["SqlDirectory"].InnerText;
            }

            if (System.IO.Directory.Exists(oraclePath))
            {
                OracleSqlDirectory = oraclePath;
            }
            else
            {
                OracleSqlDirectory = xml["SqlDirectory"].InnerText;
            }

            if (System.IO.File.Exists(dbConfigPath))
            {
                DatabaseDirectory = dbConfigPath;
            }
            else
            {
                DatabaseDirectory = xml["DBConDirectory"].InnerText;
            }

        }

        internal XmlDirectory(string appDirectory) {
            XmlDocument appXmlData = new XmlDocument();
            appXmlData.Load(appDirectory);

            XmlNode xml = appXmlData.ChildNodes[1];

            string mssqlPath = $@"{System.IO.Directory.GetCurrentDirectory()}\MssqlXmls";
            string oraclePath = $@"{System.IO.Directory.GetCurrentDirectory()}\OracleXmls";
            string dbConfigPath = $@"{System.IO.Directory.GetCurrentDirectory()}\DBConnectionString.xml";

            if (System.IO.Directory.Exists(mssqlPath))
            {
                MssqlSqlDirectory = mssqlPath;
            }
            else
            {
                MssqlSqlDirectory = xml["SqlDirectory"].InnerText;
            }

            if (System.IO.Directory.Exists(oraclePath))
            {
                OracleSqlDirectory = oraclePath;
            }
            else
            {
                OracleSqlDirectory = xml["SqlDirectory"].InnerText;
            }

            if (System.IO.Directory.Exists(dbConfigPath))
            {
                DatabaseDirectory = dbConfigPath;
            }
            else
            {
                DatabaseDirectory = xml["DBConDirectory"].InnerText;
            }
        }
        private string AppConfigDirectory = $@"./AppConfig.xml";
        internal string MssqlSqlDirectory { set; get; }
        internal string OracleSqlDirectory { set; get; }
        internal string DatabaseDirectory { set; get; }
    }
}
