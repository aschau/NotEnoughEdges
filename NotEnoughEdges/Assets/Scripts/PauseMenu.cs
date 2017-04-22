using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pausePanel;

    public void EnablePanel(bool active)
    {
        pausePanel.SetActive(active);
    }

    public void Continue()
    {
        MasterGameManager.instance.pauseManager.EnablePause(false);
    }

    public void Restart()
    {
        MasterGameManager.instance.sceneManager.ReloadScene();
    }
}
