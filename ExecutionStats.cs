using System;
using System.Collections.Generic;
using System.Text;

namespace QATest
{
    internal class ExecutionStats
    {
        public int Passed { get; set; }

        public int Failed { get; set; }

        public int Blocked { get; set; }

        public int NotRun { get; set; }
    }
}
