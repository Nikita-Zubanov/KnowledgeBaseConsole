using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class JudgmentList : IEnumerable<Judgment>
    {
        private IList<Judgment> judgmentList;

        public int Count { get { return judgmentList.Count; } }
        public Judgment First { get { return judgmentList[0]; } }

        public JudgmentList(Judgment judgment)
        {
            this.judgmentList = new List<Judgment> { judgment };
        }

        public JudgmentList(IList<Judgment> judgments)
        {
            this.judgmentList = judgments;
        }

        public IEnumerator<Judgment> GetEnumerator()
        {
            return this.judgmentList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(Judgment judgment)
        {
            this.judgmentList.Add(judgment);
        }
        public void AddRange(IList<Judgment> judgments)
        {
            foreach (Judgment judgment in judgments)
                this.judgmentList.Add(judgment);
        }

        public bool Contains(Judgment judgment)
        {
            return this.judgmentList.Contains(judgment);
        }
        public bool ContainsAll(IList<Judgment> judgments)
        {
            foreach (Judgment judgment in judgments)
                if (!this.judgmentList.Contains(judgment))
                    return false;

            return true;
        }
        public bool ContainsAny(IList<Judgment> judgments)
        {
            bool result = false;

            foreach (Judgment judgment in judgments)
                if (this.judgmentList.Contains(judgment))
                    result = true;

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is JudgmentList)
            {
                JudgmentList judgmentList = obj as JudgmentList;

                foreach (Judgment currentJudgment in this.judgmentList)
                {
                    Boolean hasJudgment = false;

                    foreach (Judgment judgment in judgmentList)
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
            string line = null;

            foreach (Judgment judgment in this.judgmentList)
            {
                line += judgment.ToString();
                if (this.judgmentList.Count > 1)
                    line += ";    ";
            }

            return line;
        }
        public List<Judgment> ToList()
        {
            List<Judgment> list = new List<Judgment>();

            foreach (Judgment judgment in judgmentList)
                list.Add(judgment);

            return list;
        }
    }
}
