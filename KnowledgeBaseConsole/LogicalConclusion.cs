using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            while (!this.workingMemory.ContainsAny(topRuleTreeConsequences))
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
            {
                int a;
                if (rule.Consequent.Equals(new Judgment(FactorTitle.ServiceabilityEquipment, FactorFuzzyValue.Maximum)))
                    a = 0;
                if (rule.CheckAntecedent(workingMemory.Factors))
                {
                    this.rulesOutput[this.iteration].Add(rule);
                    this.factorsOutput[this.iteration].Add(rule.Consequent);
                }
                else
                {
                    if (rule.Other != null && rule.CheckTitleAntecedent(workingMemory.Factors))
                    {
                        workingMemory.AddFactor(rule.Other);
                    }

                    this.FillRulesAndFactorsLogicalOutput(workingMemory, rule.GetChildRules());
                }
            }
        }

        //private void CheckOtherRule(IList<Rule> rules)
        //{
        //    foreach (var rule in rules)
        //    {
        //        if (rule.Other != null)
        //        {
        //            if (rule.CheckTitleAntecedent(workingMemory.Factors))
        //            {
        //                this.factorsOutput[this.iteration].Add(rule.Other);
        //                this.workingMemory.AddFactor(rule.Other);

        //            }
        //        }
        //    }
        //}
    }
}
