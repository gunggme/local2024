using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObj : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.Goal(GoalType.Player);
        }
        else if (other.CompareTag("AI"))
        {
            gameManager.Goal(GoalType.AI);
        }
    }
}
