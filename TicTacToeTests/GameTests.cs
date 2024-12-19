using CSharpFunctionalExtensions;
using FluentAssertions;
using TicTacToe;
using TicTacToe.Boards;
using TicTacToe.Display;
using TicTacToe.Players;

namespace TicTacToeTests
{
    public class GameTests
    {
        [Fact]
        public void TestGame()
        {
            IDisplay display = new ConsoleDisplay();

            Queue<PlayerMove> movesPlayer1 = new();
            movesPlayer1.Enqueue(new PlayerMove(1, 1));
            movesPlayer1.Enqueue(new PlayerMove(2, 2));
            movesPlayer1.Enqueue(new PlayerMove(3, 3));

            Queue<PlayerMove> movesPlayer2 = new();
            movesPlayer2.Enqueue(new PlayerMove(1, 2));
            movesPlayer2.Enqueue(new PlayerMove(2, 3));

            IPlayer player1 = new FakePlayer('X', movesPlayer1);
            IPlayer player2 = new FakePlayer('O', movesPlayer2);

            Game game = new Game(display, player1, player2);

            game.currentPlayer
                .Should()
                .Be(player1);

            game.currentPlayer
                .Should()
                .NotBe(player2);
        }
    }
}