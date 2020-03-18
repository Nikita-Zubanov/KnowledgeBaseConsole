using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    abstract class Rule : IComparable
    {
        private JudgmentList antecedent;
        private Judgment consequent;

        public JudgmentList Antecedent { get { return this.antecedent; } }
        public Judgment Consequent { get { return this.consequent; } }

        public Rule(JudgmentList antecedent, Judgment consequent)
        {
            this.antecedent = antecedent;
            this.consequent = consequent;
        }

        public abstract void AddChildRule(Rule rule);
        public abstract IList<Rule> GetChildRules();

        public int CompareTo(object obj)
        {
            if (obj is Rule)
            {
                Rule rule = obj as Rule;

                if (rule.Antecedent.Judgments.Contains(this.consequent))
                    return 1;
                else if (this.antecedent.Judgments.Contains(rule.Consequent))
                    return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException();
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

            IEnumerator<Judgment> antecedentJudgments = this.antecedent.Judgments.GetEnumerator();
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
