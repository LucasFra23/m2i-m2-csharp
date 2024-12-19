using FluentAssertions;
using TicTacToe.Boards;
using TicTacToe.Display;
using TicTacToe.Players;

namespace TicTacToeTests;

public class BoardTests
{
    [Fact]
    public void TestInvalidMove()
    {
        Board board = new(new ConsoleDisplay());
        board.PlayMoveOnBoard(new(1, 1), 'X');
        board.PlayMoveOnBoard(new(1, 1), 'O')
            .Should()
            .BeFalse();
    }

    [Fact]
    public void TestValidMove()
    {
        Board board = new(new ConsoleDisplay());
        board.PlayMoveOnBoard(new(1, 1), 'X')
            .Should()
            .BeTrue();
    }

    [Fact]
    public void TestWinningLine()
    {
        Board board = new(new ConsoleDisplay());

        board.PlayMoveOnBoard(new(1, 1), 'X');
        board.PlayMoveOnBoard(new(2, 1), 'X');
        board.PlayMoveOnBoard(new(3, 1), 'X');

        board.IsGameOver(new HumanPlayer('X'))
            .HasValue
            .Should()
            .BeTrue();
    }

    [Fact]
    public void TestWinningColumn()
    {
        Board board = new(new ConsoleDisplay());
        board.PlayMoveOnBoard(new(1, 1), 'X');
        board.PlayMoveOnBoard(new(1, 2), 'X');
        board.PlayMoveOnBoard(new(1, 3), 'X');
        board.IsGameOver(new HumanPlayer('X'))
            .HasValue
            .Should()
            .BeTrue();
    }

    [Fact]
    public void TestWinningDiagonal()
    {
        Board board = new(new ConsoleDisplay());

        board.PlayMoveOnBoard(new(1, 1), 'X');
        board.PlayMoveOnBoard(new(2, 2), 'X');
        board.PlayMoveOnBoard(new(3, 3), 'X');

        board.IsGameOver(new HumanPlayer('X'))
            .HasValue
            .Should()
            .BeTrue();
    }

    [Fact]
    public void TestDraw()
    {
        Board board = new(new ConsoleDisplay());

        board.PlayMoveOnBoard(new(1, 1), 'X');
        board.PlayMoveOnBoard(new(1, 2), 'O');
        board.PlayMoveOnBoard(new(1, 3), 'X');
        board.PlayMoveOnBoard(new(2, 1), 'O');
        board.PlayMoveOnBoard(new(2, 2), 'X');
        board.PlayMoveOnBoard(new(2, 3), 'O');
        board.PlayMoveOnBoard(new(3, 1), 'O');
        board.PlayMoveOnBoard(new(3, 2), 'X');
        board.PlayMoveOnBoard(new(3, 3), 'O');

        board.IsGameOver(new HumanPlayer('X'))
            .HasValue
            .Should()
            .BeTrue();
    }
}