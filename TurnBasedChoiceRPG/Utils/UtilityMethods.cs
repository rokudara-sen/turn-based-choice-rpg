namespace TurnBasedChoiceRPG.Utils;

public static class UtilityMethods
{
    public static void LoadingVisual(string text)
    {
        Console.WriteLine(text);
        for (int i = 0; i < 6; i++)
        {
            Thread.Sleep(1500);
            Console.Write(".");
        }
        Console.Clear();
    }
}