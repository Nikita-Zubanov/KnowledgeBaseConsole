﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBaseConsole
{
    interface IVerification
    {
        Boolean IsVerified(IList<Rule> rules);
    }
}
