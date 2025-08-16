
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace StratusLite;

// handles running the actual tasks
public class TaskRunner
{
    public async Task<TaskResult> ExecuteTaskAsync(string taskName)
    {
        return taskName switch
        {
            "build" => await ExecuteBuildTaskAsync(),
            "test" => await ExecuteTestTaskAsync(),
            _ => new TaskResult(false, $"Unknown task: {taskName}")
        };
    }

    private async Task<TaskResult> ExecuteBuildTaskAsync()
    {
        Console.WriteLine(" building stuff...");
        
        // gotta restore first, then build
        var restoreResult = await ExecuteCommandAsync("dotnet", "restore");
        if (!restoreResult.Success)
        {
            return new TaskResult(false, $"Restore failed: {restoreResult.ErrorMessage}");
        }

        var buildResult = await ExecuteCommandAsync("dotnet", "build");
        if (!buildResult.Success)
        {
            return new TaskResult(false, $"Build failed: {buildResult.ErrorMessage}");
        }

        return new TaskResult(true, "Build completed successfully");
    }

    private async Task<TaskResult> ExecuteTestTaskAsync()
    {
        Console.WriteLine(" running tests...");
        
        // using --no-build since we assume build was run first
        var testResult = await ExecuteCommandAsync("dotnet", "test --no-build");
        if (!testResult.Success)
        {
            return new TaskResult(false, $"Tests failed: {testResult.ErrorMessage}");
        }

        return new TaskResult(true, "Tests completed successfully");
    }

    // this does the actual work - running shell commands
    private async Task<TaskResult> ExecuteCommandAsync(string command, string arguments)
    {
        try
        {
            var processInfo = CreateProcessStartInfo(command, arguments);
            
            Console.WriteLine($"  running: {command} {arguments}");
            
            using var process = new Process { StartInfo = processInfo };
            
            process.Start();
            
            // read both output and error streams
            var outputTask = process.StandardOutput.ReadToEndAsync();
            var errorTask = process.StandardError.ReadToEndAsync();
            
            await process.WaitForExitAsync();
            
            var output = await outputTask;
            var error = await errorTask;
            
            // show the output if there's any
            if (!string.IsNullOrWhiteSpace(output))
            {
                Console.WriteLine(output);
            }
            
            if (process.ExitCode == 0)
            {
                return new TaskResult(true, "Command executed successfully");
            }
            else
            {
                var errorMessage = !string.IsNullOrWhiteSpace(error) ? error : $"Process exited with code {process.ExitCode}";
                Console.WriteLine($" {errorMessage}");
                return new TaskResult(false, errorMessage);
            }
        }
        catch (Exception ex)
        {
            return new TaskResult(false, $"Failed to execute command: {ex.Message}");
        }
    }

    // figured out the windows vs unix differences here
    private static ProcessStartInfo CreateProcessStartInfo(string command, string arguments)
    {
        var processInfo = new ProcessStartInfo
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        // windows uses cmd, everything else uses bash
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            processInfo.FileName = "cmd.exe";
            processInfo.Arguments = $"/c {command} {arguments}";
        }
        else
        {
            processInfo.FileName = "/bin/bash";
            processInfo.Arguments = $"-c \"{command} {arguments}\"";
        }

        return processInfo;
    }
}

// simple result object to track success/failure
public record TaskResult(bool Success, string ErrorMessage = "");
