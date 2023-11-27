using CustomUtils;
using Dapper;
using DBManagemnet;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlManagement;

namespace RTD_DataViewer
{
    //도구는 데이터를 가지고 있지 않는다. 
    //데이터는 사용자가 가지고 있다.
    internal class WinformUtils
    {
        MainViewer main;

        public WinformUtils(MainViewer mainViewer)
        {
            main = mainViewer;
        }

        /// <summary>
        /// 케리어 테이블에 넣어서 사용하는 방안 고려 필요
        /// </summary>
        /// <param name="carriers"></param>
        /// <returns></returns>
        public static string MakeCSTErrMsg(List<Carrier> carriers)
        {
            string routid = ""; string dfct = "F"; string scrp = "N";
            if (carriers.Count != 0)
            {
                if (dfct != "Y") { dfct = carriers[0].DFCT_LIMIT_OVER_FLAG; }
                if (routid == "") { routid = carriers[0].ROUTID; }
                if (scrp != "N") { scrp = carriers[0].SCRP_TRAY_FLAG; }

                if (carriers.Count == 2)
                {
                    //--------------------------------------------------------------------------------------------------------------------------------------------------
                    if (carriers[0].CSTSTAT != carriers[1].CSTSTAT ||
                        carriers[0].TRAY_TYPE_CODE != carriers[1].TRAY_TYPE_CODE) // cststat, 트레이 타입
                    {
                        return CSTErrMsg.typeErr;
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------------
                    if (carriers[0].ASSY_LOTID != carriers[1].ASSY_LOTID ||
                        carriers[0].ROUTID != carriers[1].ROUTID ||
                        carriers[0].PROCID != carriers[1].PROCID ||
                        carriers[0].SPCL_FLAG != carriers[1].SPCL_FLAG ||
                        carriers[0].LOTTYPE != carriers[1].LOTTYPE)
                    { return CSTErrMsg.typeErr; }


                }
                //--------------------------------------------------------------------------------------------------------------------------------------------------
                if (carriers[0].SPCL_FLAG == "Y")
                {
                    if (carriers.Count == 2)
                    {
                        if (carriers[0].ASSY_LOTID != carriers[1].ASSY_LOTID ||
                    carriers[0].ROUTID != carriers[1].ROUTID ||
                    carriers[0].PROCID != carriers[1].PROCID ||
                    carriers[0].SPCL_FLAG != carriers[1].SPCL_FLAG ||
                    carriers[0].LOTTYPE != carriers[1].LOTTYPE ||
                    carriers[0].FORM_SPCL_GR_ID != carriers[1].FORM_SPCL_GR_ID
                    )
                        {
                            return CSTErrMsg.spcCstErr;
                        }
                    }
                }

                if (dfct == "Y")
                {
                    return CSTErrMsg.allCellErr;
                }
                if (scrp == "Y")
                {
                    return CSTErrMsg.crackTrayErr;
                }
            }
            return string.Empty;
        }


        public static void AddToOptionalSqlSyntax(ref string cquery, XmlOptionData sqldata, int seq)
        {
            cquery += string.Concat("\n", sqldata.optionSqls[seq].sql);
        }

        public static void AddToOptionalSqlSyntax(ref string cquery, XmlOptionData sqldata, int seq, string parameterName,  string parameterValue)
        {
            cquery += string.Concat("\n", sqldata.optionSqls[seq].sql.Replace(parameterName, parameterValue));
        }

        public static void AddToOptionalSqlSyntax(ref string cquery, XmlOptionData sqldata, int seq, Dictionary<string, string> parameters)
        {
            foreach (KeyValuePair<string, string> item in parameters)
            {
                sqldata.optionSqls[seq].sql.Replace(item.Key, item.Value);
            }

            cquery += string.Concat("\n", sqldata);
        }

        public Dictionary<string, DBConnectionString> GetConfigList()
        {
            return new XmlParser().MakeConnectionStringLIst(@"./DBConnectionString.xml");
        }

        public void ChangeDBConn( string dbString)
        {
            main.lb_ServerIP.Text = main.strs[dbString].Server.ToString();
            main.lb_ServerName.Text = main.strs[dbString].Database.ToString();
            main.cstr = main.strs[dbString].ConnectionString();
        }

        public void ShowSqltoDGV(DataGridView dataGridView, string cquery, DynamicParameters parameters, DBConnectionString dBConnectionString)
        {
            if (dBConnectionString.DatabaseProvider.ToString() == "ORACLE")
            {
                ShowSqltoDGV_ORACLE(dataGridView, cquery, parameters, dBConnectionString.ConnectionString());
            }
            else if (dBConnectionString.DatabaseProvider.ToString() == "MSSQL")
            {
                ShowSqltoDGV_MSSQL(dataGridView, cquery, parameters, dBConnectionString.MssqlConnectionString());
            }
            else { MessageBox.Show("Check DatabaseProvier into DBConnectionString.xml file "); }
        }

        private void ShowSqltoDGV_ORACLE(DataGridView dataGridView, string cquery, DynamicParameters parameters, string connectionString)
        {
            try
            {
                cquery = "SELECT * FROM AKACHISCHEMA.CARRIER";

                dataGridView.DataSource = null;
                //dgv_test.AutoGenerateColumns = false;
                //using (var connection = new OracleConnection(cstr))
                using (var connection = new OracleConnection(connectionString))
                {
                    

                    if (parameters != null)
                    {
                        dataGridView.DataSource = connection.Query(cquery, parameters).ToList();
                    }
                    else
                    {
                        dataGridView.DataSource = connection.Query(cquery).ToList();
                    }
                }
                dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowSqltoDGV_MSSQL(DataGridView dataGridView, string cquery, DynamicParameters parameters, string connectionString)
        {
            try
            {
                dataGridView.DataSource = null;
                //dgv_test.AutoGenerateColumns = false;
                //using (var connection = new OracleConnection(cstr))
                using (var connection = new SqlConnection(connectionString))
                {
                    if (parameters != null)
                    {
                        dataGridView.DataSource = connection.Query(cquery, parameters).ToList();
                    }
                    else
                    {
                        dataGridView.DataSource = connection.Query(cquery).ToList();
                    }
                }
                dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView.AutoResizeColumns();
                dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
