using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    public float speed;
    public int damage;
    public static float timer = 10;
    public string ability = "None";

    private Rigidbody2D _rigidbody;
    private Vector2 originalVelocity;
    private float originalAngularVelocity;
    private Transform player;
    private Animator anim;
    //private bool animating = false;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        this.anim = GetComponentInChildren<Animator>();
    }

    // Use this for initialization
    void Start ()
    {
        MasterGameManager.instance.pauseManager.onPause += FreezeMovement;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y - player.position.y > 10)
            Destroy(gameObject);

        transform.Translate(Vector3.up * Time.deltaTime * speed);
        
        if (this.ability == "Bounce")
        {
            if (Vector3.Distance(this.transform.position, this.player.transform.position) < 2f && this.player.GetComponent<Rigidbody2D>().velocity.y < 2f)
            {
                this.anim.Play("Bounce Collision");
            }
        }
	}

    void OnDestroy()
    {
        MasterGameManager.instance.pauseManager.onPause -= FreezeMovement;
    }

    void FreezeMovement(bool isPaused)
    {
        if (isPaused)
        {
            this.originalVelocity = this._rigidbody.velocity;
            this.originalAngularVelocity = this._rigidbody.angularVelocity;
            this._rigidbody.isKinematic = true;
            this._rigidbody.velocity = Vector2.zero;
            this._rigidbody.angularVelocity = 0;
        }

        else
        {
            this._rigidbody.isKinematic = false;
            this._rigidbody.velocity = this.originalVelocity;
            this._rigidbody.angularVelocity = this.originalAngularVelocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
}
