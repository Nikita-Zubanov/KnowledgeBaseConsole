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

        public Boolean HaveJudgments(IList<Judgment> judgments)
        {
            foreach (Judgment judgment in judgments)
                if (!this.Factors.Contains(judgment))
                    return false;

            return true;
        }

        public bool ContainsAny(IList<Judgment> judgments)
        {
            foreach (Judgment judgment in judgments)
                if (Factors.Contains(judgment))
                    return true;
            return false;
        }
    }
}
