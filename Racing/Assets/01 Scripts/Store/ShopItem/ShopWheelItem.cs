using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new ShopWheelItem", menuName = "Shop/Wheel")]
public class ShopWheelItem : ShopItemBase
{
    public override bool BuyItem()
    {
        if (SaveManager.Instance.CurData.IsHaveMoney(Price))
        {
            // ������ ���� ����
            SaveManager.Instance.CurData.HaveWheels.Add(ItemName);
            return true;
        }
        else
        {
            // ������ ���� ����
            return false;
        }
    }

    public override bool CheatBuy()
    {
        // ������ ���� ����
        SaveManager.Instance.CurData.HaveWheels.Add(ItemName);
        return true;
    }


    public override void ChangeItem()
    {
        SaveManager.Instance.CurData.CurWheel = ItemName;
        equipItem.EquipItem();
    }


    public override bool isEquipItem()
    {
        if (!(SaveManager.Instance.CurData.CurWheel == (ItemName)))
        {
            return false;
            
        }
        return true;
    }

    public override bool IsHaveItem()
    {
        if (!SaveManager.Instance.CurData.HaveWheels.Contains(ItemName))
        {
            return false;
        }
        return true;
    }
}
