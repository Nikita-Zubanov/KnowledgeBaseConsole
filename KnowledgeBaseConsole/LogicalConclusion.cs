using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace KnowledgeBaseConsole
{
    class LogicalConclusion
    {
        private RuleBase ruleBase;
        private WorkingMemory workingMemory;

        private IDictionary<Int32, IList<Judgment>> factorsOutput;
        private IDictionary<Int32, IList<Rule>> rulesOutput;

        private Int32 iteration = 1;

        public IDictionary<Int32, IList<Judgment>> FactorsOutput { get { return this.factorsOutput; } }
        public IDictionary<Int32, IList<Rule>> RulesOutput { get { return this.rulesOutput; } }

        public LogicalConclusion(IList<Judgment> factors)
        {
            this.ruleBase = new RuleBase();
            this.workingMemory = new WorkingMemory(factors);

            this.factorsOutput = new Dictionary<Int32, IList<Judgment>>();
            this.rulesOutput = new Dictionary<Int32, IList<Rule>>();
        }

        public void SetLogicalOutput()
        {
            IList<Rule> baseRuleTree = ruleBase.RuleTree;
            IList<Judgment> workingMemoryFactors = workingMemory.Factors;
            IList<Judgment> topRulesConsequents = this.GetTopRulesConsequents(ruleBase.RuleTree);

            while (!this.FirstJudgmentHaveSecond(workingMemoryFactors, topRulesConsequents))
            {
                this.factorsOutput.Add(this.iteration, new List<Judgment>());
                this.rulesOutput.Add(this.iteration, new List<Rule>());

                this.FillRulesAndFactorsLogicalOutput(baseRuleTree, workingMemoryFactors);

                this.workingMemory.AddRangeFactors(this.factorsOutput[iteration]);
                
                this.iteration++;
            }
        }

        private IList<Judgment> GetTopRulesConsequents(IList<Rule> rules)
        {
            IList<Judgment> topRulesConsequents = new List<Judgment>();

            foreach (Rule rule in rules)
                topRulesConsequents.Add(rule.Consequent);

            return topRulesConsequents;
        }

        private void FillRulesAndFactorsLogicalOutput(IList<Rule> baseRuleTree, IList<Judgment> workingMemoryFactors)
        {
            foreach (Rule rule in baseRuleTree)
                if (this.FirstJudgmentHaveSecond(workingMemoryFactors, rule.Antecedent.Judgments))
                {
                    this.rulesOutput[this.iteration].Add(rule);
                    this.factorsOutput[this.iteration].Add(rule.Consequent);
                }
                else
                    this.FillRulesAndFactorsLogicalOutput(rule.GetChildRules(), workingMemoryFactors);
        }

        private Boolean FirstJudgmentHaveSecond(IList<Judgment> firstJudgments, IList<Judgment> secondJudgments)
        {
            foreach (Judgment secondJudgment in secondJudgments)
                if (!firstJudgments.Contains(secondJudgment))
                    return false;

            return true;
        }
    }
}
