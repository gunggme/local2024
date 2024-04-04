using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
    public Rigidbody carColl;

    public float MoveSpeed;

    private void Start()
    {
        carColl.transform.SetParent(transform.parent);
        carColl.GetComponent<NPCColl>().parent = transform;
        Invoke("OnDestroyObj", 5f);
    }

    private void Update()
    {
        transform.position = carColl.transform.position;
        carColl.transform.rotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        carColl.AddForce(transform.forward * MoveSpeed, ForceMode.Acceleration);
    }

    void OnDestroyObj()
    {
        Destroy(carColl.gameObject);
        Destroy(gameObject);
    }
}
