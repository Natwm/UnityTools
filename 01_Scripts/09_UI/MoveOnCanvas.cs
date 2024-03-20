using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveOnCanvas : MonoBehaviour
{
    public void MoveOnTarget(Transform target)
    {
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 canvasSize = FindObjectOfType<Canvas>().GetComponent<RectTransform>().sizeDelta;

        // Calculer la position finale sur le canvas en fonction de la taille du canvas et de la position du joueur
        Vector2 anchoredPosition = new Vector2(
            (viewportPosition.x * canvasSize.x) - (canvasSize.x * 0.5f),
            (viewportPosition.y * canvasSize.y) - (canvasSize.y * 0.5f)
        );

        // Appliquer la position à l'image sur le canvas
        GetComponent<RectTransform>().anchoredPosition = anchoredPosition;

        
        GetComponent<RectTransform>()
            .DOMove(target.GetComponent<RectTransform>().position, 1f)
            .SetEase(Ease.Linear).OnComplete(
                () =>
                {
                    Destroy(gameObject);
                });
    }
}
