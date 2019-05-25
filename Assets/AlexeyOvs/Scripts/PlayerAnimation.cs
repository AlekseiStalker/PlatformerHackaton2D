using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {


    Animator _animPlayer;

    int _moveId = Animator.StringToHash("Move");
    int _jumpId = Animator.StringToHash("Jumping");  
    int _deadId = Animator.StringToHash("Dead");
    int _hurtId = Animator.StringToHash("Hurt");


    public float TimeBeforeDestroy;

    private void Start()
    {
        InitComponent();
    }

    private void InitComponent()
    {
        _animPlayer = transform.GetChild(0).GetComponentInChildren<Animator>(); 
         
    }
     

    public void Move(bool value)
    {
        _animPlayer.SetBool(_moveId, value);
    }

    public void Jump(bool isJumping)
    {
        _animPlayer.SetBool(_jumpId, isJumping);
    }

    public void Dead()
    { 
        _animPlayer.SetTrigger(_deadId);

        Destroy(this.gameObject, TimeBeforeDestroy);
    }

    public void Hurt()
    {
        _animPlayer.SetTrigger(_hurtId);
    }
}
