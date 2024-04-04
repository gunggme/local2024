using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreShopButten : MonoBehaviour
{
    public ShopItemBase ShopItem;
    StoreShopParent shopParent;
    TMP_Text itemText;
    StoreScene storeScene;
    Button button;

    StoreCheat storeCheat;

    private void Awake()
    {
        storeScene = FindObjectOfType<StoreScene>();
        storeCheat = FindObjectOfType<StoreCheat>();
        shopParent = GetComponentInParent<StoreShopParent>();
        button = GetComponent<Button>();
        itemText = GetComponentInChildren<TMP_Text>();
        button.onClick.AddListener(Btn_OnClick);
    }

    private void Start()
    {
        UpdateState();
        if (ShopItem.IsHaveItem())
        {
            if (ShopItem.isEquipItem())
            {
                ShopItem.ChangeItem();
            }
        }
    }

    public void UpdateState()
    {
        if (ShopItem.IsHaveItem())
        {
            if (ShopItem.isEquipItem())
            {
                itemText.text = $"{ShopItem.ItemName}" + System.Environment.NewLine + $"Equipped";
                button.interactable = false;
            }
            else
            {
                itemText.text = $"{ShopItem.ItemName}" + System.Environment.NewLine + $"Equip";
                button.interactable = true;
            }
        }
        else
        {
          itemText.text = $"{ShopItem.ItemName}" + System.Environment.NewLine + $"$ {ShopItem.Price}";
        }
    }

    public void Btn_OnClick()
    {
        if (ShopItem.IsHaveItem())
        {
            SoundManager.Instance.SoundPlay(7, AudioType.FBX);
            ShopItem.ChangeItem();
        }
        else if (storeCheat.IsCheatShop)
        {
            ShopItem.CheatBuy();
            storeScene.BuySuccess();
        }
        else
        {
            if (ShopItem.BuyItem())
            {
                storeScene.BuySuccess();
            }
            else
            {
                storeScene.BuyFailed();
            }
        }

        storeScene.UpdateGold();
        shopParent.UpdateStates();
        SaveManager.Instance.SaveData();
    }
}
