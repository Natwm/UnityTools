using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAnimator : MonoBehaviour
{
    public Image[] listOfStarIndicator;

    [Header("Animation param")] 
    public Vector3 endScale;
    public float animationDuration;
    public Ease selectedEase;

    public bool isUsingCurve;
    public AnimationCurve easeCurve;
    public float delayBtwAnim;

    public ParticleSystem[] starParticle;
    public void SetScoreVisual(int score = 0)
    {
        InitScreen();
        
        if(score <= 0)
            return;

        StartCoroutine(TestEnumaratorScale(score));
        //SetAnimation(score);
    }

    private void InitScreen()
    {
        foreach (var selectedStar in listOfStarIndicator)
        {
            RectTransform startTransform = selectedStar.GetComponent<RectTransform>();

            startTransform.localScale = Vector3.zero;
        }
    }

    private void SetAnimation(int score = 0)
    {
        Sequence sequence = DOTween.Sequence();
        for (int iteration = 0; iteration < score; iteration++)
        {
            RectTransform startTransform = listOfStarIndicator[iteration].GetComponent<RectTransform>();
            if(isUsingCurve)
                sequence.Append(startTransform.DOScale(endScale, animationDuration)
                    .SetEase(easeCurve)
                    /*.SetDelay(iteration * delayBtwAnim)*/);
            else
            {
                sequence.Append(startTransform.DOScale(endScale, animationDuration)
                        .SetEase(selectedEase).OnComplete(()=>starParticle[iteration].Play())
                    /*.SetDelay(iteration * delayBtwAnim)*/);
            }
        }
    }

    private IEnumerator TestEnumaratorScale(int score = 0)
    {
        for (int iteration = 0; iteration < score; iteration++)
        {
            RectTransform startTransform = listOfStarIndicator[iteration].GetComponent<RectTransform>();
            if (isUsingCurve)
                startTransform.DOScale(endScale, animationDuration)
                    .SetEase(easeCurve);
            else
            {
                startTransform.DOScale(endScale, animationDuration)
                    .SetEase(selectedEase);
            }

            starParticle[iteration].Play();
            yield return new WaitForSeconds(delayBtwAnim);
        }
    }
}
