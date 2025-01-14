using CustomUtills;
using CustomUtils;
using Dapper;
using DBManagemnet;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    public abstract class SqlResultDataImpl : SqlResultData
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
        public SqlResultDataImpl(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString) 
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
            //전제 조건 : 여기서는 값이 없는 item이 없다.

            /*
             * Case 1 : 마스킹 해서 오는 경우 -> 해당 경우 삭제
             * Case 2 : 마스킹 안해서 오는 경우 -> 해당 케이스로 추가
             * Case 3 : 
             * 
             * Case 1 : like
             * Case 2 : =
             * Case 3 : IN
             */

            //SQL 값이 있을 경우
            if (item.Sql != null || item.Type.Equals(CommonXml.Type.VAR))
            {
                //+Option이 있다면
                if (cquery.Contains(@$"+{sqldata.Name}"))
                {
                    //+Option을 쿼리로 Replace
                    cquery = cquery.Replace(@$"+{sqldata.Name}", sqldata.Sql);
                }
                else
                {
                    cquery += string.Concat("\n", sqldata.Sql);
                }
            }
            //SQL 값이 없을 경우
            else
            {
                cquery = cquery.Replace(@$"@{item.Key}", $@"{paramaterDic[item.Key]}");
            }
        }

        public void SqlVarMappingFunction(XmlOptionSql item, ref string cquery, bool IsLineAdd)
        {
            //전제 조건 : 여기서는 값이 없는 item이 없다.

            /*
             * Case 1 : 마스킹 해서 오는 경우 -> 해당 경우 삭제
             * Case 2 : 마스킹 안해서 오는 경우 -> 해당 케이스로 추가
             * Case 3 : 
             * 
             * Case 0 : 본문에 있는 변수 일 경우
             * Case 1 : like
             * Case 2 : =
             * Case 3 : IN
             */
            if (!IsLineAdd)
            {// SQL에 +option은 있지만 사용하지 않는 포인트 일 경우 
                if (cquery.Contains(@$"+{item.Name}"))
                {
                    cquery = cquery.Replace(@$"+{item.Name}", string.Empty);
                    return;
                }
            }


            string dicKey = item.Key;
            string dicValue = paramaterDic[dicKey];
            string itemSql = item.Sql;

            //SQL 값이 있을 경우
            if (item.Sql != string.Empty)
            {
                //+Option이 있다면
                if (cquery.Contains(@$"+{item.Name}"))
                {
                    //+Option을 쿼리로 Replace
                    cquery = cquery.Replace(@$"+{item.Name}", itemSql);
                }
                else
                {
                    cquery += string.Concat("\n", itemSql);
                }

                if (CustomUtill.IsEqualQeury(itemSql))
                {
                    cquery = cquery.Replace(@$"@{dicKey}", $@"{CustomUtill.StringToDBStr(dicValue)}");
                }
                else if (CustomUtill.IsLikeQeury(itemSql))
                {
                    cquery = cquery.Replace(@$"@{dicKey}", $@"{CustomUtill.LikeStringMaskingByBoth(dicValue)}");
                }
                else if (CustomUtill.IsInQeury(itemSql))
                {
                    cquery = cquery.Replace(@$"@{dicKey}", $@"{CustomUtill.StringToDBStr(dicValue)}");
                }
                // 
                else
                {
                    cquery = cquery.Replace(@$"@{dicKey}", $@"{dicValue}");
                }
            }
            //SQL 값이 없을 경우
            else if(item.Sql == string.Empty)
            {
                /*
                 * SQL 값이 없을 경우는 본문에 변수가 있는 경우,
                 * 먼저 +option을 제거하고 왔기 때문에 본문 변수를 Replace 하는게 여기 block의 주 목적
                 * 본문 변수는 반드시 있다고 가정하기 때문에 항상 Replace 한다.
                 * 
                 * 보통 해당 Block의 사용은 이벤트로 인한 값으로 본다.
                 * 
                 * 
                 */
                

                //
                if (cquery.Contains(@$"@{dicKey}"))
                {
                    if (CustomUtill.IsMaskingValue(dicValue))
                    {
                        cquery = cquery.Replace(@$"@{item.Key}", $@"{CustomUtill.StringToDBStr(dicValue)}");
                    }
                    else
                    {
                        cquery = cquery.Replace(@$"@{item.Key}", $@"{CustomUtill.StringToDBStr(dicValue)}");
                    }
                    
                }
            }
        }


        #endregion

        internal string MakeSql()
        {
            string cquery = sqldata.Sql;

            //OptionalSql 추가 Logic
            foreach (XmlOptionSql item in sqldata.OptionSqls)
            {
                //paramaterDic에 실제 값이 없으면 Sql에 있는 +Option 삭제
                if (!paramaterDic.ContainsKey(item.Key))
                {
                    SqlVarMappingFunction(item, ref cquery, false);
                    continue;
                }

                string dicKey = item.Key;
                string dicValue = paramaterDic[dicKey];

                //해당 키 타입이 IF일 경우
                if (item.Type == CommonXml.Type.IF)
                {
                    if (item.Condition == CommonXml.Condition.not_equal)
                    {
                        //기본 값과 같지 않다면.
                        if (dicValue != item.Default)
                        {
                            SqlVarMappingFunction(item, ref cquery, true);
                            continue;
                        }
                        //기본 값과 같다면
                        else
                        {
                            SqlVarMappingFunction(item, ref cquery, false);
                            continue;
                        }
                    }
                    else if (item.Condition == CommonXml.Condition.equal)
                    {
                        if (dicValue == item.Default)
                        {
                            SqlVarMappingFunction(item, ref cquery, true);
                            continue;
                        }
                    }
                }

                if (item.Type == CommonXml.Type.CHECK)
                {
                    bool check = bool.Parse(dicValue);
                    if (check)
                    {
                        SqlVarMappingFunction(item, ref cquery, true);
                        continue;
                    }
                    else {
                        SqlVarMappingFunction(item, ref cquery, false);
                        continue;
                    }
                }

                if (item.Type == CommonXml.Type.VAR)
                {
                    if (dicValue != item.Default)
                    {
                        SqlVarMappingFunction(item, ref cquery, false);
                        continue;
                    }
                }

                if (item.Type == CommonXml.Type.NONE)
                {
                    SqlVarMappingFunction(item, ref cquery, false);
                    continue;
                }
                //그 어떤 값도 아닐 경우
                SqlVarMappingFunction(item, ref cquery, false);
            }
            return cquery;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual object ExcuteSql()
        {
            /*
             * SQL 변수 처리 정리
             * 1. 각 타입별로 처리 
             * 2. 변수 마스킹 및 기타 처리는 Like 문인지 아닌지로 넣는 로직 필요. -> 20240225 추가
             * 3. Option 삭제는 아무 값이 없다면 삭제하는 것으로 설정
             * 4. 아무 값이 없다는 것은 기본 값으로 설정된 내용을 말함
             * 
             * 기본 로직 순서
             * 1. 변수 입력 : Winform에 입력값 받음
             * 2. 변수 값 마스킹 처리 : Like문이면 '%%'로 Equal(=)이면 ''로 마스킹 처리
             * 3. 변수 값 기반으로 SQL 삭제 처리 : 기본 값('%%', '')이면 삭제 
             * 4. 기본 값이 아닐 경우 SQL과 변수 추가
             * 
             * SQL + 변수 추가 로직
             * 1. 위 사항에서 변수 추가 포인트 소스까지 도달
             * 2. 변수 값이 기본 값이 아니라면 SQL에 변수 Replace처리
             * 3. Replace된 SQL을 Main SQL에 추가 
             * 
             */
            string cquery = MakeSql();
            try
            {
                sqlStr = MakeSql();

                return databaseUtilities.GetSqlData(cquery, dBConnectionString, ref errMsg);
            }
            catch (Exception ex)
            {
                ex.HelpLink = $"{ex.Message} : {this.GetType().Name}";
                ex.Source = cquery;
                throw ex;
            }
        }


        public object GetClassType(object className)
        {

            if (className is DefaultSqlData)
            {
                return className as DefaultSqlData;
            }

            if (className is SearchCarrierInfomation)
            {
                return className as SearchCarrierInfomation;
            }

            return this;
        }

        public virtual object ExcuteSql(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString)
        {
            this.dBConnectionString = dBConnectionString;
            this.paramaterDic = paramaterDic;
            this.sqldata = sqldata;
            return ExcuteSql();
        }
    }
}
