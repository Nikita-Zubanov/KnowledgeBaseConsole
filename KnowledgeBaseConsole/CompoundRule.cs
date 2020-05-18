using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class CompoundRule : Rule
    {
        private IList<Rule> childRules;
        private IList<Rule> otherRules;

        public CompoundRule(LinguisticVariable linguisticVariable, Antecedent antecedent, Judgment consequent) : base(linguisticVariable, antecedent, consequent)
        {
            this.childRules = new List<Rule>();
            this.otherRules = new List<Rule>();
        }
        public CompoundRule(LinguisticVariable linguisticVariable, Antecedent antecedent, Judgment consequent, Judgment other) : base(linguisticVariable, antecedent, consequent, other)
        {
            this.childRules = new List<Rule>();
            this.otherRules = new List<Rule>();
        }

        public override void AddChildRule(Rule rule)
        {
            if (rule != null)
                this.childRules.Add(rule);
        }
        public override void AddChildRules(IList<Rule> rules)
        {
            if (rules != null)
                foreach (Rule rule in rules)
                    this.childRules.Add(rule);
        }

        public override IList<Rule> GetChildRules()
        {
            return this.childRules;
        }

        //public override void AddOtherRule(Rule rule)
        //{
        //    if (rule != null)
        //        this.otherRules.Add(rule);
        //}
        //public override IList<Rule> GetOtherRules()
        //{
        //    return this.otherRules;
        //}
        //public new void Print()
        //{
        //    IEnumerator<Rule> childRule = childRules.GetEnumerator();

        //    while(childRule.MoveNext())
        //        childRule.Current.Print();

        //    base.Print();
        //}
    }
}
