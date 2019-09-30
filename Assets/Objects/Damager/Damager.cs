using System;
using System.Collections;
using System.Collections.Generic;
using Main.PlayerCharacter;
using UnityEngine;

public class Damager : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().ReceiveDamage(transform);
        }
    }
}
