using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    public delegate void OnEdgeChange(int edgeDelta);
    public event OnEdgeChange onEdgeChange = delegate { };

    public float radius;
    private PolygonCollider2D col;
    private PlayerHealth playerHealth;
    private ParticleSystem.EmissionModule playerEmmiter;

    private int winNum = 11;
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

    void Awake()
    {
        playerEmmiter = GameObject.FindWithTag("Emmiter").GetComponent<ParticleSystem>().emission;
    }

    void Start()
    {
        col = GetComponent<PolygonCollider2D>();
        currentShape = GetComponent<SpriteRenderer>();
        playerHealth = this.GetComponent<PlayerHealth>();

        edgeNum = edgeNum;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ChangeEdge(1);
            //GainEdge(1);
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            ChangeEdge(-1);
            //LoseEdge(1);
        }

        playerEmmiter.rateOverTime = 100 * (edgeNum - 2)/8;
    }

    public void ChangeEdge(int amount)
    {
        int tempNum = edgeNum + amount;

        if (tempNum >= winNum)  //Win the game, insert winning edge number here
        {
            playerHealth.Win();
            edgeNum = winNum;
        }
        else if (tempNum < 3)   //Lose the game
        {
            playerHealth.Die();
            edgeNum = 3;
        }
        else
        {
            edgeNum = tempNum;
        }

        onEdgeChange(amount);
    }
    //public void GainEdge(int amount)
    //{
    //    int tempNum = edgeNum + amount;

    //    if (tempNum >= winNum) //Win the game, insert winning edge number here
    //    {
    //        playerHealth.Win();
    //        //Debug.Log("You won! :D");
    //        edgeNum = winNum;
    //    }
    //    else
    //    {
    //        edgeNum = tempNum;
    //    }

    //    onEdgeChange(amount);
    //}

    //public void LoseEdge(int amount)
    //{
    //    int tempNum = edgeNum - amount;

    //    if (tempNum < 3) //Lose the game
    //    {
    //        playerHealth.Die();
    //        //Debug.Log("You lost. :(");
    //        edgeNum = 3;
    //    }
    //    else
    //    {
    //        edgeNum = tempNum;
    //    }

    //    onEdgeChange(amount);
    //}

    void ChangeShape(int vertNum)
    {
        Spawner.resetSpawn();

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

        //Set offset for every odd edgeNum
        //If don't set offset then col and sprite won't line up.
        /*col.offset = Vector3.zero;
        if (edgeNum % 2 == 1)
        {
            //Debug.Log("Center of " + edgeNum + "= " + col.transform.InverseTransformPoint(col.bounds.center));
            col.offset = -col.transform.InverseTransformPoint(col.bounds.center);
        }*/

        if (vertNum - 3 < shapes.Length)
        {
            currentShape.sprite = shapes[vertNum - 3];
        }

        /*Destroy(col);
        col = gameObject.AddComponent<PolygonCollider2D>();*/
    }
}
