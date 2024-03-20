using UnityEngine;

namespace Blacktool.Utils.PlayerPref
{
    /// <summary>
    /// This class is used to store every key used for PlayerPrefs (or Sprefs)
    /// This should be the only way to use a local key to avoid typos or having multiple keys storing the same data
    /// </summary>
    public class UserPrefsStrings
    {
        [Header("Player Keys")] [SerializeField]
        public static readonly string _usernameKey = "Player/Username";
        
        public static readonly string _duplicateCardsKey = "Player/Duplicate";
        public static readonly string _uniqueCardsKey = "Player/Unique";
        public static readonly string _totalCardsKey = "Player/Cards";
        public static readonly string _emailKey = "Player/Email";
        public static readonly string _currentTradesKey = "Player/CurrentTrades";
        public static readonly string _lastScannedCode = "Player/LastScannedCode";
        public static readonly string _lastDayConnexion = "Player/LastConnexion";
        public static readonly string _userClientKey = "Player/UserClientKey";
        public static readonly string _userTokenKey = "Player/UserTokenKey";

        [Header("Game Keys")] [SerializeField] public static readonly string _remainingDaysKey = "Game/RemainingDays";

        public static readonly string _missionsKey = "Game/Missions";
        public static readonly string _maxCardsKey = "Game/MaxCards";
        public static readonly string _popup2CardsKey = "Game/2cardspopup";
        public static readonly string _popup5CardsKey = "Game/5cardspopup";

        [Header("Tutorials Keys")] [SerializeField]
        public static readonly string _onboardingExchangeKey = "Tutorials/Exchange";

        public static readonly string _onboardingKey = "Tutorials/Onboarding";
        public static readonly string _onboardingCollectionsKey = "Tutorials/Collections";
        public static readonly string _onboardingLotsKey = "Tutorials/Lots";

        [Header("Settings Keys")] [SerializeField]
        public static readonly string _muteKey = "Settings/Muted";

        public static readonly string _notificationsChoiceKey = "Settings/NotificationChoice";
    }
}