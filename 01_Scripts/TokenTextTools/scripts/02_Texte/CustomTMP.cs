using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CustomTMP : MonoBehaviour
{
    [BoxGroup("Color Parametter")][SerializeField] private ColorTokenScriptableObject colorParametter;
    private TMP_Text textElement;
    private void Start()
    {
        textElement = GetComponent<TMP_Text>();
        textElement.fontSize = colorParametter.size;
        textElement.font = colorParametter.myFont;
        textElement.fontStyle = colorParametter.style;
        textElement.color = colorParametter.GetColor();
    }
}
