using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    public float SpawnTime;
    public float MaxSpawnTime;

    public GameObject NPCObj;

    public BoxCollider boxColl;

    private void Update()
    {
        if(SpawnTime > 0)
        {
            SpawnTime -= Time.deltaTime;
        }
        else
        {
            Spawn();
            SpawnTime = MaxSpawnTime;
        }
    }

    void Spawn()
    {
        float sizeX = boxColl.size.x;
        float sizeZ = boxColl.size.z;

        // ½ºÆù
        Vector3 spawnVec = transform.position + new Vector3(Random.Range(-sizeX, sizeX), 0.9f, Random.Range(-sizeZ, sizeZ));

        Instantiate(NPCObj, spawnVec, boxColl.transform.rotation, transform);
    }
}
