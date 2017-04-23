using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : Menu
{
    public GameObject gameOverPanel;

    public void EnableGameOverPanel(bool active)
    {
        gameOverPanel.SetActive(active);
    }
}
