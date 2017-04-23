using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    Text edgeScore;
    ShapeManager shapeManager;

    void Awake()
    {
        MasterGameManager.instance.sceneManager.onSceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded()
    {
        edgeScore = GameObject.Find("Edge Score").GetComponent<Text>();
        shapeManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ShapeManager>();
        shapeManager.onEdgeChange += UpdateEdgeCount;
    }

    void UpdateEdgeCount(int edgeCount)
    {
        //Debug.Log(edgeCount);
        edgeScore.text = string.Format("Edges: {0}", edgeCount);
    }
}
