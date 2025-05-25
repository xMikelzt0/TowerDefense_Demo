using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;


    void Start()
    {
        gameOver = false;
        gameOverUI.SetActive(false);
    }
    void Update()
    {
        if (gameOver)
            return;

        //if(Input.GetKeyDown("e"))
        //{
        //    gameOver = true;
        //    gameOverUI.SetActive(true);
        //}

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        //Debug.Log("Game Over");
        
    }
    public void WinLevel()
    {
        gameOver = true;
        completeLevelUI.SetActive(true);
    }
}
