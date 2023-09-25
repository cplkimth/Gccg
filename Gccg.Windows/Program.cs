namespace Gccg.Windows;

internal static class Program
{
    public static bool IsRunTime { get; private set; }  = true;

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}