using System.Reflection.Metadata.Ecma335;

namespace QATest;

class Program
{
    static void Main()
    {
        TestSuite suite = new TestSuite("Regression Suite");

        suite.AddTest(
            new FunctionalTest("Login Test", TestPriority.High));

        suite.AddTest(
            new PerformanceTest("Load Test", TestPriority.Critical));

        string? choice = DisplayMenu();

        if (choice == "1")
        {
            DisplayTests(suite);
        }
        else if (choice == "2")
        {
            ITestRunner runner = CreateRunner();
            RunTests(suite, runner);
        }
        else if (choice == "3")
        {
            DisplayResults(suite);
        }
    }

    static string? DisplayMenu()
    {
        Console.WriteLine("=== QA Test System ===");
        Console.WriteLine("1. View Tests");
        Console.WriteLine("2. Run Tests");
        Console.WriteLine("3. View Results");
        Console.WriteLine("0. Exit");

        Console.Write("Enter selection: ");

        string? choice = Console.ReadLine();

        Console.WriteLine();

        return choice;
    }

    static void DisplayTests(TestSuite suite)
    {
        Console.WriteLine($"Suite: {suite.Name}");
        Console.WriteLine();
        foreach (TestCase test in suite.Tests)
        {
            Console.WriteLine(
                $"{test.Name} - {test.Priority} - {test.Status}");
        }

    }

    static void RunTests(TestSuite suite, ITestRunner runner)
    {
              runner.RunTests(suite);
    }

    static ITestRunner CreateRunner()
    {
        Console.WriteLine("Select Runner Type");
        Console.WriteLine("1. Manual Runner");
        Console.WriteLine("2. Automated Runner");

        Console.Write("Selection: ");

        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            return new ManualTestRunner();
        }

        return new AutomatedTestRunner();
    }

    static void DisplayResults(TestSuite suite)
    {
        List<TestResult> results = suite.GetResults();

        Console.WriteLine("=== Results ===");

        foreach (TestResult result in results)
        {
            Console.WriteLine(
                $"{result.TestName} - {result.Status}");
        }
    }


};

