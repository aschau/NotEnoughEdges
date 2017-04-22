using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    public float speed = 1.0f;
    public int damage = 1;
    public static double upperBound = 100.0;
    public string ability = "None";

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y > upperBound)
            Destroy(gameObject);
	}
}
