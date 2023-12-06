using System.Collections;
using System.Collections.Generic;
using Blacktool.Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : Singleton<CustomSceneManager>
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }
    
    public void LoadALevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    
    public void TryLoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(SceneManager.sceneCountInBuildSettings <= currentSceneIndex + 1)
            PlayerPrefs.SetInt("LoadLevel", 1);
        
        LoadNextLevel();
    }
    
    private void LoadNextLevel()
    {
        if (!PlayerPrefs.HasKey("LoadLevel"))
            LoadALevel(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            int randomIndex = Random.Range(0, SceneManager.sceneCountInBuildSettings + 1);
            LoadALevel(randomIndex);

        }
    }
}
