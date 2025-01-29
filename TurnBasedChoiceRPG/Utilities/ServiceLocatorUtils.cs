using TurnBasedChoiceRPG.Core;

namespace TurnBasedChoiceRPG.Utilities;

public static class ServiceLocatorUtils
{
    public static T GetRequiredService<T>() where T : class
    {
        var service = ServiceLocator.GetService<T>();
        if (service == null)
            throw new InvalidOperationException($"{typeof(T).Name} is not registered in the ServiceLocator.");
            
        return service;
    }
}