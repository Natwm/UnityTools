using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

/// <summary>
/// Component for animating floating-point number increase on a TextMeshPro text element.
/// </summary>
public class floatIncreaseAnimation : MonoBehaviour
{
    private TMPro.TMP_Text selectedText;
    
    /// <summary>
    /// Animates the increase of a floating-point number from a start value to a target value over a specified duration with a specified number of decimal places.
    /// </summary>
    /// <param name="startValue">Starting value of the animation.</param>
    /// <param name="targetValue">Target value of the animation.</param>
    /// <param name="duration">Duration of the animation.</param>
    /// <param name="decimalPlaces">Number of decimal places to display.</param>
    void  PlayAnimation(float startValue, float targetValue, float duration, int decimalPlaces)
    {
        string formatString = "F" + decimalPlaces.ToString();
        DOVirtual.Float(startValue, targetValue, duration, (x) =>
        {
            selectedText.text = x.ToString(formatString);
        });
    }
    
    /// <summary>
    /// Animates the increase of a floating-point number from a start value to a target value over a specified duration with a specified number of decimal places. Invokes a delegate method upon completion.
    /// </summary>
    /// <param name="startValue">Starting value of the animation.</param>
    /// <param name="targetValue">Target value of the animation.</param>
    /// <param name="duration">Duration of the animation.</param>
    /// <param name="decimalPlaces">Number of decimal places to display.</param>
    /// <param name="OnComplete">Delegate method to invoke upon completion.</param>
    void PlayAnimationWithDelegate (float startValue, float targetValue, float duration, int decimalPlaces, Action OnComplete)
    {
        string formatString = "F" + decimalPlaces.ToString();
        DOVirtual.Float(startValue, targetValue, duration, (x) =>
        {
            selectedText.text = x.ToString(formatString);
        }).OnComplete(()=> OnComplete.Invoke());
    }
}
