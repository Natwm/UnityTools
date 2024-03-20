using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if POST_PROCESSING_STACK_2
using UnityEngine.Rendering.PostProcessing;

public class VignetteEffects : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;

    public float targetMaxIntensity = 0.25f;
    
    public void ModifyVignette(float value)
    {
        if (postProcessVolume == null)
        {
            Debug.LogError("PostProcessVolume not assigned!");
            return;
        }

        Vignette vignette;

        if (postProcessVolume.profile.TryGetSettings(out vignette))
        {
            vignette.intensity.value = value * targetMaxIntensity;
        }
        else
        {
            Debug.LogError("Vignette not found in PostProcessVolume!");
        }
    }
}
#endif