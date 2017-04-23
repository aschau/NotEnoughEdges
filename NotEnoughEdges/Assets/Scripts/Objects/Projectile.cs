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

        transform.rotation = Quaternion.LookRotation(Vector3.forward, theTarget.transform.position - transform.position + new Vector3(0, playerRigidBody.velocity.y * 1.5f, 0));
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * projectileSpeed);
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Drawing")) // Bounce back if hits drawn line
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + 180);
            Destroy(gameObject, 5);
        }
        else
            Destroy(gameObject);
    }
}
