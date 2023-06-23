using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_WWISE
namespace Blacktool.Tools
{
    public class WwiseTool : MonoBehaviour
    {
        public void StopWwiseEvent(string eventName, uint playingID) =>
            AkSoundEngine.ExecuteActionOnEvent(eventName, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, 0,
                out playingID);


        public void SetRTPCValue(string rtpcName, float value) =>
            AkSoundEngine.SetRTPCValue(rtpcName, value, gameObject);

        public void SetSwitchGroup(string switchGroupName, string switchState, GameObject gameObj) =>
            AkSoundEngine.SetSwitch(switchGroupName, switchState, gameObj);


        public void SetState(string stateGroupName, string stateName) =>
            AkSoundEngine.SetState(stateGroupName, stateName);

        public void RegisterGameObject(GameObject gameObj) =>
            AkSoundEngine.RegisterGameObj(gameObj, gameObj.name);

        public void PostTrigger(string triggerName) =>
            AkSoundEngine.PostTrigger(triggerName, gameObject);

        public void LoadBank(string bankName) =>
            AkBankManager.LoadBank(bankName, true, true);

        public void UnloadBank(string bankName) =>
            AkBankManager.UnloadBank(bankName, true, true);

        public void PlaySound(string enemyHitEvent, GameObject target)
        {
            AkSoundEngine.PostEvent(enemyHitEvent, target);
        }
    }
}
#endif