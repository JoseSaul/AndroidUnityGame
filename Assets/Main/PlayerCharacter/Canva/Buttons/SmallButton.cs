using System.Collections;
using System.Collections.Generic;
using Main.PlayerCharacter;
using UnityEngine;
using UnityEngine.EventSystems;

public class SmallButton : MonoBehaviour,IPointerDownHandler
{
    public PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.Shrink();
    }
    
}
