using CustomUtils;
using Dapper;
using DBManagemnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using XmlManagement;

namespace DBManagement
{
    /// <summary>
    /// Sql 정보와 데이터를 가지고 있는 객체 
    /// 이 객체로 프로그램 실행 데이터 가지게 한다. 
    /// 로그 박스 
    /// </summary>
    public abstract class SqlResultData
    {
        #region Variable List
        internal Dictionary<string, string>? paramaterDic;
        internal XmlOptionData? sqldata;
        internal DBConnectionString? dBConnectionString;
        internal string? sqlStr;
        internal string? errMsg;

        DatabaseUtilities databaseUtilities = new DatabaseUtilities();

        #endregion

        #region Get/Set List
        public Dictionary<string, string>? ParamaterDic { get => paramaterDic; set => paramaterDic = value; }
        public XmlOptionData? Sqldata { get => sqldata; set => sqldata = value; }
        public DBConnectionString? DBConnectionString { get => dBConnectionString; set => dBConnectionString = value; }
        public string? ErrMsg { get => errMsg; set => errMsg = value; }
        public string? SqlStr { get => sqlStr; set => sqlStr = value; }

        #endregion

        #region Constructor List
        public SqlResultData(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString) 
        {
            this.paramaterDic = paramaterDic;
            this.sqldata = sqldata;
            this.dBConnectionString = dBConnectionString;
            this.errMsg = string.Empty;
        }
        #endregion

        #region Optional Sql Functions

        public void SqlVarFunction(XmlOptionSql item, ref string cquery)
        {
            /*
             * Step 1 : Option data 읽어서 분류
             * Step 2 : 변수 받아서 변수가 있다면 처리 
             * Step 3 : 
             */
            if (paramaterDic.ContainsKey(item.Key))
            {
                if (item.Sql != null || item.Type.Equals(CommonXml.Type.VAR))
                {
                    DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, true);
                }

                if (item.DataType == CommonXml.DataType._DateTime)
                {
                    cquery = cquery.Replace(@$"@{item.Key}", $@"'{paramaterDic[item.Key]}'");
                }
                else
                {
                    cquery = cquery.Replace(@$"@{item.Key}", $@"'%{paramaterDic[item.Key]}%'");
                }
                
            }
            //else
            //{
            //    cquery = cquery.Replace(@$"@{item.Key}", @$"'%{item.Default}%'");
            //}
        }

        #endregion

        public virtual object ExcuteSql()
        {
            try
            {
                string cquery = sqldata.Sql;

                //OptionalSql 추가 Logic
                foreach (XmlOptionSql item in sqldata.OptionSqls)
                {
                    if (item.Type == CommonXml.Type.IF)
                    {
                        if (item.Condition == CommonXml.Condition.not_equal)
                        {
                            if (paramaterDic[item.Key] != item.Default)
                            {
                                SqlVarFunction(item, ref cquery);
                                continue;
                            }
                        }
                        else if (item.Condition == CommonXml.Condition.equal)
                        {
                            if (paramaterDic[item.Key] == item.Default)
                            {
                                SqlVarFunction(item, ref cquery);
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
                                DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, true);
                                cquery = cquery.Replace($"@{item.Key}", string.Concat("U"));
                            }   // 실트레이
                            else if (paramaterDic[SqlVal.CSTSTAT] == "2")
                            {
                                DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, true);
                                cquery = cquery.Replace($"@{item.Key}", string.Concat("E"));
                            } // 공트레이
                            else
                            {
                                DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, false);
                            }
                            continue;
                        }
                    }

                    if (item.Type == CommonXml.Type.VAR)
                    {
                        if (paramaterDic[item.Key] != item.Default)
                        {
                            SqlVarFunction(item, ref cquery);
                            continue;
                        }
                    }

