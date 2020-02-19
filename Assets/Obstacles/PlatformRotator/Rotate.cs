using System;
using Main.PlayerCharacter;
using UnityEngine;

namespace Obstacles.PlatformRotator
{
    public class Rotate : MonoBehaviour
    {

        [SerializeField] private GameObject platform;
        [SerializeField] private bool zEje;
        [SerializeField] private int speed;

        void Update()
        {
            if (zEje)
            {
                platform.transform.Rotate(new Vector3(0,0,Time.deltaTime*speed));
            }
            else
            {
                platform.transform.Rotate(new Vector3(Time.deltaTime*-speed,0,0));
            }
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().LateralImpulse(speed,zEje);
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().ExitLateralImpulse();
            }
        }
        
        
    }
}
