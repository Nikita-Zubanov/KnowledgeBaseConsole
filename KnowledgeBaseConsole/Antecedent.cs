using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Antecedent : IEnumerable<Judgment>
    {
        private IList<Judgment> judgments;

        public IList<Judgment> Judgments { get { return this.judgments; } }

        public Antecedent(Judgment judgment)
        {
            this.judgments = new List<Judgment> { judgment };
        }

        public Antecedent(IList<Judgment> judgments)
        {
            this.judgments = judgments;
        }

        public override bool Equals(object obj)
        {
            if (obj is Antecedent)
            {
                Antecedent antecedent = obj as Antecedent;

                foreach (Judgment currentJudgment in this.judgments)
                {
                    Boolean hasJudgment = false;

                    foreach (Judgment judgment in antecedent)
                        if (currentJudgment.Equals(judgment))
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

        public override string ToString()
        {
            string toString = null;

            foreach (Judgment judgment in this.judgments)
            {
                toString += judgment.ToString();
                if (this.judgments.Count > 1)
                    toString += ";    ";
            }

            return toString;
        }

        public bool Contains(object obj)
        {
            if (obj is Judgment)
            {
                Judgment judgment = obj as Judgment;

                if (this.judgments.Contains(judgment))
                    return true;
                else
                    return false;

            }
            else
                throw new ArgumentException();
        }

        public IEnumerator<Judgment> GetEnumerator()
        {
            return this.judgments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.judgments.GetEnumerator();
        }
    }
}
