using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnowledgeBaseConsole
{
    abstract class Rule 
    {
        public LinguisticVariable LinguisticVariable { get; private set; }
        public Antecedent Antecedent { get; private set; }
        public Judgment Consequent { get; private set; }
        public Judgment Otherwise { get; private set; }

        public Rule(LinguisticVariable linguisticVariable, Antecedent antecedent, Judgment consequent) : this(linguisticVariable, antecedent, consequent, null) { }
        public Rule(LinguisticVariable linguisticVariable, Antecedent antecedent, Judgment consequent, Judgment other)
        {
            this.LinguisticVariable = linguisticVariable;
            this.Antecedent = antecedent;
            this.Consequent = consequent;
            this.Otherwise = other;
        }

        public abstract void AddChildRule(Rule rule);
        public abstract IList<Rule> GetChildRules();

        public bool IsAllowConsequent(IList<Judgment> judgments)
        {
            return Antecedent.IsTrue(judgments);
        }
        public bool IsAllowOtherwise(IList<Judgment> judgments)
        {
            return Otherwise != null &&
                GetChildRules().Count == 0 &&
                Antecedent.IsCorrespondsButNotTrue(judgments);
        }

        public override bool Equals(object obj)
        {
            if (obj is Rule)
            {
                Rule rule = obj as Rule;

                if (this.Antecedent.Equals(rule.Antecedent) &&
                    this.Consequent.Equals(rule.Consequent))
                    return true;
                else
                    return false;
            }
            else
                throw new NullReferenceException();
        }

        public override string ToString()
        {
            return String.Format("Antecedent: {0}; Consequent: {1}; Otherwise: {2}", this.Antecedent.ToString(), this.Consequent.ToString(), this.Otherwise?.ToString());
        }
    }
}
