using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class JudgmentList : IEnumerable<Judgment>
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

        public override bool Equals(object obj)
        {
            if (obj is JudgmentList)
            {
                JudgmentList antecedent = obj as JudgmentList;

                foreach (Judgment currentJudgment in this.judgments)
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

        public IList<Judgment> ToList()
        {
            return this.judgments;
        }

        public void Add(Judgment judgment)
        {
            this.judgments.Add(judgment);
        }

        public void AddRange(IList<Judgment> judgments)
        {
            foreach (Judgment judgment in judgments)
                this.judgments.Add(judgment);
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
