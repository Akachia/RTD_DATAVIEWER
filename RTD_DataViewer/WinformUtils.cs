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
using System.Collections.ObjectModel;
using System.Reflection;
using DBManagement;
using UserWinfromControl;
using CustomUtills;

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
            return null;// new DatabaseUtills().MakeConnectionStringLIst(@"./DBConnectionString.xml");
        }

        public Dictionary<string, string> MakeParamaterDic(List<Control> variableControls)
        {
            Dictionary<string, string> paramaterDic = new Dictionary<string, string>();
            try
            {
                foreach (var item in variableControls)
                {
                    if (item is UWC_LabelAndDateTimePicker)
                    {
                        UWC_LabelAndDateTimePicker datePicker = item as UWC_LabelAndDateTimePicker;
                        paramaterDic.Add(datePicker.VariableName, CustomUtill.StringToDBStr(datePicker.MakeNowDateStringAndSetting()));
                    }

                    if (item is UWC_LabelAndTextBox)
                    {
                        UWC_LabelAndTextBox text = item as UWC_LabelAndTextBox;

                        if (text.VariableName == "CSTID")
                        {
                            string carrierIds = text.TextToCarrierListByRex(text.Tb_Text);
                            paramaterDic.Add(text.VariableName, carrierIds);
                            text.Tb_Text = carrierIds;
                        }
                        else 
                        {
                            paramaterDic.Add(text.VariableName, CustomUtill.LikeStringMaskingByBoth(text.Tb_Text));
                        }
                    }

                    if (item is UWC_ComboBox)
                    {
                        UWC_ComboBox comboBox = item as UWC_ComboBox;

                        if (comboBox.ComboBoxSelectedIndex > 0)
                        {
                            paramaterDic.Add(comboBox.VariableName, comboBox.ComboBoxSelectedItem);
                        }
                        else
                        {
                            paramaterDic.Add(comboBox.VariableName, $"");
                        }
                    }
                }

                return paramaterDic;
            }
            catch (Exception)
            {
                return null;
            }
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

                //OptionalSql 추가 Logic
                foreach (XmlOptionSql item in sqldata.OptionSqls)
                {
                    if (item.Type == CommonXml.Type.IF)
                    {
                        if (item.Condition == CommonXml.Condition.not_equal)
                        {
                            if (paramaterDic[item.Key] != item.Default)
                            {
                                AddToOptionalSqlSyntax(ref cquery, item, true);
                                parameters.Add($"@{item.Key}", string.Concat("%", paramaterDic[item.Key], "%"));
                                //cquery += " AND H.CSTID LIKE '%" + txtCSTID.Text + "%'";
                                continue;
                            }
                        }
                        else if (item.Condition == CommonXml.Condition.equal)
                        {
                            if (paramaterDic[item.Key] == item.Default)
                            {
                                AddToOptionalSqlSyntax(ref cquery, item, true);
                                parameters.Add($"@{item.Key}", string.Concat("%", paramaterDic[item.Key], "%"));
                                //cquery += " AND H.CSTID LIKE '%" + txtCSTID.Text + "%'";
                                continue;
                            }
                        }
                    }

                    if (item.Type == CommonXml.Type.CSTSTAT)
                    {
                        if (paramaterDic[SqlVal.CSTSTAT] != item.Default)
                        {
                            if (paramaterDic[SqlVal.CSTSTAT] == "1")
                            {
                                AddToOptionalSqlSyntax(ref cquery, item, true);
                                parameters.Add($"@{item.Key}", string.Concat("U"));
                            }   // 실트레이
                            else if (paramaterDic[SqlVal.CSTSTAT] == "2")
                            {
                                AddToOptionalSqlSyntax(ref cquery, item, true);
                                parameters.Add($"@{item.Key}", string.Concat("E")); 
                            } // 공트레이
                            else {
                                AddToOptionalSqlSyntax(ref cquery, item, false);
                            }
                            continue;
                        }
                    }

                    if (item.Type == CommonXml.Type.MOVINGSTATE)
                    {

                        if (paramaterDic[SqlVal.MOVINGSTATE] != item.Default)
                        {
                            AddToOptionalSqlSyntax(ref cquery, item, true);
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "1") parameters.Add($"@{item.Key}", string.Concat("DELETE")); ;    // 실트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "2") parameters.Add($"@{item.Key}", string.Concat("NORMAL_END")); ;    // 공트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "3") parameters.Add($"@{item.Key}", string.Concat("ABNORMAL_END")); ;    // 실트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "4") parameters.Add($"@{item.Key}", string.Concat("RECEIVE")); ;    // 공트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "5") parameters.Add($"@{item.Key}", string.Concat("MOVING")); ;    // 실트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "6") parameters.Add($"@{item.Key}", string.Concat("SEND")); ;    // 공트레이
                            continue;
                        }
                    }

                    if (item.Type == CommonXml.Type.NONE)
                    {
                        AddToOptionalSqlSyntax(ref cquery, item, true);
                        continue;
                    }
                    AddToOptionalSqlSyntax(ref cquery, item, false);
                }
                ShowSqltoDGV(dataGridView, cquery, parameters, dBConnectionString);

                DataGridView_Coloring(dataGridView, sqldata);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {mathodName}");
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
                string testcquery = "SELECT * FROM AKACHISCHEMA.CARRIER";

                dataGridView.DataSource = null;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                dataGridView.RowPostPaint -= DataGridView_RowPostPaint;
                using (var connection = new OracleConnection(connectionString))
                {
                    if (parameters != null)
                    {
                        dataGridView.DataSource = connection.Query(testcquery, parameters).ToList();
                        main.AppendLog(cquery, parameters);
                    }
                    else
                    {
                        dataGridView.DataSource = connection.Query(testcquery).ToList();
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

        public void DataGridView_Coloring(DataGridView dataGridView, XmlOptionData sqldata)
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.AutoResizeColumns();
            try
            {
                int rowCount = dataGridView.Rows.Count;
                if (sqldata.ColoringDic.Count > 0)
                {
                    foreach (string item in sqldata.ColoringDic.Keys)
                    {
                        if (ColumnExists(dataGridView, item))
                        {
                            Coloring coloring = sqldata.ColoringDic[item];
                            if (coloring.IsColoringColumn)
                            {
                                foreach (DataGridViewRow row in dataGridView.Rows)
                                {
                                    row.Cells[item].Style.BackColor = Color.FromArgb(coloring.Red, coloring.Green, coloring.Blue); // 색상 변경
                                }
                            }

                            for (int i = 0; i < rowCount; i++)
                            {

                                string value = dataGridView.Rows[i].Cells[item].Value.ToString();
                                if (value != string.Empty)
                                {
                                    if (coloring.IsTimeCompare)
                                    {
                                        //Dictionary<string, ColoringValue> coloringValues = coloring.ColoringVarDic;
                                        //if (coloringValues.ContainsKey(value))
                                        //{
                                        //    if (value != string.Empty)
                                        //    {
                                        //        DateTime dateTime = DateTime.Parse(value);

                                        //        if (dateTime < date1)
                                        //        {
                                        //            //FFD4D4
                                        //            dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 212, 212);
                                        //        }
                                        //    }

                                        //}
                                    }
                                    else
                                    {
                                        Dictionary<string, ColoringValue> coloringValues = coloring.ColoringVarDic;
                                        if (coloringValues.ContainsKey(value))
                                        {
                                            ColoringValue coloringValue = sqldata.ColoringDic[item].ColoringVarDic[value];
                                            bool IsColoringRow = coloringValue.IsColoringRow;

                                            if (IsColoringRow)
                                            {
                                                dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(coloringValue.Red, coloringValue.Green, coloringValue.Blue);
                                            }
                                            else
                                            {
                                                dataGridView.Rows[i].Cells[item].Style.BackColor = Color.FromArgb(coloringValue.Red, coloringValue.Green, coloringValue.Blue);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool ColumnExists(DataGridView dgv, string columnName)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Name == columnName)
                    return true;
            }
            return false;
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

        public void SearchCstInfo(DataGridView dataGridView, string cstId, ref string errMsg)
        {
            try
            {
                XmlOptionData sqldata = main.sqlList["SearchCstInfo2"];
                string cquery = sqldata.Sql;
                string plantId = main.correntConnectionStringSetting.PlantID;
                string systemTypeCode = main.correntConnectionStringSetting.SystemTypeCode;

                DynamicParameters parameters = new DynamicParameters();
                if (cstId == string.Empty)
                {
                    MessageBox.Show("CSTID를 입력해주세요.");
                    return;
                }
                parameters.Add("@CSTID", cstId);
                List<Carrier> carriers;

                if (main.correntConnectionStringSetting.DatabaseProvider == "ORACLE")
                {

                    string testcquery = "SELECT * FROM AKACHISCHEMA.CARRIER";

                    dataGridView.DataSource = null;
                    dataGridView.Rows.Clear();
                    dataGridView.Columns.Clear();
                    // dgv_CstInfo.DgvData.RowPostPaint -= DataGridView_RowPostPaint;
                    using (var connection = new OracleConnection(main.correntConnectionStringSetting.ConnectionString()))
                    {
                        if (parameters != null)
                        {
                            dataGridView.DataSource = connection.Query(testcquery, parameters).ToList();
                            main.AppendLog(cquery, parameters);
                        }
                        else
                        {
                            dataGridView.DataSource = connection.Query(testcquery).ToList();
                            main.AppendLog(cquery);
                        }
                    }
                    dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gray;

                    dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    dataGridView.AutoResizeColumns();

                    //    dgv_CstInfo.DgvData.RowPostPaint += DataGridView_RowPostPaint;
                    foreach (DataGridViewRow item in dataGridView.Rows)
                    {
                        item.DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
                    }
                    return;
                }

                using (var connection = new SqlConnection(main.correntConnectionStringSetting.MssqlConnectionString()))
                {
                    carriers = connection.Query<Carrier>(cquery, parameters).ToList();
                    dataGridView.DataSource = carriers;
                }
                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    var prop = typeof(Carrier).GetProperty(col.DataPropertyName);
                    var displayName = prop?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                    if (displayName != null)
                    {
                        col.HeaderText = displayName;
                    }
                }
                main.AppendLog(cquery, parameters);
                dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView.AutoResizeColumns();

                if (carriers != null)
                {
                    string mismatchMessage = MakeCSTErrMsg(carriers);
                    errMsg = mismatchMessage;
                    if (mismatchMessage == string.Empty)
                    {
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            item.DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
                        }
                    }
                    else
                    {
                        int rowCount = 0;
                        //lb_MismatchMessage.BackColor = Color.FromArgb(255, 155, 155);
                        foreach (DataGridViewRow item in dataGridView.Rows)
                        {
                            if (rowCount == 0)
                            {
                                item.DefaultCellStyle.BackColor = Color.FromArgb(179, 255, 174);
                                rowCount++;
                            }
                            else
                            {
                                item.DefaultCellStyle.BackColor = Color.FromArgb(255, 214, 165);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string MakeCSTErrMsg(List<Carrier> carriers)
        {
            /*
             * 1. 위 아래 데이터가 안맞을 경우 RouteID, WIPSTAT, SpclFlag, LotType, DayGrLotID, FormSpclGrID, PROCID
             * 2. DFCT_LIMIT_OVER_FLAG = Y
             * 3. SCRP_TRAY_FLAG = Y
             * 4. SMPL_ISS_TYPE_CODE = Y
             */
            string routid = ""; string dfct = "F"; string scrp = "N"; string sltc = "N";
            if (carriers.Count != 0)
            {
                dfct = carriers[0].DFCT_LIMIT_OVER_FLAG;
                routid = carriers[0].ROUTID;
                scrp = carriers[0].SCRP_TRAY_FLAG;
                sltc = carriers[0].SMPL_ISS_TYPE_CODE;

                if (carriers.Count == 2)
                {
                    //--------------------------------------------------------------------------------------------------------------------------------------------------
                    if (carriers[0].CSTSTAT != carriers[1].CSTSTAT)
                    {
                        return CSTErrMsg.typeErr + "(실,공 다름)";
                    }
                    if (carriers[0].TRAY_TYPE_CODE != carriers[1].TRAY_TYPE_CODE) // cststat, 트레이 타입
                    {
                        return CSTErrMsg.typeErr + "(트레이 타입 다름)";
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------------
                    if (carriers[0].DAY_GR_LOTID != carriers[1].DAY_GR_LOTID)
                    {
                        return CSTErrMsg.upDownErr + "(조립 LOT ID 다름)";
                    }
                    if (carriers[0].ROUTID != carriers[1].ROUTID)
                    {
                        return CSTErrMsg.upDownErr + "(RoutId 다름)";
                    }
                    if (carriers[0].PROCID != carriers[1].PROCID)
                    {
                        return CSTErrMsg.upDownErr + "(PROCID 다름)";
                    }
                    if (carriers[0].SPCL_FLAG != carriers[1].SPCL_FLAG)
                    {
                        return CSTErrMsg.upDownErr + "(스페셜 타입 다름)";
                    }
                    if (carriers[0].LOTTYPE != carriers[1].LOTTYPE)
                    {
                        return CSTErrMsg.upDownErr + "(Lot 타입 다름)";
                    }
                    if (carriers[0].WIPSTAT != carriers[1].WIPSTAT)
                    {
                        return CSTErrMsg.upDownErr + "(Lot 상태 다름)";
                    }
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------------
                if (carriers[0].SPCL_FLAG == "Y")
                {
                    if (carriers.Count == 2)
                    {
                        if (carriers[0].DAY_GR_LOTID != carriers[1].DAY_GR_LOTID ||
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
                if (sltc == "Y")
                {
                    return CSTErrMsg.smplMsg;
                }
            }
            return string.Empty;
        }

        public SqlResultData ShowDgv(string methodName, DataGridView dataGridView, SqlResultData sqlResultData, Dictionary<string, string> paramaterDic)
        {
            try
            {

                if (sqlResultData == null)
                {
                    sqlResultData = new DefaultSqlData(paramaterDic, main.sqlList[methodName], main.correntConnectionStringSetting);
                    dataGridView.DataSource = sqlResultData.ExcuteSql();
                }
                else
                {
                    dataGridView.DataSource = sqlResultData.ExcuteSql(paramaterDic, main.sqlList[methodName], main.correntConnectionStringSetting);
                }

                if (sqlResultData.ErrMsg == string.Empty)
                {
                    main.AppendLog(sqlResultData.SqlStr);
                    new WinformUtils().DataGridView_Coloring(dataGridView, main.sqlList[methodName]);
                }
                else
                {
                    MessageBox.Show($"{sqlResultData.ErrMsg} : {methodName}");
                }

                return sqlResultData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} : {methodName}");
                return null;
            }
        }
    }
}
