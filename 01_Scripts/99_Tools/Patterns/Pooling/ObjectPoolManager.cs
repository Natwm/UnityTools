using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages a pool of objects for reusability.
/// </summary>
public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab; // Prefab de l'objet à pooler
    [SerializeField] private int initialPoolSize = 10; // Taille initiale du pool

    private Stack<GameObject> pool = new Stack<GameObject>(); // Pool d'objets

    /// <summary>
    /// Initializes the object pool.
    /// </summary>
    void Start()
    {
        InitializePool();
    }

    /// <summary>
    /// Initializes the pool with inactive objects.
    /// </summary>
    private void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            AddObjectToPool();
        }
    }

    /// <summary>
    /// Adds an object to the pool.
    /// </summary>
    private void AddObjectToPool()
    {
        GameObject newObj = Instantiate(objectPrefab);
        newObj.SetActive(false);
        pool.Push(newObj);
    }

    /// <summary>
    /// Retrieves an object from the pool.
    /// </summary>
    /// <returns>The retrieved object.</returns>
    public GameObject GetObjectFromPool()
    {
        if (pool.Count == 0)
        {
            Debug.LogWarning("Le pool est vide. Ajoutez des objets au pool ou augmentez la taille initiale du pool.");
            return null;
        }

        GameObject obj = pool.Pop();
        obj.SetActive(true);
        return obj;
    }

    /// <summary>
    /// Returns an object to the pool.
    /// </summary>
    /// <param name="obj">The object to return to the pool.</param>
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Push(obj);
    }
}
