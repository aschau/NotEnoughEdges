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

    void OnSceneLoaded()
    {
        pauseMenu = GameObject.Find("Pause Menu").GetComponent<PauseMenu>();
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnablePause(!isPaused);
        }
    }

    public void EnablePause(bool active)
    {
        if (pauseMenu != null)
        {
            pauseMenu.EnablePausePanel(active);
        }

        isPaused = active;

        onPause(active);
    }
}
