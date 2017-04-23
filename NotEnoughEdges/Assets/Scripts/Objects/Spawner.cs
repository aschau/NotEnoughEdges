using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public List<GameObject> enemyList;
    public List<float> probList;
    public float rate;
    public float deltaRate;
    public Vector2 range;
    public static float highEnd = 0;
    public static float lowEnd = 0;
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

    }
	
	// Update is called once per frame
	void Update ()
    {
        highEnd = transform.position.y;

        Debug.Log(highEnd - lowEnd);

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
	}

    public static void resetSpawn()
    {
        lowEnd = highEnd;
    }
}
