using UnityEngine;

public class Selfdestruct : MonoBehaviour
{
    public bool destructOnStart = false;
    public float lifespan;

	void Start ()
    {
        if (destructOnStart)
        {
            StartDestruct();
        }
	}

    public void StartDestruct()
    {
        Destroy(gameObject, lifespan);
    }
}
