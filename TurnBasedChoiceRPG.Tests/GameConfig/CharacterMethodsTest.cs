using NUnit.Framework;
using TurnBasedChoiceRPG.GameConfig;
using TurnBasedChoiceRPG.Models.PlayerClasses;
using TurnBasedChoiceRPG.Models.Stats;
using TurnBasedChoiceRPG.Utils.Enums;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TurnBasedChoiceRPG.Tests.GameConfig;

[TestFixture]
[TestOf(typeof(CharacterMethods))]
public class CharacterMethodsTest
{
    [Test]
    [Description("Creating a new character will null class should return null")]
    public void CreateNewCharacter_NullClass_ReturnsNull()
    {
        // Act
        var result = CharacterMethods.CreateNewCharacter("Peter", null);
        
        // Assert
        Assert.IsNull(result);
    }
    
    [Test]
    [Description("Creating a new character will null name should return null")]
    public void CreateNewCharacter_NullName_ReturnsNull()
    {
        // Act
        var result = CharacterMethods.CreateNewCharacter(null, CharacterClasses.Knight);
        
        // Assert
        Assert.IsNull(result);
    }
    
    [Test]
    [Description("Creating a character with knight enum should return knight class")]
    public void CreateNewCharacter_KnightClass_ReturnsKnight()
    {
        // Arrange
        BaseInfo baseInfo = new BaseInfo("Peter", 25, 0, 10);
        BaseStats baseStats = new BaseStats(6, 3, 5, 1);
        Knight dummyClass = new Knight(baseInfo, baseStats);
        
        // Act
        var result = CharacterMethods.CreateNewCharacter("Peter", CharacterClasses.Knight);
        
        // Assert
        Assert.IsNotNull(result, "Expected a Knight character, but got null.");
        Assert.AreEqual(dummyClass.BaseInfo.Name, result.BaseInfo.Name);
        Assert.AreEqual(dummyClass.BaseInfo.Health, result.BaseInfo.Health);
    }
    
    [Test]
    [Description("Creating a new character will null class should return null")]
    public void CreateNewCharacter_NotExistingClass_ReturnsNull()
    {
        // Act
        var result = CharacterMethods.CreateNewCharacter("Peter", CharacterClasses.Ranger);
        
        // Assert
        Assert.IsNull(result);
    }
}