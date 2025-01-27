using TurnBasedChoiceRPG.Utils.Enums;

namespace TurnBasedChoiceRPG.Models;

public class Character
{
    public Character(string name, int health, int mana, int armor, int strength, int dexterity, int constitution, int intelligence, int charisma, int wisdom, int characterLevel, CharacterClasses characterClass)
    {
        Name = name;
        Health = health;
        Mana = mana;
        Armor = armor;
        
        Strength = strength;
        Constitution = constitution;
        Dexterity = dexterity;
        Intelligence = intelligence;
        Charisma = charisma;
        Wisdom = wisdom;
        
        CharacterClass = characterClass;
        CharacterLevel = characterLevel;
        Inventory = new List<Item>();
    }
    
    public string Name { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Armor { get; set; }
    
    public int Strength { get; set; }
    public int Constitution { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Charisma { get; set; }
    public int Wisdom { get; set; }
    
    public CharacterClasses CharacterClass { get; set; }
    public int CharacterLevel { get; set; }
    public List<Item> Inventory { get; set; }
}