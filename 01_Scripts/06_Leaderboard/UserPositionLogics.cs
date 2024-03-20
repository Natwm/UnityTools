using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserPositionLogics : MonoBehaviour
{
    public Image bgImage;
    public TMPro.TMP_Text stepText;
    public TMPro.TMP_Text nameText;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text increaseScoreText;

    public GameObject userVisual;
    public Sprite HolderVisual;
    public Sprite userHolderVisual;

    public Color playerColor;
    public Color userColor;

    public bool isUser;
    public int userScore;

    public void SetUp(int step, string playerName, int score,bool isUser = false)
    {
        this.isUser = isUser; 
        bgImage.sprite = isUser ? userHolderVisual : HolderVisual;
        userVisual.SetActive(false);

        stepText.text = step.ToString();
        stepText.color = this.isUser ? playerColor : userColor;
        nameText.text = playerName;
        nameText.color = this.isUser ? playerColor : userColor;
        scoreText.text = score.ToString();
        scoreText.color = this.isUser ? playerColor : userColor;

        userScore = score;
    }
    
    public void UpdateVisual(int step, int score, int increaseValue)
    {
        stepText.text = step.ToString();
        scoreText.text = score.ToString();
        
        userScore = score;

        increaseScoreText.text = "+" + increaseValue.ToString();
    }

    public void SetIncrease()
    {
        userVisual.SetActive(isUser);
    }
}
