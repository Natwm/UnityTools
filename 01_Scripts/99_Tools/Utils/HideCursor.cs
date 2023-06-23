using UnityEngine;

/// <summary>
/// Hide the mouse cursor on start of the application
/// </summary>
	public class HideCursor : MonoBehaviour
	{
		private void Start()
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}