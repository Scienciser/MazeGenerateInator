using Maze.Library;

namespace Maze.UI;


[System.Runtime.Versioning.SupportedOSPlatform("windows")] // No GDI+ support for macOS/Linux
internal class MazePanel : Panel
{
    private static Random rng = new Random();
    private MazeGenerator _maze;
    private bool _solved = false;
    private bool _navigation = false;


    public MazePanel()
    {
        DoubleBuffered = true;
        _maze = CreateMaze();
    }


    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        float cellWidth = (float)this.Width / _maze.Width;
        float cellHeight = (float)this.Height / _maze.Height;
        float[] xCoords = Enumerable.Range(0, _maze.Width + 1).Select(i => (cellWidth * i)).ToArray();
        float[] yCoords = Enumerable.Range(0, _maze.Height + 1).Select(i => (cellHeight * i)).ToArray();

        Brush mazeBorderBrush = new SolidBrush(Color.Black);
        Pen pen = new Pen(mazeBorderBrush, 2);

        // Draw maze
        for (int y = 0; y < _maze.Cells.Length; ++y)
        {
            for (int x = 0; x < _maze.Cells[y].Length; ++x)
            {
                var cell = _maze.Cells[y][x];
                if (cell.RightBorder)
                {
                    e.Graphics.DrawLine(pen, new PointF(xCoords[cell.Col + 1], yCoords[cell.Row]), new PointF(xCoords[cell.Col + 1], yCoords[cell.Row + 1]));
                }
                if (cell.BottomBorder)
                {
                    e.Graphics.DrawLine(pen, new PointF(xCoords[cell.Col], yCoords[cell.Row + 1]), new PointF(xCoords[cell.Col + 1], yCoords[cell.Row + 1]));
                }
            }
        }

        // Colour in start and end squares
        Brush startSquareBrush = new SolidBrush(Color.FromArgb(128, Color.Orange));
        e.Graphics.FillRectangle(startSquareBrush, new RectangleF(xCoords[_maze.StartingCell.Col], yCoords[_maze.StartingCell.Row], cellWidth, cellHeight));
        Brush endSquareBrush = new SolidBrush(Color.FromArgb(128, Color.Green));
        e.Graphics.FillRectangle(endSquareBrush, new RectangleF(xCoords[_maze.EndingCell.Col], yCoords[_maze.EndingCell.Row], cellWidth, cellHeight));

        // Draw solution path
        if (_solved)
        {
            Brush solutionBrush = new SolidBrush(Color.FromArgb(128, Color.LightBlue));
            foreach (var cell in _maze.Solution)
            {
                e.Graphics.FillRectangle(solutionBrush, new RectangleF(xCoords[cell.Col], yCoords[cell.Row], cellWidth, cellHeight));
            }
        }

        // Draw player square
        if (_navigation && _maze.PlayerPosition != null)
        {
            Brush navigationBrush = new SolidBrush(Color.FromArgb(128, Color.Red));
            e.Graphics.FillRectangle(navigationBrush, new RectangleF(xCoords[_maze.PlayerPosition.Col], yCoords[_maze.PlayerPosition.Row], cellWidth, cellHeight));
        }
    }


    protected override void OnResize(EventArgs eventargs)
    {
        base.OnResize(eventargs);
        Invalidate();
    }


    public void NewMaze()
    {
        _maze = CreateMaze();
        Invalidate();
    }
    
    private MazeGenerator CreateMaze()
    {
        // Half the time create a large maze, the other half create a small maze
        bool bigMaze = rng.Next(0, 2) == 0;
        var width = bigMaze ? rng.Next(50, 150) : rng.Next(15, 30);
        var height = Math.Max((int)((float)Height / Width * width), 1); // Keep the maze cell aspect ratio 1:1
        _solved = false;
        _navigation = false;
        return new MazeGenerator(width, height);
    }


    public void SolveMaze()
    {
        if (!_solved)
        {
            _solved = true;
            Invalidate();
        }
    }


    public void EnableNavigation()
    {
        _maze.EnableNavigation();
        _navigation = true;
        Invalidate();
    }


    public void DisableNavigation()
    {
        _maze.DisableNavigation();
        _navigation = false;
        Invalidate();

    }


    public void PlayerTryMove(PlayerMoveDirection moveDirection)
    {
        _maze.PlayerTryMove(moveDirection);
        Invalidate();
    }
}
