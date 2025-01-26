namespace TurnBasedChoiceRPG.Models;

public class FloorLevel
{
    public FloorLevel(int height, int width, int relicAmount)
    {
        Height = height;
        Width = width;
        RelicAmount = relicAmount;
    }
    
    public int Height { get; private set; }
    public int Width { get; private set; }
    public int RelicAmount { get; private set; }
}