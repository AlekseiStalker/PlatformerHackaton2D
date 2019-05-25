using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveRightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerController PlayerController;
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.MoveRight = true; 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.MoveRight = false;

        PlayerController.MoveStop();  
    }
}
