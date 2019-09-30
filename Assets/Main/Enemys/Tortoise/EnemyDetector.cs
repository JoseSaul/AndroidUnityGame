using UnityEngine;

namespace Main.Enemys.Tortoise
{
    public class EnemyDetector : MonoBehaviour
    {
        [SerializeField]
        private Enemy enemy;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                enemy.Attack();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                enemy.LeftAttack();
            }
        }
    }
}
