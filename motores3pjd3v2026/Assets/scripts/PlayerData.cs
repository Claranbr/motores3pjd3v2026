using UnityEngine;
using System;

public class PlayerData : MonoBehaviour
{
    public int coins = 0;
    public float speed = 5f;

    public event Action<int> OnCoinsChanged;

    public void AddCoin()
    {
        coins++;
        speed += 0.5f;

        OnCoinsChanged?.Invoke(coins);
    }
}