using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveLeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    PlayerController PlayerController;

    private void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerController.MoveLeft = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.MoveLeft = false;

        PlayerController.MoveStop();
    }
}
