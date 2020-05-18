using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnowledgeBaseConsole
{
    abstract class Rule 
    {
        private LinguisticVariable linguisticVariable;
        private Antecedent antecedent;
        private Judgment consequent;
        private Judgment other;

        public LinguisticVariable LinguisticVariable { get { return this.linguisticVariable; } }
        public Antecedent Antecedent { get { return this.antecedent; } }
        public Judgment Consequent { get { return this.consequent; } }
        public Judgment Other { get { return this.other; } }

        public Rule(LinguisticVariable linguisticVariable, Antecedent antecedent, Judgment consequent) : this(linguisticVariable, antecedent, consequent, null) { }
        public Rule(LinguisticVariable linguisticVariable, Antecedent antecedent, Judgment consequent, Judgment other)
        {
            this.linguisticVariable = linguisticVariable;
            this.antecedent = antecedent;
            this.consequent = consequent;
            this.other = other;
        }

        public abstract void AddChildRule(Rule rule);
        public abstract void AddChildRules(IList<Rule> rules);
        public abstract IList<Rule> GetChildRules();
        //public abstract void AddOtherRule(Rule rule);
        //public abstract IList<Rule> GetOtherRules();

        public bool CheckAntecedent(IList<Judgment> judgments)
        {
            return Antecedent.Check(judgments);
        }
        public bool CheckTitleAntecedent(IList<Judgment> judgments)
        {
            return Antecedent.CheckTitleAntecedent(judgments);
        }

        public override bool Equals(object obj)
        {
            if (obj is Rule)
            {
                Rule rule = obj as Rule;

                if (this.antecedent.Equals(rule.Antecedent) &&
                    this.consequent.Equals(rule.Consequent))
                    return true;
                else
                    return false;
            }
            else
                throw new NullReferenceException();
        }

        public void Print()
        {
            Console.WriteLine("————————————————————————————————————————");
            Console.WriteLine("Правило");
            Console.WriteLine("————————————————————————————————————————");
            Console.WriteLine("Aнтецедент(-ы):");

            IEnumerator<Judgment> antecedentEnumerator = this.antecedent.ToList().GetEnumerator();
            while (antecedentEnumerator.MoveNext())
            {
                Judgment antecedentJudgment = antecedentEnumerator.Current;
                antecedentJudgment.Print();
            }

            Console.WriteLine("Консеквент:");
            this.consequent.Print();
            Console.WriteLine("————————————————————————————————————————\n\n");
        }

        public override string ToString()
        {
            return this.consequent.ToString();
        }
    }
}
