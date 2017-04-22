using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    public float radius;
    private PolygonCollider2D col;

    private int edges = 3; //Do not use outside of edgeNum
    public int edgeNum //Use this to get and set collider's shape
    {
        get
        {
            return edges;
        }
        set
        {
            edges = value;
            ChangeShape(value);
        }
    } 
    
    public Sprite[] shapes;
    private SpriteRenderer currentShape;

    void Start ()
    {
        col = GetComponent<PolygonCollider2D>();
        currentShape = GetComponent<SpriteRenderer>();

        edgeNum = edgeNum;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GainEdge(1);
        }
    }

    public void GainEdge(int amount)
    {
        int tempNum = edgeNum + amount;

        if (tempNum >= 15) //Win the game, insert winning edge number here
        {
            Debug.Log("You won! :D");
        }
        else
        {
            edgeNum = tempNum;
        }
    }

    public void LoseEdge(int amount)
    {
        int tempNum = edgeNum - amount;

        if (tempNum <= 3) //Lose the game
        {
            Debug.Log("You lost. :(");
        }
        else
        {
            edgeNum = tempNum;
        }
    }

    void ChangeShape (int vertNum)
    {
        Vector2[] polyPoints = new Vector2[vertNum];

        float rot = (2 * Mathf.PI) / vertNum; //Get the rotation between each point

        for (int i = 0; i < vertNum; i++) //Get the coordinates for each point
        {
            float totalRot = (rot * i) + (Mathf.PI / 2);
            Vector2 trigRot = new Vector2(Mathf.Cos(totalRot) / transform.localScale.x, Mathf.Sin(totalRot) / transform.localScale.y);

            polyPoints[i] = trigRot * radius;
        }

        //Make the shape
        col.points = polyPoints;
        if (vertNum - 3 < shapes.Length)
        {
            currentShape.sprite = shapes[vertNum - 3];
        }

        //Set offset for every odd edgeNum
        //If don't set offset then col and sprite won't line up.
        col.offset = Vector3.zero;
        if (edgeNum % 2 == 1)
        {
            //Debug.Log("Center of " + edgeNum + "= " + col.transform.InverseTransformPoint(col.bounds.center));
            col.offset = -col.transform.InverseTransformPoint(col.bounds.center);
        }
    }
}
