using UnityEngine;

namespace Obstacles.PlatformRotator
{
    public class Rotate : MonoBehaviour
    {

        [SerializeField] private GameObject platform;
        [SerializeField] private bool right;
        [SerializeField] private int speed;
        
        void Update()
        {
            if (right)
            {
                platform.transform.Rotate(new Vector3(0,0,Time.deltaTime*speed));
            }
            else
            {
                platform.transform.Rotate(new Vector3(0,0,Time.deltaTime*-speed));
            }
            
        }
        
    
    }
}
