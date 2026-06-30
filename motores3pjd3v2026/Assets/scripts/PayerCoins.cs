using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public int coins = 0;

    public void AddCoin()
    {
        coins++;

        PlayerObserverManager.NotifyCoinsChanged(coins);
    }
}