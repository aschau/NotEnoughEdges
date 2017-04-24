using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public delegate void OnPause(bool isPaused);
    public event OnPause onPause = delegate { };

    public bool isPaused = false;

    PauseMenu pauseMenu;

    void Awake()
    {
        MasterGameManager.instance.sceneManager.onSceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(string sceneName)
    {
        if (sceneName != "Main Menu")
        {
            pauseMenu = GameObject.Find("Pause Menu").GetComponent<PauseMenu>();
            TogglePause(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(!isPaused);
        }
    }

    public void TogglePause(bool active)
    {
        if (!MasterGameManager.instance.isGameOver)
        {
            Time.timeScale = active ? 0 : 1;

            if (pauseMenu != null)
            {
                pauseMenu.EnablePausePanel(active);
            }

            isPaused = active;

            onPause(active);
        }
    }
}
