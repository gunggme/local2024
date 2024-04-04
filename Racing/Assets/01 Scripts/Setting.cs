using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Slider BackgroundSound;
    public Slider FBXSound;

    public float BGMValue;
    public float FBXValue;

    private void Start()
    {
        BGMValue = PlayerPrefs.GetFloat("BGM");
        FBXValue = PlayerPrefs.GetFloat("FBX");

        BackgroundSound.value = BGMValue;
        FBXSound.value = FBXValue;
    }

    public void Update()
    {
        if(BackgroundSound.value != BGMValue)
        {
            PlayerPrefs.SetFloat("BGM", BackgroundSound.value);
            SoundManager.Instance.audioSources[0].volume = BackgroundSound.value;
        }
        if(FBXSound.value != FBXValue)
        {
            PlayerPrefs.SetFloat("FBX", FBXSound.value);
            SoundManager.Instance.audioSources[1].volume = FBXSound.value;
        }
    }

    public void MoveMain()
    {
        SceneManager.LoadScene("Main");
    }
}
