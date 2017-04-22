using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillHazard : MonoBehaviour {
    private GameObject theTarget;
    public float stillTimer;
    public float fireRate;

    void Awake()
    {
        theTarget = GameObject.FindWithTag("Player");
    }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
