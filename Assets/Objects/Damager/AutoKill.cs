using System.Collections;
using System.Collections.Generic;
using Main.GameManager;
using UnityEngine;

public class AutoKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager manager = FindObjectOfType<GameManager>();
            manager.LoseLife();
            manager.LoseLife();
            manager.LoseLife();
        }
    }
}
