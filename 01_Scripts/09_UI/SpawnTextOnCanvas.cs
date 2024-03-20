using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

/// <summary>
/// Cette classe gère le spawn de texte sur un canvas.
/// </summary>
public class SpawnTextOnCanvas : MonoBehaviour
{
    [SerializeField] private Vector2 offset = new Vector2(50, 50);
    public GameObject textPrefab;
    public GameObject objectToSpawn;

    /// <summary>
    /// Fait apparaître du texte à l'emplacement d'un objet spécifié.
    /// </summary>
    /// <param name="gameObject">L'objet autour duquel faire apparaître le texte.</param>
    /// <param name="number">Le nombre à afficher.</param>
    public void SpawnTextAtGameObject(Vector3 gameObject, int number)
    {
        Vector3 objPosition = gameObject + (Vector3)offset;
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(objPosition);
        Vector2 canvasSize = GetComponent<RectTransform>().sizeDelta;

        GameObject textInstance = Instantiate(textPrefab, viewportPosition, Quaternion.identity,
            GetComponent<Canvas>().transform);
        textInstance.transform.localScale = Vector3.zero;
        Vector2 anchoredPosition = new Vector2(
            (viewportPosition.x * canvasSize.x) - (canvasSize.x * 0.5f),
            (viewportPosition.y * canvasSize.y) - (canvasSize.y * 0.5f)
        );
        textInstance.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        // Modifier le texte
        TMP_Text tmpText = textInstance.GetComponent<TMP_Text>();
        if (tmpText != null)
        {
            tmpText.text = "+" + number.ToString();
        }

        textInstance.transform.DOScale(2, 0.25f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            textInstance.transform.DOScale(0, 1.5f).SetEase(Ease.Linear);
        });
        // Détruire après 2 secondes
        Destroy(textInstance, 2f);
    }

    /// <summary>
    /// Fait apparaître du texte à l'emplacement de l'objet spécifié dans la variable 'objectToSpawn'.
    /// </summary>
    /// <param name="number">Le nombre à afficher.</param>
    public void SpawnTextAtGameObject(int number)
    {
        var objPosition = objectToSpawn.transform.position + (Vector3)offset;
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(objPosition);
        Vector2 canvasSize = GetComponent<RectTransform>().sizeDelta;

        GameObject textInstance = Instantiate(textPrefab, viewportPosition, Quaternion.identity,
            GetComponent<Canvas>().transform);
        textInstance.transform.localScale = Vector3.zero;
        Vector2 anchoredPosition = new Vector2(
            (viewportPosition.x * canvasSize.x) - (canvasSize.x * 0.5f),
            (viewportPosition.y * canvasSize.y) - (canvasSize.y * 0.5f)
        );
        textInstance.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        // Modifier le texte
        TMP_Text tmpText = textInstance.GetComponent<TMP_Text>();
        if (tmpText != null)
        {
            tmpText.text = "+" + number.ToString();
        }

        textInstance.transform.DOScale(2, 0.25f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            textInstance.transform.DOScale(0, 1.5f).SetEase(Ease.Linear);
        });
        Destroy(textInstance, 2f);
    }
}