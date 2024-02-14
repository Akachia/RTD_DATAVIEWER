using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomUtills
{
    public class  RuleResultCollection
    {
        public List<RuleResult> RuleResults { get; set; }

        public RuleResultCollection(string ruleResult)
        {
            RuleResults = new List<RuleResult>();
            string[] ruleResultArr = ruleResult.Split(',');
            foreach (string ruleResultStr in ruleResultArr)
            {
                RuleResult result = new RuleResult(ruleResultStr);

                if (result.ParentRuleId != 0)
                {
                    RuleResult parentRuleResult = RuleResults.Find(x => x.RuleId == result.ParentRuleId);
                    parentRuleResult.IsHaveChild = true;
                    parentRuleResult.AddChildRuleResult(result);
                }
                else
                {
                    RuleResults.Add(new RuleResult(ruleResultStr));
                }
            }
        }

        public void AddRuleResult(RuleResult ruleResult)
        {
            RuleResults.Add(ruleResult);
        }

        public void AddRuleResult(string ruleResultStr)
        {
            RuleResult ruleResult = new RuleResult(ruleResultStr);
            RuleResults.Add(ruleResult);
        }

        public void AddRuleResult(string ruleResultStr, int parentRuleId)
        {
            RuleResult ruleResult = new RuleResult(ruleResultStr);
            RuleResult parentRuleResult = RuleResults.Find(x => x.RuleId == parentRuleId);
            parentRuleResult.AddChildRuleResult(ruleResult);
        }

        public void AddRuleResult(string ruleResultStr, string parentRuleId)
        {
            RuleResult ruleResult = new RuleResult(ruleResultStr);
            RuleResult parentRuleResult = RuleResults.Find(x => x.RuleName == parentRuleId);
            parentRuleResult.AddChildRuleResult(ruleResult);
        }

        public void AddRuleResult(string ruleResultStr, string parentRuleId, string childRuleId)
        {
            RuleResult ruleResult = new RuleResult(ruleResultStr);
            RuleResult parentRuleResult = RuleResults.Find(x => x.RuleName == parentRuleId);
            RuleResult childRuleResult = parentRuleResult.ChildRuleResults.Find(x => x.RuleName == childRuleId);
            childRuleResult.AddChildRuleResult(ruleResult);
        }

        public void AddRuleResult(string ruleResultStr, int parentRuleId, int childRuleId)
        {
            RuleResult ruleResult = new RuleResult(ruleResultStr);
            RuleResult parentRuleResult = RuleResults.Find(x => x.RuleId == parentRuleId);
            RuleResult childRuleResult = parentRuleResult.ChildRuleResults.Find(x => x.RuleId == childRuleId);
            childRuleResult.AddChildRuleResult(ruleResult);
        }

        public void AddRuleResult(string ruleResultStr, int parentRuleId, string childRuleId)
        {
            RuleResult ruleResult = new RuleResult(ruleResultStr);
            RuleResult parentRuleResult = RuleResults.Find(x => x.RuleId == parentRuleId);
            RuleResult childRuleResult = parentRuleResult.ChildRuleResults.Find(x => x.RuleName == childRuleId);
            childRuleResult.AddChildRuleResult(ruleResult);
        }
}

    public class RuleResult
    {
        /*
         * 100|CNV UR|5|0
         * 117|CNV2 UR|5|0
         * 117-106|CNV Child UR|5|0
         */


        public int RuleId { get; set; }
        public string RuleName { get; set; }
        public int SpentTime { get; set; }
        public int ResultNum { get; set; }
        public bool IsHaveChild { get; set; }
        public int ParentRuleId { get; set; }
        public List<RuleResult> ChildRuleResults { get; set; }

        public RuleResult(string ruleResultStr)
        {
            ChildRuleResults = new List<RuleResult>();
            SetRuleResult(ruleResultStr);
        }

        private void SetRuleResult(string ruleResultStr)
        {
            string[] ruleResultArr = ruleResultStr.Split('|');

            if (ruleResultArr[0].Contains("-"))
            {
                string[] parentRuleIdArr = ruleResultArr[0].Split("-");

                ParentRuleId = int.Parse(parentRuleIdArr[0]);
                RuleId = int.Parse(parentRuleIdArr[1]);
            }
            else
            {
                ParentRuleId = 0;
                RuleId = int.Parse(ruleResultArr[0]);
            }
            RuleName = ruleResultArr[1];
            SpentTime = int.Parse(ruleResultArr[2]);
            ResultNum = int.Parse(ruleResultArr[3]);

        }

        public void AddChildRuleResult(RuleResult ruleResult)
        {
            ChildRuleResults.Add(ruleResult);
        }
    }
}
