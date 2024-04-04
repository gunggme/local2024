using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCheat : MonoBehaviour
{
    public bool IsCheatShop;
    public GameObject isCheat;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            IsCheatShop = !IsCheatShop;
            isCheat.SetActive(IsCheatShop);
        }
    }
}
