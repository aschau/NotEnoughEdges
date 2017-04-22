using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private GameObject theTarget;
    public float projectileSpeed;
    private Rigidbody2D playerRigidBody;

    void Awake()
    {
   
    }

    // Use this for initialization
    void Start ()
    {
        theTarget = GameObject.FindWithTag("Player");

        playerRigidBody = theTarget.GetComponent<Rigidbody2D>();

        transform.rotation = Quaternion.LookRotation(Vector3.forward, theTarget.transform.position - transform.position);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * projectileSpeed);
        transform.Translate(new Vector3(Mathf.Cos(transform.rotation.z * Mathf.PI/180) * playerRigidBody.velocity.y * 0.75f, 0, 0) * Time.deltaTime);
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        Destroy(gameObject);
    }
}
