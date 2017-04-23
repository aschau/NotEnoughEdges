using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour {
    private bool target = true;
    private GameObject theTarget;
    public float targetSpeed;

    // Use this for initialization

    void Awake()
    {
        theTarget = GameObject.FindWithTag("Player");
    }

	// Update is called once per frame
	void Update ()
    {
        if (target)
            transform.Translate(new Vector3(theTarget.transform.position.x - transform.position.x, 0, 0).normalized * targetSpeed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            target = false;
    }
}
