using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameShopPanel : MonoBehaviour
{
    public float CurTime;
    public TMP_Text timeText;
    InGameCheat inGameCheat;

    public Dictionary<KeyCode, int> inputKeys = new Dictionary<KeyCode, int>()
    {
        {KeyCode.Alpha1, 0},
        {KeyCode.Alpha2, 1},
        {KeyCode.Alpha3, 2},
        {KeyCode.Alpha4, 3},
        {KeyCode.Alpha5, 4},
    };

    public InGameShopText[] ShopTexts;

    private void Update()
    {
        if (Input.anyKey)
        {
            foreach(var dic in inputKeys)
            {
                if (Input.GetKeyDown(dic.Key))
                {
                    if (ShopTexts[dic.Value].BuyItem())
                    {
                        Debug.Log("구매 성공");
                        CurTime = 0;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CurTime = 0;
        }

        if(CurTime > 0)
        {
            CurTime -= Time.deltaTime;
            timeText.text = $"{CurTime:F0}";
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPanel(float time)
    {
        CurTime = time;
        gameObject.SetActive(true);
    }
}
