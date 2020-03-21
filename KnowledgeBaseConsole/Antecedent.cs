using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Antecedent
    {
        private IList<Judgment> judgmentList;

        public IList<Judgment> JudgmentList { get { return this.judgmentList; } }

        public Antecedent(Judgment judgment)
        {
            this.judgmentList = new List<Judgment> { judgment };
        }

        public Antecedent(IList<Judgment> judgments)
        {
            this.judgmentList = judgments;
        }

        public override bool Equals(object obj)
        {
            if (obj is Antecedent)
            {
                Antecedent antecedent = obj as Antecedent;

                foreach (Judgment currentJudgment in this.JudgmentList)
                {
                    Boolean hasJudgment = false;

                    foreach (Judgment judgment in antecedent.JudgmentList)
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

            foreach (Judgment judgment in this.judgmentList)
            {
                toString += judgment.ToString();
                if (this.judgmentList.Count > 1)
                    toString += ";    ";
            }

            return toString;
        }
    }
}
