using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Estado Atual")]
    public GameState CurrentState;

    [Header("Player Input")]
    [SerializeField] private PlayerInput playerInput;

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("GameManager iniciado");
    }

    private void Start()
    {
        ChangeState(GameState.Iniciando);

        // Vai para Splash automaticamente
        LoadScene("Splash");
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;

        Debug.Log("Estado Atual: " + CurrentState);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);

        // Atualiza estado conforme cena
        switch (sceneName)
        {
            case "Splash":
                ChangeState(GameState.Iniciando);
                break;

            case "MenuPrincipal":
                ChangeState(GameState.MenuPrincipal);
                break;

            case "GetStarted_Scene":
                ChangeState(GameState.Gameplay);
                AssignPlayerInput();
                break;
        }
    }

    private void AssignPlayerInput()
    {
        if (playerInput != null)
        {
            playerInput.ActivateInput();
            Debug.Log("Input alocado ao jogador");
        }
        else
        {
            Debug.LogWarning("PlayerInput não configurado no GameManager");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo");
        Application.Quit();
    }
}