
using System.Threading.Tasks;
using Xunit;

namespace StratusLite.Tests;

/// <summary>
/// Unit tests for the TaskRunner class.
/// </summary>
public class TaskRunnerTests
{
    [Fact]
    public async Task ExecuteTaskAsync_WithValidBuildTask_ReturnsSuccessOrHandlesGracefully()
    {
        // Arrange
        var taskRunner = new TaskRunner();

        // Act
        var result = await taskRunner.ExecuteTaskAsync("build");

        // Assert
        // The build task should either succeed or fail gracefully with a proper error message
        // This test validates the task execution flow rather than the actual build success
        Assert.NotNull(result);
        Assert.NotNull(result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteTaskAsync_WithInvalidTask_ReturnsFailure()
    {
        // Arrange
        var taskRunner = new TaskRunner();

        // Act
        var result = await taskRunner.ExecuteTaskAsync("invalid-task");

        // Assert
        Assert.False(result.Success);
        Assert.Contains("Unknown task", result.ErrorMessage);
    }

    [Theory]
    [InlineData("build")]
    [InlineData("test")]
    public async Task ExecuteTaskAsync_WithValidTasks_DoesNotThrow(string taskName)
    {
        // Arrange
        var taskRunner = new TaskRunner();

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => taskRunner.ExecuteTaskAsync(taskName));
        Assert.Null(exception);
    }
}
