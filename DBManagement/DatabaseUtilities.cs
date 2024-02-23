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
                string testcquery = "SELECT * FROM AKACHISCHEMA.CARRIER";

                using (var connection = new OracleConnection(connectionString))
                {
                    if (parameters != null)
                    {
                        return connection.Query(testcquery, parameters).ToList();
                        //main.AppendLog(cquery, parameters);
                    }
                    else
                    {
                        return connection.Query(testcquery).ToList();
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
                string testcquery = "SELECT * FROM AKACHISCHEMA.CARRIER";
                using (var connection = new OracleConnection(connectionString))
                {
                    return connection.Query(testcquery).ToList();
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
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

        public object SearchCstInfo(string cstId, ref string errMsg, XmlOptionData sqldata, DBConnectionString dBConnectionString)
        {
            try
            {
                string cquery = sqldata.Sql;
               // string plantId = main.correntConnectionStringSetting.PlantID;
               // string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

                DynamicParameters parameters = new DynamicParameters();
                if (cstId == string.Empty)
                {
                    errMsg = "CSTID를 입력해주세요.";
                    return null;
                }
                parameters.Add("@CSTID", cstId);
                List<Carrier> carriers;

                if (dBConnectionString.DatabaseProvider == "ORACLE")
                { 
                    string testcquery = "SELECT * FROM AKACHISCHEMA.CARRIER";

                    // dgv_CstInfo.DgvData.RowPostPaint -= DataGridView_RowPostPaint;
                    using (var connection = new OracleConnection(dBConnectionString.ConnectionString()))
                    {
                        if (parameters != null)
                        {
                            return connection.Query(testcquery, parameters).ToList();
                            //main.AppendLog(cquery, parameters);
                        }
                        else
                        {
                            return connection.Query(testcquery).ToList();
                            //main.AppendLog(cquery);
                        }
                    }
                    //dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gray;

                    //dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    //dataGridView.AutoResizeColumns();

                    ////    dgv_CstInfo.DgvData.RowPostPaint += DataGridView_RowPostPaint;
                    //foreach (DataGridViewRow item in dataGridView.Rows)
                    //{
                    //    item.DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
                    //}
                    
                }
                return null;
                //using (var connection = new SqlConnection(dBConnectionString.MssqlConnectionString()))
                //{
                //    carriers = connection.Query<Carrier>(cquery, parameters).ToList();
                //    dataGridView.DataSource = carriers;
                //}
                //foreach (DataGridViewColumn col in dataGridView.Columns)
                //{
                //    var prop = typeof(Carrier).GetProperty(col.DataPropertyName);
                //    var displayName = prop?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                //    if (displayName != null)
                //    {
                //        col.HeaderText = displayName;
                //    }
                //}
                //main.AppendLog(cquery, parameters);
                //dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                //dataGridView.AutoResizeColumns();

                //if (carriers != null)
                //{
                //    string mismatchMessage = MakeCSTErrMsg(carriers);
                //    errMsg = mismatchMessage;
                //    if (mismatchMessage == string.Empty)
                //    {
                //        foreach (DataGridViewRow item in dataGridView.Rows)
                //        {
                //            item.DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
                //        }
                //    }
                //    else
                //    {
                //        int rowCount = 0;
                //        //lb_MismatchMessage.BackColor = Color.FromArgb(255, 155, 155);
                //        foreach (DataGridViewRow item in dataGridView.Rows)
                //        {
                //            if (rowCount == 0)
                //            {
                //                item.DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
                //                rowCount++;
                //            }
                //            else
                //            {
                //                item.DefaultCellStyle.BackColor = Color.FromArgb(255, 214, 165);
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
