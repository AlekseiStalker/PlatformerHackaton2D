using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyCustom : MonoBehaviour
{
    public float timeToDestroy;

    private void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
}
