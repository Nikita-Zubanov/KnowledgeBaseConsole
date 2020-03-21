using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class WorkingMemory
    {
        private IList<Judgment> factors;

        public IList<Judgment> Factors { get { return this.factors; } }

        public WorkingMemory(IList<Judgment> inputFactors)
        {
            this.factors =inputFactors;
        }

        public void AddRangeFactors(IList<Judgment> factors)
        {
            foreach (Judgment factor in factors)
                this.factors.Add(factor);
        }

        public Boolean HaveJudgments(IList<Judgment> judgments)
        {
            foreach (Judgment judgment in judgments)
                if (!this.factors.Contains(judgment))
                    return false;

            return true;
        }
    }
}
