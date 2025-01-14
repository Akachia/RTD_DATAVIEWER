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
        [DisplayName("ASSY_LOT")]
        public string DAY_GR_LOTID { get; set; }
        public string SPCL_FLAG { get; set; }
        [DisplayName("샘플코드")]
        public string SMPL_ISS_TYPE_CODE { get; set; }
        public string LOT_DETL_TYPE_CODE { get; set; }
        public string FORM_FORC_MANL_PORT { get; set; }
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

    public class SearchCarrierInfomation : SqlResultDataImpl
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
            Carrier? firstCarrier = carriers[0];
            Carrier? secondCarrier = null;
            if (carriers.Count > 1)
            {
               secondCarrier = carriers[1];
            }

            string routid = ""; string dfct = "F"; string scrp = "N"; string sltc = "N";
            if (carriers.Count != 0)
            {
                dfct = firstCarrier.DFCT_LIMIT_OVER_FLAG;
                routid = firstCarrier.ROUTID;
                scrp = firstCarrier.SCRP_TRAY_FLAG;
                sltc = firstCarrier.SMPL_ISS_TYPE_CODE;

                if (firstCarrier.FORM_FORC_MANL_PORT == "F")
                {
                    return CSTErrMsg.typeErr + "강제배출 트레이";
                }

                if (firstCarrier.FORM_FORC_MANL_PORT == "N")
                {
                    return CSTErrMsg.typeErr + "폐기 트레이";
                }

                if (firstCarrier.FORM_FORC_MANL_PORT == "O")
                {
                    return CSTErrMsg.typeErr + "과불량 트레이";
                }

                if (!(firstCarrier.ABNORM_TRF_RSN_CODE != string.Empty || firstCarrier.ABNORM_TRF_RSN_CODE is not null))
                {
                    return CSTErrMsg.typeErr + " 상하단 미스매치 판정된 트레이";
                }

                if (secondCarrier != null)
                {
                    //--------------------------------------------------------------------------------------------------------------------------------------------------
                    if (firstCarrier.CSTSTAT != secondCarrier.CSTSTAT)
                    {
                        return CSTErrMsg.typeErr + "(실,공 다름)";
                    }
                    if (firstCarrier.TRAY_TYPE_CODE != secondCarrier.TRAY_TYPE_CODE) // cststat, 트레이 타입
                    {
                        return CSTErrMsg.typeErr + "(트레이 타입 다름)";
                    }
                    //--------------------------------------------------------------------------------------------------------------------------------------------------
                    if (firstCarrier.DAY_GR_LOTID != secondCarrier.DAY_GR_LOTID)
                    {
                        return CSTErrMsg.upDownErr + "(조립 LOT ID 다름)";
                    }
                    if (firstCarrier.ROUTID != secondCarrier.ROUTID)
                    {
                        return CSTErrMsg.upDownErr + "(RoutId 다름)";
                    }
                    if (firstCarrier.PROCID != secondCarrier.PROCID)
                    {
                        return CSTErrMsg.upDownErr + "(PROCID 다름)";
                    }
                    if (firstCarrier.SPCL_FLAG != secondCarrier.SPCL_FLAG)
                    {
                        return CSTErrMsg.upDownErr + "(스페셜 타입 다름)";
                    }
                    if (firstCarrier.LOTTYPE != secondCarrier.LOTTYPE)
                    {
                        return CSTErrMsg.upDownErr + "(Lot 타입 다름)";
                    }
                    if (firstCarrier.WIPSTAT != secondCarrier.WIPSTAT)
                    {
                        return CSTErrMsg.upDownErr + "(Lot 상태 다름)";
                    }
                }
                //--------------------------------------------------------------------------------------------------------------------------------------------------
                if (firstCarrier.SPCL_FLAG == "Y")
                {
                    if (secondCarrier != null)
                    {
                        if (firstCarrier.DAY_GR_LOTID != secondCarrier.DAY_GR_LOTID ||
                    firstCarrier.ROUTID != secondCarrier.ROUTID ||
                    firstCarrier.PROCID != secondCarrier.PROCID ||
                    firstCarrier.SPCL_FLAG != secondCarrier.SPCL_FLAG ||
                    firstCarrier.LOTTYPE != secondCarrier.LOTTYPE ||
                    firstCarrier.FORM_SPCL_GR_ID != secondCarrier.FORM_SPCL_GR_ID
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
            errMsg = string.Empty;
            carrierMismatchInfo = string.Empty;
            try
            {
                string cquery = sqldata.Sql;
                string plantId = dBConnectionString.PlantID;
                string systemTypeCode = dBConnectionString.SystemTypeCode;

                if (paramaterDic[CommonXml.DURABLE_ID] == string.Empty)
                {
                    errMsg = "DURABLE ID를 입력해주세요.";
                    return null;
                }
                if (paramaterDic.ContainsKey(CommonXml.DURABLE_ID))
                {
                    cquery = cquery.Replace($"@{CommonXml.DURABLE_ID}", CustomUtills.CustomUtill.StringToDBStr(paramaterDic[CommonXml.DURABLE_ID]));
                }
                else
                {
                    errMsg = $" DURABLE ID is null : {this.GetType().Name}";
                    return null;
                }
                List<Carrier> carriers;

                if (dBConnectionString.DatabaseProvider == "ORACLE")
                {
                    string testcquery = "SELECT * FROM AKACHISCHEMA.CARRIER";

                    // dgv_CstInfo.DgvData.RowPostPaint -= DataGridView_RowPostPaint;
                    using (var connection = new OracleConnection(dBConnectionString.ConnectionString()))
                    {
                        //errMsg = $" DURABLE ID is null : {cquery} : {this.GetType().Name}";
                        sqlStr = cquery;
                        return connection.Query(cquery).ToList();
                        
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

