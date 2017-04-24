using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    public bool followX = false;
    private GameObject player;
    private Vector3 distance;
    void Awake ()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.distance = this.transform.position - this.player.transform.position;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!followX)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.player.transform.position.y + this.distance.y, this.transform.position.z);
        }

        else
        {
            this.transform.position = new Vector3(this.player.transform.position.x + this.distance.x, this.player.transform.position.y + this.distance.y, this.transform.position.z);
        }
	}
}
