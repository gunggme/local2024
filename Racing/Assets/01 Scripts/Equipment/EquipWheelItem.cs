using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWheel", menuName = "Equip/Wheel")]
public class EquipWheelItem : EquipItemBase
{
    public Material CarMaterial;
    public Texture Changetextur;

    public LayerMask layers;
    public float Deaccelation;

    public override void EquipItem()
    {
        CarMaterial.mainTexture = Changetextur;
    }
}
