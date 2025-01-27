namespace TurnBasedChoiceRPG.Models.Stats;

public class BaseStats
{
    public BaseStats(int strength, int dexterity, int constitution, int intelligence)
    {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
    }
    
    public int Strength { get; set; }
    public int Constitution { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
}