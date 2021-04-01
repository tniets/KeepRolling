using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coins;

    public event Action<int> CoinCollected;

    public void AddCoin()
    {
        _coins++;
        CoinCollected?.Invoke(_coins);
    }
}
