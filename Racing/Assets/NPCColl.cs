using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCColl : MonoBehaviour
{
    public Transform parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeSpawn"))
        {
            Destroy(parent.gameObject);
            Destroy(gameObject);
        }
    }
}
