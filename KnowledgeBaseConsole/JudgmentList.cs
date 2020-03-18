using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class JudgmentList
    {
        private IList<Judgment> judgments;

        public IList<Judgment> Judgments { get { return this.judgments; } }

        public JudgmentList(Judgment judgment)
        {
            this.judgments = new List<Judgment> { judgment };
        }

        public JudgmentList(IList<Judgment> judgments) 
        {
            this.judgments = judgments;
        }

        public /*new*/ bool Equals(object obj)
        {
            if (obj is JudgmentList)
            {
                JudgmentList antecedent = obj as JudgmentList;

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
