using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItem : MonoBehaviour
{
    public EquipEngineItem EngineItem;
    public EquipWheelItem WheelItem;

    private void Awake()
    {
        LoadItems();
    }

    public void LoadItems()
    {
        EngineItem = Resources.Load<EquipEngineItem>("Equip/" + SaveManager.Instance.CurData.CurEngine);
        WheelItem = Resources.Load<EquipWheelItem>("Equip/" + SaveManager.Instance.CurData.CurWheel);
    }
}
