﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //private float currentTime = 0f; //in seconds
    private Text textTimer;

    // Use this for initialization
    void Start()
    {
        textTimer = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!SceneControl.paused)
        if (!MasterGameManager.instance.pauseManager.isPaused)
        {
            //currentTime += Time.deltaTime;
            textTimer.text = Helper.formatTime(MasterGameManager.instance.currentTime);
        }
    }
}