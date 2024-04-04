using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj2D : MonoBehaviour
{
    Camera m_Camera;

    private void Awake()
    {
        m_Camera = Camera.main;
    }

    private void Update()
    {
        Vector3 lookVec = m_Camera.transform.position;
        lookVec.y = transform.position.y;
        transform.LookAt(lookVec);
    }
}