                    if (item.Type == CommonXml.Type.MOVINGSTATE)
                    {

                        if (paramaterDic[SqlVal.MOVINGSTATE] != item.Default)
                        {
                            DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, true);
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "1") cquery = cquery.Replace($"@{item.Key}", string.Concat("DELETE")); ;    // 실트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "2") cquery = cquery.Replace($"@{item.Key}", string.Concat("NORMAL_END")); ;    // 공트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "3") cquery = cquery.Replace($"@{item.Key}", string.Concat("ABNORMAL_END")); ;    // 실트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "4") cquery = cquery.Replace($"@{item.Key}", string.Concat("RECEIVE")); ;    // 공트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "5") cquery = cquery.Replace($"@{item.Key}", string.Concat("MOVING")); ;    // 실트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "6") cquery = cquery.Replace($"@{item.Key}", string.Concat("SEND")); ;    // 공트레이
                            continue;
                        }
                    }

                    if (item.Type == CommonXml.Type.NONE)
                    {
                        DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, true);
                        continue;
                    }
                    DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, false);
                }
                sqlStr = cquery;
                return databaseUtilities.GetSqlData(cquery, dBConnectionString, ref errMsg);

                //DataGridView_Coloring(dataGridView, sqldata);
            }
            catch (Exception ex)
            {
                errMsg = $"{ex.Message} : {this.GetType().Name}";
                return null;
            }
        }

        public virtual object ExcuteSql(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString)
        {
            this.dBConnectionString = dBConnectionString;
            this.paramaterDic = paramaterDic;
            this.sqldata = sqldata;

            try
            {
                string cquery = sqldata.Sql;

                //OptionalSql 추가 Logic
                foreach (XmlOptionSql item in sqldata.OptionSqls)
                {
                    if (!paramaterDic.ContainsKey(item.Key))
                    {
                        continue;
                    }


                    if (item.Type == CommonXml.Type.IF)
                    {
                        if (item.Condition == CommonXml.Condition.not_equal)
                        {
                            if (paramaterDic[item.Key] != item.Default)
                            {
                                SqlVarFunction(item, ref cquery);
                                continue;
                            }
                        }
                        else if (item.Condition == CommonXml.Condition.equal)
                        {
                            if (paramaterDic[item.Key] == item.Default)
                            {
                                SqlVarFunction(item, ref cquery);
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
                                DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, true);
                                cquery = cquery.Replace($"@{item.Key}", string.Concat("U"));
                            }   // 실트레이
                            else if (paramaterDic[SqlVal.CSTSTAT] == "2")
                            {
                                DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, true);
                                cquery = cquery.Replace($"@{item.Key}", string.Concat("E"));
                            } // 공트레이
                            else
                            {
                                DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, false);
                            }
                            continue;
                        }
                    }

                    if (item.Type == CommonXml.Type.VAR)
                    {
                        if (paramaterDic[item.Key] != item.Default)
                        {
                            SqlVarFunction(item, ref cquery);
                            continue;
                        }
                    }

                    if (item.Type == CommonXml.Type.MOVINGSTATE)
                    {

                        if (paramaterDic[SqlVal.MOVINGSTATE] != item.Default)
                        {
                            DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, true);
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "1") cquery = cquery.Replace($"@{item.Key}", string.Concat("DELETE")); ;    // 실트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "2") cquery = cquery.Replace($"@{item.Key}", string.Concat("NORMAL_END")); ;    // 공트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "3") cquery = cquery.Replace($"@{item.Key}", string.Concat("ABNORMAL_END")); ;    // 실트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "4") cquery = cquery.Replace($"@{item.Key}", string.Concat("RECEIVE")); ;    // 공트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "5") cquery = cquery.Replace($"@{item.Key}", string.Concat("MOVING")); ;    // 실트레이
                            if (paramaterDic[SqlVal.MOVINGSTATE] == "6") cquery = cquery.Replace($"@{item.Key}", string.Concat("SEND")); ;    // 공트레이
                            continue;
                        }
                    }

                    if (item.Type == CommonXml.Type.NONE)
                    {
                        DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, true);
                        continue;
                    }
                    DatabaseUtilities.AddToOptionalSqlSyntax(ref cquery, item, false);
                }
                sqlStr = cquery;
                errMsg = string.Empty;
                return databaseUtilities.GetSqlData(cquery, dBConnectionString, ref errMsg);

                //DataGridView_Coloring(dataGridView, sqldata);
            }
            catch (Exception ex)
            {
                errMsg = $"{ex.Message} : {this.GetType().Name}";
                return null;
            }
        }
    }
}
