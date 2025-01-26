using TurnBasedChoiceRPG.Models;

namespace TurnBasedChoiceRPG.Game;

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
        
    }

    private void InitializeWorld()
    {
        const int floorCount = 15;
        
        Console.WriteLine("Initializing World");
        for (int i = 0; i < 6; i++)
        {
            Thread.Sleep(1500);
            Console.Write(".");
        }

        PopulateFloorDictonary(floorCount);
        Console.Clear();
    }

    private FloorLevel GenerateRandomFloor()
    {
        Random random = new Random();
        int floorHeight = random.Next(20, 100);
        int floorWidth = random.Next(20, 100);
        int floorRelicAmount = random.Next((floorHeight*floorWidth)/10, (floorHeight*floorWidth)/8);
        
        FloorLevel floor = new FloorLevel(floorHeight, floorWidth, floorRelicAmount);
        return floor;
    }

    private void PopulateFloorDictonary(int floorCount)
    {
        for (int i = 0; i < floorCount; i++)
        {
            FloorLevel floor = GenerateRandomFloor();
            _floors.Add(i, floor);
        }
    }
}