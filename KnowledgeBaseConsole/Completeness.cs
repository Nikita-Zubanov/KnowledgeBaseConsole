using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Completeness : IVerification
    { 
        public void Verify(IList<Rule> rules)
        {
            if (rules != null)
            {
                IList<Rule> rulesTree = this.GetTopTreeRules(rules);

                this.MakeRuleTreeFromBaseRules(rules, rulesTree);

                this.OverwriteRules(rules, rulesTree);
            }
            else
                throw new NullReferenceException();
        }

        public Boolean IsVerified(IList<Rule> rules)
        {
            if (rules != null)
            {
                if (this.GetTopTreeRules(rules).Count == 0)
                    return false;

                return true;
            }
            else
                throw new NullReferenceException();
        }

        private void MakeRuleTreeFromBaseRules(IList<Rule> baseRules, IList<Rule> rulesTree)
        {
            foreach (Rule ruleOfTree in rulesTree)
            {
                Boolean isAdded = false;

                foreach (Rule baseRule in baseRules)
                    if (ruleOfTree.Antecedent.Contains(baseRule.Consequent))
                    {
                        ruleOfTree.AddChildRule((CompoundRule)(SimpleRule)baseRule);

                        isAdded = true;
                    }

                if (isAdded)
                    this.MakeRuleTreeFromBaseRules(baseRules, ruleOfTree.GetChildRules());
            }
        }

        private void OverwriteRules(IList<Rule> beforeRules, IList<Rule> afterRules)
        {
            for (int index = beforeRules.Count - 1; index >= 0; index--)
                beforeRules.Remove(beforeRules[index]);

            foreach (Rule rule in afterRules)
                beforeRules.Add(rule);
        }

        private IList<Rule> GetTopTreeRules(IList<Rule> baseRules)
        {
            IList<Rule> topRules = new List<Rule>();

            foreach (Rule baseRule in baseRules)
            {
                Boolean isTopRule = true;
                Judgment consequentCurrentRule = baseRule.Consequent;

                foreach (Rule rule in baseRules)
                {
                    IList<Judgment> antecedentsRule = rule.Antecedent;

                    if (antecedentsRule.Contains(consequentCurrentRule))
                    {
                        isTopRule = false;
                        break;
                    }
                }

                if (isTopRule)
                    topRules.Add(new CompoundRule(baseRule.Antecedent, baseRule.Consequent));
            }

            return topRules;
        }
    }
}