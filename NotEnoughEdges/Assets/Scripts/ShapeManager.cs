using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    public float radius;
    private PolygonCollider2D col;
    private int edges = 3;
    public int edgeNum
    {
        get
        {
            return edges;
        }
        set
        {
            ChangeShape(value);
            edges = value;
        }
    }

	
	void Start ()
    {
        col = GetComponent<PolygonCollider2D>();
        ChangeShape(edges);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ChangeShape(++edges);
        }
    }

    void ChangeShape (int vertNum)
    {
        //int vertNum = 5;
        Vector2[] polyPoints = new Vector2[vertNum];

        float rot = (2 * Mathf.PI) / vertNum;

        for (int i = 0; i < vertNum; i++)
        {
            float totalRot = (rot * i) + (Mathf.PI / 2);
            Vector2 trigRot = new Vector2(Mathf.Cos(totalRot) / transform.localScale.x, Mathf.Sin(totalRot) / transform.localScale.y);

            polyPoints[i] = trigRot * radius;
        }
        col.points = polyPoints;
    }
}
