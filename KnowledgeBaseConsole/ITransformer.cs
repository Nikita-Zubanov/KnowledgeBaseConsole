using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    interface ITransformer
    {
        void Transform(ref IList<Rule> rules);
    }
}
