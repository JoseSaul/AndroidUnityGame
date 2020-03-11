using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private Canvas pauseCanvas = new Canvas();
    
    public void OnPointerDown(PointerEventData eventData)
    {
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    
}
