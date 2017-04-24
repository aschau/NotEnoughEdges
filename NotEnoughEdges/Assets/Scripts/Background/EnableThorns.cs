using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableThorns : MonoBehaviour {
    private PlayerMovement playerMovement;
    private GameObject[] thorns;
    private bool activated = false;

    private void Awake()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        thorns = GameObject.FindGameObjectsWithTag("Thorns");
    }

    // Use this for initialization
    void Start ()
    {
        foreach (GameObject g in thorns)
            g.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (playerMovement.wallsHurt && !activated)
        {
            StartCoroutine(ActivateThorns(1f));
        }
	}

    IEnumerator ActivateThorns(float activateTime)
    {
        List<SpriteRenderer> spriteList = new List<SpriteRenderer>();

        int i = 0;
        foreach (GameObject g in thorns)
        {
            g.SetActive(true);
            spriteList.Add(g.GetComponent<SpriteRenderer>());
            spriteList[i].color = Color.clear;
            i++;
        }

        activated = true;

        for (float timeElapsed = 0; timeElapsed < activateTime; timeElapsed += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, timeElapsed);

            foreach (SpriteRenderer sprite in spriteList)
            {
                sprite.color = new Color(1, 1, 1, alpha);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
