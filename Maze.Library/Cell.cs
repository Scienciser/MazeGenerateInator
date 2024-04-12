namespace Maze.Library;


public class Cell
{
    public int Row { get; }
    public int Col { get; }
    // Left border is _rightBorder of Cell to left
    // Top border is _bottomBorder of Cell above
    public bool BottomBorder { get; set; }
    public bool RightBorder { get; set; }

    internal bool _visited = false;


    internal Cell(int row, int col)
    {
        Row = row;
        Col = col;
        BottomBorder = true;
        RightBorder = true;
    }


    internal Cell(int row, int col, bool bottomBorder, bool rightBorder)
    {
        Row = row;
        Col = col;
        BottomBorder = bottomBorder;
        RightBorder = rightBorder;
    }
}
