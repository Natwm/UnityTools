#if POST_PROCESSING_INSTALLED

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public static class PostProcessExtensions
{
    /// <summary>
    /// Obtient le composant d'effet de post-processus correspondant à un type spécifique.
    /// </summary>
    /// <typeparam name="T">Le type de composant d'effet de post-processus à rechercher.</typeparam>
    /// <param name="volume">Le volume de post-processus contenant les effets.</param>
    /// <returns>Le composant d'effet de post-processus trouvé, ou null s'il n'est pas trouvé.</returns>
    public static T GetPostProcessComponent<T>(this PostProcessVolume volume) where T : PostProcessEffectSettings
    {
        if (volume != null && volume.profile != null)
        {
            foreach (var effect in volume.profile.components)
            {
                if (effect is T)
                {
                    return (T)effect;
                }
            }
        }
        return null;
    }
}

#endif