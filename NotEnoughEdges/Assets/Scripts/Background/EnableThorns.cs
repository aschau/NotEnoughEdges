using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableThorns : MonoBehaviour {
    private PlayerMovement playerMovement;
    private GameObject[] thorns;
    private bool activated = false;

    private void Awake()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        thorns = GameObject.FindGameObjectsWithTag("Thorns");
        Debug.Log(thorns.Length);
    }

    // Use this for initialization
    void Start ()
    {
        foreach (GameObject g in thorns)
            g.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (playerMovement.wallsHurt && !activated)
        {
            foreach (GameObject g in thorns)
                g.SetActive(true);
            activated = true;
        }
	}
}
