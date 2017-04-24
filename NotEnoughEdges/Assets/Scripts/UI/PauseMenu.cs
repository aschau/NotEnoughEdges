using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu {

    public GameObject pausePanel;
    public GameObject settingsPanel;

    public void EnablePausePanel(bool active)
    {
        pausePanel.SetActive(active);
        if (!active)
        {
            EnableSettingsPanel(false);
        }
    }

    public void EnableSettingsPanel(bool active)
    {
        settingsPanel.SetActive(active);
    }

    public void Continue()
    {
        MasterGameManager.instance.pauseManager.TogglePause(false);
    }

    public void Settings()
    {
        EnableSettingsPanel(true);
    }

    public void Pause()
    {
        MasterGameManager.instance.pauseManager.TogglePause(true);
    }
}
