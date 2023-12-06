using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Blackfoot.Tool.Narrative.Data
{
    [CreateAssetMenu(fileName = "SuccessNarrativeElement", menuName = "NarrativeScriptable/Screen/Success", order = 2)]
    public class SuccessScreenScriptableObject : NarrativeExchangeScriptableObject
    {
        //[BoxGroup("Data")][SerializeField] public SuccesScriptableObject m_SuccessUnlock;
        public override void OnDisplayDialogue()
        {
            //UnlockSucces
        }
    }
}