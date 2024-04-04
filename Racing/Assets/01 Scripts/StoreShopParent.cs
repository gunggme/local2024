using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreShopParent : MonoBehaviour
{
    public StoreShopButten[] buttons;

    private void Awake()
    {
        buttons = GetComponentsInChildren<StoreShopButten>();
    }

    public void UpdateStates()
    {
        foreach(var b in buttons)
        {
            b.UpdateState();
        }
    }
}
