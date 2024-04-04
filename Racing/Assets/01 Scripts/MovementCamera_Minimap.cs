using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera_Minimap : MonoBehaviour
{
    public Transform Target;

    public Vector3 distance;

    private void FixedUpdate()
    {
        transform.position = Target.position + distance;
    }
}
