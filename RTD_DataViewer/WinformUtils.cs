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
using System.ComponentModel;
using System.Windows.Forms;
using SortOrder = System.Windows.Forms.SortOrder;
using System.Data;

namespace RTD_DataViewer
{
    //도구는 데이터를 가지고 있지 않는다. 
    //데이터는 사용자가 가지고 있다.
    internal class WinformUtils
    {
        MainViewer main;

        public WinformUtils()
        {
        }

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

        public static void AddToOptionalSqlSyntax(ref string cquery, XmlOptionSql sqldata)
        {
            cquery += string.Concat("\n", sqldata.Sql);
        }

        public static void AddToOptionalSqlSyntax(ref string cquery, XmlOptionData sqldata, int seq)
        {
            cquery += string.Concat("\n", sqldata.OptionSqls[seq].Sql);
        }

        public static void AddToOptionalSqlSyntax(ref string cquery, XmlOptionData sqldata, int seq, string parameterName,  string parameterValue)
        {
            cquery += string.Concat("\n", sqldata.OptionSqls[seq].Sql.Replace(parameterName, parameterValue));
        }

        public static void AddToOptionalSqlSyntax(ref string cquery, XmlOptionData sqldata, int seq, Dictionary<string, string> parameters)
        {
            foreach (KeyValuePair<string, string> item in parameters)
            {
                sqldata.OptionSqls[seq].Sql.Replace(item.Key, item.Value);
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


        public void ExcuteSql(Dictionary<string,string> paramaterDic, DataGridView dataGridView, DBConnectionString dBConnectionString, string mathodName)
        {
            try
            {
                XmlOptionData sqldata = main.sqlList[mathodName];
                string cquery = sqldata.Sql;
                DynamicParameters parameters = new DynamicParameters();

                //추가 변수에 관한 로직 추가 필요.
                foreach (KeyValuePair<string, AdditionalVariable> item in sqldata.AdditionalVarDic)
                {
                    if (paramaterDic.ContainsKey(item.Key))
                    {
                        //CustomUtills.CustomUtill.RexReplace(ref cquery, @$"@{item.Key}", paramaterDic[item.Key]);
                        cquery = cquery.Replace(@$"@{item.Key}", paramaterDic[item.Key]);
                    }
                    else
                    {
                        cquery = cquery.Replace(@$"@{item.Key}", @$"'%{item.Value.DefaultValue}%'");
                    }
                }

                //parameters.Add(SqlVal.StartDate, paramaterDic[SqlVal.StartDate]);
                //parameters.Add(SqlVal.EndDate, paramaterDic[SqlVal.EndDate]);

                foreach (XmlOptionSql item in sqldata.OptionSqls)
                {
                    if (item.Type == CommonXml.Type.If)
                    {
                        if (item.Condition == CommonXml.Condition.not_equal)
                        {
                            if (paramaterDic[item.Key] != item.Default)
                            {
                                AddToOptionalSqlSyntax(ref cquery, item);
                                parameters.Add($"@{item.Key}", string.Concat("%", paramaterDic[item.Key], "%"));
                                //cquery += " AND H.CSTID LIKE '%" + txtCSTID.Text + "%'";
                            }
                        }
                        else if (item.Condition == CommonXml.Condition.equal)
                        {
                            if (paramaterDic[item.Key] == item.Default)
                            {
                                AddToOptionalSqlSyntax(ref cquery, item);
                                parameters.Add($"@{item.Key}", string.Concat("%", paramaterDic[item.Key], "%"));
                                //cquery += " AND H.CSTID LIKE '%" + txtCSTID.Text + "%'";
                            }
                        }
                    }

                    if (item.Type == CommonXml.Type.cststat)
                    {
                        if (paramaterDic[SqlVal.CstStat] != item.Default)
                        {
                            AddToOptionalSqlSyntax(ref cquery, item);
                            if (paramaterDic[SqlVal.CstStat] == "1") parameters.Add($"@{item.Key}", string.Concat("U")); ;    // 실트레이
                            if (paramaterDic[SqlVal.CstStat] == "2") parameters.Add($"@{item.Key}", string.Concat("E")); ;    // 공트레이
                        }
                    }

                    if (item.Type == CommonXml.Type.none)
                    {
                        AddToOptionalSqlSyntax(ref cquery, item);
                    }
                }
                ShowSqltoDGV(dataGridView, cquery, parameters, dBConnectionString);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : SearchTransportReq");
            }
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
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                dataGridView.RowPostPaint -= DataGridView_RowPostPaint;
                using (var connection = new OracleConnection(connectionString))
                {
                    if (parameters != null)
                    {
                        dataGridView.DataSource = connection.Query(cquery, parameters).ToList();
                        main.AppendLog(cquery, parameters);
                    }
                    else
                    {
                        dataGridView.DataSource = connection.Query(cquery).ToList();
                        main.AppendLog(cquery);
                    }
                }
                dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gray;

                dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView.AutoResizeColumns();

                dataGridView.RowPostPaint += DataGridView_RowPostPaint;
                main.AppendLog(cquery, parameters);
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
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                dataGridView.RowPostPaint -= DataGridView_RowPostPaint;

                using (var connection = new SqlConnection(connectionString))
                {
                    if (parameters != null)
                    {
                        dataGridView.DataSource = connection.Query(cquery, parameters).ToList();
                        main.AppendLog(cquery, parameters);
                    }
                    else
                    {
                        dataGridView.DataSource = connection.Query(cquery).ToList();
                        main.AppendLog(cquery);
                    }
                }
                dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gray;

                dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView.AutoResizeColumns();

                dataGridView.RowPostPaint += DataGridView_RowPostPaint;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_MouseMove(object? sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            //var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 1).ToString();

            //var centerFormat = new StringFormat()
            //{
            //    // 오른쪽 정렬을 위해 Alignment를 Far로 설정
            //    Alignment = StringAlignment.Far,
            //    LineAlignment = StringAlignment.Center
            //};

            //var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            //e.Graphics.DrawString(rowIdx, grid.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
