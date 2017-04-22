using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour {
    private bool target = false;
    private GameObject theTarget;

    // Use this for initialization

    void Awake()
    {
        theTarget = GameObject.FindWithTag("Player");
    }

	// Update is called once per frame
	void Update ()
    {
        if (target)
            transform.rotation = Quaternion.LookRotation(gameObject.transform.position - theTarget.transform.position);
        else
            transform.rotation = Quaternion.identity;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            target = false;
    }
}
