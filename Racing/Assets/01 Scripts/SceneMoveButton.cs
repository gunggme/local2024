using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveButton : MonoBehaviour
{
    public bool IsLastStage;

    public void Btn_MoveScene(int num)
    {
        if (IsLastStage)
        {
            SaveManager.Instance.SaveRank();
        }
        SaveManager.Instance.SaveData();
        SceneManager.LoadScene(num);
    }
}
