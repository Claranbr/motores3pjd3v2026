using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance;

    // Estados do jogo
    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    // Estado atual
    public GameState currentState;

    // Input do jogador
    public PlayerInput playerInput;

    private void Awake()
    {
        // Faz existir apenas 1 GameManager
        if (Instance == null)
        {
            Instance = this;

            // Não destrói ao trocar de cena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Estado inicial
        ChangeState(GameState.Iniciando);

        // Carrega Splash
        LoadScene("Splash");
    }

    // Troca estado
    public void ChangeState(GameState newState)
    {
        currentState = newState;

        Debug.Log("Estado atual: " + currentState);
    }

    // Carregar cenas
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        // Define estado baseado na cena
        switch (sceneName)
        {
            case "MenuPrincipal":
                ChangeState(GameState.MenuPrincipal);
                break;

            case "GetStarted_Scene":
                ChangeState(GameState.Gameplay);
                break;
        }
    }

    // Conectar input do jogador
    public void AssignPlayerInput(PlayerInput input)
    {
        playerInput = input;

        Debug.Log("Input conectado!");
    }

    // Sair do jogo
    public void QuitGame()
    {
        Debug.Log("Saindo do jogo");

        Application.Quit();
    }

    
    }