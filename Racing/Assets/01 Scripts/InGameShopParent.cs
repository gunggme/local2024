using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameShopParent : MonoBehaviour
{
    InGameShopText[] shopTexts;

    private void Awake()
    {
        shopTexts = GetComponentsInChildren<InGameShopText>();
    }

    public void UpdateStates()
    {
        foreach(var shop in shopTexts)
        {
            shop.UpdateState();
        }
    }
}
