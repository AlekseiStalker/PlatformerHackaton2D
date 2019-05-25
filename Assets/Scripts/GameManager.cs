using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public PlayerController PlayerController;

    public GameObject enemy;

    private void Awake()
    {
        if (Instance)
        {
            Instance = this;
        }
    } 
}
