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

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, timer);

        MasterGameManager.instance.pauseManager.onPause += FreezeMovement;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
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
}
