using System;
using System.Collections;
using System.Collections.Generic;
using Blackfoot.Tool.Narrative.Data;
using Blackfoot.Tool.Narrative.Screen.Base;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class NarrativeScreenManager : MonoBehaviour
{
    #region Param

    [SerializeField] private NarrativeScreenBehaviours baseNarrative;
    [SerializeField] private NarrativeScreenBehaviours inputNarrative;
    [SerializeField] private NarrativeScreenBehaviours popupNarrative;
    [SerializeField] private NarrativeScreenBehaviours successNarrative;
    public NarrativeScreenBehaviours currentScreen;
    
    [BoxGroup("NarativeElement")] public DialogueScriptableObject m_DialogueElement;
    [BoxGroup("NarativeElement")] public NarrativeExchangeScriptableObject m_CurrentDialogue;

    public delegate void NarrativeStateEvent();

    public event NarrativeStateEvent OnNarrativeStart;
    public event NarrativeStateEvent OnNarrativeEnd;
    
    private int dialogueIndex;

    #endregion
    

    #region Getter && Setter

    public DialogueScriptableObject DialogueElement
    {
        get => m_DialogueElement;
        set => m_DialogueElement = value;
    }


    #endregion
    
    private void Start()
    {
        OnNarrativeEnd += HideAllDialogueScreen;
        SetUp(m_DialogueElement);
    }
    
    /// <summary>
    /// Set up the dialogue based on the provided `DialogueElement` and optional `index`.
    /// </summary>
    /// <param name="DialogueElement">The `DialogueScriptableObject` containing the dialogue data.</param>
    /// <param name="index">Optional index to specify the starting point in the dialogue (default is 0).</param>
    private void SetUp(DialogueScriptableObject DialogueElement, int index = 0)
    {
        OnNarrativeStart.Invoke();
        
        dialogueIndex = index;
        m_DialogueElement = DialogueElement;
        m_CurrentDialogue = m_DialogueElement.GetDialogueData(dialogueIndex);

        if (currentScreen == null)
        {
            SwitchVisual();
        }
        currentScreen.DisplayDialogue(m_CurrentDialogue,m_DialogueElement,dialogueIndex);
    }
    
    /// <summary>
    /// Display the provided `dialogue`.
    /// </summary>
    /// <param name="dialogue">The `NarrativeExchangeScriptableObject` to display.</param>
    private void DisplayDialogue(NarrativeExchangeScriptableObject dialogue)
    {
        dialogueIndex = DialogueElement.GetExchangeIndex(dialogue);

        currentScreen.DisplayDialogue(m_CurrentDialogue,m_DialogueElement,dialogueIndex);
    }

    /// <summary>
    /// Display the dialogue at the specified `dialogue` index.
    /// </summary>
    /// <param name="dialogue">The index of the dialogue to display.</param>
    private void DisplayDialogue(int dialogue)
    {
        dialogueIndex = dialogue;
        currentScreen.DisplayDialogue(m_CurrentDialogue,m_DialogueElement,dialogueIndex);
    }
    
    /// <summary>
    /// Jump to a specific dialogue page by its `pageIndex`.
    /// </summary>
    /// <param name="pageIndex">The index of the dialogue page to jump to.</param>
    public void JumpToPage(int pageIndex)
    {
        if(pageIndex >= DialogueElement._Dialogue.Count || pageIndex < 0 )
            return;

        DisplayDialogue(DialogueElement.GetDialogueData(pageIndex));
    }

    /// <summary>
    /// Skip the dialogue to the next unskippable dialogue.
    /// </summary>
    public void SkipDialogue()
    {
        foreach (var unskippableIndex in DialogueElement.unskippableElement)
        {
            if (unskippableIndex >= dialogueIndex)
            {
                DisplayDialogue(unskippableIndex);
                return;
            }
        }
        this.gameObject.SetActive(false);
    }

    #region Dialogue Movement

    /// <summary>
    /// Display the next dialogue in the sequence.
    /// </summary>
    private void DisplayNextDialogue()
    {
        dialogueIndex ++;
        if (m_DialogueElement.DoChangeScreen(dialogueIndex, m_DialogueElement.GetDialogueData(dialogueIndex - 1)))
        {
            SwitchVisual();
        }
        m_CurrentDialogue = m_DialogueElement.GetDialogueData(dialogueIndex);
        currentScreen.DisplayDialogue(m_CurrentDialogue,m_DialogueElement,dialogueIndex);
    }

    private void SwitchVisual()
    {
        var obj = m_DialogueElement.GetDialogueData(dialogueIndex);

        SuccessScreenScriptableObject castToSucces = obj as SuccessScreenScriptableObject;
        PopUpScreenScriptableObject castToPopup = obj as PopUpScreenScriptableObject;
        InputNarrativeElement castToInput = obj as InputNarrativeElement;

        if (castToSucces != null)
        {
            ChangeScreen(successNarrative);
        }
        else if (castToPopup != null)
        {
            ChangeScreen(popupNarrative);
        }
        else if (castToInput != null)
        {
            ChangeScreen(inputNarrative);
        }
        else
        {
            ChangeScreen(baseNarrative);
        }
    }

    private void ChangeScreen(NarrativeScreenBehaviours screenToDisplay)
    {
        baseNarrative.gameObject.SetActive(false);
        inputNarrative.gameObject.SetActive(false);
        popupNarrative.gameObject.SetActive(false);
        successNarrative.gameObject.SetActive(false);
        
        screenToDisplay.gameObject.SetActive(true);
        currentScreen = screenToDisplay;
    }

    /// <summary>
    /// Display the previous dialogue in the sequence.
    /// </summary>
    private void DisplayPreviousDialogue()
    {
        if(dialogueIndex - 1 < 0)
            return;
        
        dialogueIndex --;

        SwitchVisual();

        m_CurrentDialogue = m_DialogueElement.GetDialogueData(dialogueIndex);
        currentScreen.DisplayDialogue(m_CurrentDialogue,m_DialogueElement,dialogueIndex);
    }

    /// <summary>
    /// Play the next dialogue in the sequence if available.
    /// </summary>
    public void PlayNextDialogue()
    {
        if (!DialogueElement.IsDialogueNext(dialogueIndex))
        {
            OnNarrativeEnd.Invoke();
            return;
        }
        
        DisplayNextDialogue();
    }
    
    /// <summary>
    /// Play the previous dialogue in the sequence if available.
    /// </summary>
    public void PlayPreviousDialogue()
    {
        if(!DialogueElement.IsPreviousDialogue(m_CurrentDialogue))
            return;
        
        DisplayPreviousDialogue();
    }

    #endregion

    /// <summary>
    /// Reset all narrative element
    /// </summary>
    private void HideAllDialogueScreen()
    {
        baseNarrative.gameObject.SetActive(false);
        inputNarrative.gameObject.SetActive(false);
        popupNarrative.gameObject.SetActive(false);
        successNarrative.gameObject.SetActive(false);
        currentScreen = null;
    }

    private void OnDisable()
    {
        OnNarrativeEnd -= HideAllDialogueScreen;
    }
}
