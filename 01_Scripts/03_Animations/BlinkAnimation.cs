using System;
using System.Collections;
using System.Collections.Generic;
using Blacktool.Utils.Tools;
using DG.Tweening;
using Tool;
using UnityEngine;

public class BlinkAnimation : MonoBehaviour
{
    protected Timer t_BlinkTimer;

    [MinMaxSlider(0,2)][SerializeField] protected MinMax blinkSpeed;
    [MinMaxSlider(0,10)][SerializeField] protected MinMax randomTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        t_BlinkTimer = new Timer(randomTimer.RandomValue, Blink);
        t_BlinkTimer.ResetPlay();
    }


    protected virtual void Blink()
    {
        transform.DOScaleY(0, blinkSpeed.RandomValue).SetEase(Ease.Linear).SetLoops(2,LoopType.Yoyo)
            .OnComplete(()=>
            {
                t_BlinkTimer.endTime = randomTimer.RandomValue;
                print("t_BlinkTimer.endTime = "+t_BlinkTimer.endTime);
                t_BlinkTimer.ResetPlay();
            });
        
    }

    private void OnDestroy()
    {
        t_BlinkTimer.Pause();
    }
}
