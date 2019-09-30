using System;
using System.Collections;
using System.Collections.Generic;
using Main.PlayerCharacter;
using UnityEngine;
using UnityEngine.Serialization;

public class DontChangeSize : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().SetCanChangeSize(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().SetCanChangeSize(true);
        }
    }
}
