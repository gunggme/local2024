using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int curTime;
    void Update()
    {
        Time.timeScale = curTime;
    }
}
