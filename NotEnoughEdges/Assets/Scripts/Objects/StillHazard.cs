using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillHazard : MonoBehaviour {
    private GameObject theTarget;
    public GameObject projectile;
    public float stillTime;
    public float fireRate;
    private float stillTimer = 0.0f;
    private bool isClose = false;
    private float fireTimer = 0.0f;

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
        if (theTarget.transform.position.y - transform.position.y < 3)
            isClose = true;

        if (stillTimer < stillTime && isClose) // Hold position below player for a few seconds
        {
            stillTimer += Time.deltaTime;

            if (theTarget.transform.position.y - transform.position.y < 3)
                transform.position = new Vector3(transform.position.x, theTarget.transform.position.y - 3, transform.position.z);

            fireTimer += Time.deltaTime;

            if (fireTimer > 1/fireRate) // Fire projectile
            {
                fireTimer = 0;
                Instantiate(projectile, transform.position + Vector3.up * 0.8f, Quaternion.identity);
            }
        }
	}
}
