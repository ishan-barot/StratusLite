
# StratusLite

> A minimal but professional C#/.NET automation tool demonstrating process orchestration and cross-platform compatibility.

## Overview

StratusLite is a lightweight automation tool built with C# and .NET 8 that showcases professional software development practices including:

- **Process Orchestration**: Uses `Process.Start` for reliable command execution
- **Cross-Platform Support**: Runs seamlessly on Linux, Windows, and macOS
- **Professional Error Handling**: Comprehensive error management and user feedback
- **CI/CD Integration**: Self-testing pipeline using the tool itself (dogfooding)
- **Clean Architecture**: Well-structured, testable, and maintainable code

## Features

- **Two Core Automation Tasks**:
  - `build`: Executes `dotnet restore && dotnet build`
  - `test`: Executes `dotnet test --no-build`
- **Real-time Output**: Live command output with professional formatting
- **Robust Error Handling**: Detailed error messages and exit codes
- **Cross-Platform Shell Execution**: Adapts to Windows CMD and Unix Bash
- **Comprehensive Testing**: Unit tests with xUnit framework

## Installation

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

### Quick Start
```bash
# Clone the repository
git clone https://github.com/yourusername/StratusLite.git
cd StratusLite

# Build the project
dotnet build

# Run automation tasks
dotnet run -- build
dotnet run -- test
```

## Usage

### Command Syntax
```bash
dotnet run -- <task>
```

### Available Tasks

#### Build Task
Restores NuGet packages and builds the solution:
```bash
dotnet run -- build
```

#### Test Task
Runs all unit tests (requires build first):
```bash
dotnet run -- test
```

### Example Output
```
StratusLite v1.0 - Automation Tool
===================================
Starting build task...
Executing: dotnet restore
  Determining projects to restore...
  Restored /path/to/StratusLite.csproj (in 1.2s)
Executing: dotnet build
  Building...
  StratusLite -> /path/to/bin/Debug/net8.0/StratusLite.dll

Task 'build' completed successfully!
```

## Architecture

### Core Components

- **`Program.cs`**: Entry point with argument parsing and user interface
- **`TaskRunner.cs`**: Process orchestration engine with cross-platform support
- **`TaskResult.cs`**: Result model for task execution outcomes

### Key Design Patterns

- **Command Pattern**: Task execution abstraction
- **Strategy Pattern**: Cross-platform process creation
- **Async/Await**: Non-blocking I/O operations
- **Record Types**: Immutable result objects

## Testing

The project includes comprehensive unit tests:

```bash
# Run tests directly
dotnet test

# Run tests using StratusLite
dotnet run -- test
```

### Test Coverage
- Task execution validation
- Error handling scenarios
- Cross-platform compatibility
- Invalid input handling

## CI/CD Pipeline

StratusLite includes a GitHub Actions workflow that demonstrates:

- **Self-Testing**: Uses the tool itself for build and test automation
- **Cross-Platform Validation**: Tests on Ubuntu, Windows, and macOS
- **Automated Quality Gates**: Ensures code quality on every commit

The pipeline runs on:
- Push to `main` or `develop` branches
- Pull requests to `main`

## Professional Highlights

This project demonstrates several key software development skills:

### Technical Skills
- **C# Process Management**: Advanced use of `Process.Start` and async I/O
- **Cross-Platform Development**: Runtime detection and shell adaptation
- **Error Handling**: Comprehensive exception management and user feedback
- **Unit Testing**: Test-driven development with xUnit framework

### DevOps Skills
- **CI/CD Pipeline**: GitHub Actions with multi-platform testing
- **Dogfooding**: Using the tool to build and test itself
- **Documentation**: Professional README with clear usage examples

### Software Engineering
- **Clean Code**: SOLID principles and readable implementation
- **Project Structure**: Professional .NET solution organization
- **Version Control**: Git best practices with meaningful commits

## Project Statistics

- **Core Logic**: ~50 lines of focused automation code
- **Total Project**: ~200 lines including tests and documentation
- **Dependencies**: Minimal - only .NET 8 and xUnit for testing
- **Platforms**: Linux, Windows, macOS support verified

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🔗 Links

- [.NET Documentation](https://docs.microsoft.com/dotnet/)
- [Process Class Documentation](https://docs.microsoft.com/dotnet/api/system.diagnostics.process)
- [xUnit Testing Framework](https://xunit.net/)

---

**StratusLite** - Demonstrating professional automation with minimal complexity.
