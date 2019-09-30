using System.Collections;
using System.Collections.Generic;
using Main.PlayerCharacter;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButton : MonoBehaviour,IPointerDownHandler
{
    public PlayerController player;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.Attack();
    }
}
