using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    static class IListExtension
    {
        public static bool EqualsJugments(this IList<Judgment> judgments, object obj)
        {
            if (obj is IList<Judgment>)
            {
                IList<Judgment> antecedent = obj as IList<Judgment>;

                foreach (Judgment currentJudgment in judgments)
                {
                    Boolean hasJudgment = false;

                    foreach (Judgment itemAntecedent in antecedent)
                        if (currentJudgment.Equals(itemAntecedent))
                        {
                            hasJudgment = true;
                            break;
                        }

                    if (!hasJudgment)
                        return false;
                }

                return true;
            }
            else
                throw new ArgumentException();
        }
    }
    abstract class Rule : IComparable
    {
        private IList<Judgment> antecedent;
        private Judgment consequent;

        public IList<Judgment> Antecedent { get { return this.antecedent; } }
        public Judgment Consequent { get { return this.consequent; } }

        public Rule(IList<Judgment> antecedent, Judgment consequent)
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

                if (rule.Antecedent.Contains(this.consequent))
                    return 1;
                else if (this.antecedent.Contains(rule.Consequent))
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

                if (this.antecedent.EqualsJugments(rule.Antecedent) &&
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
