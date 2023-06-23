using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension 
{
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
    }

    public static List<T> GetAllComponents<T>(this GameObject gameObject) where T : Component
    {
        List<T> allComponents = new List<T>();

        gameObject.GetComponents<T>()?.ApplyActionOnEachElement(x => allComponents.Add(x));
        gameObject.GetComponentsInChildren<T>()?.ApplyActionOnEachElement(x => allComponents.Add(x));

        return allComponents;
    }
    
    public static bool TryGetComponent<T>(this GameObject gameObject, out T val) where T : Component
    {
        val = gameObject.GetComponent<T>();
        return val == null;
    }
    
    public static void EnableColliders(this GameObject gameObject)
    {
        gameObject.GetAllComponents<Collider>()?.ForEach(x => x.enabled = true);
        gameObject.GetAllComponents<Collider2D>()?.ForEach(x => x.enabled = true);
    }

    public static void DisableColliders(this GameObject gameObject)
    {
        gameObject.GetAllComponents<Collider>()?.ForEach(x => x.enabled = false);
        gameObject.GetAllComponents<Collider2D>()?.ForEach(x => x.enabled = false);
    }

    public static Vector3 GetPosition(this Transform element)
    {
        return element.position;
    }
    
    public static Vector3 GetScale(this Transform element)
    {
        return element.localScale;
    }
    
    public static Quaternion GetRotation(this Transform element)
    {
        return element.rotation;
    }
}
