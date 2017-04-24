using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    private int topScoreNum = 3;
    public List<KeyValuePair<int, float>> hiscoreList { get; private set; }//= new List<KeyValuePair<int, float>>();

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

                if (PlayerPrefs.HasKey(edgeKey) && PlayerPrefs.HasKey(timeKey))
                {
                    PlayerPrefs.DeleteKey(edgeKey);
                    PlayerPrefs.DeleteKey(timeKey);
                    Debug.LogFormat("Deleting EdgeKey: {0} TimeKey{1}", edgeKey, timeKey);
                }
            }
        }
    }

    public void SaveScore()
    {
        float timeScore = MasterGameManager.instance.bestTime;
        int edgeScore = MasterGameManager.instance.maxEdges;

        KeyValuePair<int, float> newScore = new KeyValuePair<int, float>(edgeScore, timeScore);

        hiscoreList.Add(newScore);

        hiscoreList.Sort(CompareScore);

        for (int i = 0; i < hiscoreList.Count; i++)
        {
            string edgeKey = string.Format("@LeaderBoard: Edge Score #{0}", i);
            string timeKey = string.Format("@LeaderBoard: Time Score #{0}", i);
            int edgeValue = hiscoreList[i].Key;
            float timeValue = hiscoreList[i].Value;

            PlayerPrefs.SetInt(edgeKey, edgeValue);
            PlayerPrefs.SetFloat(timeKey, timeValue);
            //Debug.LogFormat("Saving Score #{0}: Edges={1}, Time={2}", i, edgeValue, timeValue);
        }

        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        hiscoreList = new List<KeyValuePair<int, float>>();

        for (int i = 0; i < topScoreNum; i++)
        {
            string edgeKey = string.Format("@LeaderBoard: Edge Score #{0}", i);
            string timeKey = string.Format("@LeaderBoard: Time Score #{0}", i);

            if (PlayerPrefs.HasKey(edgeKey) && PlayerPrefs.HasKey(timeKey))
            {
                int edgeScore = PlayerPrefs.GetInt(edgeKey);
                float timeScore = PlayerPrefs.GetFloat(timeKey);
                hiscoreList.Add(new KeyValuePair<int, float>(edgeScore, timeScore));
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
