using Xunit;

public class GuessGameTests
{
    [Fact]
    public void Correct_Guess_Should_Return_YouWin()
    {
        // Arrange
        var game = new GuessGame(numberToGuess: 5, maxAttempts: 3);

        // Act
        var result = game.ProcessGuess(5);

        // Assert
        Assert.True(game.IsCorrect);
        Assert.Equal("You win!", result);
        Assert.True(game.IsGameOver);

    }

    [Fact]
    public void Wrong_Guess_Should_Return_WrongNumber()
    {
        // Arrange
        var game = new GuessGame(numberToGuess: 5, maxAttempts: 3);

        // Act
        var result = game.ProcessGuess(1);

        // Assert
        Assert.False(game.IsCorrect);
        Assert.Equal("Wrong number", result);
        Assert.False(game.IsGameOver);
    }

    [Fact]
    public void Last_Wrong_Attempt_Should_Return_WrongNumber_And_YouLose()
    {
        // Arrange
        var game = new GuessGame(numberToGuess: 5, maxAttempts: 1);

        // Act
        var result = game.ProcessGuess(2);

        // Assert
        Assert.Equal("Wrong number\nYou lose!", result);
        Assert.True(game.IsGameOver);
        Assert.False(game.IsCorrect);
    }

    [Fact]
    public void Game_Should_End_After_Max_Attempts()
    {
        // Arrange
        var game = new GuessGame(numberToGuess: 3, maxAttempts: 2);

        // Act
        game.ProcessGuess(1); // attempt 1
        game.ProcessGuess(2); // attempt 2

        // Assert
        Assert.True(game.IsGameOver);
        Assert.False(game.IsCorrect);
    }

    [Fact]
    public void Guess_After_Win_Should_Not_Change_State()
    {
        // Arrange
        var game = new GuessGame(numberToGuess: 4, maxAttempts: 3);

        // Act
        var first = game.ProcessGuess(4);     // Win
        var second = game.ProcessGuess(1);    // Should not change anything

        // Assert
        Assert.True(game.IsCorrect);
        Assert.Equal("You win!", first);
        Assert.True(game.IsGameOver);
    }
}
