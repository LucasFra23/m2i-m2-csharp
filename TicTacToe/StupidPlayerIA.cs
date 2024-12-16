using CSharpFunctionalExtensions;

namespace TicTacToe;

internal class StupidPlayerIA : IPlayer
{
    public char icon { get; }

    public StupidPlayerIA(char icon)
    {
        this.icon = icon;
    }

    public Result<PlayerMoves> GetNextMove(List<Cell> grid)
    {
        //First cell available
        Cell cell = grid.First(c => c.IsEmpty);
        int targetRow = cell.Row;
        int targetColumn = cell.Column;

        //Random
        //int targetRow = random.Next(1, 4);
        //int targetColumn = random.Next(1, 4);

        return Result.Success(new PlayerMoves(targetRow, targetColumn));
    }
}