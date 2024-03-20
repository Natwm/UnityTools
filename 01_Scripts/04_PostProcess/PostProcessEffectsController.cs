#if POST_PROCESSING_INSTALLED

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessEffectsController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Bloom bloomEffect;
    private Vignette vignetteEffect;
    private MotionBlur motionBlurEffect;

    private void Start()
    {
        // Obtenez les composants d'effet de post-processus
        bloomEffect = postProcessVolume.GetPostProcessComponent<Bloom>();
        vignetteEffect = postProcessVolume.GetPostProcessComponent<Vignette>();
        motionBlurEffect = postProcessVolume.GetPostProcessComponent<MotionBlur>();
    }

    // Méthode pour modifier l'intensité du bloom
    public void SetBloomIntensity(float intensity)
    {
        if (bloomEffect != null)
        {
            bloomEffect.intensity.Override(intensity);
        }
    }

    // Méthode pour modifier l'intensité de la vignette
    public void SetVignetteIntensity(float intensity)
    {
        if (vignetteEffect != null)
        {
            vignetteEffect.intensity.Override(intensity);
        }
    }

    // Méthode pour activer/désactiver le flou de mouvement
    public void SetMotionBlurEnabled(bool enabled)
    {
        if (motionBlurEffect != null)
        {
            motionBlurEffect.enabled.Override(enabled);
        }
    }
}


#endif