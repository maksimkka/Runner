using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour, IGameOver
{
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject winGameCanvas;
    public static bool isStarted;

    private void Awake()
    {
        Launch();
        //isStarted = false;
        //ShowScreen(winGameCanvas);
        //HideScreen(gameCanvas);
        //HideScreen(gameOverCanvas);
        //Time.timeScale = 0;
        //gameOverCanvas.SetActive(false);
    }

    public void GameOver()
    {
        isStarted = false;
        ShowScreen(gameOverCanvas);
        HideScreen(gameCanvas);
        HideScreen(winGameCanvas);
        //gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        isStarted = true;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Launch()
    {
        isStarted = true;
        ShowScreen(gameCanvas);
        HideScreen(gameOverCanvas);
        HideScreen(winGameCanvas);
        //startCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowScreen(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void HideScreen(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }


}
