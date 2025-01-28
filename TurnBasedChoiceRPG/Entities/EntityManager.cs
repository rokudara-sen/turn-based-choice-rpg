namespace TurnBasedChoiceRPG.Entities;

public class EntityManager
{
    private readonly Dictionary<int, Entity> _entities = new();
    private int _nextEntityId = 1; // Unique ID generator

    /// <summary>
    /// Creates a new entity and registers it.
    /// </summary>
    public Entity CreateEntity()
    {
        var entity = new Entity(_nextEntityId++);
        _entities[entity.Id] = entity;
        return entity;
    }

    /// <summary>
    /// Retrieves an entity by ID.
    /// </summary>
    public Entity GetEntity(int id)
    {
        if (_entities.TryGetValue(id, out var entity))
        {
            return entity;
        }
        throw new InvalidOperationException($"Entity with ID {id} does not exist.");
    }

    /// <summary>
    /// Removes an entity by ID.
    /// </summary>
    public void RemoveEntity(int id)
    {
        if (_entities.ContainsKey(id))
        {
            _entities.Remove(id);
        }
        else
        {
            throw new InvalidOperationException($"Entity with ID {id} does not exist.");
        }
    }

    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    public IEnumerable<Entity> GetAllEntities()
    {
        return _entities.Values;
    }

    /// <summary>
    /// Clears all entities (useful for resetting the game).
    /// </summary>
    public void Clear()
    {
        _entities.Clear();
        _nextEntityId = 1;
    }
}