using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public List<string> texts;

    public bool IsDone;
    public int textNum;

    public Text textUI;

    private void Start()
    {
        SoundManager.Instance.SoundPlay(3, AudioType.BGM);
        textNum = 0;
        StartCoroutine(NextText(textNum));
    }

    private void Update()
    {
        if(textNum >= texts.Count && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsDone)
        {
            try
            {
                textNum++;
                if (textNum >= texts.Count)
                {
                    SceneManager.LoadScene(1);
                }
                StartCoroutine(NextText(textNum));

            }
            catch(ArgumentOutOfRangeException e)
            {
                SceneManager.LoadScene(1);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !IsDone)
        {
            textUI.text = texts[textNum];
        }
    }

    IEnumerator NextText(int num)
    {
        textUI.text = string.Empty;
        int txtNum = 0;
        IsDone = false;
        SoundManager.Instance.SoundPlay(4, AudioType.FBX);
        while(textUI.text != texts[num])
        {
            textUI.text += texts[num][txtNum];
            txtNum++;
            yield return new WaitForSeconds(0.1f);
        }
        IsDone = true;
    }
}
