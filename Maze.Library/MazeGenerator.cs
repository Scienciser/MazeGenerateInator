using System.Data;

namespace Maze.Library;


public class MazeGenerator
{
    public Cell[][] Cells { get; }
    public int Width { get; }
    public int Height { get; }
    public Cell StartingCell { get; }
    public Cell EndingCell { get; }
    public List<Cell> Solution { get; }
    public Cell? PlayerPosition { get; private set; }

    private static Random rng = new Random();


    public MazeGenerator(int width, int height)
    {
        if (height <= 0 || width <= 0)
        {
            throw new ArgumentException("Invalid dimensions");
        }

        Width = width;
        Height = height;
        int size = width * height;

        // Bottom row cells should have no _bottomBorder, right row cells should have no _rightBorder
        Cells = Enumerable.Range(0, Height - 1)
            .Select(row => Enumerable.Range(0, Width - 1)
                .Select(col => new Cell(row, col))
                .Append(new Cell(row, Width - 1, true, false))
                .ToArray())
            .Append(
                Enumerable.Range(0, Width - 1).Select(col => new Cell(Height - 1, col, false, true))
                .Append(new Cell(Height - 1, Width - 1, false, false))
                .ToArray())
            .ToArray();
        StartingCell = Cells[Height / 2][0];
        EndingCell = Cells[Height / 2][Width - 1];

        var parentMap = GenerateMaze();
        Solution = GenerateSolution(parentMap);
    }


    private Dictionary<Cell, Cell> GenerateMaze()
    {
        // Randomised depth-first search
        var cellStack = new Stack<Cell>();
        var parentMap = new Dictionary<Cell, Cell>();
        cellStack.Push(StartingCell);
        while (cellStack.Any())
        {
            var currCell = cellStack.Pop();
            var lastCell = parentMap!.GetValueOrDefault(currCell, null);
            var nextEdges = new List<Cell>();
            if (!currCell._visited)
            {
                currCell._visited = true;
                if (lastCell != null)
                {
                    RemoveBorder(currCell, lastCell);
                }
                GoToCell(currCell.Row, currCell.Col - 1, currCell, nextEdges, parentMap); // Left
                GoToCell(currCell.Row, currCell.Col + 1, currCell, nextEdges, parentMap); // Right
                GoToCell(currCell.Row - 1, currCell.Col, currCell, nextEdges, parentMap); // Top
                GoToCell(currCell.Row + 1, currCell.Col, currCell, nextEdges, parentMap); // Bottom
                nextEdges = nextEdges.OrderBy(_ => rng.Next()).ToList();
                foreach (var cell in nextEdges)
                {
                    cellStack.Push(cell);
                }
                nextEdges.Clear();
                lastCell = currCell;
            }
        }

        return parentMap;
    }


    private void GoToCell(int targetRow, int targetCol, Cell parent, List<Cell> nextEdges, Dictionary<Cell, Cell> parentMap)
    {
        if (CellExists(targetRow, targetCol))
        {
            Cell targetCell = Cells[targetRow][targetCol];
            if (!targetCell._visited)
            {
                nextEdges.Add(targetCell);
                // Store parent of cell so can easily calculate solution later
                parentMap[targetCell] = parent;
            }
        }
    }


    private bool CellExists(int targetRow, int targetCol)
    {
        return targetRow >= 0 && targetRow < Height && targetCol >= 0 && targetCol < Width;
    }


    private void RemoveBorder(Cell c0, Cell c1)
    {
        if (c1.Col - c0.Col == 1) // c0 is left of c1
        {
            c0.RightBorder = false;
        }
        else if (c0.Col - c1.Col == 1) // c1 is left of c0
        {
            c1.RightBorder = false;
        }
        else if (c1.Row - c0.Row == 1) // c0 is above c1
        {
            c0.BottomBorder = false;
        }
        else if (c0.Row - c1.Row == 1) // c1 is above c0
        {
            c1.BottomBorder = false;
        }
    }


    private List<Cell> GenerateSolution(Dictionary<Cell, Cell> parentMap)
    {
        // Iterate backwards through dict of parent cells from EndingCell to StartingCell
        var res = new List<Cell>()
        {
            EndingCell
        };
        var curr = EndingCell;
        while (curr != StartingCell)
        {
            curr = parentMap[curr];
            res.Add(curr);
        }
        res.Reverse();
        return res;
    }


    public void EnableNavigation()
    {
        PlayerPosition = StartingCell;
    }


    public void DisableNavigation()
    {
        PlayerPosition = null;
    }


    public void PlayerTryMove(PlayerMoveDirection direction)
    {
        if (PlayerPosition == null) { return; }

        switch (direction)
        {
        case PlayerMoveDirection.UP:
            {
                if (CellExists(PlayerPosition.Row - 1, PlayerPosition.Col))
                {
                    var targetCell = Cells[PlayerPosition.Row - 1][PlayerPosition.Col];
                    if (!targetCell.BottomBorder)
                    {
                        PlayerPosition = targetCell;
                    }
                }
                break;
            }
        case PlayerMoveDirection.DOWN:
            {
                if (CellExists(PlayerPosition.Row + 1, PlayerPosition.Col) && !PlayerPosition.BottomBorder)
                {
                    PlayerPosition = Cells[PlayerPosition.Row + 1][PlayerPosition.Col];

                }
                break;
            }
        case PlayerMoveDirection.LEFT:
            {
                if (CellExists(PlayerPosition.Row, PlayerPosition.Col - 1))
                {
                    var targetCell = Cells[PlayerPosition.Row][PlayerPosition.Col - 1];
                    if (!targetCell.RightBorder)
                    {
                        PlayerPosition = targetCell;
                    }

                }
                break;
            }
        case PlayerMoveDirection.RIGHT:
            {
                if (CellExists(PlayerPosition.Row, PlayerPosition.Col + 1) && !PlayerPosition.RightBorder)
                {
                    PlayerPosition = Cells[PlayerPosition.Row][PlayerPosition.Col + 1];

                }
                break;
            }
        }
    }
}
