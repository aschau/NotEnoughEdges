using System.Collections.Generic;
using UnityEngine;

public class EdgeMaker : MonoBehaviour
{
    public EdgeCollider2D drawnEdgePrefab;
    private EdgeCollider2D currentEdge;
    private Vector2[] currentPoints = new Vector2[2];
	
	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(GetMousePos());
            currentEdge = Instantiate(drawnEdgePrefab);

            //Debug.Log(currentEdge.points[0]);
            currentPoints[0] = GetMousePos();
            //Debug.Log(currentEdge.points[0]);
        }
        if (Input.GetMouseButton(0))
        {
            //Debug.Log(GetMousePos());
            //Debug.Log(currentEdge.points[1]);
            currentPoints[1] = GetMousePos();
            //Debug.Log(currentEdge.points[1]);
            
            Vector3[] currentPointsV3 = System.Array.ConvertAll<Vector2,Vector3>(currentPoints, Vector2to3);
            currentEdge.GetComponent<LineRenderer>().SetPositions(currentPointsV3);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log(GetMousePos());
            //Debug.Log(currentEdge.points[1]);
            currentPoints[1] = GetMousePos();
            //Debug.Log(currentEdge.points[1]);

            currentEdge.points = currentPoints;
        }
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector3 Vector2to3 (Vector2 v)
    {
        return (Vector3) v;
    }
}
