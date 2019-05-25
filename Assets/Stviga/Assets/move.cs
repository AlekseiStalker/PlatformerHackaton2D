using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public float speedmove; //speed
    public float jumppower; //jumppower

    private Vector3 movevector; //
    private float gravity = 20f;

    private CharacterController ch_controller;
    private Animator ch_animator;

    // Use this for initialization
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        GamingGravity();
    }

    private void CharacterMove()
    {
        movevector = Vector2.zero;
        movevector.x = Input.GetAxis("Horizontal") * speedmove;
        movevector.z = Input.GetAxis("Vertical") * speedmove;

        if (movevector.x != 0 || movevector.z != 0) ch_animator.SetBool("player-idle-1", true);
        else ch_animator.SetBool("player-idle-1", false);

      

        movevector.y = gravity;
        ch_controller.Move(movevector * Time.deltaTime);

    }
    private void GamingGravity()
    {
        if (!ch_controller.isGrounded) gravity -= 20f * Time.deltaTime;
        else gravity = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded) gravity = jumppower;
    }
}

