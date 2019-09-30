using System.Collections;
using System.Collections.Generic;
using Main.PlayerCharacter;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeButton : MonoBehaviour,IPointerDownHandler
{
    public PlayerController player;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.ChangeWeapon();
    }
    
}
