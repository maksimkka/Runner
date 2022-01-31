using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private IGameOver gameOver;
    private IFinish finish;
    private Score score;

    private void Awake()
    {
        GetObjects();
    }

    private void GetObjects()
    {
        gameOver = FindObjectOfType<GameState>();
        finish = FindObjectOfType<GameState>();
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver.GameOver();
        }

        if(other.gameObject.TryGetComponent(out ICoin coin))
        {
            score.IncreaseScore(coin.CoinCount);
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Finish"))
        {
            finish.Finished();
        }
    }
}
