using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private GameObject theTarget;
    public float projectileSpeed;
    private PlayerMovement _playermovement;

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        theTarget = GameObject.FindWithTag("Player");

        _playermovement = theTarget.GetComponent<PlayerMovement>();

        transform.rotation = Quaternion.LookRotation(Vector3.forward, theTarget.transform.position - transform.position);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * projectileSpeed);
        transform.Translate(new Vector3(Mathf.Cos(transform.rotation.z * Mathf.PI/180) * -2, 0, 0) * Time.deltaTime);
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        Destroy(gameObject);
    }
}
