using Main.PlayerCharacter;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public PlayerController player;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.PressJump();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.PressJump();
    }
}
