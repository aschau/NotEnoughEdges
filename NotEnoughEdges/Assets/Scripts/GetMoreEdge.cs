using UnityEngine;

public class GetMoreEdge : MonoBehaviour
{
    public int amountGained;
    private Transform player;
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) //Hit player
        {
            //col.GetComponent<ShapeManager>().GainEdge(amountGained);
            col.GetComponent<ShapeManager>().ChangeEdge(amountGained);

            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (transform.position.y - player.position.y > 10)
            Destroy(gameObject);

    }
}
