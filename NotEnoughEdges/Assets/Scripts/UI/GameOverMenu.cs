using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : Menu
{
    public GameObject gameOverPanel;
    public Text titleText;
    public Text yourScore;
    public Text[] hiscoreTextList;

    public void ShowGameOver()
    {
        //gameOverPanel.SetActive(true);
        EnablePanel(true, "Game Over");
    }

    public void ShowWin()
    {
        EnablePanel(true, "You Won!");
    }

    void EnablePanel(bool active, string title)
    {
        gameOverPanel.SetActive(active);

        titleText.text = title;

        int edgeScore = MasterGameManager.instance.maxEdges;
        float timeScore = MasterGameManager.instance.currentTime;
        yourScore.text = string.Format("Your Score: \t {0} Edges \t {1}", edgeScore, Helper.formatTime(timeScore));

        List<KeyValuePair<int, float>> hiscoreList = MasterGameManager.instance.saveManager.hiscoreList;
        for (int i = 0; i < Mathf.Min(hiscoreList.Count, hiscoreTextList.Length); i++)
        {
            Text scoreText = hiscoreTextList[i];
            scoreText.text = string.Format("#{0}) \t {1} Edges \t {2}", i + 1, hiscoreList[i].Key, Helper.formatTime(hiscoreList[i].Value));
        }
    }
}
