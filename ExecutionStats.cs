using System;
using System.Collections.Generic;
using System.Text;

namespace QATest
{
    public class ExecutionStats
    {
        public int Passed { get; set; }

        public int Failed { get; set; }

        public int Blocked { get; set; }

        public int NotRun { get; set; }
    }
}
