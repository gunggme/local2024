using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventObj : MonoBehaviour
{
    PlayerCar playerCar;
    Animator animator;

    public float MinDistance;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerCar = FindObjectOfType<PlayerCar>();
    }

    private void Update()
    {
        try
        {
            if (Vector3.Distance(transform.position, playerCar.transform.position) < MinDistance)
            {
                animator.SetTrigger("Event");
            }
        }
        catch(NullReferenceException e)
        {
            playerCar = FindObjectOfType<PlayerCar>();
        }
    }
}
