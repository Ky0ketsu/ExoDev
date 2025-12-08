using System;
using System.Collections.Generic;
using UnityEngine;

public class GameServicesLocator : MonoBehaviour
{
    private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

    // Enregistrer par interface
    public static void Register<TInterface>(TInterface serviceInstance)
    {
        Type interfaceType = typeof(TInterface);
        services[interfaceType] = serviceInstance;
        Debug.Log($"Service {interfaceType.Name} enregistré");
    }

    // Récupérer par interface
    public static TInterface Get<TInterface>()
    {
        Type interfaceType = typeof(TInterface);

        if (services.ContainsKey(interfaceType))
        {
            return (TInterface)services[interfaceType];
        }

        Debug.LogError($"Service {interfaceType.Name} non trouvé !");
        return default(TInterface);
    }

    public static void Unregister<TInterface>()
    {
        bool interfaceRemoved = services.Remove(typeof(TInterface));

        if (interfaceRemoved)
        {
            Debug.Log($"Services {typeof(TInterface).Name} désinscrit");
        }
        else
        {
            Debug.LogWarning($"Services {typeof(TInterface).Name} n'est pas enregistré");
        }
    }
}
