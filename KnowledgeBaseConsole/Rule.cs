using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    abstract class Rule 
    {
        private Antecedent antecedent;
        private Consequent consequent;

        public Antecedent Antecedent { get { return this.antecedent; } }
        public Consequent Consequent { get { return this.consequent; } }

        public Rule(Antecedent antecedent, Consequent consequent)
        {
            this.antecedent = antecedent;
            this.consequent = consequent;
        }

        public abstract void AddChildRule(Rule rule);
        public abstract IList<Rule> GetChildRules();

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

            IEnumerator<Judgment> antecedentJudgments = this.antecedent.GetEnumerator();
            while (antecedentJudgments.MoveNext())
            {
                Judgment antecedentudgment = antecedentJudgments.Current;
                antecedentudgment.Print();
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
