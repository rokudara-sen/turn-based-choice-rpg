namespace TurnBasedChoiceRPG.Entities;

public class Entity
{
    private readonly Dictionary<Type, object> _components = new();

    public int Id { get; } // Unique entity ID

    public Entity(int id)
    {
        Id = id;
    }

    /// <summary>
    /// Adds a component to the entity.
    /// </summary>
    public void AddComponent<T>(T component) where T : struct
    {
        _components[typeof(T)] = component;
    }

    /// <summary>
    /// Retrieves a component of the specified type.
    /// </summary>
    public T GetComponent<T>() where T : struct
    {
        if (_components.TryGetValue(typeof(T), out var component))
        {
            return (T)component;
        }
        throw new InvalidOperationException($"Component {typeof(T).Name} not found on Entity {Id}.");
    }

    /// <summary>
    /// Checks if the entity has a specific component.
    /// </summary>
    public bool HasComponent<T>() where T : struct
    {
        return _components.ContainsKey(typeof(T));
    }

    /// <summary>
    /// Removes a component from the entity.
    /// </summary>
    public void RemoveComponent<T>() where T : struct
    {
        _components.Remove(typeof(T));
    }

    /// <summary>
    /// Updates an existing component.
    /// </summary>
    public void UpdateComponent<T>(T component) where T : struct
    {
        if (HasComponent<T>())
        {
            _components[typeof(T)] = component;
        }
        else
        {
            throw new InvalidOperationException($"Cannot update: Component {typeof(T).Name} not found on Entity {Id}.");
        }
    }
}