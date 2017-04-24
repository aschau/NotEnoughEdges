using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public List<GameObject> enemyList;
    private List<float> probList;
    public float rate;
    public float deltaRate;
    public Vector2 range;
    public static float highEnd;
    public static float lowEnd;
    private GameObject player;
    private ShapeManager sm;
    public float distance;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        sm = player.GetComponent<ShapeManager>();
    }

    // Use this for initialization
    void Start ()
    {
        lowEnd = highEnd = transform.position.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        highEnd = transform.position.y;

        if (player.transform.position.y - transform.position.y < distance) // Hold spawner below player
            transform.position = new Vector3(transform.position.x, player.transform.position.y - distance, transform.position.z);

        if (highEnd - lowEnd <= -100 / (rate + (sm.edgeNum - 3) * deltaRate))
        {
            resetSpawn();

            float selection = Random.Range(0.0f, Helper.sumList(probList));
            GameObject toSpawn = enemyList[0];

            for (int i = 0; i < enemyList.Count; ++i) // Determine which enemy to spawn
            {
                if (selection < probList[i])
                {
                    toSpawn = enemyList[i];
                    break;
                }

                selection -= probList[i];
            }

            Instantiate(toSpawn, transform.position + new Vector3(Random.Range(range.x, range.y), 0, 0), Quaternion.identity);
        }

        switch (sm.edgeNum)
        {
            case 3:
                probList = new List<float> { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.5f };
                break;
            case 4:
                probList = new List<float> { 0.9f, 0.4f, 0.0f, 0.0f, 0.0f, 0.0f, 0.5f };
                break;
            case 5:
                probList = new List<float> { 0.8f, 0.6f, 0.0f, 0.0f, 0.0f, 0.0f, 0.5f };
                break;
            case 6:
                probList = new List<float> { 0.7f, 0.8f, 0.3f, 0.1f, 0.0f, 0.0f, 0.6f };
                break;
            case 7:
                probList = new List<float> { 0.6f, 1.0f, 0.4f, 0.2f, 0.2f, 0.0f, 0.7f };
                break;
            case 8:
                probList = new List<float> { 0.5f, 1.2f, 0.5f, 0.3f, 0.4f, 1.0f, 0.8f };
                break;
            case 9:
                probList = new List<float> { 0.4f, 1.4f, 0.6f, 0.4f, 0.6f, 1.5f, 0.9f };
                break;
            case 10:
                probList = new List<float> { 0.3f, 1.6f, 0.7f, 1.5f, 0.8f, 2.0f, 1.0f };
                break;
        }
	}

    public static void resetSpawn()
    {
        lowEnd = highEnd;
    }
}
