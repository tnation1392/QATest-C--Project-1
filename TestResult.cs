using System;
using System.Collections.Generic;
using System.Text;

namespace QATest;

public record TestResult
(
    string TestName,
    TestStatus Status
);

