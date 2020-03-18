using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Interpreter
    {
        private RuleBase ruleBase;
        private WorkingMemory workingMemory;

        private IDictionary<Int32, IList<Judgment>> factorsOutput;
        private IDictionary<Int32, IList<Rule>> rulesOutput;

        private Int32 iteration = 1;

        public IDictionary<Int32, IList<Judgment>> FactorsOutput { get { return this.factorsOutput; } }
        public IDictionary<Int32, IList<Rule>> RulesOutput { get { return this.rulesOutput; } }

        public Interpreter(IList<Judgment> factors)
        {
            this.ruleBase = new RuleBase();
            this.workingMemory = new WorkingMemory(factors);

            this.factorsOutput = new Dictionary<Int32, IList<Judgment>>();
            this.rulesOutput = new Dictionary<Int32, IList<Rule>>();
        }

        public void SetLogicalOutput()
        {
            IList<Rule> baseRulesTree = ruleBase.CompoundRules;
            IList<Judgment> workingMemoryFactors = workingMemory.Factors;
            IList<Judgment> topRulesConsequents = GetTopRulesConsequents(ruleBase.CompoundRules);

            while (!this.SecondJudgmentHaveFirst(topRulesConsequents, workingMemoryFactors))
            {
                this.factorsOutput.Add(this.iteration, new List<Judgment>());
                this.rulesOutput.Add(this.iteration, new List<Rule>());

                this.FillRulesAndFactorsForLogicalOutput(baseRulesTree, workingMemoryFactors);

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

        private void FillRulesAndFactorsForLogicalOutput(IList<Rule> baseRulesTree, IList<Judgment> workingMemoryFactors)
        {
            foreach (Rule rule in baseRulesTree)
                if (this.SecondJudgmentHaveFirst(rule.Antecedent.Judgments, workingMemory.Factors))
                {
                    this.rulesOutput[this.iteration].Add(rule);
                    this.factorsOutput[this.iteration].Add(rule.Consequent);
                }
                else
                    this.FillRulesAndFactorsForLogicalOutput(rule.GetChildRules(), workingMemoryFactors);
        }

        private Boolean SecondJudgmentHaveFirst(IList<Judgment> firstJudgment, IList<Judgment> secondJudgment)
        {
            foreach (Judgment antecedent in firstJudgment)
                if (!secondJudgment.Contains(antecedent))
                    return false;

            return true;
        }
    }
}
