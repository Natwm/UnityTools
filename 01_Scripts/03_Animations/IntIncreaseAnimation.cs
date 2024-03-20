using UnityEngine;
using DG.Tweening;
using System;

/// <summary>
/// Component for animating integer increase on a TextMeshPro text element.
/// </summary>
public class IntIncreaseAnimation : MonoBehaviour
{
    private TMPro.TMP_Text selectedText;

    /// <summary>
    /// Animates the increase of an integer from a start value to a target value over a specified duration.
    /// </summary>
    /// <param name="startValue">Starting value of the animation.</param>
    /// <param name="targetValue">Target value of the animation.</param>
    /// <param name="duration">Duration of the animation.</param>
    void  PlayAnimation(int startValue, int targetValue, float duration)
    {
        DOVirtual.Int(startValue, targetValue, duration, (x) =>
        {
            selectedText.text = x.ToString();
        });
    }
    
    /// <summary>
    /// Animates the increase of an integer from a start value to a target value over a specified duration. Invokes a delegate method upon completion.
    /// </summary>
    /// <param name="startValue">Starting value of the animation.</param>
    /// <param name="targetValue">Target value of the animation.</param>
    /// <param name="duration">Duration of the animation.</param>
    /// <param name="OnComplete">Delegate method to invoke upon completion.</param>
    void PlayAnimationWithDelegate (int startValue, int targetValue, float duration, Action OnComplete)
    {
        DOVirtual.Int(startValue, targetValue, duration, (x) =>
        {
            selectedText.text = x.ToString();
        }).OnComplete(()=> OnComplete.Invoke());
    }
}
