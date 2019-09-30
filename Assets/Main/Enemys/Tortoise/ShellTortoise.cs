using Main.PlayerCharacter;
using UnityEngine;

namespace Main.Enemys.Tortoise
{
    public class ShellTortoise : MonoBehaviour
    {
        [SerializeField] 
        private Tortoise tortoise;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (tortoise.GetAttacking())
                {
                    other.GetComponent<PlayerController>().ReceiveDamage(tortoise.GetTortoise().transform);
                    tortoise.LeftAttack();
                }
                else
                {
                    if (!other.GetComponent<PlayerController>().GetLittle())
                    {
                        other.GetComponent<PlayerController>().Impulse(15);
                        tortoise.SetParalized();
                    }
                    else
                    {
                        other.GetComponent<PlayerController>().Impulse(15);
                    }
                }
            }
        }
        
        
    }
}
