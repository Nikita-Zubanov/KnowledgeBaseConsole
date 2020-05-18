using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Completeness : IVerification, ITransformer
    {
        public void Transform(IList<Rule> rules)
        {
            if (rules != null)
            {
                IList<Rule> treeRules = GetTopRule(rules);

                MakeTreeRules(rules, treeRules);

                this.OverwriteRules(rules, treeRules);
            }
            else
                throw new NullReferenceException();
        }

        public Boolean IsVerified(IList<Rule> rules)
        {
            //if (rules != null)
            //{
            //    if (this.GetTopTreeRules(rules).Count == 0)
            //        return false;

                return true;
            //}
            //else
            //    throw new NullReferenceException();
        }

        private void MakeTreeRules(IList<Rule> baseRules, IList<Rule> rulesTree)
        {
            foreach (Rule ruleOfTree in rulesTree)
            {
                Boolean isAdded = false;

                foreach (Rule baseRule in baseRules)
                {
                    if (ruleOfTree.Antecedent.Contains(baseRule.Consequent))
                    {
                        ruleOfTree.AddChildRule((CompoundRule)(SimpleRule)baseRule);

                        isAdded = true;
                    }
                    else if (ruleOfTree.Antecedent.Contains(baseRule.Other))
                    {
                        var rls = (CompoundRule)(SimpleRule)baseRule;
                        ruleOfTree.AddChildRule(rls);

                        isAdded = true;
                    }
                }

                if (isAdded)
                    this.MakeTreeRules(baseRules, ruleOfTree.GetChildRules());
            }
        }

        private void OverwriteRules(IList<Rule> beforeRules, IList<Rule> afterRules)
        {
            for (int index = beforeRules.Count - 1; index >= 0; index--)
                beforeRules.Remove(beforeRules[index]);

            foreach (Rule rule in afterRules)
                beforeRules.Add(rule);
        }

        private IList<Rule> GetTopRule(IList<Rule> baseRules)
        {
            IList<Rule> topRules = new List<Rule>();

            foreach (Rule currentRule in baseRules)
            {
                Boolean isTopRule = true;

                foreach (Rule rule in baseRules)
                    if (rule.Antecedent.Contains(currentRule.Consequent))
                    {
                        isTopRule = false;
                        break;
                    }

                if (isTopRule)
                {
                    Rule topRule = new CompoundRule(currentRule.LinguisticVariable, currentRule.Antecedent, currentRule.Consequent);
                    topRules.Add(topRule);
                }
            }

            return topRules;
        }
    }
}