using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinCount;

    public int CoinCount()
    {
        return coinCount;
    }
}
