using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Tool;
using UnityEngine;

public class SquishAnimation : MonoBehaviour
{
    
    [Header("Animation")] 
    [MinMaxSlider(1,5)] public MinMax scaleXAnimation;
    [MinMaxSlider(0,5)] public MinMax scaleYAnimation ;
    [MinMaxSlider(0,2)] public MinMax durationXAnimation ;
    [MinMaxSlider(0,2)] public MinMax durationYAnimation;
    public Ease animationEase = Ease.InBounce;

    private Tween squishTweenX;
    private Tween squishTweenY;
    
    private Vector3 originalScale;

    public bool isPlayOnAwake = false;

    private void Start()
    {
        originalScale = transform.localScale; 
        if(isPlayOnAwake)
            CreateLoopAnimationSequence();
    }
    
    public void PlaySquishAnimation()
    {
        if (squishTweenX != null && squishTweenX.IsActive())
        {
            squishTweenX.Kill();
        }

        if (squishTweenY != null && squishTweenY.IsActive())
        {
            squishTweenY.Kill();
        }

        squishTweenX = transform.DOScaleX(scaleXAnimation.RandomValue, durationXAnimation.RandomValue)
            .SetEase(animationEase)
            .SetLoops(2, LoopType.Yoyo)
            .OnComplete(() => ResetToOriginalScale());

        squishTweenY = transform.DOScaleY(scaleYAnimation.RandomValue, durationYAnimation.RandomValue)
            .SetEase(animationEase)
            .SetLoops(2, LoopType.Yoyo);
    }
    
    private void ResetToOriginalScale()
    {
        transform.localScale = originalScale; // Rétablissement de l'échelle d'origine
    }

    public void StopSquishAnimation()
    {
        if (squishTweenX != null && squishTweenX.IsActive())
        {
            squishTweenX.Kill();
            ResetToOriginalScale(); // Rétablissement de l'échelle d'origine si l'animation est arrêtée manuellement
        }

        if (squishTweenY != null && squishTweenY.IsActive())
        {
            squishTweenY.Kill();
            ResetToOriginalScale(); // Rétablissement de l'échelle d'origine si l'animation est arrêtée manuellement
        }
    }

    public Sequence CreateLoopAnimationSequence()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Insert(0,transform.DOScaleX(scaleXAnimation.RandomValue, durationYAnimation.RandomValue).SetEase(animationEase).SetLoops(-1, LoopType.Yoyo));

        sequence.Insert(0,transform.DOScaleY(scaleYAnimation.RandomValue, durationXAnimation.RandomValue).SetEase(animationEase).SetLoops(-1, LoopType.Yoyo));

        return sequence;
    }
}
