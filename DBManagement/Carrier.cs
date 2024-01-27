using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManagemnet
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
}
