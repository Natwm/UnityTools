using UnityEngine;

namespace Blacktool.Utils
{
    [CreateAssetMenu(fileName = "BuildVer", menuName = "App/BuildVer")]
    public class BuildVer : ScriptableObject
    {
        public string buildVersion;
    }
}