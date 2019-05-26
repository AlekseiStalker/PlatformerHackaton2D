using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crate_1 : MonoBehaviour
{
    public GameObject Cherry;
    public static int crates;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            crates++;

            if (crates == 4)
                Cherry.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
            crates--;
    }
}
