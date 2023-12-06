using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Tool;
using UnityEngine;

public class FullRotationAnimation : MonoBehaviour
{
    public Ease animationEase = Ease.InBounce;
    [MinMaxSlider(5,50)] public MinMax speedRotation;

    public Sequence CreateAnimationSequenceRotateContinuously()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Insert(0,transform.DORotate(new Vector3(0f,0f,360f), speedRotation.RandomValue, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(animationEase));
        
        return sequence;
    }
    
}
