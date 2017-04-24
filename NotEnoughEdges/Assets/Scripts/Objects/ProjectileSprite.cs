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
        transform.rotation = Quaternion.LookRotation(Vector3.forward, (_projectile.theTarget.transform.position - transform.position));
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
