using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class LinguisticVariable
    {
        public FactorTitle Title { get; private set; }
        public IList<FactorFuzzyValue> FuzzyValues { get; private set; }

        public LinguisticVariable(FactorTitle title, params FactorFuzzyValue[] fuzzyValues)
        {
            Title = title;
            FuzzyValues = fuzzyValues;
        }

        public void AddFuzzyValue(FactorFuzzyValue fuzzyValue)
        {
            FuzzyValues.Add(fuzzyValue);
        }
        public void AddMissingFuzzyValue(IList<FactorFuzzyValue> fuzzyValues)
        {
            foreach (FactorFuzzyValue fuzzyValue in fuzzyValues)
                if (!FuzzyValues.Contains(fuzzyValue))
                    AddFuzzyValue(fuzzyValue);
        }
    }
}
