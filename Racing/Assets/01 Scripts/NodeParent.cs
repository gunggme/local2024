using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeParent : MonoBehaviour
{
    [SerializeField] int sphereSize;
    public List<Transform> Nodes;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Nodes = new List<Transform>();
        foreach(Transform t in transform)
        {
            Nodes.Add(t);
        }

        for(int i = 0; i < Nodes.Count; i++)
        {
            Vector3 curVec = Nodes[i].transform.position;
            Vector3 prevVec = Vector3.zero;

            if(i != 0)
            {
                prevVec = Nodes[i - 1].position;
                Gizmos.DrawLine(curVec, prevVec);
            }

            Gizmos.DrawWireSphere(curVec, sphereSize);
        }
    }
}
