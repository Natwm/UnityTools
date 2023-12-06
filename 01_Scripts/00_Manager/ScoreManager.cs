using System;
using System.Collections;
using System.Collections.Generic;
using Blacktool.Patterns;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int currentScore = 1;

    public void IncreaseScore(int score)
    {
        currentScore += score  ;
    }

    public void SetBestScore()
    {
        if (!PlayerPrefs.HasKey("Best Score"))
        {
            PlayerPrefs.SetInt("Best Score", currentScore);
            return;
        }
        
        if (currentScore > PlayerPrefs.GetInt("Best Score"))
        {
            PlayerPrefs.SetInt("Best Score", currentScore);
        }
    }
}
