namespace TurnBasedChoiceRPG.Core;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> Services = new();

    /// <summary>
    /// Registers a service in the service locator.
    /// </summary>
    public static void RegisterService<T>(T service) where T : class
    {
        if (service == null)
            throw new ArgumentNullException(nameof(service));

        var type = typeof(T);
        if (Services.ContainsKey(type))
            throw new InvalidOperationException($"Service {type.Name} is already registered.");

        Services[type] = service;
    }

    /// <summary>
    /// Retrieves a registered service.
    /// </summary>
    public static T? GetService<T>() where T : class
    {
        var type = typeof(T);
        if (Services.TryGetValue(type, out var service))
        {
            return service as T;
        }

        throw new InvalidOperationException($"Service {type.Name} not found.");
    }

    /// <summary>
    /// Checks if a service is registered.
    /// </summary>
    public static bool IsServiceRegistered<T>() where T : class
    {
        return Services.ContainsKey(typeof(T));
    }

    /// <summary>
    /// Clears all registered services (useful for testing or cleanup).
    /// </summary>
    public static void Clear()
    {
        Services.Clear();
    }
}