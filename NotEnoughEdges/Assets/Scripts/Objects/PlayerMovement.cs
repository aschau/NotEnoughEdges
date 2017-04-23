using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float gravity;
    public float size;
    public float bounce;
    public float invincibleTime;
    public float terminalVelocity;
    public float deltaTerminal;
    public float deltaGravity;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private ShapeManager _shapemanager;
    private float invincibleTimer = 0.0f;
    public static Color currentColor;
    //private Vector2 originalVelocity;
    //private float originalAngularVelocity;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _shapemanager = GetComponent<ShapeManager>();
    }

    // Use this for initialization
    void Start ()
    {
        transform.localScale = new Vector3(size, size, size);

        //MasterGameManager.instance.pauseManager.onPause += FreezeMovement;
	}
	
	// Update is called once per frame
	void Update ()
    {
        _rigidbody.gravityScale = gravity + (_shapemanager.edgeNum - 3) * deltaGravity;

        if (invincibleTimer > 0) // Invulnerability frames
        {
            invincibleTimer -= Time.deltaTime;   
        }

        if (invincibleTimer <= 0 && LayerMask.LayerToName(gameObject.layer) == "Invulnerable") // Lose invulnerability
            gameObject.layer = LayerMask.NameToLayer("Default");

        if (_rigidbody.velocity.y < (terminalVelocity + ((_shapemanager.edgeNum - 3) * deltaTerminal)) * -1) // Enforce terminal velocity
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, terminalVelocity * -1);

        currentColor = new Color(1, (7 - (_shapemanager.edgeNum - 3)) / 7.0f, (7 - (_shapemanager.edgeNum - 3)) / 7.0f);
        if (invincibleTimer <= 0)
            _spriteRenderer.color = currentColor;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Hazard"))
        {
            Hazard colHazard = col.gameObject.GetComponent<Hazard>();

            if (colHazard.damage > 0)
            {
                invincibleTimer = invincibleTime; // Become invulnerable
                StartCoroutine(Blink(invincibleTime, 0.2f));
                gameObject.layer = LayerMask.NameToLayer("Invulnerable");

                _shapemanager.LoseEdge(colHazard.damage); // Lose edges
            }

            //      _rigidbody.AddForce((transform.position - col.transform.position).normalized * bounce);

            if (colHazard.ability == "Bounce") // Bounce harder if hazard hit induces bounce
                _rigidbody.AddForce((transform.position - col.transform.position).normalized * bounce);
        }

        if (col.gameObject.CompareTag("Ceiling"))
            _shapemanager.edgeNum = 0;

        if (col.gameObject.CompareTag("Wall") && invincibleTimer <= 0)
        {
            invincibleTimer = invincibleTime; // Become invulnerable
            StartCoroutine(Blink(invincibleTime, 0.2f));
            gameObject.layer = LayerMask.NameToLayer("Invulnerable");

            _shapemanager.LoseEdge(1); // Lose edges
        }
    }

    //void OnDestroy()
    //{
    //    MasterGameManager.instance.pauseManager.onPause -= FreezeMovement;
    //}

    //void FreezeMovement(bool isPaused)
    //{
    //    if (isPaused)
    //    {
    //        this.originalVelocity = this._rigidbody.velocity;
    //        this.originalAngularVelocity = this._rigidbody.angularVelocity;
    //        this._rigidbody.isKinematic = true;
    //        this._rigidbody.velocity = Vector2.zero;
    //        this._rigidbody.angularVelocity = 0;
    //    }

    //    else
    //    {
    //        this._rigidbody.isKinematic = false;
    //        this._rigidbody.velocity = this.originalVelocity;
    //        this._rigidbody.angularVelocity = this.originalAngularVelocity;
    //    }
    //}

    IEnumerator Blink(float time, float blinkInterval)
    {
        for (float timeElapsed = 0f; timeElapsed <= time; timeElapsed += Time.deltaTime)
        {
            float fragment = timeElapsed % (blinkInterval * 2);
            if (fragment < blinkInterval)
                _spriteRenderer.color = Color.clear;
            else
                _spriteRenderer.color = currentColor;
            yield return new WaitForEndOfFrame();
        }
        _spriteRenderer.color = currentColor;
    }
}
