using TurnBasedChoiceRPG.Utils;
using TurnBasedChoiceRPG.Utils.Enums;

namespace TurnBasedChoiceRPG.GameConfig;

public class Game
{
    public Game()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        UtilityMethods.LoadingVisual("Initializing Game");
        
        string? playerName = InsertName();
        if (playerName is null)
            return;
        
        var playerClass = SelectClass();
        if (playerClass is null)
            return;
        
        CharacterMethods.CreateNewCharacter(playerName, playerClass);
        StartGame();
    }
    
    private static void StartGame()
    {
        UtilityMethods.LoadingVisual("Starting Game");
    }

    private static string? InsertName()
    {
        Console.Write("Please insert your player name: ");
        string? playerName = Console.ReadLine();
        Console.Clear();
        
        if (playerName is null)
        {
            Console.WriteLine("Player name is required.");
            Console.Clear();
            return null;
        }
        
        return playerName;
    }

    private static CharacterClasses? SelectClass()
    {
        Console.WriteLine("Knight [K]\nWizard [W]\nRanger [R]\n");
        Console.Write("Please select a class: ");
        string? playerClass = Console.ReadLine();
        Console.Clear();

        if (playerClass is null)
        {
            Console.WriteLine("Player Class is required.");
            Console.Clear();
            return null;
        } 
        
        if (!CheckPlayerClassSelection(playerClass))
        {
            Console.WriteLine("Incorrect Player Class.");
            Console.Clear();
            return null;
        }
        
        var convertedPlayerClass = SelectClassEnum(playerClass);
        
        if (convertedPlayerClass is null)
        {  
            Console.WriteLine("Couldn't Convert Player Class to Enum.");
            Console.Clear();
            return null;
        }
        
        return convertedPlayerClass;
    }

    private static bool CheckPlayerClassSelection(string playerClass)
    {
        switch (playerClass)
        {
            case "K":
                return true;
            case "W":
                return true;
            case "R":
                return true;
            default:
                return false;
        }
    }

    private static CharacterClasses? SelectClassEnum(string playerClass)
    {
        switch (playerClass)
        {
            case "K":
                return CharacterClasses.Knight;
            case "W":
                return CharacterClasses.Wizard;
            case "R":
                return CharacterClasses.Ranger;
            default:
                return null;
        }
    }
}