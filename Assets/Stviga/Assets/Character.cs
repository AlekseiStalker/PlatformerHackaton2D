using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField]
    private int lives = 5;

   

    [SerializeField]
    private float speed = 4.0F;
    [SerializeField]
    public float jumppower = 12F;

    private bool isGrounded = false;


    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    // Update is called once per frame
    void Update()
    {
        State = CharState.Idle;
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetButtonDown("Jump")) Jump();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position+direction, speed*Time.deltaTime);
        sprite.flipX = direction.x < 0.0f;
        State = CharState.Run;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumppower,ForceMode2D.Impulse);
        State = CharState.Jump;

    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.5F);
        isGrounded = colliders.Length > 2; 
    }



}

public enum CharState
{
    Idle,
    Run,
    Jump
}