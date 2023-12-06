using System;
using System.Collections;
using System.Collections.Generic;
using Blacktool.Patterns;
using Tool;
using UnityEngine;

#if UNITY_CINEMACHINE
using Cinemachine;

public class CameraController : Singleton<CameraController>
{
    public float baseShakeValue;

    public CinemachineVirtualCamera CMvC;

    [MinMaxSlider(35,120)]public MinMax f_FOVCamera;

    private bool increaseShake;

    Coroutine shakeCoroutine;
    Coroutine zoomCoroutine;
    private void Start()
    {
        increaseShake = false;
        baseShakeValue = CMvC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain;
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MakeZoomOut();
        }
    }*/

    public IEnumerator MakeItShakeForSomeSecond(float endvalue = 5f, float duration = 5f)
    {
print("pomme");
        MakeItShake(endvalue, duration / 2);
        
        yield return new WaitForSeconds(duration/2);
        
        MakeItShake(0, 1);
        
    }
    
    public void MakeItShake(float endvalue = 5f, float duration = 5f)
    {
        if (!increaseShake)
        {
            shakeCoroutine = StartCoroutine(LerpFunction(endvalue, duration));
        }

        if (endvalue == 0)
        {
            StopCoroutine(shakeCoroutine);
            shakeCoroutine = StartCoroutine(LerpFunction(endvalue, duration));
        }
    }

    IEnumerator LerpFunction(float endValue, float duration)
    {
        increaseShake = true;
            float time = 0;
            float startValue = baseShakeValue;
            while (time < duration)
            {
                CMvC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.Lerp(startValue, endValue, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            CMvC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = endValue;
            increaseShake = false;
    }

    public void MakeZoomOut()
    {
        if(zoomCoroutine != null)
            StopCoroutine(zoomCoroutine);
        
        zoomCoroutine = StartCoroutine(LerpFov(f_FOVCamera.Max, 0.5f));
    }
    public void MakeZoomIn()
    {
        if(zoomCoroutine != null)
            StopCoroutine(zoomCoroutine);
        zoomCoroutine = StartCoroutine(LerpFovIn(f_FOVCamera.Min, 0.5f));
    }
    
    IEnumerator LerpFov(float endValue, float duration)
    {
        increaseShake = true;
        float time = 0;
        float startValue = f_FOVCamera.Min;
        while (time < duration)
        {
            CMvC.m_Lens.OrthographicSize = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        CMvC.m_Lens.OrthographicSize = endValue;
        increaseShake = false;
    }
    
    IEnumerator LerpFovIn(float endValue, float duration)
    {
        increaseShake = true;
        float time = 0;
        float startValue = f_FOVCamera.Max;
        while (time < duration)
        {
            CMvC.m_Lens.OrthographicSize = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        CMvC.m_Lens.OrthographicSize = endValue;
        increaseShake = false;
    }
    
}
#endif
