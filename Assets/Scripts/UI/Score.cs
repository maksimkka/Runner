using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text[] scoreText;
    private int countScore;

    private void Awake()
    {
        TextOutput(0);
    }

    public void IncreaseScore(int score)
    {
        countScore += score;
        TextOutput(countScore);
    }

    private void TextOutput(int score)
    {
        for (int i = 0; i < scoreText.Length; i++)
        {
            scoreText[i].text = $"SCORE: {score}";
        }
    }
}