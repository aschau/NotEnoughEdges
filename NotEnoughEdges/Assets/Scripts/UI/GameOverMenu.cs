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
        float timeScore = MasterGameManager.instance.bestTime;
        yourScore.text = string.Format("Your Score: \t {0} Edges \t {1} ({2})", edgeScore, Helper.formatTime(timeScore), MasterGameManager.instance.sceneManager.currentScene.Substring(0, 4));

        List<KeyValuePair<int, float>> hiscoreList = MasterGameManager.instance.saveManager.hiscoreList;
        Dictionary<int, string> difficultyList = MasterGameManager.instance.saveManager.difficultyList;

        for (int i = 0; i < Mathf.Min(hiscoreList.Count, hiscoreTextList.Length); i++)
        {

            Text scoreText = hiscoreTextList[i];
            scoreText.text = string.Format("#{0}) \t {1} Edges \t {2} {3}", i + 1, hiscoreList[i].Key, Helper.formatTime(hiscoreList[i].Value), difficultyList[i]);
        }
    }
}
