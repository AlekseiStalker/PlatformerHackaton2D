using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameObject goToDoorPanel;
    public GameObject InputControll;

    public Animator animDoor;

    public GameObject winPanel;

    //public PlayerController PlayerController;
    //public GameObject enemy;

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
            goToDoorPanel.SetActive(true);
            animDoor.SetTrigger("Door");
            Invoke("Deactive", 7);
        }
    }

    public void Deactive()
    {
        goToDoorPanel.SetActive(false); 
    }

    public void ActiveWinPanel()
    {
        InputControll.SetActive(false);
        Instantiate(winPanel);
    }

    public void Restart()
    {
        Application.LoadLevel(1);
    }
}
