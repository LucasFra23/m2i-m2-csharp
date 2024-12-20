using CSharpFunctionalExtensions;

namespace Puissance4;

public class Board
{
    public Cell[,] Grid { get; private set; }

    public Board()
    {
        Grid = new Cell[6, 7];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Grid[i, j] = Cell.EmptyCell(i, j);
            }
        }
    }

    public Result PlaceToken(int column, char token)
    {
        if (column < 1 || column > 7)
        {
            return Result.Failure("Invalid column");
        }
        for (int i = 5; i >= 0; i--)
        {
            if (Grid[i, column - 1].Value == null)
            {
                Grid[i, column - 1].UpdateValue(token);
                return Result.Success();
            }
        }
        return Result.Failure("Column is full");
    }

    public bool IsBoardFull()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (Grid[i, j].Value == null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool CheckWin()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (Grid[i, j].Value == null)
                {
                    continue;
                }
                if (CheckHorizontal(i, j) || CheckVertical(i, j) || CheckDiagonal(i, j))
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
        return Grid[row, column].Value == Grid[row, column + 1].Value &&
               Grid[row, column].Value == Grid[row, column + 2].Value &&
               Grid[row, column].Value == Grid[row, column + 3].Value;
    }

    private bool CheckVertical(int row, int column)
    {
        if (row > 2)
        {
            return false;
        }
        return Grid[row, column].Value == Grid[row + 1, column].Value &&
               Grid[row, column].Value == Grid[row + 2, column].Value &&
               Grid[row, column].Value == Grid[row + 3, column].Value;
    }

    private bool CheckDiagonal(int row, int column)
    {
        if (row > 2 || column > 3)
        {
            return false;
        }
        return Grid[row, column].Value == Grid[row + 1, column + 1].Value &&
               Grid[row, column].Value == Grid[row + 2, column + 2].Value &&
               Grid[row, column].Value == Grid[row + 3, column + 3].Value;
    }
}
