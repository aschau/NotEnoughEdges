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
            ChangeShape(value);
            edges = value;
        }
    } 
    
    //public Sprite[] shapes;
    //private SpriteRenderer currentShape

    void Start ()
    {
        col = GetComponent<PolygonCollider2D>();
        ChangeShape(edgeNum);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GainEdge();
        }
    }

    public void GainEdge()
    {
        if (edgeNum == 15) //Win the game, insert winning edge number here
        {
            Debug.Log("You won! :D");
        }
        else
        {
            edgeNum++;
        }
    }

    public void LoseEdge()
    {
        if (edgeNum == 3) //Lose the game
        {
            Debug.Log("You lost. :(");
        }
        else
        {
            edgeNum--;
        }
    }

    void ChangeShape (int vertNum)
    {
        Vector2[] polyPoints = new Vector2[vertNum];

        float rot = (2 * Mathf.PI) / vertNum;

        for (int i = 0; i < vertNum; i++)
        {
            float totalRot = (rot * i) + (Mathf.PI / 2);
            Vector2 trigRot = new Vector2(Mathf.Cos(totalRot) / transform.localScale.x, Mathf.Sin(totalRot) / transform.localScale.y);

            polyPoints[i] = trigRot * radius;
        }

        col.points = polyPoints;
        //currentShape.sprite = shapes[vertNum - 3];
    }
}
