
using System;
using System.Threading.Tasks;

namespace StratusLite;

// simple automation tool - nothing too fancy
class Program
{
    static async Task<int> Main(string[] args)
    {
        Console.WriteLine("stratuslite - simple automation");
        Console.WriteLine("================================");

        if (args.Length == 0)
        {
            ShowUsage();
            return 1;
        }

        var taskName = args[0].ToLowerInvariant();
        var taskRunner = new TaskRunner();

        try
        {
            var result = await taskRunner.ExecuteTaskAsync(taskName);
            
            if (result.Success)
            {
                Console.WriteLine($"\n task '{taskName}' done!");
                return 0;
            }
            else
            {
                Console.WriteLine($"\n task '{taskName}' didn't work");
                Console.WriteLine($"Error: {result.ErrorMessage}");
                return 1;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n something went wrong: {ex.Message}");
            return 1;
        }
    }

    private static void ShowUsage()
    {
        Console.WriteLine("\nUsage: dotnet run -- <task>");
        Console.WriteLine("\nAvailable tasks:");
        Console.WriteLine("  build  - Restore dependencies and build the project");
        Console.WriteLine("  test   - Run tests (requires build first)");
        Console.WriteLine("\nExamples:");
        Console.WriteLine("  dotnet run -- build");
        Console.WriteLine("  dotnet run -- test");
    }
}
