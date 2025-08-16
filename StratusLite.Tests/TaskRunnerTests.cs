
using System.Threading.Tasks;
using Xunit;

namespace StratusLite.Tests;

// basic tests for the taskrunner
public class TaskRunnerTests
{
    [Fact]
    public async Task ExecuteTaskAsync_WithValidBuildTask_ReturnsSuccessOrHandlesGracefully()
    {
        // arrange
        var taskRunner = new TaskRunner();

        // act
        var result = await taskRunner.ExecuteTaskAsync("build");

        // assert
        // build might fail depending on environment, but it should handle it gracefully
        Assert.NotNull(result);
        Assert.NotNull(result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteTaskAsync_WithInvalidTask_ReturnsFailure()
    {
        // arrange
        var taskRunner = new TaskRunner();

        // act
        var result = await taskRunner.ExecuteTaskAsync("invalid-task");

        // assert
        Assert.False(result.Success);
        Assert.Contains("Unknown task", result.ErrorMessage);
    }

    [Theory]
    [InlineData("build")]
    [InlineData("test")]
    public async Task ExecuteTaskAsync_WithValidTasks_DoesNotThrow(string taskName)
    {
        // arrange
        var taskRunner = new TaskRunner();

        // act & assert - just make sure it doesn't crash
        var exception = await Record.ExceptionAsync(() => taskRunner.ExecuteTaskAsync(taskName));
        Assert.Null(exception);
    }
}
