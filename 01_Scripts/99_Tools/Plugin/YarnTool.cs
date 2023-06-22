using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
#if YARNSPINNER_PRESENT
using Yarn.Unity;
#endif

public class YarnTool : MonoBehaviour
{
    #if YARNSPINNER_PRESENT
    public DialogueRunner dialogueRunner;
    public InMemoryVariableStorage variableStorage;

    public void JumpToNode(string nodeName) =>
        dialogueRunner.Dialogue.SetNode(nodeName);
    
    public void StopDialogue() =>
        dialogueRunner.Stop();

    public void ContinueDialogue() =>
        dialogueRunner.Dialogue.Continue();
    
    public void ChangeYarnFile(string yarnScriptFileName, string startDialogue = "start")
    {
        // Charger le fichier Yarn
        YarnProject yarnScript = Resources.Load<YarnProject>(yarnScriptFileName);

        // Effacer les scripts existants du dialogue runner
        dialogueRunner.Clear();

        // Ajouter le nouveau script Yarn
        dialogueRunner.SetProject(yarnScript);

        // Démarrer le dialogue
        dialogueRunner.StartDialogue(startDialogue);
    }
    
    private void JumpToTargetNode(string startDialogue = "start") => 
        dialogueRunner.StartDialogue(startDialogue);

    #region Getter && Setter

    public void SetYarnVariable(string variableName, string variableValue) =>
        variableStorage.SetValue(variableName, variableValue);

    public T GetYarnVariable<T>(string variableName)
    {
        T temp;
        variableStorage.TryGetValue<T>(variableName, out temp);
        return temp;
    }
    
    #endregion

    #region Animation

    [YarnCommand("Pose")]
    public void SetPose(string poseName)
    {
        string stateName = "Base Layer." + poseName;
        Debug.Log($"{name} playing {stateName}");
        //animator.Play(stateName, 0);
    }

    #endregion
#endif
}
