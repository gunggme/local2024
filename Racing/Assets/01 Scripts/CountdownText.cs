using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum CountType
{
    Start,
    Retire
}

public class CountdownText : MonoBehaviour
{
    Animator animator;
    TMP_Text text;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        text = GetComponent<TMP_Text>();
    }


    private readonly WaitForSeconds wait1Sec = new(1);
    public IEnumerator Countdoawn_Croutine(float time, CountType countType = CountType.Start, Action callback = null)
    {
        gameObject.SetActive(true);
        text.text = time.ToString();
        animator.SetTrigger("Count");
        SoundManager.Instance.SoundPlay(2, AudioType.FBX);
        time--;
        yield return wait1Sec;
        while(time != 0)
        {
            text.text = time.ToString();
            time--;
            animator.SetTrigger("Count");
            SoundManager.Instance.SoundPlay(2, AudioType.FBX);
            yield return wait1Sec;
        }
        text.text = Enum.GetName(typeof(CountType), countType);
        SoundManager.Instance.SoundPlay(6, AudioType.FBX);
        callback?.Invoke();
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
