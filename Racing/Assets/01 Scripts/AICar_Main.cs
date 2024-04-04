using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar_Main : MonoBehaviour
{
    NodeParent nodeParent;

    public Rigidbody carRigid;
    public bool IsMove;

    [SerializeField] float moveSpeed;
    [SerializeField] float steerPower;
    [SerializeField] float minDistance;
    [SerializeField] int curIndex;

    private void Awake()
    {
        nodeParent = FindObjectOfType<NodeParent>();
    }


    private void Start()
    { 
        carRigid.transform.SetParent(null);
    }

    private void Update()
    {
        transform.position = carRigid.transform.position;
        carRigid.transform.rotation = transform.rotation;
        if (IsMove)
        {

            Steerring();
            FindNextNode();
        }
    }

    private void FixedUpdate()
    {
        if (IsMove)
        {
            Movement();
        }
    }

    void Movement()
    {
        int move = IsMove ? 1 : 0;
        carRigid.AddForce(transform.forward * move * moveSpeed, ForceMode.Acceleration);
    }

    void FindNextNode()
    {
        if (curIndex < nodeParent.Nodes.Count &&
            minDistance > Vector3.Distance(transform.position, nodeParent.Nodes[curIndex].position))
        {
            curIndex++;
            if (curIndex >= nodeParent.Nodes.Count)
            {
                curIndex = 0;
                return;
            }
        }
    }

    void Steerring()
    {
        if (curIndex >= nodeParent.Nodes.Count) return;
        Vector3 steer = nodeParent.Nodes[curIndex].position - transform.position;
        if (steer.magnitude < 0.1f)
        {
            return;
        }
        steer.y = 0;
        Quaternion steerAngle = Quaternion.LookRotation(steer);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, steerAngle, steerPower * Time.deltaTime);
    }
}
