using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Judgment 
    {
        private FactorName name;
        private EvaluationValue value;

        public FactorName Name { get { return this.name; } }
        public EvaluationValue Value { get { return this.value; } }

        public Judgment(FactorName name, EvaluationValue value)
        {
            this.name = name;
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Judgment)
            {
                Judgment judgment = obj as Judgment;

                if (this.name == judgment.name &&
                    this.value == judgment.value)
                    return true;
                else
                    return false;
            }
            else
                throw new ArgumentException();
        }

        public void Print()
        {
            Console.WriteLine("\t {0}", this.ToString());
        }

        public override string ToString()
        {
            return String.Format("{0} — {1}", this.name.ToString(), this.value.ToString());
        }
    }
}
