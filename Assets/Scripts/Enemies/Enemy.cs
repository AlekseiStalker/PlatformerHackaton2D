using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject lootAfterDeathPrefab;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform point_A, point_B;


    private BoxCollider2D boxCollider;

    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer sprite;

    private float _timeWaitToMove = 1.3f;
     
    protected PlayerController player;
    private WaitForSeconds _waitToContinueMoveTime;

    public float timeToKill;
    public float offsetY;

    private int _animIdAndHash_Dead = Animator.StringToHash("Dead");

    private bool isDead;

    public void Start()
    {
        Init();

        currentTarget = point_A.position;
    }

    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        _waitToContinueMoveTime = new WaitForSeconds(_timeWaitToMove);
    }

    public virtual void Update()
    {
        if (!isDead)
        { 
            Movement();
        } 
    }

    protected virtual void Movement()
    {
        SetDirection();

        MoveToTarget(); 
    }

    private void SetDirection()
    {
        if (transform.position == point_A.position)
        {
            currentTarget = point_B.position;
            sprite.flipX = true;
        }
        else if (transform.position == point_B.position)
        {
            currentTarget = point_A.position;
            sprite.flipX = false;
        }
    }


    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.smoothDeltaTime);

        Debug.Log(currentTarget + "current");
    }


    public void KillEnemy()
    {
        isDead = true;

        boxCollider.isTrigger = true;
        animator.SetTrigger(_animIdAndHash_Dead);

        Destroy(this.gameObject, timeToKill);
    }
}
