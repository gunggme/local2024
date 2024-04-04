using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newEngine", menuName ="Equip/Engine")]
public class EquipEngineItem : EquipItemBase
{
    public GameObject CarPrefab;

    public float NormalSpeed;
    public float BoostSpeed;
    public float MegaBoostSpeed;

    public override void EquipItem()
    {
        
    }
}
