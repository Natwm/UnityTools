using UnityEngine;

namespace Utils.Tools
{
    public class TimeController : MonoBehaviour
    {
        public static TimeController instance;

        [Tooltip("Valeurs min pour relancer le slowmo")] [Min(1)] [SerializeField]
        private float minKillForSlowMotion;

        [SerializeField] private float slowMotionBaseDuration;
        [SerializeField] private float slowMotionGain;


        [Space] [Header("FLOW TIME CONTROL")] [SerializeField]
        private float normalFlowTime = 1;

        [SerializeField] private float slowMotionFlowTime = 0.1f;
        [SerializeField] private float FlowTimeLerpValue = 0.2f;

        public bool isActivedOnce = false;
        private float baseFixedDeltaTime;

        private int slowmoTimer = 0;
        public TimeNonAffectedTimer slowMotionTimer;

        private float targetFlowTime = 1;

        public TimeNonAffectedTimer SlowMotionTimer
        {
            get => slowMotionTimer;
            set => slowMotionTimer = value;
        }

        void Awake()
        {
            if (instance != null)
                Debug.LogWarning("Multiple instance of same Singleton : GameManager");
            instance = this;

            targetFlowTime = 1;
            Time.fixedDeltaTime = 0.01f;
            baseFixedDeltaTime = Time.fixedDeltaTime;
            slowMotionTimer = new TimeNonAffectedTimer(slowMotionBaseDuration, EndSlowMotion);
        }

        void FixedUpdate()
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, targetFlowTime, FlowTimeLerpValue);
            Time.fixedDeltaTime = baseFixedDeltaTime * Time.timeScale;
        }

        void SetTime(float secondDuration)
        {
            targetFlowTime = secondDuration;
        }

        public void LaunchSlowMotion()
        {
            slowMotionTimer = new TimeNonAffectedTimer(slowmoTimer, EndSlowMotion);

            isActivedOnce = true;
            slowMotionTimer.ResetPlay();
        }

        public void StartSlowMotion()
        {
            SetTime(slowMotionFlowTime);

            slowMotionTimer = new TimeNonAffectedTimer(slowMotionBaseDuration, EndSlowMotion);

            isActivedOnce = true;
            slowMotionTimer.ResetPlay();
        }

        public void MaintainSlowMotion()
        {
            if (slowMotionTimer.IsStarted() == true)
            {
                slowMotionTimer.Pause();
                slowMotionTimer =
                    new TimeNonAffectedTimer((slowMotionTimer.endTime - slowMotionTimer.Time) + slowMotionGain,
                        EndSlowMotion);
                slowMotionTimer.ResetPlay();
            }
        }

        private void EndSlowMotion()
        {
            SetTime(normalFlowTime);
        }

        public void increaseSlowMoTime()
        {
            slowmoTimer += 1;
        }

        public bool IsSlowMotion()
        {
            return slowMotionTimer.IsStarted();
        }
    }
}