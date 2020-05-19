﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Antecedent
    {
        enum LogicalConnection
        {
            AND,
            OR
        }

        class JudgmentLine
        {
            LogicalConnection connection;
            IList<Judgment> judgments;

            public JudgmentLine(LogicalConnection connection, IList<Judgment> judgments)
            {
                this.connection = connection;
                this.judgments = judgments;
            }

            public bool IsTrue(IList<Judgment> judgments)
            {
                if (connection == LogicalConnection.AND)
                    return judgments.Contains(this.judgments.First());
                else if (connection == LogicalConnection.OR)
                    return this.judgments.Any(j => judgments.Contains(j));

                return false;
            }
            public bool IsCorrespondsButNotTrue(IList<Judgment> judgments)
            {
                if (connection == LogicalConnection.AND)
                    return judgments.Any(j => j.Title == this.judgments.First().Title);
                else if (connection == LogicalConnection.OR)
                    return this.judgments.Any(tj => judgments.Any(j => j.Title == tj.Title));

                return false;
            }

            public bool Contains(Judgment judgment)
            {
                return this.judgments.Contains(judgment);
            }
        }

        private IList<JudgmentLine> antecedent = new List<JudgmentLine>();

        public Antecedent AND(Judgment judgment)
        {
            JudgmentLine line = new JudgmentLine(LogicalConnection.AND, new List<Judgment> { judgment });

            antecedent.Add(line);

            return this;
        }
        public Antecedent OR(params Judgment[] judgments)
        {
            JudgmentLine line = new JudgmentLine(LogicalConnection.OR, judgments);

            antecedent.Add(line);

            return this;
        }

        public bool IsTrue(IList<Judgment> judgments)
        {
            Boolean isAllow = false;

            foreach (JudgmentLine judgmentLine in antecedent)
            {
                isAllow = judgmentLine.IsTrue(judgments);

                if (isAllow == false)
                    break;
            }

            return isAllow;
        }
        public bool IsCorrespondsButNotTrue(IList<Judgment> judgments)
        {
            Boolean isAllow = false;

            foreach (JudgmentLine judgmentLine in antecedent)
            {
                isAllow = judgmentLine.IsCorrespondsButNotTrue(judgments);

                if (isAllow == false)
                    break;
            }

            return isAllow;
        }

        public bool Contains(Judgment judgment)
        {
            return antecedent.Any(le => le.Contains(judgment));
        }

        public override string ToString()
        {
            string line = "";

            foreach (IList<Judgment> judgmentList in antecedent)
            {
                line += String.Format(" {0}: < ", judgmentList.Count > 1 ? "OR" : "AND");
                foreach (Judgment judgment in judgmentList)
                    line += String.Format("{0} — {1}; ", judgment.Title, judgment.FuzzyValue);
                line += "> ";
            }

            return line;
        }
    }
}
