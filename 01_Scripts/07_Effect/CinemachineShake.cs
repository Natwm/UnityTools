#if UNITY_CINEMACHINE

using System.Collections;
using Tool;
using UnityEngine;

/// <summary>
/// Manages camera shake effects using Cinemachine.
/// </summary>
public class CinemachineShake : MonoBehaviour
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
    
    /// <summary>
    /// Initiates a camera shake effect.
    /// </summary>
    /// <param name="endvalue">The final amplitude value of the shake effect.</param>
    /// <param name="duration">The duration of the shake effect.</param>
    public void MakeItShake(float endvalue = 1.5f, float duration = 2f)
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
    
    /// <summary>
    /// Lerps the camera shake effect from the start value to the end value over a specified duration.
    /// </summary>
    /// <param name="endValue">The final amplitude value of the shake effect.</param>
    /// <param name="duration">The duration of the shake effect.</param>
    /// <returns>An IEnumerator for the coroutine.</returns>
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
        yield return new WaitForSeconds(1f);
        CMvC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        increaseShake = false;
    }
}
#endif