# QATest

A console-based QA Test Management application built in C# while working through *The C# Player's Guide (5th Edition)*.

The purpose of this project is to practice object-oriented programming concepts and software design principles commonly found in QA automation frameworks.

---

## Project Goals

This project simulates a basic software testing system that allows users to:

- Create test cases
- Organize tests into a suite
- Execute tests using different test runners
- View test results
- Generate execution statistics
- Practice object-oriented design in C#

The project was intentionally built incrementally to reinforce concepts learned through Chapters 1-30 of *The C# Player's Guide*.

---

## Features

### Test Management

- Functional Tests
- Performance Tests
- Test Priorities
- Test Status Tracking

### Test Execution

- Manual Test Runner
- Automated Test Runner
- Interface-driven execution workflow

### Reporting

- Test Results
- Execution Summary
- Passed / Failed / Blocked / Not Run statistics

### Console UI

- Interactive menu
- Create tests at runtime
- View tests
- Run tests
- View results

---

# Architecture

## Test Hierarchy

```text
                TestCase (Abstract)
                       ▲
             ┌─────────┴─────────┐
             │                   │
      FunctionalTest      PerformanceTest
```

## Test Runner Hierarchy

```text
                 ITestRunner
                      ▲
          ┌───────────┴───────────┐
          │                       │
 ManualTestRunner      AutomatedTestRunner
```

## Test Suite

```text
TestSuite
    └── List<TestCase>
```

# C# Concepts Demonstrated

- Classes
- Constructors
- Properties
- Inheritance
- Polymorphism
- Abstract Classes
- Interfaces
- Records
- Structs
- Generics

# Author

**Todd Nason**
