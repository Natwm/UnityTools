using System.Collections;
using System.Collections.Generic;
using Blackfoot.Tool.Narrative.Data;
using Blackfoot.Tool.Narrative.Data.Type.Enum;
using Blackfoot.Tool.Narrative.Screen.Base;
using UnityEngine;

namespace Blackfoot.Tool.Narrative.Screen.Success
{
    public class PopUpScreenBehaviours : NarrativeScreenBehaviours
    {
        public override void DisplayDialogue(NarrativeExchangeScriptableObject currentDialogue,
            DialogueScriptableObject dialogueElement,
            int dialogueIndex)
        {
            PopUpScreenScriptableObject currentState = currentDialogue as PopUpScreenScriptableObject;

            m_SpeakerImage.sprite = currentState.Speaker.GetVisual(CharacterVisualStatus.PopUp, Emotion.Happy);

            m_DialogueTitle.text = "PopUp Title"; //currentState.m_SuccessUnlock.Title;
            m_DialogueContent.text = "Pop Up Text"; //currentState.m_SuccessUnlock.content
        }
    }
}