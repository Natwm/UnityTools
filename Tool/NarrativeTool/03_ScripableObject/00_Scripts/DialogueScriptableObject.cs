using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Blackfoot.Tool.Narrative.Data
{
    [CreateAssetMenu(fileName = "DialogueElement", menuName = "NarrativeScriptable/Dialogue", order = 0)]
    public class DialogueScriptableObject : ScriptableObject
    {
        #region Param

        public List<NarrativeExchangeScriptableObject> _Dialogue;

        public List<NarrativeExchangeScriptableObject> listOfUnskippableText;
        [ReadOnly] public List<int> unskippableElement = new List<int>();

        #endregion
        

        #region Logics

        /// <summary>
        /// Set the unskippable dialogue 
        /// </summary>
        private void SetUpUnskippableDialogue()
        {
            if(_Dialogue.Count <= 0)
                return;
        
            for (int dialogueIndex = 0; dialogueIndex < _Dialogue.Count; dialogueIndex++)
            {
                for (int unskippableIndex = 0; unskippableIndex < listOfUnskippableText.Count; unskippableIndex++)
                {
                    if(_Dialogue[dialogueIndex] == listOfUnskippableText[unskippableIndex] && !unskippableElement.Contains(dialogueIndex))
                        unskippableElement.Add(dialogueIndex);
                }
            }
        }
        
        /// <summary>
        ///  Can go to the previous panel on the current narrative
        /// </summary>
        /// <param name="currentDialogue"></param>
        /// <returns></returns>
        public bool IsPreviousDialogue(NarrativeExchangeScriptableObject currentDialogue)
        {
            int valueIndex = _Dialogue.GetIndex(currentDialogue);

            return valueIndex > 0;
        }
        
        
        /// <summary>
        /// Checks if the given index represents the last dialogue or beyond in the list.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns>True if the index is the last dialogue or beyond, false otherwise.</returns>
        public bool IsLastDialogue(int index)
        {
            return index >= _Dialogue.Count - 1;
        }

        /// <summary>
        /// Checks if there is a dialogue next to the one at the given index in the list.
        /// </summary>
        /// <param name="index">The index to check.</param>
        /// <returns>True if there is a dialogue next to the provided index, false otherwise.</returns>
        public bool IsDialogueNext(int index)
        {
            return index < _Dialogue.Count;
        }
        
        /// <summary>
        /// Attempt to change the screen type to a new screen object of a specific type.
        /// </summary>
        /// <param name="currentIndex">The current index in the dialogue list.</param>
        /// <param name="previousScreen">The previous screen object of type T to change to.</param>
        /// <typeparam name="T">The type of screen to change to, which must inherit from NarrativeExchangeScriptableObject.</typeparam>
        /// <returns>True if the change of screen type is necessary, false otherwise.</returns>
        public bool DoChangeScreen<T>(int currentIndex, T previousScreen ) where T : NarrativeExchangeScriptableObject
        {
            if (currentIndex < 0)
                return false;
            if (_Dialogue[currentIndex].GetType() != previousScreen.GetType())
            {
                return true; 
            }
            return false;
        }

        /// <summary>
        /// Get the NarrativeExchangeScriptableObject data at the specified index.
        /// </summary>
        /// <param name="index">The index of the dialogue data to retrieve.</param>
        /// <returns>The NarrativeExchangeScriptableObject data at the given index.</returns>
        public NarrativeExchangeScriptableObject GetDialogueData(int index)
        {
            return _Dialogue[index];
        }
        
        /// <summary>
        /// Gets the index of the selected NarrativeExchangeScriptableObject within the dialogue list.
        /// </summary>
        /// <param name="selectedExchange">The selected NarrativeExchangeScriptableObject to find the index of.</param>
        /// <returns>The index of the selectedExchange within the dialogue list, or -1 if not found.</returns>
        public int GetExchangeIndex(NarrativeExchangeScriptableObject selectedExchange)
        {
            int index = 0;
            foreach (var exchange in _Dialogue)
            {
                if (exchange == selectedExchange)
                    return index;
            }
            return -1;
        }

        #endregion

        #region Event

        public void OnNewDialogue()
        {
            
        }
        
        public void OnEndDialogue()
        {
            
        }

        #endregion
    }
}