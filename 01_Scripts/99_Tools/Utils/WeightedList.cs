using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeightedItem<T>
{
    public T item;
    public float weight;
}

[System.Serializable]
public class WeightedList<T>
{
    [SerializeField] private List<WeightedItem<T>> weightedItems = new List<WeightedItem<T>>();
    private float totalWeight = 0f;

    public WeightedList()
    {
        weightedItems = new List<WeightedItem<T>>();
        totalWeight = 0f;
    }

    /// <summary>
    /// Add an item to the list with the given weight.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <param name="weight">The weight of the item.</param>
    public void AddItem(T item, float weight)
    {
        weightedItems.Add(new WeightedItem<T> { item = item, weight = weight });
        totalWeight += weight;
    }

    /// <summary>
    /// Get a random item from the list based on the weights.
    /// </summary>
    /// <returns>A random item from the list.</returns>
    public T GetRandomItem()
    {
        float randomWeight = Random.Range(0f, totalWeight);
        float currentWeight = 0f;

        foreach (WeightedItem<T> weightedItem in weightedItems)
        {
            currentWeight += weightedItem.weight;
            if (currentWeight >= randomWeight)
            {
                return weightedItem.item;
            }
        }

        return default(T);
    }
    
    /// <summary>
    /// Add a weighted item to the list.
    /// </summary>
    /// <param name="item">The weighted item to add.</param>
    public void AddWeightedItem(WeightedItem<T> item)
    {
        weightedItems.Add(item);
    }
    
    /// <summary>
    /// Remove a weighted item from the list.
    /// </summary>
    /// <param name="item">The weighted item to remove.</param>
    public void RemoveWeightedItem(WeightedItem<T> item)
    {
        weightedItems.Remove(item);
    }
    
    /// <summary>
    /// Reset all weights to the given weight.
    /// </summary>
    /// <param name="weight">The weight to set all items to.</param>
    public void ResetWeights(float weight)
    {
        foreach (var item in weightedItems)
        {
            item.weight = weight;
        }
    }
    
    
    /// <summary>
    /// Get a weighted item from the list at the given index.
    /// </summary>
    /// <param name="index">The index of the item to get.</param>
    /// <returns>The weighted item at the given index.</returns>
    public WeightedItem<T> GetWeightedItem(int index)
    {
        if (index >= 0 && index < weightedItems.Count)
        {
            return weightedItems[index];
        }

        return null;
    }
    
    /// <summary>
    /// Get a list of all items with the given weight.
    /// </summary>
    /// <param name="weight">The weight to search for.</param>
    /// <returns>A list of all items with the given weight.</returns>
    public List<WeightedItem<T>> GetItemsByWeight(float weight)
    {
        List<WeightedItem<T>> items = new List<WeightedItem<T>>();

        foreach (WeightedItem<T> item in weightedItems)
        {
            if (item.weight == weight)
            {
                items.Add(item);
            }
        }

        return items;
    }
    
    /// <summary>
    /// Returns a list of all weights for items in the list that have the same category as the specified category.
    /// </summary>
    /// <param name="category">The category to filter by.</param>
    public List<float> GetWeightsOfCategory(T category)
    {
        List<float> weights = new List<float>();

        foreach (var item in weightedItems)
        {
            if (EqualityComparer<T>.Default.Equals(item.item, category))
            {
                weights.Add(item.weight);
            }
        }

        return weights;
    }

    // <summary>
    /// Sets the weight of the item at the specified index in the list to the specified weight.
    /// </summary>
    /// <param name="index">The index of the item to set the weight of.</param>
    /// <param name="weight">The new weight for the item.</param>
    public void SetWeight(int index, float weight)
    {
        if (index >= 0 && index < weightedItems.Count)
        {
            weightedItems[index].weight = weight;
        }
    }

    /// <summary>
    /// Returns the number of items in the list.
    /// </summary>
    public int Count
    {
        get { return weightedItems.Count; }
    }
}
