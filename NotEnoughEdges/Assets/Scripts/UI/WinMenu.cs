using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : Menu
{
    public GameObject winPanel;

    public void EnableWinPanel(bool active)
    {
        winPanel.SetActive(active);
    }
}
