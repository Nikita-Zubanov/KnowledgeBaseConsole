using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnowledgeBaseConsole
{
    class WorkingMemory
    {
        public IList<Judgment> Factors { get; private set; }

        public WorkingMemory(IList<Judgment> inputFactors)
        {
            this.Factors = inputFactors;
        }

        public void AddFactor(Judgment factor)
        {
                this.Factors.Add(factor);
        }
        public void AddRangeFactors(IList<Judgment> factors)
        {
            foreach (Judgment factor in factors)
                this.Factors.Add(factor);
        }

        //public bool ContainsAny(IList<Rule> judgments)
        //{
        //    Rule searchedRule = null;
        //    foreach (Rule judgment in judgments)
        //        if (Factors.Contains(judgment.Consequent))
        //            searchedRule = judgment;

        //    if (searchedRule != null)
        //    {
        //        foreach (Rule judgment in judgments)
        //            if (!judgment.Antecedent.ContainsAll(Factors))
        //                return false;
        //    }

        //    return true;
        //}
        public bool ContainsAny(IList<Judgment> judgments)
        {
            foreach (Judgment judgment in judgments)
                if (Factors.Contains(judgment))
                    return true;
            return false;
        }
    }
}
