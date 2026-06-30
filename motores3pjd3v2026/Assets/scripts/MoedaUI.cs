using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TMP_Text coinText;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinsChanged += UpdateCoins;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinsChanged -= UpdateCoins;
    }

    private void UpdateCoins(int coins)
    {
        coinText.text = "Moedas: " + coins;
    }
}