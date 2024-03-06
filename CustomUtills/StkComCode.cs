using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CustomUtills
{
    public class StkComCodeList : List<StkComCode>
    {
        Dictionary<string, string> stkComCodeDic;
        public Dictionary<string, string> StkComCodeDic 
        { 
            get => stkComCodeDic; 
            set => stkComCodeDic = value; 
        }

        public StkComCodeList(List<StkComCode> list)
        {
            StkComCodeDic = new();
            foreach (StkComCode item in list)
            {
                stkComCodeDic.Add(item.Sto_Desc, item.Code);
            }
            this.AddRange(list);
        }
    }

    public class StkComCode
    {
        public string Code { get; set; }
        public string Sto_Desc { get; set; }
    }
}
