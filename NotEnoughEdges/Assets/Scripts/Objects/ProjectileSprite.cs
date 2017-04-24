using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSprite : MonoBehaviour {
    private Projectile _projectile;

    void Awake()
    {
        _projectile = GetComponentInParent<Projectile>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, (transform.position - _projectile.theTarget.transform.position) - new Vector3(0, 0, transform.parent.rotation.z));
	}
}
