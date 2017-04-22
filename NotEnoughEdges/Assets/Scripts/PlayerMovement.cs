using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float size;
    public float bounce;
    public int health;

	// Use this for initialization
	void Start ()
    {
        transform.localScale = new Vector3(size, size, size);

        GetComponent<Rigidbody2D>().gravityScale = speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
            Destroy(gameObject);
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Hazard"))
        {
            health -= col.gameObject.GetComponent<Hazard>().damage;

            GetComponent<Rigidbody2D>().AddForce((transform.position - col.transform.position).normalized * bounce);

            if (col.gameObject.GetComponent<Hazard>().ability == "Bounce")
                GetComponent<Rigidbody2D>().AddForce((transform.position - col.transform.position).normalized * bounce * 2);
        }
    }
}
