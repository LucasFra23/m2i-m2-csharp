using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace TicTacToe;

public class RandomPlayer : Player
{
    public override char Icon { get; }

    public RandomPlayer(char icon)
    {
        this.Icon = icon;
    }

    public async override Task<Result<PlayerMove>> GetNextMove()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                Console.Write($"Player {Icon} is thinking");
            }
            Console.Write(".");
            await Task.Delay(1000); // Délai de 1 seconde
        }
        return Result.Success(PlayerMove.Random);
    }

}