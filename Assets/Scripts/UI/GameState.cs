using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour, IGameOver, IFinish
{
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject winGameCanvas;

    private void Awake()
    {
        Launch();
    }

    public void GameOver()
    {
        ShowScreen(gameOverCanvas);
        HideScreen(gameCanvas);
        HideScreen(winGameCanvas);
        Time.timeScale = 0;
    }

    public void Launch()
    {
        ShowScreen(gameCanvas);
        HideScreen(gameOverCanvas);
        HideScreen(winGameCanvas);
        Time.timeScale = 1;
    }

    public void Finished()
    {
        ShowScreen(winGameCanvas);
        HideScreen(gameOverCanvas);
        HideScreen(gameCanvas);
        Time.timeScale = 0;
    }

    private void ShowScreen(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void HideScreen(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}