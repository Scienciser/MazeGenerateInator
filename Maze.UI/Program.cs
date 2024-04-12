namespace Maze.UI;


[System.Runtime.Versioning.SupportedOSPlatform("windows")] // No GDI+ support for macOS/Linux
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MazeForm());
    }
}
