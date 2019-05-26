using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animator : MonoBehaviour
{
    SpriteRenderer sp;
    public bool _anim;
    public GameObject Player_;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            sp.flipX = true;
            Player_.GetComponent<Animator>().SetBool("anim_", true);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            sp.flipX = false;
            Player_.GetComponent<Animator>().SetBool("anim_", true);

        }
        else
        {
            Player_.GetComponent<Animator>().SetBool("anim_", false);
        }

    }

}
