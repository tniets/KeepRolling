using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coinCount;

    public event Action<int> CoinCollected = delegate { };

    public void AddCoin()
    {
        _coinCount++;
        CoinCollected(_coinCount);
    }
}
