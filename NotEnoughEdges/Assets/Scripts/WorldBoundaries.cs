using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoundaries : MonoBehaviour
{
    public Collider2D leftWall, rightWall;

    void Start()
    {
        leftWall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0));
        rightWall.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0));
        //Debug.Log(Camera.main.ScreenToWorldPoint());
    }
}
