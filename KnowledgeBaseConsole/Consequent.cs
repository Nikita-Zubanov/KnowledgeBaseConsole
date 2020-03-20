using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Consequent : Judgment
    {
        public Consequent(FactorName name, EvaluationValue value) : base(name, value) { }
    }
}
