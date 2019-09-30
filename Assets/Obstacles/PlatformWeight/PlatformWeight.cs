using System;
using System.Collections;
using System.Collections.Generic;
using Main.PlayerCharacter;
using UnityEngine;

public class PlatformWeight : MonoBehaviour
{
    public GameObject platform;
    public float force;
    private bool _up = true, _trigger;
    private PlayerController player;
    
    
    private void Update()
    {
        if (_trigger)
        {
            if (!player.GetLittle() && _up && player.IsGrounded())
            {
                platform.transform.localPosition = new Vector3(0,-1,0);
                _up = false;
            }else if (player.GetLittle() && !_up)
            {
                player.Impulse(force);
                platform.transform.localPosition = new Vector3(0,0,0);
                _up = true;
            }
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            _trigger = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            platform.transform.localPosition = new Vector3(0,0,0);
            player = null;
            _trigger = false;
            _up = true;
        }
    }
}
