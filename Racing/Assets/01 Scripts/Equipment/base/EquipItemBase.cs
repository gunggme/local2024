using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipItemBase : ScriptableObject
{
    public string ItemName;

    public abstract void EquipItem();
}
