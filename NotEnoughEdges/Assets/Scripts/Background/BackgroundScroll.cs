using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour
{
    private SpriteRenderer background1, background2;
    private GameObject player;

    void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.background1 = GameObject.Find("Background 1").GetComponent<SpriteRenderer>();
        this.background2 = GameObject.Find("Background 2").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player.transform.position.y < this.background2.transform.position.y)
        {
            this.background1.transform.position = new Vector3(this.background2.transform.position.x,
                this.background2.transform.position.y - this.background2.bounds.size.y, this.background2.transform.position.z);
        }
        if (this.player.transform.position.y < this.background1.transform.position.y)
        {
            this.background2.transform.position = new Vector3(this.background1.transform.position.x,
                this.background1.transform.position.y - this.background1.bounds.size.y, this.background1.transform.position.z);
        }



    }
}