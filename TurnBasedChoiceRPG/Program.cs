using TurnBasedChoiceRPG.Core;
using TurnBasedChoiceRPG.Entities;
using TurnBasedChoiceRPG.Systems.Render;
using TurnBasedChoiceRPG.Systems.World;

namespace TurnBasedChoiceRPG;

class Program
{
    static void Main()
    {
        ServiceLocator.RegisterService(new EntityManager());
        ServiceLocator.RegisterService(new MapGenerationSystem());
        ServiceLocator.RegisterService(new WorldInitializationSystem());
        ServiceLocator.RegisterService(new FloorRenderSystem());
        
        GameLoop game = new GameLoop();
        game.Initialize();
        game.RenderCurrentFloor();
    }
}