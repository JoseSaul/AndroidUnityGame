using Main.PlayerCharacter;
using Main.PlayerCharacter.Canva;
using UnityEngine;

namespace Main.GameManager
{
    public class GameManager : MonoBehaviour
    {
        private int life = 3,gold, arrows = 5;
        public canvas canvas;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        

        public void AddLife()
        {
            if (life < 3)
            {
                life++;
                canvas.GetHeart(life);
            }
            
        }

        public void LoseLife()
        {
            if (life==1)
            {
                life--;
                canvas.QuitHeart(life);
                FindObjectOfType<PlayerController>().Die();
            }
            else
            {
                life--;
                canvas.QuitHeart(life);
            }
        }
        
        public int GetLife()
        {
            return life;
        }
    
        public void AddGold()
        {
            gold++;
            canvas.TextGold(gold);
            
        }

        public int GetGold()
        {
            return gold;
        }
        
        public int GetBullets()
        {
            return arrows;
        }

        public void UseBullet()
        {
            arrows--;
            canvas.TextBullets(arrows);
        }


    }
}
