using CSharpFunctionalExtensions;
using TicTacToe.Boards;

namespace TicTacToe.Players;

//Classe pour tester les inputs de l'utilisateur
public class FakePlayer : Player
{
    public override char Icon { get; }

    private readonly Queue<PlayerMove> moves;

    public FakePlayer(char icon, Queue<PlayerMove> moves)
    {
        this.Icon = icon;
        this.moves = moves;
    }

    public async override Task<Result<PlayerMove>> GetNextMove()
    {
        if (this.moves.TryDequeue(out PlayerMove move))
        {
            return Result.Success(move);
        }
        return Result.Failure<PlayerMove>("No more moves available");
    }
}