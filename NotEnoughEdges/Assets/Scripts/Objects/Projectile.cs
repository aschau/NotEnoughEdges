using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private GameObject theTarget;
    public float projectileSpeed;

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        theTarget = GameObject.FindWithTag("Player");

        transform.rotation = Quaternion.LookRotation(Vector3.forward, theTarget.transform.position - transform.position);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * projectileSpeed);
	}
}
