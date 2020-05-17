using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    interface ITransformer
    {
        void Transform(IList<Rule> rules);
    }
}
