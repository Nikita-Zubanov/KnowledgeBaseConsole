using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Antecedent : Judgment
    {
        private IList<Judgment> judgments;

        public IList<Judgment> Judgments { get { return this.judgments; } }
            
        public Antecedent(FactorName name, EvaluationValue value) : base(name, value) 
        {
            this.judgments = new List<Judgment>();
        }

        public Antecedent(IList<Judgment> judgments)
        {
            this.judgments = judgments;
        }

        public new bool Equals(object obj)
        {
            if (obj is Judgment)
            {
                Antecedent antecedent = obj as Antecedent;

                foreach (Judgment currentJudgment in this.judgments)
                {
                    Boolean hasJudgment = false;

                    foreach (Judgment judgment in judgments)
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
    }
}
