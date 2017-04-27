using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    private int topScoreNum = 3;
    public List<KeyValuePair<int, float>> hiscoreList { get; private set; }//= new List<KeyValuePair<int, float>>();
    public Dictionary<int, string> difficultyList {get; private set; }

    void Start()
    {
        LoadScore();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            for (int i = 0; i < topScoreNum; i++)
            {
                string edgeKey = string.Format("@LeaderBoard: Edge Score #{0}", i);
                string timeKey = string.Format("@LeaderBoard: Time Score #{0}", i);
                string difficultyKey = string.Format("@LeaderBoard: Difficulty #{0}", i);

                if (PlayerPrefs.HasKey(edgeKey) && PlayerPrefs.HasKey(timeKey) && PlayerPrefs.HasKey(difficultyKey))
                {
                    PlayerPrefs.DeleteKey(edgeKey);
                    PlayerPrefs.DeleteKey(timeKey);
                    PlayerPrefs.DeleteKey(difficultyKey);
                    Debug.LogFormat("Deleting EdgeKey: {0} TimeKey{1}, Difficulty: {2}", edgeKey, timeKey, difficultyKey);
                }
            }
        }
    }

    public void SaveScore()
    {
        //difficultyList = new Dictionary<int, string>();

        float timeScore = MasterGameManager.instance.bestTime;
        int edgeScore = MasterGameManager.instance.maxEdges;

        KeyValuePair<int, float> newScore = new KeyValuePair<int, float>(edgeScore, timeScore);

        hiscoreList.Add(newScore);

        hiscoreList.Sort(CompareScore);

        bool highScore = false;

        for (int i = 0; i < hiscoreList.Count; i++)
        {
            string edgeKey = string.Format("@LeaderBoard: Edge Score #{0}", i);
            string timeKey = string.Format("@LeaderBoard: Time Score #{0}", i);
            string difficultyKey = string.Format("@LeaderBoard: Difficulty #{0}", i);
            int edgeValue = hiscoreList[i].Key;
            float timeValue = hiscoreList[i].Value;

            PlayerPrefs.SetInt(edgeKey, edgeValue);
            PlayerPrefs.SetFloat(timeKey, timeValue);

            if (hiscoreList[i].Key == edgeScore && hiscoreList[i].Value == timeScore && !highScore)
            {
                //PlayerPrefs.SetString(difficultyKey, MasterGameManager.instance.sceneManager.currentScene.Substring(0, 4));
                //difficultyList.Add(i, MasterGameManager.instance.sceneManager.currentScene.Substring(0, 4));
                addToDictionary(i, MasterGameManager.instance.sceneManager.currentScene.Substring(0, 4));
                highScore = true;
            }

            //Debug.LogFormat("Saving Score #{0}: Edges={1}, Time={2}", i, edgeValue, timeValue);
        }

        for (int i = 0; i < difficultyList.Count; i++ )
        {
            string difficultyKey = string.Format("@LeaderBoard: Difficulty #{0}", i);
            PlayerPrefs.SetString(difficultyKey, this.difficultyList[i]);
        }

        PlayerPrefs.Save();
    }

    private void addToDictionary(int key, string value)
    {
        if (difficultyList.ContainsKey(key))
        {
            string oldValue = difficultyList[key];
            addToDictionary(key + 1, oldValue);
            difficultyList.Remove(key);
        }
        difficultyList.Add(key, value);
    }

    public void LoadScore()
    {
        this.difficultyList = new Dictionary<int,string>();
        hiscoreList = new List<KeyValuePair<int, float>>();

        for (int i = 0; i < topScoreNum; i++)
        {
            string edgeKey = string.Format("@LeaderBoard: Edge Score #{0}", i);
            string timeKey = string.Format("@LeaderBoard: Time Score #{0}", i);
            string difficultyKey = string.Format("@LeaderBoard: Difficulty #{0}", i);

            if (PlayerPrefs.HasKey(edgeKey) && PlayerPrefs.HasKey(timeKey) && PlayerPrefs.HasKey(difficultyKey))
            {
                int edgeScore = PlayerPrefs.GetInt(edgeKey);
                float timeScore = PlayerPrefs.GetFloat(timeKey);

                hiscoreList.Add(new KeyValuePair<int, float>(edgeScore, timeScore));
                addToDictionary(i, PlayerPrefs.GetString(difficultyKey));
                //difficultyList.Add(i, PlayerPrefs.GetString(difficultyKey));
                //Debug.LogFormat("Loading Score #{0}: Edges={1}, Time={2}", i, edgeScore, timeScore);


            }
        }
    }

    int CompareScore(KeyValuePair<int, float> score1, KeyValuePair<int, float> score2)
    {
        int keyCompare = score2.Key.CompareTo(score1.Key);
        if (keyCompare == 0)
        {
            return score1.Value.CompareTo(score2.Value);
        }
        else
        {
            return keyCompare;
        }
    }
}
