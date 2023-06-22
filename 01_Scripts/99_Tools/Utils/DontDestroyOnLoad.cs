using UnityEngine;

/// <summary>
/// Set the gameObject to not be deleted on load
/// </summary>
	public class DontDestroyOnLoad : MonoBehaviour
	{
		void Start() => DontDestroyOnLoad(gameObject);
	}