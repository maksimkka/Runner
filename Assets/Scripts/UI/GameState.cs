using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour, IGameOver
{
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject winGameCanvas;

    public static bool isStarted;
    private int sceneIndex;
    private bool isFinished;

    private void Awake()
    {
        Launch();
    }

    public void GameOver()
    {
        //isStarted = false;
        isFinished = false;
        ShowScreen(gameOverCanvas);
        HideScreen(gameCanvas);
        HideScreen(winGameCanvas);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        isFinished = false;
        //isStarted = true;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Launch()
    {
        isFinished = false;
        //isStarted = true;
        ShowScreen(gameCanvas);
        HideScreen(gameOverCanvas);
        HideScreen(winGameCanvas);
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

    public void NextLevel()
    {
        sceneIndex++;
        Debug.Log("Next Level");
        SceneManager.LoadScene(sceneIndex);
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
