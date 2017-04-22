using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pausePanel;

    public void EnablePanel(bool active)
    {
        pausePanel.SetActive(active);
    }

    public void Resume()
    {
        MasterGameManager.instance.pauseManager.EnablePause(false);
    }
}
