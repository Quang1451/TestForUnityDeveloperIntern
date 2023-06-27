using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Canvas gameOverCanvas;

    void Start()
    {
        gameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
    }


    public void HandleGameOver()
    {
        gameOverCanvas.enabled = (true);
        Time.timeScale = 0f;
    }
}
