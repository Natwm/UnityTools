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

        public static string _userTokenKey;
    }
}