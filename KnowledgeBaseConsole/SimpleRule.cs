﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class SimpleRule : Rule
    {
        public SimpleRule(LinguisticVariable linguisticVariable, Antecedent antecedent, Judgment consequent) : base(linguisticVariable, antecedent, consequent) { }
        public SimpleRule(LinguisticVariable linguisticVariable, Antecedent antecedent, Judgment consequent, Judgment other) : base(linguisticVariable, antecedent, consequent, other) { }

        public override void AddChildRule(Rule rule) =>
            throw new NotImplementedException();
        public override IList<Rule> GetChildRules() =>
            throw new NotImplementedException();

        public static explicit operator CompoundRule(SimpleRule rule)
        {
            return new CompoundRule(rule.LinguisticVariable, rule.Antecedent, rule.Consequent, rule.Otherwise);
        }
    }
}
