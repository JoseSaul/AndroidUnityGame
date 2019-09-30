using UnityEngine;

namespace Main.PlayerCharacter
{
    public class Animations : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private GameObject[] fbx;

        public void Died()
        {
            Debug.Log("Muerto");
        }
    
        public void EndAttack()
        {
            player.RestartMove();
        }

        public void ResultAttack()
        {
            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out var result, 1.5f, layerMask))
            {
                if (result.collider.gameObject.CompareTag("Enemy"))
                {
                    GameObject enemy = result.collider.gameObject;
                    GameObject fbxResult = fbx[0];
                    Instantiate(fbxResult, enemy.transform.position, Quaternion.identity);
                    if (enemy.GetComponentInParent<Enemy>())
                    {
                        enemy.GetComponentInParent<Enemy>().ReceiveDamage();
                    }
                }
            }
        }


        public void ResultLacer()
        {
            GameObject fbxResult = fbx[1];
            Instantiate(fbxResult, player.GetWeapon(1).transform.position, player.transform.rotation);
        }
    
    
    }
}



