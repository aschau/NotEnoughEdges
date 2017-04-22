﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour {
    private Light lt;
    private AudioSource soundEffect;
	// Use this for initialization
	void Start () {
        lt = this.transform.parent.GetComponent<Light>();
        this.soundEffect = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        lt.enabled = true;
        lt.color = new Color((float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f, 1);
        this.soundEffect.Play();
    }
}
