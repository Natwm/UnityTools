using System.Collections.Generic;
using Blackfoot.Tool.Narrative.Data.Type.Enum;
using UnityEngine;

namespace Blackfoot.Tool.Narrative.Data.Type.Parameter
{
    /// <summary>
    /// Represents a set of visual references associated with character emotions.
    /// </summary>
    [System.Serializable]
    public class VisualReferences
    {
        public List<EmotionalReferences> m_ReferencesEmotionVisual;
        public CharacterVisualStatus m_Visual;

        /// <summary>
        /// Gets the visual representation (Sprite) associated with a specific emotion.
        /// </summary>
        /// <param name="status">The emotion for which to retrieve the visual representation.</param>
        /// <returns>The Sprite representing the specified emotion, or null if not found.</returns>
        public Sprite GetVisual(Emotion status)
        {
            foreach (var images in m_ReferencesEmotionVisual)
            {
                if (images.status == status)
                    return images.speakerImage;
            }

            return null;
        }
    }
}