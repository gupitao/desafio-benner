namespace DesafioBenner.menu;

internal abstract class Menu
{
    public void ShowTitle(string title)
    {
        Console.Clear();

        string margins = string.Empty.PadLeft(title.Length, '*');
        Console.WriteLine(margins);
        Console.WriteLine(title);
        Console.WriteLine(margins + "\n");
    }

    public void ClearConsole(int topPositionStart, int topPositionEnd)
    {
        for (int i = topPositionStart; i <= topPositionEnd; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }

        Console.SetCursorPosition(0, topPositionStart);
    }
}
