using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public PlayerController PlayerController;

    public GameObject enemy;

    public int countGemsToWin = 5;
    private int _curgemsCount = 0; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    } 
     
    public void AddGems()
    {
        _curgemsCount++;

        CheckOnWin(); 
    }
     

    private void CheckOnWin()
    {
        if (_curgemsCount == countGemsToWin)
        {
            //Create UI "Go to the dor"
            Debug.Log("Win!");
        }
    }
}
