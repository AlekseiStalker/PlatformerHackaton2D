using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public PlayerController PlayerController;

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.Jump();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       //PlayerController.MoveLeft = false;
    }
}
