using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas = new Canvas();

    public void continu()
    {
        Time.timeScale = 1f; 
        pauseCanvas.gameObject.SetActive(false);
    }

    public void exitGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }
}

