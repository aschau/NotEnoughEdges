using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAnimation : MonoBehaviour {
    private Animator anim;
    private GameObject player;
    private Rigidbody2D playerRB;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(this.transform.position, this.player.transform.position) < 3f && this.playerRB.velocity.y < 2f)
        {
            this.anim.Play("Impact");
        }
    }
}
