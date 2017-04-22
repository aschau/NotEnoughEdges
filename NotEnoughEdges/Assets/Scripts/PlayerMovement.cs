using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float size;
    public float bounce;
    public int health;
    private Rigidbody2D _rigidbody;
    private bool isInvincible = false;
    public float invincibleTime;
    private float invincibleTimer = 0.0f;
    public float terminalVelocity;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {
        transform.localScale = new Vector3(size, size, size);

        _rigidbody.gravityScale = speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
            Destroy(gameObject);

        if (invincibleTimer > 0)
        {
            invincibleTimer -= Time.deltaTime;
            Helper.phaseThruTags(gameObject, new List<string> { "Hazard" });
        }

        if (_rigidbody.velocity.y < terminalVelocity * -1)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, terminalVelocity * -1);
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Hazard"))
        {
            invincibleTimer = invincibleTime;

            Hazard colHazard = col.gameObject.GetComponent<Hazard>();

            health -= colHazard.damage;

            _rigidbody.AddForce((transform.position - col.transform.position).normalized * bounce);

            if (colHazard.ability == "Bounce")
                _rigidbody.AddForce((transform.position - col.transform.position).normalized * bounce);
        }
    }
}
