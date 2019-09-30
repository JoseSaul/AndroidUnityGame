using System;
using Main.PlayerCharacter;
using Main.PlayerCharacter.Canva;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        private int life = 3,gold = 0, arrows = 5;
        public canvas canvas;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }


        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void addLife()
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
        
        public int getLife()
        {
            return life;
        }
    
        public void addGold()
        {
            gold++;
            canvas.TextGold(gold);
            
        }

        public int getGold()
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
