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

    public override Result<PlayerMove> GetNextMove()
        => moves.Dequeue();
}