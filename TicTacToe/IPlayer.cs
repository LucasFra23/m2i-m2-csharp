using CSharpFunctionalExtensions;

namespace TicTacToe
{
    internal interface IPlayer
    {
        public Result<PlayerMoves> GetNextMove(List<Cell> grid);
        public char icon { get; }
    }
}
