using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    public float speed;
    public int damage;
    public static float timer = 10;
    public string ability = "None";

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, timer);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
	}
}
