using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FadeScreen : MonoBehaviour
{
	[SerializeField] private Image image;

	private Color defaultFadeInColorTarget = Color.black;
	private Color defaultFadeOutColorTarget = Color.black.WithAlpha(0);

	public void FadeOut(float fadeDuration)
	{
		image.color = defaultFadeOutColorTarget;
		image.DOFade(1f, fadeDuration);
	}

	public void FadeOut()
	{
		image.color = defaultFadeOutColorTarget;
		image.DOFade(1f, 0.5f);
	}

	public IEnumerator FadeOutCore(float fadeDuration)
	{
		image.color = defaultFadeOutColorTarget;
		Tweener fade = image.DOFade(1f, fadeDuration);
		yield return fade.WaitForCompletion();
	}

	public IEnumerator FadeOutCore()
	{
		image.color = defaultFadeOutColorTarget;
		Tweener fade = image.DOFade(1f, 0.5f);
		yield return fade.WaitForCompletion();
	}

	public void FadeIn(float fadeDuration)
	{
		image.color = defaultFadeInColorTarget;
		image.DOFade(0f, fadeDuration);
	}

	public void FadeIn()
	{
		image.color = defaultFadeInColorTarget;
		image.DOFade(0f, 0.5f);
	}

	public IEnumerator FadeInCore(float fadeDuration)
	{
		image.color = defaultFadeInColorTarget;
		Tweener fade = image.DOFade(0f, fadeDuration);
		yield return fade.WaitForCompletion();
	}

	public IEnumerator FadeInCore()
	{
		image.color = defaultFadeInColorTarget;
		Tweener fade = image.DOFade(0f, 0.5f);
		yield return fade.WaitForCompletion();
	}
}