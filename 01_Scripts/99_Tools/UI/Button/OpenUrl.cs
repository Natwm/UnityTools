using UnityEngine;
using UnityEngine.UI;

namespace Blacktool.UI.Interactable.ButtonElement
{
    /// <summary>
    /// This class is used to open url link
    /// </summary>
    public class OpenUrl : MonoBehaviour
    {
        public string buttonURL;
        Button button;

        public void Open()
        {
            Application.OpenURL(buttonURL);
        }
    } 
}

