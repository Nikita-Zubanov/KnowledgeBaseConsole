using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Coherence : IVerification
    {
        public void Verify(IList<Rule> rules)
        {
            if (rules != null)
            {
                this.RemoveDuplicates(rules);
            }
            else
                throw new NullReferenceException();
        }

        public Boolean IsVerified(IList<Rule> rules)
        {
            if (rules != null)
            {
                if (this.IsConsequentsNotContradictions(rules))
                    return true;

                return false;
            }
            else
                throw new NullReferenceException();
        }

        private void RemoveDuplicates(IList<Rule> rules)
        {
            for (Int32 index = 0; index < rules.Count - 1; index++)
            {
                Rule currentRule = rules[index];
                Rule nextRule = rules[index + 1];

                if (currentRule.Equals(nextRule))
                    rules.Remove(nextRule);
            }
        }

        private Boolean IsConsequentsNotContradictions(IList<Rule> rules)
        {
            foreach (Rule currentRule in rules)
            {
                foreach (Rule rule in rules)
                {
                    IList<Judgment> ruleAntecedents = rule.Antecedent.Judgments;
                    Judgment ruleConsequent = rule.Consequent;

                    if (currentRule.Equals(ruleAntecedents) &&
                        !currentRule.Equals(ruleConsequent))
                        return false;
                }
            }

            return true;
        }
    }
}
