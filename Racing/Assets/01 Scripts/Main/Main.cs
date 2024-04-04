using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public TMP_Text RankText;

    public void Start()
    {
        // todo 랭킹 불러오기
        SaveManager.Instance.LoadRank();
        if(!(SaveManager.Instance.RankingData.rankingData.Count == 0))
        {
            RankText.text = string.Empty;
            for(int i = 0; i < SaveManager.Instance.RankingData.rankingData.Count; i++)
            {
                RankText.text += $"{i+1}. {SaveManager.Instance.RankingData.rankingData[i].PlayerName} " +
                    $"| {SaveManager.Instance.RankingData.rankingData[i].PlayerScore:N0}" + System.Environment.NewLine;
            }
        }
        SoundManager.Instance.SoundPlay(1, AudioType.BGM);
    }

    public void MoveSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void EXIT_Btn()
    {
        Application.Quit();
    }
}
