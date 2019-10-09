using System;
using System.Collections;
using System.Collections.Generic;
using Main.GameManager;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().AddLife();
            Destroy(gameObject);
        }
    }
}
