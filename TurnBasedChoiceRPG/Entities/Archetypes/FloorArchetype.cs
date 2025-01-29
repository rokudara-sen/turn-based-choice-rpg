using TurnBasedChoiceRPG.Components.World;

namespace TurnBasedChoiceRPG.Entities.Archetypes;

public static class FloorArchetype
{
    public static Entity Create(EntityManager em)
    {
        var entity = em.CreateEntity();
        entity.AddComponent<FloorTagComponent>(new FloorTagComponent());
        entity.AddComponent<TileGridComponent>(new TileGridComponent());
        entity.AddComponent<FloorDataComponent>(new FloorDataComponent());
        return entity;
    }
}