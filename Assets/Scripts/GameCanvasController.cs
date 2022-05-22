using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanvasController : MonoBehaviour
{
    public static GameCanvasController instance;
    public GameObject gameOver;

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void Start()
    {
        instance = this;
    }

    public void EndGame() {
        gameOver.SetActive(true);
    }
}
