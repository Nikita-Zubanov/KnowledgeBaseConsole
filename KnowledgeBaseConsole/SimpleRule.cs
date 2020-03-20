using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class SimpleRule : Rule
    {
        public SimpleRule(JudgmentList antecedent, Judgment consequent) : base(antecedent, consequent) { }

        public override void AddChildRule(Rule rule) =>
            throw new NotImplementedException();

        public override IList<Rule> GetChildRules() =>
            throw new NotImplementedException();

        public static explicit operator CompoundRule(SimpleRule rule)
        {
            return new CompoundRule(rule.Antecedent, rule.Consequent);
        }
    }
}
