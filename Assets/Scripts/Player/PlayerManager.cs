using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    private IGameOver gameOver;

    //private ChechingPosition chechingPosition;

    private Score score;
    //private Finish finish;

    private void Awake()
    {
        GetObjects();
    }

    private void GetObjects()
    {
        gameOver = gameState.GetComponent<IGameOver>();

        score = FindObjectOfType<Score>();
        //finish = FindObjectOfType<Finish>();

        //chechingPosition = new ChechingPosition();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver.GameOver();
        }

        if(other.gameObject.TryGetComponent(out Coin coin))
        {
            score.IncreaseScore(coin.CoinCount());
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Finish"))
        {
            //finish.StopPlayer(playerRb);
            gameState.Finished();
        }
    }
}
