using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ResultType
{
    First,
    Second,
    Retire
}

public class ResultPageUI : MonoBehaviour
{
    public TMP_Text RankText;
    public TMP_Text LapText;
    public TMP_Text GoldText;
    public Button nextButton;
    public Button RetryButton;

    public int Gold;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OpenUI(ResultType type, float time = 0)
    {
        gameObject.SetActive(true);
        float sec = time, min = 0;
        while(sec > 60)
        {
            sec -= 60;
            min++;
        }

        switch (type)
        {
            case ResultType.First:
                RankText.text = "1st";
                LapText.text = $"{min}:{sec:f2}";
                SaveManager.Instance.Score += Mathf.RoundToInt((1000 - (1000 * ((min / 10) + (sec / 100)))));
                gameManager.UpdateGoldText(Gold);
                SoundManager.Instance.SoundPlay(11, AudioType.FBX);
                GoldText.text = $"+ $ {Gold:N0}";
                nextButton.gameObject.SetActive(true);
                RetryButton.gameObject.SetActive(false);
                break;
            case ResultType.Second:
                RankText.text = "2nd";
                LapText.text = $"{min}:{sec:f2}";
                GoldText.gameObject.SetActive(false);
                SoundManager.Instance.SoundPlay(12, AudioType.FBX);
                nextButton.gameObject.SetActive(false);
                RetryButton.gameObject.SetActive(true);
                break;
            case ResultType.Retire:
                RankText.text = "Retire!";
                LapText.gameObject.SetActive(false);
                GoldText.gameObject.SetActive(false);
                SoundManager.Instance.SoundPlay(12, AudioType.FBX);
                nextButton.gameObject.SetActive(false);
                RetryButton.gameObject.SetActive(true);
                break;
        }
    }
}
