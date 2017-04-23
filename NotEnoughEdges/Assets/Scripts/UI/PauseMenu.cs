using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu {

    public GameObject pausePanel;
    public GameObject settingsPanel;

    public void EnablePausePanel(bool active)
    {
        pausePanel.SetActive(active);
    }

    public void EnableSettingsPanel(bool active)
    {
        settingsPanel.SetActive(active);
    }

    public void Continue()
    {
        MasterGameManager.instance.pauseManager.EnablePause(false);
    }

    public void Settings()
    {
        EnableSettingsPanel(true);
    }

    public void Pause()
    {
        MasterGameManager.instance.pauseManager.EnablePause(true);
    }
}
