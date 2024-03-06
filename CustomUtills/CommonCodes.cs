using CustomUtills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManagement
{
    public class CommonCodes : List<CommonCode>
    {
        Dictionary<string, string> stkComCodeDic;
        public Dictionary<string, string> StkComCodeDic
        {
            get => stkComCodeDic;
            set => stkComCodeDic = value;
        }

        public CommonCodes(List<CommonCode> commonCodes ) {
            StkComCodeDic = new();
            foreach (CommonCode item in commonCodes)
            {
                if (!(item.Sto_Desc == null) && !(item.Code == null))
                {
                    stkComCodeDic.Add(item.Sto_Desc, item.Code);
                }
            }
            this.AddRange(commonCodes);
        }
    }


    public class CommonCode
    {
        public string EQPTID { get; set; }
        public string EQGRID { get; set; }
        public string Code { get; set; }
        public string Sto_Desc { get; set; }
    }
}
