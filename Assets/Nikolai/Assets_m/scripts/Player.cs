using UnityEngine;

public class Player : MonoBehaviour
{
    private bool IsGrounded;
    
    public float MovementSmoothing = .05f;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    
    private Vector3 Velocity = Vector3.zero;
    private bool FacingRight = true;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        bool isJump = Input.GetKeyDown(KeyCode.Space);

        Move(new Vector2(xAxis, yAxis));
        

    }

    public void Move(Vector2 move)
    {
        Vector3 targetVelocity = new Vector2(move.x * 10f, move.y * 10f);
        Rigidbody2D.velocity = Vector3.SmoothDamp(Rigidbody2D.velocity, targetVelocity, ref Velocity, MovementSmoothing);
        
        //if (move > 0 && !FacingRight)
        //{
          //  Flip();
        //}
        //else if (move < 0 && FacingRight)
        ///{
            ///Flip();
       // }
    }
    
    private void Flip()
    {
        FacingRight = !FacingRight;
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}