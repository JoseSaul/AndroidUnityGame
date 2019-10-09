using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.Menu
{
    public class Menu : MonoBehaviour
    {

        public void NewGame()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void Continue()
        {
            Debug.Log("Continuar");
        }

        public void ExitGame()
        {
            Debug.Log("Salir");
            Application.Quit();
        }
    
    }
}
