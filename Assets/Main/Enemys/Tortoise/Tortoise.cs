using UnityEngine;

namespace Main.Enemys.Tortoise
{
    public class Tortoise : Enemy
    {
        [SerializeField]
        private Animator anim;
        [SerializeField]
        private GameObject tortoiseBody;

        private float speed = 1;
        private int steps = 400, paralized;
        private bool attacking;

        private static readonly int AAttack = Animator.StringToHash("Attacking");
        
        private void Start()
        {
            life = 1;
            inmune = true;
        }

        private void Update()
        {
            Move();
        }

        public GameObject GetTortoise()
        {
            return body;
        }

        public bool GetAttacking()
        {
            return attacking;
        }

        public override void Attack()
        {
            attacking = true;
            speed = 8;
            anim.SetBool(AAttack,true);
            tortoiseBody.SetActive(false);
        }

        public override void LeftAttack()
        {
            attacking = false;
            speed = 1;
            anim.SetBool(AAttack,false);
            tortoiseBody.SetActive(true);
        }

        private void Move()
        {
            if (paralized <= 0)
            {
                body.transform.Translate(speed * Time.deltaTime * new Vector3(1,0,0));
                if (speed.Equals(1))
                {
                    steps--; 
                }
                else
                {
                    steps -= 8;
                }
            
                if (steps <= 0)
                {
                    LeftAttack();
                    body.transform.Rotate(new Vector3(0,180,0));
                    steps = 400;
                }
            }
            else
            {
                paralized--;
                if (paralized <= 0)
                {
                    ExitParalized();
                }
            }
            
        }

        public void SetParalized()
        {
            paralized = 200;
            tortoiseBody.SetActive(false);
            inmune = false;
        }

        private void ExitParalized()
        {
            tortoiseBody.SetActive(true);
            inmune = true;
        }

    }
}
