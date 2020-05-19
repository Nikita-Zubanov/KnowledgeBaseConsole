using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace KnowledgeBaseConsole
{
    class LogicalConclusion
    {
        private RuleBase ruleBase = new RuleBase();
        private WorkingMemory workingMemory;

        public LogicalOutput LogicalOutput { get; set; } = new LogicalOutput();

        public LogicalConclusion(IList<Judgment> factors)
        {
            this.workingMemory = new WorkingMemory(factors);
        }

        public void FindLogicalConclusionAndSetLogicalOutput()
        {
            IList<Judgment> topRuleConsequences = ruleBase.GetTopRuleConsequences();

            while (!workingMemory.ContainsAny(topRuleConsequences))
            {
                LogicalOutput.Next();

                FillRulesAndFactorsLogicalOutput(workingMemory, ruleBase.RuleTree);

                workingMemory.AddRangeFactors(LogicalOutput.CurrentFactors);
            }
        }

        private void FillRulesAndFactorsLogicalOutput(WorkingMemory workingMemory, IList<Rule> ruleTree)
        {
            foreach (Rule rule in ruleTree)
            {
                if (!LogicalOutput.HaveConsequentOrOtherwise(rule) &&
                    rule.IsAllowConsequent(workingMemory.Factors))
                {
                    LogicalOutput.Add(rule.Consequent);
                    LogicalOutput.Add(rule);

                    IfIsTopRuleAddToWorkingMemory(rule);
                }
                else if (!LogicalOutput.HaveConsequentOrOtherwise(rule) &&
                    rule.IsAllowOtherwise(workingMemory.Factors))
                {
                    LogicalOutput.Add(rule.Otherwise);
                    LogicalOutput.Add(rule);
                }

                FillRulesAndFactorsLogicalOutput(workingMemory, rule.GetChildRules());
            }
        }

        private void IfIsTopRuleAddToWorkingMemory(Rule rule)
        {
            IList<Judgment> topRuleConsequences = ruleBase.GetTopRuleConsequences();
            if (topRuleConsequences.Contains(rule.Consequent))
            {
                workingMemory.AddRangeFactors(LogicalOutput.CurrentFactors);

                LogicalOutput.Next();
            }
        }
    }
}
