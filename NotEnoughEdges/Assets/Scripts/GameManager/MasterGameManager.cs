using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameManager : MonoBehaviour {
    public static MasterGameManager instance;

    public AudioManager audioManager;
    public SceneManagerWrapper sceneManager;
    public PauseManager pauseManager;
    public UIManager uiManager;

    public bool isGameOver { get; private set; }

    PlayerHealth playerHealth;
    GameOverMenu gameOverMenu;
    WinMenu winMenu;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        sceneManager.onSceneLoaded += Initialize;
    }

    void Initialize()
    {
        isGameOver = false;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        gameOverMenu = GameObject.Find("Game Over Menu").GetComponent<GameOverMenu>();
        winMenu = GameObject.Find("Win Menu").GetComponent<WinMenu>();
        playerHealth.onDeath += GameOver;
        playerHealth.onWin += MaxEdge;
    }

    void GameOver()
    {
        _EndGame();
        gameOverMenu.EnableGameOverPanel(true);
    }

    void MaxEdge() //AKA win
    {
        _EndGame();
        winMenu.EnableWinPanel(true);
    }

    void _EndGame()
    {
        Time.timeScale = 0;
        isGameOver = true;
    }
}
