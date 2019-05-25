using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private int _health;

    public Slider slider;


    public float pushForseUp;
    public float PushHurtForce;


    Rigidbody2D _rb2D;
    PlayerAnimation _playerAnimation; 
    SpriteRenderer _playerSprite;

    float _distanceToGroundForIdle = 1.4f;
    WaitForSeconds _waitJumpDoing;

    private bool _isPushingHurt;

    private bool _isJump;

    private bool _isDead;
     
    void Start () {
        _rb2D = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();

        _playerSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();

        _waitJumpDoing = new WaitForSeconds(0.2f);  
    }

    private void FixedUpdate()
    {
        if (!_isPushingHurt)
        {
            if (MoveLeft)
            {
                PlayerMoveLeft();

                if (!_isJump)
                {
                    _playerAnimation.Move(true);
                }
            }
            else if (MoveRight)
            {
                PlayerMoveRight();

                if (!_isJump)
                {
                    _playerAnimation.Move(true);
                }
            }
        }
    }

    public void PlayerMoveLeft()
    {
        _playerSprite.flipX = true;
        _rb2D.velocity = new Vector2(-1 * _moveSpeed, _rb2D.velocity.y); 
    }

    public void PlayerMoveRight()
    {
        _playerSprite.flipX = false;
        _rb2D.velocity = new Vector2(1 * _moveSpeed, _rb2D.velocity.y); 
    }

    public void MoveStop()
    {
        _rb2D.velocity = new Vector2(0, _rb2D.velocity.y);

        _playerAnimation.Move(false); 
    }


    public bool MoveLeft { get; set; }
    public bool MoveRight { get; set; }


    public void Jump()
    { 
        if (!_isJump)
        {
            _isJump = true;

            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce);

            _playerAnimation.Move(false);
            _playerAnimation.Jump(true);

            StartCoroutine(DeactivateJump());
        } 
       
    }

    IEnumerator DeactivateJump()
    {
        yield return _waitJumpDoing;

        while (!IsGrounded())
        {
            yield return null; 
        }

        _isJump = false;
         
        _playerAnimation.Jump(false);
    }


    private bool IsGrounded()
    {
        Vector3 leftPos = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
        RaycastHit2D hitLeft = Physics2D.Raycast(leftPos, Vector2.down, _distanceToGroundForIdle, 1<<8);

        Vector3 rightPos = new Vector3(transform.position.x + 0.15f, transform.position.y, transform.position.z);
        RaycastHit2D hitRight = Physics2D.Raycast(rightPos, Vector2.down, _distanceToGroundForIdle, 1<<8);

        Debug.DrawRay(leftPos, Vector2.down * _distanceToGroundForIdle, Color.red);
        Debug.DrawRay(rightPos, Vector2.down * _distanceToGroundForIdle, Color.red);

        return hitLeft.collider != null || hitRight.collider != null;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        { 
            _health--;

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            slider.value = _health;

            if (IsPlayerHigherPos(collision.gameObject.transform.position.y, enemy.offsetY))
            { 
                PushPlayerUp();
                enemy.KillEnemy(); 
            }
            else
            {
                if (_health == 0)
                {
                    PlayerDead();
                }
                else
                {
                    StartCoroutine(PushHurt());
                    _playerAnimation.Hurt();
                }
            } 
        }
    }

    private void PlayerDead()
    {
        _playerAnimation.Dead();

        GameManager.Instance.Restart();
    }

    private bool IsPlayerHigherPos(float enemyY, float offset)
    {
        float posY = this.gameObject.transform.position.y;
         
        if (posY - enemyY >= offset)
        { 
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator PushHurt()
    {
        _isPushingHurt = true;
        MoveStop();


        if (!_playerSprite.flipX)
        { 
            _rb2D.AddForce(Vector2.left * PushHurtForce, ForceMode2D.Impulse);
        }
        else
        { 
            _rb2D.AddForce(Vector2.right * PushHurtForce, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(0.5f);

        _isPushingHurt = false;
    }

    private void PushPlayerUp()
    {
        _rb2D.AddForce(Vector2.up * pushForseUp, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        { 
            GameManager.Instance.AddGems();

            Destroy(collision.gameObject, 0.1f);
        }
        else if (collision.CompareTag("Cherry"))
        {
            if (_health < 3)
            { 
                _health++;
                slider.value = _health;
            }

            Destroy(collision.gameObject, 0.2f);

        }
    }
}
