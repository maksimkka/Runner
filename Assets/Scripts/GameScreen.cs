using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    //[SerializeField] private GameObject gameCanvas;
    //[SerializeField] private Text score;
    //private int scrore;

    public void CountScore(Text score, int count)
    {
        score.text += count;
    }
}
