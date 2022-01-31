using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int currentLevel;
    private int maxLevel;

    private void Awake()
    {
        maxLevel = SceneManager.sceneCountInBuildSettings;
    }

    public void NextLevel()
    {
        if (currentLevel < maxLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        if (currentLevel == maxLevel)
        {
            currentLevel = 1;
            SceneManager.LoadScene(0);
        }
    }
}
