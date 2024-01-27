using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CustomUtils
{
    public static class CommonConstants
    {
        public static readonly string sqlXmlPath = $@"./Sql.xml";
        public static string GetCurrentXmlPath(string className, string methodName) 
        {
            return $@"/SqlList/{className}/{methodName}";
        }
    }

    public static class SqlVal 
    {
        public static string CSTSTAT = "CSTSTAT";
        public static string CstId = "CstId";
        public static string ReqPortId = "ReqPortId";
        public static string ToPortId = "ToPortId";
        public static string RuleId = "RuleId";
        public static string EqptId = "EqptId";
        public static string StartDate = "StartDate";
        public static string EndDate = "EndDate";
        public static string LaneId = "LaneId";
        public static string EQGRID = "EQGRID";
        public static string MOVINGSTATE = "MOVINGSTATE";
    }

    public static class CommonXml
    {
        public static string type = "type";

        public static class Type
        {
            public static string IF = "IF";
            public static string NONE = "NONE";
            public static string CSTSTAT = "CSTSTAT";
            public static string MOVINGSTATE = "MOVINGSTATE";
        }

        public static string dataType = "dataType";
        /// <summary>
        /// condition = "condition"
        /// </summary>
        public static string condition = "condition";

        public static class Condition
        {
            /// <summary>
            /// not_equal = "not_equal";
            /// </summary>
            public static string not_equal = "not_equal";
            /// <summary>
            /// equal = "equal";
            /// </summary>
            public static string equal = "equal";
            /// <summary>
            /// FUTURE = "FUTURE";
            /// </summary>
            public static string FUTURE = "FUTURE";
            /// <summary>
            /// PAST = "PAST";
            /// </summary>
            public static string PAST = "PAST";
            /// <summary>
            /// EQUAL = "EQUAL";
            /// </summary>
            public static string EQUAL = "EQUAL";
        }

        public static class TIME
        {
            /// <summary>
            /// TODAY = "TODAY";
            /// </summary>
            public static string TODAY = "TODAY";
            /// <summary>
            /// TOMORROW = "TOMORROW";
            /// </summary>
            public static string TOMORROW = "TOMORROW";
            /// <summary>
            /// YESTERDAY = "YESTERDAY";
            /// </summary>
            public static string YESTERDAY = "YESTERDAY";
        }

        public static string key = "key";
        public static string value = "value";
        public static string Default = "default";


        public static string Coloring = "Coloring";
        public static string Red = "Red";
        public static string Green = "Green";
        public static string Blue = "Blue";
        public static string IsColoringRow = "IsColoringRow";
        public static string IsColoringColumn = "IsColoringColumn";
        public static string IsTimeCompare = "IsTimeCompare";
        

        /// <summary>
        /// Option
        /// </summary>
        public static string Option = "Option";
        /// <summary>
        /// AdditionalVariable
        /// </summary>
        public static string AdditionalVariable = "AdditionalVariable";
    }

    public static class CSTErrMsg
    {
        public static string typeErr = "트레이종류(실공, 타입)가 서로 다릅니다.";
        public static string upDownErr = "UP DOWN 트레이 정보가 맞지 않습니다.";
        public static string spcCstErr = "스페셜 트레이 정보가 맞지 않습니다.";
        public static string allCellErr = "전셀 불량 트레이 입니다.";
        public static string crackTrayErr = "해당 트레이는 크렉 트레이 입니다.";
        public static string smplMsg = "해당 트레이는 샘플 출고 트레이 입니다.";
    }

    public static class Constants
    {
        public static class Site
        {
            public static string Nanjing1 = "NJ";
            public static string Nanjing2 = "NB";

            public static class NB
            {
                public static string EF = "EF";
                public static string AA = "AA";

                public static class ELEC
                {
                    public static string FOIL_STO = "U1FSTO11301";
                    public static string ASSY = "AA";


                }
            }

        }

        public static class DB 
        {
            public static class Data_Source
            {
                public static string NB = @"Data Source=10.95.9.45,7433;Initial catalog=ESGM_BMES_ELTR_P01;User ID=rtd_app;Password =##r51T1980D@!;Area ID=EI;Plant ID=U1";
                public static string AA = "AA";

                public static class ELEC
                {
                    public static string FOIL_STO = "U1FSTO11301";
                    public static string ASSY = "AA";


                }
            }
        }
    }
}
