using TurnBasedChoiceRPG.Utils.Enums;

namespace TurnBasedChoiceRPG.Models.PlayerClasses;

public class Knight : Character
{
    public Knight(string name) : base(name, 25, 0, 10, 6, 3, 5, 2, 3, 1, 1, CharacterClasses.Knight)
    {
        SpecialAbility = PlayerClassSpecialAbility.HeavyStrike;
    }
    
    public PlayerClassSpecialAbility SpecialAbility { get; set; }
}