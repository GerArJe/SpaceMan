using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;

    public static GameManager sharedInstance;

    PlayerController Controller;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    } 

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    private void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
            //TODO: colocar la lógica del menú
            MenuManager.sharedInstance.ShowMaiMenu();
        }
        else if (newGameState == GameState.inGame)
        {
            //TODO: hay que preparar la escena para jugar
            LevelManager.sharedInstance.RemoveAllLevelBlocks();
            LevelManager.sharedInstance.GenerateInitialBlocks();
            Controller.StartGame();
            MenuManager.sharedInstance.HideMainMenu();
        }
        else if (newGameState == GameState.gameOver)
        {
            //TODO: preparar el juego para el Game Over
            MenuManager.sharedInstance.ShowMaiMenu();
        }

        this.currentGameState = newGameState;
    }
}
