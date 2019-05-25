using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class crate : MonoBehaviour
{
    public static int crates;
    public GameObject Cherry;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            crates++;

            if (crates == 3)
                Cherry.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
            crates--;
    }
}
