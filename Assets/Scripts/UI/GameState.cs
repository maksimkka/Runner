using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour, IGameOver
{
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject winGameCanvas;

    private bool isFinished;

    private void Awake()
    {
        Launch();
    }

    public void GameOver()
    {
        ShowScreen(gameOverCanvas);
        HideScreen(gameCanvas);
        HideScreen(winGameCanvas);
        isFinished = false;
        Time.timeScale = 0;
    }

    public void Launch()
    {
        ShowScreen(gameCanvas);
        HideScreen(gameOverCanvas);
        HideScreen(winGameCanvas);
        isFinished = false;
        Time.timeScale = 1;
    }

    public bool ChechingFinish()
    {
        return isFinished;
    }

    public void Finished()
    {
        ShowScreen(winGameCanvas);
        HideScreen(gameOverCanvas);
        HideScreen(gameCanvas);
        isFinished = true;
        Time.timeScale = 0;
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
