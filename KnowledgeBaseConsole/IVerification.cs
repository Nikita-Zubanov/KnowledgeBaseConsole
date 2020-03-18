using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    interface IVerification
    {
        void Verify(IList<Rule> rules);
        Boolean IsVerified(IList<Rule> rules);
    }
}
