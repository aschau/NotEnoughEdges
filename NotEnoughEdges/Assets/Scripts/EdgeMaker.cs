using UnityEngine;

public class EdgeMaker : MonoBehaviour
{
    public EdgeCollider2D drawnEdgePrefab;
    private EdgeCollider2D currentEdge;
    private Vector2[] currentPoints = new Vector2[2];
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentEdge = Instantiate(drawnEdgePrefab);
            currentEdge.transform.SetParent(Camera.main.transform);
            
            currentPoints[0] = GetLocalMousePos();
        }
        if (Input.GetMouseButton(0))
        {
            currentPoints[1] = GetLocalMousePos();
            
            Vector3[] currentPointsV3 = System.Array.ConvertAll<Vector2,Vector3>(currentPoints, Vector2to3);
            LineRenderer lineRenderer = currentEdge.GetComponent<LineRenderer>();
            lineRenderer.SetPositions(currentPointsV3);
            lineRenderer.sortingLayerName = "Foreground";
        }
        if (Input.GetMouseButtonUp(0))
        {
            currentPoints[1] = GetLocalMousePos();

            currentEdge.transform.SetParent(null);
            currentEdge.points = currentPoints;

            Vector3[] currentPointsV3 = System.Array.ConvertAll<Vector2, Vector3>(currentPoints, Vector2to3);
            LineRenderer lineRenderer = currentEdge.GetComponent<LineRenderer>();
            lineRenderer.SetPositions(currentPointsV3);
            lineRenderer.sortingLayerName = "Foreground";
        }
    }

    Vector2 GetWorldMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector2 GetLocalMousePos()
    {
        return currentEdge.transform.InverseTransformPoint(GetWorldMousePos());
    }

    Vector3 Vector2to3 (Vector2 v)
    {
        return (Vector3) v;
    }
}
