using Blackfoot.Tool.Narrative.Data.Type.Enum;
using NaughtyAttributes;
using UnityEngine;


namespace Blackfoot.Tool.Narrative.Data
{
    [CreateAssetMenu(fileName = "BaseNarrativeElement", menuName = "NarrativeScriptable/Screen/Dialogue", order = 0)]
    public class NarrativeExchangeScriptableObject : ScriptableObject
    {
        #region Parameter

        //[BoxGroup("Content Parametter")][SerializeField] private ScreenType typeOfDialogue;
        [BoxGroup("Speaker Data")][SerializeField] private CharacterScriptableObject m_speaker;
        
        [BoxGroup("Speaker Parameter")][SerializeField] private CharacterVisualStatus m_SpeakerVisual;
        [BoxGroup("Speaker Parameter")][SerializeField] private Emotion m_SpeakerEmotion;

        
        [BoxGroup("Dialogue")][SerializeField][TextArea(10,10)] private string[] m_Dialogue;

        [BoxGroup("Dialogue")][SerializeField][TextArea(10,10)] private string[] m_Response;
        [BoxGroup("Dialogue")][SerializeField][TextArea(10,10)] private string[] m_ParametterToUse;

        #endregion
        
        #region Getter & Setter
        public CharacterScriptableObject Speaker => m_speaker;

        public string[] Dialogue => m_Dialogue;

        public string[] Response => m_Response;

        #endregion

        #region Dialogue Logics

        /// <summary>
        /// Checks if any parameters are set for this dialogue element.
        /// </summary>
        /// <returns>True if there are parameters set; otherwise, false.</returns>
        public bool IsParametterUsed()
        {
            return m_ParametterToUse.Length > 0;
        }

        /// <summary>
        /// Gets the visual representation (Sprite) for the character associated with this dialogue element.
        /// </summary>
        /// <returns>The Sprite representing the character's visual appearance and emotion.</returns>
        public Sprite GetCharacterVisual()
        {
            return m_speaker.GetVisual(m_SpeakerVisual, m_SpeakerEmotion);
        }
        #endregion
        
        #region Events

        public virtual void OnDisplayDialogue()
        {
            
        }
        
        public virtual void OnHideDialogue()
        {
            
        }

        #endregion

        
    } 
}


