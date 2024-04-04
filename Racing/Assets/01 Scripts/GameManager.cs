using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GoalType
{
    Player,
    AI
}

public class GameManager : MonoBehaviour
{
    LoadItem loadItem;
    public Transform startPos;

    AICar aiCar;
    PlayerCar playerCar;

    [SerializeField] CountdownText countDown;
    [SerializeField] ResultPageUI resultPage;
    public bool IsGameDone;
    [Header("Gold"), Space(10f)]
    public TMP_Text GoldText;

    [Header("Item")]
    public InGameShopPanel ShopPanel;
    public DeapearText eventText;

    Coroutine countCoroutine;

    [SerializeField] TMP_Text TimeText;

    public float GameTimer;
    public ItemCheat itemCheat;
    public GameObject StopScreen;

    [Space(10f)]
    public int soundNum;

    private void Start()
    {
        SoundManager.Instance.SoundPlay(soundNum, AudioType.BGM);
        loadItem = FindObjectOfType<LoadItem>();
        aiCar = FindObjectOfType<AICar>();
        GameObject playerObj = Instantiate(loadItem.EngineItem.CarPrefab, startPos.transform.position, startPos.rotation); 
        playerCar = playerObj.GetComponent<PlayerCar>();
        UpdateGoldText(0);
        aiCar.IsMove = false;
        playerCar.IsMove = false;
        IsGameDone = true;

        StartCoroutine(countDown.Countdoawn_Croutine(3, CountType.Start, () =>
        {
            aiCar.IsMove = true;
            playerCar.IsMove = true;
            IsGameDone = false;
        }));
    }

    private void Update()
    {
        if (!IsGameDone)
        {
            GameTimer += Time.deltaTime;
            CalculTime(GameTimer);
        }
    }

    public void CalculTime(float Time)
    {
        int min = 0;
        float sec = Time;

        while(sec >= 60)
        {
            sec -= 60;
            min++;
        }

        TimeText.text = $"Time : {min}:{sec:F2}";
    }

    public void UpdateGoldText(int gold)
    {
        SaveManager.Instance.CurData.GetGold(gold);
        GoldText.text = $"$ {SaveManager.Instance.CurData.Gold:N0}";
    }

    public void OpenShop()
    {
        ShopPanel.OnPanel(15);
    }

    public void Goal(GoalType type)
    {
        if(type == GoalType.Player)
        {
            if (IsGameDone)
            {
                if(countCoroutine != null)
                {
                    StopCoroutine(countCoroutine);
                }
                OpenResult(ResultType.Second, GameTimer);
                return;
            }

            OpenResult(ResultType.First, GameTimer);
            IsGameDone = true;
        }
        else
        {
            if (!IsGameDone)
            {
                IsGameDone = true;
                countCoroutine = StartCoroutine(countDown.Countdoawn_Croutine(5, CountType.Retire, () => {
                    OpenResult(ResultType.Retire);
                }));
                aiCar.IsMove = false;
            }
        }
    }

    public void EventOn(string text)
    {
        eventText.OnObj(text);
    }

    public void OpenResult(ResultType type, float timer = 0)
    {
        resultPage.OpenUI(type, timer);
    }

    public void OpenCheatItem()
    {
        itemCheat.gameObject.SetActive(!itemCheat.gameObject.activeSelf);
    }

    public void GameStop(bool isGameStop)
    {
        if (isGameStop)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        StopScreen.gameObject.SetActive(!isGameStop);
    }
}
