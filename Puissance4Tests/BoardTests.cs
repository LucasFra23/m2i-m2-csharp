using CSharpFunctionalExtensions;
using FluentAssertions;
using Puissance4;

namespace Puissance4Tests;

public class BoardTests
{
    [Fact]
    public void InitializeBoard()
    {
        // Arrange

        // Act
        Board board = new();

        // Assert
        board.Grid
            .Should()
            .NotBeNull();

        board.Grid.GetLength(0)
            .Should()
            .Be(6);

        board.Grid.GetLength(1)
            .Should()
            .Be(7);
    }

    [Fact]
    public void PlaceToken_ValidMove()
    {
        // Arrange
        Board board = new();

        // Act
        Result result = board.PlaceToken(1, 'X');

        // Assert
        result.Should()
            .Be(Result.Success());

        board.Grid[5, 0].Value
            .Should()
            .Be('X');
    }

    [Fact]
    public void PlaceToken_InvalidColumn()
    {
        // Arrange
        Board board = new();

        // Act
        Result result = board.PlaceToken(0, 'X');

        // Assert
        result.Should()
            .Be(Result.Failure("Invalid column"));
    }

    [Fact]
    public void PlaceToken_ColumnFull()
    {
        // Arrange
        Board board = new();

        // Act
        board.PlaceToken(1, 'X');
        board.PlaceToken(1, 'O');
        board.PlaceToken(1, 'X');
        board.PlaceToken(1, 'O');
        board.PlaceToken(1, 'X');
        board.PlaceToken(1, 'O');
        Result result = board.PlaceToken(1, 'X');

        // Assert
        result.Should()
            .Be(Result.Failure("Column is full"));
    }

    [Fact]
    public void IsBoardFull_FullBoard()
    {
        // Arrange
        Board board = new();

        // Act
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                board.Grid[i, j].UpdateValue('X');
            }
        }

        // Assert
        board.IsBoardFull()
            .Should()
            .BeTrue();
    }

    [Fact]
    public void IsBoardFull_EmptyBoard()
    {
        // Arrange
        Board board = new();

        // Act

        // Assert
        board.IsBoardFull()
            .Should()
            .BeFalse();
    }

    [Fact]
    public void CheckBoardWin_WinningConditions()
    {
        //Arrange
        Board board = new();

        //Act
        board.PlaceToken(1, 'R');
        board.PlaceToken(1, 'R');
        board.PlaceToken(1, 'R');
        board.PlaceToken(1, 'R');

        //Assert
        board.CheckWin()
            .Should()
            .BeTrue();
    }

    [Fact]
    public void CheckBoardWin_NoWinningConditions()
    {
        //Arrange
        Board board = new();

        //Act
        board.PlaceToken(1, 'R');
        board.PlaceToken(1, 'R');
        board.PlaceToken(1, 'R');

        //Assert
        board.CheckWin()
            .Should()
            .BeFalse();
    }
}