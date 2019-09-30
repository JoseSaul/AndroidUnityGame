using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.GameManager manager = FindObjectOfType<GameManager.GameManager>();
            manager.LoseLife();
            manager.LoseLife();
            manager.LoseLife();
        }
    }
}
