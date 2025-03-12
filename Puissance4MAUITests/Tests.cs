using CSharpFunctionalExtensions;
using FluentAssertions;
using Puissance4MAUI.ViewModels;

namespace Puissance4MAUITests
{
    public class Tests
    {
        [Fact]
        public void InitBoard()
        {
            Puissance4ViewModel vm = new();
            vm.Board.Should().NotBeNull();
            vm.Board.Count.Should().Be(42);
        }

        [Fact]
        public void DropToken()
        {
            Puissance4ViewModel vm = new();
            vm.DropToken(0);
            vm.Board[35].Value.Should().Be("Rouge");
            vm.TextDisplay.Should().Be("Joueur actuel : Jaune");
        }

        [Fact]
        public void Test_Win_Vertical()
        {
            Puissance4ViewModel vm = new();
            vm.DropToken(0);
            vm.DropToken(1);
            vm.DropToken(0);
            vm.DropToken(1);
            vm.DropToken(0);
            vm.DropToken(1);
            vm.DropToken(0);
            vm.TextDisplay.Should().Be("Partie terminée, le vainqueur est : Rouge");
            vm.IsGameOver.Should().BeTrue();
        }

        [Fact]
        public void Test_Win_Horizontal()
        {
            Puissance4ViewModel vm = new();
            vm.DropToken(0);
            vm.DropToken(0);
            vm.DropToken(1);
            vm.DropToken(1);
            vm.DropToken(2);
            vm.DropToken(2);
            vm.DropToken(3);
            vm.TextDisplay.Should().Be("Partie terminée, le vainqueur est : Rouge");
            vm.IsGameOver.Should().BeTrue();
        }

        [Fact]
        public void Test_Win_Diagonal_Ascending()
        {
            Puissance4ViewModel vm = new();
            vm.DropToken(0);
            vm.DropToken(1);
            vm.DropToken(1);
            vm.DropToken(2);
            vm.DropToken(2);
            vm.DropToken(3);
            vm.DropToken(2);
            vm.DropToken(3);
            vm.DropToken(3);
            vm.DropToken(5);
            vm.DropToken(3);
            vm.TextDisplay.Should().Be("Partie terminée, le vainqueur est : Rouge");
            vm.IsGameOver.Should().BeTrue();
        }

        [Fact]
        public void Test_Win_Diagonal_Descending()
        {
            Puissance4ViewModel vm = new();
            vm.DropToken(0);
            vm.DropToken(0);
            vm.DropToken(0);
            vm.DropToken(0);
            vm.DropToken(1);
            vm.DropToken(1);
            vm.DropToken(2);
            vm.DropToken(1);
            vm.DropToken(4);
            vm.DropToken(2);
            vm.DropToken(4);
            vm.DropToken(3);
            vm.TextDisplay.Should().Be("Partie terminée, le vainqueur est : Jaune");
            vm.IsGameOver.Should().BeTrue();
        }

        [Fact]
        public void Test_Draw()
        {
            int[] dropOrder = {
                3, 2, 4, 5, 1, 0, 6,
                3, 4, 2, 1, 5, 6, 0,
                6, 5, 4, 3, 2, 1, 0,
                0, 1, 2, 3, 4, 5, 6,
                3, 2, 5, 4, 1, 0, 6,
                6, 5, 4, 3, 2, 1, 0
            };
            Puissance4ViewModel vm = new();
            for (int i = 0; i < dropOrder.GetLength(0); i++)
            {
                vm.DropToken(dropOrder[i]);
            }
            vm.TextDisplay.Should().Be("Partie terminée, égalité");
            vm.IsGameOver.Should().BeTrue();
        }
    }
}