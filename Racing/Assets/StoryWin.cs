using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryWin : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.SoundPlay(3, AudioType.BGM);
    }
}
