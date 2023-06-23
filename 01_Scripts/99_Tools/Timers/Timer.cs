namespace Blacktool.Utils.Tools
{
    public class Timer
    {
        public delegate void TimerFunction();

        public float endTime;
        protected bool isReversed = false;
        protected TimerState state = TimerState.PAUSED;
        protected float time = 0f;


        /// <summary>
        /// Crée un nouveau Timer
        /// </summary>
        /// <param name="endTime">Temps de fin du chrono</param>
        public Timer(float endTime)
        {
            TimerManager.SetupTimer(this);
            this.endTime = endTime;
        }

        /// <summary>
        /// Crée un nouveau Timer
        /// </summary>
        /// <param name="endTime">Temps de fin du chrono</param>
        /// <param name="function">Fonction déclanché à la fin du timer.</param>
        public Timer(float endTime, TimerFunction function) : this(endTime)
        {
            OnTimerEnd += function;
        }

        /// <summary>
        /// Crée un nouveau Timer
        /// </summary>
        /// <param name="endTime">Temps de fin du chrono</param>
        /// <param name="isAlreadyFinished">Le timer doit-il être fini tout de suite?</param>
        public Timer(float endTime, bool isAlreadyFinished) : this(endTime)
        {
            if (isAlreadyFinished)
            {
                time = endTime;
                state = TimerState.FINISHED;
            }
        }

        /// <summary>
        /// Crée un nouveau Timer
        /// </summary>
        /// <param name="endTime">Temps de fin du chrono</param>
        /// <param name="function">Fonction déclanché à la fin du timer.</param>
        /// <param name="isAlreadyFinished">Le timer doit-il être fini tout de suite?</param>
        public Timer(float endTime, TimerFunction function, bool isAlreadyFinished) : this(endTime, isAlreadyFinished)
        {
            OnTimerEnd += function;
        }

        public float EndTime
        {
            get { return endTime; }
            set
            {
                Reset();
                endTime = value;
            }
        }

        public bool IsReversed
        {
            get { return isReversed; }
            set { isReversed = value; }
        }

        public float Time
        {
            get { return time; }
            set
            {
                if (state == TimerState.UPDATING)
                {
                    if (value >= endTime)
                    {
                        time = endTime;
                        state = TimerState.FINISHED;
                        if (OnTimerEnd != null)
                            OnTimerEnd();
                    }
                    else if (value <= 0)
                    {
                        time = 0;
                        state = TimerState.PAUSED;
                    }
                    else
                        time = value;
                }
            }
        }

        public event TimerFunction OnTimerEnd;
        public event TimerFunction OnTimerUpdate;


        /// <summary>
        /// Remet le timer à 0.
        /// /!\ Reset() ne relance pas le timer!
        /// Pour cela, il y a ResetPlay()
        /// </summary>
        public void Reset()
        {
            state = TimerState.PAUSED;
            time = 0f;
        }

        /// <summary>
        /// Pause le timer.
        /// </summary>
        public void Pause()
        {
            state = TimerState.PAUSED;
        }

        /// <summary>
        /// Détermine si ce timer est fini.
        /// </summary>
        public bool IsFinished()
        {
            return state == TimerState.FINISHED;
        }

        /// <summary>
        /// Détermine si ce timer est en Pause.
        /// </summary>
        public bool IsPaused()
        {
            return state == TimerState.PAUSED;
        }

        /// <summary>
        /// Détermine si ce timer est lancé ou non.
        /// </summary>
        /// <returns><c>true</c> if this instance is started; otherwise, <c>false</c>.</returns>
        public bool IsStarted()
        {
            return state == TimerState.UPDATING;
        }

        /// <summary>
        /// Lance le timer.
        /// /!\ Cette méthode ne remet pas le timer à 0!
        /// Pour cela, il y a la méthode Reset().
        /// </summary>
        public void Play()
        {
            state = TimerState.UPDATING;
        }

        /// <summary>
        /// Reset et lance le timer
        /// </summary>
        public void ResetPlay()
        {
            Reset();
            Play();
        }

        public virtual void Update(float delta)
        {
            if (state == TimerState.UPDATING)
            {
                if (OnTimerUpdate != null)
                    OnTimerUpdate();
                Time = isReversed ? Time - delta : Time + delta;
            }
        }

        public float GetPercentage()
        {
            return Time / EndTime;
        }

        public float GetPercentageLeft()
        {
            return 1 - (Time / EndTime);
        }

        public float GetTimeLeft()
        {
            return EndTime - Time;
        }
    }

    public enum TimerState
    {
        PAUSED,
        FINISHED,
        UPDATING
    };
}