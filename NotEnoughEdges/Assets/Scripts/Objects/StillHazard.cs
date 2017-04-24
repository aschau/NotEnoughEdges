using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillHazard : MonoBehaviour {
    public GameObject projectile1;
    public GameObject projectile2;
    public float stillTime;
    public float fireRate;
    private GameObject theTarget;
    private float stillTimer = 0.0f;
    private bool isClose = false;
    private float fireTimer = 0.0f;
    private Rigidbody2D playerRigidBody;
    private int numOfFires = 0;
    private Animator _animator;

    void Awake()
    {
        theTarget = GameObject.FindWithTag("Player");

        playerRigidBody = theTarget.GetComponent<Rigidbody2D>();

        _animator = GetComponentInChildren<Animator>();
    }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (theTarget.transform.position.y - transform.position.y < 3)
            isClose = true;

        if (stillTimer < stillTime && isClose) // Hold position below player for a few seconds
        {
            stillTimer += Time.deltaTime;

            if (theTarget.transform.position.y - transform.position.y < 3)
                transform.position = new Vector3(transform.position.x, theTarget.transform.position.y - 3, transform.position.z);

            fireTimer += Time.deltaTime;

            if (fireTimer > 1/fireRate) // Fire projectile
            {
                fireTimer = 0;
                Fire();
            }
        }

        transform.rotation = Quaternion.LookRotation(Vector3.forward, theTarget.transform.position - transform.position);
    }

    void Fire ()
    {
        if (numOfFires == 0)
        {
            ++numOfFires;
            _animator.Play("1st Shot Part 1");
            while (_animator.GetCurrentAnimatorStateInfo(1).IsName("1st Shot Part 1"));
            Instantiate(projectile1, transform.position, Quaternion.identity);
            _animator.Play("1st Shot Part 2");
            while (_animator.GetCurrentAnimatorStateInfo(1).IsName("1st Shot Part 2"));
            _animator.Play("After 1st Shot");
        }
        else if (numOfFires == 1)
        {
            ++numOfFires;
            _animator.Play("2nd Shot Part 1");
            while (_animator.GetCurrentAnimatorStateInfo(1).IsName("2nd Shot Part 1"));
            Instantiate(projectile2, transform.position, Quaternion.identity);
            _animator.Play("2nd Shot Part 2");
        }
    }
}
