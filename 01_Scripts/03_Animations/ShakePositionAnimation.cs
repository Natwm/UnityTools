using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Tool;
using UnityEngine;

public class ShakePositionAnimation : MonoBehaviour
{
    [MinMaxSlider(0,1)] public MinMax _shakeDuratiion;
    [MinMaxSlider(0,1)] public MinMax _shakeStrenght;
    [MinMaxSlider(10,30)] public MinMax _shakeVibrato;
    public float _shakeRandomness;
  
    private Vector3 originalPosition; 
    
    private Tween _shakeTween;
    
    private void Start()
    {
        originalPosition = transform.position; // Sauvegarde de la position d'origine au démarrage
    }
    
    public void ShakePosition(bool usedBaseValue = true, float shakeDuratiion = 1, float shakeStrenght = 1, int shakeVibrato = 10, float shakeRandomness = 90)
    {
        if (_shakeTween != null && _shakeTween.IsActive())
        {
            _shakeTween.Kill();
        }
        
        if(usedBaseValue)
            _shakeTween = transform.DOShakePosition(_shakeDuratiion.RandomValue, _shakeStrenght.RandomValue,
                Mathf.RoundToInt(_shakeVibrato.RandomValue), _shakeRandomness).OnComplete(()=>ResetToOriginalPosition());
        else
            _shakeTween = transform.DOShakePosition(shakeDuratiion, shakeStrenght, shakeVibrato,
                shakeRandomness).OnComplete(()=>ResetToOriginalPosition());
    }

    public void StopShake()
    {
        if (_shakeTween != null && _shakeTween.IsActive())
        {
            _shakeTween.Kill();
            ResetToOriginalPosition();
        }
    }
    
    private void ResetToOriginalPosition()
    {
        transform.position = originalPosition; 
    }
}
