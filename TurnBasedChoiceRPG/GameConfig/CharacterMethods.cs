using TurnBasedChoiceRPG.Models;
using TurnBasedChoiceRPG.Models.PlayerClasses;
using TurnBasedChoiceRPG.Utils.Enums;

namespace TurnBasedChoiceRPG.GameConfig;

public class CharacterMethods
{

    public CharacterMethods()
    {

    }

    public Character? CreateNewCharacter(string name, CharacterClasses? characterClass)
    {
        if (characterClass == null)
            return null;
        
        switch (characterClass)
        {
            case CharacterClasses.Knight:
                return new Knight(name);
            default:
                return null;
        }
    }
}