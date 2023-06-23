using UnityEngine;

namespace Blackfoot.Tools
{
    [CreateAssetMenu(fileName = "BuildVer", menuName = "App/BuildVer")]
    public class BuildVer : ScriptableObject
    {
        public string buildVersion;
    }
}