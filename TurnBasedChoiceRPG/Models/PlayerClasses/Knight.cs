using TurnBasedChoiceRPG.Models.Stats;
using TurnBasedChoiceRPG.Utils.Enums;

namespace TurnBasedChoiceRPG.Models.PlayerClasses;

public class Knight : Character
{
    public Knight(BaseInfo baseInfo, BaseStats baseStats) : base(baseInfo, baseStats, 1, CharacterClasses.Knight)
    {
        SpecialAbility = PlayerClassSpecialAbility.HeavyStrike;
    }
    
    public PlayerClassSpecialAbility SpecialAbility { get; set; }
}