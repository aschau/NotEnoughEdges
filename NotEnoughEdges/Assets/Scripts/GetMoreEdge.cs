using UnityEngine;

public class GetMoreEdge : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) //Hit player
        {
            col.GetComponent<ShapeManager>().GainEdge();

            Destroy(gameObject);
        }
    }
}
