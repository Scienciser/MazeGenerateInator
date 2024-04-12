using Maze.Library;

namespace Maze.UI;


[System.Runtime.Versioning.SupportedOSPlatform("windows")] // No GDI+ support for macOS/Linux
public partial class MazeForm : Form
{
    private bool _navigation = false;


    public MazeForm()
    {
        KeyPreview = true;
        InitializeComponent();

        // WinForms Designer overrides
        UIContainer.SplitterDistance = UIContainer.Height - 40;
    }


    private void NewMazeButton_Click(object sender, EventArgs e)
    {
        _navigation = false;
        NavigateMazeButton.Text = "Navigate with Arrow Keys";
        MazePanel.NewMaze();
    }


    private void SolveButton_Click(object sender, EventArgs e)
    {
        MazePanel.SolveMaze();
    }


    private void NavigateMazeButton_Click(object sender, EventArgs e)
    {
        _navigation = !_navigation;
        if (_navigation)
        {
            NavigateMazeButton.Text = "Stop Navigating";
            MazePanel.EnableNavigation();
        }
        else
        {
            NavigateMazeButton.Text = "Navigate with Arrow Keys";
            MazePanel.DisableNavigation();
        }
    }


    static readonly Keys[] interceptedKeys = [Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.W, Keys.A, Keys.S, Keys.D];

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // Check if the arrow keys are pressed
        if (interceptedKeys.Contains(keyData))
        {
            if (_navigation)
            {
                switch (keyData)
                {
                    case Keys.Left:
                    case Keys.A:
                        MazePanel.PlayerTryMove(PlayerMoveDirection.LEFT);
                        break;
                    case Keys.Right:
                    case Keys.D:
                        MazePanel.PlayerTryMove(PlayerMoveDirection.RIGHT);
                        break;
                    case Keys.Up:
                    case Keys.W:
                        MazePanel.PlayerTryMove(PlayerMoveDirection.UP);
                        break;
                    case Keys.Down:
                    case Keys.S:
                        MazePanel.PlayerTryMove(PlayerMoveDirection.DOWN);
                        break;
                }
            }

            // Return true to indicate that the key has been handled
            return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }
}
