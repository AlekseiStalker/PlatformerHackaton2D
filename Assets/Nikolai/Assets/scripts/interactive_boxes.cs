using System.Collections.Generic;
using UnityEngine;

public class interactive_boxes : MonoBehaviour
{
    public bool isFox, isBox;

    //cache all colliders
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Box" && other.gameObject != this.gameObject)
        {
            isBox = true;
            print(isBox + "box");
        }
        else if (other.gameObject.tag == "Player")
        {
            isFox = true;
            print(isFox + "fox");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isFox = isBox = false;
    }

}
