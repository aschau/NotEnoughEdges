using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float size;
    public float bounce;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    public float invincibleTime;
    private float invincibleTimer = 0.0f;
    public float terminalVelocity;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (invincibleTimer > 0) // Invulnerability frames
        {
            invincibleTimer -= Time.deltaTime;   
        }

        if (invincibleTimer <= 0 && LayerMask.LayerToName(gameObject.layer) == "Invulnerable")
            gameObject.layer = LayerMask.NameToLayer("Default");

        if (_rigidbody.velocity.y < terminalVelocity * -1) // 
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, terminalVelocity * -1);
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Hazard"))
        {
            invincibleTimer = invincibleTime;
            StartCoroutine(Blink(invincibleTime, 0.2f));
            gameObject.layer = LayerMask.NameToLayer("Invulnerable");

            Hazard colHazard = col.gameObject.GetComponent<Hazard>();
            ShapeManager sm = GetComponent<ShapeManager>();

            sm.LoseEdge(colHazard.damage);

            _rigidbody.AddForce((transform.position - col.transform.position).normalized * bounce);

            if (colHazard.ability == "Bounce")
                _rigidbody.AddForce((transform.position - col.transform.position).normalized * bounce);
        }
    }

    IEnumerator Blink(float time, float blinkInterval)
    {
        for (float timeElapsed = 0f; timeElapsed <= time; timeElapsed += Time.deltaTime)
        {
            float fragment = timeElapsed / (blinkInterval * 2);
            if (fragment < blinkInterval)
                _spriteRenderer.color = Color.clear;
            else
                _spriteRenderer.color = Color.white;
            yield return new WaitForEndOfFrame();
        }
    }
}
