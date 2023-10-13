using Blackfoot.Tool.Narrative.Data;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Blackfoot.Tool.Narrative.Screen.Base
{
    public class NarrativeScreenBehaviours : MonoBehaviour
    {
        #region Parametter

        [BoxGroup("DialogueContent")] [SerializeField]
        protected TMP_Text m_DialogueTitle;

        [BoxGroup("DialogueContent")] [SerializeField]
        protected TMP_Text m_DialogueContent;

        [BoxGroup("Visual")] [SerializeField] protected Image m_SpeakerImage;
        [BoxGroup("Visual")] [SerializeField] private Image m_DialogueHolder;

        [BoxGroup("Visual Button")] [SerializeField]
        private Button m_PreviousButton;

        [BoxGroup("Visual Button")] [SerializeField]
        private Button m_NextButton;

        [BoxGroup("Visual Button")] [SerializeField]
        private Button m_SkipButton;

        public TMP_Text backText;

        #endregion


        #region Getter && Setter

        public Button PreviousButton => m_PreviousButton;

        public Button NextButton => m_NextButton;

        public Button SkipButton => m_SkipButton;

        public TMP_Text DialogueTitle => m_DialogueTitle;

        public TMP_Text DialogueContent => m_DialogueContent;

        #endregion

        public virtual void DisplayDialogue(NarrativeExchangeScriptableObject currentDialogue,
            DialogueScriptableObject dialogueElement,
            int dialogueIndex)
        {
            m_SpeakerImage.sprite = currentDialogue.GetCharacterVisual();
            DialogueContent.text = currentDialogue.Dialogue[0];
            DialogueTitle.text = currentDialogue.Speaker.CharacterName;

            if (!dialogueElement.IsPreviousDialogue(currentDialogue))
                PreviousButton.gameObject.SetActive(false);
            else
                PreviousButton.gameObject.SetActive(true);
        }

    }
}