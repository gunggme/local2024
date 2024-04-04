using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectDataPAge : MonoBehaviour
{
    public TMP_InputField NameInputField;

    public void StartGame()
    {
        if(NameInputField.text.Length < 1)
        {
            return;
        }

        SaveManager.Instance.LoadData(NameInputField.text, () =>
        {
            SceneManager.LoadScene("Store");
        });
    }
}
