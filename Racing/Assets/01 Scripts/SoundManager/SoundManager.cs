using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    BGM = 0,
    FBX = 1
}

public class SoundManager : Singletone<SoundManager>
{
    public List<AudioSource> audioSources;

    public AudioClip[] clips;

    protected override void Awake()
    {
        base.Awake();
        foreach(Transform t in transform)
        {
            if (t.TryGetComponent(out AudioSource audio))
            {
                audioSources.Add(audio);
                continue;
            }
            else
            {
                t.gameObject.AddComponent<AudioSource>();
                audioSources.Add(t.GetComponent<AudioSource>());
            }
        }

        audioSources[0].volume = PlayerPrefs.GetFloat("BGM");
        audioSources[1].volume = PlayerPrefs.GetFloat("FBX");
    }

    public void SoundPlay(int num, AudioType type, int sycle = 1)
    {
        switch ((int)type)
        {
            case 0:
                if (audioSources[0].clip == clips[num]) return;
                audioSources[0].Stop();
                audioSources[0].clip = clips[num];
                audioSources[0].Play();
                audioSources[0].loop = true;
                break;
            case 1:
                for(int i = 0; i < sycle; i++)
                {
                    audioSources[1].PlayOneShot(clips[num]);
                }
                break;
        }
    }
}
