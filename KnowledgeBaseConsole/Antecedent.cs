using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Antecedent
    {
        private IList<JudgmentList> logicalExpressions = new List<JudgmentList>();

        public Antecedent AND(Judgment judgment)
        {
            JudgmentList andExpression = new JudgmentList(judgment);

            logicalExpressions.Add(andExpression);

            return this;
        }

        public Antecedent OR(params Judgment[] judgments)
        {
            JudgmentList orExpression = new JudgmentList(judgments);

            logicalExpressions.Add(orExpression);

            return this;
        }

        public bool Check(IList<Judgment> judgments)
        {
            Boolean isContains = false;

            foreach (JudgmentList expression in logicalExpressions)
            {
                if (expression.Count > 1)
                    isContains = expression.Any(ex => judgments.Contains(ex));
                else
                    isContains = judgments.Contains(expression.First);

                if (isContains == false)
                    break;
            }

            return isContains;
        }

        public bool CheckTitleAntecedent(IList<Judgment> judgments)
        {
            Boolean result = false;

            foreach (JudgmentList expression in logicalExpressions)
            {
                if (expression.Count > 1)
                    result = expression.Any(ex => judgments.Any(j => j.Name == ex.Name));
                else
                    result = judgments.Any(j => j.Name == expression.First.Name);

                if (result == false)
                    break;
            }

            return result;
        }

        public bool Contains(Judgment judgment)
        {
            return logicalExpressions.Any(le => le.Contains(judgment));
        }

        //public bool Contains(Judgment judgment)
        //{
        //    bool isContaint = false;
        //    foreach (KeyValuePair<int, IList<Judgment>> keyValue in logicalExpressions)
        //    {
        //        isContaint = keyValue.Value.Contains(judgment);
        //        if (isContaint)
        //            return isContaint;
        //    }

        //    return false;
        //}

        //public bool Contains(Judgment judgment)
        //{
        //    return logicalExpressions.Any(le => le.Value.Contains(judgment));
        //}
        //public bool ContainsAll(IList<Judgment> judgments)
        //{
        //    foreach (Judgment judgment in judgments)
        //        if (!Contains(judgment))
        //            return false;

        //    return true;
        //}


        //public override bool Equals(object obj)
        //{
        //    if (obj is JudgmentList)
        //    {
        //        JudgmentList judgmentList = obj as JudgmentList;

        //        foreach (Judgment currentJudgment in this.judgmentList)
        //        {
        //            Boolean hasJudgment = false;

        //            foreach (Judgment judgment in judgmentList)
        //                if (currentJudgment.Equals(judgment))
        //                {
        //                    hasJudgment = true;
        //                    break;
        //                }

        //            if (!hasJudgment)
        //                return false;
        //        }

        //        return true;
        //    }
        //    else
        //        throw new ArgumentException();
        //}

        //public override string ToString()
        //{
        //    string line = null;

        //    foreach (Judgment judgment in this.judgmentList)
        //    {
        //        line += judgment.ToString();
        //        if (this.judgmentList.Count > 1)
        //            line += ";    ";
        //    }

        //    return line;
        //}
        public List<Judgment> ToList()
        {
            List<Judgment> list = new List<Judgment>();

            foreach (var a  in logicalExpressions)
                foreach (Judgment judgment in a)
                    list.Add(judgment);

            return list;
        }
        public IList<JudgmentList> ToJudgmentList()
        {
            return logicalExpressions;
        }
    }
}
