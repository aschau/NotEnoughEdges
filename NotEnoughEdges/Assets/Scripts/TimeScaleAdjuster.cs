using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleAdjuster : MonoBehaviour {
    private ParticleSystem ps;
	// Use this for initialization
	void Start () {
        this.ps = this.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0)
        {
            this.ps.Simulate(Time.unscaledDeltaTime, true, false);
        }

        else
        {
            this.ps.Simulate(Time.deltaTime, true, false);
        }


	}
}
