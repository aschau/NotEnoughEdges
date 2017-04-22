using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public List<GameObject> enemyList;
    public List<float> probList;
    public float rate;
    public Vector2 range;
    private float timer = 0.0f;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player.transform.position.y - transform.position.y < 10)
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 10, transform.position.z);

        timer += Time.deltaTime;
        
        if (timer >= 60/rate)
        {
            timer = 0;
            float selection = Random.Range(0.0f, Helper.sumList(probList));
            GameObject toSpawn = enemyList[0];

            for (int i = 0; i < enemyList.Count; ++i)
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
}
