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

        public static bool IsLikeQeury(string source)
        {
            string pattern = @"((?i)AND .+ LIKE .+)";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(source);
        }

        public static bool IsEqualQeury(string source)
        {
            string pattern = @"((?i)AND.+ = .+)";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(source);
        }

        public static bool IsInQeury(string source)
        {
            string pattern = @"((?i)AND.+ IN .+)";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(source);
        }

        public static bool IsMaskingValue(string source)
        {
            string pattern = @"('.+')";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(source);
        }

        public static bool IsMaskingLikeValue(string source)
        {
            string pattern = @"('%?.+%?')";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(source);
        }

        public static string LikeStringMaskingByLeft(string str) => @$"'%{str}'";

        public static string LikeStringMaskingByRight(string str) => @$"'{str}%'";

        public static string LikeStringMaskingByBoth(string str)
        {
            if (IsMaskingLikeValue(str))
            {
                return str;
            }
            return @$"'%{str}%'";
        }    


        public static string StringToDBStr(string str)
        {
            if (IsMaskingLikeValue(str))
            {
                return str;
            }
            return @$"'{str}'";
        } 
    }


}
