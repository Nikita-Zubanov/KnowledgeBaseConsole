using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class LogicalOutput
    {
        private IList<Judgment> allFactors = new List<Judgment>();
        private Int32 iteration = 0;

        public IDictionary<Int32, IList<Judgment>> FactorsOutput { get; private set; } = new Dictionary<Int32, IList<Judgment>>();
        public IDictionary<Int32, IList<Rule>> RulesOutput { get; private set; } = new Dictionary<Int32, IList<Rule>>();

        public IList<Judgment> CurrentFactors { get { return FactorsOutput[iteration]; } }

        public void Next()
        {
            iteration++;

            FactorsOutput[iteration] = new List<Judgment>();
            RulesOutput[iteration] = new List<Rule>();
        }

        public void Add(Judgment judgment)
        {
            FactorsOutput[iteration].Add(judgment);
            allFactors.Add(judgment);
        }
        public void Add(Rule rule)
        {
            RulesOutput[iteration].Add(rule);
        }

        public bool HaveConsequentOrOtherwise(Rule rule)
        {
            return allFactors.Contains(rule.Consequent) || allFactors.Contains(rule.Otherwise);
        }
    }
}
