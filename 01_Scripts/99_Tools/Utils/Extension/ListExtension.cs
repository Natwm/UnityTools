using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public static class ListExtensions
{
    public static T GetRandomElement<T>(this List<T> list)
    {
        int randomIndex = UnityEngine.Random.Range(0, list.Count);
        return list[randomIndex];
    }
    
    public static T GetHead<T>(this List<T> list)
    {
        return list[0];
    }
    
    public static T GetTail<T>(this List<T> list)
    {
        return list[list.Count];
    }
    
    public static void AddHead<T>(this List<T> list, T param)
    {
        list.Insert(0,param);
    }
    
    public static void AddMiddle<T>(this List<T> list, T param)
    {
        int middle = list.Count / 2;
        list.Insert(middle,param);
    }
    
    /// <summary>
    /// Removes items from a collection based on the condition you provide. This is useful if a query gives 
    /// you some duplicates that you can't seem to get rid of. Some Linq2Sql queries are an example of this. 
    /// Use this method afterward to strip things you know are in the list multiple times
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="Predicate"></param>
    /// <remarks>http://extensionmethod.net/csharp/icollection-t/removeduplicates</remarks>
    /// <returns></returns>
    public static IEnumerable<T> RemoveDuplicates<T>(this ICollection<T> list, Func<T, int> Predicate)
    {
        var dict = new Dictionary<int, T>();

        foreach (var item in list)
        {
            if (!dict.ContainsKey(Predicate(item)))
            {
                dict.Add(Predicate(item), item);
            }
        }

        return dict.Values.AsEnumerable();
    }
    
    #region IsNullOrEmpty

    /// <summary>
    /// Returns true if the array is null or empty
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T>(this T[] data)
    {
        return ((data == null) || (data.Length == 0));
    }

    /// <summary>
    /// Returns true if the list is null or empty
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T>(this List<T> data)
    {
        return ((data == null) || (data.Count == 0));
    }

    /// <summary>
    /// Returns true if the dictionary is null or empty
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T1, T2>(this Dictionary<T1,T2> data)
    {
        return ((data == null) || (data.Count == 0));
    }

    // IsNullOrEmpty
    #endregion
    
    /// <summary>
    /// Returns the current enumerable without null values
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">The enumerable</param>
    /// <returns>The enumerable without the null values</returns>
    public static IEnumerable<T> WithoutNullValues<T>(this IEnumerable<T> e) => e.Where(i => i != null);
    
    /// <summary>
    /// Executes an action on each element of the enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">The enumerable</param>
    /// <param name="action">The action to execute on each element</param>
    public static void ApplyActionOnEachElement<T>(this IEnumerable<T> e, Action<T> action)
    {
        foreach (T t in e)
        {
            action(t);
        }
    }
    
    /// <summary>
    /// Executes an action on each element of the enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">The enumerable</param>
    /// <param name="action">
    /// The action to execute on each element, with its index as the second parameter
    /// </param>
    public static void ForEach<T>(this IEnumerable<T> e, Action<T, int> action)
    {
        int i = 0;
        foreach (T t in e)
        {
            action(t, i++);
        }
    }
    
    /// <summary>
    /// Return the closest component to target from the list in 3D space
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">The enumerable</param>
    /// <param name="target"></param>
    /// <returns></returns>
    private static T GetClosest<T>(this IEnumerable<T> e, Vector3 target) where T : Component
        => e.OrderBy(x => Vector3.Distance(x.transform.position, target)).FirstOrDefault();

    /// <summary>
    /// Return the furthest component to target from the list in 3D space
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">The enumerable</param>
    /// <param name="target"></param>
    /// <returns></returns>
    private static T GetFurthest<T>(this IEnumerable<T> e, Vector3 target) where T : Component
        => e.OrderBy(x => Vector3.Distance(x.transform.position, target)).LastOrDefault();
    
    /// <summary>
    /// Return the closest component to target from the list in 2D space
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">The enumerable</param>
    /// <param name="target"></param>
    /// <returns></returns>
    private static T GetClosest2D<T>(this IEnumerable<T> e, Vector2 target) where T : Component
        => e.OrderBy(x => Vector2.Distance(x.transform.position, target)).FirstOrDefault();

    /// <summary>
    /// Return the furthest component to target from the list in 2D space
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e">The enumerable</param>
    /// <param name="target"></param>
    /// <returns></returns>
    private static T GetFurthest2D<T>(this IEnumerable<T> e, Vector2 target) where T : Component
        => e.OrderBy(x => Vector2.Distance(x.transform.position, target)).LastOrDefault();
    
    // Échange les éléments à l'index i et j dans la liste
    public static void Swap<T>(this List<T> list, int i, int j) {
        (list[i], list[j]) = (list[j], list[i]);
    }

    // Mélange la liste aléatoirement
    public static void Shuffle<T>(this List<T> list) {
        Random random = new Random();
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = random.Next(n + 1);
            list.Swap(k, n);
        }
    }
    
    // Trie la liste selon l'ordre naturel des éléments
    public static void Sort<T>(this List<T> list) where T : IComparable<T> {
        list.Sort((a, b) => a.CompareTo(b));
    }
        
    // Crée une sous-liste à partir d'une plage d'indices
    public static List<T> SubList<T>(this List<T> list, int start, int end) {
        List<T> subList = new List<T>();
        for (int i = start; i < end; i++) {
            subList.Add(list[i]);
        }
        return subList;
    }
    
}