using System.Collections;
using System.Collections.Generic;
using Blackfoot.Tool.Narrative.Data;
using Blackfoot.Tool.Narrative.Data.Type.Enum;
using Blackfoot.Tool.Narrative.Screen.Base;
using UnityEngine;

namespace Blackfoot.Tool.Narrative.Screen.Success
{
    public class SuccessScreenBehaviours : NarrativeScreenBehaviours
    {
        public override void DisplayDialogue(NarrativeExchangeScriptableObject currentDialogue,
            DialogueScriptableObject dialogueElement,
            int dialogueIndex)
        {
            SuccessScreenScriptableObject currentState = currentDialogue as SuccessScreenScriptableObject;

            //if(currentState.m_SuccessUnlock != null)
                UnlockBadge();

                m_SpeakerImage.sprite = currentState.Speaker.GetVisual(CharacterVisualStatus.PopUp, Emotion.Happy);

                m_DialogueTitle.text = "Badges Title"; //currentState.m_SuccessUnlock.Title;
                m_DialogueContent.text = "Badges Text"; //currentState.m_SuccessUnlock.content
        }

        public void UnlockBadge()
        {
            //Unlock Badge
        }
    }
}