using UnityEngine;

public class Selfdestruct : MonoBehaviour
{
    public float lifespan;

	void Start ()
    {
        Destroy(gameObject, lifespan);
	}
}
