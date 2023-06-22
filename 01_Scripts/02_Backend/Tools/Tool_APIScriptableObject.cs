using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Tool_APIScriptableObject : ScriptableObject
{
    [System.Serializable]
    public class ApiRoad
    {
        public BackRoad roadCategory;
        public string road;

        public ApiRoad(BackRoad roadCategory, string road)
        {
            this.roadCategory = roadCategory;
            this.road = road;
        }
    }

    public bool m_IsProdApi;
    
    [Header("Dev data")]
    [SerializeField] private string apiKeyDev = "t84Gtj6S5FDCXsnydmrVfSQ6";
    [SerializeField] private string urlDev;

    [Header("Prod Data")]
    [SerializeField] private string apiKeyProd = "t84Gtj6S5FDCXsnydmrVfSQ6";
    [SerializeField] private string urlProd;
    
#if UNITY_EDITOR || DEVELOPMENT_BUILD
    [SerializeField] private bool verboseLog;
#endif
    [SerializeField] private int timeoutDuration = 10;
    
    private string token;

    [Header("Route")] 
    private List<ApiRoad> listOfRoad_Dev;
    private List<ApiRoad> listOfRoad_Prod;

    private Dictionary<BackRoad, string> backendRoad_Prod;
    private Dictionary<BackRoad, string> backendRoad_Dev;

    public enum BackRoad
    {
        LOGIN,
        SIGNIN,
        FORGOTPASSWORD,
        USERROUTE,
        ANALYTICS
    }
    
    private void OnEnable()
    {
        foreach (var roadInfo in listOfRoad_Dev)
        {
            backendRoad_Dev.Add(roadInfo.roadCategory,roadInfo.road);
        }
        
        foreach (var roadInfo in listOfRoad_Prod)
        {
            backendRoad_Prod.Add(roadInfo.roadCategory,roadInfo.road);
        }
    }

    public string GetBackendRoad(BackRoad askedRoad)
    {
        if (m_IsProdApi)
        {
            string road = backendRoad_Prod.ContainsKey(askedRoad) ? backendRoad_Prod[askedRoad] : "There isn't a road setup in the scriptableObject";
            return urlProd + road;
        }
        else
        {
            string road = backendRoad_Dev.ContainsKey(askedRoad) ? backendRoad_Dev[askedRoad] : "There isn't a road setup in the scriptableObject";
            return urlDev + road;
        }
    }
    
    
}
