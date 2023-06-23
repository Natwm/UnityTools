using UnityEngine;

namespace Blacktool.Backend.API.Store
{
    /// <summary>
    /// The first element of the Inheritance of all API class.
    /// </summary>
    public class APIStore : MonoBehaviour
    {
        [Header("API Object")] [SerializeField]
        protected APIScriptableObject api_Preview;

        [SerializeField] protected APIScriptableObject api_Prod;
        [SerializeField] protected APIScriptableObject api;

        public APIScriptableObject API => api;

        [Space] [SerializeField] protected string route;


        protected void Awake()
        {
#if (DEVELOPMENT_BUILD || UNITY_EDITOR || UNITY_INCLUDE_TESTS)
            api = api_Preview;
#else
            api = api_Prod;
#endif
        }

        public void APIError()
        {
            //ScreenManager.GoToErrorScreen();
        }
        
    }
}