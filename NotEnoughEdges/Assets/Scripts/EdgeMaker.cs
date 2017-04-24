using UnityEngine;

public class EdgeMaker : MonoBehaviour
{
    public EdgeCollider2D drawnEdgePrefab;
    public Color drawingColor, finalColor;
    private EdgeCollider2D currentEdge;
    private LineRenderer edgeLine;
    private Vector2[] currentPoints = new Vector2[2];

    void Awake()
    {
        Debug.Log(this.gameObject.name);
    }
    
    void Update ()
    {
        if (!MasterGameManager.instance.pauseManager.isPaused && !MasterGameManager.instance.isGameOver)
        {
            if (Input.GetMouseButtonDown(0)) //Start edge
            {
                currentEdge = Instantiate(drawnEdgePrefab);
                currentEdge.transform.SetParent(Camera.main.transform);

                edgeLine = currentEdge.GetComponent<LineRenderer>();

                currentPoints[0] = GetLocalMousePos();
            }
            if (Input.GetMouseButton(0)) //Update edge
            {
                currentPoints[1] = GetLocalMousePos();

                Vector3[] currentPointsV3 = System.Array.ConvertAll<Vector2, Vector3>(currentPoints, Vector2to3);
                edgeLine.SetPositions(currentPointsV3);

                edgeLine.material.SetColor("_TintColor", drawingColor);
                edgeLine.sortingLayerName = "Foreground";
            }
            if (Input.GetMouseButtonUp(0)) //End edge
            {
                currentPoints[1] = GetLocalMousePos();

                currentEdge.transform.SetParent(null);
                currentEdge.points = currentPoints;

                Vector3[] currentPointsV3 = System.Array.ConvertAll<Vector2, Vector3>(currentPoints, Vector2to3);
                edgeLine.SetPositions(currentPointsV3);
                edgeLine.material.SetColor("_TintColor", finalColor);
                edgeLine.sortingLayerName = "Foreground";

                currentEdge.GetComponent<Selfdestruct>().StartDestruct();
                currentEdge = null;
                edgeLine = null;
            }
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
