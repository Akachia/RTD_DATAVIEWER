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
using XmlManagement;

namespace DBManagement
{
    public class Carrier
    {
        [DisplayName("CSTID")]
        public string CSTID { get; set; }
        [DisplayName("CSTSTAT")]
        public string CSTSTAT { get; set; }
        [DisplayName("대표CST")]
        public string LOAD_REP_CSTID { get; set; }
        [DisplayName("단")]
        public int CST_LOAD_LOCATION_CODE { get; set; }
        public string CURR_RACK_ID { get; set; }
        public string CURR_LOTID { get; set; }
        public string ABNORM_TRF_RSN_CODE { get; set; }
        public string EQPT_CUR { get; set; }
        public string PORT_CUR { get; set; }
        public string ROUTID { get; set; }
        public string WIPSTAT { get; set; }
        public string LOTTYPE { get; set; }
        public string DAY_GR_LOTID { get; set; }
        public string SPCL_FLAG { get; set; }
        public string SMPL_ISS_TYPE_CODE { get; set; }
        public string LOT_DETL_TYPE_CODE { get; set; }
        public string DFCT_LIMIT_OVER_FLAG { get; set; }
        public string SPCL_NOTE { get; set; }
        public string FORM_SPCL_GR_ID { get; set; }
        public string PROCID { get; set; }
        public string TRAY_TYPE_CODE { get; set; }
        public DateTime UPDDTTM { get; set; }
        public string DFCT_OCCR_EQPTID { get; set; }
        public DateTime AGING_ISS_SCHD_DTTM { get; set; }
        public string SCRP_TRAY_FLAG { get; set; }
        public string TRAY_CNVR_BCR_SCAN_COUNT { get; set; }
    }

    public class SearchCarrierInfomation : SqlResultData
    {
        string carrierMismatchInfo = string.Empty;

        public string CarrierMismatchInfo { get => carrierMismatchInfo; set => carrierMismatchInfo = value; }

        public SearchCarrierInfomation(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString)
            : base(paramaterDic, sqldata, dBConnectionString)
        {
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

        public new object ExcuteSql()
        {
            try
            {
                string cquery = sqldata.Sql;
                string plantId = dBConnectionString.PlantID;
                string systemTypeCode = dBConnectionString.SystemTypeCode;

                if (paramaterDic[CommonXml.CSTID] == string.Empty)
                {
                    errMsg = "Carrier ID를 입력해주세요.";
                    return null;
                }
                if (paramaterDic.ContainsKey(CommonXml.CSTID))
                {
                    cquery = cquery.Replace($"@{CommonXml.CSTID}", CustomUtills.CustomUtill.StringToDBStr(paramaterDic[CommonXml.CSTID]));
                }
                else
                {
                    errMsg = $" CSTID is null : {this.GetType().Name}";
                    return null;
                }
                List<Carrier> carriers;

                if (dBConnectionString.DatabaseProvider == "ORACLE")
                {
                    string testcquery = "SELECT * FROM AKACHISCHEMA.CARRIER";

                    // dgv_CstInfo.DgvData.RowPostPaint -= DataGridView_RowPostPaint;
                    using (var connection = new OracleConnection(dBConnectionString.ConnectionString()))
                    {
                        sqlStr = cquery;
                        return connection.Query(testcquery).ToList();
                    }
                }

                using (var connection = new SqlConnection(dBConnectionString.MssqlConnectionString()))
                {
                    sqlStr = cquery;
                    carriers = connection.Query<Carrier>(cquery).ToList();
                }

                carrierMismatchInfo = MakeCSTErrMsg(carriers);
                return carriers;
            }
            catch (Exception ex)
            {
                errMsg = $"{ex.Message} : {this.GetType().Name}";
                return null;
            }
        }

        public new object ExcuteSql(Dictionary<string, string> paramaterDic, XmlOptionData sqldata, DBConnectionString dBConnectionString)
        {
            this.dBConnectionString = dBConnectionString;
            this.paramaterDic = paramaterDic;
            this.sqldata = sqldata;

            return ExcuteSql();
        }
    }
}

