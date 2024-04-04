using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopItemBase : ScriptableObject
{
    public string ItemName;
    public int Price;

    public EquipItemBase equipItem;

    public abstract bool IsHaveItem();
    public abstract bool isEquipItem();
    public abstract bool BuyItem();
    public abstract bool CheatBuy();
    public abstract void ChangeItem();
}
