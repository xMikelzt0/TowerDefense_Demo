using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;

    void Update()
    {
        if (gameOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameOver = true;
        Debug.Log("Game Over");
        // Add any additional game over logic here, such as showing a game over screen or restarting the game.
    }
}
