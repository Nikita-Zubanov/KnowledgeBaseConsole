using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    interface IVerification
    {
        bool IsVerified(IList<Rule> rules);
    }
}
