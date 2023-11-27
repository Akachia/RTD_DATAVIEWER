using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManagemnet
{
    public class Carrier
    {
        public string CSTID { get; set; }
        public string CSTSLOTNUM { get; set; }
        public string CSTTYPE { get; set; }
        public string CSTSTAT { get; set; }
        public string EQPT_CUR { get; set; }
        public string PORT_CUR { get; set; }
        public string CSTOWNER { get; set; }
        public string CSTCAPA { get; set; }
        public string CSTIUSE { get; set; }
        public string PROCID_CUR { get; set; }
        public string CSTPROD { get; set; }
        public string CSTINDTTM { get; set; }
        public string INSUSER { get; set; }
        public DateTime INSDTTM { get; set; }
        public string UPDUSER { get; set; }
        public DateTime UPDDTTM { get; set; }
        public string CURR_RACK_ID { get; set; }
        public string DFCT_LIMIT_OVER_FLAG { get; set; }
        public string CURR_LOTID { get; set; }
        public string ROUTID { get; set; }
        public string SCRP_TRAY_FLAG { get; set; }
        public string TRAY_TYPE_CODE { get; set; }
        public string ASSY_LOTID { get; set; }
        public string LOTTYPE { get; set; }
        public string PROCID { get; set; }
        public string SPCL_FLAG { get; set; }
        public string FORM_SPCL_GR_ID { get; set; }
    }
}
