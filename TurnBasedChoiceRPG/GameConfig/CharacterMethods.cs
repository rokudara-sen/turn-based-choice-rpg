using TurnBasedChoiceRPG.Models;
using TurnBasedChoiceRPG.Models.PlayerClasses;
using TurnBasedChoiceRPG.Models.Stats;
using TurnBasedChoiceRPG.Utils.Enums;

namespace TurnBasedChoiceRPG.GameConfig;

public class CharacterMethods
{
    public static Character? CreateNewCharacter(string name, CharacterClasses? characterClass)
    {
        if (characterClass == null)
            return null;
        
        BaseInfo baseInfo = new BaseInfo(name, -1, -1, -1);
        BaseStats baseStats = new BaseStats(-1, -1, -1, -1);
        switch (characterClass)
        {
            case CharacterClasses.Knight:
                baseInfo.Health = 25;
                baseInfo.Mana = 0;
                baseInfo.Armor = 10;

                baseStats.Strength = 6;
                baseStats.Dexterity = 3;
                baseStats.Constitution = 5;
                baseStats.Intelligence = 1;
                
                return new Knight(baseInfo, baseStats);
            default:
                return null;
        }
    }
}