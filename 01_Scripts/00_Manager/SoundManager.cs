using System.Collections;
using System.Collections.Generic;
using Blacktool.Patterns;
using UnityEngine;

// <summary>
/// This class is used to contain all the audio logics of the game  
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource _Audio;
    [SerializeField] private AudioSource _Audio2;
    [SerializeField] private AudioClip uiClick;

    [Space] public float Timer = 0;

    [SerializeField] private float TimerFactor;
    [SerializeField] private float maxTransitionTime;

    [Header("Curve")] public AnimationCurve fadeInCurve;
    
    [Header("AudioClip")]
    [SerializeField] private AudioClip choiceMusic;
    [SerializeField] private AudioClip battleMusic;
    [SerializeField] private AudioClip menuMusic;

    private bool isStop = false;

    private void Start()
    {
        _Audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Get a random sound from a list
    /// </summary>
    /// <param name="sounds">List of sound to play</param>
    /// <returns>Return one sound from the sounds list</returns>
    public static AudioClip GetRandomSound(List<AudioClip> sounds)
    {
        int index = Random.Range(0, sounds.Count);
        return sounds[index];
    }

    /// <summary>
    /// Play a 2D sound
    /// </summary>
    /// <param name="clip">The audio clip to play</param>
    public void PlaySound(AudioClip clip)
    {
        _Audio.clip = clip;
        _Audio.Play();
    }

    /// <summary>
    /// [DEPRECATED]
    /// play a click sound
    /// Just For UI element
    /// </summary>
    public void PlayClickUI()
    {
        _Audio.clip = uiClick;
        _Audio.Play();
    }

    /// <summary>
    /// Play a random audio clip at a specific element( 3D sound)
    /// </summary>
    /// <param name="_soundArray">List of sounds</param>
    /// <param name="_playerObject">Object who play this sound</param>
    public void PlayRandomAudioSource(AudioClip[] _soundArray, GameObject _playerObject)
    {
        Debug.Log(_soundArray[0].name);
        if (!isStop)
        {
            isStop = true;
            int RandomInt = Random.Range(0, _soundArray.Length);
            AudioClip tempSource = _soundArray[RandomInt];
            _playerObject.GetComponent<AudioSource>().PlayOneShot(tempSource);
        }
    }

    /// <summary>
    /// Play a cross fade between two audio sources
    /// </summary>
    /// <param name="_fadeIn">The Audio source which will fade in</param>
    /// <param name="_fadeOut">The Audio source which will fade in</param>
    /// <returns>IEnumerator</returns>
    public IEnumerator CrossFade(AudioSource _fadeIn, AudioSource _fadeOut)
    {
        Timer = 0;
        while (Timer < maxTransitionTime)
        {
            Timer += Time.deltaTime / TimerFactor;
            _fadeIn.volume = fadeInCurve.Evaluate(Timer);
            _fadeOut.volume = 1 - fadeInCurve.Evaluate(Timer);
            yield return null;
        }

        yield return null;
    }

    public void PlayMenue()
    {
        _Audio.clip = menuMusic;
        _Audio.Play();
    }
    
    public void PlayChoice()
    {
        _Audio.clip = choiceMusic;
        _Audio.Play();
    }
    
    public void PlayBattle()
    {
        _Audio.clip = battleMusic;
        _Audio.Play();
    }

    public void CrossFade_MenuToChoice()
    {
        _Audio2.clip = choiceMusic;
        StartCoroutine(CrossFade(_Audio, _Audio2));
    }
    
    public void CrossFade_ChoiceToBattle()
    {
        _Audio.clip = battleMusic;
        StartCoroutine(CrossFade(_Audio2, _Audio));
    }
    
    public void CrossFade_BattleToMenu()
    {
        _Audio2.clip = menuMusic;
        StartCoroutine(CrossFade(_Audio, _Audio2));
    }
}