using UnityEngine;
using UnityEngine.UI;

namespace Main.PlayerCharacter.Canva
{
    public class canvas : MonoBehaviour
    {
        private int count = 0;
        private bool showing = true;
        public Text goldText,arrowText;
        public GameObject coinImage, bulletImage, life1, life2, life3;
        private int life, gold, bullets;

        // Start is called before the first frame update
        void Start()
        {
            GameManager.GameManager manager = FindObjectOfType<GameManager.GameManager>();
            life = manager.GetLife();
            gold = manager.GetGold();
            bullets = manager.GetBullets();
        }

        // Update is called once per frame
        void Update()
        {
            if (showing)
            {
                if (count <= 0)
                {
                    coinImage.SetActive(false);
                    bulletImage.SetActive(false);
                    goldText.text = "";
                    arrowText.text = "";
                    showing = false;
                }
                else
                {
                    count--;
                }
            }
        }

        private void ShowInfo()
        {
            coinImage.SetActive(true);
            bulletImage.SetActive(true);
            goldText.text = "" + gold;
            arrowText.text = "" + bullets;
            count = 150;
            showing = true;
        }
        

        internal void TextGold(int gold)
        {
            this.gold = gold;
            ShowInfo();
        }

        internal void TextBullets(int bullets)
        {
            this.bullets = bullets;
            ShowInfo();
        }

    
        internal void QuitHeart(int life)
        {
            if (life == 2)
            {
                life3.SetActive(false);
            }else if (life == 1)
            {
                life2.SetActive(false);
            }
            else
            {
                life1.SetActive(false);
            }
        }


        internal void GetHeart(int life)
        {
            if (life == 2)
            {
                life2.SetActive(true);
            }
            else
            {
                life3.SetActive(true);
            }
        }
    
    }
}
