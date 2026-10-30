using QATest;

public class TestSuite
{
    public string Name { get; set; }

    public List<TestCase> Tests { get; set; }

    public TestSuite(string name)
    {
        Name = name;
        Tests = new List<TestCase>();
    }

    public void AddTest(TestCase test)
    {
        Tests.Add(test);
    }

    public void RunAllTests()
    {
        foreach (TestCase test in Tests)
        {
            test.RunTest();
        }
    }

    public List<TestResult> GetResults()
    {
        List<TestResult> results = new();

        foreach (TestCase test in Tests)
        {
            results.Add(
                new TestResult(test.Name, test.Status));
        }

        return results;
    }

    public ExecutionStats GetStatistics()
    {
        ExecutionStats stats = new ExecutionStats();

        foreach (TestCase test in Tests)
        {
            if (test.Status == TestStatus.Passed)
            {
                stats.Passed++;
            }
            else if (test.Status == TestStatus.Failed)
            {
                stats.Failed++;
            }
            else if (test.Status == TestStatus.Blocked)
            {
                stats.Blocked++;
            }
            else
            {
                stats.NotRun++;
            }
        }

        return stats;
    }
}