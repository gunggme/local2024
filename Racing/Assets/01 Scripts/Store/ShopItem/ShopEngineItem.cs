using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new ShopEngineItem", menuName = "Shop/Engine")]
public class ShopEngineItem : ShopItemBase
{
    public GameObject CarModel;

    public override bool BuyItem()
    {
        if (SaveManager.Instance.CurData.IsHaveMoney(Price))
        {
            // ������ ���� ����
            SaveManager.Instance.CurData.HaveEngines.Add(ItemName);
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
        SaveManager.Instance.CurData.HaveEngines.Add(ItemName);
        return true;
    }

    public override void ChangeItem()
    {
        SaveManager.Instance.CurData.CurEngine = ItemName;
        CarPreview carPreview = FindObjectOfType<CarPreview>();
        carPreview.ChangePreviewItem(CarModel);
        equipItem.EquipItem();
    }

    public override bool isEquipItem()
    {
        if (!(SaveManager.Instance.CurData.CurEngine == (ItemName)))
        {
            return false;
        }
        return true;
    }

    public override bool IsHaveItem()
    {
        if (!SaveManager.Instance.CurData.HaveEngines.Contains(ItemName))
        {
            return false;
        }
        return true;
    }
}
