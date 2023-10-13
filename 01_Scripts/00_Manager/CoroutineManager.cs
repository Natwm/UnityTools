using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;

    private Dictionary<string, Coroutine> runningCoroutines = new Dictionary<string, Coroutine>();

    private void Awake()
    {
        // Assurez-vous qu'il n'y ait qu'une seule instance du CoroutineManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Méthode pour lancer une coroutine et l'ajouter au dictionnaire
    public static void StartCoroutine(string coroutineName, IEnumerator routine)
    {
        if (instance != null)
        {
            if (instance.runningCoroutines.ContainsKey(coroutineName))
            {
                // Vous pouvez choisir de l'arrêter avant de la remplacer si nécessaire
                instance.StopCoroutine(instance.runningCoroutines[coroutineName]);
            }

            Coroutine newCoroutine = instance.StartCoroutine(instance.WrapCoroutine(coroutineName, routine));
            instance.runningCoroutines[coroutineName] = newCoroutine;
        }
    }

    // Méthode pour arrêter une coroutine par son nom
    public static void StopCoroutine(string coroutineName)
    {
        if (instance != null && instance.runningCoroutines.ContainsKey(coroutineName))
        {
            instance.StopCoroutine(instance.runningCoroutines[coroutineName]);
            instance.runningCoroutines.Remove(coroutineName);
        }
    }

    // Wrapper de coroutine pour gérer l'ajout et la suppression automatiques
    private IEnumerator WrapCoroutine(string coroutineName, IEnumerator routine)
    {
        yield return routine; // Exécute la coroutine
        runningCoroutines.Remove(coroutineName); // Supprime la coroutine terminée du dictionnaire
    }
    public static bool IsCoroutineRunning(string coroutineName)
    {
        return instance != null && instance.runningCoroutines.ContainsKey(coroutineName);
    }
}