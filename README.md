QATest
A console-based QA Test Management application built in C# while working through The C# Player's Guide (5th Edition).

The purpose of this project is to practice object-oriented programming concepts and software design principles commonly found in QA automation frameworks.

---

Project Goals
This project simulates a basic software testing system that allows users to:

Create test cases
Organize tests into a suite
Execute tests using different test runners
View test results
Generate execution statistics
Practice object-oriented design in C#
The project was intentionally built incrementally to reinforce concepts learned through Chapters 1-30 of The C# Player's Guide.

---

Features
Test Management
Functional Tests
Performance Tests
Test Priorities
Test Status Tracking
Test Execution
Manual Test Runner
Automated Test Runner
Interface-driven execution workflow
Reporting
Test Results
Execution Summary
Passed / Failed / Blocked / Not Run statistics
Console UI
Interactive menu
Create tests at runtime
View tests
Run tests
View results
Architecture
Test Hierarchy
                TestCase (Abstract)
                       ▲
             ┌─────────┴─────────┐
             │                   │
      FunctionalTest      PerformanceTest
Why an Abstract Class?
All test types share:

Name
Priority
Status
The abstract TestCase class provides these common properties while forcing child classes to implement:

RunTest()
Test Runner Hierarchy
                 ITestRunner
                      ▲
          ┌───────────┴───────────┐
          │                       │
 ManualTestRunner      AutomatedTestRunner
Why an Interface?
The application should be able to execute tests without knowing how the runner works internally.

Both runners implement:

RunTests(TestSuite suite)
allowing implementations to be swapped with minimal code changes.

Test Suite
TestSuite
    └── List<TestCase>
Responsibilities:

Store tests
Execute tests
Generate results
Calculate execution statistics
C# Concepts Demonstrated
Object-Oriented Programming
Classes
Constructors
Properties
Methods
Encapsulation
Composition
Inheritance
Polymorphism
Abstract Classes
Interfaces
Collections
List
Examples:

List<TestCase>
List<TestResult>
Records
TestResult
public record TestResult(
    string TestName,
    TestStatus Status);
The project uses records to represent immutable test result data.

Structs
ExecutionStats
public struct ExecutionStats
{
    public int Passed { get; set; }
    public int Failed { get; set; }
    public int Blocked { get; set; }
    public int NotRun { get; set; }
}
The project uses a struct to represent lightweight statistical data.

Generics
Repository
public class Repository<T>
The project includes a custom generic repository to demonstrate creating reusable generic types.

Example Usage
Main Menu
=== QA Test System ===

1. View Tests
2. Run Tests
3. View Results
4. Add Test
0. Exit
Sample Report
=== Results ===

Login Test - Passed
Load Test - Blocked
Password Reset Test - Not Run

=== Summary ===

Passed: 1
Failed: 0
Blocked: 1
Not Run: 1
Project Structure
QATest
│
├── Program.cs
├── TestPriority.cs
├── TestStatus.cs
│
├── TestCase.cs
├── FunctionalTest.cs
├── PerformanceTest.cs
│
├── TestSuite.cs
│
├── TestResult.cs
├── ExecutionStats.cs
├── Repository.cs
│
├── ITestRunner.cs
├── ManualTestRunner.cs
└── AutomatedTestRunner.cs
What I Learned
Through this project I practiced:

Designing class hierarchies
Choosing between classes, abstract classes, interfaces, records, and structs
Creating reusable generic types
Applying polymorphism
Decoupling behavior using interfaces
Organizing a multi-file C# application
Building a simple domain model around software testing
Future Improvements
Potential enhancements include:

Persisting test results to files
Exporting reports
Adding unit tests with xUnit
Integrating Playwright for .NET
Logging test execution history
Tracking execution timestamps
Creating test categories and tags
Supporting API test cases
