using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColl : MonoBehaviour
{
    public float Limit;

    public GameObject CollEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("AI") || collision.transform.CompareTag("NPC")) 
        {
            SoundManager.Instance.SoundPlay(8, AudioType.FBX, 5);
            Instantiate(CollEffect, (transform.position + ((collision.transform.position - transform.position) * Limit)), Quaternion.identity, transform);
        }
    }
}
