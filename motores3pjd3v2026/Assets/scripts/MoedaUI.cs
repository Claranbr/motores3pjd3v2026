using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TMP_Text coinText;

    private void OnEnable()
    {
        Debug.Log("CoinUI habilitado");
        PlayerObserverManager.OnCoinsChanged += UpdateCoins;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinsChanged -= UpdateCoins;
    }

    private void UpdateCoins(int amount)
    {
        Debug.Log("Interface recebeu: " + amount);
        coinText.text = "Moedas: " + amount;
    }
}