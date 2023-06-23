using UnityEngine;

/// <summary>
/// Destroy the current object after a fix duration, just after it's initialization
/// </summary>
	public class DestroyAfterLoad : MonoBehaviour
	{
		[SerializeField] private float durationBeforeDestroy;

		private void Start() => Initialize(durationBeforeDestroy);

		/// <summary>
		/// Initialize the destruction of the gameobject
		/// </summary>
		/// <param name="duration"></param>
		public void Initialize(float duration) => Destroy(gameObject, duration);
	}