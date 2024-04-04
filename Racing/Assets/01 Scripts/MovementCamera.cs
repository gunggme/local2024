using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{
    public Transform Target;

    public float Distance;
    public float Height;
    public float Damping;

    Camera m_Camera;

    private void Awake()
    {
        m_Camera = Camera.main;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 wantVec = Target.position - Target.forward * Distance + Vector3.up * Height;
        transform.position = Vector3.Lerp(transform.position, wantVec, Damping * Time.deltaTime);
        transform.LookAt(Target.position);
    }

    public void SetDisntance(float velocity)
    {
        m_Camera.fieldOfView = 60 + Mathf.Clamp(velocity * 1.5f, 0f, 100f);
    }
}
