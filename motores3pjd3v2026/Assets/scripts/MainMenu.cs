using UnityEngine;

public class MainMenu : MonoBehaviour
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