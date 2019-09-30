using UnityEngine;

namespace Main.PlayerCharacter.Weapons
{
    public class Projectil : MonoBehaviour
    {
        [SerializeField] private GameObject fbx;
        private float speed = 30;
        private int fireRate = 120;
    
        void Update()
        {
            Vector3 transition = new Vector3(transform.forward.x,0,transform.forward.z);
            if (speed != 0)
            {
                transform.position += transition * (speed * Time.deltaTime);
                fireRate--;
                if (fireRate <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.gameObject.CompareTag("Player") )
            {
                if (other.collider.gameObject.CompareTag("Enemy"))
                {
                    other.collider.gameObject.GetComponentInParent<Enemy>().ReceiveDamage();
                }
                Instantiate(fbx, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    
    
    
    
    }
}
