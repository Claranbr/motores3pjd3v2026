using UnityEngine;

public class Menu_principal : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.LoadScene("GetStarted_Scene");
    }

    public void QuitGame()
    {
        Debug.Log("Saiu do jogo");

        Application.Quit();
    }
}