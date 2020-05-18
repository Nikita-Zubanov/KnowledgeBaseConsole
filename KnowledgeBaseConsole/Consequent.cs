using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Consequent : Judgment
    {
        public Consequent(FactorTitle title, FactorFuzzyValue fuzzyValue) : base(title, fuzzyValue) { }
    }
}
