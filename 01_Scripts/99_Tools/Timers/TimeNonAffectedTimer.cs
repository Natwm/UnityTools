namespace Blacktool.Utils.Tools
{
    public class TimeNonAffectedTimer : Timer
    {
        /// <summary>
        /// Crée un nouveau Timer non affecté par la vitesse d'écoulement du temps en jeu
        /// </summary>
        /// <param name="endTime">Temps de fin du chrono</param>
        public TimeNonAffectedTimer(float endTime) : base(endTime)
        {
        }

        /// <summary>
        /// Crée un nouveau Timer non affecté par la vitesse d'écoulement du temps en jeu
        /// </summary>
        /// <param name="endTime">Temps de fin du chrono</param>
        /// <param name="function">Fonction déclanché à la fin du timer.</param>
        public TimeNonAffectedTimer(float endTime, TimerFunction function) : base(endTime, function)
        {
        }

        /// <summary>
        /// Crée un nouveau Timer non affecté par la vitesse d'écoulement du temps en jeu
        /// </summary>
        /// <param name="endTime">Temps de fin du chrono</param>
        /// <param name="isAlreadyFinished">Le timer doit-il être fini tout de suite?</param>
        public TimeNonAffectedTimer(float endTime, bool isAlreadyFinished) : base(endTime, isAlreadyFinished)
        {
        }

        /// <summary>
        /// Crée un nouveau Timer non affecté par la vitesse d'écoulement du temps en jeu
        /// </summary>
        /// <param name="endTime">Temps de fin du chrono</param>
        /// <param name="function">Fonction déclanché à la fin du timer.</param>
        /// <param name="isAlreadyFinished">Le timer doit-il être fini tout de suite?</param>
        public TimeNonAffectedTimer(float endTime, TimerFunction function, bool isAlreadyFinished) : base(endTime,
            function, isAlreadyFinished)
        {
        }

        public override void Update(float delta)
        {
            base.Update(delta / UnityEngine.Time.timeScale);
        }
    }
}