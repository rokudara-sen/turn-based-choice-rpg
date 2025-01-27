namespace TurnBasedChoiceRPG.Models.Stats;

public class BaseInfo
{
    public BaseInfo(string name, int health, int mana, int armor)
    {
        Name = name;
        Health = health;
        Mana = mana;
        Armor = armor;
    }
    
    public string Name { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Armor { get; set; }
}