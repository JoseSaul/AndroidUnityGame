using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }
    
}
