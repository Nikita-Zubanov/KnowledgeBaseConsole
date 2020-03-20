using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class CompoundRule : Rule
    {
        private IList<Rule> childRules;

        public CompoundRule(IList<Judgment> antecedent, Judgment consequent) : base(antecedent, consequent)
        {
            this.childRules = new List<Rule>();
        }

        public override void AddChildRule(Rule rule)
        {
            if (rule != null)
                this.childRules.Add(rule);
        }

        public override IList<Rule> GetChildRules()
        {
            return this.childRules;
        }

        public new void Print()
        {
            IEnumerator<Rule> childRule = childRules.GetEnumerator();

            while(childRule.MoveNext())
                childRule.Current.Print();

            base.Print();
        }
    }
}
