using UnityEngine;
using DG.Tweening;
using System;

/// <summary>
/// Component for fading UI elements using CanvasGroup.
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class FadeComponent : MonoBehaviour
{
    private CanvasGroup CG;
    // Start is called before the first frame update
    void Start()
    {
        CG = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// Fade the CanvasGroup to a specified value over a specified duration with a specified easing function.
    /// </summary>
    /// <param name="value">Target opacity value (0 to 1).</param>
    /// <param name="duration">Duration of the fade animation.</param>
    /// <param name="animationEase">Easing function for the animation (default is linear).</param>
    public void Fade(float value, float duration, Ease animationEase = Ease.Linear)
    {
        CG.DOFade(value, duration).SetEase(animationEase);
    } 
    
    /// <summary>
    /// Fade the CanvasGroup to a specified value over a specified duration with a specified easing function. Invokes a delegate method upon completion.
    /// </summary>
    /// <param name="value">Target opacity value (0 to 1).</param>
    /// <param name="duration">Duration of the fade animation.</param>
    /// <param name="OnComplete">Delegate method to invoke upon completion.</param>
    /// <param name="animationEase">Easing function for the animation (default is linear).</param>
    public void FadeWithDelegate(float value, float duration,Action OnComplete, Ease animationEase = Ease.Linear)
    {
        CG.DOFade(value, duration).SetEase(animationEase).OnComplete(()=>OnComplete.Invoke());
    } 
    
    /// <summary>
    /// Fade in the CanvasGroup over a specified duration with a specified easing function.
    /// </summary>
    /// <param name="duration">Duration of the fade animation.</param>
    /// <param name="animationEase">Easing function for the animation (default is linear).</param>
    public void FadeIn(float duration, Ease animationEase = Ease.Linear)
    {
        Fade(1,duration,animationEase);
    } 
    
    /// <summary>
    /// Fade in the CanvasGroup over a specified duration with a specified easing function. Invokes a delegate method upon completion.
    /// </summary>
    /// <param name="duration">Duration of the fade animation.</param>
    /// <param name="OnComplete">Delegate method to invoke upon completion.</param>
    /// <param name="animationEase">Easing function for the animation (default is linear).</param>
    public void FadeInWithDelegate(float duration,Action OnComplete, Ease animationEase = Ease.Linear)
    {
        FadeWithDelegate(1,duration,OnComplete,animationEase);
    } 
    
    /// <summary>
    /// Fade out the CanvasGroup over a specified duration with a specified easing function.
    /// </summary>
    /// <param name="duration">Duration of the fade animation.</param>
    /// <param name="animationEase">Easing function for the animation (default is linear).</param>
    public void FadeOut(float duration, Ease animationEase = Ease.Linear)
    {
        Fade(0,duration,animationEase);
    } 
    
    /// <summary>
    /// Fade out the CanvasGroup over a specified duration with a specified easing function. Invokes a delegate method upon completion.
    /// </summary>
    /// <param name="duration">Duration of the fade animation.</param>
    /// <param name="OnComplete">Delegate method to invoke upon completion.</param>
    /// <param name="animationEase">Easing function for the animation (default is linear).</param>
    public void FadeOutWithDelegate(float duration,Action OnComplete , Ease animationEase = Ease.Linear)
    {
        FadeWithDelegate(0,duration,OnComplete,animationEase);
    } 
}
