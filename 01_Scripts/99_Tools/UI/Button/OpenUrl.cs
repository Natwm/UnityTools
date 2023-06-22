using UnityEngine;
using UnityEngine.UI;

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
