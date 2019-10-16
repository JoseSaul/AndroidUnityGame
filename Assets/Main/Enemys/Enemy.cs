using UnityEngine;

namespace Main.Enemys
{
    public class Enemy : MonoBehaviour
    {

        [SerializeField] private GameObject fbx;
        [SerializeField] protected GameObject body;
        protected int life;
        protected bool inmune = false;


        public void ReceiveDamage(bool isLacer)
        {
            if (!inmune || isLacer)
            {
                life--;
                if (life == 0)
                {
                    Instantiate(fbx, body.transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }  
            }
        }

        public virtual void Attack()
        {
        
        }

        public virtual void LeftAttack()
        {
        
        }

    }
}
