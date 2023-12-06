using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffectOnClick : MonoBehaviour
{
    public GameObject effectPrefab; // Le prefab de l'effet que vous souhaitez instancier

    void Update()
    {
        // Vérifier si le joueur a cliqué avec le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            // Obtenir la position du clic de la souris dans l'espace du monde
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Assurez-vous que la position z est correcte pour votre scène

            Instantiate(effectPrefab, mousePosition, Quaternion.identity);
        }
    }
}
