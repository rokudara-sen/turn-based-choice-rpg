using TurnBasedChoiceRPG.Models.Stats;
using TurnBasedChoiceRPG.Utils.Enums;

namespace TurnBasedChoiceRPG.Models;

public class Character
{
    public Character(BaseInfo baseInfo, BaseStats baseStats, int characterLevel, CharacterClasses characterClass)
    {
        BaseInfo = baseInfo;
        
        BaseStats = baseStats;
        
        CharacterClass = characterClass;
        CharacterLevel = characterLevel;
        Inventory = new List<Item>();
    }
    
    public BaseInfo BaseInfo { get; set; }
    
    public BaseStats BaseStats { get; set; }
    
    public CharacterClasses CharacterClass { get; set; }
    public int CharacterLevel { get; set; }
    public List<Item> Inventory { get; set; }
}