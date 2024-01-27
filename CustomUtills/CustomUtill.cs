using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomUtills
{
    public class CustomUtill
    {
        public static void RexReplace(ref string source, string replaceStr, string target) {

            string pattern = @$"{replaceStr}";
            Regex regex = new Regex(pattern);
            source = regex.Replace(source, target);
        }


    }

    
}
