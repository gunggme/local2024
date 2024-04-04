using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameShopText : MonoBehaviour
{
    TMP_Text itemText;
    public ShopItemBase ShopItem;

    InGameShopParent shopParent;
    InGameCheat inGameCheat;
    private void Awake()
    {
        inGameCheat = FindObjectOfType<InGameCheat>();
        shopParent = GetComponentInParent<InGameShopParent>();
        itemText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        itemText.text += System.Environment.NewLine + $"{ShopItem.ItemName}" + System.Environment.NewLine + $"$ {ShopItem.Price}";
        UpdateState();
    }

    public void UpdateState()
    {
        if (ShopItem.IsHaveItem())
        {
            itemText.color = Color.red;
        }
        else
        {
            itemText.color = Color.white;
        }
    }

    public bool BuyItem()
    {
        if (ShopItem.IsHaveItem())
        {
            return false;
        }
        else if (inGameCheat.IsShopCheat)
        {
            ShopItem.CheatBuy();
        }
        else
        {
            ShopItem.BuyItem();
        }

        shopParent.UpdateStates();
        return true;
    }
}
