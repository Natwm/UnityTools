using System.Collections.Generic;
using System.Linq;
using Blackfoot.Tool.Narrative.Data.Type.Enum;
using Blackfoot.Tool.Narrative.Data.Type.Parameter;
using NaughtyAttributes;
using UnityEngine;


namespace Blackfoot.Tool.Narrative.Data
{
    [CreateAssetMenu(fileName = "BaseCharacter", menuName = "NarrativeScriptable/Character", order = 0)]
    public class CharacterScriptableObject : ScriptableObject
    {
        #region Parameter

        [BoxGroup("Visual")] [SerializeField] private List<VisualReferences> m_SpeakerImages;

        [SerializeField] private string m_CharacterName;


        #endregion

        #region Getter & Setter

        public string CharacterName => m_CharacterName;

        #endregion

        #region Character Logics

        /// <summary>
        /// Gets the visual representation (Sprite) associated with a specific character visual status and emotion.
        /// </summary>
        /// <param name="visual">The character visual status for which to retrieve the visual representation.</param>
        /// <param name="status">The emotion for which to retrieve the visual representation.</param>
        /// <returns>The Sprite representing the specified character visual status and emotion, or null if not found.</returns>
        public Sprite GetVisual(CharacterVisualStatus visual, Emotion status)
        {
            foreach (var images in m_SpeakerImages)
            {
                if (images.m_Visual == visual)
                    return images.GetVisual(status);
            }

            return null;
        }

        #endregion


        #region Events

        #endregion


    } 
}