using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;

   
    public enum GameState
    {
        Iniciando,
        Menu_principal,
        Gameplay
    }

    
    public GameState currentState;

    
    public PlayerInput playerInput;

    private void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;

           
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        ChangeState(GameState.Iniciando);

       
        LoadScene("Splash");
    }

    
    public void ChangeState(GameState newState)
    {
        currentState = newState;

        Debug.Log("Estado atual: " + currentState);
    }

    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

      
        switch (sceneName)
        {
            case "Menu_principal":
                ChangeState(GameState.Menu_principal);
                break;

            case "GetStarted_Scene":
                ChangeState(GameState.Gameplay);
                break;
        }
    }

    
    public void AssignPlayerInput(PlayerInput input)
    {
        playerInput = input;

        Debug.Log("Input conectado!");
    }

   
    public void QuitGame()
    {
        Debug.Log("Saindo do jogo");

        Application.Quit();
    }

    
    }