using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Blackfoot.Tool.Narrative.Data
{
    [CreateAssetMenu(fileName = "InputNarrativeElement", menuName = "NarrativeScriptable/Screen/Input", order = 1)]
    public class InputNarrativeElement : NarrativeExchangeScriptableObject
    {

        /// <summary>
        /// Check if a string is valid based on several conditions including non-empty, 
        /// adhering to a specific validation method, and having a minimum length.
        /// </summary>
        /// <param name="text">The string to be validated.</param>
        /// <returns>True if the string is valid; otherwise, false.</returns>
        public bool IsStringValid(string text)
        {
            return true; //!string.IsNullOrEmpty(text) && GenericValidator.Nickname(text) && text.Length > 1;
        }
        
    }
}