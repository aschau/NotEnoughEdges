using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameManager : MonoBehaviour {
    public static MasterGameManager instance;

    public AudioManager audioManager;
    public SceneManagerWrapper sceneManager;
    public PauseManager pauseManager;
    public UIManager uiManager;
    public SaveManager saveManager;

    public bool isGameOver { get; private set; }
    public float currentTime { get; private set; }
    public int maxEdges { get; private set; }

    PlayerHealth playerHealth;
    ShapeManager shapeManager;
    GameOverMenu gameOverMenu;
    //WinMenu winMenu;

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

    void Initialize(string sceneName)
    {
        isGameOver = false;
        
        if (sceneName != "Main Menu")
        {
            GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
            playerHealth = playerGO.GetComponent<PlayerHealth>();
            shapeManager = playerGO.GetComponent<ShapeManager>();
            shapeManager.onEdgeChange += UpdateMaxEdges;
            playerHealth.onDeath += GameOver;
            playerHealth.onWin += MaxEdge;
            gameOverMenu = GameObject.Find("Game Over Menu").GetComponent<GameOverMenu>();
            currentTime = 0f;
            maxEdges = 3;
        }
    }

    void Update()
    {
        if (!pauseManager.isPaused)
        {
            this.currentTime += Time.deltaTime;
        }
    }

    void UpdateMaxEdges(int amount)
    {
        if (shapeManager.edgeNum > maxEdges)
            maxEdges = shapeManager.edgeNum;
    }

    void GameOver()
    {
        _EndGame();
        gameOverMenu.ShowGameOver();
    }

    void MaxEdge() //AKA win
    {
        _EndGame();
        gameOverMenu.ShowWin();
        //winMenu.EnableWinPanel(true);
    }

    void _EndGame()
    {
        Time.timeScale = 0;
        isGameOver = true;
        saveManager.SaveScore();
    }
}
