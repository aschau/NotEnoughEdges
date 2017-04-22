using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public bool isPaused = false;
    PauseMenu pauseMenu;

    void Awake()
    {
        MasterGameManager.instance.sceneManager.onSceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded()
    {
        pauseMenu = GameObject.Find("PauseMenu").GetComponent<PauseMenu>();
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
        Time.timeScale = active ? 0 : 1;

        if (pauseMenu != null)
        {
            pauseMenu.EnablePanel(active);
        }

        isPaused = active;
    }
}
