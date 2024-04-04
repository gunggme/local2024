using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeapearText : MonoBehaviour
{
    TMP_Text eventText;

    private void Awake()
    {
        eventText = GetComponent<TMP_Text>();
    }

    public void OnObj(string massage)
    {
        gameObject.SetActive(true);
        eventText.text = massage;
        CancelInvoke("OffObj");
        Invoke("OffObj", 1);
    }

    void OffObj()
    {
        gameObject.SetActive(false);
    }
}
