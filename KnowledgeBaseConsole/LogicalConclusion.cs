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

        public void FindLogicalConclusionAndSetLogicalOutput()
        {
            IList<Judgment> topRuleTreeConsequences = this.ruleBase.GetTopRuleTreeConsequences();

            while (!this.workingMemory.ContainsAllJudgments(topRuleTreeConsequences))
            {
                this.factorsOutput[this.iteration] = new List<Judgment>();
                this.rulesOutput[this.iteration] = new List<Rule>();

                this.FillRulesAndFactorsLogicalOutput(workingMemory, ruleBase.RuleTree);

                this.workingMemory.AddRangeFactors(this.factorsOutput[this.iteration]);

                this.iteration++;
            }
        }

        private void FillRulesAndFactorsLogicalOutput(WorkingMemory workingMemory, IList<Rule> baseRuleTree)
        {
            foreach (Rule rule in baseRuleTree)
                if (workingMemory.ContainsAllJudgments(rule.Antecedent.ToList()))
                {
                    this.rulesOutput[this.iteration].Add(rule);
                    this.factorsOutput[this.iteration].Add(rule.Consequent);
                }
                else
                    this.FillRulesAndFactorsLogicalOutput(workingMemory, rule.GetChildRules());
        }
    }
}
