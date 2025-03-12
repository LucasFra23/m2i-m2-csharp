using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Puissance4MAUI.Models;
using System.Collections.ObjectModel;

namespace Puissance4MAUI.ViewModels
{
    public partial class Puissance4ViewModel : ObservableObject
    {
        public ObservableCollection<Case> Board { get; } = new();

        private string _currentPlayer;

        [ObservableProperty]
        private string textDisplay;

        [ObservableProperty]
        private bool isGameOver;

        public Puissance4ViewModel()
        {
            CreateBoard();
        }

        private void CreateBoard()
        {
            Board.Clear();
            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    Board.Add(new Case(row, column));
                }
            }
            _currentPlayer = "Rouge";
            TextDisplay = $"Joueur actuel : {_currentPlayer}";
            IsGameOver = false;
        }

        [RelayCommand]
        private void DropToken(int column)
        {
            if (IsGameOver) return;

            for (int row = 5; row >= 0; row--)
            {
                var currentCase = Board[row * 7 + column];
                if (currentCase.Value == "")
                {
                    currentCase.UpdateValue(_currentPlayer);
                    if (CheckForWin())
                    {
                        TextDisplay = $"Partie terminée, le vainqueur est : {_currentPlayer}";
                        IsGameOver = true;
                    }
                    else if (IsBoardFull())
                    {
                        TextDisplay = "Partie terminée, égalité";
                        IsGameOver = true;
                    }
                    else
                    {
                        _currentPlayer = _currentPlayer == "Rouge" ? "Jaune" : "Rouge";
                        TextDisplay = $"Joueur actuel : {_currentPlayer}";
                    }
                    break;
                }
            }
        }

        private bool CheckForWin()
        {
            foreach (var cell in Board)
            {
                if (cell.Value != "")
                {
                    if (CheckHorizontal(cell.Row, cell.Column) || CheckVertical(cell.Row, cell.Column) || CheckDescendingDiagonal(cell.Row, cell.Column) || CheckAscendingDiagonal(cell.Row, cell.Column))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckHorizontal(int row, int column)
        {
            if (column > 3)
            {
                return false;
            }
            return Board[row * 7 + column].Value == _currentPlayer &&
                   Board[row * 7 + column + 1].Value == _currentPlayer &&
                   Board[row * 7 + column + 2].Value == _currentPlayer &&
                   Board[row * 7 + column + 3].Value == _currentPlayer;
        }

        private bool CheckVertical(int row, int column)
        {
            if (row > 2)
            {
                return false;
            }
            return Board[row * 7 + column].Value == _currentPlayer &&
                   Board[(row + 1) * 7 + column].Value == _currentPlayer &&
                   Board[(row + 2) * 7 + column].Value == _currentPlayer &&
                   Board[(row + 3) * 7 + column].Value == _currentPlayer;
        }

        private bool CheckDescendingDiagonal(int row, int column)
        {
            if (row > 2 || column > 3)
            {
                return false;
            }
            return Board[row * 7 + column].Value == _currentPlayer &&
                   Board[(row + 1) * 7 + column + 1].Value == _currentPlayer &&
                   Board[(row + 2) * 7 + column + 2].Value == _currentPlayer &&
                   Board[(row + 3) * 7 + column + 3].Value == _currentPlayer;
        }

        private bool CheckAscendingDiagonal(int row, int column)
        {
            if (row < 3 || column > 3)
            {
                return false;
            }
            return Board[row * 7 + column].Value == _currentPlayer &&
                   Board[(row - 1) * 7 + column + 1].Value == _currentPlayer &&
                   Board[(row - 2) * 7 + column + 2].Value == _currentPlayer &&
                   Board[(row - 3) * 7 + column + 3].Value == _currentPlayer;
        }

        private bool IsBoardFull()
        {
            foreach (var cell in Board)
            {
                if (cell.Value == "")
                {
                    return false;
                }
            }
            return true;
        }

        [RelayCommand]
        private void Restart()
        {
            CreateBoard();
        }
    }
}
