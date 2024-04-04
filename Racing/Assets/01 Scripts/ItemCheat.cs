using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheat : MonoBehaviour
{
    Dictionary<KeyCode, Action> KeyActions;
    GameManager gameManager;
    PlayerCar playerCar;

    public void Awake()
    {
        KeyActions = new Dictionary<KeyCode, Action>()
        {
            {KeyCode.Keypad1, Num1_Func },
            {KeyCode.Keypad2, Num2_Func },
            {KeyCode.Keypad3, Num3_Func },
            {KeyCode.Keypad4, Num4_Func },
            {KeyCode.Keypad5, Num5_Func },
            {KeyCode.Keypad6, Num6_Func }
        };
        gameManager = FindObjectOfType<GameManager>();
        playerCar = FindObjectOfType<PlayerCar>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            foreach(var dic in KeyActions)
            {
                if (Input.GetKeyDown(dic.Key))
                {
                    dic.Value?.Invoke();
                }
            }
        }
    }

    void Num1_Func()
    {
        gameManager.UpdateGoldText(100);
        gameManager.EventOn("+ $ 100");
    }
    void Num2_Func()
    {
        gameManager.UpdateGoldText(500);
        gameManager.EventOn("+ $ 500");
    }
    void Num3_Func()
    {
        gameManager.UpdateGoldText(1000);
        gameManager.EventOn("+ $ 1000");
    }
    void Num4_Func()
    {
        playerCar.StartCoroutine(playerCar.Boost(BoostType.Boost));
        gameManager.EventOn("Boost!");
        
    }
    void Num5_Func()
    {
        playerCar.StartCoroutine(playerCar.Boost(BoostType.MegaBoost));
        gameManager.EventOn("Mega Boost!!");
    }
    void Num6_Func()
    {
        gameManager.OpenShop();
        gameManager.EventOn("ShopOpen!");
    }
}
