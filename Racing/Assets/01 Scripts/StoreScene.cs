using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StoreScene : MonoBehaviour
{
    public DeapearText EventText;
    public TMP_Text GoldText;

    public void Awake()
    {
        SaveManager.Instance.Score = 0;
    }

    private void Start()
    {
        SoundManager.Instance.SoundPlay(5, AudioType.BGM);
        UpdateGold();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.Alpha0) && Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(8);
        }
    }

    public void BuySuccess()
    {
        EventText.OnObj("Purchase Success!");
    }

    public void BuyFailed()
    {
        EventText.OnObj("Purchase Failed..");
    }

    public void UpdateGold()
    {
        GoldText.text = $"$ {SaveManager.Instance.CurData.Gold:N0}";
    }

    public void Play_Btn()
    {
        SceneManager.LoadScene(2);
    }

    public void MainBtn()
    {
        SaveManager.Instance.Init();
        SceneManager.LoadScene(0);
    }
}
