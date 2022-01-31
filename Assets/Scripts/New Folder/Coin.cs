using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICoin
{
    [SerializeField] private int coinCount;

    public int CoinCount => coinCount;
}
