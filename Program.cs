using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace QATest;

class Program
{
    static void Main()
    {
        TestSuite suite = new TestSuite("Regression Suite");

        // existing test creation code

        bool running = true;

        while (running)
        {
            string? choice = DisplayMenu();

            if (choice == "0")
            {
                running = false;
            }
            else if (choice == "1")
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
            else if (choice == "4")
            {
                TestCase test = CreateTest();

                suite.AddTest(test);

                Console.WriteLine("Test added.");
            }

            Console.WriteLine();
        }
    }

    static string? DisplayMenu()
    {
        Console.WriteLine("=== QA Test System ===");
        Console.WriteLine("1. View Tests");
        Console.WriteLine("2. Run Tests");
        Console.WriteLine("3. View Results");
        Console.WriteLine("4. Add Test");
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

        int passedCount = 0;
        int failedCount = 0;
        int blockedCount = 0;
        int notRunCount = 0;

        foreach (TestResult result in results)
        {
            Console.WriteLine(
                $"{result.TestName} - {result.Status}");
            if (result.Status == TestStatus.Passed)
            {
                passedCount++;
            }
            else if (result.Status == TestStatus.Failed)
            {
                failedCount++;
            }
            else if (result.Status == TestStatus.Blocked)
            {
                blockedCount++;
            }
            else if (result.Status == TestStatus.NotRun)
            {
                notRunCount++;
            }

            Console.WriteLine();

            Console.WriteLine("=== Summary ===");
            Console.WriteLine($"Passed: {passedCount}");
            Console.WriteLine($"Failed: {failedCount}");
            Console.WriteLine($"Blocked: {blockedCount}");
            Console.WriteLine($"Not Run: {notRunCount}");
        }
    }

    static TestCase CreateTest()
    {
        Console.Write("Test Name: ");
        string? name = Console.ReadLine();

        Console.WriteLine("Test Type");
        Console.WriteLine("1. Functional");
        Console.WriteLine("2. Performance");

        Console.Write("Selection: ");
        string? testType = Console.ReadLine();

        Console.WriteLine("Priority");
        Console.WriteLine("1. Low");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. High");
        Console.WriteLine("4. Critical");

        Console.Write("Selection: ");
        string? priorityChoice = Console.ReadLine();

        TestPriority priority = TestPriority.Low;

        if (priorityChoice == "2")
        {
            priority = TestPriority.Medium;
        }
        else if (priorityChoice == "3")
        {
            priority = TestPriority.High;
        }
        else if (priorityChoice == "4")
        {
            priority = TestPriority.Critical;
        }

        if (testType == "2")
        {
            return new PerformanceTest(
                name ?? "Unnamed Test",
                priority);
        }

        return new FunctionalTest(
            name ?? "Unnamed Test",
            priority);
    }

};

