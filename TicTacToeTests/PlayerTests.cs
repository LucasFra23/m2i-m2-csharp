using CSharpFunctionalExtensions;
using FluentAssertions;
using TicTacToe;
using TicTacToe.Boards;

namespace TicTacToeTests
{
    public class PlayerTests
    {
        [Fact]
        public void TestRandomPlayerBehavior()
        {
            RandomPlayer player = new('X');
            Result<PlayerMove> result = player.GetNextMove();

            result.IsSuccess
                .Should()
                .BeTrue();

            result.Value.Row
                .Should()
                .BeInRange(1, 3);

            result.Value.Column
                .Should()
                .BeInRange(1, 3);
        }
    }
}