using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameCheat : MonoBehaviour
{
    Dictionary<KeyCode, Action> KeyActions;
    GameManager gameManager;

    public bool IsShopCheat;

    public bool IsGameStop;
    public GameObject isCheatText;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        KeyActions = new Dictionary<KeyCode, Action>()
        {
            {KeyCode.F1, F1_Func},
            {KeyCode.F2, F2_Func},
            {KeyCode.F3, F3_Func},
            {KeyCode.F4, F4_Func},
            {KeyCode.F5, F5_Func},
            {KeyCode.F6, F6_Func},
            {KeyCode.F7, F7_Func},
        };

        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            foreach(var dic in KeyActions)
            {
                if (Input.GetKeyDown(dic.Key)) {
                    dic.Value?.Invoke();
                }
            }
        }
    }

    void F1_Func()
    {
        gameManager.OpenCheatItem();
    }
    void F2_Func()
    {
        IsShopCheat = !IsShopCheat;
        isCheatText.SetActive(IsShopCheat);
    }
    void F3_Func()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void F4_Func()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Play_Desert":
                SceneManager.LoadScene("Play_Mountain");
                break;
            case "Play_Mountain":
                SceneManager.LoadScene("Play_City");
                break;
            case "Play_City":
                SceneManager.LoadScene("Play_Desert");
                break;
        }
    }
    void F5_Func()
    {
        if (IsGameStop)
        {
            IsGameStop = false;
        }
        else
        {
            IsGameStop = true;
        }
        gameManager.GameStop(!IsGameStop);
    }
    void F6_Func()
    {
        gameManager.Goal(GoalType.Player);
    }

    void F7_Func()
    {
        gameManager.Goal(GoalType.AI);
    }
}
