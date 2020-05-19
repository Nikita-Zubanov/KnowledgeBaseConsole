using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class CompoundRule : Rule
    {
        public IList<Rule> childRules = new List<Rule>();

        public CompoundRule(LinguisticVariable linguisticVariable, Antecedent antecedent, Judgment consequent) : base(linguisticVariable, antecedent, consequent) { }
        public CompoundRule(LinguisticVariable linguisticVariable, Antecedent antecedent, Judgment consequent, Judgment other) : base(linguisticVariable, antecedent, consequent, other) { }

        public override void AddChildRule(Rule rule)
        {
            this.childRules.Add(rule);
        }

        public override IList<Rule> GetChildRules()
        {
            return this.childRules;
        }
    }
}
