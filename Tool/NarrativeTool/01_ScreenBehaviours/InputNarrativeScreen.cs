using System.Collections;
using System.Collections.Generic;
using Blackfoot.Tool.Narrative.Data;
using Blackfoot.Tool.Narrative.Screen.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Blackfoot.Tool.Narrative.Screen.Input
{
    public class InputNarrativeScreen : NarrativeScreenBehaviours
    {
        public UnityEvent callbackEvent;
        
        public TMP_InputField inputField;

        private string fieldData;
        
        
        public void SendResponse()
        {
            InputNarrativeElement SO = FindObjectOfType<NarrativeScreenManager>().m_CurrentDialogue as InputNarrativeElement;
            
            if(!SO.IsStringValid(fieldData))
                print("pasbien");
            
            callbackEvent.Invoke();
        }

        public void UpdataFieldData(string value)
        {
            fieldData = value;
        }
    }
}