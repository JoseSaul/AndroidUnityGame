﻿using Main.GameManager;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           FindObjectOfType<GameManager>().AddGold();
           Destroy(gameObject);
        }
    }
}
