using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class WorkingMemory
    {
        private JudgmentList factors;

        public JudgmentList Factors { get { return this.factors; } }

        public WorkingMemory(IList<Judgment> inputFactors)
        {
            this.factors = new JudgmentList(inputFactors);
        }

        public void AddFactor(Judgment factor)
        {
            this.factors.Add(factor);
        }

        public void AddRangeFactors(IList<Judgment> factors)
        {
            this.factors.AddRange(factors);
        }
    }
}
