using CustomUtils;
using Dapper;
using DBManagemnet;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlManagement;

namespace DBManagement
{
    public class DatabaseUtilities
    {
        public Dictionary<string, DBConnectionString> MakeConnectionStringLIst(string sqlXmlPath)
        {
            XmlDocument xdoc = new XmlDocument();
            Dictionary<string, DBConnectionString> result = new Dictionary<string, DBConnectionString>();
            // 특정 노드들을 필터링
            xdoc.Load(sqlXmlPath);
            XmlNode nodes = xdoc.ChildNodes[1];

            foreach (XmlNode node in nodes)
            {
                result.Add(node.Name, new DBConnectionString(
                    node["Server"].InnerText,
                    node["Database"].InnerText,
                    node["DatabaseProvider"].InnerText,
                    node["UserId"].InnerText,
                    node["Password"].InnerText,
                    node["AreaID"].InnerText,
                    node["PlantID"].InnerText,
                    (node["TrayID"].InnerText.Split(',')[0], node["TrayID"].InnerText.Split(',')[1]),
                    node["SystemTypeCode"].InnerText)
                    );
            }
            return result;
        }

        public static void AddToOptionalSqlSyntax(ref string cquery, XmlOptionSql sqldata, bool isAdd)
        {
            if (isAdd)
            {
                if (cquery.Contains(@$"+{sqldata.Name}"))
                {
                    cquery = cquery.Replace(@$"+{sqldata.Name}", sqldata.Sql);
                }
                else
                {
                    cquery += string.Concat("\n", sqldata.Sql);
                }
            }
            else
            {
                if (cquery.Contains(@$"+{sqldata.Name}"))
                {
                    cquery = cquery.Replace(@$"+{sqldata.Name}", string.Empty);
                }
            }
        }

        public Dictionary<string, DBConnectionString> GetConfigList()
        {
            return MakeConnectionStringLIst(@"./DBConnectionString.xml");
        }

        public object GetSqlData(string cquery, DBConnectionString dBConnectionString, ref string errMsg)
        {
            if (dBConnectionString.DatabaseProvider.ToString() == "ORACLE")
            {
                if (dBConnectionString.UserId == "AKACHISCHEMA")
                {
                    cquery = "SELECT * FROM CARRIER";
                }
                return ShowSqltoDGV_ORACLE(cquery, dBConnectionString.ConnectionString(), ref errMsg);
            }
            else if (dBConnectionString.DatabaseProvider.ToString() == "MSSQL")
            {
                return ShowSqltoDGV_MSSQL(cquery, dBConnectionString.MssqlConnectionString(), ref errMsg);
            }
            else
            {
                errMsg = "Check DatabaseProvier into DBConnectionString.xml file ";
                return null;
            }
        }

        public object GetSqlData(string cquery, DynamicParameters parameters, DBConnectionString dBConnectionString, ref string errMsg)
        {
            if (dBConnectionString.DatabaseProvider.ToString() == "ORACLE")
            {
                if (dBConnectionString.UserId == "AKACHISCHEMA")
                {
                    cquery = "SELECT * FROM CARRIER";
                }
                return ShowSqltoDGV_ORACLE(cquery, parameters, dBConnectionString.ConnectionString(), ref errMsg);
            }
            else if (dBConnectionString.DatabaseProvider.ToString() == "MSSQL")
            {
                return ShowSqltoDGV_MSSQL(cquery, parameters, dBConnectionString.MssqlConnectionString(), ref errMsg);
            }
            else
            {
                errMsg = "Check DatabaseProvier into DBConnectionString.xml file ";
                return null;
            }
        }

        private object ShowSqltoDGV_ORACLE(string cquery, DynamicParameters parameters, string connectionString, ref string errMsg)
        {
            try
            {
                using (var connection = new OracleConnection(connectionString))
                {
                    if (parameters != null)
                    {
                        return connection.Query(cquery, parameters).ToList();
                        //main.AppendLog(cquery, parameters);
                    }
                    else
                    {
                        return connection.Query(cquery).ToList();
                        //main.AppendLog(cquery);
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }
        private object ShowSqltoDGV_ORACLE(string cquery, string connectionString, ref string errMsg)
        {
            try
            {
                using (var connection = new OracleConnection(connectionString))
                {
                    return connection.Query(cquery).ToList();
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                throw new Exception(errMsg, ex);
            }
        }

        private object ShowSqltoDGV_MSSQL(string cquery, string connectionString, ref string errMsg)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                     return connection.Query(cquery).ToList();
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                throw new Exception(errMsg, ex);
            }
        }
        private object ShowSqltoDGV_MSSQL(string cquery, DynamicParameters parameters, string connectionString, ref string errMsg)
        {
            try
            {

                using (var connection = new SqlConnection(connectionString))
                {
                    if (parameters != null)
                    {
                        
                        return connection.Query(cquery, parameters).ToList();
                        //main.AppendLog(cquery, parameters);
                    }
                    else
                    {
                        return connection.Query(cquery).ToList();
                        //main.AppendLog(cquery);
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }

        public class DatabaseConnectionTest
        {
            public bool TestConnection(string connectionString)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open(); // 데이터베이스 연결 시도
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            // 연결 상태 확인
                            Console.WriteLine("Connection successful.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Connection failed.");
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 연결 시도 중 오류 발생
                    Console.WriteLine($"Connection failed: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
