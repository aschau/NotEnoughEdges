using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameManager : MonoBehaviour {
    public static MasterGameManager instance;

    public AudioManager audioManager;
    public SceneManagerWrapper sceneManager;
    public PauseManager pauseManager;

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

        sceneManager.onSceneLoaded += OnSceneLoaded;
    }

    void Start()
    {

    }

    void OnSceneLoaded()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerHealth.onDeath += GameOver;
        playerHealth.onWin += MaxEdge;
        gameOverMenu = GameObject.Find("Game Over Menu").GetComponent<GameOverMenu>();
        winMenu = GameObject.Find("Win Menu").GetComponent<WinMenu>();
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverMenu.EnableGameOverPanel(true);
    }

    void MaxEdge() //AKA win
    {
        Time.timeScale = 0;
        winMenu.EnableWinPanel(true);
    }
}
