using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



[System.Serializable]
public class ListGamePlayerData
{
    public List<LeaderBoardEntry> datas;
}

public class LeaderBoardLogics : MonoBehaviour
{
    
    public int amountOfElmentToSpawn;
    public GameObject leaderBoardElement;
    public Transform spanwEltParent;

    private List<GameObject> scrollElement = new List<GameObject>();
    
    public ScrollRect scrollView;
    public RectTransform contentPanel;

    public Sprite bgGame;
    public Sprite bgScreen;
    public Image bg;
    // Start is called before the first frame update
    
    public List<LeaderBoardEntry> playerDataList;
    public string jsonData; // Changer le type de TextAsset à string

    private GameObject user;
    void Start()
    {
        bg.sprite = SceneManager.GetActiveScene().buildIndex != 0 ? bgGame : bgScreen;
    }

    public void SetLeaderBoard()
    {
        if(user != null)
            return;
        
        string playerPrefData = PlayerPrefs.GetString("Player");

        var data = JsonUtility.FromJson<LeaderBoardEntry>(playerPrefData);
        
        playerDataList.Add(data);

        ConvertJsonToPlayerDataList();
        SortPlayerDataListByScore();
        
        for (int i = 0; i < playerDataList.Count; i++)
        {
            GameObject elt = Instantiate(leaderBoardElement,spanwEltParent);
            UserPositionLogics userlogics = elt.GetComponent<UserPositionLogics>();
            
            userlogics.SetUp(i + 1, playerDataList[i].Name,(int)playerDataList[i].Value);
            
            scrollElement.Add(elt);
            if (userlogics.isUser)
                user = elt;
        }

        StartCoroutine(SetPositionToPlayer());
        
        user.name = "user";
    }

    private IEnumerator SetPositionToPlayer()
    {
        yield return new WaitForSeconds(0.25f);
        MoveToTarget(user.GetComponent<RectTransform>());
        yield return new WaitForSeconds(1.2f);
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            int currentScore = ScoreManager.Instance.GetCurrentScore();
            int userScore = user.GetComponent<UserPositionLogics>().userScore;
            if ( currentScore> userScore)
            {
                StartCoroutine(LeaderBoardAnimation());
            }
        }
    }
    
    public float ScrollToElement(GameObject targetElement)
    {
        // Assurez-vous que le ScrollView et le contenu sont définis
        if (scrollView == null || contentPanel == null)
        {
            Debug.LogWarning("ScrollView ou ContentPanel non défini !");
            return -1;
        }

        // Vérifiez si l'élément cible est dans le contenu
        if (!targetElement.transform.IsChildOf(contentPanel))
        {
            Debug.LogWarning("L'élément cible n'est pas dans le contenu !");
            return -1;
        }

        // Calculez la position de l'élément cible par rapport au contenu
        RectTransform targetRectTransform = targetElement.GetComponent<RectTransform>();
        Vector2 targetLocalPosition = contentPanel.InverseTransformPoint(targetRectTransform.position);

        // Calculez la position normalisée de l'élément par rapport au contenu (entre 0 et 1)
        float normalizedPosition = (float)targetLocalPosition.y / (float)contentPanel.rect.height;

        // Assurez-vous que la position normalisée est dans les limites de [0, 1]
        normalizedPosition = Mathf.Clamp01(-normalizedPosition);

        // Définir la position de défilement
        //scrollView.verticalNormalizedPosition = 1f - normalizedPosition - 0.13278016f;
        return 1f - normalizedPosition;
    }

    private IEnumerator LeaderBoardAnimation()
    {
        yield return new WaitForSeconds(.5f);
        user.transform.parent = transform;
        user.transform.DOScale(1.15f, 1);
        
        UserPositionLogics userLogics = user.GetComponent<UserPositionLogics>();
        userLogics.userScore = ScoreManager.Instance.GetCurrentScore();

        int newindex = scrollElement.Count(elt =>
            elt.GetComponent<UserPositionLogics>().userScore > user.GetComponent<UserPositionLogics>().userScore);

        scrollElement.Remove(user);
        scrollElement.Insert(newindex, user);
        
        user.GetComponent<UserPositionLogics>().UpdateVisual(newindex,userLogics.userScore,Int32.Parse(userLogics.stepText.text) - newindex);

        yield return new WaitForSeconds(0.5f);
        MoveToRect(contentPanel.transform.GetChild(newindex).GetComponent<RectTransform>(),newindex);
        
        ScoreManager.Instance.SetBestScore();

    }

    private void MoveToTarget(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();
        Vector2 viewPort = scrollView.viewport.localPosition;
        Vector2 targetElt = target.localPosition;

        Vector2 newPos = new Vector2(0 - (viewPort.x + targetElt.x),
            0 -(viewPort.y + targetElt.y));
        contentPanel.DOAnchorPos(newPos, 1f).SetEase(Ease.OutQuad);
    }
    
    private void MoveToRect(RectTransform target, int index)
    {
        Canvas.ForceUpdateCanvases();
        Vector2 viewPort = scrollView.viewport.localPosition;
        Vector2 targetElt = target.localPosition;

        Vector2 newPos = new Vector2(0 - (viewPort.x + targetElt.x),
            0 -(viewPort.y + targetElt.y));
        contentPanel.DOAnchorPos(newPos, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            user.transform.DOScale(1f, 1);
            user.GetComponent<UserPositionLogics>().SetIncrease();

            user.transform.parent = contentPanel.transform;
            user.transform.SetSiblingIndex(index);
        });
        
    }
    
    
    void ConvertJsonToPlayerDataList()
    {
        string jsonString = String.Empty;//param.JsonLeaderboard.ToString();
        ListGamePlayerData tempPlayerDataList = JsonUtility.FromJson<ListGamePlayerData>(jsonString);
        if (tempPlayerDataList != null)
        {
            playerDataList.AddRange(tempPlayerDataList.datas);
        }
    }

    void SortPlayerDataListByScore()
    {
        playerDataList = playerDataList.OrderByDescending(playerData => playerData.Value).ToList();
    }

}
