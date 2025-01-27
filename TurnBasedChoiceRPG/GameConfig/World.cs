using System.Security.Cryptography;
using TurnBasedChoiceRPG.Models;
using TurnBasedChoiceRPG.Utils;
using TurnBasedChoiceRPG.Utils.Enums;

namespace TurnBasedChoiceRPG.GameConfig;

public class World
{
    private readonly Dictionary<int, FloorLevel> _floors;
    public World()
    {
        _floors = new Dictionary<int, FloorLevel>();
        InitializeWorld();
    }

    public void DisplayFloor(int currentFloor)
    {
        FloorLevel floor = _floors[currentFloor];
        for (int i = 0; i < floor.Height; i++)
        {
            for (int j = 0; j < floor.Width; j++)
            {
                if (floor.FloorTiles[i][j] is FloorTileType.Relic)
                {
                    Console.Write(" ‡ ");
                } else if (floor.FloorTiles[i][j] is FloorTileType.Danger)
                {
                    Console.Write(" \u00a4 ");
                } else if (floor.FloorTiles[i][j] is FloorTileType.Well)
                {
                    Console.Write(" † ");
                } else
                {
                    Console.Write(" - ");
                }
            }
            Console.WriteLine();
        }
        int displayCurrentFloorNumber = currentFloor + 1;
        Console.WriteLine("\nRelics: {0}\nDangers: {1}\nWells: {2}\nCurrent Floor: {3} out of {4}\n\n", floor.RelicAmount, floor.DangerAmount, floor.WellAmount, displayCurrentFloorNumber, _floors.Count);
    }

    private void InitializeWorld()
    {
        const int floorCount = 15;
        
        UtilityMethods.LoadingVisual("Initializing World");

        InitializeFloorDictionary(floorCount);
        Console.Clear();
        DisplayFloor(0);
    }

    private FloorLevel GenerateFloor()
    {
        RandomNumberGenerator random = RandomNumberGenerator.Create();
        int floorHeight = RandomNumberGenerator.GetInt32(10, 40);
        int floorWidth = RandomNumberGenerator.GetInt32(10, 40);
        int floorRelicAmount = RandomNumberGenerator.GetInt32((floorHeight * floorWidth) / 100, (floorHeight * floorWidth) / 50);
        
        FloorLevel floor = new FloorLevel(floorHeight, floorWidth, floorRelicAmount);
        floor = RandomizeFloorTiles(floor);
        return floor;
    }

    private void InitializeFloorDictionary(int floorCount)
    {
        for (int i = 0; i < floorCount; i++)
        {
            FloorLevel floor = GenerateFloor();
            _floors.Add(i, floor);
        }
    }

    private static FloorLevel RandomizeFloorTiles(FloorLevel floor)
    {
        int relicCounter = 0;
        for (int i = 0; i < floor.Height; i++)
        {
            for (int j = 0; j < floor.Width; j++)
            {
                int randomTile = RandomNumberGenerator.GetInt32(1, 11);
                if (randomTile < 2 && relicCounter < floor.RelicAmount)
                {
                    floor.FloorTiles[i][j] = FloorTileType.Relic;
                    relicCounter++;
                } else if (randomTile < 4)
                {
                    floor.FloorTiles[i][j] = FloorTileType.Danger;
                    floor.DangerAmount += 1;
                } else if (randomTile < 5)
                {
                    floor.FloorTiles[i][j] = FloorTileType.Well;
                    floor.WellAmount += 1;
                }
                else
                {
                    floor.FloorTiles[i][j] = FloorTileType.Empty;
                }
            }
        }
        return floor;
    }
}