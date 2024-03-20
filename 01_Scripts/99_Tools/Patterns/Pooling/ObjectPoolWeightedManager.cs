using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages a weighted pool of objects for reusability.
/// </summary>
public class ObjectPoolWeightedManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectPrefabs; 

    private Dictionary<int, List<GameObject>> pools = new Dictionary<int, List<GameObject>>(); 
    public Transform spawnPosition;
    
    [SerializeField]
    private int initialPoolSize = 10; 

    
    void Awake()
    {
        InitializePool();
    }

    /// <summary>
    /// Initializes the object pools.
    /// </summary>
    private void InitializePool()
    {
        foreach (GameObject prefab in objectPrefabs)
        {
            WeightedPooledObject parametter = prefab.GetComponent<WeightedPooledObject>();
            if (parametter != null)
            {
                if (!pools.ContainsKey(parametter.Weigth))
                {
                    pools[parametter.Weigth] = new List<GameObject>();
                }

                for (int i = 0; i < initialPoolSize; i++)
                {
                    AddObjectToPool(prefab, parametter.Weigth);
                }
            }
            else
            {
                Debug.LogWarning("Le prefab " + prefab.name + " n'a pas de composant LevelTemplateParametter. Ignoré lors de la création du pool.");
            }
        }
    }

    /// <summary>
    /// Adds an object to the pool.
    /// </summary>
    /// <param name="prefab">The object prefab to add to the pool.</param>
    /// <param name="difficultyLevel">The difficulty level associated with the object.</param>
    private void AddObjectToPool(GameObject prefab, int difficultyLevel)
    {
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(false);
        newObj.transform.SetParent(spawnPosition); // Ou tout autre parent souhaité
        pools[difficultyLevel].Add(newObj);
    }
    
    /// <summary>
    /// Retrieves an object from the pool based on difficulty level.
    /// </summary>
    /// <param name="difficultyLevel">The difficulty level of the object to retrieve.</param>
    /// <returns>The retrieved object.</returns>
    public GameObject GetObjectFromPool(int difficultyLevel)
    {
        List<GameObject> poolForDifficulty;
        if (pools.TryGetValue(difficultyLevel, out poolForDifficulty))
        {
            if (poolForDifficulty.Count == 0)
            {
                Debug.LogWarning("Le pool pour le niveau de difficulté " + difficultyLevel + " est vide. Assurez-vous qu'il y a suffisamment d'objets pré-créés dans le pool.");
                return null;
            }

            GameObject obj = poolForDifficulty[Random.Range(0, poolForDifficulty.Count)];
            poolForDifficulty.Remove(obj);
            obj.SetActive(true);
            return obj;
        }
        else
        {
            Debug.LogWarning("Aucun pool trouvé pour le niveau de difficulté " + difficultyLevel);
            return null;
        }
    }

    
    /// <summary>
    /// Retrieves an object from the pool based on difficulty level and optional fixed index.
    /// </summary>
    /// <param name="difficulty">The difficulty level of the object to retrieve.</param>
    /// <param name="fixIndex">Optional fixed index of the object to retrieve.</param>
    /// <returns>The retrieved object.</returns>
    public GameObject GetObjectFromPool(int difficulty, int fixIndex = -1)
    {
        if (!pools.ContainsKey(difficulty) || pools[difficulty].Count == 0)
        {
            Debug.LogWarning("Le pool pour le niveau de difficulté " + difficulty + " est vide ou n'existe pas. Ajoutez des objets au pool pour ce niveau.");
            return null;
        }

        List<GameObject> selection = pools[difficulty];
        GameObject obj;
        
        if (fixIndex < 0)
        {
            obj = selection[Random.Range(0,selection.Count)];
        }
        else
        {
            obj = selection[fixIndex];
        }

        selection.Remove(obj);

        obj.SetActive(true);
        obj.transform.SetParent(spawnPosition);
        return obj;
    }

    /// <summary>
    /// Returns an object to the pool.
    /// </summary>
    /// <param name="obj">The object to return to the pool.</param>
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    
        WeightedPooledObject parametter = obj.GetComponent<WeightedPooledObject>();
        obj.transform.SetParent(spawnPosition);

        int difficultyLevel = parametter.Weigth;
        if (pools.ContainsKey(difficultyLevel))
        {
            pools[difficultyLevel].Add(obj);
        }
        else
        {
            Debug.LogWarning("Aucun pool trouvé pour le niveau de difficulté " + difficultyLevel + ". L'objet sera simplement désactivé.");
        }

    }
}
