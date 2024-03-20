using DG.Tweening;
using System;
using Blacktool.Patterns;
using UnityEngine;

public class GameBase : Singleton<GameBase>
{
	public event Action OnLoadingEvent;
	public event Action OnStartRunningEvent;
	public event Action OnGameOverEvent;
	public event Action OnPauseEvent;
	
	private GameState state;

	public GameState State
	{
		get => state;
		set
		{
			state = value;

			switch (value)
			{
				case GameState.Loading:
					OnLoadingEvent?.Invoke();
					break;

				case GameState.GameOver:
					OnGameOverEvent?.Invoke();
					break;

				case GameState.Pause:
					OnPauseEvent?.Invoke();
					break;

				case GameState.Running:
					OnStartRunningEvent?.Invoke();
					break;
			}
		}
	}

	public bool IsRunning => state == GameState.Running;

	protected void Awake()
	{

		Application.targetFrameRate = 60;

		DOTween.Init();
		DOTween.defaultAutoPlay = AutoPlay.All;

		// Disable screen dimming
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
}