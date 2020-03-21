using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    class Consequent
    {
        private Judgment judgment;

        public Judgment Judgment { get { return this.judgment; } }

        public Consequent(Judgment judgment) 
        {
            this.judgment = judgment;
        }

        public override string ToString()
        {
            return this.judgment.ToString();
        }
    }
}
