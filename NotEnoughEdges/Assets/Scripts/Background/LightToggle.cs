using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour {
    public float speed = 5f;
    private Light lt;
    private float intensity;
    private AudioSource soundEffect;
    private bool increasingIntensity;
	// Use this for initialization
	void Start () {
        this.lt = this.GetComponent<Light>();
        this.intensity = this.lt.intensity;
        this.soundEffect = this.GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
		if (this.lt.intensity > this.intensity/2 && !this.increasingIntensity)
        {
            this.lt.intensity -= Time.deltaTime * speed;
        }

        else
        {
            this.increasingIntensity = true;
            this.lt.intensity += Time.deltaTime * speed;
        }

        if (this.lt.intensity >= this.intensity && this.increasingIntensity)
        {
            this.increasingIntensity = false;
        }
	}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    lt.enabled = true;
    //    lt.color = new Color((float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f, (float)Random.Range(0, 255) / 255f, 1);
    //    this.soundEffect.Play();
    //}
}
